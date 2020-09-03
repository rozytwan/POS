using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BLLS;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace POS_System.Customer_Management
{
 public   class ClubCardBalanceReturn
    {
        public string customer_name;
        public string Card_type;
        public string card_no;
        public string user_name;
        public string cash_in_card;
        public string return_balance;
        public string card_bill_amount;
        public string non_refundable_balance;
        public string refundable_amount;
        public string cash_back_mode;
        public string useable_balance;
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
            DateTime strDate = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString());

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

            e.Graphics.DrawString("Cash Return Invoice", drawFontArial10Regular, drawBrush, new RectangleF(xs, ys + ybinc + yinc, widths, heights), drawFormatCenter);
            ys += e.Graphics.MeasureString("Cash Return Invoice", drawFontArial10Regular).Height;

            gra.DrawString(strDate.ToString(), new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = yinc + 15;
            gra.DrawString("Customer Name :", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            gra.DrawString(customer_name, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = yinc + 15;

            gra.DrawString("Card Type :", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            gra.DrawString(Card_type, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = yinc + 15;

            gra.DrawString("Card No :", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            gra.DrawString(card_no, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = yinc + 15;

            gra.DrawString("Cash In Card :", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            gra.DrawString(cash_in_card, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = yinc + 15;

            gra.DrawString("Card Bill Amount:", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            gra.DrawString(card_bill_amount, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = yinc + 15;

            gra.DrawString("Non Refundable Amount:", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            gra.DrawString(non_refundable_balance, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = yinc + 15;

            gra.DrawString("Refundable Amount:", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            gra.DrawString(refundable_amount, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = yinc + 15;

            gra.DrawString("Cash Back Mode:", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            gra.DrawString(cash_back_mode, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = yinc + 15;

            gra.DrawString("Avilable Balance:", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            gra.DrawString(refundable_amount, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = yinc + 15;

            gra.DrawString("Useable Balance:", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            gra.DrawString(useable_balance, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = yinc + 15;

            gra.DrawString("Fix Deposite:", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            gra.DrawString("500", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = yinc + 15;

            gra.DrawString("Cash Back:", new System.Drawing.Font("Times New Roman ", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            gra.DrawString(return_balance, new System.Drawing.Font("Times New Roman ", 12, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc); yinc = yinc + 65;

            gra.DrawLine(drawingPen, 0, 73 + ybinc + yinc, 100, 73 + ybinc + yinc);
            gra.DrawLine(drawingPen, 200, 73 + ybinc + yinc, 300, 73 + ybinc + yinc);
            yinc = yinc + 15;
            gra.DrawString("Customer Signature :", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 73 + ybinc + yinc);
            gra.DrawString(customer_name, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 88 + ybinc + yinc);

            gra.DrawString("Cashier Signature:", new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 73 + ybinc + yinc);
            gra.DrawString(user_name, new System.Drawing.Font("Times New Roman ", 8, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 200, 88 + ybinc + yinc);

        }
    }
}
