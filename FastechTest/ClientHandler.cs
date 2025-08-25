using System;
using System.Collections.Concurrent;
using System.Threading;

namespace FastechTest
{
    public class ClientHandler
    {
        //private readonly Client_RADIX client;
        private readonly Tcpip_Server Server_FasTech;
        // 외부 구독자를 위해 수신된 명령을 알리는 이벤트
        public event EventHandler<CommandReceivedEventArgs> CommandReceived;

        //// 외부에서 응답해야 할 명령 저장용 (필요시 다시 활성화)
        //private readonly ConcurrentQueue<string> pendingScanCommands = new ConcurrentQueue<string>();

        public ClientHandler(Tcpip_Server socketClient)
        {
            Server_FasTech = socketClient;

        }

        public void Run()
        {
            while (true)
            {
                // 서버로부터 받은 메시지 처리
                if (Server_FasTech.ReceivedMessages.TryDequeue(out string msg))
                {
                    HandleCommand(msg);
                }

                Thread.Sleep(10);
            }
        }

        private void HandleCommand(string command)
        {
            string commandType = "Unknown";
            string responseSent = string.Empty; // ClientHandler가 보낸 응답 메시지

            if (command == "[S]")
            {
                commandType = "S_Command";
                if (Global.Instance.System.Mode == CSystem.MODE.AUTO) Server_FasTech.SendMessage("GON");
                else Server_FasTech.SendMessage("GOFF");
                responseSent = "GON";
            }
            else if (command == "[T]")
            {
                commandType = "T_Command";
                Console.WriteLine("[스캔 요청 저장]");
            }
            else
            {
                commandType = "Error_Command";
                Server_FasTech.SendMessage("[ERROR] Unknown command");
                responseSent = "[ERROR] Unknown command";
            }

            // 이벤트 발생: 외부 구독자에게 명령 정보 전달
            OnCommandReceived(new CommandReceivedEventArgs(command, commandType, responseSent));
        }

        // 외부에서 수동으로 결과 전송하는 함수
        public void SendScanResult(string result)
        {
            Server_FasTech.SendMessage(result);
        }

        // CommandReceived 이벤트를 안전하게 발생시키는 헬퍼 메서드
        protected virtual void OnCommandReceived(CommandReceivedEventArgs e)
        {
            CommandReceived?.Invoke(this, e);
        }
    }

    // 명령 정보를 담는 커스텀 EventArgs 클래스
    public class CommandReceivedEventArgs : EventArgs
    {
        public string RawCommand { get; }      // 원본 수신 명령
        public string CommandType { get; }     // 파악된 명령 유형
        public string ResponseSent { get; }    // ClientHandler가 보낸 응답 메시지

        public CommandReceivedEventArgs(string rawCommand, string commandType, string responseSent)
        {
            RawCommand = rawCommand;
            CommandType = commandType;
            ResponseSent = responseSent;
        }
    }
}
