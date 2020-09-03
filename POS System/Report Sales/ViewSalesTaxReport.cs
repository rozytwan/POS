using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLS;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;
using iTextSharp.text.pdf;
using iTextSharp.text;
using ClosedXML.Excel;
using System.Threading;
using System.Xml;

namespace POS_System
{
    public partial class Viewrestaurant_copy : UserControl
    {
        public Viewrestaurant_copy()
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


        private void Viewrestaurant_Load(object sender, EventArgs e)
        {
            dtp_from.Value = DateTime.Now;
            dtp_to.Value = DateTime.Now;
            this.Width = this.Parent.Width;
            user_name = Login.sendtext;
            backPanel.Hide();
            cbo_searchTYpe.SelectedIndex = 0;
            // dtdsearchbydate.Focus();



        }
        string bill_no;
        public void grandtotal()
        {
            decimal sum_tax = 0;
            decimal grand_total = 0;
            decimal discount = 0;
            decimal taxable_amount = 0;
         

            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {

            

                if (bill_no != dataGridView1.Rows[x].Cells["calbill_no"].Value.ToString())
                {
                    grand_total += Convert.ToDecimal(dataGridView1.Rows[x].Cells["cal_total_sales"].Value.ToString());
                    sum_tax += Convert.ToDecimal(dataGridView1.Rows[x].Cells["cal_tax"].Value.ToString());
                    discount += Convert.ToDecimal(dataGridView1.Rows[x].Cells["cal_discount"].Value.ToString());
                    taxable_amount += Convert.ToDecimal(dataGridView1.Rows[x].Cells["cal_taxable_sales_amount"].Value.ToString());

                }
            }
            lblgrand_total.Text = grand_total.ToString("#.##");
            lbl_tax_amount.Text = sum_tax.ToString("#.##");
            lbl_tax_sales_discount.Text = discount.ToString("#.##");
            lbl_taxable_sales.Text = taxable_amount.ToString("#.##");
        

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
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount - 16);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            PdfPCell cell = new PdfPCell();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                if (column.Index <= 8)
                {
                    cell = new PdfPCell(new Phrase(column.HeaderText));
                    pdfTable.AddCell(cell);
                }
            }



            //Adding DataRow
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                foreach (DataGridViewCell cells in row.Cells)
                {
                    if (cells.ColumnIndex <= 8)
                    {
                        pdfTable.AddCell(cells.Value.ToString() ?? string.Empty);
                    }
                }
            }

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\Restaurant Tax Sales Report\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string Datename = DateTime.Now.ToString("dd-mm-yyyy hh");
            using (FileStream stream = new FileStream(folderPath + "RestaurantTAXSalesReport " + Datename + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                pdfDoc.Header = new HeaderFooter(new Phrase("Header Text"), false);
                pdfDoc.Open();
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph pheading = new Paragraph("Restaurant Tax Sales Report");
                Paragraph pheading_business_name = new Paragraph(Business_Name);
                Paragraph pheading_pan_no = new Paragraph("Pan No :" + pan_no);
                Paragraph pheadingDate = new Paragraph("From:     " + dtp_from.Text + "                                        " + "To:      " + dtp_to.Text);
                pheading.Alignment = Element.TITLE;
                pheading_business_name.Alignment = Element.TITLE;
                pheading_pan_no.Alignment = Element.TITLE;
                pheading.Alignment = Element.TITLE;
                Paragraph pheading_space = new Paragraph("   ");
                Paragraph p = new Paragraph("Total:-                                                                                                    " + lblgrand_total.Text + "           "+lbl_tax_sales_discount.Text+ "                                                 "+lbl_taxable_sales.Text+"                 " + lbl_tax_amount.Text);
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


        private void btn_excel_Click(object sender, EventArgs e)
        {
            
            ////ExporyToExcel(btn_export_toexcel, "ExportedUserDetail");
            //DataTable dt = new DataTable();

            ////Adding the Columns
            //foreach (DataGridViewColumn column in dataGridView1.Columns)
            //{
            //    if (column.Index <= 9)
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
            //        if (cell.ColumnIndex <= 9)
            //        {
            //            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
            //        }
            //    }
            //}

            ////Exporting to Excel
            //string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\RestaurantSalesReport Excel\\";
            //if (!Directory.Exists(folderPath))
            //{
            //    Directory.CreateDirectory(folderPath);
            //}
            //using (XLWorkbook wb = new XLWorkbook())
            //{
            //    wb.Worksheets.Add(dt, "Sales Report");
            //    wb.SaveAs(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "SalesReport.xlsx");
            //}
       
      

        }

        decimal service_charger;
        decimal sum_tax;
        string fiscal_year;
        BLLRestaurantReport blrr = new BLLRestaurantReport();
        BLL_Fiscal blfsc = new BLL_Fiscal();
        private void btn_show_Click_1(object sender, EventArgs e)
        {
            DataTable dtfs = blfsc.get_all_data_from_fiscal("True");
            if (dtfs.Rows.Count > 0)
            {
                fiscal_year = dtfs.Rows[0]["fiscal_year"].ToString();

            }
            else
            {
                DataTable dt = blfsc.get_all_data_from_fiscal("True");
                if (dt.Rows.Count > 0)
                {
                    fiscal_year = dt.Rows[0]["fiscal_year"].ToString();

                }
            }
            if (cbo_searchTYpe.Text == "" || cbo_searchTYpe.Text == "Choose Type" || txt_searchText.Text == "")
            {
                MessageBox.Show("The Fields are Empty or invalid.");
            }

            else
            {
                DateTime dateOne = Convert.ToDateTime(dtp_from.Text);
                DateTime datetwo = Convert.ToDateTime(dtp_to.Text);
                DateTime date = Convert.ToDateTime(DateTime.Now.ToString());
                DataTable dtfis = blrr.GetFiscalYearsales(dateOne, datetwo);
                if (dtfis.Rows.Count > 0)
                {
                    fiscal_year = dtfis.Rows[0]["fiscal_year"].ToString();
                }
                if (cbo_searchTYpe.Text == "Item")
                {
                    DataTable dt = blod.searchitembyname2_taX_SALES(txt_searchText.Text, dateOne, datetwo,fiscal_year);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int inc = 0; inc < dt.Rows.Count; inc++)
                        {
                            int ac = dataGridView1.Rows.Add();
                            DateTime date_of_billing = Convert.ToDateTime(dt.Rows[inc]["date2"].ToString());
                            dataGridView1.Rows[inc].Cells["caldate"].Value = Convert.ToDateTime(dt.Rows[inc]["date_of_sale"].ToString());
                            dataGridView1.Rows[inc].Cells["calcardamount"].Value = dt.Rows[inc]["card_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["calcashamt"].Value = dt.Rows[inc]["cash_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["calpaymode"].Value = dt.Rows[inc]["payment_mode"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_kot_type"].Value = dt.Rows[inc]["kot_type"].ToString();
                          
                            dataGridView1.Rows[inc].Cells["cal_non_taxable_sales"].Value = (0.00).ToString();
                            string bill_no = dt.Rows[inc]["bill_no"].ToString();
                            dataGridView1.Rows[inc].Cells["calbill_no"].Value = bill_no;
                           
                                dataGridView1.Rows[inc].Cells["cal_tax"].Value = dt.Rows[inc]["tax_amount"].ToString();
                                dataGridView1.Rows[inc].Cells["cal_service_charge"].Value = dt.Rows[inc]["service_charge"].ToString();
                                dataGridView1.Rows[inc].Cells["cal_taxable_sales_amount"].Value = dt.Rows[inc]["taxable_amount"].ToString();
                            service_charger = dt.Select().Where(p => p["service_charge"] != DBNull.Value && Convert.ToDecimal(p["service_charge"]) > 0).Select(c => Convert.ToDecimal(c["service_charge"])).Sum();
                                sum_tax = dt.Select().Where(p => p["tax_amount"] != DBNull.Value && Convert.ToDecimal(p["tax_amount"]) > 0).Select(c => Convert.ToDecimal(c["tax_amount"])).Sum();
                          
                            dataGridView1.Rows[inc].Cells["cal_total_sales"].Value = dt.Rows[inc]["grand_total"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dt.Rows[inc]["sales_type"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dt.Rows[inc]["table_no"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_discount"].Value = dt.Rows[inc]["discount"].ToString();                        
                            dataGridView1.Rows[inc].Cells["cal_date2"].Value = dt.Rows[inc]["date2"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_customer_pan"].Value = dt.Rows[inc]["customer_no"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_customer_name"].Value = dt.Rows[inc]["customer_name"].ToString();
                            // grandtotal();
                            decimal sum_grand_total = dt.Select().Where(p => p["grand_total"] != DBNull.Value && Convert.ToInt32(p["grand_total"]) > 0).Select(c => Convert.ToDecimal(c["grand_total"])).Sum();
                            decimal sum_discount = dt.Select().Where(p => p["discount"] != DBNull.Value && Convert.ToInt32(p["discount"]) > 0).Select(c => Convert.ToDecimal(c["discount"])).Sum();

                            decimal sum_sub_total = dt.Select().Where(p => p["sub_total"] != DBNull.Value && Convert.ToInt32(p["sub_total"]) > 0).Select(c => Convert.ToDecimal(c["sub_total"])).Sum();
                            lblgrand_total.Text = Convert.ToString(sum_grand_total);
                            lbl_tax_sales_discount.Text = Convert.ToString(sum_discount);
                            lbl_taxable_sales.Text = Convert.ToString(sum_sub_total);
                            lbl_tax_amount.Text = sum_tax.ToString();
                        }
                        backPanel.Show();
                        searchPanel.Hide();

                    }//dt rows if end
                    else
                    {
                        MessageBox.Show("No Record Found");
                    }
                }
                else if (cbo_searchTYpe.Text == "Category")
                {
                    DataTable dt = blod.searchbycategory_for_tax_(txt_searchText.Text, dateOne, datetwo);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int inc = 0; inc < dt.Rows.Count; inc++)
                        {
                            int ac = dataGridView1.Rows.Add();
                            DateTime date_of_billing = Convert.ToDateTime(dt.Rows[inc]["date2"].ToString());
                            dataGridView1.Rows[inc].Cells["caldate"].Value = Convert.ToDateTime(dt.Rows[inc]["date_of_sale"].ToString());
                            dataGridView1.Rows[inc].Cells["calcardamount"].Value = dt.Rows[inc]["card_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["calcashamt"].Value = dt.Rows[inc]["cash_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["calpaymode"].Value = dt.Rows[inc]["payment_mode"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_kot_type"].Value = dt.Rows[inc]["kot_type"].ToString();
                           
                            dataGridView1.Rows[inc].Cells["cal_non_taxable_sales"].Value = (0.00).ToString();
                            string bill_no = dt.Rows[inc]["bill_no"].ToString();
                            dataGridView1.Rows[inc].Cells["calbill_no"].Value = bill_no;

                            dataGridView1.Rows[inc].Cells["cal_tax"].Value = dt.Rows[inc]["tax_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_service_charge"].Value = dt.Rows[inc]["service_charge"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_taxable_sales_amount"].Value = dt.Rows[inc]["taxable_amount"].ToString();
                            service_charger = dt.Select().Where(p => p["service_charge"] != DBNull.Value && Convert.ToDecimal(p["service_charge"]) > 0).Select(c => Convert.ToDecimal(c["service_charge"])).Sum();
                            sum_tax = dt.Select().Where(p => p["tax_amount"] != DBNull.Value && Convert.ToDecimal(p["tax_amount"]) > 0).Select(c => Convert.ToDecimal(c["tax_amount"])).Sum();

                            dataGridView1.Rows[inc].Cells["cal_total_sales"].Value = dt.Rows[inc]["grand_total"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dt.Rows[inc]["sales_type"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dt.Rows[inc]["table_no"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_discount"].Value = dt.Rows[inc]["discount"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_date2"].Value = dt.Rows[inc]["date2"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_customer_pan"].Value = dt.Rows[inc]["customer_no"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_customer_name"].Value = dt.Rows[inc]["customer_name"].ToString();
                            // grandtotal();
                            decimal sum_grand_total = dt.Select().Where(p => p["grand_total"] != DBNull.Value && Convert.ToInt32(p["grand_total"]) > 0).Select(c => Convert.ToDecimal(c["grand_total"])).Sum();
                            decimal sum_discount = dt.Select().Where(p => p["discount"] != DBNull.Value && Convert.ToInt32(p["discount"]) > 0).Select(c => Convert.ToDecimal(c["discount"])).Sum();

                            decimal sum_sub_total = dt.Select().Where(p => p["sub_total"] != DBNull.Value && Convert.ToInt32(p["sub_total"]) > 0).Select(c => Convert.ToDecimal(c["sub_total"])).Sum();
                            lblgrand_total.Text = Convert.ToString(sum_grand_total);
                            lbl_tax_sales_discount.Text = Convert.ToString(sum_discount);
                            lbl_taxable_sales.Text = Convert.ToString(sum_sub_total);
                            lbl_tax_amount.Text = sum_tax.ToString();
                        }
                        backPanel.Show();
                        searchPanel.Hide();

                    }//dt rows if end
                    else
                    {
                        MessageBox.Show("No Record Found");
                    }
                }
                else if (cbo_searchTYpe.Text == "Bill No")
                {
                    DataTable dt = blod.searchbybill2_for_tax(txt_searchText.Text, dateOne);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int inc = 0; inc < dt.Rows.Count; inc++)
                        {
                            int ac = dataGridView1.Rows.Add();
                            DateTime date_of_billing = Convert.ToDateTime(dt.Rows[inc]["date2"].ToString());
                            dataGridView1.Rows[inc].Cells["caldate"].Value = Convert.ToDateTime(dt.Rows[inc]["date_of_sale"].ToString());
                            dataGridView1.Rows[inc].Cells["calcardamount"].Value = dt.Rows[inc]["card_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["calcashamt"].Value = dt.Rows[inc]["cash_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["calpaymode"].Value = dt.Rows[inc]["payment_mode"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_kot_type"].Value = dt.Rows[inc]["kot_type"].ToString();
                          
                            dataGridView1.Rows[inc].Cells["cal_non_taxable_sales"].Value = (0.00).ToString();
                            string bill_no = dt.Rows[inc]["bill_no"].ToString();
                            dataGridView1.Rows[inc].Cells["calbill_no"].Value = bill_no;

                            dataGridView1.Rows[inc].Cells["cal_tax"].Value = dt.Rows[inc]["tax_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_service_charge"].Value = dt.Rows[inc]["service_charge"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_taxable_sales_amount"].Value = dt.Rows[inc]["taxable_amount"].ToString();
                            service_charger = dt.Select().Where(p => p["service_charge"] != DBNull.Value && Convert.ToDecimal(p["service_charge"]) > 0).Select(c => Convert.ToDecimal(c["service_charge"])).Sum();
                            sum_tax = dt.Select().Where(p => p["tax_amount"] != DBNull.Value && Convert.ToDecimal(p["tax_amount"]) > 0).Select(c => Convert.ToDecimal(c["tax_amount"])).Sum();

                            dataGridView1.Rows[inc].Cells["cal_total_sales"].Value = dt.Rows[inc]["grand_total"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dt.Rows[inc]["sales_type"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dt.Rows[inc]["table_no"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_discount"].Value = dt.Rows[inc]["discount"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_date2"].Value = dt.Rows[inc]["date2"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_customer_pan"].Value = dt.Rows[inc]["customer_no"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_customer_name"].Value = dt.Rows[inc]["customer_name"].ToString();
                            // grandtotal();
                            decimal sum_grand_total = dt.Select().Where(p => p["grand_total"] != DBNull.Value && Convert.ToInt32(p["grand_total"]) > 0).Select(c => Convert.ToDecimal(c["grand_total"])).Sum();
                            decimal sum_discount = dt.Select().Where(p => p["discount"] != DBNull.Value && Convert.ToInt32(p["discount"]) > 0).Select(c => Convert.ToDecimal(c["discount"])).Sum();

                            decimal sum_sub_total = dt.Select().Where(p => p["sub_total"] != DBNull.Value && Convert.ToInt32(p["sub_total"]) > 0).Select(c => Convert.ToDecimal(c["sub_total"])).Sum();
                            lblgrand_total.Text = Convert.ToString(sum_grand_total);
                            lbl_tax_sales_discount.Text = Convert.ToString(sum_discount);
                            lbl_taxable_sales.Text = Convert.ToString(sum_sub_total);
                            lbl_tax_amount.Text = sum_tax.ToString();
                            
                        }
                        backPanel.Show();
                        searchPanel.Hide();
                    }
                    else
                    {
                        MessageBox.Show("No Record Found");
                    }
                }
                else if (cbo_searchTYpe.Text == "ALL")
                {
                    DataTable dt = blod.searchALL_for_tax(dateOne, datetwo, fiscal_year);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int inc = 0; inc < dt.Rows.Count; inc++)
                        {
                            int ac = dataGridView1.Rows.Add();
                            DateTime date_of_billing = Convert.ToDateTime(dt.Rows[inc]["date2"].ToString());
                            dataGridView1.Rows[inc].Cells["caldate"].Value = Convert.ToDateTime(dt.Rows[inc]["date_of_sale"].ToString());
                            dataGridView1.Rows[inc].Cells["calcardamount"].Value = dt.Rows[inc]["card_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["calcashamt"].Value = dt.Rows[inc]["cash_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["calpaymode"].Value = dt.Rows[inc]["payment_mode"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_kot_type"].Value = dt.Rows[inc]["kot_type"].ToString();
                           
                            dataGridView1.Rows[inc].Cells["cal_non_taxable_sales"].Value = (0.00).ToString();
                            string bill_no = dt.Rows[inc]["bill_no"].ToString();
                            dataGridView1.Rows[inc].Cells["calbill_no"].Value = bill_no;

                            dataGridView1.Rows[inc].Cells["cal_tax"].Value = dt.Rows[inc]["tax_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_service_charge"].Value = dt.Rows[inc]["service_charge"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_taxable_sales_amount"].Value = dt.Rows[inc]["taxable_amount"].ToString();
                            service_charger = dt.Select().Where(p => p["service_charge"] != DBNull.Value && Convert.ToDecimal(p["service_charge"]) > 0).Select(c => Convert.ToDecimal(c["service_charge"])).Sum();
                            sum_tax = dt.Select().Where(p => p["tax_amount"] != DBNull.Value && Convert.ToDecimal(p["tax_amount"]) > 0).Select(c => Convert.ToDecimal(c["tax_amount"])).Sum();

                            dataGridView1.Rows[inc].Cells["cal_total_sales"].Value = dt.Rows[inc]["grand_total"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dt.Rows[inc]["sales_type"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dt.Rows[inc]["table_no"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_discount"].Value = dt.Rows[inc]["discount"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_date2"].Value = dt.Rows[inc]["date2"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_customer_pan"].Value = dt.Rows[inc]["customer_no"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_customer_name"].Value = dt.Rows[inc]["customer_name"].ToString();
                            // grandtotal();
                            decimal sum_grand_total = dt.Select().Where(p => p["grand_total"] != DBNull.Value && Convert.ToInt32(p["grand_total"]) > 0).Select(c => Convert.ToDecimal(c["grand_total"])).Sum();
                            decimal sum_discount = dt.Select().Where(p => p["discount"] != DBNull.Value && Convert.ToInt32(p["discount"]) > 0).Select(c => Convert.ToDecimal(c["discount"])).Sum();

                            decimal sum_sub_total = dt.Select().Where(p => p["sub_total"] != DBNull.Value && Convert.ToInt32(p["sub_total"]) > 0).Select(c => Convert.ToDecimal(c["sub_total"])).Sum();
                            lblgrand_total.Text = Convert.ToString(sum_grand_total);
                            lbl_tax_sales_discount.Text = Convert.ToString(sum_discount);
                            lbl_taxable_sales.Text = Convert.ToString(sum_sub_total);
                            lbl_tax_amount.Text = sum_tax.ToString();
                           
                        }
                        backPanel.Show();
                        searchPanel.Hide();
                    }
                    //dtm rows if end
                    else
                    {
                        MessageBox.Show("No  Record Found");
                    }
                }
                else if (cbo_searchTYpe.Text == "Payment Mode")
                {
                    DataTable dt = blod.searchpayment_mode_for_tax(txt_searchText.Text, dateOne, datetwo, fiscal_year);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int inc = 0; inc < dt.Rows.Count; inc++)
                        {
                            int ac = dataGridView1.Rows.Add();
                            DateTime date_of_billing = Convert.ToDateTime(dt.Rows[inc]["date2"].ToString());
                            dataGridView1.Rows[inc].Cells["caldate"].Value = Convert.ToDateTime(dt.Rows[inc]["date_of_sale"].ToString());
                            dataGridView1.Rows[inc].Cells["calcardamount"].Value = dt.Rows[inc]["card_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["calcashamt"].Value = dt.Rows[inc]["cash_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["calpaymode"].Value = dt.Rows[inc]["payment_mode"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_kot_type"].Value = dt.Rows[inc]["kot_type"].ToString();
                          
                            dataGridView1.Rows[inc].Cells["cal_non_taxable_sales"].Value = (0.00).ToString();
                            string bill_no = dt.Rows[inc]["bill_no"].ToString();
                            dataGridView1.Rows[inc].Cells["calbill_no"].Value = bill_no;

                            dataGridView1.Rows[inc].Cells["cal_tax"].Value = dt.Rows[inc]["tax_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_service_charge"].Value = dt.Rows[inc]["service_charge"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_taxable_sales_amount"].Value = dt.Rows[inc]["taxable_amount"].ToString();
                            service_charger = dt.Select().Where(p => p["service_charge"] != DBNull.Value && Convert.ToDecimal(p["service_charge"]) > 0).Select(c => Convert.ToDecimal(c["service_charge"])).Sum();
                            sum_tax = dt.Select().Where(p => p["tax_amount"] != DBNull.Value && Convert.ToDecimal(p["tax_amount"]) > 0).Select(c => Convert.ToDecimal(c["tax_amount"])).Sum();

                            dataGridView1.Rows[inc].Cells["cal_total_sales"].Value = dt.Rows[inc]["grand_total"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dt.Rows[inc]["sales_type"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dt.Rows[inc]["table_no"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_discount"].Value = dt.Rows[inc]["discount"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_date2"].Value = dt.Rows[inc]["date2"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_customer_pan"].Value = dt.Rows[inc]["customer_no"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_customer_name"].Value = dt.Rows[inc]["customer_name"].ToString();
                            // grandtotal();
                            decimal sum_grand_total = dt.Select().Where(p => p["grand_total"] != DBNull.Value && Convert.ToInt32(p["grand_total"]) > 0).Select(c => Convert.ToDecimal(c["grand_total"])).Sum();
                            decimal sum_discount = dt.Select().Where(p => p["discount"] != DBNull.Value && Convert.ToInt32(p["discount"]) > 0).Select(c => Convert.ToDecimal(c["discount"])).Sum();

                            decimal sum_sub_total = dt.Select().Where(p => p["sub_total"] != DBNull.Value && Convert.ToInt32(p["sub_total"]) > 0).Select(c => Convert.ToDecimal(c["sub_total"])).Sum();
                            lblgrand_total.Text = Convert.ToString(sum_grand_total);
                            lbl_tax_sales_discount.Text = Convert.ToString(sum_discount);
                            lbl_taxable_sales.Text = Convert.ToString(sum_sub_total);
                            lbl_tax_amount.Text = sum_tax.ToString();
                        }
                        backPanel.Show();
                        searchPanel.Hide();
                    }
                    else
                    {
                        MessageBox.Show("No Record Found");
                    }

                }
                else if (cbo_searchTYpe.Text == "Sales Type")
                {
                    DataTable dt = blod.searchsale_type_for_tax(txt_searchText.Text, dateOne, datetwo, fiscal_year);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int inc = 0; inc < dt.Rows.Count; inc++)
                        {
                            int ac = dataGridView1.Rows.Add();
                            DateTime date_of_billing = Convert.ToDateTime(dt.Rows[inc]["date2"].ToString());
                            dataGridView1.Rows[inc].Cells["caldate"].Value = Convert.ToDateTime(dt.Rows[inc]["date_of_sale"].ToString());
                            dataGridView1.Rows[inc].Cells["calcardamount"].Value = dt.Rows[inc]["card_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["calcashamt"].Value = dt.Rows[inc]["cash_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["calpaymode"].Value = dt.Rows[inc]["payment_mode"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_kot_type"].Value = dt.Rows[inc]["kot_type"].ToString();
                           
                            dataGridView1.Rows[inc].Cells["cal_non_taxable_sales"].Value = (0.00).ToString();
                            string bill_no = dt.Rows[inc]["bill_no"].ToString();
                            dataGridView1.Rows[inc].Cells["calbill_no"].Value = bill_no;

                            dataGridView1.Rows[inc].Cells["cal_tax"].Value = dt.Rows[inc]["tax_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_service_charge"].Value = dt.Rows[inc]["service_charge"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_taxable_sales_amount"].Value = dt.Rows[inc]["taxable_amount"].ToString();
                            service_charger = dt.Select().Where(p => p["service_charge"] != DBNull.Value && Convert.ToDecimal(p["service_charge"]) > 0).Select(c => Convert.ToDecimal(c["service_charge"])).Sum();
                            sum_tax = dt.Select().Where(p => p["tax_amount"] != DBNull.Value && Convert.ToDecimal(p["tax_amount"]) > 0).Select(c => Convert.ToDecimal(c["tax_amount"])).Sum();

                            dataGridView1.Rows[inc].Cells["cal_total_sales"].Value = dt.Rows[inc]["grand_total"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dt.Rows[inc]["sales_type"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dt.Rows[inc]["table_no"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_discount"].Value = dt.Rows[inc]["discount"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_date2"].Value = dt.Rows[inc]["date2"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_customer_pan"].Value = dt.Rows[inc]["customer_no"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_customer_name"].Value = dt.Rows[inc]["customer_name"].ToString();
                            // grandtotal();
                            decimal sum_grand_total = dt.Select().Where(p => p["grand_total"] != DBNull.Value && Convert.ToInt32(p["grand_total"]) > 0).Select(c => Convert.ToDecimal(c["grand_total"])).Sum();
                            decimal sum_discount = dt.Select().Where(p => p["discount"] != DBNull.Value && Convert.ToInt32(p["discount"]) > 0).Select(c => Convert.ToDecimal(c["discount"])).Sum();

                            decimal sum_sub_total = dt.Select().Where(p => p["sub_total"] != DBNull.Value && Convert.ToInt32(p["sub_total"]) > 0).Select(c => Convert.ToDecimal(c["sub_total"])).Sum();
                            lblgrand_total.Text = Convert.ToString(sum_grand_total);
                            lbl_tax_sales_discount.Text = Convert.ToString(sum_discount);
                            lbl_taxable_sales.Text = Convert.ToString(sum_sub_total);
                            lbl_tax_amount.Text = sum_tax.ToString();
                        }
                      
                        backPanel.Show();
                        searchPanel.Hide();

                    }
                    else
                    {
                        MessageBox.Show("No Record Found");
                    }

                }
                else if (cbo_searchTYpe.Text == "User")
                {
                    DataTable dt = blod.searchsale_by_user_for_tax(txt_searchText.Text, dateOne, datetwo, fiscal_year);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int inc = 0; inc < dt.Rows.Count; inc++)
                        {
                            int ac = dataGridView1.Rows.Add();
                            DateTime date_of_billing = Convert.ToDateTime(dt.Rows[inc]["date2"].ToString());
                            dataGridView1.Rows[inc].Cells["caldate"].Value = Convert.ToDateTime(dt.Rows[inc]["date_of_sale"].ToString());
                            dataGridView1.Rows[inc].Cells["calcardamount"].Value = dt.Rows[inc]["card_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["calcashamt"].Value = dt.Rows[inc]["cash_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["calpaymode"].Value = dt.Rows[inc]["payment_mode"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_kot_type"].Value = dt.Rows[inc]["kot_type"].ToString();
                           
                            dataGridView1.Rows[inc].Cells["cal_non_taxable_sales"].Value = (0.00).ToString();
                            string bill_no = dt.Rows[inc]["bill_no"].ToString();
                            dataGridView1.Rows[inc].Cells["calbill_no"].Value = bill_no;

                            dataGridView1.Rows[inc].Cells["cal_tax"].Value = dt.Rows[inc]["tax_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_service_charge"].Value = dt.Rows[inc]["service_charge"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_taxable_sales_amount"].Value = dt.Rows[inc]["taxable_amount"].ToString();
                            service_charger = dt.Select().Where(p => p["service_charge"] != DBNull.Value && Convert.ToDecimal(p["service_charge"]) > 0).Select(c => Convert.ToDecimal(c["service_charge"])).Sum();
                            sum_tax = dt.Select().Where(p => p["tax_amount"] != DBNull.Value && Convert.ToDecimal(p["tax_amount"]) > 0).Select(c => Convert.ToDecimal(c["tax_amount"])).Sum();

                            dataGridView1.Rows[inc].Cells["cal_total_sales"].Value = dt.Rows[inc]["grand_total"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dt.Rows[inc]["sales_type"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dt.Rows[inc]["table_no"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_discount"].Value = dt.Rows[inc]["discount"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_date2"].Value = dt.Rows[inc]["date2"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_customer_pan"].Value = dt.Rows[inc]["customer_no"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_customer_name"].Value = dt.Rows[inc]["customer_name"].ToString();
                            // grandtotal();
                            decimal sum_grand_total = dt.Select().Where(p => p["grand_total"] != DBNull.Value && Convert.ToInt32(p["grand_total"]) > 0).Select(c => Convert.ToDecimal(c["grand_total"])).Sum();
                            decimal sum_discount = dt.Select().Where(p => p["discount"] != DBNull.Value && Convert.ToInt32(p["discount"]) > 0).Select(c => Convert.ToDecimal(c["discount"])).Sum();

                            decimal sum_sub_total = dt.Select().Where(p => p["sub_total"] != DBNull.Value && Convert.ToInt32(p["sub_total"]) > 0).Select(c => Convert.ToDecimal(c["sub_total"])).Sum();
                            lblgrand_total.Text = Convert.ToString(sum_grand_total);
                            lbl_tax_sales_discount.Text = Convert.ToString(sum_discount);
                            lbl_taxable_sales.Text = Convert.ToString(sum_sub_total);
                            lbl_tax_amount.Text = sum_tax.ToString();
                           
                        }
                        backPanel.Show();
                        searchPanel.Hide();
                    }
                    else
                    {
                        MessageBox.Show("No Record Found");
                    }

                }
                else if (cbo_searchTYpe.Text == "KOT Type")
                {
                    DataTable dt = blod.searchsale_by_user_for_kot_type(txt_searchText.Text, dateOne, datetwo, fiscal_year);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int inc = 0; inc < dt.Rows.Count; inc++)
                        {
                            int ac = dataGridView1.Rows.Add();
                            DateTime date_of_billing = Convert.ToDateTime(dt.Rows[inc]["date2"].ToString());
                            dataGridView1.Rows[inc].Cells["caldate"].Value = Convert.ToDateTime(dt.Rows[inc]["date_of_sale"].ToString());
                            dataGridView1.Rows[inc].Cells["calcardamount"].Value = dt.Rows[inc]["card_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["calcashamt"].Value = dt.Rows[inc]["cash_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["calpaymode"].Value = dt.Rows[inc]["payment_mode"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_kot_type"].Value = dt.Rows[inc]["kot_type"].ToString();
                           
                            dataGridView1.Rows[inc].Cells["cal_non_taxable_sales"].Value = (0.00).ToString();
                            string bill_no = dt.Rows[inc]["bill_no"].ToString();
                            dataGridView1.Rows[inc].Cells["calbill_no"].Value = bill_no;

                            dataGridView1.Rows[inc].Cells["cal_tax"].Value = dt.Rows[inc]["tax_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_service_charge"].Value = dt.Rows[inc]["service_charge"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_taxable_sales_amount"].Value = dt.Rows[inc]["taxable_amount"].ToString();
                            service_charger = dt.Select().Where(p => p["service_charge"] != DBNull.Value && Convert.ToDecimal(p["service_charge"]) > 0).Select(c => Convert.ToDecimal(c["service_charge"])).Sum();
                            sum_tax = dt.Select().Where(p => p["tax_amount"] != DBNull.Value && Convert.ToDecimal(p["tax_amount"]) > 0).Select(c => Convert.ToDecimal(c["tax_amount"])).Sum();

                            dataGridView1.Rows[inc].Cells["cal_total_sales"].Value = dt.Rows[inc]["grand_total"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dt.Rows[inc]["sales_type"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dt.Rows[inc]["table_no"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_discount"].Value = dt.Rows[inc]["discount"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_date2"].Value = dt.Rows[inc]["date2"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_customer_pan"].Value = dt.Rows[inc]["customer_no"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_customer_name"].Value = dt.Rows[inc]["customer_name"].ToString();
                            // grandtotal();
                            decimal sum_grand_total = dt.Select().Where(p => p["grand_total"] != DBNull.Value && Convert.ToInt32(p["grand_total"]) > 0).Select(c => Convert.ToDecimal(c["grand_total"])).Sum();
                            decimal sum_discount = dt.Select().Where(p => p["discount"] != DBNull.Value && Convert.ToInt32(p["discount"]) > 0).Select(c => Convert.ToDecimal(c["discount"])).Sum();

                            decimal sum_sub_total = dt.Select().Where(p => p["sub_total"] != DBNull.Value && Convert.ToInt32(p["sub_total"]) > 0).Select(c => Convert.ToDecimal(c["sub_total"])).Sum();
                            lblgrand_total.Text = Convert.ToString(sum_grand_total);
                            lbl_tax_sales_discount.Text = Convert.ToString(sum_discount);
                            lbl_taxable_sales.Text = Convert.ToString(sum_sub_total);
                            lbl_tax_amount.Text = sum_tax.ToString();
                        }
                        backPanel.Show();
                        searchPanel.Hide();

                    }
                    else
                    {
                        MessageBox.Show("No Record Found");
                    }

                }
                user_log_insert();
            }
        }
        public void user_log_insert()
        {
            DateTime date = Convert.ToDateTime(DateTime.Now.ToString());
            BLL_user_log bulg = new BLL_user_log();
            string user_name_log = Login.sendtext;
            string day = DateTime.Now.ToString("ddd");
            DataTable dt = bulg.getall_user_log(user_name_log,day, "View Restaurant Sales Tax Report");

            if(dt.Rows.Count==0)
            {
                int abc = bulg.createuserlog(user_name_log, "View Restaurant Sales Tax Report", date, day);
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
            }
            else if (cbo_searchTYpe.Text == "Category")
            {

                category();
            }
            else if (cbo_searchTYpe.Text == "Bill No")
            {
                Billno();
            }

            else if (cbo_searchTYpe.Text == "ALL")
            {
                clearcombo(txt_searchText);
                txt_searchText.Text = "ALL";
            }
            else if (cbo_searchTYpe.Text == "Payment Mode")
            {
                clearcombo(txt_searchText);
                List<string> mylist = new List<string>();
                mylist.Add("Cash");
                mylist.Add("Card");
                mylist.Add("Cheque");
                mylist.Add("Zomato");
                mylist.Add("Credit");
                txt_searchText.DataSource = mylist;
            }
            else if (cbo_searchTYpe.Text == "Sales Type")
            {
                clearcombo(txt_searchText);
                List<string> mylist = new List<string>();
                mylist.Add("TS");
                mylist.Add("TA");
                mylist.Add("HD");
                txt_searchText.DataSource = mylist;

            }
            else if (cbo_searchTYpe.Text == "User")
            {
                clearcombo(txt_searchText);
                User();

            }
            else if (cbo_searchTYpe.Text == "KOT Type")
            {
                clearcombo(txt_searchText);
                List<string> mylist = new List<string>();
                mylist.Add("K1");
                mylist.Add("K2");
                mylist.Add("B1");
                txt_searchText.DataSource = mylist;

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
            //    if (e.ColumnIndex == dataGridView1.Columns["cal_delete"].Index && e.RowIndex >= 0)
            //    {
            //        DialogResult dialogResult = MessageBox.Show("Are You Sure Want To Delete This Data", "Record Delete", MessageBoxButtons.YesNo);
            //        if (dialogResult == DialogResult.Yes)
            //        {
            //            DataTable dt = blu.getusername(user_name);
            //            if (dt.Rows[0]["user_type"].ToString() == "Admin" || dt.Rows[0]["user_type"].ToString() == "admin")
            //            {
            //                int delete_by_id = blres.delete_sale_by_id(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_sales_id"].Value));
            //                if (delete_by_id > 0)
            //                {
            //                    string item_name = dataGridView1.CurrentRow.Cells["calitem"].Value.ToString();
            //                    int quantity = Convert.ToInt32(dataGridView1.CurrentRow.Cells["calquantity"].Value);
            //                    decimal total = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["caltotal"].Value);
            //                    DateTime date_time = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["caldate"].Value);
            //                    decimal card_amount = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["calcardamount"].Value);
            //                    decimal cash_amount = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["calcashamt"].Value);
            //                    string payment_mode = dataGridView1.CurrentRow.Cells["calpaymode"].Value.ToString();
            //                    string cashier_name = dataGridView1.CurrentRow.Cells["calcashier_name"].Value.ToString();
            //                    int bill_no = Convert.ToInt32(dataGridView1.CurrentRow.Cells["calbill_no"].Value);
            //                    decimal grand_total = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_grand_total"].Value);
            //                    string sales_type = dataGridView1.CurrentRow.Cells["cal_sales_type"].Value.ToString();
            //                    int sale_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_sales_id"].Value);
            //                    decimal sub_total = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_sub_total"].Value);
            //                    decimal cost = Convert.ToDecimal("0");
            //                    decimal discount = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_discount"].Value);
            //                    string category_name = dataGridView1.CurrentRow.Cells["cal_category_name"].Value.ToString();
            //                    string table_no = dataGridView1.CurrentRow.Cells["cal_table_no"].Value.ToString();
            //                    DateTime date2 = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["cal_date2"].Value);
            //                    DateTime date_of_delete = Convert.ToDateTime(DateTime.Now.ToString());
            //                    int b = blres.inser_delete_record(sale_id, bill_no, date_time, cashier_name, table_no, "NULL", "NULL", item_name, quantity, cost, total, payment_mode, "NULL", sub_total, discount, cash_amount, card_amount, grand_total, category_name, sales_type, date_of_delete, user_name);
            //                    MessageBox.Show("Data Has Been Deleted");
            //                    dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
            //                    grandtotal();
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("You Have No Permission To Delete This Data");
            //            }

            //        }
            // }
            if ((e.ColumnIndex == dataGridView1.Columns["cal_print"].Index && e.RowIndex >= 0))
            {
                bill_no_print = dataGridView1.CurrentRow.Cells["calbill_no"].Value.ToString();
                int insert_abc = blp_re.insert_bill_reprint(bill_no_print);
                DataTable dt_prt = blpst.getalldata();
                if (dt_prt.Rows[0]["bill_printer"].ToString() == "80")
                {
                    bill_printing_for_80();
                }
                else
                {
                    bill_printing_for_58();
                }
            }
        }
        BillPrinting blp = new BillPrinting();
        BillPrinting80 blp_80 = new BillPrinting80();
        bool save_after_print;
        public void bill_printing_for_58()
        {
           
            blp.bill_no = bill_no_print;
            blp.cashier = dataGridView1.CurrentRow.Cells["calcashier_name"].Value.ToString();
            blp.cash_amount = dataGridView1.CurrentRow.Cells["calcashamt"].Value.ToString();
            blp.discount = dataGridView1.CurrentRow.Cells["cal_discount"].Value.ToString();
            blp.grand_total = dataGridView1.CurrentRow.Cells["cal_grand_total"].Value.ToString();
            blp.sub_total = dataGridView1.CurrentRow.Cells["cal_sub_total"].Value.ToString();
            blp.table_no = dataGridView1.CurrentRow.Cells["cal_table_no"].Value.ToString();
            DataTable dt_bil = blbt.get_all_tax_by_bill_no(bill_no, Convert.ToDateTime(dataGridView1.CurrentRow.Cells["cal_date2"].Value.ToString()));
            blp.print_again = true;
            if (dt_bil.Rows.Count > 0)
            {
                blp.tax_amount = dt_bil.Rows[0]["tax_amount"].ToString();
                blp.service_charge = dt_bil.Rows[0]["service_charge"].ToString();
            }
            DataTable dt = blod.searchbybill2(bill_no);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                blp.datagridview_item_name.Add(dt.Rows[i]["item_name"].ToString());
                blp.datagridview_item_price.Add(dt.Rows[i]["cost"].ToString());
                blp.datagridview_total.Add(dt.Rows[i]["total"].ToString());
                blp.datagridview_quantity.Add(dt.Rows[i]["quantity"].ToString());
            }
            blp.printtobill();
            save_after_print = blp.save_after_print;

        }
        public void bill_printing_for_80()
        {
            string bill_no = dataGridView1.CurrentRow.Cells["calbill_no"].Value.ToString();
            blp_80.bill_no = bill_no;
            blp_80.cashier = dataGridView1.CurrentRow.Cells["calcashier_name"].Value.ToString();
            blp_80.cash_amount = dataGridView1.CurrentRow.Cells["calcashamt"].Value.ToString();
            blp_80.discount = dataGridView1.CurrentRow.Cells["cal_discount"].Value.ToString();
            blp_80.grand_total = dataGridView1.CurrentRow.Cells["cal_grand_total"].Value.ToString();
            blp_80.sub_total = dataGridView1.CurrentRow.Cells["cal_sub_total"].Value.ToString();
            blp_80.table_no = dataGridView1.CurrentRow.Cells["cal_table_no"].Value.ToString();
            blp_80.print_again = true;
            blp_80.customer_PAN_no = dataGridView1.CurrentRow.Cells["cal_customer_pan"].Value.ToString();
            blp_80.customer_name = dataGridView1.CurrentRow.Cells["cal_customer_name"].Value.ToString();
            DataTable dt_bil = blbt.get_all_tax_by_bill_no(bill_no, Convert.ToDateTime(dataGridView1.CurrentRow.Cells["cal_date2"].Value.ToString()));
            if (dt_bil.Rows.Count > 0)
            {
                blp_80.tax_amount = dt_bil.Rows[0]["tax_amount"].ToString();
                blp_80.service_charge = dt_bil.Rows[0]["service_charge"].ToString();
            }
            DataTable dt = blod.searchbybill2(bill_no);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                blp_80.datagridview_item_name.Add(dt.Rows[i]["item_name"].ToString());
                blp_80.datagridview_item_price.Add(dt.Rows[i]["cost"].ToString());
                blp_80.datagridview_total.Add(dt.Rows[i]["total"].ToString());
                blp_80.datagridview_quantity.Add(dt.Rows[i]["quantity"].ToString());
            }
            blp_80.printtobill();
            save_after_print = blp_80.save_after_print;
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
            dt_xml.TableName = "Demo Restaurant";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\Restaurant Tax Sales ReportXML\\";

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
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\Restaurant Tax Sales Report Text\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
          
            TextWriter sw = new StreamWriter(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "SalesTaxReport.txt");
            int rowcount = dataGridView1.Rows.Count;
            DataTable dt = blu.checkbusiness();
            if (dt.Rows.Count > 0)
            {
                Business_Name = dt.Rows[0]["business_name"].ToString();
                pan_no = dt.Rows[0]["pan_no"].ToString();
            }
            sw.WriteLine("                         "+Business_Name+"            ");
            sw.WriteLine("                       Pan No:  " + pan_no + "            ");
            sw.WriteLine( "Date From: " + dtp_from.Text + "            Date To: "+dtp_to.Text);
            sw.WriteLine("          ");
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
    }
}

