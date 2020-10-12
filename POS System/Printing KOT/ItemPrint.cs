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
   public class ItemPrint
    {
        BLLUser blu = new BLLUser();
        BLLkot_kitchen blps = new BLLkot_kitchen();   
        public string cashier;
        public string date_from;
        public string date_to;
        public List<string> datagridview_name = new List<string>();
        public List<string> datagridview_qty = new List<string>();
        public List<string> datagridview_cost = new List<string>();
        public List<string> datagridview_service_charge= new List<string>();
        
        public void printcalcel()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Arial", 12);
            PaperSize psize = new PaperSize("Custome", 314, 31000);
            pd.Document = pdoc;
            pdoc.PrinterSettings.PrinterName = "Billing";
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.DefaultPageSettings.PaperSize.Height = 31000;
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

                float xs = 10;
                float ys = 5;
                float widths = 250.0F;
                float heights = 0F;
                DataTable dtm = blu.checkbusiness();
                string business_name = "";
                string address = "";
                Font drawFontArial12Bold = new Font("Century Gothic", 12, FontStyle.Bold);
                Font drawFontArial10Regular = new Font("Century Gothic", 9, FontStyle.Regular);
                Font drawFontArial10Regularsmall = new Font("Century Gothic", 6, FontStyle.Regular);
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

              
                    if (dtm.Rows.Count > 0)
                    {
                        business_name = dtm.Rows[0]["business_name"].ToString();
                        address = dtm.Rows[0]["address"].ToString();
                    }
                   


                        e.Graphics.DrawString(business_name, drawFontArial12Bold, drawBrush, new RectangleF(xs, ys, widths, heights), drawFormatCenter);
                        ys += e.Graphics.MeasureString(business_name, drawFontArial12Bold).Height; ys = ys + 13;
                        if (business_name.Length >= 30)
                        {
                            ys = ys + 13;
                        }
                    
                   
                        e.Graphics.DrawString(address, drawFontArial10Regular, drawBrush, new RectangleF(xs, ys, widths, heights), drawFormatCenter);
                        ys += e.Graphics.MeasureString(address, drawFontArial10Regular).Height; ys = ys + 13;
                        if (address.Length >= 40)
                        {
                            ys = ys + 13;
                        }
                   
                  
                    gra.DrawString(strDate, new System.Drawing.Font("Century Gothic", 7, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ys); ys = ys + 13;

                gra.DrawString("From:", new System.Drawing.Font("Century Gothic", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                gra.DrawString(date_from, new System.Drawing.Font("Century Gothic", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 70, ys); ys = ys + 17;
                gra.DrawString("To:", new System.Drawing.Font("Century Gothic", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                gra.DrawString(date_to, new System.Drawing.Font("Century Gothic", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 70, ys); ys = ys + 17;
                gra.DrawString("UserName:", new System.Drawing.Font("Century Gothic", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                    gra.DrawString(cashier, new System.Drawing.Font("Century Gothic", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 100, ys); ys = ys + 17;


                    gra.DrawLine(drawingPen, 10, ys, 309, ys); ys = ys + 3;
                    gra.DrawString("SN", new System.Drawing.Font("Century Gothic", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                    gra.DrawString("Item", new System.Drawing.Font("Century Gothic", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 30, ys);
                    gra.DrawString("Qty", new System.Drawing.Font("Century Gothic", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 190, ys);
                    gra.DrawString("Cost", new System.Drawing.Font("Century Gothic", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 220, ys);
                     ys = ys + 13;
                    gra.DrawLine(drawingPen, 10, ys, 309, ys); ys = ys + 3;
                    for (int i = 0; i < datagridview_name.Count; i++)
                    {
                            string item_name = datagridview_name[i];
                            string quantity = datagridview_qty[i];
                            string cost = datagridview_cost[i];
                         gra.DrawString((i+1).ToString(), new System.Drawing.Font("Century Gothic", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ys);
                          gra.DrawString(item_name, new System.Drawing.Font("Century Gothic", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 20, ys);
                            gra.DrawString(quantity, new System.Drawing.Font("Century Gothic", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 190, ys);
                            gra.DrawString(cost, new System.Drawing.Font("Century Gothic", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 220, ys);
                              ys = ys + 13;
                    }

                  

                        gra.DrawLine(drawingPen, 10, ys, 309, ys); ys = ys + 3;
                        gra.DrawString("Description", new System.Drawing.Font("Century Gothic", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ys); ys = ys + 13;
                        gra.DrawString("Cancel", new System.Drawing.Font("Century Gothic", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ys); ys = ys + 13;

                    
                  
                
            }

            
        }

    }

