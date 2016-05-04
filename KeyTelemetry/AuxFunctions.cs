using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Diagnostics;
using System.Management;

namespace KeyTelemetry
{
    static class AuxFunctions
    {
        static public string GetIP()
        {
            try
            {
                WebClient webClient = new WebClient();
                string response = webClient.DownloadString("https://api.ipify.org");
                if (response.Length < 6) return "-1";
                return response;
            }
            catch { return "-1"; }
        }

        static public string FixTime(string i)
        {
            if (i.Length < 2) return "0" + i;
            else return i;
        }

        public static string CurrentCPUusage
        {
            get
            {
                PerformanceCounter cpuCounter;
                cpuCounter = new PerformanceCounter();
                cpuCounter.CategoryName = "Processor";
                cpuCounter.CounterName = "% Processor Time";
                cpuCounter.InstanceName = "_Total";
                return cpuCounter.NextValue() + "%";
            }
        }

        public static int coreCount()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    string x = queryObj["NumberOfLogicalProcessors"].ToString();
                    int y;
                    if (Int32.TryParse(x, out y))
                    {
                        return y;
                    }
                    else return -1;

                }
                return -1;
            }
            catch (ManagementException e)
            {
                Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
                return -1;

            }
        }

        public static Int32 totalRAM()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_ComputerSystem");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Int32 x;
                    if (Int32.TryParse(queryObj["TotalPhysicalMemory"].ToString(), out x))
                    {
                        return x;
                    }
                    return -1;

                }
                return -1;
            }
            catch (ManagementException e)
            {
                Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
                return -1;
            }
        }

        public static Int32 freeRAM()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_OperatingSystem");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Int32 x;
                    if (Int32.TryParse(queryObj["FreePhysicalMemory"].ToString(), out x))
                    {
                        return x;
                    }
                }
                return -1;
            }
            catch (ManagementException e)
            {
                Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
                return -1;
            }
        }

        public static int systemArchitecture()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_OperatingSystem");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if (queryObj["OSArchitecture"].ToString() == "64-bit")  return 64;
                    else return 32;
                }
                return -1;
            }
            catch (ManagementException e)
            {
                Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
                return -1;

            }
        }
        public static string processingPercent()
        {
            string list ="";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PerfFormattedData_PerfOS_Processor");

            foreach (ManagementObject queryObj in searcher.Get())
            {
                string usage = queryObj["PercentProcessorTime"].ToString();
                list += usage+",";
            }
            return list;

        }


    }
}
