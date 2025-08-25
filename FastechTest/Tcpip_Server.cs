using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FastechTest
{
    public class Tcpip_Server
    {
        private TcpListener tcpListener;
        private CancellationTokenSource cancelTokenSource;
        private Task listenTask;

        private TcpClient connectedClient; // 단일 연결된 클라이언트
        private NetworkStream connectedStream;

        private int port;
        private string name;

        private readonly byte STX = 0x02;
        private readonly byte ETX = 0x03;

        //public event EventHandler<MessageReceivedEventArgs> MessageReceived;
        public event EventHandler<ClientConnectedEventArgs> ClientConnected;
        public event EventHandler<ClientDisconnectedEventArgs> ClientDisconnected;
        public ConcurrentQueue<string> ReceivedMessages = new ConcurrentQueue<string>();

        public bool IsListening => tcpListener != null;
        public bool IsClientConnected => connectedClient?.Connected ?? false;

        public Tcpip_Server()
        {
        }

        public async Task<bool> Start(int port, string name = "Server")
        {
            try
            {
                this.name = name;
                this.port = port;

                tcpListener = new TcpListener(IPAddress.Any, port);
                tcpListener.Start();

                cancelTokenSource = new CancellationTokenSource();
                listenTask = Task.Run(() => ListenAndHandleSingleClient(cancelTokenSource.Token));

                Console.WriteLine($"[{name}] Server started on port {port}, waiting for a single client.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{name}] Server start failed: {ex.Message}");
                return false;
            }
        }

        public void Stop()
        {
            cancelTokenSource?.Cancel();
            tcpListener?.Stop();
            DisconnectClient(); // 연결된 클라이언트가 있다면 끊습니다.

            Console.WriteLine($"[{name}] Server stopped.");
        }

        private async void ListenAndHandleSingleClient(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    if (connectedClient == null || !connectedClient.Connected)
                    {
                        Console.WriteLine($"[{name}] Waiting for a new client connection...");
                        TcpClient client = await tcpListener.AcceptTcpClientAsync();
                        connectedClient = client;
                        connectedStream = client.GetStream();

                        string clientId = client.Client.RemoteEndPoint.ToString();
                        Console.WriteLine($"[{name}] Client connected: {clientId}");
                        OnClientConnected(new ClientConnectedEventArgs(clientId, client.Client.RemoteEndPoint.ToString()));

                        // 메시지 수신 루프 시작 (이 클라이언트에 대해서만)
                        ReceiveLoop(token, clientId);
                    }
                    else
                    {
                        await Task.Delay(1000); // 이미 연결된 클라이언트가 있다면 잠시 대기
                    }
                }
                catch (ObjectDisposedException)
                {
                    // 리스너가 중지될 때 발생하는 예외는 무시합니다.
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[{name}] Error accepting client: {ex.Message}");
                    DisconnectClient();
                }
            }
        }

        private void ReceiveLoop(CancellationToken token, string clientId)
        {
            byte[] buffer = new byte[1024];
            while (!token.IsCancellationRequested && IsClientConnected && connectedClient.Client.RemoteEndPoint.ToString() == clientId) // 해당 클라이언트의 연결이 유지되는 동안
            {
                try
                {
                    if (!connectedStream.CanRead)
                    {
                        Thread.Sleep(10);
                        continue;
                    }

                    int bytesRead = connectedStream.Read(buffer, 0, buffer.Length);
                    if (bytesRead <= 0)
                    {
                        Console.WriteLine($"[{name}] Client {clientId} disconnected (read 0 bytes).");
                        DisconnectClient();
                        break;
                    }

                    string msg = Encoding.ASCII.GetString(buffer, 0, bytesRead).Trim();
                    Console.WriteLine($"[SERVER RECV from {clientId}] {msg}");
                    ReceivedMessages.Enqueue(msg);

                }
                catch (ObjectDisposedException)
                {
                    DisconnectClient();
                    break;
                }
                catch (System.IO.IOException ioEx)
                {
                    Console.WriteLine($"[{name}] Network error for {clientId}: {ioEx.Message}");
                    DisconnectClient();
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[{name}] ReceiveLoop for {clientId} failed: {ex.Message}");
                    DisconnectClient();
                    break;
                }
                Thread.Sleep(10);
            }
        }

        public void SendMessage(string message)
        {
            try
            {
                if (!IsClientConnected)
                {
                    Console.WriteLine($"[{name}] Cannot send message: No client connected.");
                    return;
                }

                byte[] body = Encoding.ASCII.GetBytes(message);
                byte[] packet = new byte[body.Length + 2];
                packet[0] = STX;
                Array.Copy(body, 0, packet, 1, body.Length);
                packet[packet.Length - 1] = ETX;

                connectedStream.Write(packet, 0, packet.Length); // 메시지 본문만 전송
                connectedStream.Flush(); // 버퍼 비우기

                Console.WriteLine($"[SEND to {(connectedClient?.Client?.RemoteEndPoint.ToString() ?? "N/A")}] {message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{name}] SendMessage failed: {ex.Message}");
                DisconnectClient();
            }
        }

        private void DisconnectClient()
        {
            if (connectedClient != null)
            {
                string clientId = connectedClient.Client.RemoteEndPoint.ToString();
                connectedStream?.Close();
                connectedClient?.Close();
                connectedStream = null;
                connectedClient = null;
                Console.WriteLine($"[{name}] Client disconnected: {clientId}");
                OnClientDisconnected(new ClientDisconnectedEventArgs(clientId));
            }
        }


        protected virtual void OnClientConnected(ClientConnectedEventArgs e)
        {
            ClientConnected?.Invoke(this, e);
        }

        protected virtual void OnClientDisconnected(ClientDisconnectedEventArgs e)
        {
            ClientDisconnected?.Invoke(this, e);
        }
    }

    // EventArgs 클래스는 동일하게 사용합니다.
    public class MessageReceivedEventArgs : EventArgs
    {
        public string ClientId { get; }
        public string Message { get; }

        public MessageReceivedEventArgs(string clientId, string message)
        {
            ClientId = clientId;
            Message = message;
        }
    }

    public class ClientConnectedEventArgs : EventArgs
    {
        public string ClientId { get; }
        public string RemoteEndPoint { get; }

        public ClientConnectedEventArgs(string clientId, string remoteEndPoint)
        {
            ClientId = clientId;
            RemoteEndPoint = remoteEndPoint;
        }
    }

    public class ClientDisconnectedEventArgs : EventArgs
    {
        public string ClientId { get; }

        public ClientDisconnectedEventArgs(string clientId)
        {
            ClientId = clientId;
        }
    }
}
