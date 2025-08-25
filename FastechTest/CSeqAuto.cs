using FastechTest;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntelligentFactory
{
    public class CSeqAuto : CSeqBase
    {
        private Global Global = Global.Instance;
        public CSeqAuto(string strName = "")
        {
            if (string.IsNullOrEmpty(strName)) ThreadName = $"SEQ_Auto";
            else ThreadName = strName;

            StartThread();
        }
        public override void Run()
        {
            try
            {
                this.ThreadSleepTime_ms = 1;
                //AUTO 가 아니고, 매뉴얼 검사도 아니면 retrun;
                if (Global.System.Mode == CSystem.MODE.ALARM) return;
                if (Global.System.Mode != CSystem.MODE.AUTO ) return;

                switch (SeqIndex)
                {
                    case "IDLE":
                        {
                            int nRtn;
                            int lCmdPos = 0;
                            if (Global.System.Mode == CSystem.MODE.AUTO)
                            {
                                if (Global.Device.bConnected == false) return;
                                if (Global.Device.Client_Status == false) return;
                                nRtn = EziMOTIONPlusELib.FAS_GetCommandPos(Global.Device.ServoInfo.ServoID, ref lCmdPos);
                                if (nRtn != EziMOTIONPlusELib.FMM_OK) return;
                                if (lCmdPos != Global.Device.ServoInfo.Wait_Pos) return;
                            }
                        }
                        SetStepEx("INIT");
                        break;
                    case "INIT":
                        {
                            Global.Device.Client_Status = false;
                            int nRtn;
                            uint dwAxisStatus = 0;
                            if (Global.Device.bConnected == false) return;
                            nRtn = EziMOTIONPlusELib.FAS_GetAxisStatus(Global.Device.ServoInfo.ServoID, ref dwAxisStatus);
                            if (nRtn != EziMOTIONPlusELib.FMM_OK) return;
                            // reset alarm if there is alarm.
                            if ((dwAxisStatus & 0x00000001) != 0) // FFLAG_ERRORALL is ON
                            {
                                nRtn = EziMOTIONPlusELib.FAS_ServoAlarmReset(Global.Device.ServoInfo.ServoID);
                                if (nRtn != EziMOTIONPlusELib.FMM_OK) return;
                            }
                            // enable drive if servo off status.
                            if ((dwAxisStatus & 0x00100000) == 0)  // FFLAG_SERVOON is OFF
                            {
                                nRtn = EziMOTIONPlusELib.FAS_ServoEnable(Global.Device.ServoInfo.ServoID, 1);
                                if (nRtn != EziMOTIONPlusELib.FMM_OK) return;
                            }
                            SetStepEx("INIT_Wait");
                        }
                        break;
                    case "INIT_Wait":
                        {
                            int nRtn;
                            uint dwAxisStatus = 0;
                            nRtn = EziMOTIONPlusELib.FAS_GetAxisStatus(Global.Device.ServoInfo.ServoID, ref dwAxisStatus);
                            if (nRtn != EziMOTIONPlusELib.FMM_OK) return;
                            if ((dwAxisStatus & 0x00000001) == 1) return;// FFLAG_ERRORALL is ON
                            if ((dwAxisStatus & 0x00100000) == 0) return;  // FFLAG_SERVOON is OFF
                            SetStepEx("InspPos");
                        }
                        break;
                    case "InspPos":
                        {
                            int nRtn;
                            nRtn = EziMOTIONPlusELib.FAS_MoveSingleAxisAbsPos(Global.Device.ServoInfo.ServoID, Global.Device.ServoInfo.Insp_Pos, Global.Device.ServoInfo.MotorSpeed);
                            if (nRtn != EziMOTIONPlusELib.FMM_OK) return;
                            SetStepEx("InspPos_Wait");

                        }
                        break;
                    case "InspPos_Wait":
                        {
                            int nRtn;
                            uint dwAxisStatus = 0;
                            int lCmdPos = 0;
                            nRtn = EziMOTIONPlusELib.FAS_GetAxisStatus(Global.Device.ServoInfo.ServoID, ref dwAxisStatus);
                            if (nRtn != EziMOTIONPlusELib.FMM_OK) return;
                            if ((dwAxisStatus & 0x00000001) == 1) return;  // FFLAG_ERRORALL is ON
                            if ((dwAxisStatus & 0x08000000) != 0) return;  // FFLAG_MOTIONING is ON
                            // check position
                            nRtn = EziMOTIONPlusELib.FAS_GetCommandPos(Global.Device.ServoInfo.ServoID, ref lCmdPos);
                            if (nRtn != EziMOTIONPlusELib.FMM_OK) return;
                            if (lCmdPos != Global.Device.ServoInfo.Insp_Pos) return;
                            // 트리거 신호 송신
                            Global.Device.Server.SendMessage("T");
                            SetStepEx("Wait_Vision_Result");
                        }
                        break;
                    case "Wait_Vision_Result":
                        {
                            // 검사 완료 수신
                            if (Global.Device.INSP_Complete) SetStepEx("WaitPos");
                        }
                        break;
                    case "WaitPos":
                        {
                            int nRtn;
                            nRtn = EziMOTIONPlusELib.FAS_MoveSingleAxisAbsPos(Global.Device.ServoInfo.ServoID, Global.Device.ServoInfo.Wait_Pos, Global.Device.ServoInfo.MotorSpeed);
                            if (nRtn != EziMOTIONPlusELib.FMM_OK) return;
                            SetStepEx("WaitPos_Wait");
                        }
                        break;
                    case "WaitPos_Wait":
                        {
                            int nRtn;
                            uint dwAxisStatus = 0;
                            int lCmdPos = 0;
                            nRtn = EziMOTIONPlusELib.FAS_GetAxisStatus(Global.Device.ServoInfo.ServoID, ref dwAxisStatus);
                            if (nRtn != EziMOTIONPlusELib.FMM_OK) return;
                            if ((dwAxisStatus & 0x00000001) == 1) return;  // FFLAG_ERRORALL is ON
                            if ((dwAxisStatus & 0x08000000) != 0) return;  // FFLAG_MOTIONING is ON
                            nRtn = EziMOTIONPlusELib.FAS_GetCommandPos(Global.Device.ServoInfo.ServoID, ref lCmdPos);
                            if (nRtn != EziMOTIONPlusELib.FMM_OK) return;
                            if (lCmdPos != Global.Device.ServoInfo.Wait_Pos) return;
                            SetStepEx("COMPLETE");
                        }
                        break;
                    case "COMPLETE":
                        {
                            Global.Device.INSP_Complete = false;
                            Thread.Sleep(1000);
                        }
                        SetStepEx("IDLE");
                        break;
                    default:
                        {
                            return;
                        }
                }
            }
            catch
            {
            }
        }
        public void SetStepEx(string strStep)
        {
            base.SetStep(strStep);
        }
    }
}

