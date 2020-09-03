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
using ClosedXML.Excel;

namespace POS_System
{
    public partial class XReportView : UserControl
    {
        public XReportView()
        {
            InitializeComponent();
        }
        BLLRestSell blres = new BLLRestSell();
        BLLOrder blod = new BLLOrder();
        BLLUser blu = new BLLUser();
        public string user_name;
        private void btn_show_Click(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text == "ALL")
            {
                DataTable dt = blres.search_all_x_data();
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int inc = 0; inc < dt.Rows.Count; inc++)
                    {
                        int ac = dataGridView1.Rows.Add();
                        dataGridView1.Rows[inc].Cells["calitem"].Value = dt.Rows[inc]["item_name"].ToString();
                        dataGridView1.Rows[inc].Cells["calquantity"].Value = dt.Rows[inc]["quantity"].ToString();
                        dataGridView1.Rows[inc].Cells["caltotal"].Value = dt.Rows[inc]["total"].ToString();
                        dataGridView1.Rows[inc].Cells["caldate"].Value = dt.Rows[inc]["date_of_sale"].ToString();
                        dataGridView1.Rows[inc].Cells["calcardamount"].Value = dt.Rows[inc]["card_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["calcashamt"].Value = dt.Rows[inc]["cash_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["calpaymode"].Value = dt.Rows[inc]["payment_mode"].ToString();
                        dataGridView1.Rows[inc].Cells["calcashier_name"].Value = dt.Rows[inc]["cashier_name"].ToString();
                        dataGridView1.Rows[inc].Cells["calbill_no"].Value = dt.Rows[inc]["bill_no"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_grand_total"].Value = dt.Rows[inc]["grand_total"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dt.Rows[inc]["sales_type"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_sales_id"].Value = dt.Rows[inc]["rest_sale_id"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dt.Rows[inc]["table_no"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_category_name"].Value = dt.Rows[inc]["category_name"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_discount"].Value = dt.Rows[inc]["discount"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_sub_total"].Value = dt.Rows[inc]["sub_total"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_date2"].Value = dt.Rows[inc]["date2"].ToString();
                        grandtotal();
                    }
                    backPanel.Show();
                    searchPanel.Hide();

                }
                else
                {
                    MessageBox.Show("No Record Found");
                }
            }
            else if (cbo_searchTYpe.Text == "Cash")
            {
                DataTable dt = blres.search_all_x_data_by_cash();
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int inc = 0; inc < dt.Rows.Count; inc++)
                    {
                        int ac = dataGridView1.Rows.Add();
                        dataGridView1.Rows[inc].Cells["calitem"].Value = dt.Rows[inc]["item_name"].ToString();
                        dataGridView1.Rows[inc].Cells["calquantity"].Value = dt.Rows[inc]["quantity"].ToString();
                        dataGridView1.Rows[inc].Cells["caltotal"].Value = dt.Rows[inc]["total"].ToString();
                        dataGridView1.Rows[inc].Cells["caldate"].Value = dt.Rows[inc]["date_of_sale"].ToString();
                        dataGridView1.Rows[inc].Cells["calcardamount"].Value = dt.Rows[inc]["card_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["calcashamt"].Value = dt.Rows[inc]["cash_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["calpaymode"].Value = dt.Rows[inc]["payment_mode"].ToString();
                        dataGridView1.Rows[inc].Cells["calcashier_name"].Value = dt.Rows[inc]["cashier_name"].ToString();
                        dataGridView1.Rows[inc].Cells["calbill_no"].Value = dt.Rows[inc]["bill_no"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_grand_total"].Value = dt.Rows[inc]["grand_total"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dt.Rows[inc]["sales_type"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_sales_id"].Value = dt.Rows[inc]["rest_sale_id"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dt.Rows[inc]["table_no"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_category_name"].Value = dt.Rows[inc]["category_name"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_discount"].Value = dt.Rows[inc]["discount"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_sub_total"].Value = dt.Rows[inc]["sub_total"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_date2"].Value = dt.Rows[inc]["date2"].ToString();
                        grandtotal();
                    }
                    backPanel.Show();
                    searchPanel.Hide();

                }
                else
                {
                    MessageBox.Show("No Record Found");
                }
            }
            else if (cbo_searchTYpe.Text == "Card")
            {
                DataTable dt = blres.search_all_x_data_by_Card();
                 if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int inc = 0; inc < dt.Rows.Count; inc++)
                    {
                        int ac = dataGridView1.Rows.Add();
                        dataGridView1.Rows[inc].Cells["calitem"].Value = dt.Rows[inc]["item_name"].ToString();
                        dataGridView1.Rows[inc].Cells["calquantity"].Value = dt.Rows[inc]["quantity"].ToString();
                        dataGridView1.Rows[inc].Cells["caltotal"].Value = dt.Rows[inc]["total"].ToString();
                        dataGridView1.Rows[inc].Cells["caldate"].Value = dt.Rows[inc]["date_of_sale"].ToString();
                        dataGridView1.Rows[inc].Cells["calcardamount"].Value = dt.Rows[inc]["card_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["calcashamt"].Value = dt.Rows[inc]["cash_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["calpaymode"].Value = dt.Rows[inc]["payment_mode"].ToString();
                        dataGridView1.Rows[inc].Cells["calcashier_name"].Value = dt.Rows[inc]["cashier_name"].ToString();
                        dataGridView1.Rows[inc].Cells["calbill_no"].Value = dt.Rows[inc]["bill_no"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_grand_total"].Value = dt.Rows[inc]["grand_total"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dt.Rows[inc]["sales_type"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_sales_id"].Value = dt.Rows[inc]["rest_sale_id"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dt.Rows[inc]["table_no"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_category_name"].Value = dt.Rows[inc]["category_name"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_discount"].Value = dt.Rows[inc]["discount"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_sub_total"].Value = dt.Rows[inc]["sub_total"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_date2"].Value = dt.Rows[inc]["date2"].ToString();
                        grandtotal();
                    }
                    backPanel.Show();
                    searchPanel.Hide();

                }
                else
                {
                    MessageBox.Show("No Record Found");
                }
            }
            else if (cbo_searchTYpe.Text == "Zomato")
            {
                DataTable dt = blres.search_all_x_data_by_Zomato();
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int inc = 0; inc < dt.Rows.Count; inc++)
                    {
                        int ac = dataGridView1.Rows.Add();
                        dataGridView1.Rows[inc].Cells["calitem"].Value = dt.Rows[inc]["item_name"].ToString();
                        dataGridView1.Rows[inc].Cells["calquantity"].Value = dt.Rows[inc]["quantity"].ToString();
                        dataGridView1.Rows[inc].Cells["caltotal"].Value = dt.Rows[inc]["total"].ToString();
                        dataGridView1.Rows[inc].Cells["caldate"].Value = dt.Rows[inc]["date_of_sale"].ToString();
                        dataGridView1.Rows[inc].Cells["calcardamount"].Value = dt.Rows[inc]["card_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["calcashamt"].Value = dt.Rows[inc]["cash_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["calpaymode"].Value = dt.Rows[inc]["payment_mode"].ToString();
                        dataGridView1.Rows[inc].Cells["calcashier_name"].Value = dt.Rows[inc]["cashier_name"].ToString();
                        dataGridView1.Rows[inc].Cells["calbill_no"].Value = dt.Rows[inc]["bill_no"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_grand_total"].Value = dt.Rows[inc]["grand_total"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dt.Rows[inc]["sales_type"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_sales_id"].Value = dt.Rows[inc]["rest_sale_id"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dt.Rows[inc]["table_no"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_category_name"].Value = dt.Rows[inc]["category_name"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_discount"].Value = dt.Rows[inc]["discount"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_sub_total"].Value = dt.Rows[inc]["sub_total"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_date2"].Value = dt.Rows[inc]["date2"].ToString();
                        grandtotal();
                    }
                    backPanel.Show();
                    searchPanel.Hide();

                }
                else
                {
                    MessageBox.Show("No Record Found");
                }
            }
            else if (cbo_searchTYpe.Text == "Credit")
            {
                DataTable dt = blres.search_all_x_data_by_Credit();
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int inc = 0; inc < dt.Rows.Count; inc++)
                    {
                        int ac = dataGridView1.Rows.Add();
                        dataGridView1.Rows[inc].Cells["calitem"].Value = dt.Rows[inc]["item_name"].ToString();
                        dataGridView1.Rows[inc].Cells["calquantity"].Value = dt.Rows[inc]["quantity"].ToString();
                        dataGridView1.Rows[inc].Cells["caltotal"].Value = dt.Rows[inc]["total"].ToString();
                        dataGridView1.Rows[inc].Cells["caldate"].Value = dt.Rows[inc]["date_of_sale"].ToString();
                        dataGridView1.Rows[inc].Cells["calcardamount"].Value = dt.Rows[inc]["card_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["calcashamt"].Value = dt.Rows[inc]["cash_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["calpaymode"].Value = dt.Rows[inc]["payment_mode"].ToString();
                        dataGridView1.Rows[inc].Cells["calcashier_name"].Value = dt.Rows[inc]["cashier_name"].ToString();
                        dataGridView1.Rows[inc].Cells["calbill_no"].Value = dt.Rows[inc]["bill_no"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_grand_total"].Value = dt.Rows[inc]["grand_total"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dt.Rows[inc]["sales_type"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_sales_id"].Value = dt.Rows[inc]["rest_sale_id"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dt.Rows[inc]["table_no"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_category_name"].Value = dt.Rows[inc]["category_name"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_discount"].Value = dt.Rows[inc]["discount"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_sub_total"].Value = dt.Rows[inc]["sub_total"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_date2"].Value = dt.Rows[inc]["date2"].ToString();
                        grandtotal();
                    }
                    backPanel.Show();
                    searchPanel.Hide();

                }
                else
                {
                    MessageBox.Show("No Record Found");
                }
            }
        }
        public void grandtotal()
        {
            double sum = 0;
            double grand_toatl = 0;
            double sub_total = 0;

            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {

                sum += Convert.ToDouble(dataGridView1.Rows[x].Cells["calquantity"].Value.ToString());
                grand_toatl += Convert.ToDouble(dataGridView1.Rows[x].Cells["cal_grand_total"].Value.ToString());
                sub_total += Convert.ToDouble(dataGridView1.Rows[x].Cells["caltotal"].Value.ToString());

            }
            lbltaotal_quantity.Text = sum.ToString();
            lblsub_total.Text = sub_total.ToString();
            lbl_grand_total.Text = grand_toatl.ToString();
        }

        private void XReportView_Load(object sender, EventArgs e)
        {
            backPanel.Hide();
            user_name = Login.sendtext;
            cbo_searchTYpe.SelectedIndex = 0;
            // dtdsearchbydate.Focus();
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(11, 81, 126);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeight = 60;
        }

        private void btn_export_to_pdf_Click(object sender, EventArgs e)
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

            //  string folderPath = "C:\\PDFs\\";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\XReport\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            Random rnum = new Random();
            String ramdomnumber = (rnum.Next(1212, 98998)).ToString();

            String Datename = Convert.ToDateTime(DateTime.Now).ToShortDateString();


            using (FileStream stream = new FileStream(folderPath + "X Report Restaurant Sales" + ramdomnumber + ".pdf", FileMode.Create))
            {
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph p = new Paragraph("X Report Restaurant Sales ");
                p.Alignment = 1;

                pdfDoc.Add(p);
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }

            MessageBox.Show("Data Has Been Export To Document");
        }

        private void backPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\XReport\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            excelFilename = "Restaurant Sales By Date";
            MessageBox.Show("Your excel file export done" + excelFilename + ".xlsx");
            objexcelapp.ActiveWorkbook.SaveCopyAs("C:\\Excel Export\\" + excelFilename + ".xlsx");
            objexcelapp.ActiveWorkbook.Saved = true;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            backPanel.Hide();
            searchPanel.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView1.Columns["cal_delete"].Index && e.RowIndex >= 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are You Sure Want To Delete This Data", "Record Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DataTable dt = blu.getusername(user_name);
                    if (dt.Rows[0]["user_type"].ToString() == "Admin" || dt.Rows[0]["user_type"].ToString() == "admin")
                    {
                        int delete_by_id = blres.delete_sale_by_id(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_sales_id"].Value));
                        if (delete_by_id > 0)
                        {
                            string item_name = dataGridView1.CurrentRow.Cells["calitem"].Value.ToString();
                            int quantity = Convert.ToInt32(dataGridView1.CurrentRow.Cells["calquantity"].Value);
                            decimal total = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["caltotal"].Value);
                            DateTime date_time = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["caldate"].Value);
                            decimal card_amount = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["calcardamount"].Value);
                            decimal cash_amount = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["calcashamt"].Value);
                            string payment_mode = dataGridView1.CurrentRow.Cells["calpaymode"].Value.ToString();
                            string cashier_name = dataGridView1.CurrentRow.Cells["calcashier_name"].Value.ToString();
                            int bill_no = Convert.ToInt32(dataGridView1.CurrentRow.Cells["calbill_no"].Value);
                            decimal grand_total = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_grand_total"].Value);
                            string sales_type = dataGridView1.CurrentRow.Cells["cal_sales_type"].Value.ToString();
                            int sale_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_sales_id"].Value);
                            decimal sub_total = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_sub_total"].Value);
                            decimal cost = Convert.ToDecimal("0");
                            decimal discount = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_discount"].Value);
                            string category_name = dataGridView1.CurrentRow.Cells["cal_category_name"].Value.ToString();
                            string table_no = dataGridView1.CurrentRow.Cells["cal_table_no"].Value.ToString();
                            DateTime date2 = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["cal_date2"].Value);
                            DateTime date_of_delete = Convert.ToDateTime(DateTime.Now.ToString());
                            int b = blres.inser_delete_record(sale_id, bill_no, date_time, cashier_name, table_no, "NULL", "NULL", item_name, quantity, cost, total, payment_mode, "NULL", sub_total, discount, cash_amount, card_amount, grand_total, category_name, sales_type, date_of_delete, user_name);
                            MessageBox.Show("Data Has Been Deleted");
                            dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                            grandtotal();
                        }
                    }
                    else
                    {
                        MessageBox.Show("You Have No Permission To Delete This Data");
                    }

                }
            }
        }

        private void btnbackpage_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            allmenu alls = new allmenu();
            ctls.Controls.Clear();
            ctls.Controls.Add(alls);
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
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\XReport Excel\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "X Report");
                wb.SaveAs(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "XReport.xlsx");
            }
        }
    }

}

