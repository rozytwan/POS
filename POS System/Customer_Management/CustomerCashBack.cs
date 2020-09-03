using BLLS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System.Customer_Management
{
    public partial class CustomerCashBack : Form
    {
        public CustomerCashBack(int customer_id)
        {
            InitializeComponent();
            id = customer_id;
        }
        public string card_type;
        decimal card_sales = 0;
        NonRefundableCashBack nrcb = new NonRefundableCashBack();
        blllCustomerDetailednyo customer = new blllCustomerDetailednyo();
        DataTable dt1 = new DataTable();
        private void CustomerCashBack_Load(object sender, EventArgs e)
        {
            btn_save.DialogResult = DialogResult.Cancel;
            DataTable dt2 = customer.GetpackagenotsetCustomer(Convert.ToString(id));
            if (dt2.Rows.Count > 0)
            {
                lbl_customer.Text = dt2.Rows[0]["name"].ToString();
                lbl_customer_no.Text = dt2.Rows[0]["card_no"].ToString();
                lbl_card_type.Text = dt2.Rows[0]["card_type"].ToString();
            }
            DataTable dt3 = customer.GetPreviousBalance(id);
            if (dt3.Rows.Count > 0)
            {
                txt_card_blc.Text = dt3.Rows[0]["customer_balance"].ToString();
            }
            DataTable dt = customer.getid(Convert.ToInt32(id));
            if (dt.Rows.Count > 0)
            {

                DataTable dt_cash_sale_sum = customer.CardSales(lbl_customer_no.Text, Convert.ToDateTime(dt.Rows[0]["date"]));
                if (dt_cash_sale_sum.Rows.Count > 0 && dt_cash_sale_sum.Rows[0][0].ToString() != "")
                {
                    for (int i = 0; dt_cash_sale_sum.Rows.Count > i; i++)
                    {
                        card_sales += Convert.ToDecimal(dt_cash_sale_sum.Rows[i][1].ToString());
                    }
                    txt_sales.Text = (card_sales).ToString("#.##");
                }
                else
                {
                    txt_sales.Text = "0.00";
                }
            }
            else
            {
                DataTable dt_cash_sale_sum = customer.CardSales(lbl_customer_no.Text);
                if (dt_cash_sale_sum.Rows.Count > 0 && dt_cash_sale_sum.Rows[0][0].ToString() != "")
                {
                    for (int i = 0; dt_cash_sale_sum.Rows.Count > i; i++)
                    {
                        card_sales += Convert.ToDecimal(dt_cash_sale_sum.Rows[i][1].ToString());
                    }
                    txt_sales.Text = (card_sales).ToString("#.##");
                }
                else
                {
                    txt_sales.Text = "0.00";
                }
            }

            dt1 = customer.Getfixbalance(Convert.ToInt32(id));
            if (dt1.Rows.Count > 0)
            {
                if (dt1.Rows[0]["fix_spend_balance"].ToString() == "")
                {
                    txt_non_refundable.Text = "0.00";
                }
                else
                {
                    txt_non_refundable.Text = dt1.Rows[0]["fix_spend_balance"].ToString();
                }
                if (dt1.Rows[0]["fix_balance"].ToString() == "")
                {
                    txt_fix.Text = "0.00";
                }
                else
                {
                    txt_fix.Text = dt1.Rows[0]["fix_balance"].ToString();
                }
            }
            txt_refundable.Text = nrcb.RefundableAmount(Convert.ToDecimal(txt_card_blc.Text), Convert.ToDecimal(txt_sales.Text), Convert.ToDecimal(txt_non_refundable.Text), Convert.ToInt32(id)).ToString("#.##");

        }
        private void rdo_full_Click(object sender, EventArgs e)
        {
            rdo_full.Checked = true;
            txt_cash_back.ReadOnly = true;

            txt_cash_back.Text = txt_refundable.Text;
            txt_cash_back.Enabled = true;
            txt_fix.Text = "0.00";
            txt_avialable.Text = "0.00";
            txt_useable.Text = "0.00";
            txt_remarks.Text = "Full Cash Back";

        }

        private void rdo_partial_Click(object sender, EventArgs e)
        {
            rdo_partial.Checked = true;
            txt_avialable.Text = txt_card_blc.Text;
            txt_useable.Text = txt_refundable.Text;
            txt_cash_back.ReadOnly = false;
            txt_cash_back.Text = "";
            txt_cash_back.Enabled = true;
            txt_fix.Text = dt1.Rows[0]["fix_balance"].ToString();
            txt_remarks.Text = "Partial Cash Back";


        }

        private void txt_cash_back_TextChanged(object sender, EventArgs e)
        {
            if (rdo_partial.Checked)
            {
                if (txt_cash_back.Text.Length > 0 && txt_refundable.Text.Length > 0)
                {

                    if (Convert.ToDecimal(txt_cash_back.Text) > Convert.ToDecimal(txt_refundable.Text))
                    {
                        MessageBox.Show("Over card balance amount cash back not possible", "Check card balance!!");
                        int i = (txt_cash_back.Text.Length);
                        if (i > 0)
                        {
                            txt_cash_back.Text = txt_cash_back.Text.Substring(0, i - 1);
                        }
                    }
                    else if (Convert.ToDecimal(txt_cash_back.Text) > (Convert.ToDecimal(txt_refundable.Text) -Convert.ToDecimal( txt_fix.Text)))
                    {
                        MessageBox.Show("Fix deposite Is Available cash back is higher in  comparison", "Fix balance !!");
                        int i = (txt_cash_back.Text.Length);
                        if (i > 0)
                        {
                            txt_cash_back.Text = txt_cash_back.Text.Substring(0, i - 1);
                        }
                    }

                    else
                    {
                        btn_save.Enabled = true;
                        txt_remarks.ForeColor = Color.Red;
                        txt_avialable.Text = ((txt_refundable.Text));
                        txt_useable.Text = (Convert.ToDecimal(txt_refundable.Text) - Convert.ToDecimal(txt_cash_back.Text) - Convert.ToDecimal(txt_fix.Text)).ToString("#.##");
                        //txt_fix.Text = "500";
                        txt_remarks.Text = "Partial Cash Back";
                        if (txt_useable.Text == "")
                        {
                            txt_useable.Text = "0.00";
                        }
                    }
                }
            }
            else
            {

                txt_fix.Text = "0.00";
                txt_avialable.Text = "0.00";
                txt_useable.Text = "0.00";
                txt_remarks.ForeColor = Color.Red;
                txt_remarks.Text = "Full Cash Back";
            }
        }

        private void txt_cash_back_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        public int id;
        string name = Login.sendtext;
        DateTime date = Convert.ToDateTime(DateTime.Now.ToString());
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txt_cash_back.Text) > Convert.ToDecimal(txt_refundable.Text) && rdo_partial.Checked)
            {
                MessageBox.Show("Sorry Cash Back Balance is higher than refundable amount", "Transaction Fail!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Check();
                this.Hide();
            }
        }
        public void Check()
        {
            var confirmResult = MessageBox.Show("Are you you want Cash Back ??",
                                                  "Confirm Cash Back!!", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                AdminAccess acc = new AdminAccess();
                acc.ShowDialog();
                if (acc.DialogResult == DialogResult.OK)
                {

                    if (rdo_partial.Checked == true)
                    {
                        //    DataTable dt = customer.Searchbycard(txtpan_no.Text);
                        int partial = customer.Insert_Cash_Back(Convert.ToInt32(id), name, Convert.ToDecimal(txt_cash_back.Text), date, "Partial", "X");
                        int update = customer.Update_customer_balane(Convert.ToInt32(id), Convert.ToDecimal(txt_cash_back.Text));
                        printing();
                        printing();
                    }
                    else if (rdo_full.Checked == true)
                    {
                        int full = customer.Insert_Cash_Back(Convert.ToInt32(id), name, Convert.ToDecimal(txt_cash_back.Text), date, "Full", "X");
                        int delete = customer.DeleteCustomer(Convert.ToInt32(id));
                        printing();
                        printing();
                    }
                    int insertlog = customer.InsertCardTransaction(Convert.ToInt32(id), name, Convert.ToDecimal(txt_cash_back.Text), date, "Cash Back","Cash");

                }
            }
            btn_save.DialogResult = DialogResult.OK;
        }
        ClubCardBalanceReturn ccab = new ClubCardBalanceReturn();
        public void printing()
        {
            ccab.customer_name = lbl_customer.Text;
            ccab.Card_type = card_type;
            ccab.card_no = lbl_customer_no.Text;
            ccab.return_balance = txt_cash_back.Text;
            ccab.cash_in_card = txt_card_blc.Text;
            ccab.card_bill_amount = txt_sales.Text;
            ccab.cash_back_mode = txt_remarks.Text;
            ccab.non_refundable_balance = txt_non_refundable.Text;
            ccab.refundable_amount = txt_refundable.Text;
            ccab.useable_balance = txt_useable.Text;
            ccab.user_name = Login.sendtext;
            ccab.printtobill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void rdo_partial_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txt_cash_back_Leave(object sender, EventArgs e)
        {
            if (txt_cash_back.Text == "")
            {
                txt_cash_back.Text = "0.00";
            }
        }

        private void txt_cash_back_Enter(object sender, EventArgs e)
        {
            if (txt_cash_back.Text == "0.00")
            {
                txt_cash_back.Text = "";
            }
        }
    }

}



