using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.IRT
{
    public class InternetConnection
    {
        public bool CheckForInternetConnection()
        {
            TcpClient tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect("103.1.92.174", 9050);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            //try
            //{
            //    using (var client = new WebClient())
            //    using (client.OpenRead("http://clients3.google.com/generate_204"))
            //    {
            //        return true;
            //    }
            //}
            //catch
            //{
            //    return false;
            //}

        }
    }
  }

