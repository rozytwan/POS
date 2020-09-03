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
    public class KotCancel80
    {

        BLLUser blu = new BLLUser();
        BLLkot_kitchen blps = new BLLkot_kitchen();
        public string table_no;
        public string table_displayNo;
        public string table_name;
        public bool kot_printer_1;
        public string note_pad;
        public bool kot_printer_2;
        public bool kot_printer_3;
        public string printer_name;
        public string cashier;
        public List<string> datagridview_name = new List<string>();
        public List<string> datagridview_qty = new List<string>();
        public List<string> datagridview_kot_print = new List<string>();
        public List<string> datagridview_modifier = new List<string>();
        public void printcalcel()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Arial", 12);
            PaperSize psize = new PaperSize("Custome", 314, 3600);
            pd.Document = pdoc;
            pdoc.PrinterSettings.PrinterName = printer_name;
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.DefaultPageSettings.PaperSize.Height = 3600;
            pdoc.DefaultPageSettings.PaperSize.Width = 314;
            pdoc.PrintPage += new PrintPageEventHandler(printDocument1calcel_PrintPage);

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

        private void printDocument1calcel_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {


                float xs = 10;
                float ys = 5;
                float widths = 285.0F;
                float heights = 0F;
                DataTable dtm = blu.checkbusiness();
                string business_name = "";
                string address = "";
                Font drawFontArial12Bold = new Font("Arial", 12, FontStyle.Bold);
                Font drawFontArial10Regular = new Font("Arial", 9, FontStyle.Regular);
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
                String strDate = DateTime.Now.ToLongTimeString();

                Graphics gra = e.Graphics;

                DataTable dt_prtinting_set = blps.getall_kot_data();
                if (dt_prtinting_set.Rows.Count > 0)
                {

                    if (dtm.Rows.Count > 0)
                    {
                        business_name = dtm.Rows[0]["business_name"].ToString();
                        address = dtm.Rows[0]["address"].ToString();
                    }
                    if (dt_prtinting_set.Rows[0]["business_name"].ToString() == "True")
                    {


                        e.Graphics.DrawString(business_name, drawFontArial12Bold, drawBrush, new RectangleF(xs, ys, widths, heights), drawFormatCenter);
                        ys += e.Graphics.MeasureString(business_name, drawFontArial12Bold).Height; ys = ys + 13;
                        if (business_name.Length >= 30)
                        {
                            ys = ys + 13;
                        }
                    }
                    if (dt_prtinting_set.Rows[0]["address"].ToString() == "True")
                    {
                        e.Graphics.DrawString(address, drawFontArial10Regular, drawBrush, new RectangleF(xs, ys, widths, heights), drawFormatCenter);
                        ys += e.Graphics.MeasureString(address, drawFontArial10Regular).Height; ys = ys + 13;
                        if (address.Length >= 40)
                        {
                            ys = ys + 13;
                        }
                    }
                    if (dt_prtinting_set.Rows[0]["take_away"].ToString() == "True")
                    {
                        if (Convert.ToDecimal(table_no) >= 106)
                        {
                            if (Convert.ToDecimal(table_no) < 1000)
                            {
                                gra.DrawString("Home Delivery ::", new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ys);
                                gra.DrawString(table_displayNo, new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 250, ys); ys = ys + 13;
                            }
                            else
                            {
                                if (table_name == "DA")
                                {
                                    gra.DrawString("Dinning ::", new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 60, ys);
                                    gra.DrawString(table_displayNo, new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 120, ys); ys = ys + 13;

                                }
                                else
                                {
                                    gra.DrawString("Take Away ::", new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 60, ys);
                                    gra.DrawString(table_displayNo, new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 120, ys); ys = ys + 13;
                                }
                            }
                        }

                        else if (Convert.ToDecimal(table_no) <= 519)
                        {
                            if (Convert.ToDecimal(table_no) <= 99)
                            {
                                gra.DrawString("Table No::", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                                gra.DrawString(table_displayNo, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 80, ys); ys = ys + 13;
                                gra.DrawString("Name::", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                                gra.DrawString(table_name, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 80, ys); ys = ys + 13;
                            }

                            else
                            {
                                gra.DrawString("Room No::", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 190, ys);
                                gra.DrawString(table_displayNo, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 250, ys); ys = ys + 13;
                            }
                        }
                    }
                    gra.DrawString(strDate, new System.Drawing.Font("Arial", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ys); ys = ys + 13;

                    gra.DrawString("UserName :", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ys);
                    gra.DrawString(cashier, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 230, ys); ys = ys + 13;


                    gra.DrawLine(drawingPen, 10, ys, 309, ys); ys = ys + 3;
                    gra.DrawString("Item", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 30, ys);
                    gra.DrawString("Qty", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 250, ys); ys = ys + 13;
                    gra.DrawLine(drawingPen, 10, ys, 309, ys); ys = ys + 7;
                    if (datagridview_name.Count > 0)
                    {
                        for (int i = 0; i < datagridview_name.Count; i++)
                        {
                            if (datagridview_kot_print[i] == printer_name)
                            {
                                string item_name = datagridview_name[i].ToString();
                                string quantity = datagridview_qty[i];

                                gra.DrawString(item_name, new System.Drawing.Font("Time New Roamn", 9, FontStyle.Strikeout), new SolidBrush(System.Drawing.Color.Black), 30, ys);
                                gra.DrawString(quantity, new System.Drawing.Font("Time New Roamn", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 250, ys); ys = ys + 13;
                            }
                            
                        }
                    }
                    
                   

                    if (dt_prtinting_set.Rows[0]["discription"].ToString() == "True")
                    {

                        gra.DrawLine(drawingPen, 10, ys, 309, ys); ys = ys + 3;
                        gra.DrawString("Description", new System.Drawing.Font("Time New Roamn", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ys); ys = ys + 13;
                        gra.DrawString("Cancel", new System.Drawing.Font("Time New Roamn", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ys); ys = ys + 13;

                       
                    }
                }
                kot_printer_1 = false;
                clear_data();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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



