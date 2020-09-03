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
using POS_System.CreditForm;

namespace POS_System
{
    public partial class Creditpayform : Form
    {
        public Creditpayform()
        {
           
            InitializeComponent();
        }


        BLLcustomer_credit blcc = new BLLcustomer_credit();
        BLL_credit_paid blcp = new BLL_credit_paid();
        BLLcredit_clear blclear = new BLLcredit_clear();
        DateTime date_now = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        BLLUser blu = new BLLUser();
        decimal sum_credit_paid = 0;
      //  decimal remaining = 0;
        decimal sum_credit_amount = 0;
        public string phone_no;
        public string pay_status;
        string username = Login.sendtext;
        string payment_mode;
        string paid_status;
        string credit_status;
        string creditload = second_user_interface.creditload;
        CheckDynamic cd = new CheckDynamic();
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (creditload=="Hotel Credit")
            {
                paid_status = "HP";
                credit_status = "HC";
            }
            else
            {
                paid_status = "RP";
                credit_status = "RC";
            }
            if (txt_amount.Text == "" || txt_checkedby.Text == "" || txt_payment.Text == "")
            {
                MessageBox.Show("The fields are Empty. Pleas Check!");

            }
            else if (Convert.ToDecimal(txt_amount.Text) < Convert.ToDecimal(txt_payment.Text) || Convert.ToDecimal(txt_remaining.Text) < Convert.ToDecimal(txt_payment.Text))
            {
                //int i = blclear.Insert_credit_clear(Convert.ToInt32(customer_id), Convert.ToDecimal(txt_amount.Text), Convert.ToDecimal(txt_payment.Text), Convert.ToDecimal(txt_remain.Text), txt_checkedby.Text, date_now, txt_remarks.Text);

                //if (i > 0)
                //{
                //    this.DialogResult = DialogResult.OK;
                //    MessageBox.Show("Payment Successfull zero credit amount remaining", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //    this.Hide();

                //}
                MessageBox.Show("Please keep less amount than credit amount");
            }
            else
            {
                if (rbn_cash.Checked)
                {
                    payment_mode = "Cash";

                }
                else if (rbn_cheque.Checked)
                {
                    payment_mode = "Cheque";
                }
                else
                {
                    payment_mode = "Card";
                }


                if (rdo_full.Checked == true)
                {
                  
                       int i = blcp.Insert_credit_paid(Convert.ToInt32(customer_id), Convert.ToDecimal(txt_amount.Text), Convert.ToDecimal(txt_payment.Text), Convert.ToDecimal(txt_remain.Text), txt_checkedby.Text, date_now, payment_mode, "X", paid_status);
                        int insert = blcp.Insert_credit_received(Convert.ToInt32(customer_id), Convert.ToDecimal(txt_amount.Text), Convert.ToDecimal(txt_payment.Text), date_now, payment_mode, paid_status);

                        int dt3 = blcc.Delete_Clear_customer(customer_id, credit_status);
                        int dt4 = blcc.Delete_paid_customer(customer_id, paid_status);
                        printingCredit();
                        printingCredit();
                        MessageBox.Show("Your credit may be cleared");
                        this.Hide();
                    
                }
                else
                {
                    //remaing_check();
                  
                    if (Convert.ToDecimal(txt_remaining.Text) > Convert.ToDecimal(txt_payment.Text))
                    {
                        int i = blcp.Insert_credit_paid(Convert.ToInt32(customer_id), Convert.ToDecimal(txt_amount.Text), Convert.ToDecimal(txt_payment.Text), Convert.ToDecimal(txt_remain.Text), txt_checkedby.Text, date_now,payment_mode,"X",paid_status);
                        int insert = blcp.Insert_credit_received(Convert.ToInt32(customer_id), Convert.ToDecimal(txt_amount.Text), Convert.ToDecimal(txt_payment.Text), date_now,payment_mode,paid_status);

                        if (i > 0)
                        {
                            this.DialogResult = DialogResult.Yes;
                            MessageBox.Show("Partial payment is done", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();

                        }
                        //remaing_check();
                    }


                    else if (Convert.ToDecimal(txt_remain.Text) == (Convert.ToDecimal(txt_payment.Text)))
                    {
                        {
                            int insert = blcp.Insert_credit_received(Convert.ToInt32(customer_id), Convert.ToDecimal(txt_amount.Text), Convert.ToDecimal(txt_payment.Text), date_now,payment_mode,paid_status);
                            int insertrecord = blcp.Insert_credit_paid(Convert.ToInt32(customer_id), Convert.ToDecimal(txt_amount.Text), Convert.ToDecimal(txt_payment.Text), Convert.ToDecimal(txt_remain.Text), username, date_now,payment_mode,"X",paid_status);
                            int dt3 = blcc.Delete_Clear_customer(customer_id,credit_status);
                            int dt4 = blcc.Delete_paid_customer(customer_id,paid_status);
                            MessageBox.Show("Cutomer is removed from credit database", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Hide();
                        }
                    }
                    printingCredit();
                    printingCredit();
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


        //else if (Convert.ToDecimal(txt_amount.Text) > Convert.ToDecimal(txt_payment.Text))
        //{
        //    int i = blcp.Insert_credit_paid(Convert.ToInt32(customer_id), Convert.ToDecimal(txt_amount.Text), Convert.ToDecimal(txt_payment.Text), Convert.ToDecimal(txt_remain.Text), txt_checkedby.Text, date_now);
        //    if (i > 0)
        //    {
        //        this.DialogResult = DialogResult.Yes;
        //        MessageBox.Show("Partial payment is done", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        this.Hide();

        //    }
        //}


        //else if (remaining < 0)
        //{
        //    //int i = blclear.Insert_credit_clear(Convert.ToInt32(customer_id), Convert.ToDecimal(sum_credit_amount), Convert.ToDecimal(sum_credit_paid), Convert.ToDecimal(remaining), txt_checkedby.Text, date_now, txt_remarks.Text);

        //     int dt4 = blcc.Delete_paid_customer(customer_id);
        //    int dt5 = blcc.Delete_Clear_customer(customer_id);

        //      MessageBox.Show("Payment successfull amount is debited now", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //MessageBox.Show("Payment is more than credit amount");
        //}


        public int creditpay_id;
        public int bill_no;
        AllCreditsLists acl = new AllCreditsLists();
        // public static int creditpay_id;
      
        private void Creditpayform_Load(object sender, EventArgs e)
        {
            if (creditload == "Hotel Credit")
            {
                CreditHotelSum();

                DataTable dt1 = blcc.Get_Sum_HotelCredit_Paid(customer_id);
                DataTable dt2 = blcc.Get_HotelCredit_Amount(customer_id);
                if (dt1.Rows.Count > 0 && dt2.Rows.Count > 0)
                {
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
            else
            {
                CreditSum();
                DataTable dt1 = blcc.Get_Sum_Credit_Paid(customer_id);
                DataTable dt2 = blcc.Get_Credit_Amount(customer_id);
                if (dt1.Rows.Count > 0 && dt2.Rows.Count > 0)
                {

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
            if (creditpay_id > 0)
            {
                DataTable dt = blcc.Get_creditpay_Byid(creditpay_id);
                {
                    if (dt.Rows.Count > 0)
                    {
                        txt_payment.Text = dt.Rows[0]["credit_paid"].ToString();
                        //  txt_remain.Text = dt.Rows[0]["credit_left"].ToString();
                        txt_remain.Text = Convert.ToString(Convert.ToDecimal(txt_remaining.Text) - Convert.ToDecimal(txt_payment.Text));

                        Edit.Enabled = true;
                        btn_save.Enabled = false;
                    }
                }
            }
            else
            {
                Edit.Enabled = false;
                btn_save.Enabled = true;
            }

            //DataTable dt1 = blcc.Get_Sum_Credit_Paid(customer_id);
            //DataTable dt2 = blcc.Get_Credit_Amount(customer_id);
            //if (dt1.Rows.Count > 0 && dt2.Rows.Count > 0)
            //{
            //    // int i = blcp.Insert_credit_paid(Convert.ToInt32(customer_id), Convert.ToDecimal(txt_amount.Text), Convert.ToDecimal(txt_payment.Text), Convert.ToDecimal(txt_remain.Text), txt_checkedby.Text, date_now);


            //    if (dt1.Rows[0][0].ToString() == null || dt1.Rows[0][0].ToString() == "")
            //    {
            //        sum_credit_paid = Convert.ToDecimal("0.00");
            //        sum_credit_amount = Convert.ToDecimal(dt2.Rows[0][0].ToString());
            //        txt_remaining.Text = Convert.ToString(Convert.ToDecimal(sum_credit_amount) - Convert.ToDecimal(sum_credit_paid));
            //    }
            //    else
            //    {
            //        sum_credit_amount = Convert.ToDecimal(dt2.Rows[0][0].ToString());
            //        sum_credit_paid = Convert.ToDecimal(dt1.Rows[0][0].ToString());
            //        txt_remaining.Text = Convert.ToString(Convert.ToDecimal(sum_credit_amount) - Convert.ToDecimal(sum_credit_paid));

            //    }

            //}

        }
        //public void remaing_check()
        //{
        //    DataTable dt1 = blcc.Get_Sum_HotelCredit_Paid(customer_id);
        //    DataTable dt2 = blcc.Get_HotelCredit_Amount(customer_id);

        //    if (dt1.Rows.Count > 0 && dt2.Rows.Count > 0)
        //    {
        //        // int i = blcp.Insert_credit_paid(Convert.ToInt32(customer_id), Convert.ToDecimal(txt_amount.Text), Convert.ToDecimal(txt_payment.Text), Convert.ToDecimal(txt_remain.Text), txt_checkedby.Text, date_now);


        //        if (dt1.Rows[0][0].ToString() == null || dt2.Rows[0][0].ToString() == null)
        //        {
        //            sum_credit_paid = Convert.ToDecimal("0.00");
        //            sum_credit_amount = Convert.ToDecimal(dt2.Rows[0][0].ToString());
        //            remaining = sum_credit_amount - sum_credit_paid;
        //        }
        //        else
        //        {
        //            sum_credit_amount = Convert.ToDecimal(dt2.Rows[0][0].ToString());
        //            sum_credit_paid = Convert.ToDecimal(dt1.Rows[0][0].ToString());
        //            remaining = sum_credit_amount - sum_credit_paid;

        //        }

        //    }
        //}
        string user = Login.sendtext;
        int customer_id = CustomerDetail.customer_id;
        public void CreditSum()
        {
            DataTable dt = blcc.Get_Customer_creditsum(customer_id);

            {
                if (dt.Rows.Count > 0)
                {
                    txt_amount.Text = (Convert.ToDecimal(dt.Rows[0][0].ToString())).ToString();
                    txt_checkedby.Text = user;
                }

            }
        }
        public void CreditHotelSum()
        {
            DataTable dt = blcc.Get_hotel_creditsum(customer_id);

            {
                if (dt.Rows.Count > 0)
                {
                    txt_amount.Text = (Convert.ToDecimal(dt.Rows[0][0].ToString())).ToString();
                    txt_checkedby.Text = user;
                }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void rdo_full_Click(object sender, EventArgs e)
        {
            rdo_full.Checked = true;

            txt_payment.Text = txt_remaining.Text;
            txt_payment.Enabled = false;

        }

        private void rdo_partial_Click(object sender, EventArgs e)
        {
            rdo_partial.Checked = true;
            txt_payment.Text = "";
            txt_payment.Enabled = true;
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

                }
                else if (Convert.ToDecimal(txt_amount.Text) < Convert.ToDecimal(txt_payment.Text))
                {
                    btn_save.Enabled = true;
                    txt_payment.ForeColor = Color.Black;
                    txt_remain.Text = (Convert.ToDecimal(txt_payment.Text) - Convert.ToDecimal(txt_amount.Text)).ToString();

                }
                else
                {
                    txt_remain.Text = "0.00";

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

        private void Edit_Click(object sender, EventArgs e)
        {
            if (creditpay_id > 0)
            {
                DataTable dt = blu.getusername(txt_checkedby.Text);
                if (dt.Rows.Count > 0)
                {
                    int update = blcc.Update_creditpay(creditpay_id, Convert.ToDecimal(txt_payment.Text), Convert.ToDecimal(txt_remain.Text));
                    if (update > 0)
                    {
                        MessageBox.Show("Once row is changed");

                    }
                }
            }
        }

        private void rbn_cheque_Click(object sender, EventArgs e)
        {
            bool checkdetail = cd.ChequeDetailAccess();
            if (checkdetail == true)
            {
                pay_status = "Credit Payment";
                ChequeDetail cl = new ChequeDetail(pay_status);
                cl.ShowDialog();
            }
        }
    }
}
