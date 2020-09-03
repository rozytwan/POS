using BLLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System
{
    public partial class Dailycardreport : Form
    {
        public Dailycardreport()
        {
            InitializeComponent();
        }
        BLLRestSell blres = new BLLRestSell();
        BLLcardreport blcr = new BLLcardreport();
        BLLUser blu = new BLLUser();
        DateTime today = Convert.ToDateTime(DateTime.Today.ToShortDateString());
        public decimal club_card_sum;
        bool print_ok;
        private void Dailycardreport_Load(object sender, EventArgs e)
        {
            ClubCardsales();
            Sum_add_balance();
            Sum_cash_back();
            Fix_deposite();
            Fix_deposite_back();
            Card_no();
            DataTable dt1 = blcr.CardNo();
            decimal count = Convert.ToDecimal(dt1.Rows[0][0].ToString());
            DataTable dt = blcr.Getallbalance();

            if (dt.Rows[0][0].ToString() == "")
            {
                txt_balance.Text = "0.00";
            }
            else
            {
                txt_balance.Text = Convert.ToString(Convert.ToDecimal(dt.Rows[0][0].ToString()) - (count * 500));
            }
            DataTable dt_club_card_sales = blcr.Club_card_sales();
            if (dt_club_card_sales.Rows.Count > 0 && dt_club_card_sales.Rows[0][0].ToString()=="")
            {
                for (int i = 0; i < dt_club_card_sales.Rows.Count; i++)
                {
                    club_card_sum += Convert.ToDecimal(dt_club_card_sales.Rows[i][1].ToString());
                }
                txt_use_balance.Text = club_card_sum.ToString("#.##");
            }
            txt_remaining_balance.Text = Convert.ToString(Convert.ToDecimal(txt_add_balance.Text) - Convert.ToDecimal(txt_cash_back.Text));
        }
        public void ClubCardsales()
        {
            DataTable dt_club_card_sales = blres.Sum_Club_Card_Sales("X");
            if (dt_club_card_sales.Rows.Count > 0 && dt_club_card_sales.Rows[0][0].ToString() != ""&&dt_club_card_sales.Rows[0][0]!=null)
            {
                for (int i = 0; i < dt_club_card_sales.Rows.Count; i++)
                {
                    club_card_sum += Convert.ToDecimal(dt_club_card_sales.Rows[i][1].ToString());
                }
                txt_card_sales.Text = club_card_sum.ToString("#.##");
            }
        }
        public void Sum_add_balance()
        {
            DataTable dt = blcr.GetAddBalance("X");
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != null && dt.Rows[0][0].ToString() != "")
            {


                decimal sum_add_balance = Convert.ToDecimal(dt.Rows[0]["balance_add"].ToString());

                if (Convert.ToString(sum_add_balance) != "")
                {
                    txt_add_balance.Text = Convert.ToString(sum_add_balance);
                }
            }

        }
        public void Sum_cash_back()
        {
            DataTable dt = blcr.GetCashBack("X");
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != null && dt.Rows[0][0].ToString() != "")
            {
                decimal sum_cash_back = Convert.ToDecimal(dt.Rows[0]["cash_back"].ToString());

                if (Convert.ToString(sum_cash_back) != "")
                {
                    txt_cash_back.Text = Convert.ToString(sum_cash_back);
                }
            }

        }
        public void Fix_deposite()
        {
            DataTable dt = blcr.CardNo();
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != null && dt.Rows[0][0].ToString() != "")
            {
                decimal fix_deposite = Convert.ToDecimal(dt.Rows[0][0].ToString());


                txt_fix.Text = Convert.ToString(fix_deposite * 500);
            }


        }
        public void Fix_deposite_back()
        {
            DataTable dt = blcr.FixBack();
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != null && dt.Rows[0][0].ToString() != "")
            {
                decimal fix_deposite_back = Convert.ToDecimal(dt.Rows[0][0].ToString());

                if (Convert.ToString(fix_deposite_back) != "")
                {
                    txt_fix_back.Text = Convert.ToString(fix_deposite_back * 500);
                }
            }
        }
        public void Card_no()
        {
            DataTable dt = blcr.CardNo();
            txt_club_card.Text = ((dt.Rows[0][0].ToString()));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_dailycardreport_Click(object sender, EventArgs e)
        {
            printing_closing_report();
            if (print_ok == true)
            {

                //  int ib = blcwd.delete_care_of();
                // denominationInsert();
                printing_closing_report_pdf();
                // DatatoPdf();

                this.Close();
            }
        }
        public void printing_closing_report()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            System.Drawing.Font font = new System.Drawing.Font("Arial", 12);
            PaperSize psize = new PaperSize("Custome", 314, 1500);
            pd.Document = pdoc;
            pdoc.PrinterSettings.PrinterName = "B1";
            pdoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.DefaultPageSettings.PaperSize.Height = 1500;
            pdoc.DefaultPageSettings.PaperSize.Width = 314;

            if (pdoc.PrinterSettings.IsValid)
            {
                pdoc.Print();
                print_ok = true;
            }
            else
            {
                MessageBox.Show("Invalid Printer");
                DialogResult results = pd.ShowDialog();
                if (results == DialogResult.OK)
                {

                    pdoc.Print();
                    print_ok = true;
                }

            }
        }
        public void printing_closing_report_pdf()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            System.Drawing.Font font = new System.Drawing.Font("Arial", 12);
            PaperSize psize = new PaperSize("Custome", 314, 1500);
            pd.Document = pdoc;
            pdoc.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            pdoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.DefaultPageSettings.PaperSize.Height = 1500;
            pdoc.DefaultPageSettings.PaperSize.Width = 314;

            if (pdoc.PrinterSettings.IsValid)
            {
                pdoc.Print();
                print_ok = true;
            }
            else
            {
                MessageBox.Show("Invalid Printer");
                DialogResult results = pd.ShowDialog();
                if (results == DialogResult.OK)
                {

                    pdoc.Print();
                    print_ok = true;
                }

            }
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            float xs = 10;
            float ys = 5;
            int yinc = 0;
            int ybinc = 0;
            float widths = 285.0F; // max width I found through trial and error
            float heights = 0F;
            DataTable dtm = blu.checkbusiness();
            System.Drawing.Font drawFontArial12Bold = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            System.Drawing.Font drawFontArial10Regular = new System.Drawing.Font("Arial", 9, FontStyle.Regular);
            System.Drawing.Font drawFontArial10Regularsmall = new System.Drawing.Font("Arial", 6, FontStyle.Regular);
            SolidBrush drawBrush = new SolidBrush(System.Drawing.Color.Black);
            Pen drawingPen = new Pen(System.Drawing.Color.Black, 1);
            // Set format of string.
            StringFormat drawFormatCenter = new StringFormat();
            drawFormatCenter.Alignment = StringAlignment.Center;
            StringFormat drawFormatLeft = new StringFormat();
            drawFormatLeft.Alignment = StringAlignment.Near;
            StringFormat drawFormatRight = new StringFormat();
            drawFormatRight.Alignment = StringAlignment.Far;
            StringFormat drawFormatRightlest = new StringFormat();
            string business_name = dtm.Rows[0]["business_name"].ToString();
            string address = dtm.Rows[0]["address"].ToString();
            Graphics gra = e.Graphics;
            DateTime timedate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            DateTime strDate = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString());
            e.Graphics.DrawString(business_name, drawFontArial12Bold, drawBrush, new RectangleF(xs, ys, widths, heights), drawFormatCenter);
            ys += e.Graphics.MeasureString(business_name, drawFontArial12Bold).Height;
            if (business_name.Length >= 30)
            {
                ybinc = 13;
            }
            e.Graphics.DrawString(address, drawFontArial10Regular, drawBrush, new RectangleF(xs, ys + ybinc, widths, heights), drawFormatCenter);
            ys += e.Graphics.MeasureString(address, drawFontArial10Regular).Height;
            if (address.Length >= 40)
            {
                yinc = 15;
            }
            ybinc = 50 + ybinc + yinc;
            gra.DrawRectangle(drawingPen, 10, ybinc, 255, 20);

            gra.DrawString("Daily Card Report", new System.Drawing.Font("Arial", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 40, ybinc); ybinc = ybinc + 20;

            gra.DrawString("Log Out", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(strDate.ToString(), new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;

            gra.DrawRectangle(drawingPen, 10, ybinc, 255, 175); ybinc = ybinc + 5;
            gra.DrawString("Card Report Summery", new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 60, ybinc); ybinc = ybinc + 18;
            gra.DrawString("Card Sales", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(txt_card_sales.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Add Balance", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(txt_add_balance.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Total Club Card No", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(txt_club_card.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Total Cash Back", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(txt_cash_back.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Total Fix deposite", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(txt_fix.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Total Fix Return", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(txt_fix_back.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Total Remain Balance", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(txt_remaining_balance.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

        }
    }
}
