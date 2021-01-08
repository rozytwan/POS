using BLLS;

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
using iTextSharp.text.pdf;
using iTextSharp.text;
using ClosedXML.Excel;
using System.Reflection;

namespace POS_System.Customer_Management
{
    public partial class CustomerList : UserControl
    {
        public CustomerList()

        {
            InitializeComponent();
        }
        blllCustomerDetailednyo customer = new blllCustomerDetailednyo();
        BLLUser blu = new BLLUser();
        BLLcardreport blcr = new BLLcardreport();
        
        // Page for pagination
        int mintTotalRecords = 0;
        int mintPageSize = 0;
        int mintPageCount = 0;
        int mintCurrentPage = 1;
       // int tbPageSize;
        string status;
        DataTable dt = new DataTable();
        string today = DateTime.Now.ToShortDateString();
        int customer_id;
        private void CutomerList_Load(object sender, EventArgs e)
        {
            fillGrid();
            Loadcustomer();
            panel_replace.Hide();
            panel_topup.Hide();
            cmb_search.SelectedIndex = 0;
            txt_search_by.Hide();
        }
        public void Loadcustomer()
        {
            int intSkip = 0;
            intSkip = (this.mintCurrentPage * this.mintPageSize);
            dt = customer.getallcustomersrecent(mintPageSize, intSkip);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
               
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_id"].Value = dt.Rows[i]["id"].ToString();
                   
                    dataGridView1.Rows[i].Cells["col_name"].Value = dt.Rows[i]["name"].ToString();
                    dataGridView1.Rows[i].Cells["col_last_name"].Value = dt.Rows[i]["lastname"].ToString();
                    dataGridView1.Rows[i].Cells["col_phone"].Value = dt.Rows[i]["phone"].ToString();
                    dataGridView1.Rows[i].Cells["col_card_no"].Value = dt.Rows[i]["card_no"].ToString();
                   
                    dataGridView1.Rows[i].Cells["col_balance"].Value = dt.Rows[i]["customer_balance"].ToString();
                  
                    dataGridView1.Rows[i].Cells["col_card_type"].Value = dt.Rows[i]["card_type"].ToString();
                }
            }
            this.status = (this.mintCurrentPage + 1).ToString() + " / " + this.mintPageCount.ToString();

        }

        private void btn_back_Click(object sender, EventArgs e)
        {

        }
 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col_add"].Index && e.RowIndex >= 0)
            {
                AdminAccess acc = new AdminAccess();
                acc.ShowDialog();
                if (acc.DialogResult == DialogResult.OK)
                {
                    Customer_Management.CustomerCard_Info cci = new Customer_Management.CustomerCard_Info(Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_id"].Value.ToString()));
                    cci.ShowDialog();
                }
            }
            else if (e.ColumnIndex == dataGridView1.Columns["col_replace"].Index && e.RowIndex >= 0)
            {
                AdminAccess acc = new AdminAccess();
                acc.ShowDialog();
                panel_replace.Hide();
                if (acc.DialogResult == DialogResult.OK)
                {
                    panel_replace.Show();
                    customer_id = Convert.ToInt32((dataGridView1.CurrentRow.Cells["col_id"].Value.ToString()));
                    lbl_cardno.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["col_card_no"].Value.ToString());
                    DataTable dt = customer.GetPreviousBalance(Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_id"].Value.ToString()));
                    if (dt.Rows.Count > 0)
                    {
                        decimal card_balance = Convert.ToDecimal(dt.Rows[0]["customer_balance"].ToString());
                        lbl_blc.Text = Convert.ToString(card_balance);
                    }
                    else
                    {
                        lbl_blc.Text = "0.00";
                    }

                }
            }
            else if (e.ColumnIndex == dataGridView1.Columns["col_cash_back"].Index && e.RowIndex >= 0)
            {
                CustomerCashBack ccb = new CustomerCashBack(Convert.ToInt32((dataGridView1.CurrentRow.Cells["col_id"].Value.ToString())));
                int customer_id = Convert.ToInt32((dataGridView1.CurrentRow.Cells["col_id"].Value.ToString()));
                ccb.lbl_customer.Text = dataGridView1.CurrentRow.Cells["col_name"].Value.ToString() + dataGridView1.CurrentRow.Cells["col_last_name"].Value.ToString();
                ccb.card_type = dataGridView1.CurrentRow.Cells["col_card_type"].Value.ToString();
                ccb.lbl_customer_no.Text = dataGridView1.CurrentRow.Cells["col_card_no"].Value.ToString();
                DataTable dt = customer.GetPreviousBalance(Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_id"].Value.ToString()));

                if (dt.Rows.Count > 0)
                {
                    decimal card_balance = Convert.ToDecimal(dt.Rows[0]["customer_balance"].ToString());
                    ccb.lbl_id.Text = dataGridView1.CurrentRow.Cells["col_id"].Value.ToString();
                    ccb.txt_card_blc.Text = Convert.ToString(card_balance);
                    ccb.ShowDialog();
                    if (ccb.btn_save.DialogResult == DialogResult.OK)
                    {
                        Loadcustomer();
                    }
                }
                else
                {
                    MessageBox.Show("Sorry Customer Have 0.00 Balance.", "Transaction Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void txt_searchbox_TextChanged(object sender, EventArgs e)
        {

            DataTable dt = customer.Searchbycard(txt_searchbox.Text);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    // lbl_id.Text = dt.Rows[i]["id"].ToString();

                    dataGridView1.Rows[i].Cells["col_id"].Value = dt.Rows[i]["id"].ToString();
                    int customer_id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                    dataGridView1.Rows[i].Cells["col_name"].Value = dt.Rows[i]["name"].ToString();
                    dataGridView1.Rows[i].Cells["col_last_name"].Value = dt.Rows[i]["lastname"].ToString();
                    dataGridView1.Rows[i].Cells["col_phone"].Value = dt.Rows[i]["phone"].ToString();
                    dataGridView1.Rows[i].Cells["col_card_no"].Value = dt.Rows[i]["card_no"].ToString();
                    dataGridView1.Rows[i].Cells["col_card_type"].Value = dt.Rows[i]["card_type"].ToString();
                    DataTable dt1 = customer.GetPreviousBalance(customer_id);
                    if (dt1.Rows.Count>0)
                    {
                        dataGridView1.Rows[i].Cells["col_balance"].Value = dt1.Rows[0]["customer_balance"].ToString();
                    }
                  
                }
            }
           }

        private void btn_export_to_pdf_Click(object sender, EventArgs e)
        {

            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount - 3);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 10f);

            //Adding Header row
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index <= 5)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    pdfTable.AddCell(cell);
                }

            }
            string data;
            //Adding DataRow
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cells in row.Cells)
                {

                    if (cells.ColumnIndex <= 5)
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

            //Exporting to PDF

            //  string folderPath = "C:\\PDFs\\";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\Customer Details\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            //Random rnum = new Random();
            //String ramdomnumber = (rnum.Next(1212, 98998)).ToString();

            string Datename = DateTime.Now.ToString("dd-mm-yyyy hh");
            using (FileStream stream = new FileStream(folderPath + "Customer Details " + Datename + ".pdf", FileMode.Create))
            {
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph p = new Paragraph("Customer Details ");
                p.Alignment = 1;
                pdfDoc.Add(p);
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }

            MessageBox.Show("Data Has Been Export To Document Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            DataTable dt = customer.getallcustomersrecent();
            //foreach (DataGridViewColumn column in dataGridView1.Columns)
            //{
            //    if (column.Index <= 5)
            //    {
            //        dt.Columns.Add(column.HeaderText);
            //    }
            //}
            //string data;
            ////Adding the Rows
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    dt.Rows.Add();
            //    foreach (DataGridViewCell cell in row.Cells)
            //    {
            //        if (cell.ColumnIndex <= 5)
            //        {
            //            if (cell.Value == null)
            //            {
            //                data = "0.00";
            //            }
            //            else
            //            {
            //                data = cell.Value.ToString();
            //            }
            //            dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = data;
            //        }
            //    }
            //}

            //Exporting to Excel
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\Customer_Details Excel\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }


            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Customer List");
                wb.SaveAs(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "CustomerDetails.xlsx");

            }
        }

        private void cmb_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_search_by.Show();
        }

        private void txt_search_by_TextChanged(object sender, EventArgs e) 
        {
            if (cmb_search.Text.Length > 2)
            {
                if (cmb_search.Text == "Name")
                {
                    int intSkip = 0;
                    intSkip = (this.mintCurrentPage * this.mintPageSize);
                    fillGrid();
                    dt = customer.search_By_name(txt_search_by.Text,mintPageSize, intSkip);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add();
                            // lbl_id.Text = dt.Rows[i]["id"].ToString();

                            dataGridView1.Rows[i].Cells["col_id"].Value = dt.Rows[i]["id"].ToString();

                            dataGridView1.Rows[i].Cells["col_name"].Value = dt.Rows[i]["name"].ToString();
                            dataGridView1.Rows[i].Cells["col_last_name"].Value = dt.Rows[i]["lastname"].ToString();
                            dataGridView1.Rows[i].Cells["col_phone"].Value = dt.Rows[i]["phone"].ToString();
                            dataGridView1.Rows[i].Cells["col_card_no"].Value = dt.Rows[i]["card_no"].ToString();
                            dataGridView1.Rows[i].Cells["col_card_type"].Value = dt.Rows[i]["card_type"].ToString();
                            dataGridView1.Rows[i].Cells["col_balance"].Value = dt.Rows[i]["customer_balance"].ToString();

                        }
                    }
                }
                else if (cmb_search.Text == "Phone")
                {
                    int intSkip = 0;
                    intSkip = (this.mintCurrentPage * this.mintPageSize);
                    fillGrid();
                    dt = customer.getDataByitsPhonenumbers(txt_search_by.Text, mintPageSize, intSkip);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add();
                            // lbl_id.Text = dt.Rows[i]["id"].ToString();

                            dataGridView1.Rows[i].Cells["col_id"].Value = dt.Rows[i]["id"].ToString();

                            dataGridView1.Rows[i].Cells["col_name"].Value = dt.Rows[i]["name"].ToString();
                            dataGridView1.Rows[i].Cells["col_last_name"].Value = dt.Rows[i]["lastname"].ToString();
                            dataGridView1.Rows[i].Cells["col_phone"].Value = dt.Rows[i]["phone"].ToString();
                            dataGridView1.Rows[i].Cells["col_card_no"].Value = dt.Rows[i]["card_no"].ToString();
                            dataGridView1.Rows[i].Cells["col_card_type"].Value = dt.Rows[i]["card_type"].ToString();
                            dataGridView1.Rows[i].Cells["col_balance"].Value = dt.Rows[i]["customer_balance"].ToString();

                        }
                    }
                }
            }
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {
            goPrevious();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            goNext();
        }
      
        private void goPrevious()
        {
            if (this.mintCurrentPage == this.mintPageCount)
                this.mintCurrentPage = this.mintPageCount - 1;

            this.mintCurrentPage--;

            if (this.mintCurrentPage < 1)
                this.mintCurrentPage = 0;

            Loadcustomer();
        }

        private void goNext()
        {
            this.mintCurrentPage++;

            if (this.mintCurrentPage > (this.mintPageCount - 1))
                this.mintCurrentPage = this.mintPageCount - 1;

            Loadcustomer();
        }
        public void fillGrid()
        {
           
                // For Page view.
                this.mintPageSize = 50;
                DataTable dtcount = customer.countTotalCUstomer();
                 this.mintTotalRecords = Convert.ToInt32(dtcount.Rows[0][0]);
                this.mintPageCount = mintTotalRecords / this.mintPageSize;

                // Adjust page count if the last page contains partial page.
                if (mintTotalRecords % this.mintPageSize > 0)
                    this.mintPageCount++;

                this.mintCurrentPage = 0;
         
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            int update_customer = blcr.Update_Customer(customer_id, txt_newcard.Text);
            DataTable dt = blcr.GetcustomerSales(lbl_cardno.Text);
            if (dt.Rows.Count>0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int bill_no =Convert.ToInt32(dt.Rows[i]["bill_no"].ToString());
                    int update = blcr.Update_Cardno(bill_no, txt_newcard.Text);
                }
            }
          
            int insertreplace = blcr.Insert_Card_Replace(customer_id, lbl_cardno.Text, txt_newcard.Text, Convert.ToDateTime(today),Convert.ToDecimal(lbl_blc.Text));
            if (insertreplace>0)
            {
                MessageBox.Show("Successfully Card Renew !!", "Successful Insert Alert !!");
                panel_replace.Hide();
                txt_newcard.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel_replace.Hide();
        }

        private void btn_topup_Click(object sender, EventArgs e)
        {
            AdminAccess acc = new AdminAccess();
            acc.ShowDialog();
            if (acc.DialogResult == DialogResult.OK)
            {
                panel_topup.Show();
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
          
                DialogResult dialogResult = MessageBox.Show("Are You Sure To Topup Balance In All Card??", "Topup All Card !!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DataTable dt = customer.GetCustomerwithcardno();

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                        int id = Convert.ToInt32(dt.Rows[i]["id"].ToString());
                        int insert = customer.Insert_add_balance(id, Login.sendtext, Convert.ToDecimal(txt_topup.Text), Convert.ToDateTime(DateTime.Now.ToLongTimeString()), "X", "Cash","All Topup");

                        int update = customer.UpdateCardBalance(id,Convert.ToDecimal(txt_topup.Text));
                        if (update==0)
                        {
                            int insertblc = customer.Insert_balance(id, Convert.ToDecimal(txt_topup.Text), "true", Convert.ToDecimal(0.00), "Inactive", Convert.ToDecimal(0.00), "Inactive");

                        }
                        
                    }
                   
                       MessageBox.Show("Successfully Update Alert !!", "Success Alert !!");
                    Loadcustomer();
                    panel_topup.Hide();
                }
                }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            panel_topup.Hide();
        }
    }
    }


