using BLLS;
using BLLS.bakery;
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
    public partial class DayEndReport : Form
    {

        public DayEndReport()
        {
            InitializeComponent();

        }
        Bll_cashcounter blcas = new Bll_cashcounter();
        BLLRestSell blres = new BLLRestSell();
        BLLUser blu = new BLLUser();
        Bll_CashwithDrawl blcwd = new Bll_CashwithDrawl();
        BLL_Billing_Tax bltx = new BLL_Billing_Tax();
        BLLOrder blod = new BLLOrder();
        blllCustomerDetailednyo blc = new blllCustomerDetailednyo();
        BllBakeryOrder blbo = new BllBakeryOrder();
        string login_date;
        string set_by;
        decimal discount = 0;
        string care_of = "0.00";
        string table_count="0";
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
        string fiscal_year;
        BLLDynamic bldync = new BLLDynamic();
        BLL_Fiscal blf = new BLL_Fiscal();
        BLL_Login_logout bllgin = new BLL_Login_logout();
        string ird_username;
        string ird_password;
        decimal bakeryAdvance_amountCash = 0;
        decimal bakeryAdvance_amountCard = 0;
        bool cashdrop;
        private void DayEndReport_Load(object sender, EventArgs e)
        {
            cashdrop = cd.PurchaseCashDropAccess();
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
            btn_day_end.Text = Login.sendtext;
            txtuser_name.Text = Login.sendtext;
            // txt_opening_balance.Text = "0.00";
            // opening balalance 
            DataTable dt = blcas.get_oening_balance_details();
            if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "")
            {
                DataTable dtm = blcas.getopeningbalance();
                if (dtm.Rows.Count > 0)
                {
                    txt_opening_balance.Text = dtm.Rows[0][0].ToString();
                }

                login_date = dt.Rows[0]["date"].ToString();
                set_by = dt.Rows[0]["set_by"].ToString();
            }
            //grandtotal of sales 
            DataTable dt_grand_sum = blres.sum_grand_total("X", fiscal_year);
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
            DataTable dt_bill_count = blres.Count_bill_no("X");
            if (dt_bill_count.Rows.Count > 0)
            {
                bill_count = dt_bill_count.Rows[0][0].ToString();
                firstBill = dt_bill_count.Rows[0][1].ToString();
                lastBill = dt_bill_count.Rows[0][2].ToString();
            }
            //total cash/card saless
            DataTable dt_cashcard_sale_sum = blres.sum_Cash_card_sales("X", fiscal_year);
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
            DataTable dt_cash_sale_sum = blres.sum_cash_sale("X", fiscal_year);
            if (dt_cash_sale_sum.Rows.Count > 0 && dt_cash_sale_sum.Rows[0][0].ToString() != "")
            {

                for (int i = 0; dt_cash_sale_sum.Rows.Count > i; i++)
                {
                    cash_sum += Convert.ToDecimal(dt_cash_sale_sum.Rows[i][1].ToString());
                }
                txt_total_cash_sales.Text = (cash_sum + cashcard_cash_sum).ToString("#.##");
            }
           
            //total card sales
            DataTable dt_card_sale_sum = blres.sum_card_sale("X", fiscal_year);
            if (dt_card_sale_sum.Rows.Count > 0 && dt_card_sale_sum.Rows[0][0].ToString() != "")
            {

                for (int i = 0; dt_card_sale_sum.Rows.Count > i; i++)
                {
                    card_sum += Convert.ToDecimal(dt_card_sale_sum.Rows[i][1].ToString());
                }
              

            }
            //sum Bakery Advance Amount cash
          
            DataTable dtc = blbo.SumAdvanceAmount("Cash");
            if (dtc.Rows[0]["advance_amount"] != DBNull.Value)
            {
                bakeryAdvance_amountCash = Convert.ToDecimal(dtc.Rows[0]["advance_amount"]) ;

            }
           
            DataTable dtca = blbo.SumAdvanceAmount("Card");
            if (dtca.Rows[0]["advance_amount"]!=DBNull.Value)
            {
                bakeryAdvance_amountCard = Convert.ToDecimal(dtca.Rows[0]["advance_amount"]);

            }
            //total sales from club card
            DataTable dt_club_card_sales = blres.Sum_Club_Card_Sales("X");
            if (dt_club_card_sales.Rows.Count > 0)
            {
                for (int i = 0; i < dt_club_card_sales.Rows.Count; i++)
                {
                    club_card_sum += Convert.ToDecimal(dt_club_card_sales.Rows[i][1].ToString());
                }
                txt_club_card.Text = club_card_sum.ToString("#.##");
            }
            //total credit amount recived by cash
            DataTable dt_sum_credit_amount_received = blres.Sum_Credit_Amount_receive("X", "Cash");
            if (dt_sum_credit_amount_received.Rows.Count > 0 && dt_sum_credit_amount_received.Rows[0][0].ToString() != "")
            {

                credit_recive_amount = Convert.ToDecimal(dt_sum_credit_amount_received.Rows[0][0].ToString());
            }

            //total credit amount recived by card
            DataTable dt_sum_credit_amount_receivedByCard = blres.Sum_Credit_Amount_receive("X", "Card");
            if (dt_sum_credit_amount_receivedByCard.Rows.Count > 0 && dt_sum_credit_amount_receivedByCard.Rows[0][0].ToString() != "")
            {

                credit_recive_amountBYCard = Convert.ToDecimal(dt_sum_credit_amount_receivedByCard.Rows[0][0].ToString());


            }
            //total complementry sales
            DataTable dt_sum_complementry_sales = blres.getallcomplementrysalebystatus("X");
            if (dt_sum_complementry_sales.Rows.Count > 0 && dt_sum_complementry_sales.Rows[0][0].ToString() != "")
            {

                complementrySalesSum = (dt_sum_complementry_sales.Rows[0][0].ToString());
                totalComplementry = (dt_sum_complementry_sales.Rows[0][1].ToString());

            }
            //total Shift Change
            DataTable dt_count = blres.GetCountShiftChange("X");
            if (dt_count.Rows.Count > 0 && dt_count.Rows[0][0].ToString() != "")
            {
                totalshiftchange = (dt_count.Rows[0][0].ToString());

            }
            //sum of total credit amount  recived by cash and card
            txt_credit_paid.Text = (credit_recive_amount + credit_recive_amountBYCard).ToString();
            //total credit sum 
            DataTable dt_sum_credit_amount = blres.Sum_Credit_Amount("X", fiscal_year);
            if (dt_sum_credit_amount.Rows.Count > 0)
            {
                for (int i = 0; i < dt_sum_credit_amount.Rows.Count; i++)
                {
                    credit_sum += Convert.ToDecimal(dt_sum_credit_amount.Rows[i][1].ToString());
                }
                txt_credit.Text = credit_sum.ToString("#.##");
            }
            //total cash drop 
            if (cashdrop == true)
            {
                DataTable dt_care_of = blcwd.sum_get_care_of();
                if (dt_care_of.Rows.Count > 0 && dt_care_of.Rows[0][0].ToString() != "")
                {
                    care_of = dt_care_of.Rows[0][0].ToString();
                    txttotal_care_of.Text = care_of.ToString();
                }
            }
            else
            {
                DataTable dt_care_of = blcwd.sum_get_care_of_restaurant("Restaurant");
                if (dt_care_of.Rows.Count > 0 && dt_care_of.Rows[0][0].ToString() != "")
                {
                    care_of = dt_care_of.Rows[0][0].ToString();
                    txttotal_care_of.Text = care_of.ToString();
                }
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
            var sum_cash_counter = Convert.ToDecimal(txt_opening_balance.Text) + bakeryAdvance_amountCash + Convert.ToDecimal(txt_total_cash_sales.Text) + credit_recive_amount - Convert.ToDecimal(txttotal_care_of.Text);
            txt_total_cash_counter.Text = sum_cash_counter.ToString();
            txt_total_card_sales.Text = (card_sum + cashcard_sum + bakeryAdvance_amountCard).ToString();

            DataTable dt_tbl_sale_count = blres.Count_total_Table("X");
            if (dt_tbl_sale_count.Rows.Count > 0 && dt_tbl_sale_count.Rows[0][0].ToString() != "")
            {
                table_count = dt_tbl_sale_count.Rows.Count.ToString();
            }
            DataTable dt_tbl_sale_Take_away = blres.Count_total_Take_away();
            if (dt_tbl_sale_Take_away.Rows.Count > 0 && dt_tbl_sale_Take_away.Rows[0][0].ToString() != "")
            {
                take_away = dt_tbl_sale_Take_away.Rows.Count.ToString();
            }
            DataTable dt_tbl_sale_home_delivery = blres.Count_total_Home_delivery();
            if (dt_tbl_sale_home_delivery.Rows.Count > 0 && dt_tbl_sale_home_delivery.Rows[0][0].ToString() != "")
            {
                home_delivery = dt_tbl_sale_home_delivery.Rows.Count.ToString();
            }
            DataTable dt_tbl_sale_dinning = blres.Count_totalDinning();
            if (dt_tbl_sale_dinning.Rows.Count > 0 && dt_tbl_sale_dinning.Rows[0][0].ToString() != "")
            {
                dinning = dt_tbl_sale_dinning.Rows.Count.ToString();
            }
            DataTable dt_count_cancel = blres.count_cancelitem(Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            if (dt_count_cancel.Rows.Count > 0 && dt_count_cancel.Rows[0][0].ToString() != "")
            {
                totalcancel = dt_count_cancel.Rows[0][0].ToString();
            }
            countorder = (Convert.ToDecimal(table_count) + Convert.ToDecimal(take_away) + Convert.ToDecimal(home_delivery) + Convert.ToDecimal(dinning)).ToString();
            DataTable dt_voidbill = blres.Count_Voidbill();
            if (dt_voidbill.Rows.Count > 0 && dt_voidbill.Rows[0][0].ToString() != "")
            {
                billVoid = dt_tbl_sale_dinning.Rows.Count.ToString();
            }
            DataTable dt_kotTypeSum = blres.SumKOTType(fiscal_year);
            if (dt_kotTypeSum.Rows.Count > 0)
            {
                K1 = dt_kotTypeSum.Rows[0]["K1"].ToString();
                K2 = dt_kotTypeSum.Rows[0]["K2"].ToString();
                B1 = dt_kotTypeSum.Rows[0]["B1"].ToString();
                B2 = dt_kotTypeSum.Rows[0]["B2"].ToString();
                K3 = dt_kotTypeSum.Rows[0]["k3"].ToString();
            }
            DynamicCheck();
        }
        string sendMail = "False";
        string email = "";
        public void DynamicCheck()
        {
            DataTable dt = bldync.GetDynamic("DEM");
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["Status"].ToString() == "True")
                {
                    sendMail = "True";
                }
            }
            DataTable dtm = bldync.GetDynamic("DEMT");
            if (dtm.Rows.Count > 0)
            {
                if (dtm.Rows[0]["Status"].ToString() == "True")
                {
                    email = dtm.Rows[0]["description"].ToString();
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
            gra.DrawString(btn_day_end.Text, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 130, ybinc); ybinc = ybinc + 17;

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
           


            gra.DrawString("Sales By Club Card", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(txt_club_card.Text, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Sales In Credit", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
            gra.DrawString(credit_sum.ToString(), new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;
            if (bakeryAdvance_amountCash > 0)
            {
                gra.DrawString("Advance By Cash", new XFont("Arial", 10, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
                gra.DrawString(txt_total_cash_sales.Text, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;
            }
            if (bakeryAdvance_amountCard > 0)
            {
                gra.DrawString("Advance By Card", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
                gra.DrawString(txt_total_card_sales.Text, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;
            }
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
            gra.DrawRectangle(drawingPen, 10, ybinc - 10, 255, 140);
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
            gra.DrawString(credit_recive_amountBYCard.ToString(), new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 27;


            gra.DrawRectangle(drawingPen, 10, ybinc - 5, 255, 135); ybinc = ybinc + 5;
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
            gra.DrawString(complementrySalesSum, new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 170, ybinc); ybinc = ybinc + 50;

            gra.DrawRectangle(drawingPen, 10, ybinc, 255, 90); ybinc = ybinc + 5;
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
            gra.DrawString("This KOT total is without service charge and Tax.", new XFont("Arial", 9, XFontStyle.Regular), new SolidBrush(Color.Black), 0, ybinc); ybinc = ybinc + 15;
            string Pdfolderpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\Day End\\";
            PDfSaveFolderPatha = Pdfolderpath + timedate.ToString("dd-MM-yyyy") + ".pdf";
            if (!Directory.Exists(Pdfolderpath))
            {
                Directory.CreateDirectory(Pdfolderpath);
            }

            pdoc.Save(PDfSaveFolderPatha);


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
            gra.DrawString(login_date, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;


            gra.DrawString("Log Out", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(strDate.ToString(), new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;


            gra.DrawString("Report By", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(btn_day_end.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 130, ybinc); ybinc = ybinc + 17;

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

            gra.DrawString("Sales By Club Card", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(txt_club_card.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;

            gra.DrawString("Sales In Credit", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 10, ybinc);
            gra.DrawString(credit_sum.ToString(), new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 150, ybinc); ybinc = ybinc + 17;
            if (bakeryAdvance_amountCash > 0)
            {
                gra.DrawString("Advance By Cash", new System.Drawing.Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
                gra.DrawString(txt_total_cash_sales.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;
            }
            if (bakeryAdvance_amountCard > 0)
            {
                gra.DrawString("Advance By Card", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(Color.Black), 10, ybinc);
                gra.DrawString(txt_total_card_sales.Text, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 17;
            }

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
            gra.DrawString(totalshiftchange, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 170, ybinc); ybinc = ybinc + 50;

            gra.DrawRectangle(drawingPen, 10, ybinc,255, 100); ybinc = ybinc + 5;
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
            gra.DrawString(B2, new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(Color.Black), 150, ybinc); ybinc = ybinc + 25;
            gra.DrawString("This KOT total is without service charge and Tax.", new System.Drawing.Font("Arial", 9, FontStyle.Regular), new SolidBrush(System.Drawing.Color.Black), 0, ybinc); ybinc = ybinc + 15;


        }
        private void btn_set_Click_1(object sender, EventArgs e)
        { 
         if (btn_day_end.Text != "")
            {
                DataTable dt = blu.getusername(btn_day_end.Text);
                if (dt.Rows.Count > 0)
                {
                    DataTable dtm = blu.get_user_and_type_inner(Convert.ToInt32(dt.Rows[0]["user_id"].ToString()));
                    if (dtm.Rows.Count > 0)
                    {
                        if (dtm.Rows[0]["dayend"].ToString() == "True")
                        {
                            if (txt_cashsettlement.Text == "0.00")
                            {
                                MessageBox.Show("Cash settlement is required");
                            }
                            else if (dt.Rows[0]["user_type"].ToString() == "admin" || dt.Rows[0]["user_type"].ToString() == "Admin")
                            {
                                panel2.Show();

                            }
                        }
                        else
                        {
                            MessageBox.Show("You Have No Permission To Print A Report");
                        }
                    }
                }
            }
        }

        private void btn_exit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        NonRefundableBalanceLessDayend nrb = new NonRefundableBalanceLessDayend();
        TotalCreditInDayPrinting tcid = new TotalCreditInDayPrinting();
        BLL_Billing_Tax blbt = new BLL_Billing_Tax();
        IRT.IRTAPI apir = new IRT.IRTAPI();
        BLL_Fiscal blfsc = new BLL_Fiscal();
        BLLDynamic bldd = new BLLDynamic();
        BLLPurchase bllp = new BLLPurchase();
        private void button2_Click(object sender, EventArgs e)
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

                                int getivalue = den.insertintdailyend(btn_day_end.Text, txt_opening_balance.Text, txt_sub_total.Text, txt_total_cash_sales.Text, txt_total_card_sales.Text, txt_club_card.Text, txttotal_care_of.Text, txt_total_cash_counter.Text, Convert.ToDecimal(txt_discount.Text), Convert.ToDecimal(txt_service_charge.Text), Convert.ToDecimal(txt_tax.Text), Convert.ToDecimal(txt_grand_total.Text), Convert.ToDecimal(txt_credit.Text), Convert.ToDecimal(txt_credit_paid.Text), Convert.ToDecimal(txt_counting_cash.Text), Convert.ToDecimal(txt_excess_shortage.Text), Convert.ToDecimal(txt_cashsettlement.Text), Convert.ToDecimal(txt_closing_balance.Text), lbl_status.Text, Convert.ToDateTime(getdates), totalshiftchange, totalcancel, countorder, Convert.ToDecimal(complementrySalesSum));

                                if (getivalue > 0)
                                {
                                    nrb.balanceLessNonRefundable();
                                    int updateSales = blres.update_sale_x_report("X");
                                    int updateComplementrySales = blres.update_complementry_x_report("X");
                                    int updateCreditRecived = blres.updateCreditPaystatus("X");
                                    int cashwithdrabulk = blcwd.bulk_data_insert();
                                    int inactive = blc.updateNonRefundable();
                                    int updateadd_balance_log = blres.update_addbalance_Log_x_report("X");
                                    int upadtecashbackLog = blres.update_cashBackLog_report("X");
                                    int iop = blcas.delete_opening_balancerestaurant();
                                    int top = blcas.delete_creditrestaurant();
                                    int insert = blcas.insertinto(Convert.ToDecimal(txt_closing_balance.Text), Convert.ToDateTime(getdates), set_by, "OB");
                                    DataTable dt1 = bllp.GetTransactioncashdrop();
                                    if (dt1.Rows.Count > 0)
                                    {
                                        int category_id = Convert.ToInt32(dt1.Rows[0]["category_id"].ToString());
                                        int inserts = bllp.CreateTransactionPurchase(category_id, "Cash Settlement", today, "Dayend Saving", Convert.ToDecimal(txt_cashsettlement.Text), fiscal_year, "Cash");
                                    }
                                    int updateCreditPaid = blres.updateCreditPaidstatus("X");
                                    int updateshiftchange = blres.UpdateShiftChange("X");
                                    printing_closing_report();
                                    tcid.PrintCredit();

                                    if (print_ok == true)
                                    {
                                        printDocument1PDF();
                                        int ib = blcwd.delete_care_of("Restaurant");
                                        if (sendMail == "True")
                                        {
                                            sendEMailThroughOUTLOOK();
                                        }
                                       
                                        backgroundWorker1.RunWorkerAsync(2000);
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
        BLLdenomination bld = new BLLdenomination();
        public void denominationInsert()
        {
            var date = DateTime.Now.ToShortDateString();
            DataTable dt = bld.GetId();
            if (dt.Rows.Count > 0)
            {
                int id = Convert.ToInt32(dt.Rows[0][0].ToString());
                // if (txt_one.Text != "" && txt_two.Text != "" && txt_five.Text != "" && txt_ten.Text != "" && txt_twenty.Text != "" && txt_fifty.Text != "" && txt_hundred.Text != "" && txt_fivehundred.Text != "" && txt_thousand.Text != "" && txt_ic.Text != "") ;
                if (DenomonationStatic.one != "" && DenomonationStatic.two != "" && DenomonationStatic.five != "" && DenomonationStatic.ten != "" && DenomonationStatic.twenty != "" && DenomonationStatic.fifty != "" && DenomonationStatic.onehundred != "" && DenomonationStatic.fivehundred != "" && DenomonationStatic.thousand != "" && DenomonationStatic.ic != "")
                {
                    //  int insert = bld.InsertDenomination(id, txt_ic.Text, txt_thousand.Text, txt_fivehundred.Text, txt_hundred.Text, txt_fifty.Text, txt_twenty.Text, txt_ten.Text, txt_five.Text, txt_two.Text, txt_one.Text, total, Convert.ToDateTime(date));
                    int insert = bld.InsertDenomination(id, DenomonationStatic.ic, DenomonationStatic.thousand, DenomonationStatic.fivehundred, DenomonationStatic.onehundred, DenomonationStatic.fifty, DenomonationStatic.twenty, DenomonationStatic.ten, DenomonationStatic.five, DenomonationStatic.two, DenomonationStatic.one, txt_counting_cash.Text, Convert.ToDateTime(date));

                    if (insert > 0)
                    {
                        MessageBox.Show("Inserted successfully");
                    }
                }
            }
        }
      
        private void bth_panel_close_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void buttonX2_Click(object sender, EventArgs e)
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

        private void txt_cashsettlement_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_excess_shortage_TextChanged(object sender, EventArgs e)
        {

        }
        ItemPrint itm = new ItemPrint();
        DataTable dti = new DataTable();
        string Business_Name;
        string pan_no;
        private void buttonX3_Click(object sender, EventArgs e)
        {
            dti = blod.itemGroup();
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
        public void exportItemQuantity()
        {
            //ExporyToExcel(btn_export_toexcel, "ExportedUserDetail");

            DataTable dt_m = blu.checkbusiness();
            if (dt_m.Rows.Count > 0)
            {
                Business_Name = dt_m.Rows[0]["business_name"].ToString();
                pan_no = dt_m.Rows[0]["pan_no"].ToString();
            }
            ////Adding the Columns
            //foreach (DataGridViewColumn column in dataGridView1.Columns)
            //{
            //    if (column.Index <= 14)
            //    {
            //        dt.Columns.Add(column.HeaderText);
            //    }
            //}

            ////Adding the Rows
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    dt.Rows.Add();
            //    foreach (DataGridViewCell cell in row.Cells)
            //    {
            //        if (cell.ColumnIndex <= 14)
            //        {
            //            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
            //        }
            //    }
            //}

            //Exporting to Excel
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\ItemSales Excel\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }


            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dti, "ItemSales");
                wb.SaveAs(folderPath + DateTime.Now.ToString("mm-dd") + "ItemSalesReport.xlsx");

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_sub_total_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_print_preview_Click(object sender, EventArgs e)
        {
            printing_closing_report();
        }

        private void btn_club_card_Click(object sender, EventArgs e)
        {
            Dailycardreport dcr = new Dailycardreport();
            dcr.ShowDialog();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            dti = blod.cancelitemGroup(Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            if (dti.Rows.Count > 0)
            {
                OrderCancelDetails ocd = new OrderCancelDetails();
                ocd.ShowDialog();
            }
        }
        private void isOutlook()
        {
            Microsoft.Win32.RegistryKey key =
          Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\microsoft\\windows\\currentversion\\app paths\\OUTLOOK.EXE");
            string path = (string)key.GetValue("Path");
            if (path != null)
                System.Diagnostics.Process.Start("OUTLOOK.EXE");
            else
                MessageBox.Show("There is no Outlook in this computer!", "SystemError", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
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
            Outlook.Attachment oAttach = oMsg.Attachments.Add
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

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            IRD();
        }
        public void IRD()
        {
            DataTable dtird = blbt.checkDataIRDCBMS();
            if (dtird.Rows.Count > 0)
            {
                for (int i = 0; i < dtird.Rows.Count; i++)
                {

                    int IRDOnline = apir.posBilling(dtird.Rows[i]["buyer_pan"].ToString(), dtird.Rows[i]["buyer_name"].ToString(), dtird.Rows[i]["invoice_number"].ToString(), dtird.Rows[i]["invoice_date"].ToString(), Convert.ToDouble(dtird.Rows[i]["total_sales"]), Convert.ToDouble(dtird.Rows[i]["taxable_sales_vat"]), Convert.ToDouble(dtird.Rows[i]["vat"]), false, fiscal_year, ird_username, ird_password);
                    if (IRDOnline > 0)
                    {
                        int syncWithIRD = blfsc.updateSyncIRD(Convert.ToInt32(dtird.Rows[i]["invoice_number"]));
                        int id = Convert.ToInt32(dtird.Rows[i]["ird_id"].ToString());
                        int delete = blbt.deleteIrdData(id);
                    }
                }
                if (!backgroundWorker1.IsBusy)
                    backgroundWorker1.CancelAsync();
            }
        }
    }
    }




