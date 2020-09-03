using BLLS;
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
    public partial class View_Complementry_Sales : UserControl
    {
        public View_Complementry_Sales()
        {
            InitializeComponent();
        }
        BLLComplementry bllcom = new BLLComplementry();
        BLLUser blu = new BLLUser();
        public void Category_name()
        {
            DataTable dt = bllcom.GetCategory();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["category_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = dt;
                txt_searchText.DisplayMember = "category_name";

            }
        }
        public void Item_Name()
        {
            DataTable dt = bllcom.GetComplementryitem();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["item_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = dt;
                txt_searchText.DisplayMember = "item_name";

            }
        }
        public void Complementry_User()
        {
            DataTable dt = bllcom.GetUser();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["com_user"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = dt;
                txt_searchText.DisplayMember = "com_user";

            }
        }
        public void Complementry_Customer()
        {
            DataTable dt = bllcom.GetCustomer();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["customer_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = dt;
                txt_searchText.DisplayMember = "customer_name";

            }
        }
        private void View_Complementry_Sales_Load(object sender, EventArgs e)
        {
            backpanel.Hide();
            cbo_searchTYpe.SelectedIndex = 0;
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text == "" || cbo_searchTYpe.Text == "Choose Type" || txt_searchText.Text == "")
            {
                MessageBox.Show("The Fields are Empty or invalid.");
            }

            else
            {
 string dateOne = Convert.ToDateTime(dtp_from.Text).ToShortDateString();
                string datetwo = Convert.ToDateTime(dtp_to.Text).ToShortDateString();

    
                 if (cbo_searchTYpe.Text == "Category")
                {
                    DataTable dt = bllcom.GetCategoryComplementry((txt_searchText.Text), Convert.ToDateTime(dateOne), Convert.ToDateTime(datetwo));
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int er = 0; er < dt.Rows.Count; er++)
                        {
                            dataGridView1.Rows.Add();
                          
                            dataGridView1.Rows[er].Cells["col_item"].Value = dt.Rows[er]["item_name"].ToString();
                            dataGridView1.Rows[er].Cells["col_category"].Value = dt.Rows[er]["category_name"].ToString();
                            decimal cost = Convert.ToDecimal(dt.Rows[er]["cost"].ToString());
                            dataGridView1.Rows[er].Cells["col_cost"].Value = cost;
                            decimal qty = Convert.ToDecimal(dt.Rows[er]["quantity"].ToString());
                            dataGridView1.Rows[er].Cells["col_quantity"].Value = qty;
                            dataGridView1.Rows[er].Cells["col_total"].Value = cost * qty;
                            dataGridView1.Rows[er].Cells["col_date"].Value = dt.Rows[er]["date_of_sales"].ToString();
                            dataGridView1.Rows[er].Cells["col_customer"].Value = dt.Rows[er]["customer_name"].ToString();
                            dataGridView1.Rows[er].Cells["col_cashier"].Value = dt.Rows[er]["cashier_name"].ToString();
                            dataGridView1.Rows[er].Cells["cal_comp_no"].Value = dt.Rows[er]["comp_invoice"].ToString();

                        }
                  
                        // changedatagridColors();
                        backpanel.Show();
                        searchPanel.Hide();

                    }
                }
               else if (cbo_searchTYpe.Text == "Item Name")
                {
                    DataTable dt = bllcom.GetItemComplementrysales((txt_searchText.Text), Convert.ToDateTime(dateOne), Convert.ToDateTime(datetwo));
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int er = 0; er < dt.Rows.Count; er++)
                        {
                            dataGridView1.Rows.Add();
                          
                            dataGridView1.Rows[er].Cells["col_item"].Value = dt.Rows[er]["item_name"].ToString();
                            dataGridView1.Rows[er].Cells["col_category"].Value = dt.Rows[er]["category_name"].ToString();
                            decimal cost = Convert.ToDecimal(dt.Rows[er]["cost"].ToString());
                            dataGridView1.Rows[er].Cells["col_cost"].Value = cost;
                            decimal qty = Convert.ToDecimal(dt.Rows[er]["quantity"].ToString());
                            dataGridView1.Rows[er].Cells["col_quantity"].Value = qty;
                            dataGridView1.Rows[er].Cells["col_total"].Value = cost * qty;
                            dataGridView1.Rows[er].Cells["col_date"].Value = dt.Rows[er]["date_of_sales"].ToString();
                            dataGridView1.Rows[er].Cells["col_customer"].Value = dt.Rows[er]["customer_name"].ToString();
                            dataGridView1.Rows[er].Cells["col_cashier"].Value = dt.Rows[er]["cashier_name"].ToString();
                            dataGridView1.Rows[er].Cells["cal_comp_no"].Value = dt.Rows[er]["comp_invoice"].ToString();
                        }
                   
                        // changedatagridColors();
                        backpanel.Show();
                        searchPanel.Hide();

                    }
                }
                else if (cbo_searchTYpe.Text == "Complementry Customer")
                {
                    DataTable dt = bllcom.GetCustomerComplementry((txt_searchText.Text), Convert.ToDateTime(dateOne), Convert.ToDateTime(datetwo));
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int er = 0; er < dt.Rows.Count; er++)
                        {
                            dataGridView1.Rows.Add();
                       
                            dataGridView1.Rows[er].Cells["col_item"].Value = dt.Rows[er]["item_name"].ToString();
                            dataGridView1.Rows[er].Cells["col_category"].Value = dt.Rows[er]["category_name"].ToString();
                            decimal cost = Convert.ToDecimal(dt.Rows[er]["cost"].ToString());
                            dataGridView1.Rows[er].Cells["col_cost"].Value = cost;
                            decimal qty = Convert.ToDecimal(dt.Rows[er]["quantity"].ToString());
                            dataGridView1.Rows[er].Cells["col_quantity"].Value = qty;
                            dataGridView1.Rows[er].Cells["col_total"].Value = cost * qty;
                            dataGridView1.Rows[er].Cells["col_date"].Value = dt.Rows[er]["date_of_sales"].ToString();
                            dataGridView1.Rows[er].Cells["col_customer"].Value = dt.Rows[er]["customer_name"].ToString();
                            dataGridView1.Rows[er].Cells["col_cashier"].Value = dt.Rows[er]["cashier_name"].ToString();
                            dataGridView1.Rows[er].Cells["cal_comp_no"].Value = dt.Rows[er]["comp_invoice"].ToString();
                        }
                     
                        // changedatagridColors();
                        backpanel.Show();
                        searchPanel.Hide();

                    }
                }
                else if (cbo_searchTYpe.Text == "Cashier Complementry")
                {
                    DataTable dt = bllcom.GetCashierComplementry((txt_searchText.Text), Convert.ToDateTime(dateOne), Convert.ToDateTime(datetwo));
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int er = 0; er < dt.Rows.Count; er++)
                        {
                            dataGridView1.Rows.Add();

                            dataGridView1.Rows[er].Cells["col_item"].Value = dt.Rows[er]["item_name"].ToString();
                            dataGridView1.Rows[er].Cells["col_category"].Value = dt.Rows[er]["category_name"].ToString();
                            decimal cost = Convert.ToDecimal(dt.Rows[er]["cost"].ToString());
                            dataGridView1.Rows[er].Cells["col_cost"].Value = cost;
                            decimal qty = Convert.ToDecimal(dt.Rows[er]["quantity"].ToString());
                            dataGridView1.Rows[er].Cells["col_quantity"].Value = qty;
                            dataGridView1.Rows[er].Cells["col_total"].Value = cost * qty;
                            dataGridView1.Rows[er].Cells["col_date"].Value = dt.Rows[er]["date_of_sales"].ToString();
                            dataGridView1.Rows[er].Cells["col_customer"].Value = dt.Rows[er]["customer_name"].ToString();
                            dataGridView1.Rows[er].Cells["col_cashier"].Value = dt.Rows[er]["cashier_name"].ToString();
                            dataGridView1.Rows[er].Cells["cal_comp_no"].Value = dt.Rows[er]["comp_invoice"].ToString();
                        }

                        // changedatagridColors();
                        backpanel.Show();
                        searchPanel.Hide();

                    }
                }
                else if (cbo_searchTYpe.Text == "ALL")
                {
                    DataTable dt = bllcom.GetAllComplementrysales(Convert.ToDateTime(dateOne), Convert.ToDateTime(datetwo));
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int er = 0; er < dt.Rows.Count; er++)
                        {
                            dataGridView1.Rows.Add();
                           // dataGridView1.Rows[er].Cells["col_bill_no"].Value = dt.Rows[er]["bill_no"].ToString();
                            dataGridView1.Rows[er].Cells["col_item"].Value = dt.Rows[er]["item_name"].ToString();
                            dataGridView1.Rows[er].Cells["col_category"].Value = dt.Rows[er]["category_name"].ToString();
                            decimal cost = Convert.ToDecimal(dt.Rows[er]["cost"].ToString());
                            dataGridView1.Rows[er].Cells["col_cost"].Value = cost;
                            decimal qty = Convert.ToDecimal(dt.Rows[er]["quantity"].ToString());
                            dataGridView1.Rows[er].Cells["col_quantity"].Value = qty;
                            dataGridView1.Rows[er].Cells["col_total"].Value = cost * qty;
                            dataGridView1.Rows[er].Cells["col_date"].Value = dt.Rows[er]["date_of_sales"].ToString();
                            dataGridView1.Rows[er].Cells["col_customer"].Value = dt.Rows[er]["customer_name"].ToString();
                            dataGridView1.Rows[er].Cells["col_cashier"].Value = dt.Rows[er]["cashier_name"].ToString();
                            dataGridView1.Rows[er].Cells["cal_comp_no"].Value = dt.Rows[er]["comp_invoice"].ToString();
                            qty += Convert.ToDecimal(qty);
                        }
                     
                        // changedatagridColors();
                        backpanel.Show();
                        searchPanel.Hide();

                    }

                    else
                    {
                        MessageBox.Show("Can't find " + txt_searchText.Text + " from " + dtp_from.Text + " To" + dtp_to.Text);
                    }
                
                }
                grandtotal();
            }
           
        }
  
        public void grandtotal()
        {
            decimal qty = 0;
            decimal cost = 0;
            decimal total = 0;
            if (dataGridView1.Rows.Count>0)
            {
                for (int x = 0; x < dataGridView1.Rows.Count; x++)
                {
                    qty += Convert.ToDecimal(dataGridView1.Rows[x].Cells["col_quantity"].Value.ToString());
                    cost += Convert.ToDecimal(dataGridView1.Rows[x].Cells["col_cost"].Value.ToString());
                    total += Convert.ToDecimal(dataGridView1.Rows[x].Cells["col_total"].Value.ToString());

                }
                lbl_cost.Text = cost.ToString();
                lbl_qty.Text = qty.ToString();
                lbl_total.Text = total.ToString();
            }

        }
        private void cbo_searchTYpe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text == "Category")
            {
                Category_name();
            }
            else if (cbo_searchTYpe.Text == "Item Name")
            {

                Item_Name();
            }
            else if (cbo_searchTYpe.Text == "Complementry Customer")
            {
                Complementry_Customer();
            }
            else if (cbo_searchTYpe.Text == "Cashier Complementry")
            {
                Complementry_User();
            }
            else if (cbo_searchTYpe.Text == "ALL")
            {
                txt_searchText.Text = "ALL";
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            backpanel.Hide();
            searchPanel.Show();
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
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
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

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\ComplementrySales\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string Datename = DateTime.Now.ToString("dd-mm-yyyy hh");
            using (FileStream stream = new FileStream(folderPath + "ComplementrySales " + Datename + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                pdfDoc.Header = new HeaderFooter(new Phrase("Header Text"), false);
                pdfDoc.Open();
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph pheading = new Paragraph("Complementry Sales Report");
                Paragraph pheading_business_name = new Paragraph(Business_Name);
                Paragraph pheading_pan_no = new Paragraph("Pan No :" + pan_no);
                Paragraph pheadingDate = new Paragraph("From:     " + dtp_from.Text + "                                        " + "To:      " + dtp_to.Text);
                pheading.Alignment = Element.TITLE;
                pheading_business_name.Alignment = Element.TITLE;
                pheading_pan_no.Alignment = Element.TITLE;
                pheading.Alignment = Element.TITLE;
                Paragraph pheading_space = new Paragraph("   ");
                Paragraph p = new Paragraph("Total:-                                                                                   " + lbl_qty.Text + "                 " + lbl_cost.Text+"                   "+lbl_total.Text);
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
        string data;
        private void btn_excel_Click(object sender, EventArgs e)
        {
            //ExporyToExcel(btn_export_toexcel, "ExportedUserDetail");
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index <= 8)
                {
                    dt.Columns.Add(column.HeaderText);
                }
            }

            //Adding the Rows
         
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex <= 8)
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
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\ComplementrySales Excel\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Complementry Sales");
                wb.SaveAs(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "ComplementrySales.xlsx");
                MessageBox.Show("Your complementry excel report has been export to document", "Complementry Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void View_Complementry_Sales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control==true && e.KeyCode.ToString()=="A")
            {
                MessageBox.Show("This is true");

            }
        }

        private void lbl_total_Click(object sender, EventArgs e)
        {

        }

        private void searchPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
