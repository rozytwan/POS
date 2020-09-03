using Newtonsoft.Json.Linq;
using QRCoder;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperSocket.ClientEngine;
using System.Threading;
using WebSocket4Net;
using System.Data;
using BLLS;
using System.Collections.Generic;
using POS_System.Printing_Billing;

namespace POS_System.FonePayApi
{
    public partial class QRCodeScan : Form
    {
        public QRCodeScan()
        {
            InitializeComponent();

        }

        FonePayApi fpa = new FonePayApi();
        public static string data;
        static string wss;
       System.Drawing.Bitmap image;
        BLLFonePay blfp = new BLLFonePay();
        string secret_key;
        string user_name;
        string password;
        string merchantCode;
        public string amount;
        public string remarks;
        public string remarks2;
        public string prnNo;
        CheckDynamic cd = new CheckDynamic();
        string checkFonePay;

        private void Test_Load(object sender, EventArgs e)
        {
            checkFonePay = cd.FonePayCheck();
            if (checkFonePay != "")
            {
                pictureBox1.ImageLocation = checkFonePay;
            }
            else
            {
                DataTable dt = blfp.getALLFonePayData();
                if (dt.Rows.Count > 0)
                {
                    secret_key = dt.Rows[0]["secret_key"].ToString();
                    user_name = dt.Rows[0]["user_name"].ToString();
                    password = Encryption.StringEncryption.Decrypt(dt.Rows[0]["password"].ToString(), "sblw-3hn8-sqoy19");
                    merchantCode = dt.Rows[0]["merchant_code"].ToString();
                    string dv = FonePayDataValidation.SHA512_keyHash(secret_key, amount + "," + prnNo + "," + merchantCode + ",Billing," + remarks2);
                    string abc = fpa.posFonePay(amount, remarks, remarks2, prnNo, merchantCode, dv.ToLower(), user_name, password);
                    JObject deserjson = JObject.Parse(abc);
                    string qrmessage = deserjson["qrMessage"].ToString();
                    wss = deserjson["thirdpartyQrWebSocketUrl"].ToString();
                    QRCodeGenerator qrgen = new QRCodeGenerator();
                    var qrdata = qrgen.CreateQrCode(qrmessage.ToString(), QRCodeGenerator.ECCLevel.H);
                    var qrcode = new QRCoder.QRCode(qrdata);
                     image = qrcode.GetGraphic(2);
                     pictureBox1.Image = image;
                    //WebSocketManager wsm = new WebSocketManager();
                    //wsm.connection(wss);
                     WebSocketManager.connection(wss);

                }
            }
        }
          string qrVerified;
        string fiscal_year;
       
        BLL_Fiscal blfsc = new BLL_Fiscal();
        //string amounts;
 

        public  void webSocketData(string data)
        {
            JObject deserjson = JObject.Parse(data);
            JObject deserts =JObject.Parse(deserjson["transactionStatus"].ToString());
            string message = deserts["message"].ToString();          
            if (message == "VERIFIED")
            {
                qrVerified = deserts["qrVerified"].ToString();
                 MessageBox.Show(qrVerified);
            }
            else
            {
                if (qrVerified == "True")
                {
                    string messageRequest = deserts["message"].ToString();
                    string paymentStatus = deserts["paymentSuccess"].ToString();
                    if (messageRequest == "Request Complete" && paymentStatus == "true" || paymentStatus=="True")
                    {
                        QRCodeScan qrc = new QRCodeScan();
                    DataTable dt1 = blfsc.get_all_data_from_fiscal("True");
                            if (dt1.Rows.Count > 0)
                            {
                                fiscal_year = dt1.Rows[0]["fiscal_year"].ToString();
                            
                            }
                            int insert = blfp.InsertFonePayLog(Convert.ToInt32(remarks2), Login.sendtext, Convert.ToDecimal(amount),prnNo, fiscal_year, Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                        
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                      
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                    }
                }
            }
           
        }

        public void acma()
        {
            QRCodeScan qcs = new QRCodeScan();
            qcs.DialogResult = DialogResult.OK;
            qcs.Close();
        }
        private void btn_disconnect_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        QRCodePrinting qcp = new QRCodePrinting();
        private void btn_qr_print_Click(object sender, EventArgs e)
        {
            qcp.printer_name = "";
            qcp.pb1 = pictureBox1;
            qcp.printQR();
            pictureBox1.Size = new System.Drawing.Size(328, 327);
        }
    }
 }


         