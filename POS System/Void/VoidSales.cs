using BLLS;
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
    public partial class VoidSales : UserControl
    {
        public VoidSales()
        {
            InitializeComponent();
        }
        BLLRestSell order = new BLLRestSell();
        BLL_Billing_Tax blbt = new BLL_Billing_Tax();
        BLLUser blu = new BLLUser();
        DateTime today = Convert.ToDateTime(DateTime.Now.Date.ToShortDateString());
        private void VoidSales_Load(object sender, EventArgs e)
        {
            cmb_search.SelectedIndex = 0;
          
            searchPanel.Show();
            Backpanel.Hide();
            dtp_from.Text = Convert.ToString(today);
            dtp_to.Text = Convert.ToString(today);
        }
        public void LoadVoidName()
        {
            DataTable dt = blu.getalluser();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["user_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cmb_find.DataSource = dt;
                cmb_find.DisplayMember = "user_name";
                cmb_find.ValueMember = "user_name";
            }
        }
        public void LoadVoidBill()
        {
            DataTable dt = order.GetVoidBill();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["void_bill_no"] = ("0000");
                dt.Rows.InsertAt(dr, 0);
                cmb_find.DataSource = dt;
                cmb_find.DisplayMember = "new_bill_no";
                cmb_find.ValueMember = "void_id";
            }
        }
        decimal tax_amount = 0;
        decimal service_charge_amount = 0;
        decimal subtotal = 0;
        decimal discount = 0;
        decimal tax_sale_amount_with_discount = 0;
        decimal net_sales_with_service = 0;
       
         

        public void grandtotal()
        {
            double grandtotal = 0;
           // double grand_total = 0;
            double sales_amount = 0;
            double service_charge = 0;
           // double tax = 0;
        
            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {

                grandtotal += Convert.ToDouble(dataGridView1.Rows[x].Cells["cal_grand_total"].Value.ToString());
                sales_amount += Convert.ToDouble(dataGridView1.Rows[x].Cells["cal_total_sales_amount"].Value.ToString());
                service_charge += Convert.ToDouble(dataGridView1.Rows[x].Cells["cal_service_charge"].Value.ToString());
            }
        
             lbl_grandtotal.Text = grandtotal.ToString();
            lbl_service_charge.Text = service_charge.ToString();
            lbl_sales_amount.Text = sales_amount.ToString();
        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            Backpanel.Hide();
            searchPanel.Show();
        }

        private void btn_show_Click(object sender, EventArgs e)
        {

            string dateOne = Convert.ToDateTime(dtp_from.Text).ToShortDateString();
            string datetwo = Convert.ToDateTime(dtp_to.Text).ToShortDateString();
            if (cmb_search.Text == "Void Bill No")
            {
                DataTable dt = order.SearchBy(cmb_find.Text);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int inc = 0; inc < dt.Rows.Count; inc++)
                    {
                        int ac = dataGridView1.Rows.Add();

                        DateTime date_of_sales = Convert.ToDateTime(dt.Rows[inc]["Date2"].ToString());
                        dataGridView1.Rows[inc].Cells["cal_date2"].Value = date_of_sales;
                        dataGridView1.Rows[inc].Cells["caldate"].Value = dt.Rows[inc]["void_date"].ToString();
                        string bill_nos = dt.Rows[inc]["bill_no"].ToString();
                        dataGridView1.Rows[inc].Cells["calbill_no"].Value = bill_nos;
                        dataGridView1.Rows[inc].Cells["calcashamt"].Value = dt.Rows[inc]["cash_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["calpaymode"].Value = dt.Rows[inc]["payment_mode"].ToString();

                        subtotal = Convert.ToDecimal(dt.Rows[inc]["sub_total"].ToString());

                        dataGridView1.Rows[inc].Cells["cal_sub_total"].Value = subtotal.ToString();
                        discount = Convert.ToDecimal(dt.Rows[inc]["discount"].ToString());
                        dataGridView1.Rows[inc].Cells["cal_discount"].Value = discount.ToString();
                        tax_sale_amount_with_discount = subtotal - discount;
                        dataGridView1.Rows[inc].Cells["cal_total_sales_amount"].Value = tax_sale_amount_with_discount.ToString();
                       
                            tax_amount = Convert.ToDecimal(dt.Rows[inc]["tax_amount"].ToString());
                            service_charge_amount = Convert.ToDecimal(dt.Rows[inc]["service_charge"].ToString());
                            dataGridView1.Rows[inc].Cells["cal_tax"].Value = tax_amount.ToString();
                            dataGridView1.Rows[inc].Cells["cal_service_charge"].Value = service_charge_amount.ToString();

                        string fiscal_year = dt.Rows[inc]["fiscal_year"].ToString();
                        DataTable dtvoid = order.GetBillVoid(bill_nos, fiscal_year);
                        if (dtvoid.Rows.Count > 0)
                        {
                            dataGridView1.Rows[inc].Cells["col_voidbill"].Value = dtvoid.Rows[0]["void_bill_no"].ToString();
                            dataGridView1.Rows[inc].Cells["col_voiduser"].Value = dtvoid.Rows[0]["void_user"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_date2"].Value = dtvoid.Rows[0]["void_date"].ToString();
                        }
                        net_sales_with_service = tax_sale_amount_with_discount + service_charge_amount;
                        dataGridView1.Rows[inc].Cells["cal_net_sales"].Value = net_sales_with_service;
                        dataGridView1.Rows[inc].Cells["cal_grand_total"].Value = dt.Rows[inc]["grand_total"].ToString();
                        // dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dt.Rows[inc]["sales_type"].ToString();
                        // dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dt.Rows[inc]["table_no"].ToString();

                        dataGridView1.Rows[inc].Cells["cal_date2"].Value = dt.Rows[inc]["date2"].ToString();

                    }
                    //dataGridView1.ClearSelection();
                    Backpanel.Show();
                    searchPanel.Hide();
                }
            }
            else if (cmb_search.Text == "ALL")
            {
                DataTable dt1 = order.GetAllVoids(Convert.ToDateTime(dateOne), Convert.ToDateTime(datetwo));
                if (dt1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int inc = 0; inc < dt1.Rows.Count; inc++)
                    {
                        int ac = dataGridView1.Rows.Add();

                        DateTime date_of_sales = Convert.ToDateTime(dt1.Rows[inc]["Date2"].ToString());
                      
                        dataGridView1.Rows[inc].Cells["caldate"].Value = dt1.Rows[inc]["void_date"].ToString();
                        string bill_nos = dt1.Rows[inc]["bill_no"].ToString();
                        dataGridView1.Rows[inc].Cells["calbill_no"].Value = bill_nos;
                        dataGridView1.Rows[inc].Cells["calcashamt"].Value = dt1.Rows[inc]["cash_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["calpaymode"].Value = dt1.Rows[inc]["payment_mode"].ToString();

                        subtotal = Convert.ToDecimal(dt1.Rows[inc]["sub_total"].ToString());

                        dataGridView1.Rows[inc].Cells["cal_sub_total"].Value = subtotal.ToString();
                        discount = Convert.ToDecimal(dt1.Rows[inc]["discount"].ToString());
                        dataGridView1.Rows[inc].Cells["cal_discount"].Value = discount.ToString();
                        tax_sale_amount_with_discount = subtotal - discount;
                        dataGridView1.Rows[inc].Cells["cal_total_sales_amount"].Value = tax_sale_amount_with_discount.ToString();
                      
                            tax_amount = Convert.ToDecimal(dt1.Rows[inc]["tax_amount"].ToString());
                            service_charge_amount = Convert.ToDecimal(dt1.Rows[inc]["service_charge"].ToString());
                            dataGridView1.Rows[inc].Cells["cal_tax"].Value = tax_amount.ToString();
                            dataGridView1.Rows[inc].Cells["cal_service_charge"].Value = service_charge_amount.ToString();
                        string fiscal_year = dt1.Rows[inc]["fiscal_year"].ToString();
                        DataTable dtvoid = order.GetBillVoid(bill_nos,fiscal_year);
                        if (dtvoid.Rows.Count > 0)
                        {
                            dataGridView1.Rows[inc].Cells["col_voidbill"].Value = dtvoid.Rows[0]["void_bill_no"].ToString();
                            dataGridView1.Rows[inc].Cells["col_voiduser"].Value = dtvoid.Rows[0]["void_user"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_date2"].Value = dtvoid.Rows[0]["void_date"].ToString();
                        }

                        net_sales_with_service = tax_sale_amount_with_discount + service_charge_amount;
                        dataGridView1.Rows[inc].Cells["cal_net_sales"].Value = net_sales_with_service;
                        dataGridView1.Rows[inc].Cells["cal_grand_total"].Value = dt1.Rows[inc]["grand_total"].ToString();
                        // dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dt.Rows[inc]["sales_type"].ToString();
                        // dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dt.Rows[inc]["table_no"].ToString();

                        dataGridView1.Rows[inc].Cells["cal_date2"].Value = dt1.Rows[inc]["date2"].ToString();

                    }
                
                   // dataGridView1.ClearSelection();
                    Backpanel.Show();
                    searchPanel.Hide();
                }
            }
            grandtotal();
        }
        private void cmb_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_search.Text=="Void Bill No")
            {
                LoadVoidBill();
            }
            else if (cmb_search.Text=="ALL")
            {
                cmb_find.Text = "ALL";
                
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
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount-15);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            PdfPCell cell = new PdfPCell();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                if (column.Index <= 10)
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
                    if (cells.ColumnIndex <= 10)
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

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\VoidSales\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string Datename = DateTime.Now.ToString("dd-mm-yyyy hh");
            using (FileStream stream = new FileStream(folderPath + "VoidSales " + Datename + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                pdfDoc.Header = new HeaderFooter(new Phrase("Header Text"), false);
                pdfDoc.Open();
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph pheading = new Paragraph("Void Sales Report");
                Paragraph pheading_business_name = new Paragraph(Business_Name);
                Paragraph pheading_pan_no = new Paragraph("Pan No :" + pan_no);
                Paragraph pheadingDate = new Paragraph("From:     " + dtp_from.Text + "                                        " + "To:      " + dtp_to.Text);
                pheading.Alignment = Element.TITLE;
                pheading_business_name.Alignment = Element.TITLE;
                pheading_pan_no.Alignment = Element.TITLE;
                pheading.Alignment = Element.TITLE;
                Paragraph pheading_space = new Paragraph("   ");
                Paragraph p = new Paragraph("Total:-                                  " + lbl_sales_amount.Text + "                                                    " + lbl_service_charge.Text+"                                                                             "+lbl_grandtotal.Text);
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
    }
}

