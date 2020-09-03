using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLS;
using System.Drawing.Printing;
using System.Net.Mail;
using System.IO;

namespace POS_System
{
    public partial class ShiftChange : Form
    {
        public ShiftChange()
        {
            InitializeComponent();
        }
        BLLcustomer_credit blcc = new BLLcustomer_credit();
        BLLSift_Change blsc = new BLLSift_Change();
        BLLUser blu = new BLLUser();
        Bll_cashcounter blcas = new Bll_cashcounter();
        BLLRestSell blres = new BLLRestSell();

        string care_of = "0.00";
        string care_of_by_user = "0.00";
        string table_count;
        string take_away;
        string cancel_item;
        string home_delivery;      
        public decimal cash_sum;
        public decimal card_sum;
        public decimal grand_total_sum;
        public decimal sub_total_sum;
        public decimal service_charge;
        public decimal tax;
        public decimal discount;
        public decimal zomato_sum;
        public decimal credit_sum;
        public decimal credit_recive_amount;
        public decimal credit_recive_amountBYCard;
        public bool print_ok;
        public decimal club_card_sum;
        string login_date;
        decimal creditCashSum = 0;
        decimal creditCardSum = 0;
        public string opening_balance = "0.00";
        DateTime date_now = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        private void ShiftChange_Load(object sender, EventArgs e)
        {
            txtuser_name.Text = Login.sendtext;

            DataTable dt = blcas.get_oening_balance_details();
            if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "")
            {
                DataTable dt_opening = blcas.getopeningbalance();
                opening_balance = dt_opening.Rows[0][0].ToString();

            }
            DataTable dt_login_time = blsc.get_login_time_staff_name(txtuser_name.Text, date_now);
            if (dt_login_time.Rows.Count > 0)
            {
                login_date = dt_login_time.Rows[0]["working_date"].ToString();
            }
            DataTable dt_grand_sum = blsc.sum_grand_total_by_user(txtuser_name.Text, "X");
            if (dt_grand_sum.Rows.Count > 0 && dt_grand_sum.Rows[0][0].ToString() != "")
            {
                for (int i = 0; dt_grand_sum.Rows.Count > i; i++)
                {
                    grand_total_sum += Convert.ToDecimal(dt_grand_sum.Rows[i][1].ToString());
                    sub_total_sum += Convert.ToDecimal(dt_grand_sum.Rows[i][2].ToString());
                }
                txttotal_sales.Text = sub_total_sum.ToString();
                txt_grand_total.Text = grand_total_sum.ToString();
             }
            DataTable dt_tax_service_discount = blsc.Sum_service_tax_discount(txtuser_name.Text, "X");
            if (dt_tax_service_discount.Rows.Count > 0 && dt_tax_service_discount.Rows[0][0].ToString() != "")
            {
                for (int i = 0; dt_grand_sum.Rows.Count > i; i++)
                {
                  
                    service_charge += Convert.ToDecimal(dt_tax_service_discount.Rows[i]["service_charge"].ToString());
                    tax += Convert.ToDecimal(dt_tax_service_discount.Rows[i]["tax_amount"].ToString());
                    discount += Convert.ToDecimal(dt_tax_service_discount.Rows[i]["discount"].ToString());
                }
           
                txt_service_charge.Text = service_charge.ToString();
                txt_tax.Text = tax.ToString();
                txt_discount.Text = discount.ToString();

            }
            DataTable dt_cash_sale_sum = blsc.sum_grand_total_by_user_cash(txtuser_name.Text, "X");
            if (dt_cash_sale_sum.Rows.Count > 0 && dt_cash_sale_sum.Rows[0][0].ToString() != "")
            {

                for (int i = 0; dt_cash_sale_sum.Rows.Count > i; i++)
                {
                    cash_sum += Convert.ToDecimal(dt_cash_sale_sum.Rows[i][1].ToString());
                }
                txtcash_sales.Text = cash_sum.ToString();
            }
            DataTable dt_zomato_sale_sum = blsc.sum_zomato_sales(txtuser_name.Text, "X");
            if (dt_zomato_sale_sum.Rows.Count > 0 && dt_zomato_sale_sum.Rows[0][0].ToString() != "")
            {
                for (int i = 0; dt_zomato_sale_sum.Rows.Count > i; i++)
                {
                    zomato_sum += Convert.ToDecimal(dt_zomato_sale_sum.Rows[i][1].ToString());
                }
            }
            DataTable dt_card_sale_sum = blsc.sum_card_sale(txtuser_name.Text,"X");
            if (dt_card_sale_sum.Rows.Count > 0 && dt_card_sale_sum.Rows[0][0].ToString() != "")
            {
                for (int i = 0; dt_card_sale_sum.Rows.Count > i; i++)
                {
                    card_sum += Convert.ToDecimal(dt_card_sale_sum.Rows[i][1].ToString());
                }
                txtcard_sales.Text = (card_sum+zomato_sum).ToString();
            }
            DataTable dt_care_of = blsc.sum_get_care_of_by_user(txtuser_name.Text);
            if (dt_care_of.Rows.Count > 0 && dt_care_of.Rows[0][0].ToString() != "")
            {
                care_of = dt_care_of.Rows[0][0].ToString();
            }
            DataTable dt_care_of_by_user = blsc.sum_get_care_of_by_user(txtuser_name.Text);
            if (dt_care_of_by_user.Rows.Count > 0 && dt_care_of_by_user.Rows[0][0].ToString() != "")
            {
                care_of_by_user = dt_care_of_by_user.Rows[0][0].ToString();
                txt_cash_drop.Text = care_of.ToString();
            }
            DataTable dt_sum_credit_amount = blsc.Sum_Credit_Amount("X",txtuser_name.Text);
            if (dt_sum_credit_amount.Rows.Count > 0)
            {
                for (int i = 0; i < dt_sum_credit_amount.Rows.Count; i++)
                {
                    credit_sum += Convert.ToDecimal(dt_sum_credit_amount.Rows[i][1].ToString());
                }
              txt_credit_sales.Text = credit_sum.ToString("#.##");
            }
            //Credit Calculation
          
            DataTable dt_credit_receive_byusername = blcc.Get_Credit_Receive_ByUsernameandCash(txtuser_name.Text,"X");
            if (dt_credit_receive_byusername.Rows.Count > 0 && dt_credit_receive_byusername.Rows[0][0].ToString() != "")
            {
                creditCashSum = (Convert.ToDecimal(dt_credit_receive_byusername.Rows[0][0].ToString()));
            }
            DataTable dt_credit_receive_byusernameCard = blcc.Get_Credit_Receive_ByUsernameandCard(txtuser_name.Text, "X");
            if (dt_credit_receive_byusernameCard.Rows.Count > 0 && dt_credit_receive_byusernameCard.Rows[0][0].ToString() != "")
            {
                creditCardSum = (Convert.ToDecimal(dt_credit_receive_byusernameCard.Rows[0][0].ToString()));
                txt_credit_receive.Text = (creditCardSum + creditCashSum).ToString();

            }
           

            DataTable dt_total_cash_counter_sum = blsc.sum_total_cash_counter();
            if (dt_total_cash_counter_sum.Rows.Count > 0 && dt_total_cash_counter_sum.Rows[0][0].ToString() != "")
            {
                txt_opening_balance.Text = dt_total_cash_counter_sum.Rows[0][0].ToString();
                txtcash_counter.Text = (Convert.ToDecimal(dt_total_cash_counter_sum.Rows[0][0].ToString()) + Convert.ToDecimal(txtcash_sales.Text) + creditCashSum - Convert.ToDecimal(care_of)).ToString();
            }
            DataTable dt_tbl_sale_count = blsc.Count_total_Table(txtuser_name.Text);
            if (dt_tbl_sale_count.Rows.Count > 0 && dt_tbl_sale_count.Rows[0][0].ToString() != "")
            {
                table_count = dt_tbl_sale_count.Rows.Count.ToString();
            }
            DataTable dt_tbl_sale_Take_away = blsc.count_total_takeaway(txtuser_name.Text);
            if (dt_tbl_sale_Take_away.Rows.Count > 0 && dt_tbl_sale_Take_away.Rows[0][0].ToString() != "")
            {
               take_away = dt_tbl_sale_Take_away.Rows[0][0].ToString();
             }
            DataTable dt_count_cancel = blsc.count_cancelitem(txtuser_name.Text, Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            if (dt_count_cancel.Rows.Count > 0 && dt_count_cancel.Rows[0][0].ToString() != "")
            {
                cancel_item = dt_count_cancel.Rows[0][0].ToString();
                txt_cancel.Text = cancel_item;
            }
            DataTable dt_busy_table_count = blsc.count_total_table_busy();
            if (dt_busy_table_count.Rows.Count > 0 && dt_busy_table_count.Rows[0][0].ToString() != "")
            {
                txtbusy_table.Text = dt_busy_table_count.Rows.Count.ToString();
            }
            DataTable dt_busy_hd_count = blsc.count_total_home_delivery_left(txtuser_name.Text);
            if (dt_busy_hd_count.Rows.Count > 0 && dt_busy_hd_count.Rows[0][0].ToString() != "")
            {
                home_delivery = dt_busy_hd_count.Rows.Count.ToString();
            }

            DataTable dt_busy_TS_cash_count = blsc.count_total_cost_to_be_recived_ts();
            if (dt_busy_TS_cash_count.Rows.Count > 0 && dt_busy_TS_cash_count.Rows[0][0].ToString() != "")
            {
                txtamount_hold_by_table.Text = dt_busy_TS_cash_count.Rows[0][0].ToString();
            }
            DataTable dt_delivery_amount_hold = blsc.Sum_hold_By_HomeDelivery(txtuser_name.Text);
            if (dt_delivery_amount_hold.Rows.Count > 0 && dt_delivery_amount_hold.Rows[0][0].ToString() != "")
            {
                txt_amount_hold_from_hd.Text = dt_delivery_amount_hold.Rows[0][0].ToString();
            }
            DataTable dt_club_card_sales = blsc.Sum_Club_Card_Sales("X",txtuser_name.Text);
            if (dt_club_card_sales.Rows.Count > 0)
            {
                for (int i = 0; i < dt_club_card_sales.Rows.Count; i++)
                {
                    club_card_sum += Convert.ToDecimal(dt_club_card_sales.Rows[i][1].ToString());
                }
                txt_club_card.Text = club_card_sum.ToString("#.##");
            }
        }

       private void button2_Click(object sender, EventArgs e)
        {
            if (txt_cashsettlement.Text == "0.00" || txt_counting_cash.Text == "0.00")
            {
                MessageBox.Show("Cash settlement is required");
            }
            else
            {
                printing_closing();
                if (print_ok == true)
                {
                    int i = blsc.insert_into_tbl(txtuser_name.Text, Convert.ToDecimal(txtcash_counter.Text), Convert.ToDecimal(txtcard_sales.Text), Convert.ToDecimal(txttotal_sales.Text), Convert.ToDecimal(txtcash_counter.Text), txtbusy_table.Text, Convert.ToDecimal(txtamount_hold_by_table.Text), Convert.ToDecimal(txt_amount_hold_from_hd.Text), "0.00", txt_hand_over_to.Text, date_now, date_now, Convert.ToDecimal(txt_cash_drop.Text), Convert.ToDecimal(txt_service_charge.Text), Convert.ToDecimal(txt_tax.Text), Convert.ToDecimal(txt_discount.Text), Convert.ToDecimal(txt_grand_total.Text),Convert.ToDecimal(txt_counting_cash.Text),Convert.ToDecimal(txt_closing_balance.Text),Convert.ToDecimal(txt_cashsettlement.Text));
                    if (i > 0)
                    {
                        printing_closing_report_pdf();
                        this.Close();
                    }
                    print_ok = false;
                }
            }
        }
        public void printing_closing()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            System.Drawing.Font font = new System.Drawing.Font("Arial", 12);
            PaperSize psize = new PaperSize("Custome", 314, 500);
            pd.Document = pdoc;
            pdoc.PrinterSettings.PrinterName = "Billing";
            pdoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.DefaultPageSettings.PaperSize.Height = 500;
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
            PaperSize psize = new PaperSize("Custome", 314, 500);
            pd.Document = pdoc;
            pdoc.PrinterSettings.PrinterName = "Microsoft Print to PDF";
            pdoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.DefaultPageSettings.PaperSize.Height = 500;
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
            float widths = 285.0F; //max width I found through trial and error
            float heights = 0F;
            DataTable dtm = blu.checkbusiness();
            System.Drawing.Font drawFontArial12Bold = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            System.Drawing.Font drawFontArial10Regular = new System.Drawing.Font("Arial", 9, FontStyle.Regular);
            System.Drawing.Font drawFontArial10Regularsmall = new System.Drawing.Font("Arial", 6, FontStyle.Regular);
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
                yinc = 10;
            }
            gra.DrawRectangle(drawingPen, 10, 75 + ybinc + yinc, 255, 20);
            gra.DrawString("Shift Change Report", new System.Drawing.Font("Arial", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 40, 75 + ybinc + yinc);
            gra.DrawString("Session Date", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 95 + ybinc + yinc);
            gra.DrawString("Login Date", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 110 + ybinc + yinc);
            gra.DrawString("Log Out", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 125 + ybinc + yinc);
            gra.DrawString("Report Of", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 140 + ybinc + yinc);
           // gra.DrawString("Balance Set By", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 155 + ybinc + yinc);


            gra.DrawString(timedate.ToString(), new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, 95 + ybinc + yinc);
            gra.DrawString(login_date, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, 110 + ybinc + yinc);
            gra.DrawString(strDate.ToString(), new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, 125 + ybinc + yinc);
            gra.DrawString(txtuser_name.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, 140 + ybinc + yinc);
            //gra.DrawString(set_by, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, 155 + ybinc + yinc);

            gra.DrawRectangle(drawingPen, 10, 170 + ybinc + yinc, 255, 200);
            gra.DrawString("Sales Summery", new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 60, 175 + ybinc + yinc);
           
            gra.DrawString("Total Sales", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 195 + ybinc + yinc);
            gra.DrawString(txttotal_sales.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, 195 + ybinc + yinc);
            gra.DrawString("Total Discount", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 210 + ybinc + yinc);
            gra.DrawString(txt_discount.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, 210 + ybinc + yinc);
            gra.DrawString("Total Tax", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 225 + ybinc + yinc);
            gra.DrawString(txt_tax.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, 225 + ybinc + yinc);
            gra.DrawString("Service Charge", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 240 + ybinc + yinc);
            gra.DrawString(txt_service_charge.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, 240 + ybinc + yinc);
            gra.DrawString("Grand Total", new System.Drawing.Font("Arial", 9, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, 255 + ybinc + yinc);
            gra.DrawString(txt_grand_total.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, 255 + ybinc + yinc);
            gra.DrawString("Sales By Cash", new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 270 + ybinc + yinc);
            gra.DrawString(txtcash_sales.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, 270 + ybinc + yinc);
            gra.DrawString("Sales By Card", new System.Drawing.Font("Arial", 9, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, 285 + ybinc + yinc);
            gra.DrawString(txtcard_sales.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, 285 + ybinc + yinc);
            gra.DrawString("Cash In Counter", new System.Drawing.Font("Arial", 9, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, 300 + ybinc + yinc);
            gra.DrawString(txtcash_counter.Text, new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, 300 + ybinc + yinc);
            gra.DrawString("Counting Cash", new System.Drawing.Font("Arial", 9, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, 315 + ybinc + yinc);
            gra.DrawString(txt_counting_cash.Text, new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, 315 + ybinc + yinc);
            gra.DrawString("Cash Settlement", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, 330 + ybinc + yinc);
            gra.DrawString(txt_cashsettlement.Text, new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, 330 + ybinc + yinc);
            gra.DrawString("Closing Balance", new System.Drawing.Font("Arial", 9, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, 345 + ybinc + yinc);

            gra.DrawString(txt_closing_balance.Text, new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, 345 + ybinc + yinc);
            // gra.DrawString("Sales By Zomato", new System.Drawing.Font("Arial", 9, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, 300 + ybinc + yinc);

            // gra.DrawString(txt_zomato.Text, new System.Drawing.Font("Arial", 9, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 130, 300 + ybinc + yinc);

            gra.DrawRectangle(drawingPen, 10, 385 + ybinc + yinc, 255, 120);
            gra.DrawString("Cash Summery", new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 60, 390 + ybinc + yinc);
            yinc = yinc + 390 +15;
            gra.DrawString("Opening Balance", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10,  yinc);
            gra.DrawString(opening_balance, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130,  yinc); yinc = yinc + 15;
            gra.DrawString("Cash", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10,  yinc);
            gra.DrawString(txtcash_sales.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130,  yinc); yinc = yinc + 15;
            gra.DrawString("Cash Drop", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10,  yinc);
            gra.DrawString(care_of, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130,  yinc); yinc = yinc + 15;
            gra.DrawString("Cash In Counter", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10,  yinc);
            gra.DrawString(txtcash_counter.Text, new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 130, yinc); yinc = yinc + 15;
            gra.DrawString("Credit Cash Receive", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10,  yinc);
            gra.DrawString(creditCashSum.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 130,  yinc); yinc = yinc + 15;
            gra.DrawString("Credit Card Receive", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10,   yinc);
            gra.DrawString(creditCardSum.ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 130,  yinc); yinc = yinc + 15;
            gra.DrawString("Net Cash", new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10,  yinc);
         
            gra.DrawString((Convert.ToDecimal(txtcash_sales.Text) + creditCashSum + Convert.ToDecimal(opening_balance)).ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 130,  yinc); yinc = yinc + 20;

            gra.DrawRectangle(drawingPen, 10, 520 + ybinc + yinc, 255, 160);
            gra.DrawString("Order Summery", new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 60,  yinc); yinc = yinc + 15;
            gra.DrawString("Table Sales", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, yinc);
            gra.DrawString(table_count, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 160,  yinc); yinc = yinc + 15;
            gra.DrawString("Take Away", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, yinc);
            gra.DrawString(take_away, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 160, yinc); yinc = yinc + 15;

            gra.DrawString("Delivery", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, yinc);
            gra.DrawString(home_delivery, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 160,  yinc); yinc = yinc + 15;
            gra.DrawString("Total Order", new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10,  yinc);
            gra.DrawString((Convert.ToInt32(table_count) + Convert.ToInt32(take_away) + Convert.ToInt32(home_delivery)).ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 160,yinc); yinc = yinc + 15;
            gra.DrawString("Total Order Cancel", new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10,  yinc);
            gra.DrawString(cancel_item, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 160, yinc); yinc = yinc + 15;
            gra.DrawString("Total Table To Received", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10,  yinc);
            gra.DrawString(txtamount_hold_by_table.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 160,  yinc); yinc = yinc + 15;
            gra.DrawString("Total HD To Received", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10,  yinc);
            gra.DrawString(txt_amount_hold_from_hd.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 160,  yinc); yinc = yinc + 15;
            gra.DrawString("Total Busy Table", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10,  yinc);
            gra.DrawString(txtbusy_table.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 160,  yinc); yinc = yinc + 15;

            gra.DrawString("Hand Over To", new System.Drawing.Font("Arial", 9, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, yinc);
            gra.DrawString(txt_hand_over_to.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 160,  yinc); yinc = yinc + 15;
        }

        private void bth_panel_close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void txt_hand_over_to_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btn_denomation_Click(object sender, EventArgs e)
        {
            Denomination dm = new Denomination();
            dm.ShowDialog();
            txt_counting_cash.Text = dm.total;
        }

        private void txt_cashsettlement_TextChanged(object sender, EventArgs e)
        {
            if (txt_cashsettlement.Text != "")
            {
                txt_closing_balance.Text = Convert.ToString(Convert.ToDecimal(txt_counting_cash.Text) - Convert.ToDecimal(txt_cashsettlement.Text));

            }
            else if (txt_cashsettlement.Text == "")
            {
                txt_cashsettlement.Text = "";
            }
        }

        private void btn_mail_Click(object sender, EventArgs e)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                //From To Boyd Subject
                MailMessage message = new MailMessage("twanjurozy@gmail.com","rozytwan@gmail.com","Day end toady","sales report");
        
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                txt_closing_balance.Text = "myfile";
                string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "CustomerForms" + "\\" +txt_closing_balance.Text+".pdf";
                if (File.Exists(folderPath))
                {
               message.Attachments.Add(new Attachment(folderPath));
                }
                client.Credentials = new System.Net.NetworkCredential("twanjurozy@gmail.com", "rozy3140");
                client.Send(message);
                message = null;
            }
            catch
            {
                MessageBox.Show("May Be Wrong Password Alert !!", "Oops Something Went Wrong !!");
            }
            //System.Net.Mail.Attachment attachment;
            //attachment = new System.Net.Mail.Attachment("your attachment file");
            //mail.Attachments.Add(attachment);
        }
    }
}
