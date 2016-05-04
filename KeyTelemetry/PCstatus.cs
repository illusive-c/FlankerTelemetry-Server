using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeyTelemetry
{
    class PCstatus
    {
        //CPU Cores
        public int CPU_Core_Count;
        //System Architecture
        public int System_Architecture = 64;
        //CPU Loads
        public int CPU_Load = 0;
        public int CPU1_Load = 0;
        public int CPU2_Load = 0;
        public int CPU3_Load = 0;
        public int CPU4_Load = 0;
        //CPU Temps
        public float CPU_Temp = 0;
        public float CPU1_Temp = 0;
        public float CPU2_Temp = 0;
        public float CPU3_Temp = 0;
        public float CPU4_Temp = 0;
        //RAM Load
        public double Ram = 0;
        //Volume
        public int Volume = 0;
        public bool Mute = false;
        public int Peak = 0;
        public string last_VolumeStream;
        //NET
        public string IP= "-";
        public bool Connected = false;
        public int DownloadSpeed=0;
        public int UploadSpeed=0;
        public string last_IP;
        //DATE TIME
        public string last_DateStream;


    }
}
