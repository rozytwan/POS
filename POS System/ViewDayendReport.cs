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
    public partial class ViewDayendReport : UserControl
    {
        public ViewDayendReport()
        {
            InitializeComponent();
        }
        Bll_dayend bllde = new Bll_dayend();
        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        public DateTime date;

        private void btn_show_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(cal_date.Text);

            DataTable dt = bllde.SearchDayEndByDate(Convert.ToDateTime(cal_date.Text));
            DataTable dt1 = bllde.SearchByDate(date);
            if (dt1.Rows.Count > 1)
            {
                
                dataGridView1.Rows.Clear();
                for (int inc = 0; inc < dt1.Rows.Count; inc++)
                {
                    int ww = dataGridView1.Rows.Add();
                    dataGridView1.Rows[inc].Cells["col_id"].Value = dt1.Rows[inc]["id"].ToString();
                    dataGridView1.Rows[inc].Cells["col_user"].Value = dt1.Rows[inc]["endby"].ToString();
                    dataGridView1.Rows[inc].Cells["col_date"].Value = Convert.ToDateTime(dt1.Rows[inc]["date"].ToString());

                }
              searchPanel.Hide();
                panel1.Hide();
                panel_list.Show();


            }
            else
            {
                if (dt1.Rows.Count > 0)
                {
                    lbl_logout_date.Text = dt1.Rows[0]["date"].ToString();
                    lbl_endby.Text = dt1.Rows[0]["endby"].ToString();
                    lbl_sub_total.Text = dt.Rows[0][0].ToString();
                    lbl_discount.Text = dt.Rows[0][1].ToString();
                    lbl_tax.Text = dt.Rows[0][2].ToString();
                    lbl_service_charge.Text = dt.Rows[0][3].ToString();
                    lbl_grand_total.Text = dt.Rows[0][4].ToString();
                    lbl_cash_sales.Text = dt.Rows[0][5].ToString();
                    lbl_card_sale.Text = dt.Rows[0][6].ToString();
                    lbl_credit.Text = dt.Rows[0][7].ToString();
                    lbl_cashin_counter.Text = dt.Rows[0][8].ToString();
                    lbl_counting_cash.Text = dt.Rows[0][9].ToString();
                    lbl_cash_settlement.Text = dt.Rows[0][10].ToString();
                    lbl_excess_shortage.Text = dt.Rows[0][11].ToString();
                    lbl_close_blc.Text = dt.Rows[0][12].ToString();
                    lbl_opening_blc.Text = dt.Rows[0][13].ToString();
                    lbl_cash.Text = dt.Rows[0][8].ToString();
                    lbl_cash_drop.Text = dt.Rows[0][14].ToString();
                    lbl_credit_received.Text = dt.Rows[0][15].ToString();

                    searchPanel.Hide();
                    panel_list.Hide();
                    panel1.Show();
                }

                else
                {
                    MessageBox.Show("Data in this date is not avialable", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
        }
        private void ViewDayendReport_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            panel1.AutoScroll = true;
            DateTime today = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            cal_date.Text = Convert.ToString(today);
            panel_list.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            searchPanel.Show();
            panel1.Hide();
        }

        private void btn_set_Click(object sender, EventArgs e)
        {
            printing_closing_report();
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
        BLLUser blu = new BLLUser();
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
            ybinc = 70 + ybinc + yinc;
            gra.DrawRectangle(drawingPen, 10, ybinc, 255, 20);

            gra.DrawString("Close Counter Report", new System.Drawing.Font("Arial", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 40, ybinc); ybinc = ybinc + 20;

            gra.DrawString("Session Date", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(timedate.ToString(), new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;


            gra.DrawString("Login Date", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lbl_logout_date.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;


            gra.DrawString("Reprint", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(strDate.ToString(), new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;


            gra.DrawString("Report By", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lbl_endby.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;




            gra.DrawRectangle(drawingPen, 10, ybinc, 255, 244); ybinc = ybinc + 5;

            gra.DrawString("Sales Summery", new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 60, ybinc); ybinc = ybinc + 18;
            gra.DrawString("Sub Total", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lbl_sub_total.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Total Discount", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lbl_discount.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Total Tax", new System.Drawing.Font("Arial", 9, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lbl_tax.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Total Service Charge", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lbl_service_charge.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Grand Total", new System.Drawing.Font("Arial", 13, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lbl_grand_total.Text, new System.Drawing.Font("Arial", 9, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 20;

            gra.DrawString("Sales By Cash", new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lbl_cash_sales.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Sales By Card", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lbl_card_sale.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Sales In Credit", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lbl_credit.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Total Cash In Counter ", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lbl_cashin_counter.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;


            gra.DrawString("Total Counting Cash ", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lbl_counting_cash.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Cash Settlement", new System.Drawing.Font("Arial", 9, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lbl_cash_settlement.Text, new System.Drawing.Font("Arial", 9, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Excess/Shortage ", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lbl_excess_shortage.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Closing Balance ", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lbl_close_blc.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;


            ybinc = ybinc + 20;
            gra.DrawRectangle(drawingPen, 10, ybinc, 255, 100);
            gra.DrawString("Cash Summery", new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 60, ybinc); ybinc = ybinc + 17;
            gra.DrawString("Opening Balance", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lbl_opening_blc.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Cash", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lbl_cash.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Cash Drop", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lbl_cash_drop.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;

            //gra.DrawString("Net Cash", new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            //gra.DrawString(lbl_.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Credit Received", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lbl_credit_received.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 27;

            //gra.DrawRectangle(drawingPen, 10, ybinc, 255, 90); ybinc = ybinc + 5;
            //gra.DrawString("Order Summery", new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 60, ybinc); ybinc = ybinc + 17;
            //gra.DrawString("Table Sales", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            //gra.DrawString(table_count, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 15;

            //gra.DrawString("Take Away", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            //gra.DrawString(take_away, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;

            //gra.DrawString("Delivery", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            //gra.DrawString(home_delivery, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;

            //gra.DrawString("Total Order", new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            //gra.DrawString((Convert.ToInt32(table_count) + Convert.ToInt32(take_away) + Convert.ToInt32(home_delivery)).ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); 
            ybinc = ybinc + 50;
            gra.DrawRectangle(drawingPen, 10, ybinc, 255, 90);

        }
        int id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col_view"].Index)
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_id"].Value);
                DataTable dt = bllde.DayendbyId(id);
                if (dt.Rows.Count>0)
                {
                    //lbl_logout_date.Text = dt1.Rows[0]["date"].ToString();
                    //lbl_endby.Text = dt1.Rows[0]["endby"].ToString();
                    lbl_sub_total.Text = dt.Rows[0]["subtotal"].ToString();
                    lbl_discount.Text = dt.Rows[0]["discount"].ToString();
                    lbl_tax.Text = dt.Rows[0]["tax"].ToString();
                    lbl_service_charge.Text = dt.Rows[0]["service_charge"].ToString();
                    lbl_grand_total.Text = dt.Rows[0]["grand_total"].ToString();
                    lbl_cash_sales.Text = dt.Rows[0]["totalcashsales"].ToString();
                    lbl_card_sale.Text = dt.Rows[0]["totalcardsales"].ToString();
                    lbl_credit.Text = dt.Rows[0]["credit"].ToString();
                    lbl_cashin_counter.Text = dt.Rows[0]["totalCashinCounter"].ToString();
                    lbl_counting_cash.Text = dt.Rows[0]["counting_cash"].ToString();
                    lbl_cash_settlement.Text = dt.Rows[0]["cash_sattlement"].ToString();
                    lbl_excess_shortage.Text = dt.Rows[0]["excess_shortage"].ToString();
                    lbl_close_blc.Text = dt.Rows[0]["closing_blc"].ToString();
                    lbl_opening_blc.Text = dt.Rows[0]["openingbalc"].ToString();
                    lbl_cash.Text = dt.Rows[0]["totalCashinCounter"].ToString();
                    lbl_cash_drop.Text = dt.Rows[0]["totalCareof"].ToString();
                    lbl_credit_received.Text = dt.Rows[0]["credit_paid"].ToString();

                    searchPanel.Hide();
                    panel_list.Hide();
                    panel1.Show();
                }
            }
           }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            panel_list.Hide();
            searchPanel.Show();
        }
    }
    }

