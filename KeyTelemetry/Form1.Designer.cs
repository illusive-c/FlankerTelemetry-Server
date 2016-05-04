namespace KeyTelemetry
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.HwMonitorTimer = new System.Windows.Forms.Timer(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.labelIPAddress = new System.Windows.Forms.Label();
            this.labelIP = new System.Windows.Forms.Label();
            this.lblUpload = new System.Windows.Forms.Label();
            this.lblDownload = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInterfaceType = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBytesReceived = new System.Windows.Forms.Label();
            this.lblBytesSent = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInterface = new System.Windows.Forms.Label();
            this.cmbInterface = new System.Windows.Forms.ComboBox();
            this.VolumeRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.cpuBox = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.CPU4temp = new System.Windows.Forms.TextBox();
            this.CPU3temp = new System.Windows.Forms.TextBox();
            this.CPU2temp = new System.Windows.Forms.TextBox();
            this.CPU1temp = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CPU4 = new System.Windows.Forms.ProgressBar();
            this.CPU3 = new System.Windows.Forms.ProgressBar();
            this.CPU2 = new System.Windows.Forms.ProgressBar();
            this.CPU1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trackWave = new System.Windows.Forms.TrackBar();
            this.MuteBox = new System.Windows.Forms.CheckBox();
            this.pkMaster = new System.Windows.Forms.ProgressBar();
            this.serialMonitor = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.IpGet = new System.ComponentModel.BackgroundWorker();
            this.labelNet = new System.Windows.Forms.Label();
            this.NetStatus = new System.Windows.Forms.Label();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.serialBGW = new System.ComponentModel.BackgroundWorker();
            this.button2 = new System.Windows.Forms.Button();
            this.GuiRefreshBGW = new System.ComponentModel.BackgroundWorker();
            this.cpuBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackWave)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(5, 7);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(233, 181);
            this.textBox1.TabIndex = 0;
            // 
            // HwMonitorTimer
            // 
            this.HwMonitorTimer.Enabled = true;
            this.HwMonitorTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(244, 7);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(253, 181);
            this.textBox2.TabIndex = 1;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(503, 7);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(253, 181);
            this.textBox3.TabIndex = 2;
            // 
            // labelIPAddress
            // 
            this.labelIPAddress.AutoSize = true;
            this.labelIPAddress.Location = new System.Drawing.Point(102, 380);
            this.labelIPAddress.Name = "labelIPAddress";
            this.labelIPAddress.Size = new System.Drawing.Size(40, 13);
            this.labelIPAddress.TabIndex = 33;
            this.labelIPAddress.Text = "0.0.0.0";
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(8, 381);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(61, 13);
            this.labelIP.TabIndex = 32;
            this.labelIP.Text = "IP Address:";
            // 
            // lblUpload
            // 
            this.lblUpload.AutoSize = true;
            this.lblUpload.Location = new System.Drawing.Point(99, 353);
            this.lblUpload.Name = "lblUpload";
            this.lblUpload.Size = new System.Drawing.Size(13, 13);
            this.lblUpload.TabIndex = 31;
            this.lblUpload.Text = "0";
            // 
            // lblDownload
            // 
            this.lblDownload.AutoSize = true;
            this.lblDownload.Location = new System.Drawing.Point(99, 327);
            this.lblDownload.Name = "lblDownload";
            this.lblDownload.Size = new System.Drawing.Size(13, 13);
            this.lblDownload.TabIndex = 30;
            this.lblDownload.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 353);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Upload";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 327);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Download:";
            // 
            // lblInterfaceType
            // 
            this.lblInterfaceType.AutoSize = true;
            this.lblInterfaceType.Location = new System.Drawing.Point(99, 223);
            this.lblInterfaceType.Name = "lblInterfaceType";
            this.lblInterfaceType.Size = new System.Drawing.Size(13, 13);
            this.lblInterfaceType.TabIndex = 27;
            this.lblInterfaceType.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Interface Type:";
            // 
            // lblBytesReceived
            // 
            this.lblBytesReceived.AutoSize = true;
            this.lblBytesReceived.Location = new System.Drawing.Point(99, 301);
            this.lblBytesReceived.Name = "lblBytesReceived";
            this.lblBytesReceived.Size = new System.Drawing.Size(13, 13);
            this.lblBytesReceived.TabIndex = 25;
            this.lblBytesReceived.Text = "0";
            // 
            // lblBytesSent
            // 
            this.lblBytesSent.AutoSize = true;
            this.lblBytesSent.Location = new System.Drawing.Point(99, 275);
            this.lblBytesSent.Name = "lblBytesSent";
            this.lblBytesSent.Size = new System.Drawing.Size(13, 13);
            this.lblBytesSent.TabIndex = 24;
            this.lblBytesSent.Text = "0";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(99, 249);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(13, 13);
            this.lblSpeed.TabIndex = 23;
            this.lblSpeed.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Bytes Received:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Bytes Sent:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Speed:";
            // 
            // lblInterface
            // 
            this.lblInterface.AutoSize = true;
            this.lblInterface.Location = new System.Drawing.Point(5, 195);
            this.lblInterface.Name = "lblInterface";
            this.lblInterface.Size = new System.Drawing.Size(49, 13);
            this.lblInterface.TabIndex = 19;
            this.lblInterface.Text = "Interface";
            // 
            // cmbInterface
            // 
            this.cmbInterface.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInterface.FormattingEnabled = true;
            this.cmbInterface.Location = new System.Drawing.Point(60, 192);
            this.cmbInterface.Name = "cmbInterface";
            this.cmbInterface.Size = new System.Drawing.Size(205, 21);
            this.cmbInterface.TabIndex = 18;
            // 
            // VolumeRefreshTimer
            // 
            this.VolumeRefreshTimer.Enabled = true;
            this.VolumeRefreshTimer.Interval = 150;
            this.VolumeRefreshTimer.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // cpuBox
            // 
            this.cpuBox.Controls.Add(this.label12);
            this.cpuBox.Controls.Add(this.label11);
            this.cpuBox.Controls.Add(this.CPU4temp);
            this.cpuBox.Controls.Add(this.CPU3temp);
            this.cpuBox.Controls.Add(this.CPU2temp);
            this.cpuBox.Controls.Add(this.CPU1temp);
            this.cpuBox.Controls.Add(this.label10);
            this.cpuBox.Controls.Add(this.label9);
            this.cpuBox.Controls.Add(this.label8);
            this.cpuBox.Controls.Add(this.label7);
            this.cpuBox.Controls.Add(this.CPU4);
            this.cpuBox.Controls.Add(this.CPU3);
            this.cpuBox.Controls.Add(this.CPU2);
            this.cpuBox.Controls.Add(this.CPU1);
            this.cpuBox.Location = new System.Drawing.Point(219, 223);
            this.cpuBox.Name = "cpuBox";
            this.cpuBox.Size = new System.Drawing.Size(189, 127);
            this.cpuBox.TabIndex = 46;
            this.cpuBox.TabStop = false;
            this.cpuBox.Text = "CPU ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(148, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 59;
            this.label12.Text = "Temp";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(76, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 58;
            this.label11.Text = "Load";
            // 
            // CPU4temp
            // 
            this.CPU4temp.Location = new System.Drawing.Point(150, 104);
            this.CPU4temp.Name = "CPU4temp";
            this.CPU4temp.ReadOnly = true;
            this.CPU4temp.Size = new System.Drawing.Size(30, 20);
            this.CPU4temp.TabIndex = 57;
            this.CPU4temp.TabStop = false;
            this.CPU4temp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CPU3temp
            // 
            this.CPU3temp.Location = new System.Drawing.Point(150, 81);
            this.CPU3temp.Name = "CPU3temp";
            this.CPU3temp.ReadOnly = true;
            this.CPU3temp.Size = new System.Drawing.Size(30, 20);
            this.CPU3temp.TabIndex = 56;
            this.CPU3temp.TabStop = false;
            this.CPU3temp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CPU2temp
            // 
            this.CPU2temp.Location = new System.Drawing.Point(151, 56);
            this.CPU2temp.Name = "CPU2temp";
            this.CPU2temp.ReadOnly = true;
            this.CPU2temp.Size = new System.Drawing.Size(30, 20);
            this.CPU2temp.TabIndex = 55;
            this.CPU2temp.TabStop = false;
            this.CPU2temp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CPU1temp
            // 
            this.CPU1temp.Location = new System.Drawing.Point(151, 33);
            this.CPU1temp.Name = "CPU1temp";
            this.CPU1temp.ReadOnly = true;
            this.CPU1temp.Size = new System.Drawing.Size(30, 20);
            this.CPU1temp.TabIndex = 54;
            this.CPU1temp.TabStop = false;
            this.CPU1temp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 13);
            this.label10.TabIndex = 53;
            this.label10.Text = "Core4 :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 52;
            this.label9.Text = "Core3 :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 51;
            this.label8.Text = "Core2 :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 50;
            this.label7.Text = "Core1 :";
            // 
            // CPU4
            // 
            this.CPU4.Location = new System.Drawing.Point(44, 101);
            this.CPU4.Name = "CPU4";
            this.CPU4.Size = new System.Drawing.Size(100, 23);
            this.CPU4.TabIndex = 49;
            // 
            // CPU3
            // 
            this.CPU3.Location = new System.Drawing.Point(44, 78);
            this.CPU3.Name = "CPU3";
            this.CPU3.Size = new System.Drawing.Size(100, 23);
            this.CPU3.TabIndex = 48;
            // 
            // CPU2
            // 
            this.CPU2.Location = new System.Drawing.Point(44, 55);
            this.CPU2.Name = "CPU2";
            this.CPU2.Size = new System.Drawing.Size(100, 23);
            this.CPU2.TabIndex = 47;
            // 
            // CPU1
            // 
            this.CPU1.Location = new System.Drawing.Point(44, 32);
            this.CPU1.Name = "CPU1";
            this.CPU1.Size = new System.Drawing.Size(100, 23);
            this.CPU1.TabIndex = 46;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.trackWave);
            this.groupBox1.Controls.Add(this.MuteBox);
            this.groupBox1.Controls.Add(this.pkMaster);
            this.groupBox1.Location = new System.Drawing.Point(213, 353);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 79);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sound";
            // 
            // trackWave
            // 
            this.trackWave.AutoSize = false;
            this.trackWave.LargeChange = 10;
            this.trackWave.Location = new System.Drawing.Point(20, 19);
            this.trackWave.Maximum = 100;
            this.trackWave.Name = "trackWave";
            this.trackWave.Size = new System.Drawing.Size(104, 22);
            this.trackWave.TabIndex = 50;
            this.trackWave.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackWave.Scroll += new System.EventHandler(this.trackWave_Scroll);
            // 
            // MuteBox
            // 
            this.MuteBox.AutoSize = true;
            this.MuteBox.Location = new System.Drawing.Point(130, 19);
            this.MuteBox.Name = "MuteBox";
            this.MuteBox.Size = new System.Drawing.Size(50, 17);
            this.MuteBox.TabIndex = 44;
            this.MuteBox.Text = "Mute";
            this.MuteBox.UseVisualStyleBackColor = true;
            this.MuteBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // pkMaster
            // 
            this.pkMaster.Location = new System.Drawing.Point(20, 47);
            this.pkMaster.Name = "pkMaster";
            this.pkMaster.Size = new System.Drawing.Size(160, 13);
            this.pkMaster.Step = 1;
            this.pkMaster.TabIndex = 43;
            // 
            // serialMonitor
            // 
            this.serialMonitor.Location = new System.Drawing.Point(503, 192);
            this.serialMonitor.Multiline = true;
            this.serialMonitor.Name = "serialMonitor";
            this.serialMonitor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.serialMonitor.Size = new System.Drawing.Size(253, 240);
            this.serialMonitor.TabIndex = 48;
            this.serialMonitor.WordWrap = false;
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(503, 439);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(253, 23);
            this.button1.TabIndex = 49;
            this.button1.Text = "Serial Start/Stop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // IpGet
            // 
            this.IpGet.DoWork += new System.ComponentModel.DoWorkEventHandler(this.IpGet_DoWork);
            // 
            // labelNet
            // 
            this.labelNet.AutoSize = true;
            this.labelNet.Location = new System.Drawing.Point(12, 400);
            this.labelNet.Name = "labelNet";
            this.labelNet.Size = new System.Drawing.Size(60, 13);
            this.labelNet.TabIndex = 50;
            this.labelNet.Text = "Net Status:";
            // 
            // NetStatus
            // 
            this.NetStatus.AutoSize = true;
            this.NetStatus.Location = new System.Drawing.Point(105, 399);
            this.NetStatus.Name = "NetStatus";
            this.NetStatus.Size = new System.Drawing.Size(10, 13);
            this.NetStatus.TabIndex = 51;
            this.NetStatus.Text = "-";
            // 
            // serialPort
            // 
            this.serialPort.BaudRate = 115200;
            // 
            // serialBGW
            // 
            this.serialBGW.WorkerSupportsCancellation = true;
            this.serialBGW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.serialBGW_DoWork);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(298, 439);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(199, 23);
            this.button2.TabIndex = 52;
            this.button2.Text = "AutoScan Device";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // GuiRefreshBGW
            // 
            this.GuiRefreshBGW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.GuiRefreshBGW_DoWork);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 482);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.NetStatus);
            this.Controls.Add(this.labelNet);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.serialMonitor);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cpuBox);
            this.Controls.Add(this.labelIPAddress);
            this.Controls.Add(this.labelIP);
            this.Controls.Add(this.lblUpload);
            this.Controls.Add(this.lblDownload);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblInterfaceType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblBytesReceived);
            this.Controls.Add(this.lblBytesSent);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblInterface);
            this.Controls.Add(this.cmbInterface);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "back";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.cpuBox.ResumeLayout(false);
            this.cpuBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackWave)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer HwMonitorTimer;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label labelIPAddress;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Label lblUpload;
        private System.Windows.Forms.Label lblDownload;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInterfaceType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblBytesReceived;
        private System.Windows.Forms.Label lblBytesSent;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInterface;
        private System.Windows.Forms.ComboBox cmbInterface;
        private System.Windows.Forms.Timer VolumeRefreshTimer;
        private System.Windows.Forms.GroupBox cpuBox;
        private System.Windows.Forms.TextBox CPU4temp;
        private System.Windows.Forms.TextBox CPU3temp;
        private System.Windows.Forms.TextBox CPU2temp;
        private System.Windows.Forms.TextBox CPU1temp;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ProgressBar CPU4;
        private System.Windows.Forms.ProgressBar CPU3;
        private System.Windows.Forms.ProgressBar CPU2;
        private System.Windows.Forms.ProgressBar CPU1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox MuteBox;
        private System.Windows.Forms.ProgressBar pkMaster;
        private System.Windows.Forms.TrackBar trackWave;
        private System.Windows.Forms.TextBox serialMonitor;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker IpGet;
        private System.Windows.Forms.Label labelNet;
        private System.Windows.Forms.Label NetStatus;
        private System.IO.Ports.SerialPort serialPort;
        private System.ComponentModel.BackgroundWorker serialBGW;
        private System.Windows.Forms.Button button2;
        private System.ComponentModel.BackgroundWorker GuiRefreshBGW;
    }
}

