using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLS;

using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace POS_System
{
    public partial class ViewLoginLogout : UserControl
    {
        public ViewLoginLogout()
        {
            InitializeComponent();
        }
        blllCustomerDetailednyo blcus = new blllCustomerDetailednyo();
        BLL_Login_logout blog = new BLL_Login_logout();
        BLLUser blu = new BLLUser();
        private void ViewLoginLogout_Load(object sender, EventArgs e)
        {
            dtp_from.Value = DateTime.Now;
            dtp_to.Value = DateTime.Now;            
            get_customer_name();
            panel1.Hide();
            panel3.Show();
            //dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(11, 81, 126);
            //dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeight = 60;
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
        string login_time;
        string logout_time;
        private void btn_show_Click(object sender, EventArgs e)
        {
            if (cbo_user_name.Text != "" || cbo_user_name.Text=="Choose One")
            {
                DateTime date_from = Convert.ToDateTime(dtp_from.Text);
                DateTime date_to = Convert.ToDateTime(dtp_to.Text);
                if (cbo_user_name.Text == "ALL")
                {
                    DataTable dt = blog.get_all_data_by_date(date_from, date_to);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; dt.Rows.Count > i; i++)
                        {
                            int abc = dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["cal_sn"].Value = (i + 1).ToString();
                            dataGridView1.Rows[i].Cells["cal_name"].Value = dt.Rows[i]["staff_name"].ToString();
                            dataGridView1.Rows[i].Cells["cal_day"].Value = dt.Rows[i]["working_day"].ToString();
                            DateTime date_only = Convert.ToDateTime(dt.Rows[i]["working_date"].ToString());
                            dataGridView1.Rows[i].Cells["cal_date"].Value = date_only.ToString("dd/MM/yyyy");
                            dataGridView1.Rows[i].Cells["cal_session_id"].Value = dt.Rows[i]["session_id"].ToString();
                            DataTable dtm = blog.get_all_Login__time(date_from, date_to, dataGridView1.Rows[i].Cells["cal_session_id"].Value.ToString());
                            if (dtm.Rows.Count > 0)
                            {
                                login_time = dtm.Rows[0]["working_time"].ToString();
                            }
                            DataTable dt_logout = blog.get_all_logout_time(date_from, date_to, dataGridView1.Rows[i].Cells["cal_session_id"].Value.ToString());
                            if (dt_logout.Rows.Count > 0)
                            {
                                logout_time = dt_logout.Rows[0]["working_time"].ToString();
                            }
                            dataGridView1.Rows[i].Cells["cal_time"].Value = login_time + " - " + logout_time;
                            DateTime dt_login_time = Convert.ToDateTime(login_time);
                            DateTime dt_logout_time = Convert.ToDateTime(logout_time);
                            decimal dt_total_hours = Convert.ToDecimal((dt_login_time - dt_logout_time).TotalHours);
                            dataGridView1.Rows[i].Cells["cal_total_time"].Value = Math.Abs(Math.Round(dt_total_hours, 2, MidpointRounding.AwayFromZero));
                        }
                        panel1.Show();
                        panel3.Hide();

                    }
                    else
                    {

                    }
                }
                else
                {
                    DataTable dt = blog.get_all_data_by_date_by_user(date_from, date_to,cbo_user_name.Text);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; dt.Rows.Count > i; i++)
                        {                          
                            int abc = dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["cal_sn"].Value = (i + 1).ToString();
                            dataGridView1.Rows[i].Cells["cal_name"].Value = dt.Rows[i]["staff_name"].ToString();
                            dataGridView1.Rows[i].Cells["cal_day"].Value = dt.Rows[i]["working_day"].ToString();
                            DateTime date_only = Convert.ToDateTime(dt.Rows[i]["working_date"].ToString());
                            dataGridView1.Rows[i].Cells["cal_date"].Value = date_only.ToString("dd/MM/yyyy");
                            dataGridView1.Rows[i].Cells["cal_session_id"].Value = dt.Rows[i]["session_id"].ToString();
                            DataTable dtm = blog.get_all_Login__time_customer(date_from, date_to, dataGridView1.Rows[i].Cells["cal_session_id"].Value.ToString(),cbo_user_name.Text);
                            if (dtm.Rows.Count > 0)
                            {
                                login_time = dtm.Rows[0]["working_time"].ToString();
                            }
                            DataTable dt_logout = blog.get_all_logout_time(date_from, date_to, dataGridView1.Rows[i].Cells["cal_session_id"].Value.ToString(),cbo_user_name.Text);
                            if (dt_logout.Rows.Count > 0)
                            {
                                logout_time = dt_logout.Rows[0]["working_time"].ToString();
                            }
                            dataGridView1.Rows[i].Cells["cal_time"].Value = login_time + " - " + logout_time;
                            DateTime dt_login_time = Convert.ToDateTime(login_time);
                            DateTime dt_logout_time = Convert.ToDateTime(logout_time);
                            decimal dt_total_hours = Convert.ToDecimal((dt_login_time - dt_logout_time).TotalHours);
                            dataGridView1.Rows[i].Cells["cal_total_time"].Value = Math.Abs(Math.Round(dt_total_hours, 2, MidpointRounding.AwayFromZero));
                        }
                        panel1.Show();
                        panel3.Hide();

                    }
                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            searchPanel.Show();
        }

        private void btn_export_to_pdf_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount-1);
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



            //Adding DataRow
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                foreach (DataGridViewCell cells in row.Cells)
                {
                    if (cells.ColumnIndex <= 5)
                    {
                        pdfTable.AddCell(cells.Value.ToString() ?? string.Empty);
                    }
                }
            }

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\Login Tracker Report \\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string Datename = DateTime.Now.ToString("dd-mm-yyyy hh");
            using (FileStream stream = new FileStream(folderPath + "Login Report " + Datename + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                pdfDoc.Header = new HeaderFooter(new Phrase("Header Text"), false);
                pdfDoc.Open();
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph pheading = new Paragraph("Login Tracker Report ");
               // Paragraph pheadingDate = new Paragraph("From:     " + datefrom.Text + "                                        " + "To:      " + dateto.Text);
                pheading.Alignment = Element.TITLE;

                pheading.Alignment = Element.TITLE;
                Paragraph pheading_space = new Paragraph("   ");
                Paragraph p = new Paragraph("");
                p.Alignment = Element.ALIGN_BOTTOM;
                pdfDoc.Add(pheading);

               // pdfDoc.Add(pheadingDate);
                pdfDoc.Add(pheading_space);
                pdfDoc.Add(pdfTable);
                pdfDoc.Add(p);
                pdfDoc.Close();
                stream.Close();
            }

            MessageBox.Show("Data Has Been Export To Document");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
