using BLLS;
using POS_System.CreditForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System
{
    public partial class CardCreditPay : Form
    {
        public CardCreditPay()
        {
            InitializeComponent();
        }
        BLL_Card_Credit bllcredit = new BLL_Card_Credit();
        DateTime date_now = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
        int customer_id = CardCreditRecord.customer_id;
        decimal sum_credit_paid = 0;
        decimal remaining = 0;
        decimal sum_credit_amount = 0;
        public string phone_no;
        private void CardCreditPay_Load(object sender, EventArgs e)
        {
            CreditSum();

            lbl_customerId.Text = customer_id.ToString();

          
      
            DataTable dt1 = bllcredit.Get_Customer_paidsum(customer_id);
            DataTable dt2 = bllcredit.Get_Credit_Amount(customer_id);

            if (dt1.Rows.Count > 0 && dt2.Rows.Count > 0)
            {
                // int i = blcp.Insert_credit_paid(Convert.ToInt32(customer_id), Convert.ToDecimal(txt_amount.Text), Convert.ToDecimal(txt_payment.Text), Convert.ToDecimal(txt_remain.Text), txt_checkedby.Text, date_now);


                if (dt1.Rows[0][0].ToString() == null || dt1.Rows[0][0].ToString() == "")
                {
                    sum_credit_paid = Convert.ToDecimal("0.00");
                    sum_credit_amount = Convert.ToDecimal(dt2.Rows[0][0].ToString());
                    txt_remaining.Text = Convert.ToString(Convert.ToDecimal(sum_credit_amount) - Convert.ToDecimal(sum_credit_paid));
                }
                else
                {
                    sum_credit_amount = Convert.ToDecimal(dt2.Rows[0][0].ToString());
                    sum_credit_paid = Convert.ToDecimal(dt1.Rows[0][0].ToString());
                    txt_remaining.Text = Convert.ToString(Convert.ToDecimal(sum_credit_amount) - Convert.ToDecimal(sum_credit_paid));

                }

            }
        }
        string user = Login.sendtext;

        public DialogResult DialogResult { get; private set; }

        public void CreditSum()
        {
            DataTable dt = bllcredit.Get_Customer_creditsum(customer_id);

            {
                if (dt.Rows.Count > 0)
                {
                    txt_amount.Text = (Convert.ToDecimal(dt.Rows[0][0].ToString())).ToString();
                    txt_checkedby.Text = user;
                }

            }
        }
        public void printingCredit()
        {
            CreditPrinting pc = new CreditPrinting();
            pc.cashier = txt_checkedby.Text;
            pc.cash_received_amount = txt_payment.Text;
            pc.credit_amount = txt_amount.Text;
            pc.customer_name = lbl_names.Text;
            pc.past_remaining_amount = txt_remaining.Text;
            pc.total_reamaing_amount = txt_remain.Text;
            pc.phone_no = phone_no;
            pc.printtobill();
        }
        public void remaing_check()
        {
            DataTable dt1 = bllcredit.Get_Customer_paidsum(customer_id);
            DataTable dt2 = bllcredit.Get_Credit_Amount(customer_id);

            if (dt1.Rows.Count > 0 && dt2.Rows.Count > 0)
            {
                // int i = blcp.Insert_credit_paid(Convert.ToInt32(customer_id), Convert.ToDecimal(txt_amount.Text), Convert.ToDecimal(txt_payment.Text), Convert.ToDecimal(txt_remain.Text), txt_checkedby.Text, date_now);


                if (dt1.Rows[0][0].ToString() == null || dt1.Rows[0][0].ToString() == "")
                {
                    sum_credit_paid = Convert.ToDecimal("0.00");
                    sum_credit_amount = Convert.ToDecimal(dt2.Rows[0][0].ToString());
                    remaining = sum_credit_amount - sum_credit_paid;
                }
                else
                {
                    sum_credit_amount = Convert.ToDecimal(dt2.Rows[0][0].ToString());
                    sum_credit_paid = Convert.ToDecimal(dt1.Rows[0][0].ToString());
                    remaining = sum_credit_amount - sum_credit_paid;

                }

            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_amount.Text == "" || txt_checkedby.Text == "" || txt_remarks.Text == "" || txt_payment.Text == "")
            {
                MessageBox.Show("The fields are Empty. Pleas Check!");

            }
            else if (Convert.ToDecimal(txt_amount.Text) < Convert.ToDecimal(txt_payment.Text) || Convert.ToDecimal(txt_remaining.Text) < Convert.ToDecimal(txt_payment.Text))
            {
             
                MessageBox.Show("Please keep less amount than credit amount");
            }
            else
            {

                if (rdo_full.Checked == true)
                {

                    int i = bllcredit.Insert_credit_paid(Convert.ToInt32(customer_id), Convert.ToDecimal(txt_amount.Text), Convert.ToDecimal(txt_payment.Text), Convert.ToDecimal(txt_remain.Text), txt_checkedby.Text,date_now);
                    int insert = bllcredit.Insert_credit_received(Convert.ToInt32(customer_id), Convert.ToDecimal(txt_amount.Text), Convert.ToDecimal(txt_payment.Text), date_now, user);

                    int dt3 = bllcredit.Delete_Clear_customer(customer_id);
                    int dt4 = bllcredit.Delete_Credit_Paid(customer_id);
                    printingCredit();
                    printingCredit();
                    MessageBox.Show("Your credit may be cleared");

                    this.Hide();

                }
                else
                {
                    remaing_check();
                    if (remaining > Convert.ToDecimal(txt_payment.Text))
                    {
                        int i = bllcredit.Insert_credit_paid(Convert.ToInt32(customer_id), Convert.ToDecimal(txt_amount.Text), Convert.ToDecimal(txt_payment.Text), Convert.ToDecimal(txt_remain.Text), txt_checkedby.Text,date_now);
                        int insert = bllcredit.Insert_credit_received(Convert.ToInt32(customer_id), Convert.ToDecimal(txt_amount.Text), Convert.ToDecimal(txt_payment.Text), date_now, user);

                        if (i > 0)
                        {
                            this.DialogResult = DialogResult.Yes;
                            MessageBox.Show("Partial payment is done", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();

                        }
                        remaing_check();
                    }


                    else if (remaining == (Convert.ToDecimal(txt_payment.Text)))
                    {
                        {
                            int i = bllcredit.Insert_credit_paid(Convert.ToInt32(customer_id), Convert.ToDecimal(txt_amount.Text), Convert.ToDecimal(txt_payment.Text), Convert.ToDecimal(txt_remain.Text), txt_checkedby.Text, date_now);
                            int insert = bllcredit.Insert_credit_received(Convert.ToInt32(customer_id), Convert.ToDecimal(txt_amount.Text), Convert.ToDecimal(txt_payment.Text), date_now, user);


                            int dt3 = bllcredit.Delete_Clear_customer(customer_id);
                           int dt4 = bllcredit.Delete_Credit_Paid(customer_id);

                            MessageBox.Show("Cutomer is removed from credit database", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Hide();
                        }
                    }
                    printingCredit();
                    printingCredit();
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void rdo_partial_Click(object sender, EventArgs e)
        {
            rdo_partial.Checked = true;
            txt_payment.Text = "";
            txt_payment.Enabled = true;
        }

        private void rdo_full_Click(object sender, EventArgs e)
        {
            rdo_full.Checked = true;

            txt_payment.Text = txt_remaining.Text;
            txt_payment.Enabled = false;
        }

        private void txt_payment_TextChanged(object sender, EventArgs e)
        {
            if (txt_payment.Text.Length > 0)
            {
                if (Convert.ToDecimal(txt_remaining.Text) > Convert.ToDecimal(txt_payment.Text))
                {
                    btn_save.Enabled = true;
                    txt_payment.ForeColor = Color.Red;
                    txt_remain.Text = (Convert.ToDecimal(txt_remaining.Text) - Convert.ToDecimal(txt_payment.Text)).ToString();

                    txt_remarks.Text = "Partial Paid";
                }
                else if (Convert.ToDecimal(txt_amount.Text) < Convert.ToDecimal(txt_payment.Text))
                {
                    btn_save.Enabled = true;
                    txt_payment.ForeColor = Color.Black;
                    txt_remain.Text = (Convert.ToDecimal(txt_payment.Text) - Convert.ToDecimal(txt_amount.Text)).ToString();

                    txt_remarks.Text = "Debit amount";
                }
                else
                {
                    txt_remain.Text = "0.00";
                    txt_remarks.Text = "Full paid";
                }
            }

        }

        private void txt_payment_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
(e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
