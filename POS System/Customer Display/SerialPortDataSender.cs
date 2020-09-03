using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System
{
    class SerialPortDataSender
    {
        string[] colm;
        SerialPortModel spm = new SerialPortModel();
        public void CustomerDisplayVFD(string grand_total,byte ledCommand)
        {
            try
            {
                if(SerialPortModel.serialportName==""|| SerialPortModel.serialportName==null)
                { 
                StreamReader sr = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\Serial Port\\SerialPort.txt");
                    string readLine;
                    while (!sr.EndOfStream)
                    {
                        readLine = sr.ReadLine();
                        colm = readLine.Split(':');
                        if (colm != null && colm.Length > 0)
                        {
                            if (colm[0].ToString() == "SerialPort")
                                SerialPortModel.serialportName = colm[1].ToString();
                            if (colm[0].ToString() == "BaudRate")
                                SerialPortModel.portbaudRate = colm[1].ToString();
                            if (colm[0].ToString() == "Data Bits")
                                SerialPortModel.portdataBits = colm[1].ToString();
                        }
                    }
                }
                if (SerialPortModel.serialportName.Length > 0)
                {
                    SerialPort serialPort = new SerialPort();
                    serialPort.PortName = SerialPortModel.serialportName;
                    serialPort.BaudRate = Convert.ToInt32(SerialPortModel.portbaudRate);
                    serialPort.Parity = Parity.None;
                    serialPort.DataBits = Convert.ToInt32(SerialPortModel.portdataBits);
                    serialPort.StopBits = StopBits.One;
                    serialPort.Handshake = Handshake.None;
                    serialPort.RtsEnable = true;
                    serialPort.Open();
                    
                    
                    if (serialPort.BaudRate==2400)
                    {
                        //Clear the Display

                        byte[] bytesToSend2 = new byte[1] { 0x18 }; // send hex code to clear screen
                        serialPort.Write(bytesToSend2, 0, 1);

                        byte[] bytesToSend = new byte[] { 0x1B, 0x73, ledCommand }; 
                        serialPort.Write(bytesToSend, 0, 3);
                        serialPort.Write(grand_total);                                            
                    }
                    else
                    {
                        serialPort.Write("        ");
                        serialPort.Write("GrandTotal: " + grand_total);
                    }
                    serialPort.Close();
                    serialPort.Dispose();
                }
            }
            catch (Exception)
            {
            }
        }
        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            Console.WriteLine("Data Received:");
            Console.Write(indata);
        }
    }
}
