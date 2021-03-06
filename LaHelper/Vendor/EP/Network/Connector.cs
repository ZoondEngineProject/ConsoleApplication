﻿using System.Net.NetworkInformation;
using System.Net;

namespace Console.Vendor.EP.Network
{
    class Connector
    {
        protected Ping Pinger;
        protected PingReply PingReply;
        protected IPAddress HostIP;

        protected void SetHost(string hostname)
        {
            HostIP = IPAddress.Parse(hostname);
        }

        protected void Ping()
        {
            Pinger = new Ping();
            PingReply = Pinger.Send(HostIP);
        }

        protected bool CheckAllowedHost()
        {
            if(HostIP.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
