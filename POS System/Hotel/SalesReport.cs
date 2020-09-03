using BLLS;
using BLLS.Hotel;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System
{
    public partial class SalesReport : UserControl
    {
        public SalesReport()
        {
            InitializeComponent();
        }
        BLL_Report bllreport = new BLL_Report();
        BLL_Billing_Tax blbt = new BLL_Billing_Tax();
        BLLCategory blcat = new BLLCategory();
        BLLProduct blpro = new BLLProduct();
        BLLOrder blod = new BLLOrder();
        DataTable dtLoad = new DataTable();
        BLLUser blu = new BLLUser();
        private void SalesReport_Load(object sender, EventArgs e)
        {
            dtp_from.Value = DateTime.Now;
            dtp_to.Value = DateTime.Now;
            searchPanel.Show();
            backPanel.Hide();
            cbo_searchTYpe.SelectedIndex = 0;
           // DataGridViewLoad();
        }
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
        decimal cost=0;
        double grand_total=0;
        double sum=0;
        double tax = 0;
        double tax_amount = 0;
        public void grandtotal()
        {
            bill_no = "0";

            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                    if ((dataGridView1.Rows[x].Cells["cal_grand_total"].Value == null))
                    {
                       sum+= 0;
                    }
                    else
                    {
                        sum += Convert.ToDouble(dataGridView1.Rows[x].Cells["cal_grand_total"].Value.ToString());
                    }

                if ((dataGridView1.Rows[x].Cells["cal_tax"].Value == null))
                {
                    tax += 0;
                }
                else
                {
                    tax += Convert.ToDouble(dataGridView1.Rows[x].Cells["cal_tax"].Value.ToString());
                }

                grand_total = sum;
                tax_amount = tax;
                    cost = Convert.ToDecimal(dataGridView1.Rows[x].Cells["cal_sub_total"].Value.ToString());
                }
            
            lbl_grandtotal.Text = grand_total.ToString();
            lbl_cost.Text = cost.ToString();
            lbl_tax.Text = tax.ToString();
        }
        string bill_no;
      //  string colunm_name;
     
        private void btn_show_Click(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text == "ALL")
            {
                DataTable dtLoad= bllreport.GetSales(Convert.ToDateTime(dtp_from.Text), Convert.ToDateTime(dtp_to.Text));
                dt_report = bllreport.GetSales(Convert.ToDateTime(dtp_from.Text), Convert.ToDateTime(dtp_to.Text));
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
                      
                      //  dataGridView1.Rows[inc].Cells["calpaymode"].Value = dtLoad.Rows[inc]["payment_mode"].ToString();
                   
                        DateTime date_of_billing = Convert.ToDateTime(dtLoad.Rows[inc]["date2"].ToString());
                        if (bill_no != dtLoad.Rows[inc]["bill_no"].ToString())
                        {
                            dataGridView1.Rows[inc].Cells["cal_grand_total"].Value = dtLoad.Rows[inc]["grand_total"].ToString();
                            string payment_mode = dtLoad.Rows[inc]["payment_mode"].ToString();
                            dataGridView1.Rows[inc].Cells["calpaymode"].Value = payment_mode;
                      
                            dataGridView1.Rows[inc].Cells["calpaymode"].Value = dtLoad.Rows[inc]["payment_mode"].ToString();
                            dataGridView1.Rows[inc].Cells["calcardamount"].Value = dtLoad.Rows[inc]["card_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["calcashamt"].Value = dtLoad.Rows[inc]["cash_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["calcashier_name"].Value = dtLoad.Rows[inc]["cashier_name"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_tax"].Value = dtLoad.Rows[inc]["tax_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_service_charge"].Value = dtLoad.Rows[inc]["service_charge"].ToString();
                         

                        }
                        bill_no = dtLoad.Rows[inc]["bill_no"].ToString();
                        dataGridView1.Rows[inc].Cells["calbill_no"].Value = bill_no;

                        dataGridView1.Rows[inc].Cells["caldate"].Value = Convert.ToDateTime(dtLoad.Rows[inc]["date_of_sale"].ToString());

                        dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dtLoad.Rows[inc]["sales_type"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_sales_id"].Value = dtLoad.Rows[inc]["rest_sale_id"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dtLoad.Rows[inc]["table_no"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_category_name"].Value = dtLoad.Rows[inc]["category_name"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_discount"].Value = dtLoad.Rows[inc]["discount"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_sub_total"].Value = dtLoad.Rows[inc]["sub_total"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_date2"].Value = dtLoad.Rows[inc]["date2"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_customer_pan"].Value = dtLoad.Rows[inc]["customer_no"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_customer_name"].Value = dtLoad.Rows[inc]["customer_name"].ToString();

                    }
                    grandtotal();
                    backPanel.Show();
                    searchPanel.Hide();
                }
          }
            else if (cbo_searchTYpe.Text=="Category")
            {
                DataTable dtLoad = bllreport.SearchCategory(txt_searchText.Text,Convert.ToDateTime(dtp_from.Text), Convert.ToDateTime(dtp_to.Text));
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
                        dataGridView1.Rows[inc].Cells["cal_grand_total"].Value = dtLoad.Rows[inc]["grand_total"].ToString();
                        dataGridView1.Rows[inc].Cells["calpaymode"].Value = dtLoad.Rows[inc]["payment_mode"].ToString();
                        dataGridView1.Rows[inc].Cells["calcardamount"].Value = dtLoad.Rows[inc]["card_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["calcashamt"].Value = dtLoad.Rows[inc]["cash_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["calcashier_name"].Value = dtLoad.Rows[inc]["cashier_name"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_tax"].Value = dtLoad.Rows[inc]["tax_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_service_charge"].Value = dtLoad.Rows[inc]["service_charge"].ToString();
                        DateTime date_of_billing = Convert.ToDateTime(dtLoad.Rows[inc]["date2"].ToString());
                         bill_no = dtLoad.Rows[inc]["bill_no"].ToString();
                        dataGridView1.Rows[inc].Cells["calbill_no"].Value = bill_no;

                        dataGridView1.Rows[inc].Cells["caldate"].Value = Convert.ToDateTime(dtLoad.Rows[inc]["date_of_sale"].ToString());

                        dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dtLoad.Rows[inc]["sales_type"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_sales_id"].Value = dtLoad.Rows[inc]["rest_sale_id"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dtLoad.Rows[inc]["table_no"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_category_name"].Value = dtLoad.Rows[inc]["category_name"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_discount"].Value = dtLoad.Rows[inc]["discount"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_sub_total"].Value = dtLoad.Rows[inc]["sub_total"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_date2"].Value = dtLoad.Rows[inc]["date2"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_customer_pan"].Value = dtLoad.Rows[inc]["customer_no"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_customer_name"].Value = dtLoad.Rows[inc]["customer_name"].ToString();

                    }
                    grandtotal();
                    backPanel.Show();
                    searchPanel.Hide();
                }
            }
            else
            {
                DataTable dtLoad = bllreport.SearchItem(txt_searchText.Text,Convert.ToDateTime(dtp_from.Text), Convert.ToDateTime(dtp_to.Text));
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
                        dataGridView1.Rows[inc].Cells["cal_grand_total"].Value = dtLoad.Rows[inc]["grand_total"].ToString();
                        dataGridView1.Rows[inc].Cells["calpaymode"].Value = dtLoad.Rows[inc]["payment_mode"].ToString();
                        dataGridView1.Rows[inc].Cells["calcardamount"].Value = dtLoad.Rows[inc]["card_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["calcashamt"].Value = dtLoad.Rows[inc]["cash_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["calcashier_name"].Value = dtLoad.Rows[inc]["cashier_name"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_tax"].Value = dtLoad.Rows[inc]["tax_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_service_charge"].Value = dtLoad.Rows[inc]["service_charge"].ToString();
                        DateTime date_of_billing = Convert.ToDateTime(dtLoad.Rows[inc]["date2"].ToString());
                        //DataTable dt_bill = blbt.get_all_tax_by_bill_no(dtLoad.Rows[inc]["bill_no"].ToString(), date_of_billing);
                        //if (dt_bill.Rows.Count > 0)
                        //{
                        //    dataGridView1.Rows[inc].Cells["cal_tax"].Value = dt_bill.Rows[0]["tax_amount"].ToString();
                        //    dataGridView1.Rows[inc].Cells["cal_service_charge"].Value = dt_bill.Rows[0]["service_charge"].ToString();
                        //}

                        bill_no = dtLoad.Rows[inc]["bill_no"].ToString();
                        dataGridView1.Rows[inc].Cells["calbill_no"].Value = bill_no;

                        dataGridView1.Rows[inc].Cells["caldate"].Value = Convert.ToDateTime(dtLoad.Rows[inc]["date_of_sale"].ToString());

                        dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dtLoad.Rows[inc]["sales_type"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_sales_id"].Value = dtLoad.Rows[inc]["rest_sale_id"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dtLoad.Rows[inc]["table_no"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_category_name"].Value = dtLoad.Rows[inc]["category_name"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_discount"].Value = dtLoad.Rows[inc]["discount"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_sub_total"].Value = dtLoad.Rows[inc]["sub_total"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_date2"].Value = dtLoad.Rows[inc]["date2"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_customer_pan"].Value = dtLoad.Rows[inc]["customer_no"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_customer_name"].Value = dtLoad.Rows[inc]["customer_name"].ToString();

                    }
                    grandtotal();
                    backPanel.Show();
                    searchPanel.Hide();
                }
            }

        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            searchPanel.Show();
            backPanel.Hide();
        }

        private void cbo_searchTYpe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text=="ALL")
            {
                txt_searchText.Text = "ALL";
            }
            else if (cbo_searchTYpe.Text == "Category")
            {
                category();
            }
            else if (cbo_searchTYpe.Text == "Item")
            {
                products();
            }

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
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount - 8);
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

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\HotelSalesReport\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string Datename = DateTime.Now.ToString("dd-mm-yyyy hh");
            using (FileStream stream = new FileStream(folderPath + "HotelSalesReport " + Datename + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                pdfDoc.Header = new HeaderFooter(new Phrase("Header Text"), false);
                pdfDoc.Open();
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph pheading = new Paragraph("Hotel Sales Report");
                Paragraph pheading_business_name = new Paragraph(Business_Name);
                Paragraph pheading_pan_no = new Paragraph("Pan No :" + pan_no);
                Paragraph pheadingDate = new Paragraph("From:     " + dtp_from.Text + "                                        " + "To:      " + dtp_to.Text);
                pheading.Alignment = Element.TITLE;
                pheading_business_name.Alignment = Element.TITLE;
                pheading_pan_no.Alignment = Element.TITLE;
                pheading.Alignment = Element.TITLE;
                Paragraph pheading_space = new Paragraph("   ");
                Paragraph p = new Paragraph();
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

        private void backPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        DataTable dt_report = new DataTable();
       // string exportBillNo;
        private void btn_excel_Click(object sender, EventArgs e)
        {
            //ExporyToExcel(btn_export_toexcel, "ExportedUserDetail");
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index <= 10)
                {
                    dt.Columns.Add(column.HeaderText);
                }
            }
            string data;
            //Adding the Rows
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex <= 10)
                    {
                        if (cell.Value == null)
                        {
                            data = "0.00";
                        }
                        else
                        {
                            data = cell.Value.ToString();
                        }

                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = data;
                    }
                }
            }

            //Exporting to Excel
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\HotelSalesReport Excel\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Hotel Sales Record");
                wb.SaveAs(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "HotelSales.xlsx");
                MessageBox.Show("Your Hotel Sales excel report has been export to document", "Hotel Sales Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
