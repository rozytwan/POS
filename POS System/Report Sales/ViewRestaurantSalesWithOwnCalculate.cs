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
using System.Linq;

namespace POS_System
{
    public partial class ViewRestaurantSalesWithOwnCalculate:UserControl
    {
        public ViewRestaurantSalesWithOwnCalculate()
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
        BLLRestaurantReport brr = new BLLRestaurantReport();
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
        
        private void Viewrestaurant_Load(object sender, EventArgs e)
        {
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
            lbltaotal_quantity.Text = (dataGridView1.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDecimal(t.Cells["calquantity"].Value))).ToString("#.##");
            lbltotal.Text = (dataGridView1.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDecimal(t.Cells["caltotal"].Value))).ToString("#.##");
          
            lbl_sub_total.Text = (dataGridView1.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDecimal(t.Cells["cal_sub_total"].Value))).ToString("#.##");
            lbl_sub_total_with_discount.Text = (dataGridView1.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDecimal(t.Cells["cal_sub_total_with_dis"].Value))).ToString("#.##");
          
            lbl_service_charge.Text = (dataGridView1.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDecimal(t.Cells["cal_service_charge"].Value))).ToString("#.##");
            lbl_taxable_amount.Text = (dataGridView1.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDecimal(t.Cells["cal_taxable_amount"].Value))).ToString("#.##");
            lbl_tax.Text = (dataGridView1.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDecimal(t.Cells["cal_tax"].Value))).ToString("#.##");
            lbl_grand_total.Text = (dataGridView1.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDecimal(t.Cells["cal_grand_total"].Value))).ToString("#.##");
          
           
            // lbl.Text = qty.ToString();
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

                if (column.Index <= 11)
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
                    if (cells.ColumnIndex <= 11)
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
            using (FileStream stream = new FileStream(folderPath + "Restaurant Item  Sales Report " + Datename + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                pdfDoc.Header = new HeaderFooter(new Phrase("Header Text"), false);
                pdfDoc.Open();
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph pheading = new Paragraph("Restaurant Item Sales Report");
                Paragraph pheading_business_name = new Paragraph(Business_Name);
                Paragraph pheading_pan_no = new Paragraph("Pan No :"+pan_no);
                Paragraph pheadingDate = new Paragraph("From:     "+ dtp_from.Text+"                                        "+"To:      "+dtp_to.Text);
                pheading.Alignment = Element.TITLE;
                pheading_business_name.Alignment = Element.TITLE;
                pheading_pan_no.Alignment = Element.TITLE;        
                pheading.Alignment = Element.TITLE;
                Paragraph pheading_space = new Paragraph("   ");
                Paragraph p = new Paragraph("Total:-                  " + lbltaotal_quantity.Text + "                 " + lbltotal.Text + "                                                     " + lbl_service_charge.Text);
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
                if (exportBillNo != dt_report.Rows[i]["bill_no"].ToString())
                {
                    dt.Rows[i]["Date"] = dt_report.Rows[i]["date_of_sale"];
                    dt.Rows[i]["Sub Total"] = dt_report.Rows[i]["sub_total"];
                    dt.Rows[i]["Discount"] = dt_report.Rows[i]["discount"];
                    dt.Rows[i]["Cash Amount"] = dt_report.Rows[i]["cash_amount"];
                    dt.Rows[i]["Card Amount"] = dt_report.Rows[i]["card_amount"];
               
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
            dt.Rows[dt_report.Rows.Count + 1]["Sub Total"] = lbltotal.Text;
            dt.Rows[dt_report.Rows.Count + 1]["Service Charge"] = lbl_service_charge.Text;
            dt.Rows[dt_report.Rows.Count + 1]["Tax"] = lbl_tax.Text;
            dt.Rows[dt_report.Rows.Count + 1]["Grand Total"] = lbl_grand_total.Text;
            //Exporting to Excel
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\KOT Wise Sales Excel\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {               
                wb.Worksheets.Add(dt, "Sales Report");               
                wb.SaveAs(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "SalesReport.xlsx");
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
            DataTable dt = bulg.getall_user_log(user_name_log, day, "Viewrestaurant");

            if (dt.Rows.Count == 0)
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
            Control ctls = this.Parent;
            allmenu alls = new allmenu();
            ctls.Controls.Clear();
            ctls.Controls.Add(alls);
        }
        private void cbo_searchTYpe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text == "Item")
            {
                products();
                colunm_name = "item_name";
                buttonX1.Visible = true;
            }
            else if (cbo_searchTYpe.Text == "Category")
            {
                category();
                colunm_name = "category_name";
                buttonX1.Visible = true;
            }
            else if (cbo_searchTYpe.Text == "Bill No")
            {
                Billno();
                colunm_name = "bill_no";
                buttonX1.Visible = true;
            }
            else if (cbo_searchTYpe.Text == "Category Group")
            {
                GroupingCategory();
                buttonX1.Visible = false;
            }
           

            else if (cbo_searchTYpe.Text == "ALL")
            {
                clearcombo(txt_searchText);
                colunm_name = "ALL";
                txt_searchText.Text = "ALL";
                buttonX1.Visible = true;
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
                colunm_name = "payment_mode";
                txt_searchText.DataSource = mylist;
                buttonX1.Visible = true;
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
                colunm_name = "kot_type";
                txt_searchText.DataSource = mylist;
                buttonX1.Visible = true;
            }
            else if (cbo_searchTYpe.Text == "Sales Type")
            {
                clearcombo(txt_searchText);
                List<string> mylist = new List<string>();
                mylist.Add("TS");
                mylist.Add("TA");
                mylist.Add("HD");
                mylist.Add("DA");
                colunm_name = "sales_type";
                txt_searchText.DataSource = mylist;
                buttonX1.Visible = true;

            }
            else if (cbo_searchTYpe.Text == "User")
            {
                clearcombo(txt_searchText);
                User();
                buttonX1.Visible = true;

            }
            else if (cbo_searchTYpe.Text == "Service Provider")
            {
                clearcombo(txt_searchText);
                User();
                buttonX1.Visible = true;

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
          
        }
        BLL_Fiscal blfs = new BLL_Fiscal();
        BillPrinting blp = new BillPrinting();
        BillPrinting80 blp_80 = new BillPrinting80();
        BillPrintingHotel bph = new BillPrintingHotel();
        bool save_after_print;
     
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
            itm.datagridview_qty.Clear();
            itm.datagridview_cost.Clear();
            if (colunm_name=="ALL")
            {
                dti = blod.itemGroup(Convert.ToDateTime(dtp_from.Text), Convert.ToDateTime(dtp_to.Text), fiscal_year);
            }
            else
            {
                dti = blod.itemGroups(txt_searchText.Text, Convert.ToDateTime(dtp_from.Text), Convert.ToDateTime(dtp_to.Text), colunm_name, fiscal_year);
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
                    dtLoad = brr.searchitembyColumnNameDynamic(txt_searchText.Text, dateOne, datetwo, colunm_name,fiscal_year);
                    dt_report = brr.searchitembyColumnNameDynamic(txt_searchText.Text, dateOne, datetwo, colunm_name,fiscal_year);
                   // dtSum = blrr.totalSalesSumBYdifferentColumn(txt_searchText.Text, dateOne, datetwo, colunm_name);
                    DataGridViewLoad();
                }
                this.status = (this.mintCurrentPage + 1).ToString() + " / " + this.mintPageCount.ToString();
            }
        }
        DiscountCalculationForReport dcr = new DiscountCalculationForReport();
        TaxCalculation tc = new TaxCalculation();
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
                    string cost = dtLoad.Rows[inc]["total"].ToString();
                    dataGridView1.Rows[inc].Cells["caltotal"].Value = cost;
                    string sub_total = dtLoad.Rows[inc]["sub_total"].ToString();
                    dataGridView1.Rows[inc].Cells["cal_sub_total"].Value = sub_total;
                    string discount = dtLoad.Rows[inc]["discount"].ToString();
                    dataGridView1.Rows[inc].Cells["calcashier_name"].Value = discount;               
                    float discount_amount = dcr.calculateDiscount(Convert.ToDecimal(cost), Convert.ToDecimal(discount));
                    string amountWithDiscount = (Convert.ToSingle(cost) - discount_amount).ToString();
                    dataGridView1.Rows[inc].Cells["cal_sub_total_with_dis"].Value = amountWithDiscount;
                    decimal service_change = tc.service_calculation(Convert.ToDecimal(amountWithDiscount));
                    dataGridView1.Rows[inc].Cells["cal_service_charge"].Value = service_change.ToString();
                    decimal taxable_amount = (Convert.ToDecimal(amountWithDiscount) + Convert.ToDecimal(service_change));
                    dataGridView1.Rows[inc].Cells["cal_taxable_amount"].Value = taxable_amount.ToString();
                    decimal tax_amount = tc.tax_calculation(taxable_amount); 
                    dataGridView1.Rows[inc].Cells["cal_tax"].Value = tax_amount.ToString();
                    dataGridView1.Rows[inc].Cells["cal_grand_total"].Value = taxable_amount + tax_amount;
                   dataGridView1.Rows[inc].Cells["calbill_no"].Value = dtLoad.Rows[inc]["bill_no"].ToString();
                    dataGridView1.Rows[inc].Cells["caldate"].Value = Convert.ToDateTime(dtLoad.Rows[inc]["date_of_sale"].ToString());
                    dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dtLoad.Rows[inc]["sales_type"].ToString();
                    dataGridView1.Rows[inc].Cells["caldate"].Value = dtLoad.Rows[inc]["date_of_sale"].ToString();
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
                this.mintPageSize = 200;
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

