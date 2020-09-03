using BLLS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System
{
    public class BakeryKOTPrinting80
    {
        BLLUser blu = new BLLUser();
        BLLkot_kitchen blps = new BLLkot_kitchen();
        public string service_type;
        public bool kot_printer_1;
        public static string note_pad;
        public string kot_id;
        public string printerName;
        public string service_provider_name;
        public static string shape;
        public static string receving_time;
        public static string Message;
        public static string Coating;
        public static string advance_amount;
        public static string payment_mode;
        public List<string> datagridview_name = new List<string>();
        public List<string> datagridview_qty = new List<string>();
        public List<string> datagridview_kot_print = new List<string>();
        public List<string> datagridview_modifier = new List<string>();
        public void printkot()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Arial", 12);
            PaperSize psize = new PaperSize("Custome", 314, 3600);
            pd.Document = pdoc;
            pdoc.PrinterSettings.PrinterName =printerName;
            pdoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.DefaultPageSettings.PaperSize.Height = 3600;
            pdoc.DefaultPageSettings.PaperSize.Width = 314;
            if (pdoc.PrinterSettings.IsValid)
            {
                pdoc.Print();
            }
            else
            {
                MessageBox.Show("Invalid Printer");
                DialogResult results = pd.ShowDialog();
                if (results == DialogResult.OK)
                {

                    pdoc.Print();
                }
            }
        }
        BLLTable bltb = new BLLTable();
        BLLTable_Area bta = new BLLTable_Area();
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            float xs = 10;
            float ys = 5;

            float widths = 285.0F; // max width I found through trial and error
            float heights = 0F;
            DataTable dtm = blu.checkbusiness();
            Font drawFontArial12Bold = new Font("Arial", 8, FontStyle.Bold);
            Font drawFontArial10Regular = new Font("Arial", 8, FontStyle.Regular);
            Font drawFontArial10Regularsmall = new Font("Arial", 6, FontStyle.Regular);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            Pen drawingPen = new Pen(Color.Black, 1);
            // Set format of string.
            StringFormat drawFormatCenter = new StringFormat();
            drawFormatCenter.Alignment = StringAlignment.Center;
            StringFormat drawFormatLeft = new StringFormat();
            drawFormatLeft.Alignment = StringAlignment.Near;
            StringFormat drawFormatRight = new StringFormat();
            drawFormatRight.Alignment = StringAlignment.Far;
            StringFormat drawFormatRightlest = new StringFormat();
            StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            DataTable dt_printing_set = blps.getall_kot_data();
          
            if (dt_printing_set.Rows.Count > 0)
            {
                string business_name = dtm.Rows[0]["business_name"].ToString();
                string address = dtm.Rows[0]["address"].ToString();
                Graphics gra = e.Graphics;
                DateTime strDate = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString());

                if (dt_printing_set.Rows[0]["business_name"].ToString() == "True")
                {

                    e.Graphics.DrawString(business_name, drawFontArial12Bold, drawBrush, new RectangleF(xs, ys, widths, heights), drawFormatCenter);
                    ys += e.Graphics.MeasureString(business_name, drawFontArial12Bold).Height; ys = ys + 13;
                    if (business_name.Length >= 45)
                    {
                        ys = ys + 13;
                    }
                }

                if (dt_printing_set.Rows[0]["address"].ToString() == "True")
                {

                    e.Graphics.DrawString(address, drawFontArial10Regular, drawBrush, new RectangleF(xs, ys, widths, heights), drawFormatCenter);
                    ys += e.Graphics.MeasureString(address, drawFontArial10Regular).Height; ys = ys + 13;
                    if (address.Length >= 25)
                    {
                        ys = ys + 13;
                    }
                }
                if (service_type == "TA")
                {
                    gra.DrawString("Take Away No::", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                    gra.DrawString(kot_id, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 95, ys); ys = ys + 13;

                }
                else
                {
                    gra.DrawString("Home Delivery No::", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                    gra.DrawString(kot_id, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 95, ys); ys = ys + 13;

                }

                gra.DrawString( strDate.ToString(), new System.Drawing.Font("Arial", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys); ys = ys + 11;

                gra.DrawString("Service Provider :", new System.Drawing.Font("Times New Roman ", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys); 
                gra.DrawString(service_provider_name, new System.Drawing.Font("Times New Roman ", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 95, ys); ys = ys + 11;
               
                    gra.DrawLine(drawingPen, 0, ys, 309, ys); ys = ys + 3;//line 1
                    gra.DrawString("Item", new System.Drawing.Font("Time New Roamn", 9, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                    gra.DrawString("Qty", new System.Drawing.Font("Time New Roamn", 9, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 250, ys); ys = ys + 13;
                    gra.DrawLine(drawingPen, 0, ys, 309, ys); ys = ys + 13;//line 2            

                    for (int i = 0; i < datagridview_name.Count; i++)
                    {
                        //if (datagridview_kot_print[i] == printerName)
                        //{
                            string item_name = datagridview_name[i];
                            string quantity = datagridview_qty[i];
                            string modifier_Value = "";

                            if (datagridview_modifier[i].Length > 0)
                            {
                                modifier_Value = (datagridview_modifier[i] ?? string.Empty).ToString();
                            }
                            gra.DrawString(item_name.ToString(), new System.Drawing.Font("Time New Roamn", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                            gra.DrawString(quantity, new System.Drawing.Font("Time New Roamn", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 250, ys); ys = ys + 12;
                            if (modifier_Value != "")
                            {
                                if (modifier_Value.Length < 40)
                                {

                                    gra.DrawString(modifier_Value, new System.Drawing.Font("Time New Roamn", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                                    ys = ys + 13;
                                }
                                else
                                {

                                    string break_modifier = modifier_Value.Substring(0, 39);
                                    gra.DrawString(break_modifier, new System.Drawing.Font("Time New Roamn", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys); ys = ys + 13;
                                    if (39 < modifier_Value.Length)
                                    {
                                        int length = Math.Abs(modifier_Value.Length - break_modifier.Length);
                                        gra.DrawString(modifier_Value.Substring(39, length), new System.Drawing.Font("Time New Roamn", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys); ys = ys + 13;
                                    }

                                }

                            }

                            ys = ys + 15;
                        //}
                    }

                

                    if (dt_printing_set.Rows[0]["discription"].ToString() == "True")
                    {
                        gra.DrawLine(drawingPen, 0, ys, 309, ys); ys = ys + 3;
                        gra.DrawString("Shape", new System.Drawing.Font("Time New Roamn", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 0, ys); 
                        gra.DrawString(shape, new System.Drawing.Font("Time New Roamn", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 95, ys); ys = ys + 11;
                        gra.DrawString("Receving Time:", new System.Drawing.Font("Time New Roamn", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                        gra.DrawString(receving_time, new System.Drawing.Font("Time New Roamn", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 95, ys); ys = ys + 11;
                    gra.DrawString("Coating Type:", new System.Drawing.Font("Time New Roamn", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                    gra.DrawString(Coating, new System.Drawing.Font("Time New Roamn", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 95, ys); ys = ys + 11;
                    gra.DrawString("Advance Amount:", new System.Drawing.Font("Time New Roamn", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 0, ys); 
                    gra.DrawString(advance_amount, new System.Drawing.Font("Time New Roamn", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 95, ys); ys = ys + 11;
                    gra.DrawString("Payment Mode:", new System.Drawing.Font("Time New Roamn", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                    gra.DrawString(payment_mode, new System.Drawing.Font("Time New Roamn", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 95, ys); ys = ys + 11;
                    gra.DrawString("Note:", new System.Drawing.Font("Time New Roamn", 7, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 0, ys); 
                    gra.DrawString(note_pad, new System.Drawing.Font("Time New Roamn", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 95, ys); ys = ys + 11;
                    if (Message != ""&&Message!=null)
                    {
                        gra.DrawString("Message", new System.Drawing.Font("Time New Roamn", 9, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                        gra.DrawString(Message, new System.Drawing.Font("Time New Roamn", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 60, ys); ys = ys + 11;
                        if (Message.Length > 30)
                        {
                            gra.DrawString(Message.Substring(30,Message.Length -30 ), new System.Drawing.Font("Time New Roamn", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 60, ys); ys = ys + 13;

                        }

                    }
                }

            }
            kot_printer_1 = false;
            clear_data();
        }
           
        
        
        public void clear_data()
        {
            datagridview_name.Clear();
            datagridview_qty.Clear();
            datagridview_modifier.Clear();
            datagridview_kot_print.Clear();
        }

    }
}
