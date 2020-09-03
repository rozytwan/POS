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
    public partial class CashWithdrawl : UserControl
    {
        string cashdrop_type;
        public CashWithdrawl(string cash_drop)
        {
         cashdrop_type = cash_drop;
            InitializeComponent();
        }
        public decimal cash_sum;
        string care_of = "0.00";
        Bll_CashwithDrawl bllwithdrawl = new Bll_CashwithDrawl();
        Bll_cashcounter bllcash = new Bll_cashcounter();
        Bll_cashcounter blcas = new Bll_cashcounter();
        BLLRestSell blres = new BLLRestSell();
        Bll_CashwithDrawl blcwd = new Bll_CashwithDrawl();

        private void btn_save_Click(object sender, EventArgs e)
        {
            dgv_all.Rows.Clear();
 
                decimal cash = Convert.ToDecimal(txt_cash.Text);
                decimal sells = Convert.ToDecimal(label_sale.Text);
                decimal openingbalc = (Convert.ToDecimal(lbl_openingbalance.Text)+ Convert.ToDecimal(label_sale.Text));
                decimal amount;
                   

            if (txt_cash.Text == "" || txt_name.Text == "" || txt_withdrawl.Text == "")
                {
                    MessageBox.Show("Fill the Required Fields...","Empty",MessageBoxButtons.OK,MessageBoxIcon.Error);

                }
                else if (!decimal.TryParse(txt_cash.Text, out amount))
                {
                    MessageBox.Show("Cash Amount can't texts or symbols");
                }
                

                else if ((Convert.ToDecimal(txt_CounterCashremain.Text)) < cash)
                {
                    MessageBox.Show("Not enough Monry at Counter","Transaction Fail",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                else
                {
                    string status = "Pending";
                    string date_pass =DateTime.Now.ToShortDateString()+" "+ DateTime.Now.ToShortTimeString();
                    int i = bllwithdrawl.insertintotable(Convert.ToDateTime(date_pass),Login.sendtext, txt_withdrawl.Text, Convert.ToDecimal(txt_cash.Text), cashdrop_type, txt_name.Text);
                    if (i > 0)
                    {
                       

                    MessageBox.Show("Data Has Been Saved Successfully","Save",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    loadgrid();
                    getsalestillnow();
                    OPeningBalances();
                    AvailableCashinCounter();
                    clear();
                }
                
            }
        }
       
        decimal credit_receive_amount=0;
        public DateTime today;
        private void CashWithdrawl_Load(object sender, EventArgs e)
        {
            today = Convert.ToDateTime(DateTime.Today.ToShortDateString());
            loadgrid();
            getsalestillnow();
            OPeningBalances();
           
            AvailableCashinCounter();

            if (Convert.ToDecimal(lbl_openingbalance.Text) < 1)
            {
                MessageBox.Show("Opening balance is not Set.","Transacation Fail",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                OpeningBalance obs = new OpeningBalance("Restaurant");
                if (obs.ShowDialog() == DialogResult.OK) {

                    loadgrid();
                    getsalestillnow();
                    OPeningBalances();
                  
                    AvailableCashinCounter();
                }


            }

        }


        string cash_type;
        public void OPeningBalances() {

            if (cashdrop_type=="Restaurant")
            {
                cash_type = "OB";
            }
            else
            {
                cash_type = "OBH";
            }
            DataTable dt = blcas.get_oening_balance_restaurant(cash_type);

            if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString() != "")
            {
                DataTable dtm = blcas.getopeningbalancerestaurant(cash_type);
                lbl_openingbalance.Text = dtm.Rows[0][0].ToString();
               
            }

        }
        string paid_status;
        public void AvailableCashinCounter()
        {
            if (cashdrop_type == "Restaurant")
            {
                paid_status = "RP";
            }
            else
            {
                paid_status = "HP";
            }
            DataTable dt_sum_credit_amount_received = blres.Sum_Credit_Amount_received(paid_status,today);
            if (dt_sum_credit_amount_received.Rows.Count > 0 && dt_sum_credit_amount_received.Rows[0][0].ToString() != "")
            {
                  credit_receive_amount= Convert.ToDecimal(dt_sum_credit_amount_received.Rows[0][0].ToString());
            }
       
            DataTable dt_care_of = blcwd.sum_get_care_of_restaurant(cashdrop_type);
            if (dt_care_of.Rows.Count > 0 && dt_care_of.Rows[0][0].ToString() != "")
            {
                care_of = dt_care_of.Rows[0][0].ToString();

            }

            txt_CounterCashremain.Text = Convert.ToString(Convert.ToDecimal(lbl_openingbalance.Text) + Convert.ToDecimal(label_sale.Text) + Convert.ToDecimal(credit_receive_amount) - Convert.ToDecimal(care_of));
        }
        BLL_Fiscal blf = new BLL_Fiscal();
        string fiscal_year;
       // string sales_type;
        public void getsalestillnow()
        {

            DataTable dtfis = blf.get_all_data_from_fiscal("True");
            if (dtfis.Rows.Count > 0)
            {
                fiscal_year = dtfis.Rows[0]["fiscal_year"].ToString();
            }

            DateTime today = Convert.ToDateTime(DateTime.Today.ToShortDateString());
            if (cashdrop_type == "Hotel")
            {
                DataTable dt_cash_sale_sum = blres.sum_cash_sale_Bysalestype("X", fiscal_year);
                if (dt_cash_sale_sum.Rows.Count > 0 && dt_cash_sale_sum.Rows[0][0].ToString() != "")
                {
                    //cash_sum= Convert.ToDecimal(dt_cash_sale_sum.Rows[0][1].ToString());
                    for (int i = 0; dt_cash_sale_sum.Rows.Count > i; i++)
                    {
                        cash_sum += Convert.ToDecimal(dt_cash_sale_sum.Rows[i][1].ToString());
                    }
                    label_sale.Text = cash_sum.ToString();
                }
            }
           else if(cashdrop_type == "Restaurant")
            {
                DataTable dt_cash_sale_sum = blres.sum_cash_sale("X", fiscal_year);
                if (dt_cash_sale_sum.Rows.Count > 0 && dt_cash_sale_sum.Rows[0][0].ToString() != "")
                {
                    //cash_sum= Convert.ToDecimal(dt_cash_sale_sum.Rows[0][1].ToString());
                    for (int i = 0; dt_cash_sale_sum.Rows.Count > i; i++)
                    {
                        cash_sum += Convert.ToDecimal(dt_cash_sale_sum.Rows[i][1].ToString());
                    }
                    label_sale.Text = cash_sum.ToString();
                }
            }

        }

        public void loadgrid() {
            dgv_all.Rows.Clear();
            DataTable dtt = bllwithdrawl.getalldatas(cashdrop_type);
            for (int qw =0;qw<dtt.Rows.Count;qw++) {
                dgv_all.Rows.Add(dtt.Rows[qw]["id"].ToString(), dtt.Rows[qw]["date"].ToString(), dtt.Rows[qw]["remarks"].ToString(), dtt.Rows[qw]["withdrawl_type"].ToString(), dtt.Rows[qw]["cash"].ToString(), dtt.Rows[qw]["name"].ToString());
               
                }
            btn_save.Enabled = true;
            edit.Enabled = false;
            }

        private void dgv_all_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_cash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dgv_all_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //String id = dgv_all.CurrentRow.Cells["colid"].Value.ToString();
            //String  date = dgv_all.CurrentRow.Cells["caldate"].Value.ToString();
            //String name = dgv_all.CurrentRow.Cells["calname"].Value.ToString();
            //String amount = dgv_all.CurrentRow.Cells["calamount"].Value.ToString();
            //String description = dgv_all.CurrentRow.Cells["caldesc"].Value.ToString();         

            //CountercashReturnedForm receive = new CountercashReturnedForm();
            //receive.txt_id.Text = id;
            //receive.txt_name.Text = name;
            //receive.txt_due.Text = amount;        
            //receive.txt_desc.Text = description;
            //receive.txt_receivedAmount.Text = amount;
            //if (receive.ShowDialog() == DialogResult.OK) {
            //    loadgrid();
            //}
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            if (second_user_interface.BusinessType == "Parlour")
            {
                Parlour al = new Parlour();
                Control ctls = this.Parent;
                ctls.Controls.Clear();
                ctls.Controls.Add(al);
            }
            else
            {
                Control ctls = this.Parent;
                allmenu alls = new allmenu();
                ctls.Controls.Clear();
                ctls.Controls.Add(alls);
            }
        }

        private void dgv_all_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv_all.Columns["col_edit"].Index && e.RowIndex >= 0)
            {
                
                txt_name.Text = dgv_all.CurrentRow.Cells["calname"].Value.ToString();
                txt_cash.Text = dgv_all.CurrentRow.Cells["calamount"].Value.ToString();
                txt_withdrawl.Text = dgv_all.CurrentRow.Cells["caldesc"].Value.ToString();
               
                edit.Enabled = true;
                btn_save.Enabled = false;
            }
            else if (e.ColumnIndex == dgv_all.Columns["col_edit"].Index && e.RowIndex >= 0)
            {
              
                txt_name.Text = dgv_all.CurrentRow.Cells["calname"].Value.ToString();
                txt_cash.Text = dgv_all.CurrentRow.Cells["calamount"].Value.ToString();
                txt_withdrawl.Text = dgv_all.CurrentRow.Cells["caldesc"].Value.ToString();
              
                btn_save.Enabled = false;
                edit.Enabled = true;
            }
            
        }
 private void txt_cash_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }
 private void btn_export_to_pdf_Click(object sender, EventArgs e)
        {
            PdfPTable pdfTable = new PdfPTable(dgv_all.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            
            Document pdfDoc = new Document(PageSize.A3, 20f, 20f, 20f, 20f);

            //Adding Header row
            foreach (DataGridViewColumn column in dgv_all.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));

                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (DataGridViewRow row in dgv_all.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(cell.Value.ToString());
                }
            }

            //Exporting to PDF

            //  string folderPath = "C:\\PDFs\\";
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\Cash Drop\\";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            Random rnum = new Random();
            String ramdomnumber = (rnum.Next(1212, 98998)).ToString();

            String Datename = Convert.ToDateTime(DateTime.Now).ToShortDateString();     
            using (FileStream stream = new FileStream(folderPath + "Cash Drop"+ ramdomnumber + ".pdf", FileMode.Create))
            {
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph p = new Paragraph("Cash Drop ");
                p.Alignment = 1;
                pdfDoc.Add(p);          
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }

            MessageBox.Show("Data Has Been Export To Document Successfully","Save",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
 private void label6_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            Counter_Cash_Withdrawl alls = new Counter_Cash_Withdrawl();
            ctls.Controls.Clear();
            ctls.Controls.Add(alls);
        }
        public void clear()
        {
            txt_cash.Text = "";
            txt_name.Text = " ";
            txt_withdrawl.Text = "";
           
            
        }

     
        private void edit_Click(object sender, EventArgs e)
        {
            if (txt_cash.Text != "" || txt_name.Text != "" || txt_withdrawl.Text != "")
            {
               
                string status = "Pending";
                string date_pass = DateTime.Now.ToShortDateString() +" "+ DateTime.Now.ToShortTimeString();
                int update = bllwithdrawl.update(Convert.ToInt32(dgv_all.CurrentRow.Cells["colid"].Value), Convert.ToDateTime(date_pass), Login.sendtext, txt_withdrawl.Text, Convert.ToDecimal(txt_cash.Text), cashdrop_type, txt_name.Text);
               
                MessageBox.Show("updated successfully","Message",MessageBoxButtons.OK,MessageBoxIcon.Information);
                loadgrid();
                AvailableCashinCounter();
                clear();
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            foreach (DataGridViewColumn column in dgv_all.Columns)
            {
                if (column.Index <= 5)
                {
                    dt.Columns.Add(column.HeaderText);
                }
            }
            foreach (DataGridViewRow rows in dgv_all.Rows)
            {
                dt.Rows.Add();
                foreach (DataGridViewCell cell in rows.Cells)
                {
                    if (cell.ColumnIndex <= 5)
                    {
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();

                    }

                }
            }
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS" + "\\Sales Delete Record Excel\\Cash Drop\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (ClosedXML.Excel.XLWorkbook wb = new ClosedXML.Excel.XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Cash Drop");
                wb.SaveAs(folderPath + DateTime.Now.ToString("yyyy-MM-dd hh") + "CashDrop.xlsx");
            }
        }
    }
    }

