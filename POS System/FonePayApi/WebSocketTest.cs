
using System;

using System.IO;
using System.Linq;
using System.Net.Http;

using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WatsonWebsocket;
using WebSocketSharp;
using WebSocketSharp.Net;

namespace POS_System.FonePayApi
{
    public class WebSocketTest
    {
       static string msg;
        public static void connection(string url)
        {
            Uri urils =new Uri(url);
            WatsonWsClient client = new WatsonWsClient(urils);
            client.ServerConnected += ServerConnected;
            client.ServerDisconnected += ServerDisconnected;
            client.MessageReceived += MessageReceived;
            client.Start();
        }
            static void MessageReceived(object sender, MessageReceivedEventArgs args)
            {
                Console.WriteLine("Message from server: " + Encoding.UTF8.GetString(args.Data));
            string abc = Encoding.UTF8.GetString(args.Data);
            }

static void ServerConnected(object sender, EventArgs args)
{
    Console.WriteLine("Server connected");
}

static void ServerDisconnected(object sender, EventArgs args)
{
    Console.WriteLine("Server disconnected");
}
        
    }

}

