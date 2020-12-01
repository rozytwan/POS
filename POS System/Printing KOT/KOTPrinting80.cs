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
    public class KOTPrinting80
    {
        BLLUser blu = new BLLUser();
        BLLkot_kitchen blps = new BLLkot_kitchen();
        public string table_no;
        public string table_displayNo;
        public string table_name;
        string table_area;
        public bool kot_printer_1;
        public string note_pad;
        public string kid;
        public string adult;
        public string cashier;
        public string printerName;
        public string kot_id;
        public string service_provider_name;
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
            DataTable dt_table = bltb.chheck_table_info(table_no);
            if (dt_table.Rows.Count > 0)
            {
                string area_id = dt_table.Rows[0]["area_id"].ToString();
                DataTable dt_area = bta.get_all_data_area_id(Convert.ToInt32(area_id));
                if (dt_area.Rows.Count > 0)
                {
                    table_area = dt_area.Rows[0]["area_name"].ToString();
                }
            }
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
                    if (business_name.Length >= 25)
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
                if (Convert.ToDecimal(table_no) >= 106)
                {
                    if (Convert.ToDecimal(table_no) < 1000)
                    {
                        gra.DrawString("Home Delivery ::", new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                        gra.DrawString(table_displayNo, new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 120, ys); ys = ys + 13;
                    }
                    else
                    {
                        if (table_name == "DA")
                        {
                            gra.DrawString("Dinning ::", new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                            gra.DrawString(table_displayNo, new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 120, ys); ys = ys + 13;

                        }
                        else
                        {
                            gra.DrawString("Take Away ::", new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                            gra.DrawString(table_displayNo, new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 120, ys); ys = ys + 13;
                        }
                    }
                }
                else if (Convert.ToDecimal(table_no) <= 99)
                {
                    gra.DrawString("Table No::", new System.Drawing.Font("Arial", 9, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                    gra.DrawString(table_displayNo, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 80, ys);
                    gra.DrawString("Table Area::", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 120, ys);
                    gra.DrawString(table_area, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, ys); ys = ys + 13;
                    gra.DrawString("Name::", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                    gra.DrawString(table_name, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 80, ys); ys = ys + 13;
                }
                gra.DrawString("KOT ID::", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                gra.DrawString(kot_id, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 80, ys); ys = ys + 13;
                gra.DrawString( strDate.ToString(), new System.Drawing.Font("Arial", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys); ys = ys + 13;

                gra.DrawString("UserName :", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 5, ys); 
                gra.DrawString(cashier, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 90, ys); ys = ys + 13;
                gra.DrawString("Service Provider :", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 5, ys); 
                gra.DrawString(service_provider_name, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 90, ys); ys = ys + 13;
               
                gra.DrawLine(drawingPen, 0, ys, 309, ys); ys = ys + 3;//line 1
                    gra.DrawString("Item", new System.Drawing.Font("Time New Roamn", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                    gra.DrawString("Qty", new System.Drawing.Font("Time New Roamn", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 250, ys); ys = ys + 18;
                    gra.DrawLine(drawingPen, 0, ys, 309, ys); ys = ys + 13;//line 2            

                    for (int i = 0; i < datagridview_name.Count; i++)
                    {
                        if (datagridview_kot_print[i] == printerName)
                        {
                            string item_name = datagridview_name[i];
                            string quantity = datagridview_qty[i];
                            string modifier_Value = "";

                            if (datagridview_modifier[i].Length > 0)
                            {
                                modifier_Value = (datagridview_modifier[i] ?? string.Empty).ToString();
                            }

                        //if (item_name.Length < 30)
                        //{
                        //    gra.DrawString(item_name.ToString(), new System.Drawing.Font("Time New Roamn", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                        //   // ys = ys + 13;
                        //}
                        //else
                        //{
                        //    string break_item_name = item_name.Substring(0, 29);
                        //    gra.DrawString(break_item_name, new System.Drawing.Font("Time New Roamn", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 0, ys); ys = ys + 13;
                        //    if (29 < item_name.Length)
                        //    {
                        //        int length = Math.Abs(item_name.Length - break_item_name.Length);
                        //        gra.DrawString(item_name.Substring(29, length), new System.Drawing.Font("Time New Roamn", 9, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 0, ys); ys = ys + 13;
                        //    }
                        //}
                        gra.DrawString(item_name.ToString(), new System.Drawing.Font("Time New Roamn", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                        gra.DrawString(quantity, new System.Drawing.Font("Time New Roamn", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 250, ys); ys = ys + 13;
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
                        }
                    }

                

                    if (dt_printing_set.Rows[0]["discription"].ToString() == "True")
                    {
                        gra.DrawLine(drawingPen, 10, ys, 309, ys); ys = ys + 3;
                        gra.DrawString("Description", new System.Drawing.Font("Time New Roamn", 9, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 0, ys); ys = ys + 13;
                        gra.DrawString(note_pad, new System.Drawing.Font("Time New Roamn", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys); ys = ys + 13;                    
                    }
                if (kid != "")
                {
                    gra.DrawString("Children :", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 5, ys);
                    gra.DrawString(kid, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 90, ys); ys = ys + 13;
                }
                if (adult != "")
                {
                    gra.DrawString("Adult :", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 5, ys);
                    gra.DrawString(adult, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 90, ys); ys = ys + 13;
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
