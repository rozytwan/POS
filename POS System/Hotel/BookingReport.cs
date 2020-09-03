using BLLS.Hotel;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using iTextSharp.text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLS;
using ClosedXML.Excel;

namespace POS_System
{
    public partial class BookingReport : UserControl
    {
        public BookingReport()
        {
            InitializeComponent();
        }
        BLL_Report bllreport = new BLL_Report();
        BLLUser blu = new BLLUser();
        string today = DateTime.Now.ToString();
        private void BookingReport_Load(object sender, EventArgs e)
        {
            searchPanel.Show();
            backPanel.Hide();
            cmb_search.SelectedIndex = 0;
            dtp_from.Text = today;
            dtp_to.Text = today;
            cbo_searchTYpe.SelectedIndex = 0;
           // LoadBooking();
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text=="Check In")
            {
                DataTable dt = bllreport.SearchCheckin(Convert.ToDateTime(dtp_from.Text), Convert.ToDateTime(dtp_to.Text));
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["col_customer"].Value = dt.Rows[i][0].ToString();
                        dataGridView1.Rows[i].Cells["col_contact"].Value = dt.Rows[i][1].ToString();
                        dataGridView1.Rows[i].Cells["col_country"].Value = dt.Rows[i][2].ToString();
                        dataGridView1.Rows[i].Cells["col_booking"].Value = dt.Rows[i][3].ToString();
                        dataGridView1.Rows[i].Cells["col_room_no"].Value = dt.Rows[i][4].ToString();
                        dataGridView1.Rows[i].Cells["col_checkin"].Value = dt.Rows[i][5].ToString();
                        dataGridView1.Rows[i].Cells["col_checkout"].Value = dt.Rows[i][6].ToString();


                    }
                    searchPanel.Hide();
                    backPanel.Show();
                }
            }
            else if (cbo_searchTYpe.Text == "Check Out")
            {
                DataTable dt = bllreport.SearchCheckout(Convert.ToDateTime(dtp_from.Text), Convert.ToDateTime(dtp_to.Text));
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["col_customer"].Value = dt.Rows[i][0].ToString();
                        dataGridView1.Rows[i].Cells["col_contact"].Value = dt.Rows[i][1].ToString();
                        dataGridView1.Rows[i].Cells["col_country"].Value = dt.Rows[i][2].ToString();
                        dataGridView1.Rows[i].Cells["col_booking"].Value = dt.Rows[i][3].ToString();
                        dataGridView1.Rows[i].Cells["col_room_no"].Value = dt.Rows[i][4].ToString();
                        dataGridView1.Rows[i].Cells["col_checkin"].Value = dt.Rows[i][5].ToString();
                        dataGridView1.Rows[i].Cells["col_checkout"].Value = dt.Rows[i][6].ToString();


                    }
                    searchPanel.Hide();
                    backPanel.Show();
                }
            }
  
        }
        public void LoadBooking()
        {
            //dtp_date.Hide();
            DataTable dt = bllreport.GetBooking();
            {
                if (dt.Rows.Count>0)
                {
                   // dataGridView1.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                         dataGridView1.Rows[i].Cells["col_customer"].Value = dt.Rows[i][0].ToString();
                        dataGridView1.Rows[i].Cells["col_contact"].Value = dt.Rows[i][1].ToString();
                        dataGridView1.Rows[i].Cells["col_country"].Value = dt.Rows[i][2].ToString();
                        dataGridView1.Rows[i].Cells["col_booking"].Value = dt.Rows[i][3].ToString();
                        dataGridView1.Rows[i].Cells["col_room_no"].Value = dt.Rows[i][4].ToString();
                        dataGridView1.Rows[i].Cells["col_checkin"].Value = dt.Rows[i][5].ToString();
                        dataGridView1.Rows[i].Cells["col_checkout"].Value = dt.Rows[i][6].ToString();
                    }
                }
            }
        }
        private void txt_search_by_TextChanged(object sender, EventArgs e)
        {
            if (cmb_search.Text.Length > 2)
            {
                if (cmb_search.Text == "Name")
                {
                    //dtp_date.Hide();
                    DataTable dt = bllreport.SimilarName(txt_search_by.Text);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["col_customer"].Value = dt.Rows[i][0].ToString();
                            dataGridView1.Rows[i].Cells["col_contact"].Value = dt.Rows[i][1].ToString();
                            dataGridView1.Rows[i].Cells["col_country"].Value = dt.Rows[i][2].ToString();
                            dataGridView1.Rows[i].Cells["col_booking"].Value = dt.Rows[i][3].ToString();
                            dataGridView1.Rows[i].Cells["col_room_no"].Value = dt.Rows[i][4].ToString();
                            dataGridView1.Rows[i].Cells["col_checkin"].Value = dt.Rows[i][5].ToString();
                            dataGridView1.Rows[i].Cells["col_checkout"].Value = dt.Rows[i][6].ToString();

                        }
                    }
                }
            
            else if (cmb_search.Text == "Phone")
            {
                DataTable dt = bllreport.Similarphone(txt_search_by.Text);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["col_customer"].Value = dt.Rows[i][0].ToString();
                            dataGridView1.Rows[i].Cells["col_contact"].Value = dt.Rows[i][1].ToString();
                            dataGridView1.Rows[i].Cells["col_country"].Value = dt.Rows[i][2].ToString();
                            dataGridView1.Rows[i].Cells["col_booking"].Value = dt.Rows[i][3].ToString();
                            dataGridView1.Rows[i].Cells["col_room_no"].Value = dt.Rows[i][4].ToString();
                            dataGridView1.Rows[i].Cells["col_checkin"].Value = dt.Rows[i][5].ToString();
                            dataGridView1.Rows[i].Cells["col_checkout"].Value = dt.Rows[i][6].ToString();
                        }
                    
                }
            }
            }
   
        }


        private void dtp_date_ValueChanged(object sender, EventArgs e)
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

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\HotelBookingReport\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string Datename = DateTime.Now.ToString("dd-mm-yyyy hh");
            using (FileStream stream = new FileStream(folderPath + "HotelBookingReport " + Datename + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                pdfDoc.Header = new HeaderFooter(new Phrase("Header Text"), false);
                pdfDoc.Open();
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph pheading = new Paragraph("Hotel Booking Report");
                Paragraph pheading_business_name = new Paragraph(Business_Name);
                Paragraph pheading_pan_no = new Paragraph("Pan No :" + pan_no);
                Paragraph pheadingDate = new Paragraph("From:     " + dtp_from.Text + "                                        " + "To:      " + dtp_to.Text);
                pheading.Alignment = Element.TITLE;
                pheading_business_name.Alignment = Element.TITLE;
                pheading_pan_no.Alignment = Element.TITLE;
                pheading.Alignment = Element.TITLE;
                Paragraph pheading_space = new Paragraph("   ");
                Paragraph p = new Paragraph();
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

        private void btn_back_Click(object sender, EventArgs e)
        {

        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            //Adding the Columns
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index <= 7)
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
                    if (cell.ColumnIndex <=7)
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
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\HotelBookingReport Excel\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Hotel Booking Record");
                wb.SaveAs(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "HotelBooking.xlsx");
                MessageBox.Show("Your Hotel Booking excel report has been export to document", "Hotel Booking Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
    }

