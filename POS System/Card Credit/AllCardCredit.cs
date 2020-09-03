using BLLS;
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
    public partial class AllCardCredit : UserControl
    {
        public AllCardCredit()
        {
            InitializeComponent();
        }

        BLL_Card_Credit bllcredit = new BLL_Card_Credit();
        BLLcustomer_credit blcc = new BLLcustomer_credit();
        int customer_id = CardCreditRecord.customer_id;
        private void AllCardCredit_Load(object sender, EventArgs e)
        {
           
            LoadCustomerCredit();
            CreditSum();
            PaidSum();
            //  calculation();
        
            DataTable dt = blcc.Get_Customer_ById(customer_id);
            {
                if (dt.Rows.Count > 0)
                {
                    Byte[] image = (byte[])dt.Rows[0]["image"];
                    MemoryStream msstream = new MemoryStream(image);
                    picbox_user.Image = System.Drawing.Image.FromStream(msstream);
                    lbl_name.Text = dt.Rows[0]["name"].ToString();
                    lbl_phone.Text = dt.Rows[0]["phone"].ToString();
                    lbl_address.Text = dt.Rows[0]["address"].ToString();
                    lbl_city.Text = dt.Rows[0]["city"].ToString();
                    lbl_email.Text = dt.Rows[0]["email"].ToString();
                    lbl_id.Text = dt.Rows[0]["id"].ToString();
                    lbl_remain.Text = (Convert.ToDecimal(lbl_total.Text) - Convert.ToDecimal(lbl_pay.Text)).ToString();
                }
            }

        }
        public void LoadCustomerCredit()
        {
            DataTable dt = bllcredit.Get_customer_credit_Customerid(customer_id);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int abc = dataGridView1.Rows.Add();
                    int customer_id = Convert.ToInt32(dt.Rows[i]["customer_id"].ToString());

                    DataTable dt1 = blcc.Get_Customer_ById(customer_id);
                    if (dt1.Rows.Count > 0)
                    {
                        dataGridView1.Rows[i].Cells["col_customername"].Value = dt1.Rows[0]["name"].ToString();
                    }
                    //dataGridView1.Rows[i].Cells["col_bill_no"].Value = dt.Rows[i]["bill_no"].ToString();

                    dataGridView1.Rows[i].Cells["col_credit_amount"].Value = dt.Rows[i]["credit_amount"].ToString();
                    dataGridView1.Rows[i].Cells["col_credit_by"].Value = dt.Rows[i]["credit_by"].ToString();
                    dataGridView1.Rows[i].Cells["col_credit_date"].Value = dt.Rows[i]["credit_date"].ToString();
                    dataGridView1.Rows[i].Cells["col_refer_by"].Value = dt.Rows[i]["refer_by"].ToString();

                }
            }

        }
        public void CreditSum()
        {
            DataTable dt = bllcredit.Get_Customer_creditsum(customer_id);

            {
                if (dt.Rows.Count > 0)
                {
                    lbl_total.Text = (Convert.ToDecimal(dt.Rows[0][0].ToString())).ToString();

                }

            }
        }
        public void PaidSum()
        {
            DataTable dt = bllcredit.Get_Customer_paidsum(customer_id);
            {
                if (dt.Rows.Count > 0 && dt.Rows[0][0].ToString()!="")
                {
                        lbl_pay.Text = (1 * (Convert.ToDecimal(dt.Rows[0][0].ToString()))).ToString();

                    }
                    else
                    {
                        MessageBox.Show("No payment have been done till now", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
        }
        private void btn_clearall_Click(object sender, EventArgs e)
        {
            CardCreditPay cl = new CardCreditPay();
            cl.phone_no = lbl_phone.Text;
            cl.lbl_names.Text = lbl_name.Text;
            cl.Show();
        }

        private void Show_paid_credits_Click(object sender, EventArgs e)
        {
            Control ctrl = this.Parent;
            CreditPayList pay = new CreditPayList();
            ctrl.Controls.Clear();
            ctrl.Controls.Add(pay);
         }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Control ctrl = this.Parent;
            CardCreditRecord pay = new CardCreditRecord();
            ctrl.Controls.Clear();
            ctrl.Controls.Add(pay);

        }
    }
}
