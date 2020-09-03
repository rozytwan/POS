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
    public partial class ViewStockTransfer : UserControl
    {
        public ViewStockTransfer()
        {
            InitializeComponent();
        }
        BLLStockCategory blsc = new BLLStockCategory();
        BLLStockTransfer blst = new BLLStockTransfer();
        private object saveFileDialog1;

        private void ViewStockTransfer_Load(object sender, EventArgs e)
        {
            loadCategory();
            LoadProduct();
            searchPanel.Show();
            backPanel.Hide();
            cbo_searchTYpe.Text = "Choose Type";
            string today = DateTime.Now.ToShortDateString();
            dtp_from.Text = today;
            dtp_to.Text = today;
            DataTable dt = blst.QuantitySum();
            if (lbl_qty.Text!="")
            {
                lbl_qty.Text = dt.Rows[0][0].ToString();
            }
            else
            {
                lbl_qty.Text = "0.00";
            }

        }
        public void loadCategory()
        {
            DataTable dt = blsc.GetCategories();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["category_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cmb_search.DataSource = dt;
                cmb_search.DisplayMember = "category_name";
                cmb_search.ValueMember = "category_id";
            }
        }
        public void LoadProduct()
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
        private void cbo_searchTYpe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text == "Product Name")
            {
                LoadProduct();
            }
            else if (cbo_searchTYpe.Text == "Category Name")
            {
                loadCategory();
            }
        }

        private void btn_show_Click(object sender, EventArgs e)
        {

            if (cbo_searchTYpe.Text == "" || cbo_searchTYpe.Text == "Choose Type" || cmb_search.Text == "")
            {
                MessageBox.Show("The Fields are Empty or invalid.");
            }
            else
            {
                DateTime datefrom = Convert.ToDateTime(dtp_from.Text);
                DateTime dateto = Convert.ToDateTime(dtp_to.Text);
                DateTime date = Convert.ToDateTime(DateTime.Now.ToString());
                if (cbo_searchTYpe.Text == "Category Name")
                {
                    DataTable dt = blst.SearchByCategory(Convert.ToInt32(cmb_search.SelectedValue), datefrom, dateto);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add();
                            int category_id = Convert.ToInt32(dt.Rows[i]["category_id"].ToString());
                            DataTable dt1 = blsc.GetCategory(category_id);

                            dataGridView1.Rows[i].Cells["col_category_name"].Value = dt1.Rows[0]["category_name"].ToString();

                            dataGridView1.Rows[i].Cells["col_stock_id"].Value = dt.Rows[i]["stock_dec_id"].ToString();
                            int product_id = Convert.ToInt32(dt.Rows[i]["product_id"].ToString());
                            DataTable dt2 = blsc.Getproductbyid(Convert.ToString(product_id));

                            dataGridView1.Rows[i].Cells["col_product_name"].Value = dt2.Rows[0]["product_name"].ToString();

                            dataGridView1.Rows[i].Cells["col_transfer_date"].Value = dt.Rows[i]["transfer_date"].ToString();
                            dataGridView1.Rows[i].Cells["col_transfer_to"].Value = dt.Rows[i]["transfer_to"].ToString();
                            dataGridView1.Rows[i].Cells["col_transfer_by"].Value = dt.Rows[i]["transfer_by"].ToString();

                            dataGridView1.Rows[i].Cells["col_unit"].Value = dt.Rows[i]["unit"].ToString();
                            dataGridView1.Rows[i].Cells["col_qty"].Value = dt.Rows[i]["qty"].ToString();
                            dataGridView1.Rows[i].Cells["col_location"].Value = dt.Rows[i]["location"].ToString();

                        }
                        searchPanel.Hide();
                        backPanel.Show();

                    }
                }
                else if (cbo_searchTYpe.Text == "Product Name")
                {
                    DataTable dt3 = blst.SearchByProduct(Convert.ToInt32(cmb_search.SelectedValue), datefrom, dateto);
                    if (dt3.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < dt3.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add();
                            int category_id = Convert.ToInt32(dt3.Rows[i]["category_id"].ToString());
                            DataTable dt1 = blsc.GetCategory(category_id);

                            dataGridView1.Rows[i].Cells["col_category_name"].Value = dt1.Rows[0]["category_name"].ToString();

                            int product_id = Convert.ToInt32(dt3.Rows[i]["product_id"].ToString());
                            DataTable dt2 = blsc.Getproductbyid(Convert.ToString(product_id));

                            dataGridView1.Rows[i].Cells["col_product_name"].Value = dt2.Rows[0]["product_name"].ToString();

                            dataGridView1.Rows[i].Cells["col_transfer_date"].Value = dt3.Rows[i]["transfer_date"].ToString();
                            dataGridView1.Rows[i].Cells["col_transfer_to"].Value = dt3.Rows[i]["transfer_to"].ToString();
                            dataGridView1.Rows[i].Cells["col_transfer_by"].Value = dt3.Rows[i]["transfer_by"].ToString();

                            dataGridView1.Rows[i].Cells["col_unit"].Value = dt3.Rows[i]["unit"].ToString();
                            dataGridView1.Rows[i].Cells["col_qty"].Value = dt3.Rows[i]["qty"].ToString();
                            dataGridView1.Rows[i].Cells["col_location"].Value = dt3.Rows[i]["location"].ToString();

                        }
                        searchPanel.Hide();
                        backPanel.Show();

                    }
                }

            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            backPanel.Hide();
            searchPanel.Show();
        }

        private void btn_export_to_pdf_Click(object sender, EventArgs e)
        {

            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            Document pdfDoc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);

            //Adding Header row
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));

                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(cell.Value.ToString());
                }
            }

            //Exporting to PDF

          //  saveFileDialog1.FileName = label23.Text;

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SmTechDocuments " + "\\StockTransfer\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "Stock Transfer.pdf", FileMode.Create))
            {
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph p = new Paragraph("Stock Transfer");
                p.Alignment = 1;

                pdfDoc.Add(p);
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }

            MessageBox.Show("Data Has Been Export To Sm5TechDocuments/StockTransfer");
        }
        DataTable dt_xml = new DataTable();
        private void btn_export_XML_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index < 14)
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
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\StockTransfer\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            dt_xml.WriteXml(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "StockTransfer.xml", XmlWriteMode.WriteSchema);
            MessageBox.Show("Data Exported To XML");
            dt_xml.Clear();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
    }
    
        
    

