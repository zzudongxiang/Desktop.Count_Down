using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CountDown
{
    public static class Common
    {
        public static string GetClientLocalIPv4Address()
        {
            string[] Ips = GetLocalIpAddress();
            foreach (string ip in Ips) if (ip.StartsWith("10.80.")) return ip;
            foreach (string ip in Ips) if (ip.Contains(".")) return ip;
            return "127.0.0.1";
        }

        public static string[] GetLocalIpAddress()
        {
            string hostName = Dns.GetHostName();                     
            IPAddress[] addresses = Dns.GetHostAddresses(hostName);   
            string[] IP = new string[addresses.Length];             
            for (int i = 0; i < addresses.Length; i++) IP[i] = addresses[i].ToString();
            return IP;
        }
    }
}
