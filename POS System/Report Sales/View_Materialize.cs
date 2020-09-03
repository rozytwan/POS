using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLS;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ClosedXML.Excel;

namespace POS_System
{
    public partial class View_Materialize : UserControl
    {
        public View_Materialize()
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

        private void cbo_searchTYpe_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
             if (cbo_searchTYpe.Text == "Bill No")
            {
                Billno();
            }

            else if (cbo_searchTYpe.Text == "ALL")
            {
                clearcombo(txt_searchText);
                txt_searchText.Text = "ALL";
            }
          
            else if (cbo_searchTYpe.Text == "Fiscal Year")
            {
                clearcombo(txt_searchText);
                txt_searchText.Text = "2074/75";

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
        BLL_Fiscal blfs = new BLL_Fiscal();
        private void btn_show_Click(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text == "" || cbo_searchTYpe.Text == "Choose Type" || txt_searchText.Text == "")
            {
                MessageBox.Show("The Fields are Empty or invalid.");
            }

            else
            {
                DateTime dateOne = Convert.ToDateTime(dtp_from.Text);
                DateTime datetwo = Convert.ToDateTime(dtp_to.Text);

                if (cbo_searchTYpe.Text == "Bill No")
                {
                    DataTable dt = blfs.search_materialized_by_bill(txt_searchText.Text);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int inc = 0; inc < dt.Rows.Count; inc++)
                        {
                            int ww = dataGridView1.Rows.Add();
                            dataGridView1.Rows[inc].Cells["calbill_no"].Value = dt.Rows[inc]["bill_no"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_fiscal_year"].Value = dt.Rows[inc]["fiscal_year"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_customer"].Value = dt.Rows[inc]["customer"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_customer_pan"].Value = dt.Rows[inc]["customer_pan"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_discount"].Value = dt.Rows[inc]["discount"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_amount"].Value = dt.Rows[inc]["amount"].ToString();
                           decimal taxable_amount= Convert.ToDecimal(dt.Rows[inc]["taxable_amount"].ToString());
                            decimal tax_amount = Convert.ToDecimal(dt.Rows[inc]["tax_amount"].ToString());
                            dataGridView1.Rows[inc].Cells["cal_taxable_amount"].Value = taxable_amount;
                            dataGridView1.Rows[inc].Cells["cal_tax_amount"].Value = tax_amount;
                            dataGridView1.Rows[inc].Cells["cal_total_amount"].Value = (taxable_amount + tax_amount).ToString("#.##");
                            dataGridView1.Rows[inc].Cells["cal_bill_date"].Value = dt.Rows[inc]["bill_date"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_printed_by"].Value = dt.Rows[inc]["printed_by"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_printed_time"].Value = dt.Rows[inc]["printed_time"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_is_printed"].Value = dt.Rows[inc]["is_printed"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_is_active"].Value = dt.Rows[inc]["is_active"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_enter_by"].Value = dt.Rows[inc]["entered_by"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_sync_with_ird"].Value = dt.Rows[inc]["sync_with_ird"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_is_real_time"].Value = dt.Rows[inc]["is_real_time"].ToString();
                        }
                        grandtotal();
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
                    DataTable dt = blfs.search_materialized_by_all(dateOne, datetwo);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int inc = 0; inc < dt.Rows.Count; inc++)
                        {
                            int ww = dataGridView1.Rows.Add();
                            dataGridView1.Rows[inc].Cells["calbill_no"].Value = dt.Rows[inc]["bill_no"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_fiscal_year"].Value = dt.Rows[inc]["fiscal_year"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_customer"].Value = dt.Rows[inc]["customer"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_customer_pan"].Value = dt.Rows[inc]["customer_pan"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_discount"].Value = dt.Rows[inc]["discount"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_amount"].Value = dt.Rows[inc]["amount"].ToString();
                            decimal taxable_amount = Convert.ToDecimal(dt.Rows[inc]["taxable_amount"].ToString());
                            decimal tax_amount = Convert.ToDecimal(dt.Rows[inc]["tax_amount"].ToString());
                            dataGridView1.Rows[inc].Cells["cal_taxable_amount"].Value = taxable_amount;
                            dataGridView1.Rows[inc].Cells["cal_tax_amount"].Value = tax_amount;
                            dataGridView1.Rows[inc].Cells["cal_total_amount"].Value = (taxable_amount + tax_amount).ToString("#.##");
                            dataGridView1.Rows[inc].Cells["cal_bill_date"].Value = dt.Rows[inc]["bill_date"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_printed_by"].Value = dt.Rows[inc]["printed_by"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_printed_time"].Value = dt.Rows[inc]["printed_time"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_is_printed"].Value = dt.Rows[inc]["is_printed"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_is_active"].Value = dt.Rows[inc]["is_active"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_enter_by"].Value = dt.Rows[inc]["entered_by"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_sync_with_ird"].Value = dt.Rows[inc]["sync_with_ird"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_is_real_time"].Value = dt.Rows[inc]["is_real_time"].ToString();
                        }
                        grandtotal();
                        backPanel.Show();
                    searchPanel.Hide();

                }
                else
                {
                    MessageBox.Show("No Record Found");
                }
              }
                else if (cbo_searchTYpe.Text == "Fiscal Year")
                {
                    DataTable dt = blfs.search_materialized_by_fiscal(txt_searchText.Text);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int inc = 0; inc < dt.Rows.Count; inc++)
                        {
                            int ww = dataGridView1.Rows.Add();
                            dataGridView1.Rows[inc].Cells["calbill_no"].Value = dt.Rows[inc]["bill_no"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_fiscal_year"].Value = dt.Rows[inc]["fiscal_year"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_customer"].Value = dt.Rows[inc]["customer"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_customer_pan"].Value = dt.Rows[inc]["customer_pan"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_discount"].Value = dt.Rows[inc]["discount"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_amount"].Value = dt.Rows[inc]["amount"].ToString();
                            decimal taxable_amount = Convert.ToDecimal(dt.Rows[inc]["taxable_amount"].ToString());
                            decimal tax_amount = Convert.ToDecimal(dt.Rows[inc]["tax_amount"].ToString());
                            dataGridView1.Rows[inc].Cells["cal_taxable_amount"].Value = taxable_amount;
                            dataGridView1.Rows[inc].Cells["cal_tax_amount"].Value = tax_amount;
                            dataGridView1.Rows[inc].Cells["cal_total_amount"].Value = (taxable_amount + tax_amount).ToString("#.##");
                            dataGridView1.Rows[inc].Cells["cal_bill_date"].Value = dt.Rows[inc]["bill_date"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_printed_by"].Value = dt.Rows[inc]["printed_by"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_printed_time"].Value = dt.Rows[inc]["printed_time"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_is_printed"].Value = dt.Rows[inc]["is_printed"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_is_active"].Value = dt.Rows[inc]["is_active"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_enter_by"].Value = dt.Rows[inc]["entered_by"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_sync_with_ird"].Value = dt.Rows[inc]["sync_with_ird"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_is_real_time"].Value = dt.Rows[inc]["is_real_time"].ToString();
                        }
                        grandtotal();
                        backPanel.Show();
                        searchPanel.Hide();

                    }
                    else
                    {
                        MessageBox.Show("No Record Found");
                    }
                }
               
            }
        }

        private void View_Materialize_Load(object sender, EventArgs e)
        {
            dtp_from.Value = DateTime.Now;
            dtp_to.Value = DateTime.Now;
           // this.Width = this.Parent.Width;          
            backPanel.Hide();
            searchPanel.Show();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            backPanel.Hide();
            searchPanel.Show();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            allmenu alls = new allmenu();
            ctls.Controls.Clear();
            ctls.Controls.Add(alls);
        }

        private void btnbackpage_Click(object sender, EventArgs e)
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
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            PdfPCell cell = new PdfPCell();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {

                if (column.Index <= 16)
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
                    if (cells.ColumnIndex <= 16)
                    {
                        pdfTable.AddCell(cells.Value.ToString() ?? string.Empty);
                    }
                }
            }

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\Restaurant Materialize Sales Report\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string Datename = DateTime.Now.ToString("dd-mm-yyyy hh");
            using (FileStream stream = new FileStream(folderPath + "Restaurant Materialize" + Datename + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                pdfDoc.Header = new HeaderFooter(new Phrase("Header Text"), false);
                pdfDoc.Open();
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph pheading = new Paragraph("Materialized Report");
                Paragraph pheading_business_name = new Paragraph(Business_Name);
                Paragraph pheading_pan_no = new Paragraph("Pan No :" + pan_no);
                Paragraph pheadingDate = new Paragraph("From:     " + dtp_from.Text + "                                        " + "To:      " + dtp_to.Text);
                pheading.Alignment = Element.TITLE;
                pheading_business_name.Alignment = Element.TITLE;
                pheading_pan_no.Alignment = Element.TITLE;
                pheading.Alignment = Element.TITLE;
                Paragraph pheading_space = new Paragraph("   ");
                Paragraph p = new Paragraph("Total:-                                                                " + lblgrand_total.Text +"        " +lbl_taxable_amount.Text+"       "+lbl_tax_amount.Text );
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
        public void grandtotal()
        {           
            lblgrand_total.Text = (dataGridView1.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDecimal(t.Cells["cal_total_amount"].Value))).ToString();
            lbl_tax_amount.Text = (dataGridView1.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDecimal(t.Cells["cal_tax_amount"].Value))).ToString();
            lbl_taxable_amount.Text = (dataGridView1.Rows.Cast<DataGridViewRow>().Sum(t => Convert.ToDecimal(t.Cells["cal_taxable_amount"].Value))).ToString();
        }
        private void btn_excel_Click(object sender, EventArgs e)
        {
            //ExporyToExcel(btn_export_toexcel, "ExportedUserDetail");
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index <= 14)
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
                    if (cell.ColumnIndex <= 14)
                    {
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                    }
                }
            }

            //Exporting to Excel
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\Materialize View\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Sales Report");
                wb.SaveAs(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "Materialize_View.xlsx");
            }
        }

        private void btn_text_export_Click(object sender, EventArgs e)
        {

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\Materialize View\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            TextWriter sw = new StreamWriter(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "Materialize_View.txt");
            int rowcount = dataGridView1.Rows.Count;
            DataTable dt = blu.checkbusiness();
            if (dt.Rows.Count > 0)
            {
                Business_Name = dt.Rows[0]["business_name"].ToString();
                pan_no = dt.Rows[0]["pan_no"].ToString();
            }
            sw.WriteLine("                         " + Business_Name + "            ");
            sw.WriteLine("                       Pan No:  " + pan_no + "            ");
            sw.WriteLine("Date From: " + dtp_from.Text + "            Date To: " + dtp_to.Text);
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
        DataTable dt_xml = new DataTable();
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
            dt_xml.TableName = "MyTable";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\Materialize View\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            dt_xml.WriteXml(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "Materialize_View.xml", XmlWriteMode.WriteSchema);
            MessageBox.Show("Data Exported To XML");
            dt_xml.Clear();
        }
    }
}
