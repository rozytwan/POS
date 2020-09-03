using BLLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System
{
    public partial class ViewStockSales : UserControl
    {
        public ViewStockSales()
        {
            InitializeComponent();
        }
        BLLStock blls = new BLLStock();
        BLLStockCategory blsc = new BLLStockCategory();
        BLLUser blu = new BLLUser();
        private void ViewStockSales_Load(object sender, EventArgs e)
        {
            searchPanel.Show();
            backPanel.Hide();
            cbo_searchTYpe.SelectedIndex = 0;
            dtp_from.Text = DateTime.Now.ToShortDateString();
            dtp_to.Text = DateTime.Now.ToShortDateString();
            

        }
        public void Category()
        {
            DataTable dt = blsc.GetAllItems();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["item_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cmb_search.DataSource = dt;
                cmb_search.DisplayMember = "item_name";
                cmb_search.ValueMember = "item_id";
            }
        }
        public void Product()
        {
            DataTable dt = blsc.GetproductList();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["product_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cmb_search.DataSource = dt;
                cmb_search.DisplayMember = "product_name";
                cmb_search.ValueMember = "product_id";

            }
        }
        public void LoadStock()
        {
            DataTable dt = blls.GetStockSales(Convert.ToDateTime(dtp_from.Text), Convert.ToDateTime(dtp_to.Text));
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    //int category_id = Convert.ToInt32(dt.Rows[i]["item_id"].ToString());
                    //DataTable dt1 = blsc.GetCategory(category_id);
                    dataGridView1.Rows[i].Cells["col_item"].Value = dt.Rows[i]["item_name"].ToString();
                    //int product_id = Convert.ToInt32(dt.Rows[i]["product_id"].ToString());
                    //DataTable dt2 = blsc.GetQtybyProductid(product_id);
                    dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();
                   dataGridView1.Rows[i].Cells["col_unit"].Value = dt.Rows[i]["unit"].ToString();
                    dataGridView1.Rows[i].Cells["col_stock_id"].Value = dt.Rows[i]["id"].ToString();
                    dataGridView1.Rows[i].Cells["col_qty"].Value = dt.Rows[i]["qty"].ToString();

                    dataGridView1.Rows[i].Cells["col_location"].Value = dt.Rows[i]["location"].ToString();
                    dataGridView1.Rows[i].Cells["col_date"].Value = dt.Rows[i]["date_of_Sales"].ToString();

                }
                backPanel.Show();
                searchPanel.Hide();
                SumQuantity();
            }
            else
            {
                MessageBox.Show("No Data Available", "No Data Alert !!");
            }

        }
        public void SumQuantity()
        {
            decimal sum = 0;

            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {

                sum += Convert.ToDecimal(dataGridView1.Rows[x].Cells["col_qty"].Value.ToString());

            }
            lbl_qty.Text = sum.ToString();

        }
        private void btn_show_Click(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text == "" || cbo_searchTYpe.Text == "Choose Type" || cmb_search.Text == "")
            {
                MessageBox.Show("The Fields are Empty or invalid.");
            }
            else
            {
                if (cbo_searchTYpe.Text == "Item Name")
                {
                    DataTable dt = blls.GetItemSales(Convert.ToInt32(cmb_search.SelectedValue), Convert.ToDateTime(dtp_from.Text), Convert.ToDateTime(dtp_to.Text));
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add();
                            //int category_id = Convert.ToInt32(dt.Rows[i]["item_id"].ToString());
                            //DataTable dt1 = blsc.GetItemName(category_id);
                            dataGridView1.Rows[i].Cells["col_item"].Value = dt.Rows[i]["item_name"].ToString();
                            //int product_id = Convert.ToInt32(dt.Rows[i]["product_id"].ToString());
                            //DataTable dt2 = blsc.GetQtybyProductid(product_id);
                            dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();
                         
                            dataGridView1.Rows[i].Cells["col_unit"].Value = dt.Rows[i]["unit"].ToString();
                            dataGridView1.Rows[i].Cells["col_stock_id"].Value = dt.Rows[i]["id"].ToString();
                            dataGridView1.Rows[i].Cells["col_qty"].Value = dt.Rows[i]["qty"].ToString();
                            dataGridView1.Rows[i].Cells["col_status"].Value = dt.Rows[i]["status"].ToString();
                            dataGridView1.Rows[i].Cells["col_location"].Value = dt.Rows[i]["location"].ToString();
                            dataGridView1.Rows[i].Cells["col_date"].Value = dt.Rows[i]["date_of_sales"].ToString();

                        }
                        backPanel.Show();
                        SumQuantity();
                        searchPanel.Hide();

                    }
                    else
                    {
                        MessageBox.Show("No Data Available", "No Data Alert !!");
                    }
                  
                }
                else if (cbo_searchTYpe.Text == "Product")
                {
                    DataTable dt = blls.GetProductSales(Convert.ToInt32(cmb_search.SelectedValue), Convert.ToDateTime(dtp_from.Text), Convert.ToDateTime(dtp_to.Text));
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add();
                            //int item_id = Convert.ToInt32(dt.Rows[i]["item_id"].ToString());
                            //DataTable dt1 = blsc.GetItemName(item_id);
                            dataGridView1.Rows[i].Cells["col_item"].Value = dt.Rows[i]["item_name"].ToString();
                            //int product_id = Convert.ToInt32(dt.Rows[i]["product_id"].ToString());
                            //DataTable dt2 = blsc.GetQtybyProductid(product_id);
                            dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();
                            dataGridView1.Rows[i].Cells["col_unit"].Value = dt.Rows[i]["unit"].ToString();
                            dataGridView1.Rows[i].Cells["col_stock_id"].Value = dt.Rows[i]["id"].ToString();
                            dataGridView1.Rows[i].Cells["col_qty"].Value = dt.Rows[i]["qty"].ToString();
                            dataGridView1.Rows[i].Cells["col_status"].Value = dt.Rows[i]["status"].ToString();
                            dataGridView1.Rows[i].Cells["col_location"].Value = dt.Rows[i]["location"].ToString();
                            dataGridView1.Rows[i].Cells["col_date"].Value = dt.Rows[i]["date_of_sales"].ToString();

                        }
                        backPanel.Show();
                        searchPanel.Hide();
                        SumQuantity();
                    }
                    else
                    {
                        MessageBox.Show("No Data Available", "No Data Alert !!");
                    }

                }
                else
                {
                    LoadStock();
              
                }
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            backPanel.Hide();
            searchPanel.Show();
        }

        private void cbo_searchTYpe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text == "Item Name")
            {
                Category();
            }
            else if (cbo_searchTYpe.Text == "Product")
            {
                Product();
            }
            else if (cbo_searchTYpe.Text == "ALL")
            {
                cmb_search.Text = "ALL";
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

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\StockSales\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string Datename = DateTime.Now.ToString("dd-mm-yyyy hh");
            using (FileStream stream = new FileStream(folderPath + "StockSales " + Datename + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                pdfDoc.Header = new HeaderFooter(new Phrase("Header Text"), false);
                pdfDoc.Open();
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph pheading = new Paragraph("Stock Sales Report");
                Paragraph pheading_business_name = new Paragraph(Business_Name);
                Paragraph pheading_pan_no = new Paragraph("Pan No :" + pan_no);
                Paragraph pheadingDate = new Paragraph("From:     " + dtp_from.Text + "                                        " + "To:      " + dtp_to.Text);
                pheading.Alignment = Element.TITLE;
                pheading_business_name.Alignment = Element.TITLE;
                pheading_pan_no.Alignment = Element.TITLE;
                pheading.Alignment = Element.TITLE;
                Paragraph pheading_space = new Paragraph("   ");
                Paragraph p = new Paragraph("Total:-                                  " + lbl_qty.Text);
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
            //ExporyToExcel(btn_export_toexcel, "ExportedUserDetail");
            DataTable dt = new DataTable();
            DataTable dt_m = blu.checkbusiness();
            if (dt_m.Rows.Count > 0)
            {
                Business_Name = dt_m.Rows[0]["business_name"].ToString();
                pan_no = dt_m.Rows[0]["pan_no"].ToString();
            }
            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index <= 14)
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
                    if (cell.ColumnIndex <= 14)
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
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\StockSales Excel\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }


            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, Business_Name);
                wb.SaveAs(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "StockSalesReport.xlsx");
                MessageBox.Show("Your stock sales excel report has been export to document", "Stock Sales Export", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
