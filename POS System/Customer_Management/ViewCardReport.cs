using BLLS;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using ClosedXML.Excel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Customer_Management
{
    public partial class ViewCardReport : Form
    {
        public ViewCardReport()
        {
            InitializeComponent();
        }
        BLLcardreport blcr = new BLLcardreport();
        BLLUser blu = new BLLUser();
        blllCustomerDetailednyo blcd = new blllCustomerDetailednyo();
        private void ViewCardReport_Load(object sender, EventArgs e)
        {
            dtp_from.Value = DateTime.Now;
            dtp_to.Value = DateTime.Now;
            searchPanel.Show();
            backpanel.Hide();
            cbo_searchTYpe.SelectedIndex = 0;
            cbo_from_hours.Visible = false;
            cbo_minuts.Visible = false;
            cbo_minuts_from.Visible = false;
            cbo_to_hours.Visible = false;
            cbo_from_hours.SelectedIndex = 0;
            cbo_minuts.SelectedIndex = 0;
            cbo_minuts_from.SelectedIndex = 0;
            cbo_to_hours.SelectedIndex = 22;
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
   
        public void amountcalculation()
        {
            double add_balance_cash = 0;
            double add_balance_credit = 0;
            double add_balance_atmcard = 0;
            double cash_back = 0;
            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {
                if (dataGridView1.Rows[x].Cells["col_recharge_type"].Value.ToString()=="Cash" && dataGridView1.Rows[x].Cells["col_status"].Value.ToString() == "Balance Added")
                {
                    add_balance_cash += Convert.ToDouble(dataGridView1.Rows[x].Cells["col_add_balance"].Value.ToString());
                }
                if (dataGridView1.Rows[x].Cells["col_recharge_type"].Value.ToString() == "Credit")
                {
                    add_balance_credit += Convert.ToDouble(dataGridView1.Rows[x].Cells["col_add_balance"].Value.ToString());
                }
                if (dataGridView1.Rows[x].Cells["col_recharge_type"].Value.ToString() == "Atm Card")
                {
                    add_balance_atmcard += Convert.ToDouble(dataGridView1.Rows[x].Cells["col_add_balance"].Value.ToString());
                }
                if (dataGridView1.Rows[x].Cells["col_status"].Value.ToString() == "Cash Back")
                {
                    cash_back += Convert.ToDouble(dataGridView1.Rows[x].Cells["col_add_balance"].Value.ToString());
                }

            }
         lbl_cash.Text = add_balance_cash.ToString("#.##");
            lbl_credit.Text = add_balance_credit.ToString("#.##");
            lbl_atm.Text = add_balance_atmcard.ToString("#.##");
            lbl_add_balance.Text = (add_balance_cash + add_balance_credit + add_balance_atmcard).ToString();
            lbl_cash_back.Text = cash_back.ToString("#.##");
        
        }
        private void btn_show_all_Click(object sender, EventArgs e)
        {
            string theDate = dtp_from.Value.ToString("yyyy-MM-dd") + " " + cbo_from_hours.Text + ":" + cbo_minuts_from.Text + ":00";
            string theDate2 = dtp_to.Value.ToString("yyyy-MM-dd") + " " + cbo_to_hours.Text + ":" + cbo_minuts.Text + ":00";
  
            DateTime dateOne = Convert.ToDateTime(theDate);
            DateTime datetwo = Convert.ToDateTime(theDate2);
            if (cbo_searchTYpe.Text == "" || cbo_searchTYpe.Text == "Choose Type")
            {
                MessageBox.Show("The Fields are Empty or invalid.");
            }
          
            else if (cbo_searchTYpe.Text == "User")
            {
                DataTable dt = blcr.Getblanancebyuser(txt_searchText.Text,dateOne, datetwo);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int inc = 0; inc < dt.Rows.Count; inc++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[inc].Cells["col_id"].Value = dt.Rows[inc]["customer_id"].ToString();
                        int customer_id = Convert.ToInt32(dt.Rows[inc]["customer_id"].ToString());
                        DataTable dt1 = blcd.getDataByitsId(customer_id);
                        if (dt1.Rows.Count > 0)
                        {
                            dataGridView1.Rows[inc].Cells["col_customer"].Value = dt1.Rows[0]["name"].ToString();
                            dataGridView1.Rows[inc].Cells["col_card_no"].Value = dt1.Rows[0]["card_no"].ToString();
                        }
                        dataGridView1.Rows[inc].Cells["col_add_balance"].Value = dt.Rows[inc]["amount"].ToString();
                        dataGridView1.Rows[inc].Cells["col_status"].Value = dt.Rows[inc]["status"].ToString();
                        dataGridView1.Rows[inc].Cells["col_recharge_type"].Value = dt.Rows[inc]["payment_mode"].ToString();
                        dataGridView1.Rows[inc].Cells["col_date"].Value = dt.Rows[inc]["date"].ToString();
                        dataGridView1.Rows[inc].Cells["col_user"].Value = dt.Rows[inc]["user_name"].ToString();
                        dataGridView1.Rows[inc].Cells["col_date"].Value = dt.Rows[inc]["date"].ToString();
                    }
                    backpanel.Show();
                    searchPanel.Hide(); 
                   amountcalculation();
                }
            }
            else if (cbo_searchTYpe.Text == "All")
            {
                DataTable dt = blcr.GetBalanceAdd(dateOne, datetwo);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int inc = 0; inc < dt.Rows.Count; inc++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[inc].Cells["col_id"].Value = dt.Rows[inc]["customer_id"].ToString();
                        int customer_id = Convert.ToInt32(dt.Rows[inc]["customer_id"].ToString());
                        DataTable dt1 = blcd.getDataByitsId(customer_id);
                        if (dt1.Rows.Count > 0)
                        {
                            dataGridView1.Rows[inc].Cells["col_customer"].Value = dt1.Rows[0]["name"].ToString();
                            dataGridView1.Rows[inc].Cells["col_card_no"].Value = dt1.Rows[0]["card_no"].ToString();
                        }
                        dataGridView1.Rows[inc].Cells["col_add_balance"].Value = dt.Rows[inc]["amount"].ToString();
                        dataGridView1.Rows[inc].Cells["col_status"].Value = dt.Rows[inc]["status"].ToString();
                        dataGridView1.Rows[inc].Cells["col_recharge_type"].Value = dt.Rows[inc]["payment_mode"].ToString();
                        dataGridView1.Rows[inc].Cells["col_date"].Value = dt.Rows[inc]["date"].ToString();
                        dataGridView1.Rows[inc].Cells["col_user"].Value = dt.Rows[inc]["user_name"].ToString();
                        dataGridView1.Rows[inc].Cells["col_date"].Value = dt.Rows[inc]["date"].ToString();

                         }
                    backpanel.Show();
                    searchPanel.Hide();
                 
                    amountcalculation();
                }
            }
            else if (cbo_searchTYpe.Text == "Cash Back")
            {
                DataTable dt = blcr.GetCardCashBack(dateOne,datetwo);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int inc = 0; inc < dt.Rows.Count; inc++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[inc].Cells["col_id"].Value = dt.Rows[inc]["customer_id"].ToString();
                        int customer_id = Convert.ToInt32(dt.Rows[inc]["customer_id"].ToString());
                        DataTable dt1 = blcd.getDataByitsId(customer_id);
                        if (dt1.Rows.Count > 0)
                        {
                            dataGridView1.Rows[inc].Cells["col_customer"].Value = dt1.Rows[0]["name"].ToString();
                            dataGridView1.Rows[inc].Cells["col_card_no"].Value = dt1.Rows[0]["card_no"].ToString();
                        }
                        dataGridView1.Rows[inc].Cells["col_add_balance"].Value = dt.Rows[inc]["amount"].ToString();
                        dataGridView1.Rows[inc].Cells["col_status"].Value = dt.Rows[inc]["status"].ToString();
                        dataGridView1.Rows[inc].Cells["col_recharge_type"].Value = dt.Rows[inc]["payment_mode"].ToString();
                        dataGridView1.Rows[inc].Cells["col_date"].Value = dt.Rows[inc]["date"].ToString();
                        dataGridView1.Rows[inc].Cells["col_user"].Value = dt.Rows[inc]["user_name"].ToString();
                        dataGridView1.Rows[inc].Cells["col_date"].Value = dt.Rows[inc]["date"].ToString();

                    }
                    backpanel.Show();
                    searchPanel.Hide();
                  
                    amountcalculation();
                }
            }
            else if (cbo_searchTYpe.Text == "Balance Topup")
            {
                if (txt_searchText.Text == "All")
                {
                    DataTable dt2 = blcr.GetAllBalanceAdd(dateOne, datetwo);
                    if (dt2.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int inc = 0; inc < dt2.Rows.Count; inc++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[inc].Cells["col_id"].Value = dt2.Rows[inc]["customer_id"].ToString();
                            int customer_id = Convert.ToInt32(dt2.Rows[inc]["customer_id"].ToString());
                            DataTable dt1 = blcd.getDataByitsId(customer_id);
                            if (dt1.Rows.Count > 0)
                            {
                                dataGridView1.Rows[inc].Cells["col_customer"].Value = dt1.Rows[0]["name"].ToString();
                                dataGridView1.Rows[inc].Cells["col_card_no"].Value = dt1.Rows[0]["card_no"].ToString();
                            }
                            dataGridView1.Rows[inc].Cells["col_add_balance"].Value = dt2.Rows[inc]["amount"].ToString();
                            dataGridView1.Rows[inc].Cells["col_status"].Value = dt2.Rows[inc]["status"].ToString();
                            dataGridView1.Rows[inc].Cells["col_recharge_type"].Value = dt2.Rows[inc]["payment_mode"].ToString();
                            dataGridView1.Rows[inc].Cells["col_date"].Value = dt2.Rows[inc]["date"].ToString();
                            dataGridView1.Rows[inc].Cells["col_user"].Value = dt2.Rows[inc]["user_name"].ToString();
                            dataGridView1.Rows[inc].Cells["col_date"].Value = dt2.Rows[inc]["date"].ToString();
                        }
                        backpanel.Show();
                        searchPanel.Hide();
                        amountcalculation();
                    }
                }
                else
                {
                    DataTable dt = blcr.GetBalancebyRechargeType(txt_searchText.Text,dateOne,datetwo);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int inc = 0; inc < dt.Rows.Count; inc++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[inc].Cells["col_id"].Value = dt.Rows[inc]["customer_id"].ToString();
                            int customer_id = Convert.ToInt32(dt.Rows[inc]["customer_id"].ToString());
                            DataTable dt1 = blcd.getDataByitsId(customer_id);
                            if (dt1.Rows.Count > 0)
                            {
                                dataGridView1.Rows[inc].Cells["col_customer"].Value = dt1.Rows[0]["name"].ToString();
                                dataGridView1.Rows[inc].Cells["col_card_no"].Value = dt1.Rows[0]["card_no"].ToString();
                            }
                            dataGridView1.Rows[inc].Cells["col_add_balance"].Value = dt.Rows[inc]["amount"].ToString();
                            dataGridView1.Rows[inc].Cells["col_status"].Value = dt.Rows[inc]["status"].ToString();
                            dataGridView1.Rows[inc].Cells["col_recharge_type"].Value = dt.Rows[inc]["payment_mode"].ToString();
                            dataGridView1.Rows[inc].Cells["col_date"].Value = dt.Rows[inc]["date"].ToString();
                            dataGridView1.Rows[inc].Cells["col_user"].Value = dt.Rows[inc]["user_name"].ToString();
                            dataGridView1.Rows[inc].Cells["col_date"].Value = dt.Rows[inc]["date"].ToString();


                        }
                        backpanel.Show();
                        searchPanel.Hide();
                        amountcalculation();
                    }
                }

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
        private void cbo_searchTYpe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.Text=="Balance Topup")
            {
                clearcombo(txt_searchText);
                List<string> mylist = new List<string>();
                mylist.Add("Cash");
                mylist.Add("Atm Card");
                mylist.Add("Credit");
                mylist.Add("All");
                txt_searchText.DataSource = mylist;
            }
            else if (cbo_searchTYpe.Text=="All")
            {
                clearcombo(txt_searchText);
                txt_searchText.Text = "All";
            }
            else if (cbo_searchTYpe.Text == "Cash Back")
            {
                clearcombo(txt_searchText);
                txt_searchText.Text = "Cash Back";
            }
            else if (cbo_searchTYpe.Text == "User")
            {
                clearcombo(txt_searchText);
                User();
            }
      
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            searchPanel.Show();
            backpanel.Hide();
        }

        private void backpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chk_time_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_time.Checked == true)
            {
                cbo_from_hours.Visible = true;
                cbo_minuts.Visible = true;
                cbo_minuts_from.Visible = true;
                cbo_to_hours.Visible = true;
            }
            else
            {
                cbo_from_hours.Visible = false;
                cbo_minuts.Visible = false;
                cbo_minuts_from.Visible = false;
                cbo_to_hours.Visible = false;
            }
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

                if (column.Index <= 7)
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
                    if (cells.ColumnIndex <= 7)
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

            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\CardReport\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string Datename = DateTime.Now.ToString("dd-mm-yyyy hh");
            using (FileStream stream = new FileStream(folderPath + "CardReport " + Datename + ".pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f);
                pdfDoc.Header = new HeaderFooter(new Phrase("Header Text"), false);
                pdfDoc.Open();
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph pheading = new Paragraph("Card Deatil Report");
                Paragraph pheading_business_name = new Paragraph(Business_Name);
                Paragraph pheading_pan_no = new Paragraph("Pan No :" + pan_no);
                Paragraph pheadingDate = new Paragraph("From:     " + dtp_from.Text + "                                        " + "To:      " + dtp_to.Text);
                pheading.Alignment = Element.TITLE;
                pheading_business_name.Alignment = Element.TITLE;
                pheading_pan_no.Alignment = Element.TITLE;
                pheading.Alignment = Element.TITLE;
                Paragraph pheading_space = new Paragraph("   ");
                Paragraph p = new Paragraph("cash:- " + lbl_cash.Text + "                 " +"Credit: "+ lbl_credit.Text + "               "+"Atm card:" + lbl_atm.Text +"               "+"Total:"+lbl_add_balance.Text+"                    "+"Cash back:"+lbl_cash_back.Text);
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

    }
}
