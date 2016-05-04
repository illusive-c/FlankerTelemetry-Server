using CoreAudioApi;
using OpenHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.IO.Ports;//Arduino
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using System.Management;
using System.Linq;


namespace KeyTelemetry
{
    public partial class Form1 : Form
    {
        #region General Vars

        //OpenHW Monitor Vars
        Computer thisComputer;
        //--------------

        //Network Vars
        private const double timerUpdate = 1000;
        private NetworkInterface[] nicArr;
        private Timer timer;
        //--------------

        // Volume Vars
        private MMDevice device;
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        int Volume;
        //--------------

        //Serial Vars
        string port = "COM47";//Properties.Settings.Default.port;
        int baud = Properties.Settings.Default.baud;
        PCstatus myPC = new PCstatus();
        string RxString;
        bool serialRun = true;
        //-----------
        
        //GUI
        bool refreshGUI = false;
        
        #endregion

        public Form1()
        {

            InitializeComponent();
            thisComputer = new Computer() { CPUEnabled = true, GPUEnabled = true, RAMEnabled = true };
            thisComputer.Open();

            InitializeTimer();

            MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
            device = DevEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
            trackWave.Value = (int)(device.AudioEndpointVolume.MasterVolumeLevelScalar * 100);
            myPC.Volume = trackWave.Value;
            device.AudioEndpointVolume.OnVolumeNotification += new AudioEndpointVolumeNotificationDelegate(AudioEndpointVolume_OnVolumeNotification);

            IpGet.RunWorkerAsync();
            serialBGW.RunWorkerAsync();
            GuiRefreshBGW.RunWorkerAsync();

            //myPC.CPU_Core_Count = AuxFunctions.coreCount();
            //myPC.System_Architecture = AuxFunctions.systemArchitecture();

            refreshGUI = true;//Leave this last
        }


        #region OpenhwMonitor

        /// <summary>
        /// OpenHW monitor's main function 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            String temp = "";
            String load = "";
            String clock = "";

            foreach (var hardwareItem in thisComputer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.CPU || hardwareItem.HardwareType == HardwareType.GpuNvidia || hardwareItem.HardwareType == HardwareType.RAM)
                {
                    hardwareItem.Update();
                    foreach (IHardware subHardware in hardwareItem.SubHardware)
                        subHardware.Update();

                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Temperature)
                        {

                            temp += String.Format("{0} Temperature = {1}\r\n", sensor.Name, sensor.Value.HasValue ? sensor.Value.Value.ToString() : "no value");
                            if (sensor.Value.HasValue) { SensorRead(2, sensor.Name, sensor.Value.Value); }
                        }
                    }

                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Load)
                        {

                            load += String.Format("{0} Load = {1}\r\n", sensor.Name, sensor.Value.HasValue ? sensor.Value.Value.ToString() : "no value");
                            if (sensor.Value.HasValue) { SensorRead(1, sensor.Name, sensor.Value.Value); }

                        }
                    }


                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        if (sensor.SensorType == SensorType.Clock)
                        {

                            clock += String.Format("{0} Clock = {1}\r\n", sensor.Name, sensor.Value.HasValue ? sensor.Value.Value.ToString() : "no value");

                        }
                    }

                }

            }
            textBox3.Text = clock;
            textBox2.Text = load;
            textBox1.Text = temp;
        }

        #endregion

        #region Net
        #region Speed
        /// <summary>
        /// Initialize all network interfaces on this computer
        /// </summary>
        private void InitializeNetworkInterface()
        {
            nicArr = NetworkInterface.GetAllNetworkInterfaces();
            List<string> goodAdapters = new List<string>();

            foreach (NetworkInterface nicnac in nicArr)
            {
                if (nicnac.SupportsMulticast && nicnac.GetIPv4Statistics().UnicastPacketsReceived >= 1 && nicnac.OperationalStatus.ToString() == "Up")
                {
                    goodAdapters.Add(nicnac.Name);
                    //cmbInterface.Items.Add(nicnac.Name);
                }

            }
            if (goodAdapters.Count != cmbInterface.Items.Count && goodAdapters.Count != 0)
            {
                cmbInterface.Items.Clear();
                foreach (string gadpt in goodAdapters)
                {
                    cmbInterface.Items.Add(gadpt);
                }
                cmbInterface.SelectedIndex = 0;
            }
            if (goodAdapters.Count == 0) cmbInterface.Items.Clear();
        }

        /// <summary>
        /// Initialize the Timer
        /// </summary>

        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = (int)timerUpdate;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

        }


        /// <summary>
        /// Update GUI components for the network interfaces
        /// </summary>
        private void UpdateNetworkInterface()
        {
            //MessageBox.Show(cmbInterface.Items.Count.ToString());
            if (cmbInterface.Items.Count >= 1)
            {
                // Grab NetworkInterface object that describes the current interface
                NetworkInterface nic = nicArr[cmbInterface.SelectedIndex];

                // Grab the stats for that interface
                IPv4InterfaceStatistics interfaceStats = nic.GetIPv4Statistics();


                int bytesSentSpeed = (int)(interfaceStats.BytesSent - double.Parse(lblBytesSent.Text)) / 1024;
                int bytesReceivedSpeed = (int)(interfaceStats.BytesReceived - double.Parse(lblBytesReceived.Text)) / 1024;

                // Update the labels
                lblSpeed.Text = nic.Speed.ToString();
                lblInterfaceType.Text = nic.NetworkInterfaceType.ToString();
                lblSpeed.Text = (nic.Speed).ToString("N0");
                lblBytesReceived.Text = interfaceStats.BytesReceived.ToString("N0");
                lblBytesSent.Text = interfaceStats.BytesSent.ToString("N0");

                lblUpload.Text = bytesSentSpeed.ToString() + " KB/s";
                myPC.UploadSpeed = bytesSentSpeed;
                lblDownload.Text = bytesReceivedSpeed.ToString() + " KB/s";
                myPC.DownloadSpeed = bytesReceivedSpeed;

                UnicastIPAddressInformationCollection ipInfo = nic.GetIPProperties().UnicastAddresses;

                foreach (UnicastIPAddressInformation item in ipInfo)
                {
                    if (item.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        //labelIPAddress.Text = item.Address.ToString();
                        //uniCastIPInfo = item;
                        break;
                    }
                }
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            InitializeNetworkInterface();
            UpdateNetworkInterface();
        }
        #endregion
        #region IP

        private void IpGet_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                string ip = AuxFunctions.GetIP();

                if (ip == "-1")
                {
                    myPC.IP = "No connection";
                    myPC.Connected = false;
                    labelIPAddress.Invoke((MethodInvoker)delegate { labelIPAddress.Text = "No Connection"; });
                    NetStatus.Invoke((MethodInvoker)delegate { NetStatus.Text = "No Connection"; });
                }
                else
                {
                    myPC.IP = ip;
                    labelIPAddress.Invoke((MethodInvoker)delegate { labelIPAddress.Text = ip; });
                    NetStatus.Invoke((MethodInvoker)delegate { NetStatus.Text = "Connected"; });
                }

                System.Threading.Thread.Sleep(5000);
            }
        }

        #endregion
        #endregion

        #region VolumeControl

        void AudioEndpointVolume_OnVolumeNotification(AudioVolumeNotificationData data)
        {
            if (this.InvokeRequired)
            {
                object[] Params = new object[1];
                Params[0] = data;
                this.Invoke(new AudioEndpointVolumeNotificationDelegate(AudioEndpointVolume_OnVolumeNotification), Params);
            }
            else
            {
                trackWave.Value = (int)(data.MasterVolume * 100);
                myPC.Volume = (int)(data.MasterVolume * 100);// Set the volume int in the Object
            }
        }

        private void trackWave_Scroll(object sender, EventArgs e)
        {
            device.AudioEndpointVolume.MasterVolumeLevelScalar = ((float)trackWave.Value / 100);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (device.AudioEndpointVolume.Mute == true)
            {
                myPC.Mute = true;// Set the muted status bool in the Object
                MuteBox.Checked = true;
                trackWave.Value = 0;
                trackWave.Enabled = false;
            }
            else
            {
                MuteBox.Checked = false;
                myPC.Mute = false;
            }
            pkMaster.Value = (int)(device.AudioMeterInformation.MasterPeakValue * 100);
            myPC.Peak = pkMaster.Value;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (MuteBox.Checked)
            {
                device.AudioEndpointVolume.Mute = true;
                trackWave.Enabled = false;
                Volume = trackWave.Value;
                trackWave.Value = 0;
                myPC.Mute = true;

            }
            else
            {
                device.AudioEndpointVolume.Mute = false;
                trackWave.Enabled = true;
                trackWave.Value = Volume;
                myPC.Mute = false;

            }

        }

        #endregion

        #region GUI Update


        private void SensorRead(int flag, string name, float value)
        {

            if (flag == 1)//LOADS
            {
                switch (name)
                {
                    case "CPU Core #1":
                        CPU1.Value = (int)value;
                        myPC.CPU1_Load = (int)value;
                        break;
                    case "CPU Core #2":
                        CPU2.Value = (int)value;
                        myPC.CPU2_Load = (int)value;
                        break;
                    case "CPU Core #3":
                        CPU3.Value = (int)value;
                        myPC.CPU3_Load = (int)value;
                        break;
                    case "CPU Core #4":
                        CPU4.Value = (int)value;
                        myPC.CPU4_Load = (int)value;
                        break;
                    case "CPU Total":
                        myPC.CPU_Load = (int)value;
                        break;
                    case "Memory":
                        myPC.Ram = Math.Round(value);
                        break;
                }
            }

            else if (flag == 2)// CPU Temp
            {
                switch (name)
                {
                    case "CPU Package":
                        myPC.CPU_Temp = value;
                        break;
                    case "CPU Core #1":
                        CPU1temp.Text = value.ToString();
                        myPC.CPU1_Temp = value;
                        break;
                    case "CPU Core #2":
                        CPU2temp.Text = value.ToString();
                        myPC.CPU2_Temp = value;
                        break;
                    case "CPU Core #3":
                        CPU3temp.Text = value.ToString();
                        myPC.CPU3_Temp = value;
                        break;
                    case "CPU Core #4":
                        CPU4temp.Text = value.ToString();
                        myPC.CPU4_Temp = value;
                        break;
                }


            }

        }

        private void button1_Click(object sender, EventArgs e) //Serial Start Stop button
        {
            if (serialRun == true) { closeSerial(); }
            else
            {
                serialRun = true;
                if (!serialBGW.IsBusy) { serialBGW.RunWorkerAsync(); Console.WriteLine("Serail started."); }
                else { MessageBox.Show("Serial port is busy. Please wait a few seconds", "Error"); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (serialRun == true) { closeSerial(); }
            getPort();
            MessageBox.Show("Telemetry device found on port " + port + ". Click start serial to use it.", "Result");


        }

        private void GuiRefreshBGW_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            while (refreshGUI == true)
            {
                try
                {
                    if (serialPort1.IsOpen) { button1.Invoke((MethodInvoker)delegate { button1.ForeColor = System.Drawing.Color.Green; }); }
                    else { button1.Invoke((MethodInvoker)delegate { button1.ForeColor = System.Drawing.Color.Red; }); }
                    System.Threading.Thread.Sleep(500);
                }
                catch { Console.WriteLine("Couldn't refresh GUI"); }
            }


        }
        #endregion

        #region Serial

        public void getPort()
        {
            SerialPort tmp;
            foreach (string str in SerialPort.GetPortNames())
            {
                tmp = new SerialPort(str);
                if (tmp.IsOpen == false)
                {
                    try
                    {
                        tmp.Open();
                        //open serial port
                        tmp.BaudRate = 9600;
                        tmp.WriteTimeout = 10;
                        tmp.ReadTimeout = 10;
                        tmp.Write("<CON>");
                        String s = tmp.ReadTo("\n");
                        if (s == "<pong>")
                        {
                            Console.WriteLine("Found: " + str);
                            Properties.Settings.Default.port = str;
                            Properties.Settings.Default.Save();
                            tmp.Close();
                            break;
                        }
                        else
                        {

                            tmp.Close();
                        }
                    }
                    catch (TimeoutException)
                    {
                        tmp.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }


        void openSerial()
        {
            Console.WriteLine("Openserial function. Port: " + port + " Baud: " + baud);
            {
                serialPort1.PortName = port;
                serialPort1.BaudRate = baud;
                try
                {
                    serialPort1.Open();

                }
                catch
                {
                    Console.WriteLine("Couldn't open " + port);
                }
            }

        }

        void closeSerial()
        {
            WriteSerial("<STP>");

            serialRun = false;
            serialPort1.Close();
            Console.WriteLine("Serail stopped.");
        }

        void WriteSerial(string args)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Write(args);
                }
                catch
                {
                    Console.WriteLine("Serial communication error.");
                    serialPort1.Close();
                }

            }
            else { }

        }

        private void serialBGW_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            DateTime nowVar = DateTime.Now;
            var lastExecutionDate = nowVar;
            var lastExecutionHour = nowVar;
            var lastExecutionTemp = nowVar;
            var lastExecutionIP = nowVar;
            var lastExecutionLOD = nowVar;
            var lastExecutionNTW = nowVar;


            while (serialRun == true)
            {

                if (!serialPort1.IsOpen) openSerial();
                {
                    List<string> streamList = new List<string>();
                    DateTime _now = DateTime.Now;

                    //CPU and RAM Load
                    if ((_now - lastExecutionLOD).TotalSeconds >= 0.1)
                    {
                        lastExecutionLOD = _now;
                        streamList.Add("<LOD," + myPC.CPU_Load + "," + myPC.CPU1_Load + "," + myPC.CPU2_Load + "," + myPC.CPU3_Load + "," + myPC.CPU4_Load + "," + myPC.Ram.ToString() + ">");
                    }
                    //Temperature
                    if ((_now - lastExecutionTemp).TotalSeconds >= 0.5)
                    {
                        lastExecutionTemp = _now;
                        streamList.Add("<CTM," + myPC.CPU_Temp + "," + myPC.CPU1_Temp + "," + myPC.CPU2_Temp + "," + myPC.CPU3_Temp + "," + myPC.CPU4_Temp + ">");
                    }


                    //Volume and Peak Volume
                    {
                        string volstream = "<VOL," + myPC.Volume + "," + myPC.Mute + "," + myPC.Peak + ">";
                        if (volstream == myPC.last_VolumeStream) { }
                        else
                        {
                            myPC.last_VolumeStream = volstream;
                            streamList.Add(volstream);
                        }
                    }

                    //Hour:Minute
                    if ((_now - lastExecutionHour).TotalSeconds >= 0.5)
                    {
                        lastExecutionHour = _now;
                        string HourStream;
                        string minute = _now.Minute.ToString();
                        string hour = _now.Hour.ToString();
                        string second = _now.Second.ToString();
                        HourStream = "<HOR," + AuxFunctions.FixTime(hour) + ":" + AuxFunctions.FixTime(minute) + ":" + AuxFunctions.FixTime(second) + ">";

                        streamList.Add(HourStream);
                    }

                    //Date

                    {
                        String DateStream = "<TME," + _now.Date.ToShortDateString() + "," + _now.DayOfWeek + ">";
                        if (myPC.last_DateStream != DateStream || (_now - lastExecutionDate).TotalSeconds >= 60)
                        {
                            lastExecutionDate = _now;
                            streamList.Add(DateStream);
                            myPC.last_DateStream = DateStream;
                        }

                    }

                    //IP Adress
                    if (myPC.last_IP != myPC.IP || (_now - lastExecutionIP).TotalSeconds >= 20)
                    {
                        lastExecutionIP = _now;
                        myPC.last_IP = myPC.IP;
                        String ipSteam = "<IPA,";
                        ipSteam += myPC.Connected.ToString() + ",";
                        ipSteam += myPC.IP + ">";
                        streamList.Add(ipSteam);
                    }

                    //Network Usage
                    if ((_now - lastExecutionNTW).TotalSeconds >= 0.2)
                    {
                        lastExecutionNTW = _now;
                        String NetStream = "<NTW,";
                        NetStream += myPC.DownloadSpeed + ",";
                        NetStream += myPC.UploadSpeed + ">";
                        streamList.Add(NetStream);
                    }

                    foreach (string item in streamList)
                    {
                        Console.WriteLine(item);
                        System.Threading.Thread.Sleep(10);
                        WriteSerial(item);

                    }

                    streamList.Clear();
                    //System.Threading.Thread.Sleep(10);

                }
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeSerial();
            refreshGUI = false;
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (refreshGUI)
            {
                RxString = serialPort1.ReadExisting();
                this.Invoke(new EventHandler(ReadSerialMessage));
            }
        }

        private void ReadSerialMessage(object sender, EventArgs e)
        {
            serialMonitor.AppendText(RxString);
        }

        #endregion



    }
}
