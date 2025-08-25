using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FastechTest
{
    public partial class Form1 : Form
    {
        string m_strIP;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Global.Instance.Init();
            Init_Servo();
            Init_UI();
        }
        private void Init_UI()
        {
            textSpeed.Text = Global.Instance.Device.ServoInfo.MotorSpeed.ToString();
            textBoxAccelTime.Text = Global.Instance.Device.ServoInfo.AccelTime.ToString();
            textBoxDecelTime.Text = Global.Instance.Device.ServoInfo.DecelTime.ToString();
            TbMovePos_Start.Text = Global.Instance.Device.ServoInfo.Wait_Pos.ToString();
            TbMovePos_End.Text = Global.Instance.Device.ServoInfo.Insp_Pos.ToString();
            textBoxJogSpd.Text = Global.Instance.Device.ServoInfo.JogSpeed.ToString();
        }

        private void Init_Servo()
        {
            IPAddress ipaddr = null;

            if (IPAddress.TryParse(Global.Instance.Device.ServoInfo.ServoIP, out ipaddr))
            {
                if (EziMOTIONPlusELib.FAS_Connect(ipaddr, 0) == true)
                {
                    Global.Instance.Device.bConnected = true;
                    MessageBox.Show("Connect Success");
                }
                else
                    MessageBox.Show("Connect Fail");
            }
        }
        private void buttonMoveDEC_Click(object sender, EventArgs e)
        {
            int nRtn;
            int lPosition;

            if (Global.Instance.Device.bConnected == false) return;
            lPosition = int.Parse(textPosition.Text);
            nRtn = EziMOTIONPlusELib.FAS_MoveSingleAxisIncPos(Global.Instance.Device.ServoInfo.ServoID, lPosition * -1, Global.Instance.Device.ServoInfo.JogSpeed);
            if (nRtn != EziMOTIONPlusELib.FMM_OK)
            {
                string strMsg;
                strMsg = "FAS_MoveSingleAxisIncPos() \nReturned: " + nRtn.ToString();
                MessageBox.Show(strMsg, "Function Failed");
            }
        }

        private void buttonMoveINC_Click(object sender, EventArgs e)
        {
            int nRtn;
            int lPosition;
            if (Global.Instance.Device.bConnected == false) return;
            lPosition = int.Parse(textPosition.Text);
            nRtn = EziMOTIONPlusELib.FAS_MoveSingleAxisIncPos(Global.Instance.Device.ServoInfo.ServoID, lPosition, Global.Instance.Device.ServoInfo.JogSpeed);
            if (nRtn != EziMOTIONPlusELib.FMM_OK)
            {
                string strMsg;
                strMsg = "FAS_MoveSingleAxisIncPos() \nReturned: " + nRtn.ToString();
                MessageBox.Show(strMsg, "Function Failed");
            }
        }

        private void buttonMoveABS_Click(object sender, EventArgs e)
        {
            int nRtn;
            if (Global.Instance.Device.bConnected == false) return;
            nRtn = EziMOTIONPlusELib.FAS_MoveSingleAxisAbsPos(Global.Instance.Device.ServoInfo.ServoID, Global.Instance.Device.ServoInfo.Wait_Pos, Global.Instance.Device.ServoInfo.MotorSpeed);
            if (nRtn != EziMOTIONPlusELib.FMM_OK)
            {
                string strMsg;
                strMsg = "FAS_MoveSingleAxisAbsPos() \nReturned: " + nRtn.ToString();
                MessageBox.Show(strMsg, "Function Failed");
            }
        }

        private void BtnMovePulse_End_Click(object sender, EventArgs e)
        {
             int nRtn;
            if (Global.Instance.Device.bConnected == false) return;
            nRtn = EziMOTIONPlusELib.FAS_MoveSingleAxisAbsPos(Global.Instance.Device.ServoInfo.ServoID, Global.Instance.Device.ServoInfo.Insp_Pos, Global.Instance.Device.ServoInfo.MotorSpeed);
            if (nRtn != EziMOTIONPlusELib.FMM_OK)
            {
                string strMsg;
                strMsg = "FAS_MoveSingleAxisAbsPos() \nReturned: " + nRtn.ToString();
                MessageBox.Show(strMsg, "Function Failed");
            }
        }
        private void buttonAlarmReset_Click(object sender, EventArgs e)
        {
            int nRtn;

            if (Global.Instance.Device.bConnected == false) return;

            nRtn = EziMOTIONPlusELib.FAS_ServoAlarmReset(0);
            if (nRtn != EziMOTIONPlusELib.FMM_OK)
            {
                string strMsg;
                strMsg = "FAS_ServoAlarmReset() \nReturned: " + nRtn.ToString();
                MessageBox.Show(strMsg, "Function Failed");
            }
        }

        private void buttonServoON_Click(object sender, EventArgs e)
        {
            int nRtn;

            if (Global.Instance.Device.bConnected == false) return;


            nRtn = EziMOTIONPlusELib.FAS_ServoEnable(Global.Instance.Device.ServoInfo.ServoID, 1);
            if (nRtn != EziMOTIONPlusELib.FMM_OK)
            {
                string strMsg;
                strMsg = "FAS_ServoEnable() \nReturned: " + nRtn.ToString();
                MessageBox.Show(strMsg, "Function Failed");
            }
        }

        private void buttonSTOP_Click(object sender, EventArgs e)
        {
            int nRtn;

            if (Global.Instance.Device.bConnected == false) return;
            nRtn = EziMOTIONPlusELib.FAS_MoveStop(0);
            if (nRtn != EziMOTIONPlusELib.FMM_OK)
            {
                string strMsg;
                strMsg = "FAS_MoveStop() \nReturned: " + nRtn.ToString();
                MessageBox.Show(strMsg, "Function Failed");
            }
        }

        private void buttonJogPositive_Click(object sender, EventArgs e)
        {
            int nRtn;
            if (Global.Instance.Device.bConnected == false) return;

            nRtn = EziMOTIONPlusELib.FAS_MoveVelocity(Global.Instance.Device.ServoInfo.ServoID, Global.Instance.Device.ServoInfo.JogSpeed, 1);
            if (nRtn != EziMOTIONPlusELib.FMM_OK)
            {
                string strMsg;
                strMsg = "FAS_MoveVelocity() \nReturned: " + nRtn.ToString();
                MessageBox.Show(strMsg, "Function Failed");
            }
        }

        private void buttonJogNegative_Click(object sender, EventArgs e)
        {
            int nRtn;
            if (Global.Instance.Device.bConnected == false) return;

            nRtn = EziMOTIONPlusELib.FAS_MoveVelocity(Global.Instance.Device.ServoInfo.ServoID, Global.Instance.Device.ServoInfo.JogSpeed, 0);
            if (nRtn != EziMOTIONPlusELib.FMM_OK)
            {
                string strMsg;
                strMsg = "FAS_MoveVelocity() \nReturned: " + nRtn.ToString();
                MessageBox.Show(strMsg, "Function Failed");
            }
        }

        private void buttonSpdOverride_Click(object sender, EventArgs e)
        {
            int nRtn;
            uint lVelocity;

            if (Global.Instance.Device.bConnected == false)
                return;

            if (textBoxJogSpd.Text.Length <= 0)
            {
                textBoxJogSpd.Focus();
                return;
            }

            lVelocity = uint.Parse(textBoxJogSpd.Text);

            nRtn = EziMOTIONPlusELib.FAS_VelocityOverride(0, lVelocity);
            if (nRtn != EziMOTIONPlusELib.FMM_OK)
            {
                string strMsg;
                strMsg = "FAS_VelocityOverride() \nReturned: " + nRtn.ToString();
                MessageBox.Show(strMsg, "Function Failed");
            }
        }

        private void textBoxAccelTime_TextChanged(object sender, EventArgs e)
        {
            try
            { 
                Global.Instance.Device.ServoInfo.AccelTime = int.Parse(textBoxAccelTime.Text);
            }
            catch { }
        }

        private void textBoxDecelTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Global.Instance.Device.ServoInfo.DecelTime = int.Parse(textBoxDecelTime.Text);
            }
            catch { }
        }
       
        private void buttonMotionTest_Click(object sender, EventArgs e)
        {
            // TODO:
            // reset alarm if there is alarm.
            // enable drive if servo off status.
            // and wait until servo on status.

            // move to 10000 pulse.
            // move to -20000 pulse when first motion is finished.

            uint dwAxisStatus = 0;
            int lCmdPos = 0;
            int nRtn;

            if (Global.Instance.Device.bConnected == false) return;
            nRtn = EziMOTIONPlusELib.FAS_GetAxisStatus(0, ref dwAxisStatus);
            if (nRtn != EziMOTIONPlusELib.FMM_OK) return;

            // reset alarm if there is alarm.
            if ((dwAxisStatus & 0x00000001) != 0) // FFLAG_ERRORALL is ON
            {
                nRtn = EziMOTIONPlusELib.FAS_ServoAlarmReset(0); 
                if (nRtn != EziMOTIONPlusELib.FMM_OK) return;
            }

            // enable drive if servo off status.
            if ((dwAxisStatus & 0x00100000) == 0)  // FFLAG_SERVOON is OFF
            {
                nRtn = EziMOTIONPlusELib.FAS_ServoEnable(0, 1);
                if (nRtn != EziMOTIONPlusELib.FMM_OK) return;
            }

            // and wait until servo on status.
            do
            {
                nRtn = EziMOTIONPlusELib.FAS_GetAxisStatus(0, ref dwAxisStatus);
                if (nRtn != EziMOTIONPlusELib.FMM_OK) return;
                if ((dwAxisStatus & 0x00000001) == 1) return; // FFLAG_ERRORALL is ON
            }
            while ((dwAxisStatus & 0x00100000) == 0);  // FFLAG_SERVOON is OFF

            nRtn = EziMOTIONPlusELib.FAS_MoveSingleAxisAbsPos(Global.Instance.Device.ServoInfo.ServoID, Global.Instance.Device.ServoInfo.Insp_Pos, Global.Instance.Device.ServoInfo.MotorSpeed);
            if (nRtn != EziMOTIONPlusELib.FMM_OK) return;

            // WAIT
            do
            {
                nRtn = EziMOTIONPlusELib.FAS_GetAxisStatus(0, ref dwAxisStatus);
                if (nRtn != EziMOTIONPlusELib.FMM_OK) return;
                if ((dwAxisStatus & 0x00000001) == 1) return;  // FFLAG_ERRORALL is ON
            }
            while ((dwAxisStatus & 0x08000000) != 0);  // FFLAG_MOTIONING is ON
                                                       // check position
            nRtn = EziMOTIONPlusELib.FAS_GetCommandPos(0, ref lCmdPos);
            if (nRtn != EziMOTIONPlusELib.FMM_OK) return;

            if (lCmdPos != Global.Instance.Device.ServoInfo.Insp_Pos) return;
            
            // move to -20000 pulse when first motion is finished.
            nRtn = EziMOTIONPlusELib.FAS_MoveSingleAxisAbsPos(Global.Instance.Device.ServoInfo.ServoID, Global.Instance.Device.ServoInfo.Wait_Pos, Global.Instance.Device.ServoInfo.MotorSpeed);
            if (nRtn != EziMOTIONPlusELib.FMM_OK) return;

            // WAIT
            do
            {
                nRtn = EziMOTIONPlusELib.FAS_GetAxisStatus(0, ref dwAxisStatus);
                if (nRtn != EziMOTIONPlusELib.FMM_OK) return;
                if ((dwAxisStatus & 0x00000001) == 1) return; // FFLAG_ERRORALL is ON
            }
            while ((dwAxisStatus & 0x08000000) != 0);  // FFLAG_MOTIONING is ON
            // check position
            nRtn = EziMOTIONPlusELib.FAS_GetCommandPos(0, ref lCmdPos);
            if (nRtn != EziMOTIONPlusELib.FMM_OK) return;
            if (lCmdPos != Global.Instance.Device.ServoInfo.Wait_Pos) return;

            MessageBox.Show("Finished");
        }

        private void textSpeed_TextChanged(object sender, EventArgs e)
        {
            try
            { 
                Global.Instance.Device.ServoInfo.MotorSpeed = uint.Parse(textSpeed.Text);
            }
            catch { }
        }

        private void BtnSet_Acc_Click(object sender, EventArgs e)
        {
            if (Global.Instance.Device.bConnected == false) return;

            EziMOTIONPlusELib.FAS_SetParameter(Global.Instance.Device.ServoInfo.ServoID, 3, Global.Instance.Device.ServoInfo.AccelTime);
        }

        private void BtnSet_Dec_Click(object sender, EventArgs e)
        {
            if (Global.Instance.Device.bConnected == false) return;

            EziMOTIONPlusELib.FAS_SetParameter(Global.Instance.Device.ServoInfo.ServoID, 3, Global.Instance.Device.ServoInfo.DecelTime);
        }

        private void TbMovePos_Start_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Global.Instance.Device.ServoInfo.Wait_Pos = int.Parse(TbMovePos_Start.Text);
            }
            catch { }
        }

        private void TbMovePos_End_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Global.Instance.Device.ServoInfo.Insp_Pos = int.Parse(TbMovePos_End.Text);
            }
            catch { }
        }

        private void textBoxJogSpd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Global.Instance.Device.ServoInfo.JogSpeed = uint.Parse(textBoxJogSpd.Text);
            }
            catch { }
        }
        private void BtnStartAuto_Click(object sender, EventArgs e)
        {
            if (Global.Instance.SeqAuto != null)
            {
                Global.Instance.SeqAuto.SetStepEx("IDLE");
            }
            if (Global.Instance.System.Mode != CSystem.MODE.AUTO)
            {
                BtnStartAuto.Enabled = false;
                BtnStartAuto.BackColor = Color.Green;
                Global.Instance.System.Mode = CSystem.MODE.AUTO;
            }
        }

        private void BtnStartStop_Click(object sender, EventArgs e)
        {
            BtnStartAuto.Enabled = true;
            BtnStartAuto.BackColor = Color.White;
            Global.Instance.System.Mode = CSystem.MODE.READY;
        }
           
        private void BtnSave_Click(object sender, EventArgs e)
        {
            Global.Instance.Device.ServoInfo.Save();
            MessageBox.Show("Save Success");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int nRtn = 0;
            int lCmdPos = 0;
            nRtn = EziMOTIONPlusELib.FAS_GetCommandPos(0, ref lCmdPos);
            if (nRtn != EziMOTIONPlusELib.FMM_OK) return;
            TbCurrentPos.Text = lCmdPos.ToString();

        }
    }
}
