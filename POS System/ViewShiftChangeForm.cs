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
using iTextSharp.text;
using iTextSharp.text.pdf;
using ClosedXML.Excel;

namespace POS_System
{
    public partial class ViewShiftChangeForm : UserControl
    {
        public ViewShiftChangeForm()
        {
            InitializeComponent();
        }
        BLLSift_Change bsf = new BLLSift_Change();

        private void ShiftChangeForm_Load(object sender, EventArgs e)
        {
            backpanel.Hide();            
            cbo_searchTYpe.SelectedIndex = 0;
            dtp_from.Text = DateTime.Now.ToString();
            dtp_to.Text = DateTime.Now.ToString();
        }
        public void loadgrid() {
            DataTable getdt = bsf.getall();

            if (getdt.Rows.Count > 0) {

                dataGridView1.Rows.Clear();
                for (int j = 0; j < getdt.Rows.Count; j++) {

                    dataGridView1.Rows.Add(getdt.Rows[j]["sift_change_id"].ToString(), getdt.Rows[j]["user_name"].ToString(), getdt.Rows[j]["total_cash_sales"].ToString(), getdt.Rows[j]["total_card_sales"].ToString(), getdt.Rows[j]["total_sales"].ToString(), getdt.Rows[j]["total_cash_in_counter"].ToString(), getdt.Rows[j]["total_busy_table"].ToString(), getdt.Rows[j]["total_amount_hold_in_table"].ToString(), getdt.Rows[j]["total_amount_hold_in_hd"].ToString(), getdt.Rows[j]["total_delivery_left"].ToString(), getdt.Rows[j]["hand_over_to"].ToString(), getdt.Rows[j]["session_date"].ToString(), getdt.Rows[j]["session_date_time"].ToString());
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
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            Document pdfDoc = new Document(PageSize.A3, 20f, 20f, 20f, 20f);

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



            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\SmTechDocuments " + "\\ShiftChangesReport\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "Shift Changes Report.pdf", FileMode.Create))
            {
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph p = new Paragraph("Shift Changes Report");
                p.Alignment = 1;

                pdfDoc.Add(p);
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }

            MessageBox.Show("Data Has Been Export To SmTechDocuments/ShiftChangesReport");
        }

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
                if (cbo_searchTYpe.Text == "Username")
                {
                    DataTable getallusers = bsf.searchbyUsername(txt_searchText.Text, dateOne, datetwo);
                    if (getallusers.Rows.Count > 0)
                    {

                        dataGridView1.Rows.Clear();
                        for (int j = 0; j < getallusers.Rows.Count; j++)
                        {

                            dataGridView1.Rows.Add(getallusers.Rows[j]["sift_change_id"].ToString(), getallusers.Rows[j]["user_name"].ToString(), getallusers.Rows[j]["total_cash_sales"].ToString(), getallusers.Rows[j]["total_card_sales"].ToString(), getallusers.Rows[j]["total_sales"].ToString(), getallusers.Rows[j]["total_cash_in_counter"].ToString(), getallusers.Rows[j]["total_busy_table"].ToString(), getallusers.Rows[j]["total_amount_hold_in_table"].ToString(), getallusers.Rows[j]["total_amount_hold_in_hd"].ToString(), getallusers.Rows[j]["total_delivery_left"].ToString(), getallusers.Rows[j]["hand_over_to"].ToString(), getallusers.Rows[j]["session_date"].ToString(), getallusers.Rows[j]["session_date_time"].ToString());
                        }
                        backpanel.Show();
                        searchPanel.Hide();
                    }
                    else {
                        MessageBox.Show("No Data Found");
                    }
                   

                }
                else if (cbo_searchTYpe.Text == "Hand Over To") {
                    DataTable getallhandoverusers = bsf.searchbyhandovertto(txt_searchText.Text, dateOne, datetwo);
                    if (getallhandoverusers.Rows.Count > 0)
                    {

                        dataGridView1.Rows.Clear();
                        for (int j = 0; j < getallhandoverusers.Rows.Count; j++)
                        {

                            dataGridView1.Rows.Add(getallhandoverusers.Rows[j]["sift_change_id"].ToString(), getallhandoverusers.Rows[j]["user_name"].ToString(), getallhandoverusers.Rows[j]["total_cash_sales"].ToString(), getallhandoverusers.Rows[j]["total_card_sales"].ToString(), getallhandoverusers.Rows[j]["total_sales"].ToString(), getallhandoverusers.Rows[j]["total_cash_in_counter"].ToString(), getallhandoverusers.Rows[j]["total_busy_table"].ToString(), getallhandoverusers.Rows[j]["total_amount_hold_in_table"].ToString(), getallhandoverusers.Rows[j]["total_amount_hold_in_hd"].ToString(), getallhandoverusers.Rows[j]["total_delivery_left"].ToString(), getallhandoverusers.Rows[j]["hand_over_to"].ToString(), getallhandoverusers.Rows[j]["session_date"].ToString(), getallhandoverusers.Rows[j]["session_date_time"].ToString());
                        }
                        backpanel.Show();
                        searchPanel.Hide();
                    }
                    else
                    {
                        MessageBox.Show("No Data Found");
                    }
                   
                }
                else if (cbo_searchTYpe.Text == "ALL")
                {

                    DataTable getdt = bsf.getallbetweendates(dateOne, datetwo);

                    if (getdt.Rows.Count > 0)
                    {

                        dataGridView1.Rows.Clear();
                        for (int j = 0; j < getdt.Rows.Count; j++)
                        {
                            dataGridView1.Rows.Add(getdt.Rows[j]["sift_change_id"].ToString(), getdt.Rows[j]["user_name"].ToString(), getdt.Rows[j]["total_cash_sales"].ToString(), getdt.Rows[j]["total_card_sales"].ToString(), getdt.Rows[j]["total_sales"].ToString(), getdt.Rows[j]["total_cash_in_counter"].ToString(), getdt.Rows[j]["total_busy_table"].ToString(), getdt.Rows[j]["total_amount_hold_in_table"].ToString(), getdt.Rows[j]["total_amount_hold_in_hd"].ToString(), getdt.Rows[j]["total_delivery_left"].ToString(), getdt.Rows[j]["hand_over_to"].ToString(), getdt.Rows[j]["session_date"].ToString(), getdt.Rows[j]["session_date_time"].ToString());
                        }
                        backpanel.Show();
                        searchPanel.Hide();
                    }
                    else
                    {
                        MessageBox.Show("No Data Found");
                    }



                }

            }
        }


        public void getsusername() {
            DataTable getno = bsf.getusernames();
            if (getno.Rows.Count > 0)
            {
                DataRow dr = getno.NewRow();
                dr["user_name"] = "Choose One";
                getno.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = getno;
                txt_searchText.DisplayMember = "user_name";


            }

        }
        public void gethandovertto() {

            DataTable gettables = bsf.gethandovetto();
            if (gettables.Rows.Count > 0)
            {
                DataRow dr = gettables.NewRow();
                dr["hand_over_to"] = "Choose One";
                gettables.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = gettables;
                txt_searchText.DisplayMember = "hand_over_to";


            }
        }


        private void cbo_searchTYpe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text == "Username")
            {
                getsusername();
            }
            else if (cbo_searchTYpe.Text == "Hand Over To")
            {
                gethandovertto();
            }
            else if (cbo_searchTYpe.Text == "ALL")
            {
             
                txt_searchText.Text = "All";


            }
        }
        private void btnbackpage_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            allmenu alls = new allmenu();
            ctls.Controls.Clear();
            ctls.Controls.Add(alls);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            backpanel.Hide();
            searchPanel.Show();
        }

        private void btn_export_to_excel_Click(object sender, EventArgs e)
        {
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
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\UserShiftChange Excel\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Shift Change");
                wb.SaveAs(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "ShiftChange.xlsx");
            }
        }
    }
    }

