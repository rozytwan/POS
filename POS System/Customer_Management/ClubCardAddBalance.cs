using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Drawing.Printing;
using System.Windows.Forms;
using BLLS;

namespace POS_System.Customer_Management
{
    public class ClubCardAddBalance
    {
        public string customer_name;
        public string Card_type;
        public string card_no;
        public string user_name;
        public string preview_balance;
        public string topup_balance;
        public string balance_type;
        public string fix_expend;
        public string recharge_type;
        public string fix_balance;
        BLLUser blu = new BLLUser();
        public void printtobill()
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
        PictureBox pb1 = new PictureBox();
        private void printDocument1s_PrintPage(object sender, PrintPageEventArgs e)
        {
            float xs = 10;
            float ys = 7;
            int yinc = 0;
            int ybinc = 0;
            float widths = 285.0F; // max width I found through trial and error
            float heights = 0F;
            //string price;
            //string name; string quantity; string totala; int y = 83;
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

            Graphics gra = e.Graphics;
            //
            DataTable dtm = blu.checkbusiness();
            if (dtm.Rows.Count > 0)
            {
                string business_name = dtm.Rows[0]["business_name"].ToString();
                string address = dtm.Rows[0]["address"].ToString();
                string phone_no = dtm.Rows[0]["phone_no"].ToString();
                string note_1 = dtm.Rows[0]["note_1"].ToString();
                string note_2 = dtm.Rows[0]["note_2"].ToString();
                string pan_no = dtm.Rows[0]["pan_no"].ToString();

               
                //titel       
              

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
                }
            DateTime strDate = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString());
            e.Graphics.DrawString("Topup Invoice", drawFontArial10Regular, drawBrush, new RectangleF(xs, ys + ybinc + yinc, widths, heights), drawFormatCenter);
            ys += e.Graphics.MeasureString("Topup Invoice", drawFontArial10Regular).Height;

            gra.DrawString(strDate.ToString(), new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc); yinc = yinc + 15;
            gra.DrawString("Customer Name :", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            gra.DrawString(customer_name, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc);yinc = yinc + 15;

            gra.DrawString("Card Type :", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            gra.DrawString(Card_type, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = yinc + 15;

            gra.DrawString("Card No :", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            gra.DrawString(card_no, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = yinc + 15;

            gra.DrawString("Previous Balance :", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            gra.DrawString(preview_balance, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = yinc + 15;
            gra.DrawString("Balance Type :", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            gra.DrawString(balance_type, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = yinc + 15;

            gra.DrawString("Fix Expend :", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            gra.DrawString(fix_expend, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = yinc + 15;

            gra.DrawString("Fix Balance :", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            gra.DrawString(fix_balance, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = yinc + 15;

            gra.DrawString("Topup Balance:", new System.Drawing.Font("Times New Roman ", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            gra.DrawString(topup_balance, new System.Drawing.Font("Times New Roman ", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = 
                yinc + 20;
            gra.DrawString("Recharge Type:", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            gra.DrawString(recharge_type, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = yinc + 65;


            gra.DrawLine(drawingPen, 0, 73 + ybinc + yinc, 100, 73 + ybinc + yinc) ;
            gra.DrawLine(drawingPen, 200, 73 + ybinc + yinc, 300, 73 + ybinc + yinc);
            yinc = yinc + 15;
            gra.DrawString("Customer Signature :", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            gra.DrawString(customer_name, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 88 + ybinc + yinc);

            gra.DrawString("Cashier Signature:", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc);
            gra.DrawString(user_name, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 88 + ybinc + yinc);

        }
    }
}
