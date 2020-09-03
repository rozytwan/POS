using BLLS;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace POS_System
{
    public partial class btnshowall : UserControl
    {
        public btnshowall()
        {
            InitializeComponent();
        }

        BLLPurchase blpur = new BLLPurchase();
        BLLCategory blcat = new BLLCategory();
      
        BLLProduct blpro = new BLLProduct();



 public void category()
        {
            DataTable dt = blcat.getallcategory();
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
            DataTable dt = blpro.getallproduct();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["product_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = dt;
                txt_searchText.DisplayMember = "product_name";

            }
        }

        public void inoiveids()
        {

            DataTable dt = blpur.getallpurchaseiInvoiceNo();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["invoice_no"] = "00000";
                dt.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = dt;
                txt_searchText.DisplayMember = "invoice_no";

            }
        }
        public void supliers_name()
        {
            DataTable dt = blpur.get_all_supliers();
            if (dt.Rows.Count > 0)
            {
                txt_searchText.DataSource = dt;
                txt_searchText.DisplayMember = "name";
                txt_searchText.ValueMember = "name";
            }
        }

        


        private void UserControl_view_purchases_Load(object sender, EventArgs e)
        {
            this.Width = this.Parent.Width;

            backpanel.Hide();
            cbo_searchTYpe.SelectedIndex = 0;
            changedatagridColors();
            
          
        }
      
        public void loadalldatagrid()
        {

            DataTable dt = blpur.getallpurchase();
            if (dt.Rows.Count > 0)
            {
                for (int er = 0; er < dt.Rows.Count; er++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[er].Cells["calquantity"].Value = dt.Rows[er]["quantity"].ToString();
                    dataGridView1.Rows[er].Cells["calinvoice"].Value = dt.Rows[er]["invoice_no"].ToString();
                    dataGridView1.Rows[er].Cells["calprice"].Value = dt.Rows[er]["price"].ToString();
                    dataGridView1.Rows[er].Cells["caldiscount"].Value = dt.Rows[er]["discount"].ToString();
                    dataGridView1.Rows[er].Cells["caltotal"].Value = dt.Rows[er]["total"].ToString();
                    dataGridView1.Rows[er].Cells["calexpiry"].Value = dt.Rows[er]["expiry_date"].ToString();
                    dataGridView1.Rows[er].Cells["calpaid"].Value = dt.Rows[er]["paid_amount"].ToString();
                    dataGridView1.Rows[er].Cells["calremain"].Value = dt.Rows[er]["remaining_amount"].ToString();
                    dataGridView1.Rows[er].Cells["calcategory_name"].Value = dt.Rows[er]["category_name"].ToString();
                    dataGridView1.Rows[er].Cells["calproduct_name"].Value = dt.Rows[er]["product_name"].ToString();



                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            allmenu alls = new allmenu();
            ctls.Controls.Clear();
            ctls.Controls.Add(alls);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadalldatagrid();
        }



        private void btn_export_to_pdf_Click_1(object sender, EventArgs e)
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

            // string folderPath = "C:\\PDFs\\";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\PurchaseReport\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "Purchase Report.pdf", FileMode.Create))
            {
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph p = new Paragraph("Purchase Report");
                p.Alignment = 1;

                pdfDoc.Add(p);
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }

            MessageBox.Show("Data Has Been Export To Documnet POS/PurchaseReport");
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            ExporyToExcel(dataGridView1, "ExportedUserDetail");
        }
        public void ExporyToExcel(DataGridView gridviewID, string excelFilename)

        {
            Microsoft.Office.Interop.Excel.Application objexcelapp = new Microsoft.Office.Interop.Excel.Application();
            objexcelapp.Application.Workbooks.Add(Type.Missing);
            objexcelapp.Columns.ColumnWidth = 15;
            for (int i = 1; i < gridviewID.Columns.Count + 1; i++)
            {
                objexcelapp.Cells[1, i] = gridviewID.Columns[i - 1].HeaderText;

            }
            for (int i = 0; i < gridviewID.Rows.Count; i++)
            {
                for (int j = 0; j < gridviewID.Columns.Count; j++)
                {
                    if (gridviewID.Rows[i].Cells[j].Value != null)
                    {
                        objexcelapp.Cells[i + 2, j + 1] = gridviewID.Rows[i].Cells[j].Value.ToString();
                    }
                }

            }
            excelFilename = "Purchase Report";
            MessageBox.Show("Your excel file export done" + excelFilename + ".xlsx");
            objexcelapp.ActiveWorkbook.SaveCopyAs("C:\\Excel Export\\" + excelFilename + ".xlsx");
            objexcelapp.ActiveWorkbook.Saved = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            allmenu alls = new allmenu();
            ctls.Controls.Clear();
            ctls.Controls.Add(alls);
        }

        private void backpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnproductsearch_Click_1(object sender, EventArgs e)
        {

        }

        public void changedatagridColors()
        {
           
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

                if (cbo_searchTYpe.Text == "Product")
                {
                    DataTable dt = blpur.searchpurchasebydateProducts(txt_searchText.Text, Convert.ToDateTime(dateOne), Convert.ToDateTime(datetwo));
                    if (dt.Rows.Count > 0)
                    {
                        for (int er = 0; er < dt.Rows.Count; er++)
                        {
                           
                                int i= dataGridView1.Rows.Add();
                                dataGridView1.Rows[er].Cells["calquantity"].Value = dt.Rows[er]["category_name"].ToString();
                                dataGridView1.Rows[er].Cells["calquantity"].Value = dt.Rows[er]["unit"].ToString();
                                dataGridView1.Rows[er].Cells["calquantity"].Value = dt.Rows[er]["payment_type"].ToString();
                                dataGridView1.Rows[er].Cells["calquantity"].Value = dt.Rows[er]["quantity"].ToString();
                                dataGridView1.Rows[er].Cells["calinvoice"].Value = dt.Rows[er]["invoice_no"].ToString();
                                dataGridView1.Rows[er].Cells["calprice"].Value = dt.Rows[er]["price"].ToString();
                                dataGridView1.Rows[er].Cells["caldiscount"].Value = dt.Rows[er]["discount"].ToString();
                                dataGridView1.Rows[er].Cells["caltotal"].Value = dt.Rows[er]["total"].ToString();
                                dataGridView1.Rows[er].Cells["calexpiry"].Value = dt.Rows[er]["expiry_date"].ToString();
                                dataGridView1.Rows[er].Cells["calpaid"].Value = dt.Rows[er]["paid_amount"].ToString();
                                dataGridView1.Rows[er].Cells["calremain"].Value = dt.Rows[er]["remaining_amount"].ToString();
                                dataGridView1.Rows[er].Cells["calcategory_name"].Value = dt.Rows[er]["category_name"].ToString();
                                dataGridView1.Rows[er].Cells["calproduct_name"].Value = dt.Rows[er]["product_name"].ToString();

                        }
                        dataGridView1.ClearSelection();
                        changedatagridColors();
                        backpanel.Show();
                        searchPanel.Hide();

                    }//dt rows if end
                    else
                    {
                        MessageBox.Show("Can't find " + txt_searchText.Text + " from " + dtp_from.Text + " To" + dtp_to.Text);
                    }
                }
                else if (cbo_searchTYpe.Text == "Category")
                {
                    DataTable dt = blpur.getpurchasebycategorybyDate(txt_searchText.Text, Convert.ToDateTime(dateOne), Convert.ToDateTime(datetwo));
                    if (dt.Rows.Count > 0)
                    {
                        for (int er = 0; er < dt.Rows.Count; er++)
                        {
                            dataGridView1.Rows.Add(dt.Rows[er]["invoice_no"].ToString(), dt.Rows[er]["category_name"].ToString(), dt.Rows[er]["product_name"].ToString(), dt.Rows[er]["quantity"].ToString(), dt.Rows[er]["unit"].ToString(), dt.Rows[er]["price"].ToString(), dt.Rows[er]["discount"].ToString(), dt.Rows[er]["total"].ToString(), dt.Rows[er]["expiry_date"].ToString(), dt.Rows[er]["paid_amount"].ToString(), dt.Rows[er]["remaining_amount"].ToString(), dt.Rows[er]["payment_type"].ToString());
                        }
                        dataGridView1.ClearSelection();
                        changedatagridColors();
                        backpanel.Show();
                        searchPanel.Hide();

                    }//dt rows if end
                    else
                    {
                        MessageBox.Show("Can't find " + txt_searchText.Text + " from " + dtp_from.Text + " To" + dtp_to.Text);
                    }
                }
                else if (cbo_searchTYpe.Text == "Invoice No")
                {
                    DataTable dt = blpur.getpurchasebycategorybyInvoices(txt_searchText.Text, Convert.ToDateTime(dateOne), Convert.ToDateTime(datetwo));
                    if (dt.Rows.Count > 0)
                    {
                        for (int er = 0; er < dt.Rows.Count; er++)
                        {
                            dataGridView1.Rows.Add(dt.Rows[er]["invoice_no"].ToString(), dt.Rows[er]["category_name"].ToString(), dt.Rows[er]["product_name"].ToString(), dt.Rows[er]["quantity"].ToString(), dt.Rows[er]["unit"].ToString(), dt.Rows[er]["price"].ToString(), dt.Rows[er]["discount"].ToString(), dt.Rows[er]["total"].ToString(), dt.Rows[er]["expiry_date"].ToString(), dt.Rows[er]["paid_amount"].ToString(), dt.Rows[er]["remaining_amount"].ToString(), dt.Rows[er]["payment_type"].ToString());
                        }
                        dataGridView1.ClearSelection();
                        changedatagridColors();
                        backpanel.Show();
                        searchPanel.Hide();

                    }//dt rows if end
                    else
                    {
                        MessageBox.Show("Can't find " + txt_searchText.Text + " from " + dtp_from.Text + " To" + dtp_to.Text);
                    }

                }
                else if (cbo_searchTYpe.Text == "ALL")
                {
                    DataTable dt = blpur.getpurchasebydate( Convert.ToDateTime(dateOne), Convert.ToDateTime(datetwo));
                    if (dt.Rows.Count > 0)
                    {
                        for (int er = 0; er < dt.Rows.Count; er++)
                        {
                            int i = dataGridView1.Rows.Add();
                            dataGridView1.Rows[er].Cells["calcategory_name"].Value = dt.Rows[er]["category_name"].ToString();
                            dataGridView1.Rows[er].Cells["calunit"].Value = dt.Rows[er]["unit"].ToString();
                            dataGridView1.Rows[er].Cells["calbill_no"].Value = dt.Rows[er]["bill_no"].ToString();
                            dataGridView1.Rows[er].Cells["calquantity"].Value = dt.Rows[er]["quantity"].ToString();
                            dataGridView1.Rows[er].Cells["calinvoice"].Value = dt.Rows[er]["invoice_no"].ToString();
                            dataGridView1.Rows[er].Cells["calprice"].Value = dt.Rows[er]["price"].ToString();
                            dataGridView1.Rows[er].Cells["caldiscount"].Value = dt.Rows[er]["discount"].ToString();
                            dataGridView1.Rows[er].Cells["caltotal"].Value = dt.Rows[er]["total"].ToString();
                            dataGridView1.Rows[er].Cells["calexpiry"].Value = dt.Rows[er]["expiry_date"].ToString();
                            dataGridView1.Rows[er].Cells["calpaid"].Value = dt.Rows[er]["paid_amount"].ToString();
                            dataGridView1.Rows[er].Cells["calremain"].Value = dt.Rows[er]["remaining_amount"].ToString();
                            dataGridView1.Rows[er].Cells["calcategory_name"].Value = dt.Rows[er]["category_name"].ToString();
                            dataGridView1.Rows[er].Cells["calproduct_name"].Value = dt.Rows[er]["product_name"].ToString();
                        }
                        dataGridView1.ClearSelection();
                        changedatagridColors();
                        backpanel.Show();
                        searchPanel.Hide();

                    }//dt rows if end
                    else
                    {
                        MessageBox.Show("Can't Find From " + dtp_from.Text + " To" + dtp_to.Text);
                    }

                }
                else if (cbo_searchTYpe.Text == "Payment Type")
                {
                    DataTable dt = blpur.getpurchasebypurchase(txt_searchText.Text,Convert.ToDateTime(dateOne), Convert.ToDateTime(datetwo));
                    if (dt.Rows.Count > 0)
                    {
                        for (int er = 0; er < dt.Rows.Count; er++)
                        {
                            dataGridView1.Rows.Add(dt.Rows[er]["invoice_no"].ToString(), dt.Rows[er]["category_name"].ToString(), dt.Rows[er]["product_name"].ToString(), dt.Rows[er]["quantity"].ToString(), dt.Rows[er]["unit"].ToString(), dt.Rows[er]["price"].ToString(), dt.Rows[er]["discount"].ToString(), dt.Rows[er]["total"].ToString(), dt.Rows[er]["expiry_date"].ToString(), dt.Rows[er]["paid_amount"].ToString(), dt.Rows[er]["remaining_amount"].ToString(), dt.Rows[er]["payment_type"].ToString());
                        }
                        dataGridView1.ClearSelection();
                        changedatagridColors();
                        backpanel.Show();
                        searchPanel.Hide();

                    }//dt rows if end
                    else
                    {
                        MessageBox.Show("Can't Find From " + dtp_from.Text + " To" + dtp_to.Text);
                    }

                }
                else if (cbo_searchTYpe.Text == "Supplier Name")
                {
                    DataTable dt = blpur.getpurchasebysupplier(txt_searchText.Text, Convert.ToDateTime(dateOne), Convert.ToDateTime(datetwo));
                    if (dt.Rows.Count > 0)
                    {
                        for (int er = 0; er < dt.Rows.Count; er++)
                        {
                            dataGridView1.Rows.Add(dt.Rows[er]["invoice_no"].ToString(), dt.Rows[er]["category_name"].ToString(), dt.Rows[er]["product_name"].ToString(), dt.Rows[er]["quantity"].ToString(), dt.Rows[er]["unit"].ToString(), dt.Rows[er]["price"].ToString(), dt.Rows[er]["discount"].ToString(), dt.Rows[er]["total"].ToString(), dt.Rows[er]["expiry_date"].ToString(), dt.Rows[er]["paid_amount"].ToString(), dt.Rows[er]["remaining_amount"].ToString(), dt.Rows[er]["payment_type"].ToString());
                        }
                        dataGridView1.ClearSelection();
                        changedatagridColors();
                        backpanel.Show();
                        searchPanel.Hide();

                    }//dt rows if end
                    else
                    {
                        MessageBox.Show("Can't Find From " + dtp_from.Text + " To" + dtp_to.Text);
                    }                   
                }

            }
        }

        private void btncategorysearch_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_back_Click_1(object sender, EventArgs e)
        {
            backpanel.Hide();
            searchPanel.Show();
        }

     

        private void cbo_searchTYpe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text == "Product")
            {
                products();
            }
            else if (cbo_searchTYpe.Text == "Category")
            {

                category();
            }
            else if (cbo_searchTYpe.Text == "Invoice No")
            {
                inoiveids();
            }
            else if (cbo_searchTYpe.Text == "ALL")
            {
                txt_searchText.Text = "ALL";
            }
            else if (cbo_searchTYpe.Text == "Payment Type")
            {
                clearcombo(txt_searchText);
                List<string> li = new List<string>();
                li.Add("Cash");
                li.Add("Credit");
                txt_searchText.DataSource = li;

            }         
            else if (cbo_searchTYpe.Text == "Supplier Name")
            {
                supliers_name();
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

        private void searchPanel_Paint(object sender, PaintEventArgs e)
        {

        }

       

        
    }
}
