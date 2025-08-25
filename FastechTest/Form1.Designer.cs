namespace FastechTest
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonMotionTest = new System.Windows.Forms.Button();
            this.textBoxDecelTime = new System.Windows.Forms.TextBox();
            this.Dec = new System.Windows.Forms.Label();
            this.textBoxAccelTime = new System.Windows.Forms.TextBox();
            this.Acc = new System.Windows.Forms.Label();
            this.BtnMovePulse_Start = new System.Windows.Forms.Button();
            this.buttonMoveINC = new System.Windows.Forms.Button();
            this.buttonMoveDEC = new System.Windows.Forms.Button();
            this.textSpeed = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textPosition = new System.Windows.Forms.TextBox();
            this.buttonJogNegative = new System.Windows.Forms.Button();
            this.buttonJogPositive = new System.Windows.Forms.Button();
            this.textBoxJogSpd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonSTOP = new System.Windows.Forms.Button();
            this.buttonServoON = new System.Windows.Forms.Button();
            this.buttonAlarmReset = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnSet_Dec = new System.Windows.Forms.Button();
            this.BtnSet_Acc = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnMovePulse_End = new System.Windows.Forms.Button();
            this.TbMovePos_End = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TbMovePos_Start = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnStartAuto = new System.Windows.Forms.Button();
            this.BtnStartStop = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.TbCurrentPos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonMotionTest
            // 
            this.buttonMotionTest.Location = new System.Drawing.Point(200, 252);
            this.buttonMotionTest.Name = "buttonMotionTest";
            this.buttonMotionTest.Size = new System.Drawing.Size(89, 30);
            this.buttonMotionTest.TabIndex = 21;
            this.buttonMotionTest.Text = "Motion Test";
            this.buttonMotionTest.UseVisualStyleBackColor = true;
            this.buttonMotionTest.Click += new System.EventHandler(this.buttonMotionTest_Click);
            // 
            // textBoxDecelTime
            // 
            this.textBoxDecelTime.Location = new System.Drawing.Point(94, 74);
            this.textBoxDecelTime.Name = "textBoxDecelTime";
            this.textBoxDecelTime.Size = new System.Drawing.Size(63, 21);
            this.textBoxDecelTime.TabIndex = 12;
            this.textBoxDecelTime.Text = "0";
            this.textBoxDecelTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxDecelTime.TextChanged += new System.EventHandler(this.textBoxDecelTime_TextChanged);
            // 
            // Dec
            // 
            this.Dec.AutoSize = true;
            this.Dec.Location = new System.Drawing.Point(7, 77);
            this.Dec.Name = "Dec";
            this.Dec.Size = new System.Drawing.Size(27, 12);
            this.Dec.TabIndex = 11;
            this.Dec.Text = "Dec";
            // 
            // textBoxAccelTime
            // 
            this.textBoxAccelTime.Location = new System.Drawing.Point(94, 47);
            this.textBoxAccelTime.Name = "textBoxAccelTime";
            this.textBoxAccelTime.Size = new System.Drawing.Size(63, 21);
            this.textBoxAccelTime.TabIndex = 10;
            this.textBoxAccelTime.Text = "0";
            this.textBoxAccelTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxAccelTime.TextChanged += new System.EventHandler(this.textBoxAccelTime_TextChanged);
            // 
            // Acc
            // 
            this.Acc.AutoSize = true;
            this.Acc.Location = new System.Drawing.Point(7, 50);
            this.Acc.Name = "Acc";
            this.Acc.Size = new System.Drawing.Size(27, 12);
            this.Acc.TabIndex = 9;
            this.Acc.Text = "Acc";
            // 
            // BtnMovePulse_Start
            // 
            this.BtnMovePulse_Start.Location = new System.Drawing.Point(162, 17);
            this.BtnMovePulse_Start.Name = "BtnMovePulse_Start";
            this.BtnMovePulse_Start.Size = new System.Drawing.Size(51, 24);
            this.BtnMovePulse_Start.TabIndex = 8;
            this.BtnMovePulse_Start.Text = "Move";
            this.BtnMovePulse_Start.UseVisualStyleBackColor = true;
            this.BtnMovePulse_Start.Click += new System.EventHandler(this.buttonMoveABS_Click);
            // 
            // buttonMoveINC
            // 
            this.buttonMoveINC.Location = new System.Drawing.Point(93, 140);
            this.buttonMoveINC.Name = "buttonMoveINC";
            this.buttonMoveINC.Size = new System.Drawing.Size(75, 39);
            this.buttonMoveINC.TabIndex = 8;
            this.buttonMoveINC.Text = "Move Pulse (+)";
            this.buttonMoveINC.UseVisualStyleBackColor = true;
            this.buttonMoveINC.Click += new System.EventHandler(this.buttonMoveINC_Click);
            // 
            // buttonMoveDEC
            // 
            this.buttonMoveDEC.Location = new System.Drawing.Point(6, 140);
            this.buttonMoveDEC.Name = "buttonMoveDEC";
            this.buttonMoveDEC.Size = new System.Drawing.Size(75, 39);
            this.buttonMoveDEC.TabIndex = 8;
            this.buttonMoveDEC.Text = "Move Pulse (-)";
            this.buttonMoveDEC.UseVisualStyleBackColor = true;
            this.buttonMoveDEC.Click += new System.EventHandler(this.buttonMoveDEC_Click);
            // 
            // textSpeed
            // 
            this.textSpeed.Location = new System.Drawing.Point(94, 20);
            this.textSpeed.Name = "textSpeed";
            this.textSpeed.Size = new System.Drawing.Size(63, 21);
            this.textSpeed.TabIndex = 7;
            this.textSpeed.Text = "0";
            this.textSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textSpeed.TextChanged += new System.EventHandler(this.textSpeed_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "Speed";
            // 
            // textPosition
            // 
            this.textPosition.Location = new System.Drawing.Point(105, 20);
            this.textPosition.Name = "textPosition";
            this.textPosition.Size = new System.Drawing.Size(63, 21);
            this.textPosition.TabIndex = 5;
            this.textPosition.Text = "0";
            this.textPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonJogNegative
            // 
            this.buttonJogNegative.Location = new System.Drawing.Point(67, 111);
            this.buttonJogNegative.Name = "buttonJogNegative";
            this.buttonJogNegative.Size = new System.Drawing.Size(50, 23);
            this.buttonJogNegative.TabIndex = 10;
            this.buttonJogNegative.Text = "- Jog";
            this.buttonJogNegative.UseVisualStyleBackColor = true;
            this.buttonJogNegative.Click += new System.EventHandler(this.buttonJogNegative_Click);
            // 
            // buttonJogPositive
            // 
            this.buttonJogPositive.Location = new System.Drawing.Point(8, 111);
            this.buttonJogPositive.Name = "buttonJogPositive";
            this.buttonJogPositive.Size = new System.Drawing.Size(50, 23);
            this.buttonJogPositive.TabIndex = 10;
            this.buttonJogPositive.Text = "+ Jog";
            this.buttonJogPositive.UseVisualStyleBackColor = true;
            this.buttonJogPositive.Click += new System.EventHandler(this.buttonJogPositive_Click);
            // 
            // textBoxJogSpd
            // 
            this.textBoxJogSpd.Location = new System.Drawing.Point(105, 47);
            this.textBoxJogSpd.Name = "textBoxJogSpd";
            this.textBoxJogSpd.Size = new System.Drawing.Size(63, 21);
            this.textBoxJogSpd.TabIndex = 9;
            this.textBoxJogSpd.Text = "0";
            this.textBoxJogSpd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxJogSpd.TextChanged += new System.EventHandler(this.textBoxJogSpd_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "Speed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "Position";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TbCurrentPos);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.buttonJogNegative);
            this.groupBox3.Controls.Add(this.buttonJogPositive);
            this.groupBox3.Controls.Add(this.textBoxJogSpd);
            this.groupBox3.Controls.Add(this.buttonMoveINC);
            this.groupBox3.Controls.Add(this.buttonSTOP);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.buttonMoveDEC);
            this.groupBox3.Controls.Add(this.textPosition);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(231, 46);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(178, 200);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Jog";
            // 
            // buttonSTOP
            // 
            this.buttonSTOP.Location = new System.Drawing.Point(118, 111);
            this.buttonSTOP.Name = "buttonSTOP";
            this.buttonSTOP.Size = new System.Drawing.Size(50, 23);
            this.buttonSTOP.TabIndex = 15;
            this.buttonSTOP.Text = "STOP";
            this.buttonSTOP.UseVisualStyleBackColor = true;
            this.buttonSTOP.Click += new System.EventHandler(this.buttonSTOP_Click);
            // 
            // buttonServoON
            // 
            this.buttonServoON.Location = new System.Drawing.Point(107, 252);
            this.buttonServoON.Name = "buttonServoON";
            this.buttonServoON.Size = new System.Drawing.Size(89, 30);
            this.buttonServoON.TabIndex = 16;
            this.buttonServoON.Text = "Servo ON";
            this.buttonServoON.UseVisualStyleBackColor = true;
            this.buttonServoON.Click += new System.EventHandler(this.buttonServoON_Click);
            // 
            // buttonAlarmReset
            // 
            this.buttonAlarmReset.Location = new System.Drawing.Point(12, 252);
            this.buttonAlarmReset.Name = "buttonAlarmReset";
            this.buttonAlarmReset.Size = new System.Drawing.Size(89, 30);
            this.buttonAlarmReset.TabIndex = 17;
            this.buttonAlarmReset.Text = "Alarm Reset";
            this.buttonAlarmReset.UseVisualStyleBackColor = true;
            this.buttonAlarmReset.Click += new System.EventHandler(this.buttonAlarmReset_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnSet_Dec);
            this.groupBox2.Controls.Add(this.BtnSet_Acc);
            this.groupBox2.Controls.Add(this.textBoxDecelTime);
            this.groupBox2.Controls.Add(this.Dec);
            this.groupBox2.Controls.Add(this.textBoxAccelTime);
            this.groupBox2.Controls.Add(this.Acc);
            this.groupBox2.Controls.Add(this.textSpeed);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(13, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 105);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Speed Setting";
            // 
            // BtnSet_Dec
            // 
            this.BtnSet_Dec.Location = new System.Drawing.Point(161, 71);
            this.BtnSet_Dec.Name = "BtnSet_Dec";
            this.BtnSet_Dec.Size = new System.Drawing.Size(51, 24);
            this.BtnSet_Dec.TabIndex = 14;
            this.BtnSet_Dec.Text = "Set";
            this.BtnSet_Dec.UseVisualStyleBackColor = true;
            this.BtnSet_Dec.Click += new System.EventHandler(this.BtnSet_Dec_Click);
            // 
            // BtnSet_Acc
            // 
            this.BtnSet_Acc.Location = new System.Drawing.Point(161, 44);
            this.BtnSet_Acc.Name = "BtnSet_Acc";
            this.BtnSet_Acc.Size = new System.Drawing.Size(51, 24);
            this.BtnSet_Acc.TabIndex = 13;
            this.BtnSet_Acc.Text = "Set";
            this.BtnSet_Acc.UseVisualStyleBackColor = true;
            this.BtnSet_Acc.Click += new System.EventHandler(this.BtnSet_Acc_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnMovePulse_End);
            this.groupBox1.Controls.Add(this.TbMovePos_End);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TbMovePos_Start);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BtnMovePulse_Start);
            this.groupBox1.Location = new System.Drawing.Point(12, 157);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 89);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Move Position";
            // 
            // BtnMovePulse_End
            // 
            this.BtnMovePulse_End.Location = new System.Drawing.Point(162, 44);
            this.BtnMovePulse_End.Name = "BtnMovePulse_End";
            this.BtnMovePulse_End.Size = new System.Drawing.Size(51, 24);
            this.BtnMovePulse_End.TabIndex = 13;
            this.BtnMovePulse_End.Text = "Move";
            this.BtnMovePulse_End.UseVisualStyleBackColor = true;
            this.BtnMovePulse_End.Click += new System.EventHandler(this.BtnMovePulse_End_Click);
            // 
            // TbMovePos_End
            // 
            this.TbMovePos_End.Location = new System.Drawing.Point(95, 47);
            this.TbMovePos_End.Name = "TbMovePos_End";
            this.TbMovePos_End.Size = new System.Drawing.Size(63, 21);
            this.TbMovePos_End.TabIndex = 12;
            this.TbMovePos_End.Text = "0";
            this.TbMovePos_End.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TbMovePos_End.TextChanged += new System.EventHandler(this.TbMovePos_End_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "Inspection Pos";
            // 
            // TbMovePos_Start
            // 
            this.TbMovePos_Start.Location = new System.Drawing.Point(95, 20);
            this.TbMovePos_Start.Name = "TbMovePos_Start";
            this.TbMovePos_Start.Size = new System.Drawing.Size(63, 21);
            this.TbMovePos_Start.TabIndex = 10;
            this.TbMovePos_Start.Text = "0";
            this.TbMovePos_Start.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TbMovePos_Start.TextChanged += new System.EventHandler(this.TbMovePos_Start_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Wait Pos";
            // 
            // BtnStartAuto
            // 
            this.BtnStartAuto.Location = new System.Drawing.Point(13, 7);
            this.BtnStartAuto.Name = "BtnStartAuto";
            this.BtnStartAuto.Size = new System.Drawing.Size(77, 28);
            this.BtnStartAuto.TabIndex = 22;
            this.BtnStartAuto.Text = "Start Auto";
            this.BtnStartAuto.UseVisualStyleBackColor = true;
            this.BtnStartAuto.Click += new System.EventHandler(this.BtnStartAuto_Click);
            // 
            // BtnStartStop
            // 
            this.BtnStartStop.Location = new System.Drawing.Point(93, 7);
            this.BtnStartStop.Name = "BtnStartStop";
            this.BtnStartStop.Size = new System.Drawing.Size(77, 28);
            this.BtnStartStop.TabIndex = 23;
            this.BtnStartStop.Text = "Stop Auto";
            this.BtnStartStop.UseVisualStyleBackColor = true;
            this.BtnStartStop.Click += new System.EventHandler(this.BtnStartStop_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(320, 252);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(89, 30);
            this.BtnSave.TabIndex = 24;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // TbCurrentPos
            // 
            this.TbCurrentPos.Location = new System.Drawing.Point(105, 74);
            this.TbCurrentPos.Name = "TbCurrentPos";
            this.TbCurrentPos.Size = new System.Drawing.Size(63, 21);
            this.TbCurrentPos.TabIndex = 17;
            this.TbCurrentPos.Text = "0";
            this.TbCurrentPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "Current Position";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 301);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnStartStop);
            this.Controls.Add(this.BtnStartAuto);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonMotionTest);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonServoON);
            this.Controls.Add(this.buttonAlarmReset);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "FasTech Servo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonMotionTest;
        private System.Windows.Forms.TextBox textBoxDecelTime;
        private System.Windows.Forms.Label Dec;
        private System.Windows.Forms.TextBox textBoxAccelTime;
        private System.Windows.Forms.Label Acc;
        private System.Windows.Forms.Button BtnMovePulse_Start;
        private System.Windows.Forms.Button buttonMoveINC;
        private System.Windows.Forms.Button buttonMoveDEC;
        private System.Windows.Forms.TextBox textSpeed;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textPosition;
        private System.Windows.Forms.Button buttonJogNegative;
        private System.Windows.Forms.Button buttonJogPositive;
        private System.Windows.Forms.TextBox textBoxJogSpd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonSTOP;
        private System.Windows.Forms.Button buttonServoON;
        private System.Windows.Forms.Button buttonAlarmReset;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TbMovePos_Start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnStartAuto;
        private System.Windows.Forms.Button BtnStartStop;
        private System.Windows.Forms.TextBox TbMovePos_End;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnMovePulse_End;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnSet_Dec;
        private System.Windows.Forms.Button BtnSet_Acc;
        private System.Windows.Forms.TextBox TbCurrentPos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
    }
}

