using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FastechTest
{
    public class IDevice
    {
        public Tcpip_Server Server { get; set; }
        public ClientHandler Clienthandler { get; set; }
        public CFastechServo ServoInfo { get; set; } = new CFastechServo();
        public bool bConnected = false;
        public bool INSP_Complete = false;
        public bool Client_Status = false;
        public bool Init()
        {
            try
            {
                Server = new Tcpip_Server();
                Server_Init();
                ServoInfo = ServoInfo.Load();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private async void Server_Init() // 반환 타입을 Task 또는 void로 변경해야 합니다. UI 이벤트 핸들러가 아니라면 Task를 권장.
        {

            if (!await Global.Instance.Device.Server.Start(9000, "VISION")) // 3000ms = 3초 타임아웃
            {
                return;
            }

            if (Global.Instance.Device.Clienthandler == null)
            {
                Global.Instance.Device.Clienthandler = new ClientHandler(Global.Instance.Device.Server);

                Global.Instance.Device.Clienthandler.CommandReceived += OnClientCommandReceived;

                Task.Run(() => Global.Instance.Device.Clienthandler.Run());
                Console.WriteLine("ClientHandler 이벤트 구독 및 Run 태스크 시작 완료.");
            }
        }
        private static void OnClientCommandReceived(object sender, CommandReceivedEventArgs e)
        {
            Console.WriteLine($"\n--- 명령 수신 이벤트 ---");
            Console.WriteLine($"원본 명령: {e.RawCommand}");
            Console.WriteLine($"명령 유형: {e.CommandType}");
            Console.WriteLine($"전송된 응답: {e.ResponseSent}");
            Console.WriteLine($"--------------------------");

            // 받은 명령 유형에 따라 Global.Instance.Device를 통해 bool 변수 상태 업데이트
            switch (e.CommandType)
            {
                case "T_Command":
                    Global.Instance.Device.INSP_Complete = true;
                    break;
                case "S_Command":
                    Global.Instance.Device.Client_Status = true;
                    break;
                case "Error_Command":
                    Console.WriteLine($"[오류] 알 수 없는 명령 수신.");
                    break;
            }
        }

    }
}
