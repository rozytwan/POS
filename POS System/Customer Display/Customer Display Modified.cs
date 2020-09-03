using POS_System.Customer_Display;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System
{
    public partial class CustomerDisplayModified : Form
    {
        public CustomerDisplayModified()
        {
            InitializeComponent();
        }
        byte byteCommand = 0x30;
        private void btn_save_Click(object sender, EventArgs e)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\Serial Port\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            else
            {
                File.WriteAllText(folderPath + "SerialPort.txt", String.Empty);
            }
            using (StreamWriter sw1 = new StreamWriter(folderPath+"SerialPort.txt", true))
            {
               
                sw1.WriteLine("Serial Port v:1");
                sw1.WriteLine("SerialPort:"+cbo_serial_port_name.Text);
                sw1.WriteLine("BaudRate:" + cbo_Baud_rate.Text);
                sw1.WriteLine("Parity:" + cbo_parity.Text);
                sw1.WriteLine("Data Bits:" + cbo_databits.Text);
                sw1.WriteLine("HandShake:" + cbo_HandShake.Text);
                sw1.WriteLine("RtsEnable:" + cbo_RTS_enable.Text);
                sw1.WriteLine("Status:" + cbo_status.Text);
                sw1.Close();
            }

        }

        private void btn_test_port_Click(object sender, EventArgs e)
        {
            // PoleDisplay.WriteComm(0.0012);

            SerialPort sp = new SerialPort();

            sp.PortName = cbo_serial_port_name.Text;
            sp.BaudRate = Convert.ToInt32(cbo_Baud_rate.Text);
            sp.Parity = Parity.None;
            sp.DataBits = Convert.ToInt32(cbo_databits.Text);
            sp.StopBits = StopBits.One;                    
            sp.Open();
            if (rbtn_vfd.Checked)
            {
                sp.Write("GrandTotal: "+ txt_text.Text);
            }
            else
            {
                byte[] bytesToSend2 = new byte[1] { 0x18 }; // send hex code 0C to clear screen
                sp.Write(bytesToSend2, 0, 1);
                byte[] bytesToSend = new byte[] { 0x1B, 0x73, byteCommand }; // command to static led 
                sp.Write(bytesToSend, 0, 3);
                sp.Write(txt_text.Text);
             }
            sp.Close();
            sp.Dispose();

            sp = null;
        }
       
        private void CustomerDisplayModified_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cbo_serial_port_name.Items.AddRange(ports);
            if (ports.Length > 0)
            {
                cbo_serial_port_name.SelectedIndex = 0;
                cbo_Baud_rate.SelectedIndex = 0;
                cbo_databits.SelectedIndex = 0;
                cbo_HandShake.SelectedIndex = 0;
                cbo_parity.SelectedIndex = 0;
                cbo_RTS_enable.SelectedIndex = 0;
                cbo_status.SelectedIndex = 0;
            }
           
        }

        private void rbtn_price_CheckedChanged(object sender, EventArgs e)
        {
            byteCommand = 0x31;
        }

        private void rbtn_total_CheckedChanged(object sender, EventArgs e)
        {
            byteCommand = 0x32;
        }

        private void rbtn_collection_CheckedChanged(object sender, EventArgs e)
        {
            byteCommand = 0x33;
        }

        private void rbtn_change_CheckedChanged(object sender, EventArgs e)
        {
            byteCommand = 0x34;
        }
    }
}
