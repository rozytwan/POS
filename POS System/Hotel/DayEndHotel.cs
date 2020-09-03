using BLLS;
using BLLS.Hotel;
using ClosedXML.Excel;
using Customer_Management;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using POS_System.CreditForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace POS_System
{
    public partial class DayEndHotel : Form
    {
        public DayEndHotel()
        {
            InitializeComponent();
        }
        Bll_cashcounter blcas = new Bll_cashcounter();
        BLLUser blu = new BLLUser();
        Bll_CashwithDrawl blcwd = new Bll_CashwithDrawl();
        BLL_DayendHotel bllh = new BLL_DayendHotel();
        string login_date;
        string set_by;
        decimal discount = 0;
        string care_of = "0.00";
        string table_count = "0";
        string take_away = "0";
        string home_delivery = "0";
        string dinning = "0";
        string billVoid = "0";
        bool print_ok;
        public decimal cash_sum = 0;
        public decimal card_sum = 0;
        public decimal credit_sum = 0;
        public decimal sub_total_sum = 0;
        public decimal club_card_sum = 0;
        public decimal grand_total_sum = 0;
        decimal tax_sum = 0;
        decimal service_charge = 0;
        decimal credit_recive_amount = 0;
        decimal credit_recive_amountBYCard = 0;
        public decimal zomato_sum = 0;
        public decimal cashcard_sum = 0;
        public decimal cashcard_grandTotal_sum = 0;
        public decimal cashcard_cash_sum = 0;
        string complementrySalesSum = "0";
        string totalComplementry = "0";
        string totalshiftchange = "0";
        string totalcancel = "0";
        string countorder = "0";
        public DateTime today;
        string bill_count = "0";
        string firstBill = "0";
        string lastBill = "0";
        string K1 = "0";
        string K2 = "0";
        string K3 = "0";
        string B2 = "0";
        string B1 = "0";
        string R1 = "0";
        string fiscal_year;
       
        BLL_Fiscal blf = new BLL_Fiscal();
        BLL_Report bllr = new BLL_Report();
        BLL_Login_logout bllgin = new BLL_Login_logout();
        string ird_username;
        string ird_password;
        private void DayEndHotel_Load(object sender, EventArgs e)
        {
            DataTable dtfis = blf.get_all_data_from_fiscal("True");
            if (dtfis.Rows.Count > 0)
            {
                fiscal_year = dtfis.Rows[0]["fiscal_year"].ToString();
            }
            DataTable dt1 = bllgin.GetIrdInfo();
            if (dt1.Rows.Count > 0)
            {

                ird_password = Encryption.StringEncryption.Decrypt(dt1.Rows[0]["password"].ToString(), "sblw-3hn8-sqoy19");

                ird_username = dt1.Rows[0]["username"].ToString();
            }
            today = Convert.ToDateTime(DateTime.Today.ToShortDateString());
            panel2.Hide();
           
            txtuser_name.Text = Login.sendtext;
            // txt_opening_balance.Text = "0.00";
            // opening balalance 
            DataTable dt = bllh.get_oening_balance_detailshotel();
            if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "")
            {
                DataTable dtm = bllh.getopeningbalancehotel();
                if (dtm.Rows.Count > 0)
                {
                    txt_opening_balance.Text = dtm.Rows[0][0].ToString();
                }

                login_date = dt.Rows[0]["date"].ToString();
                set_by = dt.Rows[0]["set_by"].ToString();
            }
            //grandtotal of sales 
            DataTable dt_grand_sum = bllh.sum_grand_total("X", fiscal_year);
            if (dt_grand_sum.Rows.Count > 0 && dt_grand_sum.Rows[0][0].ToString() != "")
            {
                for (int i = 0; i < dt_grand_sum.Rows.Count; i++)
                {


                    grand_total_sum += Convert.ToDecimal(dt_grand_sum.Rows[i]["grand_total"].ToString());
                    sub_total_sum += Convert.ToDecimal(dt_grand_sum.Rows[i]["sub_total"].ToString());
                    discount += Convert.ToDecimal(dt_grand_sum.Rows[i]["discount"].ToString());
                    tax_sum += Convert.ToDecimal(dt_grand_sum.Rows[i]["tax_amount"]);
                    service_charge += Convert.ToDecimal(dt_grand_sum.Rows[i]["service_charge"]);
                }

                txt_grand_total.Text = grand_total_sum.ToString("#.##");
                txt_sub_total.Text = sub_total_sum.ToString("#.##");
                txt_discount.Text = Convert.ToString(discount);
                txt_service_charge.Text = service_charge.ToString("#.##");
                txt_tax.Text = tax_sum.ToString("#.##");

            }
            //total no of bill printed 
            DataTable dt_bill_count = bllh.Count_bill_no("X");
            if (dt_bill_count.Rows.Count > 0)
            {
                bill_count = dt_bill_count.Rows[0][0].ToString();
                firstBill = dt_bill_count.Rows[0][1].ToString();
                lastBill = dt_bill_count.Rows[0][2].ToString();
            }
            //total cash/card saless
            DataTable dt_cashcard_sale_sum = bllh.sum_Cash_card_sales("X", fiscal_year);
            if (dt_cashcard_sale_sum.Rows.Count > 0 && dt_cashcard_sale_sum.Rows[0][0].ToString() != "")
            {

                for (int i = 0; dt_cashcard_sale_sum.Rows.Count > i; i++)
                {
                    cashcard_sum += Convert.ToDecimal(dt_cashcard_sale_sum.Rows[i][1].ToString());
                    cashcard_grandTotal_sum += Convert.ToDecimal(dt_cashcard_sale_sum.Rows[i][2].ToString());
                }
                cashcard_cash_sum = cashcard_grandTotal_sum - cashcard_sum;
            }
            // total cash sales 
            DataTable dt_cash_sale_sum = bllh.sum_cash_sale("X", fiscal_year);
            if (dt_cash_sale_sum.Rows.Count > 0 && dt_cash_sale_sum.Rows[0][0].ToString() != "")
            {

                for (int i = 0; dt_cash_sale_sum.Rows.Count > i; i++)
                {
                    cash_sum += Convert.ToDecimal(dt_cash_sale_sum.Rows[i][1].ToString());
                }
                txt_total_cash_sales.Text = (cash_sum + cashcard_cash_sum).ToString("#.##");
            }
            //total card sales
            DataTable dt_card_sale_sum = bllh.sum_card_sale("X", fiscal_year);
            if (dt_card_sale_sum.Rows.Count > 0 && dt_card_sale_sum.Rows[0][0].ToString() != "")
            {

                for (int i = 0; dt_card_sale_sum.Rows.Count > i; i++)
                {
                    card_sum += Convert.ToDecimal(dt_card_sale_sum.Rows[i][1].ToString());
                }


            }

            //total credit amount recived by cash
            DataTable dt_sum_credit_amount_received = bllh.Sum_Credit_Amount_receive("X", "Cash");
            if (dt_sum_credit_amount_received.Rows.Count > 0 && dt_sum_credit_amount_received.Rows[0][0].ToString() != "")
            {
  credit_recive_amount = Convert.ToDecimal(dt_sum_credit_amount_received.Rows[0][0].ToString());
                
            }

            //total credit amount recived by card
            DataTable dt_sum_credit_amount_receivedByCard = bllh.Sum_Credit_Amount_receive("X", "Card");
            if (dt_sum_credit_amount_receivedByCard.Rows.Count > 0 && dt_sum_credit_amount_receivedByCard.Rows[0][0].ToString() != "")
            {

                credit_recive_amountBYCard = Convert.ToDecimal(dt_sum_credit_amount_receivedByCard.Rows[0][0].ToString());


            }
            //total complementry sales
            DataTable dt_sum_complementry_sales = bllh.getallcomplementrysalebystatus("X");
            if (dt_sum_complementry_sales.Rows.Count > 0 && dt_sum_complementry_sales.Rows[0][0].ToString() != "")
            {

                complementrySalesSum = (dt_sum_complementry_sales.Rows[0][0].ToString());
                totalComplementry = (dt_sum_complementry_sales.Rows[0][1].ToString());

            }
            //total Shift Change
            DataTable dt_count = bllh.GetCountShiftChange("X");
            if (dt_count.Rows.Count > 0 && dt_count.Rows[0][0].ToString() != "")
            {
                totalshiftchange = (dt_count.Rows[0][0].ToString());

            }
            //sum of total credit amount  recived by cash and card
            txt_credit_paid.Text = (credit_recive_amount + credit_recive_amountBYCard).ToString();
            //total credit sum 
            DataTable dt_sum_credit_amount = bllh.Sum_Credit_Amount("X");
            if (dt_sum_credit_amount.Rows.Count > 0)
            {
                for (int i = 0; i < dt_sum_credit_amount.Rows.Count; i++)
                {
                    credit_sum += Convert.ToDecimal(dt_sum_credit_amount.Rows[i][1].ToString());
                }
                txt_credit.Text = credit_sum.ToString("#.##");
            }
            //total cash drop 
            DataTable dt_care_of = bllh.sum_get_care_of();
            if (dt_care_of.Rows.Count > 0 && dt_care_of.Rows[0][0].ToString() != "")
            {
                care_of = dt_care_of.Rows[0][0].ToString();
                txttotal_care_of.Text = care_of.ToString();
            }

            if (txt_opening_balance.Text == "") txt_opening_balance.Text = "0.00";
            if (txt_total_card_sales.Text == "") txt_total_card_sales.Text = "0.00";
            if (txt_service_charge.Text == "" || txt_service_charge.Text == null)
                txt_service_charge.Text = "0.00";
            if (txt_tax.Text == "" || txt_tax.Text == null)
                txt_tax.Text = "0.00";
            if (txt_credit_paid.Text == "") txt_credit_paid.Text = "0.00";
            if (txttotal_care_of.Text == "") txttotal_care_of.Text = "0.00";
            if (txt_total_card_sales.Text == "") txt_total_card_sales.Text = "0.00";
            var sum_cash_counter = Convert.ToDecimal(txt_opening_balance.Text) + Convert.ToDecimal(txt_total_cash_sales.Text) + credit_recive_amount - Convert.ToDecimal(txttotal_care_of.Text);
            txt_total_cash_counter.Text = sum_cash_counter.ToString();
            txt_total_card_sales.Text = (card_sum + cashcard_sum).ToString();

            DataTable dt_tbl_sale_count = bllh.Count_total_Table("X");
            if (dt_tbl_sale_count.Rows.Count > 0 && dt_tbl_sale_count.Rows[0][0].ToString() != "")
            {
                table_count = dt_tbl_sale_count.Rows.Count.ToString();
            }
            DataTable dt_tbl_sale_Take_away = bllh.Count_total_Take_away();
            if (dt_tbl_sale_Take_away.Rows.Count > 0 && dt_tbl_sale_Take_away.Rows[0][0].ToString() != "")
            {
                take_away = dt_tbl_sale_Take_away.Rows.Count.ToString();
            }
            DataTable dt_tbl_sale_home_delivery = bllh.Count_total_Home_delivery();
            if (dt_tbl_sale_home_delivery.Rows.Count > 0 && dt_tbl_sale_home_delivery.Rows[0][0].ToString() != "")
            {
                home_delivery = dt_tbl_sale_home_delivery.Rows.Count.ToString();
            }
            DataTable dt_tbl_sale_dinning = bllh.Count_totalDinning();
            if (dt_tbl_sale_dinning.Rows.Count > 0 && dt_tbl_sale_dinning.Rows[0][0].ToString() != "")
            {
                dinning = dt_tbl_sale_dinning.Rows.Count.ToString();
            }
            DataTable dt2 = bllr.HotelCheckout(Convert.ToDateTime(today));
            if (dt2.Rows.Count > 0)
            {
                lbl_checkout.Text = dt2.Rows[0][0].ToString();
            }
            DataTable dtreport = bllr.Dailycheckin(Convert.ToDateTime(today));
            if (dt.Rows.Count > 0)
            {
                lbl_checkin.Text = dtreport.Rows[0][0].ToString();
            }
            DataTable dt_total = bllr.NumofRoom();
            DataTable dt_bookings = bllr.Bookings();
            lbl_bgroom.Text= Convert.ToInt32(dt_bookings.Rows[0][0].ToString()).ToString();
            lbl_freeroom.Text = (Convert.ToInt32(dt_total.Rows[0][0].ToString()) - Convert.ToInt32(dt_bookings.Rows[0][0].ToString())).ToString();
            DataTable dt_count_cancel = bllh.count_cancelitem(Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            if (dt_count_cancel.Rows.Count > 0 && dt_count_cancel.Rows[0][0].ToString() != "")
            {
                totalcancel = dt_count_cancel.Rows[0][0].ToString();
            }
            countorder = (Convert.ToDecimal(table_count) + Convert.ToDecimal(take_away) + Convert.ToDecimal(home_delivery) + Convert.ToDecimal(dinning)).ToString();
            DataTable dt_voidbill = bllh.Count_Voidbill();
            if (dt_voidbill.Rows.Count > 0 && dt_voidbill.Rows[0][0].ToString() != "")
            {
                billVoid = dt_tbl_sale_dinning.Rows.Count.ToString();
            }
            DataTable dt_kotTypeSum = bllh.SumKOTType();
            if (dt_kotTypeSum.Rows.Count > 0)
            {
                K1 = dt_kotTypeSum.Rows[0]["K1"].ToString();
                K2 = dt_kotTypeSum.Rows[0]["K2"].ToString();
                B1 = dt_kotTypeSum.Rows[0]["B1"].ToString();
                B2 = dt_kotTypeSum.Rows[0]["B2"].ToString();
                K3 = dt_kotTypeSum.Rows[0]["k3"].ToString();
                R1 = dt_kotTypeSum.Rows[0]["Room"].ToString();
            }
          //  DynamicCheck();
        }

        private void btn_dayend_Click(object sender, EventArgs e)
        {
            if (Login.sendtext != "")
            {
                DataTable dt = blu.getusername(Login.sendtext);
                if (dt.Rows.Count > 0)
                {
                    if (txt_cashsettlement.Text == "0.00")
                    {
                        MessageBox.Show("Cash settlement is required");
                    }
                    else if (dt.Rows[0]["user_type"].ToString() == "admin" || dt.Rows[0]["user_type"].ToString() == "Admin")
                    {
                        panel2.Show();

                    }
                    else
                    {
                        MessageBox.Show("You Have No Permission To Print A Report");
                    }
                }
            }
        }
        NonRefundableBalanceLessDayend nrb = new NonRefundableBalanceLessDayend();
        BLLPurchase bllp = new BLLPurchase();
        TotalCreditInDayPrinting tcid = new TotalCreditInDayPrinting();
        string sendMail = "False";
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (txtuser_name.Text != "" && txtpassword.Text != "")
            {
                DataTable dt = blu.getusername(txtuser_name.Text);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["user_type"].ToString() == "admin" || dt.Rows[0]["user_type"].ToString() == "Admin")
                    {
                        DataTable dtm = blu.getalluserlogin(txtuser_name.Text, txtpassword.Text);
                        if (dtm.Rows.Count > 0)
                        {
                            Bll_dayend den = new Bll_dayend();
                            string getdates = Convert.ToDateTime(DateTime.Now).ToString();
                            if (txt_discount.Text != "" && txt_service_charge.Text != "" && txt_tax.Text != "" || txt_grand_total.Text != "" && txt_credit.Text != "" && txt_credit_paid.Text != "" && txt_counting_cash.Text != "" && txt_excess_shortage.Text != "" && txt_cashsettlement.Text != "" && txt_closing_balance.Text != "")
                            {

                                int getivalue = den.insertintdailyend(Login.sendtext, txt_opening_balance.Text, txt_sub_total.Text, txt_total_cash_sales.Text, txt_total_card_sales.Text, "",txttotal_care_of.Text, txt_total_cash_counter.Text, Convert.ToDecimal(txt_discount.Text), Convert.ToDecimal(txt_service_charge.Text), Convert.ToDecimal(txt_tax.Text), Convert.ToDecimal(txt_grand_total.Text), Convert.ToDecimal(txt_credit.Text), Convert.ToDecimal(txt_credit_paid.Text), Convert.ToDecimal(txt_counting_cash.Text), Convert.ToDecimal(txt_excess_shortage.Text), Convert.ToDecimal(txt_cashsettlement.Text), Convert.ToDecimal(txt_closing_balance.Text), lbl_status.Text, Convert.ToDateTime(getdates), totalshiftchange, totalcancel, countorder, Convert.ToDecimal(complementrySalesSum));

                                if (getivalue > 0)
                                {
                                    nrb.balanceLessNonRefundable();
                                    int updateSales = bllh.update_sale_x_report("X");
                                    int updateComplementrySales = bllh.update_complementry_x_report("X");
                                    int updateCreditRecived = bllh.updateCreditPaystatus("X");
                                 
                                    int iop = blcas.delete_opening_balancehotel();
                                    int top = blcas.delete_credithotel();
                                    int insert = blcas.insertinto(Convert.ToDecimal(txt_closing_balance.Text), Convert.ToDateTime(getdates), set_by, "OBH");
                                    DataTable dt1 = bllh.GetTransactioncashdrop();
                                    if (dt1.Rows.Count > 0)
                                    {
                                        int category_id = Convert.ToInt32(dt1.Rows[0]["category_id"].ToString());
                                        int inserts = bllh.CreateTransactionPurchase(category_id, "Cash Settlement", today, "Dayend Saving Hotel", Convert.ToDecimal(txt_cashsettlement.Text), fiscal_year, "Cash");
                                    }
                                    int updateCreditPaid = bllh.updateCreditPaidstatus("X");
                                    int updateshiftchange = bllh.UpdateShiftChange("X");
                                    printing_closing_report();
                                    tcid.PrintCredit();

                                    if (print_ok == true)
                                    {
                                        printDocument1PDF();
                                        int ib = blcwd.delete_care_of("Hotel");
                                        if (sendMail == "True")
                                        {
                                            sendEMailThroughOUTLOOK();
                                        }

                                      //  backgroundWorker1.RunWorkerAsync(2000);
                                        this.Close();
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Incorrect User Name Password");

                        }

                    }
                    else
                    {
                        MessageBox.Show("You Have No Permission To Print A Report");
                    }

                }

            }
        }
        string PDfSaveFolderPatha;
        public void printDocument1PDF()
        {
            PrintDialog pd = new PrintDialog();
            PdfDocument pdoc = new PdfDocument();
            PdfPage ps = pdoc.AddPage();
            XGraphics gra = XGraphics.FromPdfPage(ps);
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
            //Graphics gras = e.Graphics;
            DateTime timedate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            DateTime strDate = Convert.ToDateTime(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString());
            gra.Graphics.DrawString(business_name, drawFontArial12Bold, drawBrush, new RectangleF(xs, ys, widths, heights), drawFormatCenter);
            ys += gra.Graphics.MeasureString(business_name, drawFontArial12Bold).Height;
            if (business_name.Length >= 30)
            {
                ybinc = 13;
            }
            gra.Graphics.DrawString(address, drawFontArial10Regular, drawBrush, new RectangleF(xs, ys + ybinc, widths, heights), drawFormatCenter);
            ys += gra.Graphics.MeasureString(address, drawFontArial10Regular).Height;
            if (address.Length >= 40)
            {
                yinc = 15;
            }
            ybinc = 55 + ybinc + yinc;
            gra.DrawRectangle(drawingPen, 10, ybinc - 20, 255, 20);

            gra.DrawString("Close Counter Report", new XFont("Arial", 12, XFontStyle.Bold), new SolidBrush(Color.Black), 40, ybinc); ybinc = ybinc + 20;

            gra.DrawString("Session Date", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(timedate.ToString(), new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 130, ybinc); ybinc = ybinc + 17;


            gra.DrawString("Login Date", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(login_date, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 130, ybinc); ybinc = ybinc + 17;


            gra.DrawString("Log Out", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(strDate.ToString(), new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 130, ybinc); ybinc = ybinc + 17;


            gra.DrawString("Report By", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(Login.sendtext, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 130, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Total Bill No", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(bill_count, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 130, ybinc); ybinc = ybinc + 17;

            gra.DrawString("First Bill No", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(firstBill, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 130, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Last Bill No", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(lastBill, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 130, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Total Bill Void", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(billVoid, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 130, ybinc); ybinc = ybinc + 17;

            gra.DrawRectangle(drawingPen, 10, ybinc - 5, 255, 255); ybinc = ybinc + 5;

            gra.DrawString("Sales Summary", new XFont("Arial", 10, XFontStyle.Bold), new SolidBrush(Color.Black), 60, ybinc); ybinc = ybinc + 18;
            gra.DrawString("Sub Total", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(txt_sub_total.Text, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Total Discount", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(discount.ToString(), new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Total Tax", new XFont("Arial", 9, XFontStyle.Bold), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(txt_tax.Text, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Total Service Charge", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(service_charge.ToString(), new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Grand Total", new XFont("Arial", 13, XFontStyle.Bold), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(txt_grand_total.Text, new XFont("Arial", 9, XFontStyle.Bold), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 20;

            gra.DrawString("Sales By Cash", new XFont("Arial", 10, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(txt_total_cash_sales.Text, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Sales By Card", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(txt_total_card_sales.Text, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;
            
            gra.DrawString("Sales In Credit", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(credit_sum.ToString(), new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;

           

            gra.DrawString("Total Cash In Counter ", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(txt_total_cash_counter.Text, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Total Counting Cash ", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(txt_counting_cash.Text, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Cash Settlement", new XFont("Arial", 9, XFontStyle.Bold), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(txt_cashsettlement.Text, new XFont("Arial", 9, XFontStyle.Bold), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Excess/Shortage ", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(txt_excess_shortage.Text, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Closing Balance ", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(txt_closing_balance.Text, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;


            ybinc = ybinc + 20;
            gra.DrawRectangle(drawingPen, 10, ybinc - 10, 255, 110);
            gra.DrawString("Cash Summary", new XFont("Arial", 10, XFontStyle.Bold), new SolidBrush(Color.Black), 60, ybinc); ybinc = ybinc + 17;
            gra.DrawString("Opening Balance", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(txt_opening_balance.Text, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 130, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Cash", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(txt_total_cash_sales.Text, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 130, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Cash Drop", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(care_of, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 130, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Net Cash", new XFont("Arial", 10, XFontStyle.Bold), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(txt_total_cash_counter.Text, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Credit Received", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(txt_credit_paid.Text, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;
            gra.DrawString("By Cash", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 20, ybinc);
            gra.DrawString(credit_recive_amount.ToString(), new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;
            gra.DrawString("By Card ", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 20, ybinc);
            gra.DrawString(credit_recive_amount.ToString(), new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 27;


            gra.DrawRectangle(drawingPen, 10, ybinc - 5, 255, 170); ybinc = ybinc + 5;
            gra.DrawString("Order Summary", new XFont("Arial", 10, XFontStyle.Bold), new SolidBrush(Color.Black), 60, ybinc); ybinc = ybinc + 17;
            gra.DrawString("Table Sales", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(table_count, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 15;

            gra.DrawString("Take Away", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(take_away, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;
            gra.DrawString("Dinning", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(dinning, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Delivery", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(home_delivery, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Total Order", new XFont("Arial", 10, XFontStyle.Bold), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString((Convert.ToDecimal(table_count) + Convert.ToDecimal(take_away) + Convert.ToDecimal(home_delivery) + Convert.ToDecimal(dinning)).ToString(), new XFont("Arial", 10, XFontStyle.Bold), new SolidBrush(Color.Black), 130, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Total Complementry", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(totalComplementry, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 170, ybinc); ybinc = ybinc + 17;
            gra.DrawString("Total Complementry AMT", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(complementrySalesSum, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 170, ybinc); ybinc = ybinc + 17;

            gra.DrawString("No. Of Check-In", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(lbl_checkin.Text, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("No.Of Checkin-Out", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(lbl_checkout.Text, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Busy Rooms", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(lbl_bgroom.Text, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Free Room", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(lbl_freeroom.Text, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 30;
           

            gra.DrawRectangle(drawingPen, 10, ybinc, 255, 110); ybinc = ybinc + 5;
            gra.DrawString("KOT Total", new XFont("Arial", 10, XFontStyle.Bold), new SolidBrush(Color.Black), 60, ybinc); ybinc = ybinc + 17;
            gra.DrawString("K1", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(K1, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 15;
            gra.DrawString("K2", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(K2, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 15;
            gra.DrawString("K3", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(K3, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 15;
            gra.DrawString("B1", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(B1, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 15;
            gra.DrawString("B2", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(B2, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 15;
            gra.DrawString("Room Charge", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(R1, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 15;
            gra.DrawString("This KOT total is without service charge and Tax.", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 0, ybinc); ybinc = ybinc + 15;
            string Pdfolderpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\Day End\\";
            PDfSaveFolderPatha = Pdfolderpath + timedate.ToString("dd-MM-yyyy") + ".pdf";
            if (!Directory.Exists(Pdfolderpath))
            {
                Directory.CreateDirectory(Pdfolderpath);
            }

            pdoc.Save(PDfSaveFolderPatha);


        }
        string email = "";
        public void sendEMailThroughOUTLOOK()
        {
            try
            {
                // Create the Outlook application.
                Outlook.Application oApp = new Outlook.Application();
                // Create a new mail item.
                Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
                // Set HTMLBody. 
                //add the body of the email
                oMsg.HTMLBody = "Day End Report";
                //Add an attachment.
                String sDisplayName = "Report";
                int iPosition = (int)oMsg.Body.Length + 1;
                int iAttachType = (int)Outlook.OlAttachmentType.olByValue;
                //now attached the file
                Microsoft.Office.Interop.Outlook.Attachment oAttach = oMsg.Attachments.Add
                                            (PDfSaveFolderPatha, iAttachType, iPosition, sDisplayName);
                //Subject line
                oMsg.Subject = "Day End Report";
                // Add a recipient.
                Outlook.Recipients oRecips = (Outlook.Recipients)oMsg.Recipients;
                // Change the recipient in the next line if necessary.
                Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(email);
                oRecip.Resolve();
                oMsg.Display(true);
                // Send.

                // Clean up.
                oRecip = null;
                oRecips = null;
                oMsg = null;
                oApp = null;
            }//end of try block
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }//end of catch
        }//end of Email Method
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
            gra.DrawString("Hotel", new System.Drawing.Font("Arial", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 40, ybinc); ybinc = ybinc + 20;

            gra.DrawString("Close Counter Report", new System.Drawing.Font("Arial", 12, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 40, ybinc); ybinc = ybinc + 20;

            gra.DrawString("Session Date", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(timedate.ToString(), new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;


            gra.DrawString("Login Date", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(login_date, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;


            gra.DrawString("Log Out", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(strDate.ToString(), new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;


            gra.DrawString("Report By", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(Login.sendtext, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Total Bill No", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(bill_count, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;

            gra.DrawString("First Bill No", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(firstBill, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Last Bill No", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lastBill, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Total Bill Void", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(billVoid, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;

            gra.DrawRectangle(drawingPen, 10, ybinc, 255, 244); ybinc = ybinc + 5;

            gra.DrawString("Sales Summary", new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 60, ybinc); ybinc = ybinc + 18;
            gra.DrawString("Sub Total", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(txt_sub_total.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Total Discount", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(discount.ToString(), new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Total Service Charge", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(service_charge.ToString(), new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;


            gra.DrawString("Total Tax", new System.Drawing.Font("Arial", 9, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(txt_tax.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;


            gra.DrawString("Grand Total", new System.Drawing.Font("Arial", 13, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(txt_grand_total.Text, new System.Drawing.Font("Arial", 9, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 20;

            gra.DrawString("Sales By Cash", new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(txt_total_cash_sales.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Sales By Card", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(txt_total_card_sales.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;
            

            gra.DrawString("Sales In Credit", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(credit_sum.ToString(), new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Total Cash In Counter ", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(txt_total_cash_counter.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;


            gra.DrawString("Total Counting Cash ", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(txt_counting_cash.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Cash Settlement", new System.Drawing.Font("Arial", 9, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(txt_cashsettlement.Text, new System.Drawing.Font("Arial", 9, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Excess/Shortage ", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(txt_excess_shortage.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Closing Balance ", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(txt_closing_balance.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;


            ybinc = ybinc + 20;
            gra.DrawRectangle(drawingPen, 10, ybinc, 255, 140);
            gra.DrawString("Cash Summary", new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 60, ybinc); ybinc = ybinc + 17;
            gra.DrawString("Opening Balance", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(txt_opening_balance.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Cash", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(txt_total_cash_sales.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Cash Drop", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(care_of, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Net Cash", new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(txt_total_cash_counter.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Credit Received", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(txt_credit_paid.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;
            gra.DrawString("By Cash", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 20, ybinc);
            gra.DrawString(credit_recive_amount.ToString(), new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;
            gra.DrawString("By Card ", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 20, ybinc);
            gra.DrawString(credit_recive_amount.ToString(), new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 27;


            gra.DrawRectangle(drawingPen, 10, ybinc, 255, 170); ybinc = ybinc + 5;
            gra.DrawString("Order Summary", new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 60, ybinc); ybinc = ybinc + 17;
            gra.DrawString("Table Sales", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(table_count, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 15;

            gra.DrawString("Take Away", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(take_away, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;
            gra.DrawString("Dinning", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(dinning, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Delivery", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(home_delivery, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Total Order", new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString((Convert.ToDecimal(table_count) + Convert.ToDecimal(take_away) + Convert.ToDecimal(home_delivery) + Convert.ToDecimal(dinning)).ToString(), new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 170, ybinc); ybinc = ybinc + 17;
            gra.DrawString("Cancel Order", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(totalcancel, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 170, ybinc); ybinc = ybinc + 17;
            gra.DrawString("Total Complementry", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(totalComplementry, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 170, ybinc); ybinc = ybinc + 17;
            gra.DrawString("Total Complementry AMT", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(complementrySalesSum, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 170, ybinc); ybinc = ybinc + 17;
            gra.DrawString("Total ShiftChange", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(totalshiftchange, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 170, ybinc); ybinc = ybinc + 20;

            gra.DrawRectangle(drawingPen, 10, ybinc, 255, 90); ybinc = ybinc + 5;
            gra.DrawString("Hotel Summary", new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 60, ybinc); ybinc = ybinc + 17;
            gra.DrawString("No.Of Check-In", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lbl_checkin.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 170, ybinc); ybinc = ybinc + 17;
            gra.DrawString("No.Of Check-Out", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lbl_checkout.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 170, ybinc); ybinc = ybinc + 17;
            gra.DrawString("Busy Room", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lbl_bgroom.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 170, ybinc); ybinc = ybinc + 17;
            gra.DrawString("Free Room", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(lbl_freeroom.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 170, ybinc); ybinc = ybinc + 30;
            
            gra.DrawRectangle(drawingPen, 10, ybinc, 255, 110); ybinc = ybinc + 5;
            gra.DrawString("KOT Total", new System.Drawing.Font("Arial", 10, FontStyle.Bold), new SolidBrush(System.Drawing.Color.Black), 60, ybinc); ybinc = ybinc + 17;
            gra.DrawString("K1", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(K1, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 15;
            gra.DrawString("K2", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(K2, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 15;
            gra.DrawString("K3", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(K3, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 15;
            gra.DrawString("B1", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(B1, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 15;
            gra.DrawString("B2", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(B2, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 15;
            gra.DrawString("Room Charge", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(R1, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 25;
            gra.DrawString("This KOT total is without service charge and Tax.", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ybinc); ybinc = ybinc + 15;


        }
        CheckDynamic cd = new CheckDynamic();
        public void printing_closing_report()
        {
            string printername = cd.CheckDayEndPrint();
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            System.Drawing.Font font = new System.Drawing.Font("Arial", 12);
            PaperSize psize = new PaperSize("Custome", 314, 1500);
            pd.Document = pdoc;
            pdoc.PrinterSettings.PrinterName = printername;
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

        private void btn_print_preview_Click(object sender, EventArgs e)
        {
            printing_closing_report();
        }

        private void txt_counting_cash_TextChanged(object sender, EventArgs e)
        {
            if (txt_counting_cash.Text != "")
            {
                if (Convert.ToDecimal(txt_counting_cash.Text) == Convert.ToDecimal(txt_total_cash_counter.Text))
                {
                    txt_excess_shortage.Text = (Convert.ToDecimal(txt_total_cash_counter.Text) - Convert.ToDecimal(txt_counting_cash.Text)).ToString();
                    lbl_status.ForeColor = System.Drawing.Color.Black;
                    lbl_status.Visible = false;
                }
                if (Convert.ToDecimal(txt_counting_cash.Text) < Convert.ToDecimal(txt_total_cash_counter.Text))
                {
                    txt_excess_shortage.Text = (Convert.ToDecimal(txt_total_cash_counter.Text) - Convert.ToDecimal(txt_counting_cash.Text)).ToString();
                    txt_excess_shortage.ForeColor = System.Drawing.Color.Red;
                    lbl_status.ForeColor = System.Drawing.Color.Red;
                    lbl_status.Text = "Shortage";

                }
                else if (Convert.ToDecimal(txt_counting_cash.Text) > Convert.ToDecimal(txt_total_cash_counter.Text))
                {
                    txt_excess_shortage.Text = (Convert.ToDecimal(txt_counting_cash.Text) - Convert.ToDecimal(txt_total_cash_counter.Text)).ToString();
                    lbl_status.ForeColor = System.Drawing.Color.Black;
                    txt_excess_shortage.ForeColor = System.Drawing.Color.Black;
                    lbl_status.Text = "Excess";
                }
            }
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
        ItemPrint itm = new ItemPrint();
        DataTable dti = new DataTable();
        private void btn_itemsales_Click(object sender, EventArgs e)
        {
            dti = bllh.itemGroup();
            if (dti.Rows.Count > 0)
            {
                itm.cashier = Login.sendtext;
                itm.date_from = DateTime.Now.ToShortDateString();

                for (int i = 0; i < dti.Rows.Count; i++)
                {
                    itm.datagridview_name.Add(dti.Rows[i]["item_name"].ToString());
                    itm.datagridview_qty.Add(dti.Rows[i]["quantity"].ToString());
                    itm.datagridview_cost.Add(dti.Rows[i]["cost"].ToString());

                }
                itm.printcalcel();
                //  exportItemQuantity();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            dti = bllh.cancelitemGroup(Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            if (dti.Rows.Count > 0)
            {
                OrderCancelDetails ocd = new OrderCancelDetails();
                ocd.ShowDialog();
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bth_panel_close_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void lbl_freeroom_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
 