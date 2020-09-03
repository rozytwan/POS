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
    public partial class ViewRestaurantDeleteRecord : UserControl
    {
        public ViewRestaurantDeleteRecord()
        {
            InitializeComponent();
        }
        BLLOrder blod = new BLLOrder();
        BLLCategory blcat = new BLLCategory();
        BLLProduct blpro = new BLLProduct();
        BLLUser blu = new BLLUser();
        BLLRestSell blres = new BLLRestSell();

        public string user_name;

        private void ViewRestaurantDeleteRecord_Load(object sender, EventArgs e)
        {
            dtp_from.Value = DateTime.Now;
            dtp_to.Value = DateTime.Now;
            //this.Width = this.Parent.Width;
            user_name = Login.sendtext;
            backPanel.Hide();
            cbo_searchTYpe.SelectedIndex = 0;
            // dtdsearchbydate.Focus();
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(11, 81, 126);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeight = 60;
            user_name = Login.sendtext;
        }

        public void category()
        {
            DataTable dt = blcat.getallItemcategory();
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
        public void Billno()
        {
            DataTable dt = blod.getalldatasFromSalesRecords_delete_record();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["bill_no"] = "00000";
                dt.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = dt;
                txt_searchText.DisplayMember = "bill_no";

            }
        }

        public void products()
        {
            DataTable dt = blpro.getallItems();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["item_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = dt;
                txt_searchText.DisplayMember = "item_name";

            }
        }
        public void grandtotal()
        {
            double sum = 0;
            double grand_toatl = 0;

            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {

                sum += Convert.ToDouble(dataGridView1.Rows[x].Cells["calquantity"].Value.ToString());
                grand_toatl += Convert.ToDouble(dataGridView1.Rows[x].Cells["caltotal"].Value.ToString());

            }
            lbltaotal_quantity.Text = sum.ToString();
            lblgrandtotal.Text = grand_toatl.ToString();
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

                if (cbo_searchTYpe.Text == "Product")
                {
                    DataTable dt = blod.searchitembyname_delete_record(txt_searchText.Text, dateOne, datetwo);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int inc = 0; inc < dt.Rows.Count; inc++)
                        {
                            int ww = dataGridView1.Rows.Add();
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

                    }//dt rows if end
                    else
                    {
                        MessageBox.Show("No Record Found");
                    }
                }
                else if (cbo_searchTYpe.Text == "Category")
                {
                    DataTable dt = blod.searchbycategory2_delete_record(txt_searchText.Text, dateOne, datetwo);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int inc = 0; inc < dt.Rows.Count; inc++)
                        {
                            int y = dataGridView1.Rows.Add();
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

                    }//dt rows if end
                    else
                    {
                        MessageBox.Show("No Record Found");
                    }
                }
                else if (cbo_searchTYpe.Text == "Bill No")
                {
                    DataTable dt = blod.searchbybill2_delete_record(txt_searchText.Text);
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
                else if (cbo_searchTYpe.Text == "ALL")
                {
                    DataTable dtm = blod.searchALL_delete_record(dateOne, datetwo);
                    if (dtm.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int inc = 0; inc < dtm.Rows.Count; inc++)
                        {
                            int ac = dataGridView1.Rows.Add();
                            dataGridView1.Rows[inc].Cells["calitem"].Value = dtm.Rows[inc]["item_name"].ToString();
                            dataGridView1.Rows[inc].Cells["calquantity"].Value = dtm.Rows[inc]["quantity"].ToString();
                            dataGridView1.Rows[inc].Cells["caltotal"].Value = dtm.Rows[inc]["total"].ToString();
                            dataGridView1.Rows[inc].Cells["caldate"].Value = dtm.Rows[inc]["date_of_sale"].ToString();
                            dataGridView1.Rows[inc].Cells["calcardamount"].Value = dtm.Rows[inc]["card_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["calcashamt"].Value = dtm.Rows[inc]["cash_amount"].ToString();
                            dataGridView1.Rows[inc].Cells["calpaymode"].Value = dtm.Rows[inc]["payment_mode"].ToString();
                            dataGridView1.Rows[inc].Cells["calcashier_name"].Value = dtm.Rows[inc]["cashier_name"].ToString();
                            dataGridView1.Rows[inc].Cells["calbill_no"].Value = dtm.Rows[inc]["bill_no"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_grand_total"].Value = dtm.Rows[inc]["grand_total"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dtm.Rows[inc]["sales_type"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_sales_id"].Value = dtm.Rows[inc]["rest_sale_id"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dtm.Rows[inc]["table_no"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_category_name"].Value = dtm.Rows[inc]["category_name"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_discount"].Value = dtm.Rows[inc]["discount"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_sub_total"].Value = dtm.Rows[inc]["sub_total"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_date2"].Value = dtm.Rows[inc]["date2"].ToString();
                            grandtotal();
                        }
                        backPanel.Show();
                        searchPanel.Hide();
                    }
                    //dtm rows if end
                    else
                    {
                        MessageBox.Show("No  Record Found");
                    }
                }
                else if (cbo_searchTYpe.Text == "Payment Mode")
                {
                    DataTable dt = blod.searchpayment_mode_delete_record(txt_searchText.Text, dateOne, datetwo);
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
                else if (cbo_searchTYpe.Text == "Sales Type")
                {
                    DataTable dt = blod.searchsale_type_delete(txt_searchText.Text, dateOne, datetwo);
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
                else if (cbo_searchTYpe.Text == "User")
                {
                    DataTable dt = blod.searchsale_by_user_delete(txt_searchText.Text, dateOne, datetwo);
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
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            backPanel.Hide();
            searchPanel.Show();
        }

        private void btnbackpage_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            allmenu alls = new allmenu();
            ctls.Controls.Clear();
            ctls.Controls.Add(alls);
        }

        private void cbo_searchTYpe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void User()
        {
            DataTable dt = blu.getalluser();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["user_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                txt_searchText.DataSource = dt;
                txt_searchText.DisplayMember = "user_name";
                txt_searchText.ValueMember = "user_name";
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_export_to_pdf_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;


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


            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\Sales Delete\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string Datename = DateTime.Now.ToString("dd-mm-yyyy hh");
            using (FileStream stream = new FileStream(folderPath + "RestaurantSalesReportDelete " + Datename + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                pdfDoc.Header = new HeaderFooter(new Phrase("Header Text"), false);
                pdfDoc.Open();
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph pheading = new Paragraph("Restaurant Sales Delete Report");
                Paragraph pheadingDate = new Paragraph(Datename);
                pheading.Alignment = Element.TITLE;
                Paragraph pheading_space = new Paragraph("   ");
                Paragraph p = new Paragraph("Total:-                  " + lbltaotal_quantity.Text + "                 " + lblgrandtotal.Text);
                p.Alignment = Element.ALIGN_BOTTOM;
                pdfDoc.Add(pheading);
                pdfDoc.Add(pheadingDate);
                pdfDoc.Add(pheading_space);
                pdfDoc.Add(pdfTable);
                pdfDoc.Add(p);
                pdfDoc.Close();
                stream.Close();
            }

            MessageBox.Show("Data Has Been Export To Document");
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["cal_delete"].Index && e.RowIndex >= 0)
            { }
            DialogResult dialogResult = MessageBox.Show("Are You Sure Want To Delete This Data", "Record Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DataTable dt = blu.getusername(user_name);
                if (dt.Rows[0]["user_type"].ToString() == "Admin" || dt.Rows[0]["user_type"].ToString() == "admin")
                {
                    int delete_by_id = blres.delete_Sale_delete_by_id(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_sales_id"].Value));
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
                        decimal cost = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_cost"].Value);
                        decimal discount = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_discount"].Value);
                        string category_name = dataGridView1.CurrentRow.Cells["cal_category_name"].Value.ToString();
                        string table_no = dataGridView1.CurrentRow.Cells["cal_table_no"].Value.ToString();
                        DateTime date2 = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["cal_date2"].Value);
                        DateTime date_of_delete = Convert.ToDateTime(DateTime.Now.ToString());
                       // int b = blres.insertintosalesbook(bill_no, date_time, cashier_name, table_no, "NULL", "NULL", item_name, quantity, cost, total, payment_mode, "NULL", sub_total, discount, cash_amount, card_amount, grand_total, category_name, sales_type, "NULL");
                        MessageBox.Show("Data Has Been Recover");
                        dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                        grandtotal();
                    }
                }
                else
                {
                    MessageBox.Show("You Have No Permission To Recover This Data");
                }

            }
        }

        private void cbo_searchTYpe_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text == "Product")
            {
                products();
            }
            else if (cbo_searchTYpe.Text == "Category")
            {

                category();
            }
            else if (cbo_searchTYpe.Text == "Bill No")
            {
                Billno();
            }

            else if (cbo_searchTYpe.Text == "ALL")
            {
                clearcombo(txt_searchText);
                txt_searchText.Text = "ALL";
            }
            else if (cbo_searchTYpe.Text == "Payment Mode")
            {
                clearcombo(txt_searchText);
                List<string> mylist = new List<string>();
                mylist.Add("Cash");
                mylist.Add("Card");
                mylist.Add("Credit");
                txt_searchText.DataSource = mylist;
            }
            else if (cbo_searchTYpe.Text == "Sales Type")
            {
                clearcombo(txt_searchText);
                List<string> mylist = new List<string>();
                mylist.Add("TS");
                mylist.Add("TA");
                mylist.Add("HD");
                txt_searchText.DataSource = mylist;

            }
            else if (cbo_searchTYpe.Text == "User")
            {
                clearcombo(txt_searchText);
                User();

            }
        }

        private void tbn_export_to_excel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Index <= 15)
                {
                    dt.Columns.Add(column.HeaderText);
                }
            }
            foreach (DataGridViewRow rows in dataGridView1.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in rows.Cells)
                {
                    if (cell.ColumnIndex <= 15)
                    {
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();

                    }

                }
            }
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\Sales Delete Record Excel\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Sales Deleted Report");
                wb.SaveAs(folderPath + DateTime.Now.ToString("yyyy-mm-dd hh") + "Sales Deleted Report.xlsx");
            }
        }
    }
}
