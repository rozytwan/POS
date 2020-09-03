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
    public partial class ViewUserLog : UserControl
    {
        public ViewUserLog()
        {
            InitializeComponent();
        }
        BLL_user_log bul = new BLL_user_log();
        BLL_Login_logout blog = new BLL_Login_logout();
        BLLUser blu = new BLLUser();
        private void ViewUserLog_Load(object sender, EventArgs e)
        {
            get_customer_name();
            dtp_from.Value = DateTime.Now;
            dtp_to.Value = DateTime.Now;
            panel1.Hide();
            searchPanel.Show();
        }

        public void get_customer_name()
        {
            DataTable dt = blu.getalluser();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                DataRow drm = dt.NewRow();
                dr["user_name"] = "Choose One";
                drm["user_name"] = "ALL";
                dt.Rows.InsertAt(drm, 1);
                dt.Rows.InsertAt(dr, 0);
                cbo_user_name.DataSource = dt;
                cbo_user_name.DisplayMember = "user_name";

            }
        }
       

        private void btn_show_Click(object sender, EventArgs e)
        {
            if (cbo_user_name.Text != "" || cbo_user_name.Text == "Choose One")
            {
                DateTime date_from = Convert.ToDateTime(dtp_from.Text);
                DateTime date_to = Convert.ToDateTime(dtp_to.Text);
                if (cbo_user_name.Text == "ALL")
                {
                    DataTable dt = bul.get_all_data_by_date_user_log(date_from, date_to);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; dt.Rows.Count > i; i++)
                        {
                            int ac = dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["cal_activity_date"].Value = dt.Rows[i]["activity_date"].ToString();
                            dataGridView1.Rows[i].Cells["cal_activity_day"].Value = dt.Rows[i]["activity_day"].ToString();
                            dataGridView1.Rows[i].Cells["cal_user_activity"].Value = dt.Rows[i]["user_activity"].ToString();
                            dataGridView1.Rows[i].Cells["cal_user_name"].Value = dt.Rows[i]["user_name"].ToString();
                        }
                        panel1.Show();
                        searchPanel.Hide();
                    }
                }
                else
                {
                    DataTable dt = bul.get_all_data_by_date_by_user_log(date_from, date_to, cbo_user_name.Text);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; dt.Rows.Count > i; i++)
                        {
                            int ac = dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["cal_activity_date"].Value = dt.Rows[i]["activity_date"].ToString();
                            dataGridView1.Rows[i].Cells["cal_activity_day"].Value = dt.Rows[i]["activity_day"].ToString();
                            dataGridView1.Rows[i].Cells["cal_user_activity"].Value = dt.Rows[i]["user_activity"].ToString();
                            dataGridView1.Rows[i].Cells["cal_user_name"].Value = dt.Rows[i]["user_name"].ToString();
                        }
                        panel1.Show();
                        searchPanel.Hide();
                    }

                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            panel1.Hide();
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

                if (column.Index <= 3)
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
                    if (cells.ColumnIndex <= 3)
                    {
                        pdfTable.AddCell(cells.Value.ToString() ?? string.Empty);
                    }
                }
            }

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\User Log PDF Report\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string Datename = DateTime.Now.ToString("dd-mm-yyyy hh");
            using (FileStream stream = new FileStream(folderPath + "User Log" + Datename + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                pdfDoc.Header = new HeaderFooter(new Phrase("Header Text"), false);
                pdfDoc.Open();
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph pheading = new Paragraph("User Log");
                Paragraph pheading_business_name = new Paragraph(Business_Name);
                Paragraph pheading_pan_no = new Paragraph("Pan No :" + pan_no);
                Paragraph pheadingDate = new Paragraph("From:     " + dtp_from.Text + "                                        " + "To:      " + dtp_to.Text);
                pheading.Alignment = Element.TITLE;
                pheading_business_name.Alignment = Element.TITLE;
                pheading_pan_no.Alignment = Element.TITLE;
                pheading.Alignment = Element.TITLE;
                Paragraph pheading_space = new Paragraph("   ");
               
               
                pdfDoc.Add(pheading);
                pdfDoc.Add(pheading_business_name);
                pdfDoc.Add(pheading_pan_no);
                pdfDoc.Add(pheadingDate);
                pdfDoc.Add(pheading_space);
                pdfDoc.Add(pdfTable);
               
                pdfDoc.Close();
                stream.Close();
            }

            MessageBox.Show("Data Has Been Export To Document");
        }
        DataTable dt_xml = new DataTable();
        private void btn_export_XML_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index < 4)
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
                    if (cell.ColumnIndex < 4)
                    {
                        dt_xml.Rows[dt_xml.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                    }
                }
            }
            dt_xml.TableName = "MyTable";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\User Log XML\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            dt_xml.WriteXml(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "User Log.xml", XmlWriteMode.WriteSchema);
            MessageBox.Show("Data Exported To XML");
            dt_xml.Clear();
        }

        private void btn_text_export_Click(object sender, EventArgs e)
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\User Log Text\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            TextWriter sw = new StreamWriter(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "User Log.txt");
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
                                
                                    
                               );
            }
            sw.Close();
            MessageBox.Show("Data Has Been Export In Text File");
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index <= 3)
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
                    if (cell.ColumnIndex <= 3)
                    {
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                    }
                }
            }

            //Exporting to Excel
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\User Log Excel\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Sales Report");
                wb.SaveAs(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "User Log.xlsx");
            }
        }
    }
}
