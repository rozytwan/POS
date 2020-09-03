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
    public partial class Purchase_Stock_Product : UserControl
    {
        public Purchase_Stock_Product()
        {
            InitializeComponent();
        }
        BLLStock blls = new BLLStock();
        DateTime date = Convert.ToDateTime(DateTime.Now.ToString());
        private void Purchase_Stock_Product_Load(object sender, EventArgs e)
        {
            searchPanel.Show();
            backPanel.Hide();
            cbo_searchTYpe.SelectedIndex = 0;
            dtp_from.Text = date.ToString();
            dtp_to.Text = date.ToString();
        }
        public void LoadProduct()
        {
            DataTable dt = blls.Getproduct();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["product_name"] = "Choose Product";
                dt.Rows.InsertAt(dr, 0);

                cmb_search.DataSource = dt;
                cmb_search.DisplayMember = "product_name";
               // cmb_search.ValueMember = "prodcut_id";
            }
        }
        string productname;
        decimal sum;
        public void LoadAllPurchase()
        {
            DateTime datefrom = Convert.ToDateTime(dtp_from.Text);
            DateTime dateto = Convert.ToDateTime(dtp_to.Text);
          
            DataTable dt = blls.GetAllProduct(datefrom, dateto);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
               
                   dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();
             
                    dataGridView1.Rows[i].Cells["col_location"].Value = dt.Rows[i]["location"].ToString();
                    dataGridView1.Rows[i].Cells["col_status"].Value = dt.Rows[i]["status"].ToString();
                    dataGridView1.Rows[i].Cells["col_purchase_date"].Value = dt.Rows[i]["dateOfSales"].ToString();
                    string status = dt.Rows[i]["status"].ToString();
                    if (status == "Opening")
                    {
                        dataGridView1.Rows[i].Cells["col_opening"].Value = dt.Rows[i]["purchase"].ToString() + " " + dt.Rows[i]["unit"].ToString();
                    }
                    else if (status == "Received")
                    {
                        dataGridView1.Rows[i].Cells["col_purchase"].Value = dt.Rows[i]["purchase"].ToString() + " " + dt.Rows[i]["unit"].ToString();
                    }
                    else if (status == "Transfer")

                    {
                        dataGridView1.Rows[i].Cells["col_transfer"].Value = dt.Rows[i]["purchase"].ToString() + " " + dt.Rows[i]["unit"].ToString();
                    }
                    else if (status == "Add Adjust")

                    {
                        dataGridView1.Rows[i].Cells["col_add"].Value = dt.Rows[i]["purchase"].ToString() + " " + dt.Rows[i]["unit"].ToString();
                    }
                    else if (status == "Decrease Adjust")

                    {
                        dataGridView1.Rows[i].Cells["col_decrease"].Value = dt.Rows[i]["purchase"].ToString() + " " + dt.Rows[i]["unit"].ToString();
                    }
          
                    searchPanel.Hide();
                    backPanel.Show();
                }
            }
        }
        private void btn_show_Click(object sender, EventArgs e)
        {
            DateTime datefrom = Convert.ToDateTime(dtp_from.Text);
            DateTime dateto = Convert.ToDateTime(dtp_to.Text);
            if (cbo_searchTYpe.Text == "" || cbo_searchTYpe.Text == "Choose Type" || cmb_search.Text == "")
            {
                MessageBox.Show("The Fields are Empty or invalid.");
            }
            else
            {
                if (cbo_searchTYpe.Text == "ALL")
                {
                    LoadAllPurchase();
                }
                if (cbo_searchTYpe.Text == "Product Name")
                {
                    DataTable dt = blls.GetProduct(cmb_search.Text, datefrom, dateto);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add();
                          
                            dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();
                            string product_name = dt.Rows[i]["product_name"].ToString();
                            dataGridView1.Rows[i].Cells["col_location"].Value = dt.Rows[i]["location"].ToString();
                            dataGridView1.Rows[i].Cells["col_purchase_date"].Value = dt.Rows[i]["dateOfSales"].ToString();
                            string purchase = dt.Rows[i]["dateOfSales"].ToString();
                            dataGridView1.Rows[i].Cells["col_status"].Value = dt.Rows[i]["status"].ToString();
                           
                            string status = dt.Rows[i]["status"].ToString();
                            if (status == "Opening")
                            {
                                dataGridView1.Rows[i].Cells["col_opening"].Value = dt.Rows[i]["purchase"].ToString() + " " + dt.Rows[i]["unit"].ToString();
                            }
                            else if (status == "Received")
                            {
                                dataGridView1.Rows[i].Cells["col_purchase"].Value = dt.Rows[i]["purchase"].ToString() + " " + dt.Rows[i]["unit"].ToString();
                            }
                            else if (status == "Transfer")

                            {
                                dataGridView1.Rows[i].Cells["col_transfer"].Value = dt.Rows[i]["purchase"].ToString() + " " + dt.Rows[i]["unit"].ToString();
                            }
                            else if (status == "Add Adjust")

                            {
                                dataGridView1.Rows[i].Cells["col_add"].Value = dt.Rows[i]["purchase"].ToString() + " " + dt.Rows[i]["unit"].ToString();
                            }
                            else if (status == "Decrease Adjust")

                            {
                                dataGridView1.Rows[i].Cells["col_decrease"].Value = dt.Rows[i]["purchase"].ToString() + " " + dt.Rows[i]["unit"].ToString();
                            }
                            
                           
                        }
 searchPanel.Hide();
                        backPanel.Show();

                    }
                    else
                    {
                        MessageBox.Show("No Data Available Between Dates !!", "No Data Alert !!");
                    }
                }
            }
        }
           private void cbo_searchTYpe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text=="ALL")
            {
                cmb_search.Text = "ALL";
            }
            else if (cbo_searchTYpe.Text=="Product Name")
            {
                LoadProduct();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            searchPanel.Show();
            backPanel.Hide();
            cbo_searchTYpe.SelectedIndex = 0;
            dtp_from.Text = date.ToString();
            dtp_to.Text = date.ToString();
        }

        string StaticDate;
        private void btn_excel_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index <= 6)
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
                    if (Convert.ToDateTime(row.Cells["col_purchase_date"].Value).ToString("dd-MM-yyyy") != StaticDate)
                    {
                        dt.Rows.Add();
                        StaticDate = Convert.ToDateTime(row.Cells["col_purchase_date"].Value).ToString("dd-MM-yyyy");
                        dt.Rows.Add(StaticDate);
                        dt.Rows.Add();
                    }
                    if (cell.Value == null)
                    {
                        data = "0.00";
                    }
                    else
                    {
                        data = cell.Value.ToString();
                    }
                    if (cell.ColumnIndex <= 6)
                    {
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = data;
                    }
                }
            }

            //Exporting to Excel
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\StockProductPurchase Excel\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Stock Purchase");
                wb.SaveAs(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "StockProductPurchase.xlsx");
            }
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
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\StockProductPurchase\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            dt_xml.WriteXml(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "StockProductPurchase.xml", XmlWriteMode.WriteSchema);
            MessageBox.Show("Data Exported To XML");
            dt_xml.Clear();

        }
        BLLUser blu = new BLLUser();
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
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount-2);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            PdfPCell cell = new PdfPCell();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                if (column.Index <= 7)
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
                    if (cells.ColumnIndex <= 7)
                    {
                        if (cells.Value == null)
                        {
                            data = "";
                        }
                        else
                        {
                            data = cells.Value.ToString();
                        }
                        pdfTable.AddCell(data);
                    }
                }
            }

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\StockPurchase\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string Datename = DateTime.Now.ToString("dd-mm-yyyy hh");
            using (FileStream stream = new FileStream(folderPath + "StockPurchase " + Datename + ".pdf", FileMode.Create))
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
                Paragraph p = new Paragraph("                                                  ");
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
