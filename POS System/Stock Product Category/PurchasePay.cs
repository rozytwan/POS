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

namespace POS_System

{
    public partial class PurchasePay : Form
    {
        string name;
        decimal sum_grand_total;
        public PurchasePay(string supplier_name,decimal grand_total)
        {
            name = supplier_name;
            sum_grand_total = grand_total;
            InitializeComponent();
        }
        BLLPurchase bllp = new BLLPurchase();
        BLL_Fiscal blfsc = new BLL_Fiscal();
        DataTable dt = new DataTable();
        Bll_CashwithDrawl bllwithdrawl = new Bll_CashwithDrawl();
        // string supplier_name = SupplierPurchase.supplier_name;
        string date_pass = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
        int supplier_id=SupplierPurchase.sup_id;
        private void rbn_card_CheckedChanged(object sender, EventArgs e)
        {

        }
        decimal grand_total = SupplierPurchase.grand_total;
        decimal sum_paid;
        private void PurchasePay_Load(object sender, EventArgs e)
       {
            txt_amount.Text =Convert.ToString(sum_grand_total);
            dt = bllp.Getsupplier(name);
          
            if (dt.Rows.Count > 0)
            {
                supplier_id = Convert.ToInt32(dt.Rows[0]["sup_id"].ToString());
            }
            DataTable dt1 = bllp.GetSupplierPay(supplier_id);
            if (dt1.Rows[0][0].ToString()!=null && dt1.Rows[0][0].ToString()!="")
            {
                txt_remaining.Text =(dt1.Rows[0]["purchase_pay"].ToString());
            }
            else
            {
                txt_remaining.Text =("0.00");
            }
            txt_remaining.Text = Convert.ToString(Convert.ToDecimal(txt_amount.Text) - Convert.ToDecimal(txt_remaining.Text));
        }
        DateTime today = Convert.ToDateTime(DateTime.Now.ToString());

        string payment_mode;
        string fiscal_year;
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_payment.Text == "")
            {
                MessageBox.Show("Payment Amount is Required Alert !!", "Amount Required Alert !!");
            }
            else {
            
                
            dt = bllp.Getsupplier(name);
            if (rbn_cash.Checked)
            {
                 payment_mode = "Cash";
            }
            else
            {
                payment_mode = "Cheque";
            }
                if (rdo_full.Checked==true)
                {
                    if (dt.Rows.Count > 0)
                    {
                       // int supplier_id = Convert.ToInt32(dt.Rows[0]["sup_id"].ToString());

                        int insert = bllp.createpurchasepay(supplier_id, Convert.ToDecimal(txt_amount.Text), Convert.ToDecimal(txt_payment.Text), Convert.ToDecimal(txt_remain.Text), "Partialpay", today);
                        DataTable dt1 = bllp.GetTransactionCategory();
                        if (dt1.Rows.Count > 0)
                        {
                            int category_id = Convert.ToInt32(dt1.Rows[0]["category_id"].ToString());
                            DataTable dt = blfsc.get_all_data_from_fiscal("True");
                            if (dt.Rows.Count > 0)
                            {
                                fiscal_year = dt.Rows[0]["fiscal_year"].ToString();

                            }
                            int inserts = bllp.CreateTransactionPurchase(category_id, "Inventory Pay", today, name, -Convert.ToDecimal(txt_payment.Text), fiscal_year, payment_mode);
                            int i = bllwithdrawl.insertintotable(Convert.ToDateTime(date_pass), Login.sendtext,"Purchase Payment", Convert.ToDecimal(txt_payment.Text), "Pending", name);
                        }
                        if (insert > 0)
                        {
                            int update = bllp.UpdatePurchase(name);
                            int delete = bllp.DeletePayment(supplier_id);
                             MessageBox.Show("Successfully Inserted", "Inserted Successfully");
                            this.Close();
                        }
                    }
                }
              else  
                {
                    if (Convert.ToDecimal(txt_remaining.Text) > Convert.ToDecimal(txt_payment.Text))
                    {
                     //   int supplier_id = Convert.ToInt32(dt.Rows[0]["sup_id"].ToString());

                        int insert = bllp.createpurchasepay(supplier_id, Convert.ToDecimal(txt_amount.Text), Convert.ToDecimal(txt_payment.Text), Convert.ToDecimal(txt_remain.Text), "Partialpay", today);
                        DataTable dt1 = bllp.GetTransactionCategory();
                        if (dt1.Rows.Count > 0)
                        {
                            int category_id = Convert.ToInt32(dt1.Rows[0]["category_id"].ToString());
                            DataTable dt = blfsc.get_all_data_from_fiscal("True");
                            if (dt.Rows.Count > 0)
                            {
                                fiscal_year = dt.Rows[0]["fiscal_year"].ToString();

                            }
                            int inserts = bllp.CreateTransactionPurchase(category_id, "Inventory Pay", today, name, -Convert.ToDecimal(txt_payment.Text), fiscal_year, payment_mode);
                            int i = bllwithdrawl.insertintotable(Convert.ToDateTime(date_pass), Login.sendtext, "Purchase Payment", Convert.ToDecimal(txt_payment.Text), "Pending", name);
                        }
                        if (insert > 0)
                        {
                            MessageBox.Show("Successfully Inserted", "Inserted Successfully");
                            this.Close();
                        }
                    }
                    else if (Convert.ToDecimal(txt_remain.Text) == (Convert.ToDecimal(txt_payment.Text)))
                    {
                       // int supplier_id = Convert.ToInt32(dt.Rows[0]["sup_id"].ToString());

                        int insert = bllp.createpurchasepay(supplier_id, Convert.ToDecimal(txt_amount.Text), Convert.ToDecimal(txt_payment.Text), Convert.ToDecimal(txt_remain.Text), "Partialpay", today);
                        DataTable dt1 = bllp.GetTransactionCategory();
                        if (dt1.Rows.Count > 0)
                        {
                            int category_id = Convert.ToInt32(dt1.Rows[0]["category_id"].ToString());
                            DataTable dt = blfsc.get_all_data_from_fiscal("True");
                            if (dt.Rows.Count > 0)
                            {
                                fiscal_year = dt.Rows[0]["fiscal_year"].ToString();

                            }
                            int inserts = bllp.CreateTransactionPurchase(category_id, "Inventory Pay", today, name, -Convert.ToDecimal(txt_payment.Text), fiscal_year, payment_mode);
                            int i = bllwithdrawl.insertintotable(Convert.ToDateTime(date_pass), Login.sendtext, "Purchase Payment", Convert.ToDecimal(txt_payment.Text), "Pending", name);
                        }
                        if (insert > 0)
                        {
                            int update = bllp.UpdatePurchase(name);
                            int delete = bllp.DeletePayment(supplier_id);
                            MessageBox.Show("Successfully Inserted", "Inserted Successfully");
                            this.Close();
                        }
                    }
                }
              //  UserControl_purchase_form_Load.this(null, null);
            }
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
                    txt_remain.Text = (Convert.ToDecimal(txt_remaining.Text) - Convert.ToDecimal(txt_payment.Text)).ToString();

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdo_full_Click(object sender, EventArgs e)
        {
            rdo_full.Checked = true;

            txt_payment.Text = txt_remaining.Text;
            txt_payment.Enabled = false;
        }

        private void Edit_Click(object sender, EventArgs e)
        {
           
        }
    }
}
