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
    public partial class CustomerDetail : UserControl
    {
        BLLcustomer_credit blcustom = new BLLcustomer_credit();
        BLLUser blu = new BLLUser();
        public CustomerDetail()
        {
            InitializeComponent();
        }
        string credit_load = second_user_interface.creditload;
        decimal sumtotal = 0;
        decimal sumqty_credit= 0;
        decimal sumqty_paid = 0;
        decimal sumqty_remaining = 0;
        public void LoadCustomerCredit()
        {
            if (credit_load == "Hotel Credit")
            {
                DataTable dt = blcustom.Get_Hotel_Credit_Groupbyid(customer_id);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int abc = dataGridView1.Rows.Add();
                        int customer_id = Convert.ToInt32(dt.Rows[i]["customer_id"].ToString());
                        DataTable dt1 = blcustom.Get_Customer_ById(customer_id);
                        DataTable dt2 = blcustom.Get_hotelcustomer_paidsum(customer_id);
                        DataTable dt3 = blcustom.Get_Hotel_CreditLeft(customer_id);
                        if (dt1.Rows.Count > 0)
                        {
                            dataGridView1.Rows[i].Cells["col_customer_id"].Value = dt1.Rows[0]["id"].ToString();

                            dataGridView1.Rows[i].Cells["col_customer_name"].Value = dt1.Rows[0]["name"].ToString() + " " + dt1.Rows[0]["lastname"].ToString();
                            dataGridView1.Rows[i].Cells["col_customer_phone"].Value = dt1.Rows[0]["phone"].ToString();
                            dataGridView1.Rows[i].Cells["col_customer_address"].Value = dt1.Rows[0]["address"].ToString();
                        }
                        if (dt2.Rows.Count > 0)
                        {
                            dataGridView1.Rows[i].Cells["col_paid"].Value = dt2.Rows[0][0].ToString();
                            if (dt2.Rows[0][0].ToString() != "")
                            {
                                paid = Convert.ToDecimal(dt2.Rows[0][0].ToString());
                            }
                        }
                        dataGridView1.Rows[i].Cells["col_credit_amount"].Value = dt.Rows[i]["sum_credit_amount"].ToString();
                        credit = Convert.ToDecimal(dt.Rows[i]["sum_credit_amount"].ToString());
                        if (dt3.Rows.Count > 0)
                        {
                            dataGridView1.Rows[i].Cells["col_remaining"].Value = dt3.Rows[0]["credit_left"].ToString();
                        }
                      
                    }

                }
                TotalsumCredit();
            }
            else
            {
                DataTable dt = blcustom.Get_Data_ByGrouping_Customer_Id(customer_id);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int abc = dataGridView1.Rows.Add();
                        int customer_id = Convert.ToInt32(dt.Rows[i]["customer_id"].ToString());
                        DataTable dt1 = blcustom.Get_Customer_ById(customer_id);
                        DataTable dt2 = blcustom.Get_Customer_paidsum(customer_id);
                        DataTable dt3 = blcustom.Get_Credit_Left(customer_id);
                        if (dt1.Rows.Count > 0)
                        {
                            dataGridView1.Rows[i].Cells["col_customer_id"].Value = dt1.Rows[0]["id"].ToString();

                            dataGridView1.Rows[i].Cells["col_customer_name"].Value = dt1.Rows[0]["name"].ToString() + " " + dt1.Rows[0]["lastname"].ToString();
                            dataGridView1.Rows[i].Cells["col_customer_phone"].Value = dt1.Rows[0]["phone"].ToString();
                            dataGridView1.Rows[i].Cells["col_customer_address"].Value = dt1.Rows[0]["address"].ToString();
                        }
                        if (dt2.Rows.Count>0)
                        {
                            dataGridView1.Rows[i].Cells["col_paid"].Value = dt2.Rows[0][0].ToString();
                            if (dt2.Rows[0][0].ToString() != "")
                            {
                                paid = Convert.ToDecimal(dt2.Rows[0][0].ToString());
                            }
                           
                        }
                        dataGridView1.Rows[i].Cells["col_credit_amount"].Value = dt.Rows[i]["sum_credit_amount"].ToString();
                        credit = Convert.ToDecimal(dt.Rows[i]["sum_credit_amount"].ToString());
                        if (dt3.Rows.Count > 0)
                        {
                            dataGridView1.Rows[i].Cells["col_remaining"].Value =credit-paid;
                           
                        }
                       
                    
                    }

                }
               TotalsumCredit();
            }
        }

        public void TotalsumCredit()
        {
            if (lbl_credit.Text != "")
            {
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)

                {

                    sumqty_credit += Convert.ToDecimal(dataGridView1.Rows[i].Cells[3].Value);

                }
                lbl_credit.Text = sumqty_credit.ToString();
            }
            else
            {
                lbl_credit.Text = "0.00";
            }
            if (lbl_remaining.Text != "")
            {
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)

                {

                    sumqty_remaining += Convert.ToDecimal(dataGridView1.Rows[i].Cells[5].Value);

                }
                lbl_remaining.Text = sumqty_remaining.ToString();
            }
            else
            {
                lbl_remaining.Text = "0.00";
            }
            if (lbl_paid.Text != "")
            {
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)

                {
                    if (dataGridView1.Rows[i].Cells[4].Value=="")
                    {
                        dataGridView1.Rows[i].Cells[4].Value = "0.00";
                    }
                    sumqty_paid += Convert.ToDecimal(dataGridView1.Rows[i].Cells[4].Value);

                }
                lbl_paid.Text = sumqty_paid.ToString();
            }
            else
            {
                lbl_paid.Text = "0.00";
            }
        }
        private void CustomerDetail_Load(object sender, EventArgs e)
        {
            LoadCustomerCredit();
        }
        public static int customer_id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col_view"].Index)
            {
               
                 customer_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_customer_id"].Value);

                Control ctls = this.Parent;
                AllCreditsLists cl = new AllCreditsLists();
                ctls.Controls.Clear();
                ctls.Controls.Add(cl);
            }
        }

        private void btn_clearall_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount-2);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            PdfPCell cell = new PdfPCell();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                if (column.Index <= 5)
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

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\AllCustomerCredits\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string Datename = DateTime.Now.ToString("dd-mm-yyyy hh");
            using (FileStream stream = new FileStream(folderPath + "AllCustomerCredits " + Datename + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                pdfDoc.Header = new HeaderFooter(new Phrase("Header Text"), false);
                pdfDoc.Open();
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph pheading = new Paragraph("Customer Credit Reports");
                Paragraph pheading_business_name = new Paragraph(Business_Name);
                Paragraph pheading_pan_no = new Paragraph("Pan No :" + pan_no);
                Paragraph pheadingDate = new Paragraph(" ");
                pheading.Alignment = Element.TITLE;
                pheading_business_name.Alignment = Element.TITLE;
                pheading_pan_no.Alignment = Element.TITLE;
                pheading.Alignment = Element.TITLE;
                Paragraph pheading_space = new Paragraph("   ");
                Paragraph p = new Paragraph(" ");
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
                if (column.Index <= 5)
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
                    if (cell.ColumnIndex <= 5)
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
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\AllCustomerCredit Excel\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }


            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, Business_Name);
                wb.SaveAs(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "AllCustomerCredit.xlsx");
                MessageBox.Show("Your customer credit excel report has been export to document", "Customer Credit Export", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {

        }
        decimal credit;
        decimal paid;
        private void txt_search_TextChanged(object sender, EventArgs e)
      {
            if (credit_load == "Hotel Credit")
            {
             if (txt_search.Text.Length >2)
               {
                DataTable dt = blcustom.Search_Hotel_CustomerCredit(txt_search.Text);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int abc = dataGridView1.Rows.Add();
                            int customer_id = Convert.ToInt32(dt.Rows[i]["customer_id"].ToString());
                            DataTable dt2 = blcustom.Get_Customer_paidsum(customer_id);
                            DataTable dt3 = blcustom.Get_Credit_Left(customer_id);
                            if (dt.Rows.Count > 0)
                            {
                                dataGridView1.Rows[i].Cells["col_customer_id"].Value = dt.Rows[0]["id"].ToString();

                                dataGridView1.Rows[i].Cells["col_customer_name"].Value = dt.Rows[0]["name"].ToString()+" "+ dt.Rows[0]["lastname"].ToString();
                                dataGridView1.Rows[i].Cells["col_customer_phone"].Value = dt.Rows[0]["phone"].ToString();
                                dataGridView1.Rows[i].Cells["col_customer_address"].Value = dt.Rows[0]["address"].ToString();
                            }
                            if (dt2.Rows.Count > 0)
                            {
                                dataGridView1.Rows[i].Cells["col_paid"].Value = dt2.Rows[0][0].ToString();
                                if (dt2.Rows[0][0].ToString() != "")
                                {
                                    paid = Convert.ToDecimal(dt2.Rows[0][0].ToString());
                                }

                            }
                            dataGridView1.Rows[i].Cells["col_credit_amount"].Value = dt.Rows[i]["credit_amount"].ToString();
                            credit = Convert.ToDecimal(dt.Rows[i]["credit_amount"].ToString());
                            if (dt3.Rows.Count > 0)
                            {
                                dataGridView1.Rows[i].Cells["col_remaining"].Value = credit-paid;
                            }
                        }
                    }
                }
            }
            else
            {
              if (txt_search.Text.Length >2)
                {
                    DataTable dt = blcustom.Search_by_CustomerCredit(txt_search.Text);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            int abc = dataGridView1.Rows.Add();
                            int customer_id = Convert.ToInt32(dt.Rows[i]["customer_id"].ToString());
                            DataTable dt2 = blcustom.Get_Customer_paidsum(customer_id);
                            DataTable dt3 = blcustom.Get_Credit_Left(customer_id);
                            if (dt.Rows.Count > 0)
                            {
                                dataGridView1.Rows[i].Cells["col_customer_id"].Value = dt.Rows[0]["id"].ToString();

                                dataGridView1.Rows[i].Cells["col_customer_name"].Value = dt.Rows[0]["name"].ToString() + " " + dt.Rows[0]["lastname"].ToString();
                                dataGridView1.Rows[i].Cells["col_customer_phone"].Value = dt.Rows[0]["phone"].ToString();
                                dataGridView1.Rows[i].Cells["col_customer_address"].Value = dt.Rows[0]["address"].ToString();
                            }
                            if (dt2.Rows.Count > 0)
                            {
                                dataGridView1.Rows[i].Cells["col_paid"].Value = dt2.Rows[0][0].ToString();
                                if (dt2.Rows[0][0].ToString() != "")
                                {
                                    paid = Convert.ToDecimal(dt2.Rows[0][0].ToString());
                                }
                            }
                            dataGridView1.Rows[i].Cells["col_credit_amount"].Value = dt.Rows[i]["credit_amount"].ToString();
                            credit = Convert.ToDecimal(dt.Rows[i]["credit_amount"].ToString());
                            if (dt3.Rows.Count > 0)
                            {
                                dataGridView1.Rows[i].Cells["col_remaining"].Value = credit-paid;
                            }
                           

                        }
                    }
                }
            }
        }
    }
}
