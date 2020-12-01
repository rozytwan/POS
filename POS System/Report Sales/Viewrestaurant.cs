using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BLLS;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using ClosedXML.Excel;
using POS_System.Printing_Billing;

namespace POS_System
{
    public partial class Viewrestaurant : UserControl
    {
        public Viewrestaurant()
        {
            InitializeComponent();
        }
        BLLOrder blod = new BLLOrder();
        BLLCategory blcat = new BLLCategory();
        BLLProduct blpro = new BLLProduct();
        BLLUser blu = new BLLUser();
        BLLRestSell blres = new BLLRestSell();
        BLLPrinterSetting blpst = new BLLPrinterSetting();
        BLL_Billing_Tax blbt = new BLL_Billing_Tax();
        // Page for pagination
        int mintTotalRecords = 0;
         int mintPageSize = 0;
         int mintPageCount = 0;
         int mintCurrentPage = 1;
        int tbPageSize;

        public string user_name;
        public void category()
        {
            DataTable dt = blcat.getallItemcategory();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["category_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = dt;
                txt_searchText.DisplayMember = "category_name";
                txt_searchText.ValueMember = "category_id";
            }
        }
        public void Billno()
        {
            DataTable dt = blod.DifferentBillno();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["bill_no"] = "00000";
                dt.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = dt;
                txt_searchText.DisplayMember = "bill_no";

            }
        }

        public void GroupingCategory()
        {
            DataTable dt = blcg.getallItemcategoryGrouping();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["group_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = dt;
                txt_searchText.DisplayMember = "group_name";
               // txt_searchText.ValueMember = "id";

            }
        }

        public void products()
        {
            DataTable dt = blpro.getallItems();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["item_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = dt;
                txt_searchText.DisplayMember = "item_name";

            }
        }
     
        //decimal tax_sum;
        //decimal service_charge;
        //decimal grand_total_sum;
        //decimal sub_total;
        string bill_no;
        string brfiscal_year;
        decimal Abbreviatedtax;
        bool AbbreviatedtaxEnable;
        CheckDynamic cd = new CheckDynamic();

        private void Viewrestaurant_Load(object sender, EventArgs e)
        {
            Abbreviatedtax = cd.CheckabbreviatedTaxAmount();
            AbbreviatedtaxEnable = cd.CheckabbreviatedTax();
            dtp_from.Value = DateTime.Now;
            dtp_to.Value = DateTime.Now;
           // this.Width = this.Parent.Width;
            user_name = Login.sendtext;
            backPanel.Hide();
            searchPanel.Show();
            cbo_searchTYpe.SelectedIndex = 0;
            // dtdsearchbydate.Focus();
            //time
            cbo_from_hours.Visible = false;
            cbo_minuts.Visible = false;
            cbo_minuts_from.Visible = false;
            cbo_to_hours.Visible = false;
            cbo_from_hours.SelectedIndex = 0;
            cbo_minuts.SelectedIndex = 0;
            cbo_minuts_from.SelectedIndex = 0;
            cbo_to_hours.SelectedIndex = 22;
         

        }
      
        public void grandtotalCalculation()
        {
            double qty = 0;
            double grand_total = 0;
            double sub_total = 0;
            double service_charge = 0;
            double tax = 0;


            if (dtSum.Rows.Count > 0)
            {
                for (int i = 0; i < dtSum.Rows.Count; i++)
                {
                    service_charge += Convert.ToDouble(dtSum.Rows[i]["service_charge"].ToString());
                    tax += Convert.ToDouble(dtSum.Rows[i]["tax_amount"].ToString());
                    grand_total += Convert.ToDouble(dtSum.Rows[i]["grand_total"].ToString());
                    qty += Convert.ToDouble(dtSum.Rows[i]["quantity"].ToString());
                    sub_total += Convert.ToDouble(dtSum.Rows[i]["total"].ToString());
                }
            }
            lblsubtotal.Text = sub_total.ToString("#.##");
            lbl_grand_total.Text = grand_total.ToString("#.##");
            lbl_service_charge.Text = service_charge.ToString("#.##");
            lbl_tax.Text = tax.ToString("#.##");
            lbltaotal_quantity.Text = qty.ToString();


        }


        private void btn_excel_Click_1(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            allmenu alls = new allmenu();
            ctls.Controls.Clear();
            ctls.Controls.Add(alls);

        }
        string Business_Name;
        string pan_no;
        private void btn_export_to_pdf_Click(object sender, EventArgs e)
        {
            DataTable dt = blu.checkbusiness();
            if (dt.Rows.Count > 0)
            {
                Business_Name = dt.Rows[0]["business_name"].ToString();
                pan_no = dt.Rows[0]["pan_no"].ToString();
            }
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount-8);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            PdfPCell cell = new PdfPCell();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                if (column.Index <= 14)
                {
                    cell = new PdfPCell(new Phrase(column.HeaderText));
                    pdfTable.AddCell(cell);
                }    
            }


            string data;
            //Adding DataRow
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                foreach (DataGridViewCell cells in row.Cells)
                {
                    if (cells.ColumnIndex <= 14)
                    {
                        if (cells.Value == null)
                        {
                            data = "0.00";
                        }
                        else
                        {
                            data = cells.Value.ToString();
                        }
                        pdfTable.AddCell(data);
                    }
                }
            }

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\RestaurantSalesReport\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string Datename = DateTime.Now.ToString("dd-mm-yyyy hh");
            using (FileStream stream = new FileStream(folderPath + "RestaurantSalesReport " + Datename + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                pdfDoc.Header = new HeaderFooter(new Phrase("Header Text"), false);
                pdfDoc.Open();
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph pheading = new Paragraph("Restaurant Sales Report");
                Paragraph pheading_business_name = new Paragraph(Business_Name);
                Paragraph pheading_pan_no = new Paragraph("Pan No :"+pan_no);
                Paragraph pheadingDate = new Paragraph("From:     "+ dtp_from.Text+"                                        "+"To:      "+dtp_to.Text);
                pheading.Alignment = Element.TITLE;
                pheading_business_name.Alignment = Element.TITLE;
                pheading_pan_no.Alignment = Element.TITLE;        
                pheading.Alignment = Element.TITLE;
                Paragraph pheading_space = new Paragraph("   ");
                Paragraph p = new Paragraph("Total:-                  " + lbltaotal_quantity.Text + "                 " + lblsubtotal.Text + "                                                     " + lbl_service_charge.Text);
                p.Alignment = Element.ALIGN_BOTTOM;
                pdfDoc.Add(pheading);
                pdfDoc.Add(pheading_business_name);
                pdfDoc.Add(pheading_pan_no);
                pdfDoc.Add(pheadingDate);               
                pdfDoc.Add(pheading_space);
                pdfDoc.Add(pdfTable);
                pdfDoc.Add(p);
                pdfDoc.Close();
                stream.Close();
            }

            MessageBox.Show("Data Has Been Export To Document");
        }

        string exportBillNo;
        private void btn_excel_Click(object sender, EventArgs e)
        {
            //ExporyToExcel(btn_export_toexcel, "ExportedUserDetail");
          //  DataTable dt = new DataTable();
            DataTable dt_m = blu.checkbusiness();
           
            if (dt_m.Rows.Count > 0)
            {
                Business_Name = dt_m.Rows[0]["business_name"].ToString();
                if (Business_Name.Length >= 30)
                {
                    Business_Name = Business_Name.Substring(0, 30);
                }
                pan_no = dt_m.Rows[0]["pan_no"].ToString();
            }
            //Adding the Columns
          
            dt.Columns.Add("Bill No");
            dt.Columns.Add("Customer Name");
            dt.Columns.Add("Item");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("Rate");
            dt.Columns.Add("Total");
            dt.Columns.Add("Date");
            dt.Columns.Add("Paymode");
            dt.Columns.Add("Sub Total");
            dt.Columns.Add("Discount");
            dt.Columns.Add("Cash Amount");
            dt.Columns.Add("Card Amount");
            dt.Columns.Add("Credit Amount");
            dt.Columns.Add("Service Charge");
            dt.Columns.Add("Tax");
            dt.Columns.Add("Grand Total");
            dt.Columns.Add("Cashier");
            dt.Columns.Add("Sales Type");
            for (int i = 0; i < dt_report.Rows.Count; i++)
            {
                dt.Rows.Add();
                dt.Rows[i]["Bill No"] = dt_report.Rows[i]["bill_no"];
                dt.Rows[i]["Item"] = dt_report.Rows[i]["item_name"];
                dt.Rows[i]["Quantity"] = dt_report.Rows[i]["quantity"];
                dt.Rows[i]["Rate"] = dt_report.Rows[i]["cost"];
                dt.Rows[i]["Total"] = dt_report.Rows[i]["total"];
                dt.Rows[i]["Paymode"] = dt_report.Rows[i]["payment_mode"];
                dt.Rows[i]["cashier"] = dt_report.Rows[i]["cashier_name"];
                dt.Rows[i]["Customer Name"] = dt_report.Rows[i]["customer_name"];
                if (exportBillNo != dt_report.Rows[i]["bill_no"].ToString())
                {
                    dt.Rows[i]["Date"] = dt_report.Rows[i]["date_of_sale"];
                    dt.Rows[i]["Sub Total"] = dt_report.Rows[i]["sub_total"];
                    dt.Rows[i]["Discount"] = dt_report.Rows[i]["discount"];
                    dt.Rows[i]["Cash Amount"] = dt_report.Rows[i]["cash_amount"];
                    dt.Rows[i]["Card Amount"] = dt_report.Rows[i]["card_amount"];
                    if (dt_report.Rows[i]["payment_mode"].ToString() == "Credit")
                    {
                        dt.Rows[i]["Credit Amount"] = dt_report.Rows[i]["grand_total"];
                    }
                    else
                    {
                        dt.Rows[i]["Credit Amount"]= "0.00";
                    }
                    dt.Rows[i]["Service Charge"] = dt_report.Rows[i]["service_charge"];
                    dt.Rows[i]["Tax"] = dt_report.Rows[i]["tax_amount"];
                    dt.Rows[i]["Grand Total"] = dt_report.Rows[i]["grand_total"];
                    dt.Rows[i]["Sales Type"] = dt_report.Rows[i]["sales_type"];
                }
                exportBillNo = dt_report.Rows[i]["bill_no"].ToString();
            }
            dt.Rows.Add();
            dt.Rows[dt_report.Rows.Count + 1]["Item"] = "Total";
            dt.Rows[dt_report.Rows.Count + 1]["Quantity"] = lbltaotal_quantity.Text;
            dt.Rows[dt_report.Rows.Count + 1]["Sub Total"] = lblsubtotal.Text;
            dt.Rows[dt_report.Rows.Count + 1]["Service Charge"] = lbl_service_charge.Text;
            dt.Rows[dt_report.Rows.Count + 1]["Tax"] = lbl_tax.Text;
            dt.Rows[dt_report.Rows.Count + 1]["Grand Total"] = lbl_grand_total.Text;
            //Exporting to Excel
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\RestaurantSalesReport Excel\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {               
                wb.Worksheets.Add(dt, Business_Name);               
                wb.SaveAs(folderPath + DateTime.Now.ToString("yyyy-MM-dd hh") + "SalesReport.xlsx");
                MessageBox.Show("Your sales excel report has been export to document", "Sales Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        string colunm_name;
        DataTable dt = new DataTable();//for counting total rows
        DataTable dtLoad = new DataTable();//for load total rows
        string status;
        private void btn_show_Click_1(object sender, EventArgs e)
        {
            fillGrid();
            datatableLoad();
            user_log_insert();   
        }
       
        public void user_log_insert()
        {
            DateTime date = Convert.ToDateTime(DateTime.Now.ToString());
            BLL_user_log bulg = new BLL_user_log();
            string user_name_log = Login.sendtext;
            string day = DateTime.Now.ToString("ddd");
            DataTable dt = bulg.getall_user_log(user_name_log,day, "Viewrestaurant");

            if(dt.Rows.Count==0)
            {
                int abc = bulg.createuserlog(user_name_log, "Viewrestaurant", date, day);
            }
        }
        private void btn_back_Click_1(object sender, EventArgs e)
        {
            backPanel.Hide();
            searchPanel.Show();
        }
        private void btnbackpage_Click(object sender, EventArgs e)
        {
            if (second_user_interface.BusinessType == "Parlour")
            {
                Parlour al = new Parlour();
                Control ctls = this.Parent;
                ctls.Controls.Clear();
                ctls.Controls.Add(al);
            }
            else
            {
                Control ctls = this.Parent;
                allmenu alls = new allmenu();
                ctls.Controls.Clear();
                ctls.Controls.Add(alls);
            }
        }
        private void cbo_searchTYpe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text == "Item")
            {
                products();
                buttonX1.Visible = true;
                colunm_name = "item_name";
            }
            else if (cbo_searchTYpe.Text == "Category")
            {

                category();
                buttonX1.Visible = true;
                colunm_name = "category_name";
            }
            else if (cbo_searchTYpe.Text == "Bill No")
            {
                Billno();
                buttonX1.Visible = true;
                colunm_name = "bill_no";
            }
            else if (cbo_searchTYpe.Text == "Category Group")
            {
                GroupingCategory();
                buttonX1.Visible = false;

            }
           

            else if (cbo_searchTYpe.Text == "ALL")
            {
                clearcombo(txt_searchText);
                txt_searchText.Text = "ALL";
                buttonX1.Visible = true;
                colunm_name = "ALL";
            }
            else if (cbo_searchTYpe.Text == "Payment Mode")
            {
                clearcombo(txt_searchText);
                List<string> mylist = new List<string>();
                mylist.Add("Cash");
                mylist.Add("Card");
                mylist.Add("Cheque");
                mylist.Add("Online");
                mylist.Add("Credit");
                txt_searchText.DataSource = mylist;
                buttonX1.Visible = true;
                colunm_name = "payment_mode";
            }
            else if (cbo_searchTYpe.Text == "KOT Type")
            {
                clearcombo(txt_searchText);
                List<string> mylist = new List<string>();
                mylist.Add("K1");
                mylist.Add("K2");
                mylist.Add("K3");
                mylist.Add("B1");
                mylist.Add("B2");
                txt_searchText.DataSource = mylist;
                buttonX1.Visible = true;
                colunm_name = "kot_type";
            }
            else if (cbo_searchTYpe.Text == "Sales Type")
            {
                clearcombo(txt_searchText);
                List<string> mylist = new List<string>();
                mylist.Add("TS");
                mylist.Add("TA");
                mylist.Add("HD");
                mylist.Add("DA");
                txt_searchText.DataSource = mylist;
                buttonX1.Visible = false;
                colunm_name = "sales_type";
            }
            else if (cbo_searchTYpe.Text == "User")
            {
                clearcombo(txt_searchText);
                User();
                buttonX1.Visible = false;
                colunm_name = "cashier_name";
            }
            else if (cbo_searchTYpe.Text == "Service Provider")
            {
                clearcombo(txt_searchText);
                User();
                buttonX1.Visible = true;
                colunm_name = "service_provider";

            }

        }
        public void User()
        {
            DataTable dt = blu.getalluser();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["user_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = dt;
                txt_searchText.DisplayMember = "user_name";
                txt_searchText.ValueMember = "user_name";
            }
        }
        public void clearcombo(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is ComboBox)
                    ((ComboBox)c).ResetText();
                else
                    clearcombo(c);


            }
        }
        BLLBill_printing blp_re = new BLLBill_printing();
        string bill_no_print;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == dataGridView1.Columns["cal_print"].Index && e.RowIndex >= 0))
            {
                if (dataGridView1.CurrentRow.Cells["cal_sales_type"].Value.ToString() == "HR")
                {
                    bill_printing_for_hotel();
                }
                else
                {
                    bill_no_print = dataGridView1.CurrentRow.Cells["calbill_no"].Value.ToString();
                    int insert_abc = blp_re.insert_bill_reprint(bill_no_print);
                    int mv = blfs.update__materialized(bill_no_print);
                    DataTable dt_prt = blpst.getalldata();
                    if (dt_prt.Rows[0]["bill_printer"].ToString() == "80")
                    {
                        if (AbbreviatedtaxEnable == true && Abbreviatedtax >= Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_grand_total"].Value))
                        {
                            abbreviatedbill_printing_for_80();
                        }
                        else
                        {
                            bill_printing_for_80();
                        }
                    }
                    else if (dt_prt.Rows[0]["bill_printer"].ToString() == "P80")
                    {
                        panBilling80();
                    }
                    else if (dt_prt.Rows[0]["bill_printer"].ToString() == "76")
                    {
                        bill_printing_for_76();
                    }
                    else if (dt_prt.Rows[0]["bill_printer"].ToString() == "A4")
                    {
                        bill_printing_for_A4();
                    }
                    else if (dt_prt.Rows[0]["bill_printer"].ToString() == "C80")
                    {
                        bill_printing_for_Coupon_80();
                    }
                    else
                    {
                        bill_printing_for_58();
                    }
                }
            }
        }
        BLL_Fiscal blfs = new BLL_Fiscal();
        BillPrinting blp = new BillPrinting();
        BillPrinting80 blp_80 = new BillPrinting80();
        BillPrintingHotel bph = new BillPrintingHotel();
        bool save_after_print;
        public void bill_printing_for_58()
        {
           
            blp.bill_no = dataGridView1.CurrentRow.Cells["calbill_no"].Value.ToString(); 
            blp.cashier = dataGridView1.CurrentRow.Cells["calcashier_name"].Value.ToString();
            blp.cash_amount = dataGridView1.CurrentRow.Cells["calcashamt"].Value.ToString();
            blp.discount = dataGridView1.CurrentRow.Cells["cal_discount"].Value.ToString();
            blp.grand_total = dataGridView1.CurrentRow.Cells["cal_grand_total"].Value.ToString();
            blp.sub_total = dataGridView1.CurrentRow.Cells["cal_sub_total"].Value.ToString();
            blp.table_no = dataGridView1.CurrentRow.Cells["cal_table_no"].Value.ToString();
            DateTime date_of_billing = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["caldate"].Value);
            blp.Headerstatus = true;
            blp.FooterStatus = true;
            blp.print_again = true;
            blp.duplicate_bill_print = true;
            DataTable dt = blod.searchbybill2(dataGridView1.CurrentRow.Cells["calbill_no"].Value.ToString());
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    blp.datagridview_item_name.Add(dt.Rows[i]["item_name"].ToString());
                    blp.datagridview_item_price.Add(dt.Rows[i]["cost"].ToString());
                    blp.datagridview_total.Add(dt.Rows[i]["total"].ToString());
                    blp.datagridview_quantity.Add(dt.Rows[i]["quantity"].ToString());
                  
                }
                blp.tax_amount = dt.Rows[0]["tax_amount"].ToString();
                blp.service_charge = dt.Rows[0]["service_charge"].ToString();
            }
            blp.printtobill();
            save_after_print = blp.save_after_print;

        }
        blllCustomerDetailednyo blcd = new blllCustomerDetailednyo();
        BillPrintingA4 ba4 = new BillPrintingA4();
        public void bill_printing_for_A4()
        {
            ba4.Headerstatus = true;
            ba4.FooterStatus = true;
            ba4.printer_name = "Billing";
            string bill_no = dataGridView1.CurrentRow.Cells["calbill_no"].Value.ToString();
            ba4.bill_no = bill_no;
            ba4.cashier = dataGridView1.CurrentRow.Cells["calcashier_name"].Value.ToString();
            ba4.cash_amount = dataGridView1.CurrentRow.Cells["calcashamt"].Value.ToString();
            decimal discount = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_discount"].Value.ToString());
            ba4.discount = discount.ToString();
            ba4.grand_total = dataGridView1.CurrentRow.Cells["cal_grand_total"].Value.ToString();
            decimal subtotal = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_sub_total"].Value.ToString());
            ba4.sub_total = subtotal.ToString();
            ba4.table_no = dataGridView1.CurrentRow.Cells["cal_table_no"].Value.ToString();
            ba4.payment_mode = dataGridView1.CurrentRow.Cells["calpaymode"].Value.ToString();
            ba4.print_again = true;
            ba4.duplicate_bill_print = true;
            ba4.discount_sub_total = (subtotal - discount).ToString();
            ba4.tax_amount = dataGridView1.CurrentRow.Cells["cal_tax"].Value.ToString();
            decimal service_charge = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_service_charge"].Value.ToString());
            ba4.service_charge = service_charge.ToString();
            ba4.taxable_amount = (subtotal + service_charge - discount).ToString();
            ba4.customer_PAN_no = dataGridView1.CurrentRow.Cells["cal_customer_pan"].Value.ToString();
            ba4.customer_name = dataGridView1.CurrentRow.Cells["cal_customer_name"].Value.ToString();
            DataTable dt1 = blcd.search_By_Fullname(dataGridView1.CurrentRow.Cells["cal_customer_name"].Value.ToString());
            if (dt1.Rows.Count > 0)
            {
                ba4.customer_phone_no = dt1.Rows[0]["phone2"].ToString();
                ba4.customer_address = dt1.Rows[0]["address"].ToString();
            }
            DateTime date_billing = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["caldate"].Value.ToString());
            ba4.billing_date = date_billing;



            DataTable dt = blod.searchbybill_and_date(bill_no, date_billing);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ba4.datagridview_item_name.Add(dt.Rows[i]["item_name"].ToString());
                    ba4.datagridview_item_price.Add(dt.Rows[i]["cost"].ToString());
                    ba4.datagridview_total.Add(dt.Rows[i]["total"].ToString());
                    ba4.datagridview_quantity.Add(dt.Rows[i]["quantity"].ToString());
                    ba4.datagridview_complementary.Add("");                   
                }
            }
            ba4.printtobill();
            save_after_print = ba4.save_after_print;
        }
        string nepaliDateConvert;
        public void dateConvertToNepali()
        {
            NepaliDateConverter.DateConverter dp = new NepaliDateConverter.DateConverter();
            var nepalidate = dp.EngToNep(Convert.ToInt32(DateTime.Now.Year), Convert.ToInt32(DateTime.Now.ToString("MM")), Convert.ToInt32(DateTime.Now.ToString("dd")));
            string nyear = nepalidate.ConvertedDate.Year.ToString();
            string nday = nepalidate.ConvertedDate.Day.ToString();
            string nmonths = nepalidate.ConvertedDate.Month.ToString();
            nepaliDateConvert = nyear + ".0" + nmonths + "." + nday;
        }
        /// <summary>
        /// 
        /// </summary>
        public void bill_printing_for_80()
        {
            blp_80.Headerstatus = true;
            blp_80.FooterStatus = true;
            blp_80.printer_name = "Billing";
            blp_80.nepaliDate = nepaliDateConvert;
            string bill_no = dataGridView1.CurrentRow.Cells["calbill_no"].Value.ToString();
            blp_80.bill_no = bill_no;
            string fiscal_year = dataGridView1.CurrentRow.Cells["col_fiscal_year"].Value.ToString();
            blp_80.fiscal_year = fiscal_year;
            blp_80.cashier = dataGridView1.CurrentRow.Cells["calcashier_name"].Value.ToString();
            blp_80.cash_amount = dataGridView1.CurrentRow.Cells["calcashamt"].Value.ToString();
            decimal discount = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_discount"].Value.ToString());
            blp_80.discount = discount.ToString();
            blp_80.grand_total = dataGridView1.CurrentRow.Cells["cal_grand_total"].Value.ToString();
            decimal subtotal= Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_sub_total"].Value.ToString());
            blp_80.sub_total = subtotal.ToString();
            blp_80.table_no = dataGridView1.CurrentRow.Cells["cal_table_no"].Value.ToString();
            blp_80.print_again = true;
            blp_80.duplicate_bill_print = true;
          
            blp_80.tax_amount = dataGridView1.CurrentRow.Cells["cal_tax"].Value.ToString();
            decimal service_charge= Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_service_charge"].Value.ToString());
            blp_80.service_charge = service_charge.ToString();
            if (AbbreviatedtaxEnable == true )
            {
                blp_80.discount_sub_total = (subtotal).ToString();
                blp_80.taxable_amount = (subtotal + service_charge).ToString();
            }
            else
            {
                blp_80.discount_sub_total = (subtotal - discount).ToString();
                blp_80.taxable_amount = (subtotal + service_charge - discount).ToString();
            }
            blp_80.customer_PAN_no = dataGridView1.CurrentRow.Cells["cal_customer_pan"].Value.ToString();
            blp_80.customer_name = dataGridView1.CurrentRow.Cells["cal_customer_name"].Value.ToString();
            blp_80.abbBilling = AbbreviatedtaxEnable;
            DataTable dt1 = blcd.search_By_Fullname(dataGridView1.CurrentRow.Cells["cal_customer_name"].Value.ToString());
            if (dt1.Rows.Count > 0)
            {
                blp_80.customer_phone_no = dt1.Rows[0]["phone2"].ToString();
                blp_80.customer_address= dt1.Rows[0]["address"].ToString();
            }
            DateTime date_billing= Convert.ToDateTime(dataGridView1.CurrentRow.Cells["caldate"].Value.ToString());
            blp_80.billing_date = date_billing;

          

            DataTable dt = blod.searchbybill_and_date(bill_no,date_billing);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    blp_80.datagridview_item_name.Add(dt.Rows[i]["item_name"].ToString());
                    blp_80.datagridview_item_price.Add(dt.Rows[i]["cost"].ToString());
                    blp_80.datagridview_total.Add(dt.Rows[i]["total"].ToString());
                    blp_80.datagridview_quantity.Add(dt.Rows[i]["quantity"].ToString());
                  
                    blp_80.datagridview_complementary.Add("");
                    //string service_provider = dt.Rows[i]["service_provider"].ToString();
                    //if (service_provider != "" && service_provider != null)
                    //{
                    //    blp_80.service_provider += service_provider + " ,";
                    //}
                }
            }
            blp_80.printtobill();
            save_after_print = blp_80.save_after_print;
        }
        AbbreviatedTax80 abt = new AbbreviatedTax80();
        public void abbreviatedbill_printing_for_80()
        {
            abt.Headerstatus = true;
            abt.FooterStatus = true;
            abt.printer_name = "Billing";
            string bill_no = dataGridView1.CurrentRow.Cells["calbill_no"].Value.ToString();
            abt.bill_no = bill_no;
            abt.cashier = dataGridView1.CurrentRow.Cells["calcashier_name"].Value.ToString();
            abt.cash_amount = dataGridView1.CurrentRow.Cells["calcashamt"].Value.ToString();
            decimal discount = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_discount"].Value.ToString());
            abt.discount = discount.ToString();
            abt.grand_total = dataGridView1.CurrentRow.Cells["cal_grand_total"].Value.ToString();
            decimal subtotal = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_sub_total"].Value.ToString());
            abt.sub_total = subtotal.ToString();
            abt.table_no = dataGridView1.CurrentRow.Cells["cal_table_no"].Value.ToString();
            abt.print_again = true;
            abt.duplicate_bill_print = true;
            abt.discount_sub_total = (subtotal - discount).ToString();
            abt.tax_amount = dataGridView1.CurrentRow.Cells["cal_tax"].Value.ToString();
            decimal service_charge = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_service_charge"].Value.ToString());
            abt.service_charge = service_charge.ToString();
            abt.taxable_amount = (subtotal + service_charge - discount).ToString();
            abt.customer_PAN_no = dataGridView1.CurrentRow.Cells["cal_customer_pan"].Value.ToString();
            abt.customer_name = dataGridView1.CurrentRow.Cells["cal_customer_name"].Value.ToString();
        
            DataTable dt1 = blcd.search_By_Fullname(dataGridView1.CurrentRow.Cells["cal_customer_name"].Value.ToString());
            if (dt1.Rows.Count > 0)
            {
                abt.customer_phone_no = dt1.Rows[0]["phone2"].ToString();
                abt.customer_address = dt1.Rows[0]["address"].ToString();
            }
            DateTime date_billing = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["caldate"].Value.ToString());
            abt.billing_date = date_billing;



            DataTable dt = blod.searchbybill_and_date(bill_no, date_billing);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    abt.datagridview_item_name.Add(dt.Rows[i]["item_name"].ToString());
                    abt.datagridview_item_price.Add(dt.Rows[i]["cost"].ToString());
                    abt.datagridview_total.Add(dt.Rows[i]["total"].ToString());
                    abt.datagridview_quantity.Add(dt.Rows[i]["quantity"].ToString());

                    abt.datagridview_complementary.Add("");
                    //string service_provider = dt.Rows[i]["service_provider"].ToString();
                    //if (service_provider != "" && service_provider != null)
                    //{
                    //    abt.service_provider += service_provider + " ,";
                    //}
                }
            }
            abt.printtobill();
            save_after_print = abt.save_after_print;
        }
        CouponPrint cp = new CouponPrint();
        public void bill_printing_for_Coupon_80()
        {
            cp.Headerstatus = true;
            cp.FooterStatus = true;
            cp.printer_name = "Billing";
            string bill_no = dataGridView1.CurrentRow.Cells["calbill_no"].Value.ToString();
            cp.bill_no = bill_no;
            cp.cashier = dataGridView1.CurrentRow.Cells["calcashier_name"].Value.ToString();
            cp.cash_amount = dataGridView1.CurrentRow.Cells["calcashamt"].Value.ToString();
            decimal discount = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_discount"].Value.ToString());
            cp.discount = discount.ToString();
            cp.grand_total = dataGridView1.CurrentRow.Cells["cal_grand_total"].Value.ToString();
            decimal subtotal = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_sub_total"].Value.ToString());
            cp.sub_total = subtotal.ToString();
            cp.table_no = dataGridView1.CurrentRow.Cells["cal_table_no"].Value.ToString();
            cp.print_again = true;
            cp.duplicate_bill_print = true;
            cp.discount_sub_total = (subtotal - discount).ToString();
            cp.tax_amount = dataGridView1.CurrentRow.Cells["cal_tax"].Value.ToString();
            decimal service_charge = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_service_charge"].Value.ToString());
            cp.service_charge = service_charge.ToString();
            cp.taxable_amount = (subtotal + service_charge - discount).ToString();
            cp.customer_PAN_no = dataGridView1.CurrentRow.Cells["cal_customer_pan"].Value.ToString();
            cp.customer_name = dataGridView1.CurrentRow.Cells["cal_customer_name"].Value.ToString();
            DateTime date_billing = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["caldate"].Value.ToString());
            cp.billing_date = date_billing;



            DataTable dt = blod.searchbybill_and_date(bill_no, date_billing);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cp.datagridview_item_name.Add(dt.Rows[i]["item_name"].ToString());
                    cp.datagridview_item_price.Add(dt.Rows[i]["cost"].ToString());
                    cp.datagridview_total.Add(dt.Rows[i]["total"].ToString());
                    cp.datagridview_quantity.Add(dt.Rows[i]["quantity"].ToString());
                    cp.datagridview_complementary.Add("");
                    string service_provider= dt.Rows[i]["service_provider"].ToString();
                    if (service_provider != "" && service_provider != null)
                    {
                        cp.service_provider += service_provider+" ,";
                    }
                }
            }
            cp.printtobill();
            save_after_print = cp.save_after_print;
        }
        BillPrinting76 blp76 = new BillPrinting76();
        public void bill_printing_for_76()
        {
            blp76.Headerstatus = true;
            blp76.FooterStatus = true;
            blp76.printer_name = "Billing";
            blp76.nepaliDate = nepaliDateConvert;
            string bill_no = dataGridView1.CurrentRow.Cells["calbill_no"].Value.ToString();
            blp76.bill_no = bill_no;
            string fiscal_year = dataGridView1.CurrentRow.Cells["col_fiscal_year"].Value.ToString();
            blp76.fiscal_year = fiscal_year;
            blp76.cashier = dataGridView1.CurrentRow.Cells["calcashier_name"].Value.ToString();
            blp76.cash_amount = dataGridView1.CurrentRow.Cells["calcashamt"].Value.ToString();
            decimal discount = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_discount"].Value.ToString());
            blp76.discount = discount.ToString();
            blp76.grand_total = dataGridView1.CurrentRow.Cells["cal_grand_total"].Value.ToString();
            decimal subtotal = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_sub_total"].Value.ToString());
            blp76.sub_total = subtotal.ToString();
            blp76.table_no = dataGridView1.CurrentRow.Cells["cal_table_no"].Value.ToString();
            blp76.print_again = true;
            blp76.duplicate_bill_print = true;
            blp76.discount_sub_total = (subtotal - discount).ToString();
            blp76.tax_amount = dataGridView1.CurrentRow.Cells["cal_tax"].Value.ToString();
            decimal service_charge = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_service_charge"].Value.ToString());
            blp76.service_charge = service_charge.ToString();
            blp76.taxable_amount = (subtotal + service_charge - discount).ToString();
            blp76.customer_PAN_no = dataGridView1.CurrentRow.Cells["cal_customer_pan"].Value.ToString();
            blp76.customer_name = dataGridView1.CurrentRow.Cells["cal_customer_name"].Value.ToString();
            DataTable dt1 = blcd.search_By_Fullname(dataGridView1.CurrentRow.Cells["cal_customer_name"].Value.ToString());
            if (dt1.Rows.Count > 0)
            {
                blp76.customer_phone_no = dt1.Rows[0]["phone2"].ToString();
                blp76.customer_address = dt1.Rows[0]["address"].ToString();
            }
            DateTime date_billing = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["caldate"].Value.ToString());
            blp76.billing_date = date_billing;
            DataTable dt = blod.searchbybill_and_date(bill_no, date_billing);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    blp76.datagridview_item_name.Add(dt.Rows[i]["item_name"].ToString());
                    blp76.datagridview_item_price.Add(dt.Rows[i]["cost"].ToString());
                    blp76.datagridview_total.Add(dt.Rows[i]["total"].ToString());
                    blp76.datagridview_quantity.Add(dt.Rows[i]["quantity"].ToString());
                    blp76.datagridview_complementary.Add("");
                    //string service_provider = dt.Rows[i]["service_provider"].ToString();
                    //if (service_provider != "" && service_provider != null)
                    //{
                    //    blp76.service_provider += service_provider + " ,";
                    //}
                }
            }
            blp76.printtobill();
            save_after_print = blp76.save_after_print;
        }
        PANBillPrinting80 p80 = new PANBillPrinting80();
        public void panBilling80()
        {
            p80.Headerstatus = true;
            p80.FooterStatus = true;
            p80.printer_name = "Billing";
            string bill_no = dataGridView1.CurrentRow.Cells["calbill_no"].Value.ToString();
            p80.bill_no = bill_no;
            p80.cashier = dataGridView1.CurrentRow.Cells["calcashier_name"].Value.ToString();
            p80.cash_amount = dataGridView1.CurrentRow.Cells["calcashamt"].Value.ToString();
            decimal discount = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_discount"].Value.ToString());
            p80.discount = discount.ToString();
            p80.grand_total = dataGridView1.CurrentRow.Cells["cal_grand_total"].Value.ToString();
            decimal subtotal = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_sub_total"].Value.ToString());
            p80.sub_total = subtotal.ToString();
            p80.table_no = dataGridView1.CurrentRow.Cells["cal_table_no"].Value.ToString();
            p80.print_again = true;
            p80.duplicate_bill_print = true;
            p80.discount_sub_total = (subtotal - discount).ToString();
            decimal service_charge = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_service_charge"].Value.ToString());
            p80.service_charge = service_charge.ToString();
            p80.taxable_amount = (subtotal + service_charge - discount).ToString();
            p80.customer_PAN_no = dataGridView1.CurrentRow.Cells["cal_customer_pan"].Value.ToString();
            p80.customer_name = dataGridView1.CurrentRow.Cells["cal_customer_name"].Value.ToString();
            DateTime date_billing = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["caldate"].Value.ToString());
            p80.billing_date = date_billing;
            DataTable dt = blod.searchbybill_and_date(bill_no, date_billing);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    p80.datagridview_item_name.Add(dt.Rows[i]["item_name"].ToString());
                    p80.datagridview_item_price.Add(dt.Rows[i]["cost"].ToString());
                    p80.datagridview_total.Add(dt.Rows[i]["total"].ToString());
                    p80.datagridview_quantity.Add(dt.Rows[i]["quantity"].ToString());
                    p80.datagridview_complementary.Add("");
                }
            }
            p80.printtobill();
            save_after_print = p80.save_after_print;
        }
        public void bill_printing_for_hotel()
        {
            string bill_no = dataGridView1.CurrentRow.Cells["calbill_no"].Value.ToString();
            bph.bill_no = bill_no;
            bph.cashier = dataGridView1.CurrentRow.Cells["calcashier_name"].Value.ToString();
            bph.cash_amount = dataGridView1.CurrentRow.Cells["calcashamt"].Value.ToString();
            bph.discount = dataGridView1.CurrentRow.Cells["cal_discount"].Value.ToString();
            bph.grand_total = dataGridView1.CurrentRow.Cells["cal_grand_total"].Value.ToString();
            bph.sub_total = dataGridView1.CurrentRow.Cells["cal_sub_total"].Value.ToString();
            bph.table_no = dataGridView1.CurrentRow.Cells["cal_table_no"].Value.ToString();
            bph.print_again = true;
            bph.duplicate_bill_print = true;
            bph.mobile_no = dataGridView1.CurrentRow.Cells["cal_customer_pan"].Value.ToString();
            bph.customer_name = dataGridView1.CurrentRow.Cells["cal_customer_name"].Value.ToString();
            DateTime date_of_billing = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["cal_date2"].Value);
            DataTable dt_bil = blbt.get_all_tax_by_bill_no(bill_no, date_of_billing);
            if (dt_bil.Rows.Count > 0)
            {
                bph.tax_amount = dt_bil.Rows[0]["tax_amount"].ToString();
                bph.service_charge = dt_bil.Rows[0]["service_charge"].ToString();
            }
            DataTable dt = blod.searchbybill2(bill_no);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bph.datagridview_item_name.Add(dt.Rows[i]["item_name"].ToString());
                bph.datagridview_item_price.Add(dt.Rows[i]["cost"].ToString());
                bph.datagridview_total.Add(dt.Rows[i]["total"].ToString());
                bph.datagridview_quantity.Add(dt.Rows[i]["quantity"].ToString());
            }
            bph.print();
          
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        DataTable dt_xml= new DataTable();
       
        private void btn_export_XML_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index <14)
                {
                    dt_xml.Columns.Add(column.HeaderText);
                }
            }

            //Adding the Rows
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dt_xml.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex < 14)
                    {
                        dt_xml.Rows[dt_xml.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                    }
                }
            }
            dt_xml.TableName = "MyTable";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\RestaurantSalesReportXML\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            dt_xml.WriteXml(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "SalesReport.xml", XmlWriteMode.WriteSchema);
            MessageBox.Show("Data Exported To XML");
            dt_xml.Clear();
        }
            
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_text_export_Click(object sender, EventArgs e)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\RestaurantSalesReportText\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
          
            TextWriter sw = new StreamWriter(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "SalesReport.txt");
            DataTable dt = blu.checkbusiness();
            if (dt.Rows.Count > 0)
            {
                Business_Name = dt.Rows[0]["business_name"].ToString();
                pan_no = dt.Rows[0]["pan_no"].ToString();
            }
            sw.WriteLine("                         " + Business_Name + "            ");
            sw.WriteLine("                       Pan No:  " + pan_no + "            ");
            sw.WriteLine("Date From: " + dtp_from.Text + "            Date To: " + dtp_to.Text);
            sw.WriteLine("          ");
            int rowcount = dataGridView1.Rows.Count;
            for (int i = 0; i < rowcount - 1; i++)
            {
                sw.WriteLine(dataGridView1.Rows[i].Cells[0].Value.ToString() + "\t"
                             + dataGridView1.Rows[i].Cells[1].Value.ToString() + "\t"
                              + dataGridView1.Rows[i].Cells[2].Value.ToString() + "\t"
                               + dataGridView1.Rows[i].Cells[3].Value.ToString() + "\t"
                                 + dataGridView1.Rows[i].Cells[4].Value.ToString() + "\t"
                                   + dataGridView1.Rows[i].Cells[5].Value.ToString() + "\t"
                                     + dataGridView1.Rows[i].Cells[6].Value.ToString() + "\t"
                                       + dataGridView1.Rows[i].Cells[7].Value.ToString() + "\t"
                                        + dataGridView1.Rows[i].Cells[8].Value.ToString() + "\t"
                                         + dataGridView1.Rows[i].Cells[9].Value.ToString() + "\t"
                                          + dataGridView1.Rows[i].Cells[10].Value.ToString() + "\t"
                                            + dataGridView1.Rows[i].Cells[11].Value.ToString() + "\t"
                                             + dataGridView1.Rows[i].Cells[12].Value.ToString() + "\t"


                               );
            }
            sw.Close();
            MessageBox.Show("Data Has Been Export In Text File");
        }
        ItemPrint itm = new ItemPrint();
        DataTable dti = new DataTable();
        private void buttonX1_Click(object sender, EventArgs e)
        {
            dti.Rows.Clear();
            itm.datagridview_name.Clear();
            itm.datagridview_cost.Clear();
            itm.datagridview_qty.Clear();
            if (colunm_name == "ALL")
            {
                dti = blod.itemGroup(Convert.ToDateTime(dtp_from.Text), Convert.ToDateTime(dtp_to.Text), fiscal_year);
            }
            else
            {
                dti = blod.itemGroups(txt_searchText.Text,Convert.ToDateTime(dtp_from.Text), Convert.ToDateTime(dtp_to.Text),colunm_name, fiscal_year);
            }
            if (dti.Rows.Count > 0)
            {
                itm.cashier = Login.sendtext;
                itm.date_from = dtp_from.Text;
                itm.date_to = dtp_to.Text;
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

        private void chk_time_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_time.Checked == true)
            {
                cbo_from_hours.Visible = true;
                cbo_minuts.Visible = true;
                cbo_minuts_from.Visible = true;
                cbo_to_hours.Visible = true;
            }
            else
            {
                cbo_from_hours.Visible = false;
                cbo_minuts.Visible = false;
                cbo_minuts_from.Visible = false;
                cbo_to_hours.Visible = false;
            }
        }
        DataTable dt_report = new DataTable();
        DataTable dtSum = new DataTable();
        BLLRestaurantReport blrr = new BLLRestaurantReport();
        string fiscal_year;
        private void datatableLoad()
        {
            if (cbo_searchTYpe.Text == "" || cbo_searchTYpe.Text == "Choose Type" || txt_searchText.Text == "")
            {
                MessageBox.Show("The Fields are Empty or invalid.");
            }

            else
            {
                string theDate = dtp_from.Value.ToString("yyyy-MM-dd") + " " + cbo_from_hours.Text + ":" + cbo_minuts_from.Text + ":00";
                string theDate2 = dtp_to.Value.ToString("yyyy-MM-dd") + " " + cbo_to_hours.Text + ":" + cbo_minuts.Text + ":00";
                DateTime dateOne = Convert.ToDateTime(theDate);
                DateTime datetwo = Convert.ToDateTime(theDate2);
                DataTable dtfis = blrr.GetFiscalYearsales(dateOne, datetwo);
                if (dtfis.Rows.Count > 0)
                {
                    fiscal_year = dtfis.Rows[0]["fiscal_year"].ToString();
                }
                else
                {
                    DataTable dt = blfs.get_all_data_from_fiscal("True");
                    if (dt.Rows.Count > 0)
                    {
                        fiscal_year = dt.Rows[0]["fiscal_year"].ToString();

                    }
                }

                if (cbo_searchTYpe.Text == "Item")
                {
                    colunm_name = "item_name";
                }
                else if (cbo_searchTYpe.Text == "Category")
                {
                    colunm_name = "category_name";
                }
                else if (cbo_searchTYpe.Text == "Bill No")
                {
                    colunm_name = "bill_no";
                }

                else if (cbo_searchTYpe.Text == "Payment Mode")
                {
                    colunm_name = "payment_mode";
                }

                else if (cbo_searchTYpe.Text == "KOT Type")
                {
                    colunm_name = "kot_type";
                }
                else if (cbo_searchTYpe.Text == "Sales Type")
                {
                    colunm_name = "sales_type";
                }
                else if (cbo_searchTYpe.Text == "User")
                {
                    colunm_name = "cashier_name";
                }
                else if (cbo_searchTYpe.Text == "Service provider")
                {
                    colunm_name = "service_provider";
                }
                int intSkip = 0;

                intSkip = (this.mintCurrentPage * this.mintPageSize);
                if (cbo_searchTYpe.Text == "ALL")
                {
                    dt_report = blod.searchALLSalesWithoutpagination(dateOne, datetwo,fiscal_year);
                    dtLoad = blod.searchALLSales(dateOne, datetwo, mintPageSize, intSkip,fiscal_year);
                    dtSum = blrr.totalSalesSum(dateOne, datetwo,fiscal_year);
                    DataGridViewLoad();
                }
                else if (cbo_searchTYpe.Text == "Bill No")
                {

                    dtLoad = blod.searchbybill2(txt_searchText.Text);
                    dt_report = blod.searchbybill2(txt_searchText.Text);
                    dtSum = blrr.totalSalesSumByBillNo(txt_searchText.Text,fiscal_year);
                    DataGridViewLoad();
                }
                else if (cbo_searchTYpe.Text == "Category Group")
                {
                    dtLoad = blcg.getallFromView(dateOne, datetwo, txt_searchText.Text);
                    dt_report = blcg.getallFromView(dateOne, datetwo, txt_searchText.Text);
                    DataGridViewLoad();
                }
                else
                {
                    dtLoad = blod.searchitembyname2(txt_searchText.Text, dateOne, datetwo, colunm_name,fiscal_year);
                    dt_report = blod.searchitembyname2(txt_searchText.Text, dateOne, datetwo, colunm_name,fiscal_year);
                    dtSum = blrr.totalSalesSumBYdifferentColumn(txt_searchText.Text, dateOne, datetwo, colunm_name,fiscal_year);
                    DataGridViewLoad();
                }
                this.status = (this.mintCurrentPage + 1).ToString() + " / " + this.mintPageCount.ToString();
            }
        }

        public void DataGridViewLoad()
        {
            if (dtLoad.Rows.Count > 0)
            {

                dataGridView1.Rows.Clear();
                for (int inc = 0; inc < dtLoad.Rows.Count; inc++)
                {
                    int ww = dataGridView1.Rows.Add();
                    dataGridView1.Rows[inc].Cells["calitem"].Value = dtLoad.Rows[inc]["item_name"].ToString();
                    dataGridView1.Rows[inc].Cells["calquantity"].Value = dtLoad.Rows[inc]["quantity"].ToString();
                    dataGridView1.Rows[inc].Cells["caltotal"].Value = dtLoad.Rows[inc]["total"].ToString();
                    dataGridView1.Rows[inc].Cells["cal_cost"].Value = dtLoad.Rows[inc]["cost"].ToString();
                    dataGridView1.Rows[inc].Cells["caldate"].Value = dtLoad.Rows[inc]["date_of_sale"].ToString();
                    dataGridView1.Rows[inc].Cells["col_fiscal_year"].Value = dtLoad.Rows[inc]["fiscal_year"].ToString();
                  //  brfiscal_year = dtLoad.Rows[inc]["fiscal_year"].ToString();
                    //if (fiscal_year!= dtLoad.Rows[inc]["fiscal_year"].ToString())
                    //{

                    //}
                    //else
                    //{

                    //}
               
                    if (bill_no != dtLoad.Rows[inc]["bill_no"].ToString() || brfiscal_year != dtLoad.Rows[inc]["fiscal_year"].ToString())
                    {
                        dataGridView1.Rows[inc].Cells["cal_grand_total"].Value = dtLoad.Rows[inc]["grand_total"].ToString();                    
                        string payment_mode  = dtLoad.Rows[inc]["payment_mode"].ToString();
                        dataGridView1.Rows[inc].Cells["calpaymode"].Value = payment_mode;
                        if (payment_mode == "Credit")
                        {
                            dataGridView1.Rows[inc].Cells["cal_credit_amt"].Value = dtLoad.Rows[inc]["grand_total"].ToString();
                        }
                        else
                        {
                            dataGridView1.Rows[inc].Cells["cal_credit_amt"].Value = "0.00";
                        }
                        
                        dataGridView1.Rows[inc].Cells["calcardamount"].Value = dtLoad.Rows[inc]["card_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["calcashamt"].Value = dtLoad.Rows[inc]["cash_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["calcashier_name"].Value = dtLoad.Rows[inc]["cashier_name"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_tax"].Value = dtLoad.Rows[inc]["tax_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_service_charge"].Value = dtLoad.Rows[inc]["service_charge"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_discount"].Value = dtLoad.Rows[inc]["discount"].ToString();
                   

                    }
                    
                    bill_no = dtLoad.Rows[inc]["bill_no"].ToString();
                    brfiscal_year= dtLoad.Rows[inc]["fiscal_year"].ToString();
                    dataGridView1.Rows[inc].Cells["calbill_no"].Value = bill_no;
                    dataGridView1.Rows[inc].Cells["caldate"].Value = Convert.ToDateTime(dtLoad.Rows[inc]["date_of_sale"].ToString());
                    dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dtLoad.Rows[inc]["sales_type"].ToString();
                    dataGridView1.Rows[inc].Cells["cal_sales_id"].Value = dtLoad.Rows[inc]["rest_sale_id"].ToString();
                    dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dtLoad.Rows[inc]["table_no"].ToString();
                    dataGridView1.Rows[inc].Cells["cal_category_name"].Value = dtLoad.Rows[inc]["category_name"].ToString();                 
                    dataGridView1.Rows[inc].Cells["cal_sub_total"].Value = dtLoad.Rows[inc]["sub_total"].ToString();
                    dataGridView1.Rows[inc].Cells["cal_date2"].Value = dtLoad.Rows[inc]["date2"].ToString();
                    dataGridView1.Rows[inc].Cells["cal_customer_pan"].Value = dtLoad.Rows[inc]["customer_no"].ToString();
                    dataGridView1.Rows[inc].Cells["cal_customer_name"].Value = dtLoad.Rows[inc]["customer_name"].ToString();

                }
               grandtotalCalculation();
                backPanel.Show();
                searchPanel.Hide();
                bill_no = null;
            }
        }
        private void cbo_to_hours_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbo_minuts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
        private void btn_next_Click(object sender, EventArgs e)
        {
            goNext();
        }
        private void btn_previous_Click(object sender, EventArgs e)
        {
            goPrevious();
        }
        public void fillGrid()
        {
            if (cbo_searchTYpe.Text != "" || cbo_searchTYpe.Text != "Choose Type" || txt_searchText.Text != ""|| cbo_searchTYpe.Text != "Category Group")
            {
                // For Page view.
                this.mintPageSize = 20;
                datatableLoadCount();
                this.mintTotalRecords = Convert.ToInt32(dt.Rows[0][0]);
                this.mintPageCount = mintTotalRecords / this.mintPageSize;

                // Adjust page count if the last page contains partial page.
                if (mintTotalRecords % this.mintPageSize > 0)
                    this.mintPageCount++;

                this.mintCurrentPage = 0;
            }
           // loadPage();
        }
        BLLCategoryGrouping blcg = new BLLCategoryGrouping();
             
        public void datatableLoadCount()
        {
            if (cbo_searchTYpe.Text == "" || cbo_searchTYpe.Text == "Choose Type" || txt_searchText.Text == "")
            {
                MessageBox.Show("The Fields are Empty or invalid.");
            }

            else
            {
                string theDate = dtp_from.Value.ToString("yyyy-MM-dd") + " " + cbo_from_hours.Text + ":" + cbo_minuts_from.Text + ":00";
                string theDate2 = dtp_to.Value.ToString("yyyy-MM-dd") + " " + cbo_to_hours.Text + ":" + cbo_minuts.Text + ":00";
                DateTime dateOne = Convert.ToDateTime(theDate);
                DateTime datetwo = Convert.ToDateTime(theDate2);
                DataTable dtfis = blrr.GetFiscalYearsales(dateOne, datetwo);
                if (dtfis.Rows.Count > 0)
                {
                    fiscal_year = dtfis.Rows[0]["fiscal_year"].ToString();
                }
                else
                {
                    DataTable dt = blfs.get_all_data_from_fiscal("True");
                    if (dt.Rows.Count > 0)
                    {
                        fiscal_year = dt.Rows[0]["fiscal_year"].ToString();

                    }
                }
                if (cbo_searchTYpe.Text == "Item")
                {
                    colunm_name = "item_name";
                }
                else if (cbo_searchTYpe.Text == "Category")
                {
                    colunm_name = "category_name";
                }
                else if (cbo_searchTYpe.Text == "Bill No")
                {
                    colunm_name = "bill_no";
                }

                else if (cbo_searchTYpe.Text == "Payment Mode")
                {
                    colunm_name = "payment_mode";
                }

                else if (cbo_searchTYpe.Text == "KOT Type")
                {
                    colunm_name = "kot_type";
                }
                else if (cbo_searchTYpe.Text == "Sales Type")
                {
                    colunm_name = "sales_type";
                }
                else if (cbo_searchTYpe.Text == "User")
                {
                    colunm_name = "cashier_name";
                }
                else if (cbo_searchTYpe.Text == "Service Provider")
                {
                    colunm_name = "service_provider";
                }

                if (cbo_searchTYpe.Text == "ALL")
                {
                    dt = blod.searchALLSalesRecord(dateOne, datetwo,fiscal_year);
                }
                else if (cbo_searchTYpe.Text == "Bill No")
                {

                    dt = blod.searchbybill2Count(txt_searchText.Text);
                }
                else if (cbo_searchTYpe.Text == "Category Group")
                {
                    dt = blcg.getallFromView(dateOne, datetwo, txt_searchText.Text);
                }
                else
                {
                    dt = blod.searchitembyname2Count(txt_searchText.Text, dateOne, datetwo, colunm_name,fiscal_year);
                }

            }
        }
        private void goFirst()
        {
            this.mintCurrentPage = 0;

            datatableLoad();
        }

        private void goPrevious()
        {
            if (this.mintCurrentPage == this.mintPageCount)
                this.mintCurrentPage = this.mintPageCount - 1;

            this.mintCurrentPage--;

            if (this.mintCurrentPage < 1)
                this.mintCurrentPage = 0;

            datatableLoad();
        }

        private void goNext()
        {
            this.mintCurrentPage++;

            if (this.mintCurrentPage > (this.mintPageCount - 1))
                this.mintCurrentPage = this.mintPageCount - 1;

            datatableLoad();
        }

        private void goLast()
        {
            this.mintCurrentPage = this.mintPageCount - 1;

            datatableLoad();
        }

       
    }
}

