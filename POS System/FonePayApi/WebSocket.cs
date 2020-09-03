using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WatsonWebsocket;

namespace POS_System
{


    public class WebSocketManager
    {
       // public static string webSocketUri;
        private static AutoResetEvent messageReceiveEvent = new AutoResetEvent(false);


     
        static FonePayApi.QRCodeScan qecs = new FonePayApi.QRCodeScan();
        public static void connection(string url)
        {
            Uri urils = new Uri(url);
            WatsonWsClient client = new WatsonWsClient(urils);
            client.ServerConnected += ServerConnected;
            client.ServerDisconnected += ServerDisconnected;
            client.MessageReceived += MessageReceived;
            client.Start();
        }
        static void MessageReceived(object sender, MessageReceivedEventArgs args)
        {
            //Console.WriteLine("Message from server: " + Encoding.UTF8.GetString(args.Data));
            string data = Encoding.UTF8.GetString(args.Data);
            qecs.webSocketData(data);
        }

        static void ServerConnected(object sender, EventArgs args)
        {
            Console.WriteLine("Server connected");
        }

        static void ServerDisconnected(object sender, EventArgs args)
        {
            Console.WriteLine("Server disconnected");
        }
        //public string close()
        //{
        //    ws.Close();
        //    return "True";
        //}
        //public static void connection(string webSocketUri)
        //        {
        //            //Console.WriteLine("Initializing websocket. Uri: " + webSocketUri);
        //            ws = new WebSocket(webSocketUri);
        //            ws.Opened += new EventHandler(websocket_Opened);
        //            ws.Closed += new EventHandler(websocket_Closed);
        //            //  webSocket.Error += new EventHandler<ErrorEventArgs>(websocket_Error);
        //            ws.MessageReceived += new EventHandler<MessageReceivedEventArgs>(websocket_MessageReceived);

        //            ws.Open();
        //            while (ws.State == WebSocketState.Connecting)
        //            {

        //            };   // by default webSocket4Net has AutoSendPing=true, 
        //                 //                                                                // so we need to wait until connection established
        //            if (ws.State != WebSocketState.Open)
        //            {
        //                throw new Exception("Connection is not opened.");
        //            }
        //        }


        //        public void Close()
        //        {
        //            Console.WriteLine("Closing websocket...");
        //            ws.Close();
        //        }
        //        private static void websocket_Opened(object sender, EventArgs e)
        //        {
        //            Console.WriteLine("Websocket is opened.");
        //        }

        //        private static void websocket_Closed(object sender, EventArgs e)
        //        {
        //            Console.WriteLine("Websocket is closed.");
        //        }
        //        FonePayApi.QRCodeScan qecs = new FonePayApi.QRCodeScan();
        //        private static void websocket_MessageReceived(object sender, MessageReceivedEventArgs e)
        //        {

        //            lastMessageReceived = e.Message.ToString();
        //            // qecs.webSocketData(lastMessageReceived);
        //            messageReceiveEvent.Set();
        //        }

    }
}

