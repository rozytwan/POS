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
using System.Runtime.InteropServices;

namespace POS_System.Customer_Management
{
    public partial class CustomerCard_Info : Form
    {
        public CustomerCard_Info(int customer_id)
        {
            InitializeComponent();
            id = customer_id;
        }
        blllCustomerDetailednyo customer = new blllCustomerDetailednyo();
        string fix_spend_balance;
        string fix_balance;
        int id;
        private void CustomerCard_Info_Load(object sender, EventArgs e)
        {
            txt_fix_spend.Hide();
            label3.Hide();
            panel_remarks.Hide();
            panel_fix.Hide();
            DataTable dt = customer.GetpackagenotsetCustomer(Convert.ToString(id));
            if (dt.Rows.Count > 0)
            {
                lbl_cutomerId.Text = Convert.ToString(id);
                lbl_card_no.Text = dt.Rows[0]["card_no"].ToString();
                txt_name.Text = dt.Rows[0]["name"].ToString();
                txt_card_type.Text = dt.Rows[0]["card_type"].ToString();
            }
            DataTable dt1 = customer.Getfixbalance(Convert.ToInt32(id));
            if (dt1.Rows.Count > 0)
            {
                if (dt1.Rows[0]["fix_spend_balance"].ToString() == "")
                {
                    fix_spend_balance = "0.00";
                    txt_fix_spend.Text = "0.00";
                }
              else
                {
                    fix_spend_balance = dt1.Rows[0]["fix_spend_balance"].ToString();
                    txt_fix_spend.Text = fix_spend_balance;
                }
                if (dt1.Rows[0]["fix_balance"].ToString() == "")
                {
                    txt_fix_blc.Text = "0.00";
                }
                else
                {
                    fix_balance = dt1.Rows[0]["fix_balance"].ToString();
                    txt_fix_blc.Text =fix_balance;
                }
                if (dt1.Rows[0]["fix_spend_status"].ToString() == "Active")
                {
                    rdo_non_refundable.Checked = true;
                    txt_fix_spend.Show();
                    label3.Show();
                }
                else
                {
                    rdo_refundable.Checked = true;
                }
                if (dt1.Rows[0]["fix_balance_status"].ToString() == "Active")
                {
                    chk_fix.Checked = true;
                    panel_fix.Show();
                }
            }
            getblc();

        }


        public void refresh()
        {
            txt_name.Text = "";
            txt_card_balance.Text = "";
            txt_card_type.Text = "";
            lbl_cutomerId.Text = "";
            txt_pre_balance.Text = "";
        }
        string card_no;
        public void getblc()
        {
            DataTable dt = customer.GetPreviousBalance(Convert.ToInt32(id));

            if (dt.Rows.Count > 0)
            {
                txt_pre_balance.Text = dt.Rows[0]["customer_balance"].ToString();
            }
            DataTable dt2 = customer.getDataByitsId((id));
            if (dt.Rows.Count > 0)
            {
                card_no = dt2.Rows[0]["card_no"].ToString();
            }
        }
        string balance_status ;
        string payment_mode;
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_card_balance.Text == "")
            {
                MessageBox.Show("Card balance is required");
            }
            else if ((Convert.ToDecimal(txt_card_balance.Text) + Convert.ToDecimal(txt_pre_balance.Text)) < Convert.ToDecimal(txt_fix_spend.Text))
            {
                MessageBox.Show("Fix spend amount is higher than total card balance.", "Transaction Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txt_fix_blc.Text == "")
            {
                MessageBox.Show("Fix Balance Amount is Required .", "Amount Required Alert !!");
            }
            else if (chk_fix.Checked==true && txt_fix_blc.Text=="0.00")
            {
                MessageBox.Show("Fix Balance Cannot be 0.00", "Amount Required Alert !!");
            }
            else if ((Convert.ToDecimal(txt_card_balance.Text) + Convert.ToDecimal(txt_pre_balance.Text)) < Convert.ToDecimal(txt_fix_blc.Text))
            {
                MessageBox.Show("Fix spend amount is higher than total card balance.", "Transaction Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
       else
            {
                DataTable dt = customer.getcustomerbalance(Convert.ToInt32(lbl_cutomerId.Text));

                if (chk_fix.Checked == true && txt_fix_blc.Text!="0.00")
                {
                    balance_status = "Active";
                }
                else
                {
                    balance_status = "Inactive";
                }
            
                if (rbn_cash.Checked==true)
                {
                    payment_mode = "Cash";
                }
                else if (rbn_atmcard.Checked==true)
                {
                    payment_mode = "Atm Card";
                }
                else
                {
                    payment_mode = "Credit";
                }
                if (dt.Rows.Count == 0)
                {
                    if (rdo_refundable.Checked == true)
                    {
                        txt_fix_spend.ReadOnly = true;
                        txt_fix_spend.Text = "0.00";
                        int insert = customer.Insert_balance(Convert.ToInt32(lbl_cutomerId.Text), Convert.ToDecimal(txt_card_balance.Text), "true", Convert.ToDecimal(txt_fix_spend.Text), balance_status, Convert.ToDecimal(txt_fix_blc.Text), balance_status);
                        int i = customer.Insert_add_balance(Convert.ToInt32(lbl_cutomerId.Text), Login.sendtext, Convert.ToDecimal(txt_card_balance.Text), Convert.ToDateTime(DateTime.Now.ToLongTimeString()), "X", payment_mode, txt_remarks.Text);

                    }
                    else if (rdo_non_refundable.Checked == true)
                    {
                        if (txt_fix_spend.Text == "")
                        {
                            MessageBox.Show("Non refundable amount re required", "Amount Required !!");
                        }
                       else
                        {
                            int insert = customer.Insert_balance(Convert.ToInt32(lbl_cutomerId.Text), Convert.ToDecimal(txt_card_balance.Text), "true", Convert.ToDecimal(txt_fix_spend.Text), balance_status, Convert.ToDecimal(txt_fix_blc.Text), balance_status);
                            int it = customer.Insert_add_balance(Convert.ToInt32(lbl_cutomerId.Text), Login.sendtext, Convert.ToDecimal(txt_card_balance.Text), Convert.ToDateTime(DateTime.Now.ToLongTimeString()), "X", payment_mode, txt_remarks.Text);
                        }
                    }
                }
                else
                {
                    if (rdo_refundable.Checked == true)
                    {
                        int update = customer.Add_balance(Convert.ToInt32(lbl_cutomerId.Text), Convert.ToDecimal(txt_card_balance.Text), "true", Convert.ToDecimal(txt_fix_spend.Text), balance_status, Convert.ToDecimal(txt_fix_blc.Text), balance_status);
                        int i = customer.Insert_add_balance(Convert.ToInt32(lbl_cutomerId.Text), Login.sendtext, Convert.ToDecimal(txt_card_balance.Text), Convert.ToDateTime(DateTime.Now.ToLongTimeString()), "X", payment_mode, txt_remarks.Text);
                    }
                    else if (rdo_non_refundable.Checked == true)
                    {
                        if (txt_fix_spend.Text == "")
                        {
                            MessageBox.Show("Non refundable amount re required", "Amount Required !!");
                        }
                        else
                        {
                            int update = customer.Add_balance(Convert.ToInt32(lbl_cutomerId.Text), Convert.ToDecimal(txt_card_balance.Text), "true", Convert.ToDecimal(txt_fix_spend.Text), balance_status, Convert.ToDecimal(txt_fix_blc.Text), balance_status);
                            int it = customer.Insert_add_balance(Convert.ToInt32(lbl_cutomerId.Text), Login.sendtext, Convert.ToDecimal(txt_card_balance.Text), Convert.ToDateTime(DateTime.Now.ToLongTimeString()), "X", payment_mode, txt_remarks.Text);
                        }
                    }

                }
                    printing();
                    printing();
                  int insertlog = customer.InsertCardTransaction(Convert.ToInt32(lbl_cutomerId.Text), Login.sendtext, Convert.ToDecimal(txt_card_balance.Text), Convert.ToDateTime(DateTime.Now.ToLongTimeString()), "Balance Added",payment_mode);
                    if (rbn_credit.Checked)
                    {
                        CreditRefer refer = new CreditRefer();
                        refer.lbl_cutomerId.Text = lbl_cutomerId.Text;
                        // refer.lbl_card_no.Text = lbl_card_no.Text;
                        refer.txt_refer_balance.Text = txt_card_balance.Text;
                        refer.ShowDialog();
                    }
                  }
             refresh();
            this.Hide();
        }
        ClubCardAddBalance ccab = new ClubCardAddBalance();
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
            {
                panel_remarks.Show();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        public void printing()
        {
            ccab.customer_name = txt_name.Text;
            ccab.Card_type = txt_card_type.Text;
            ccab.preview_balance = txt_pre_balance.Text;
            ccab.user_name = Login.sendtext;
            ccab.topup_balance = txt_card_balance.Text;
            ccab.topup_balance = txt_card_balance.Text;
            ccab.fix_expend = txt_fix_spend.Text;
            ccab.card_no = card_no;
            ccab.fix_balance = txt_fix_blc.Text;
            if (rbn_cash.Checked == true)
            {
                ccab.recharge_type = "Cash";
            }
            else if (rbn_atmcard.Checked == true)
            {
                ccab.recharge_type = "ATM Card";
            }
            else
            {
                ccab.recharge_type = "ATM Card";
            }
          
            if (rdo_non_refundable.Checked == true)
            {
                ccab.balance_type = "Non Refundable";
            }
            else
            {
                ccab.balance_type = "Refundable";
            }
            ccab.printtobill();
        }


        private void rdo_non_refundable_Click(object sender, EventArgs e)
        {
            txt_fix_spend.ReadOnly = false;
            txt_fix_spend.Text = fix_spend_balance;
            txt_fix_spend.Show();
            label3.Show();
        }

        private void rdo_refundable_Click(object sender, EventArgs e)
        {
            txt_fix_spend.ReadOnly = true;
            txt_fix_spend.Text = "0.00";
            txt_fix_spend.Hide();
            label3.Hide();
        }
        private void txt_fix_spend_KeyPress(object sender, KeyPressEventArgs e)
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
        private void txt_card_balance_KeyPress(object sender, KeyPressEventArgs e)
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

        private void rdo_non_refundable_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txt_card_balance_Leave(object sender, EventArgs e)
        {

            if (txt_card_balance.Text == "")
            {
                txt_card_balance.Text = "0.00";
            }
        }

        private void txt_card_balance_Enter(object sender, EventArgs e)
        {
            if (txt_card_balance.Text == "0.00")
            {
                txt_card_balance.Text = "";
            }
        }

        private void txt_fix_spend_Leave(object sender, EventArgs e)
        {
            if (txt_fix_spend.Text == "")
            {
                txt_fix_spend.Text = "0.00";
            }
        }

        private void txt_fix_spend_Enter(object sender, EventArgs e)
        {
            if (txt_fix_spend.Text == "0.00")
            {
                txt_fix_spend.Text = "";
            }
        }

        private void rdo_refundable_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chk_fix_Click(object sender, EventArgs e)
        {
            if (chk_fix.Checked==true)
            {
                panel_fix.Show();
            }
            else
            {
                panel_fix.Hide();
            }
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
