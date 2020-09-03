using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using BLLS;

namespace POS_System.CreditForm
{
    public class DayEndCreditList
    {
        BLLUser blu = new BLLUser();
        BLLcustomer_credit blcc = new BLLcustomer_credit();
        public void printCredit()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Arial", 12);
            PaperSize psize = new PaperSize("Custome", 314, 6000);
            pd.Document = pdoc;
            pdoc.PrinterSettings.PrinterName = "B1";
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.DefaultPageSettings.PaperSize.Height = 6000;
            pdoc.DefaultPageSettings.PaperSize.Width = 314;
            pdoc.PrintPage += new PrintPageEventHandler(printDocument1s_PrintPage);


            if (pdoc.PrinterSettings.IsValid)
            {
                pdoc.Print();

            }
            else
            {
                MessageBox.Show("Invalid Printer", "Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult results = pd.ShowDialog();
                if (results == DialogResult.OK)
                {

                    pdoc.Print();

                }
            }
        }
        private void printDocument1s_PrintPage(object sender, PrintPageEventArgs e)
        {
            float xs = 10;
            float ys = 7;
            int yinc = 0;
            int ybinc = 0;
            float widths = 285.0F; // max width I found through trial and error
            float heights = 0F;
            int y = 83;
            Pen drawingPen = new Pen(Color.Black, 1);
            Pen draw_watermark = new Pen(Color.FromArgb(64, Color.Black));
            Font drawFontArial12Bold = new Font("Arial", 12, FontStyle.Bold);
            Font drawFontArial10Regular = new Font("Arial", 9, FontStyle.Regular);
            Font drawFontArial10Regularsmall = new Font("Arial", 7, FontStyle.Regular);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            // Set format of string.
            StringFormat drawFormatCenter = new StringFormat();
            drawFormatCenter.Alignment = StringAlignment.Center;
            StringFormat drawFormatLeft = new StringFormat();
            drawFormatLeft.Alignment = StringAlignment.Near;
            StringFormat drawFormatRight = new StringFormat();
            drawFormatRight.Alignment = StringAlignment.Far;
            StringFormat drawFormatRightlest = new StringFormat();
            StringFormat format = new StringFormat(StringFormatFlags.DirectionRightToLeft);

            //
            DataTable dtm = blu.checkbusiness();
            string business_name = dtm.Rows[0]["business_name"].ToString();
            string address = dtm.Rows[0]["address"].ToString();
            string phone_no = dtm.Rows[0]["phone_no"].ToString();
            string note_1 = dtm.Rows[0]["note_1"].ToString();
            string note_2 = dtm.Rows[0]["note_2"].ToString();
            string pan_no = dtm.Rows[0]["pan_no"].ToString();

            Graphics gra = e.Graphics;
            //titel       
            DateTime strDate = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString());


            e.Graphics.DrawString(business_name, drawFontArial12Bold, drawBrush, new RectangleF(xs, ys, widths, heights), drawFormatCenter);
            ys += e.Graphics.MeasureString(business_name, drawFontArial12Bold).Height;
            if (business_name.Length >= 30)
            {
                ybinc = 17;
            }


            e.Graphics.DrawString(address, drawFontArial10Regular, drawBrush, new RectangleF(xs, ys + ybinc, widths, heights), drawFormatCenter);
            ys += e.Graphics.MeasureString(address, drawFontArial10Regular).Height;
            if (address.Length >= 40)
            {
                yinc = 15;
            }

            e.Graphics.DrawString(phone_no, drawFontArial10Regular, drawBrush, new RectangleF(xs, ys + ybinc + yinc, widths, heights), drawFormatCenter);
            ys += e.Graphics.MeasureString(phone_no, drawFontArial10Regular).Height;




            e.Graphics.DrawString("Credit List", drawFontArial10Regular, drawBrush, new RectangleF(xs, ys + ybinc + yinc, widths, heights), drawFormatCenter);
            ys += e.Graphics.MeasureString("Credit Invoice", drawFontArial10Regular).Height;





            gra.DrawString("Date :", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, y + ybinc + yinc);
            gra.DrawString(DateTime.Now.ToLongTimeString(), new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 180, y + ybinc + yinc);
            y = y + 13;

            gra.DrawLine(drawingPen, 0, y + ybinc + yinc, 314, y + ybinc + yinc);
            y = y + 5;
            gra.DrawString("Customer Name", new System.Drawing.Font("Arial", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 5, y + ybinc + yinc);
            gra.DrawString("Bill No", new System.Drawing.Font("Arial", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 150, y + ybinc + yinc);
            gra.DrawString("Total", new System.Drawing.Font("Arial", 8, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 230, y + ybinc + yinc);
            y = y + 13;
            gra.DrawLine(drawingPen, 0, y + ybinc + yinc, 314, y + ybinc + yinc);
            y = y + 5;
            DataTable dt = blcc.GetALltodayCreditList();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string customer_name = dt.Rows[i]["name"].ToString();
                    string bill_no = dt.Rows[i]["bill_no"].ToString();
                    string credit_amount = dt.Rows[i]["creadit_amount"].ToString();


                    gra.DrawString(customer_name, new System.Drawing.Font("Time New Roamn", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, y + ybinc + yinc);
                    gra.DrawString(bill_no, new System.Drawing.Font("Time New Roamn", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, y + ybinc + yinc);
                    gra.DrawString(credit_amount, new System.Drawing.Font("Time New Roamn", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, y + ybinc + yinc);
                }
            }
        }
    }

  }
