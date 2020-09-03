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
    public partial class CustomerCardDetail : Form
    {
        public CustomerCardDetail()
        {
            InitializeComponent();
        }
        blllCustomerDetailednyo customer = new blllCustomerDetailednyo();
        BLL_Billing_Tax blbt = new BLL_Billing_Tax();
        private void CustomerCardDetail_Load(object sender, EventArgs e)
        {
            txt_searchbox.Focus();
            panel2.Show();
            panel3.Hide();
        }

        private void txt_searchbox_TextChanged(object sender, EventArgs e)       
        {
           
            
        }
        public enum Effect { Roll, Slide, Center, Blend }

        public static void Animate(Control ctl, Effect effect, int msec, int angle)
        {

            int flags = effmap[(int)effect];

            if (ctl.Visible)
            {
                flags |= 0x10000; angle += 180;

            }

            else
            {

                if (ctl.TopLevelControl == ctl) flags |= 0x20000;
                else if (effect == Effect.Blend) throw new ArgumentException();

            }

            flags |= dirmap[(angle % 360) / 45];

            bool ok = AnimateWindow(ctl.Handle, msec, flags);

            if (!ok) throw new Exception("Animation failed");

            ctl.Visible = !ctl.Visible;

        }

        private static int[] dirmap = { 1, 5, 4, 6, 2, 10, 8, 9 };

        private static int[] effmap = { 0, 0x40000, 0x10, 0x80000 };

        [DllImport("user32.dll")]

        private static extern bool AnimateWindow(IntPtr handle, int msec, int flags);
        public DateTime today;
     
        private void btn_itemsales_Click(object sender, EventArgs e)
        {
           
                today = Convert.ToDateTime(DateTime.Today.ToShortDateString());
            DataTable dt = customer.GetItems(txt_searchbox.Text,today);
            ItemSales item = new ItemSales();
            if (dt.Rows.Count>0)
            {
               
                for (int inc = 0; inc < dt.Rows.Count; inc++)
                {
                    int ww = item.dataGridView1.Rows.Add();
                    item.dataGridView1.Rows[inc].Cells["calitem"].Value = dt.Rows[inc]["item_name"].ToString();
                    item.dataGridView1.Rows[inc].Cells["calquantity"].Value = dt.Rows[inc]["quantity"].ToString();
                    item.dataGridView1.Rows[inc].Cells["caltotal"].Value = dt.Rows[inc]["total"].ToString();
                    item.dataGridView1.Rows[inc].Cells["cal_cost"].Value = dt.Rows[inc]["cost"].ToString();
                    item.dataGridView1.Rows[inc].Cells["caldate"].Value = dt.Rows[inc]["date_of_sale"].ToString();
                    item.dataGridView1.Rows[inc].Cells["calcardamount"].Value = dt.Rows[inc]["card_amount"].ToString();
                    item.dataGridView1.Rows[inc].Cells["calcashamt"].Value = dt.Rows[inc]["cash_amount"].ToString();
                    item.dataGridView1.Rows[inc].Cells["calpaymode"].Value = dt.Rows[inc]["payment_mode"].ToString();
                    item.dataGridView1.Rows[inc].Cells["calcashier_name"].Value = dt.Rows[inc]["cashier_name"].ToString();
                    string bill_no = dt.Rows[inc]["bill_no"].ToString();
                    item.dataGridView1.Rows[inc].Cells["calbill_no"].Value = bill_no;
                    DateTime date_of_billing = Convert.ToDateTime(dt.Rows[inc]["date2"].ToString());
                    item.dataGridView1.Rows[inc].Cells["caldate"].Value = Convert.ToDateTime(dt.Rows[inc]["date_of_sale"].ToString());
                    DataTable dt_bill = blbt.get_all_tax_by_bill_no(bill_no, date_of_billing);
                    if (dt_bill.Rows.Count > 0)
                    {
                        item.dataGridView1.Rows[inc].Cells["cal_tax"].Value = dt_bill.Rows[0]["tax_amount"].ToString();
                        item.dataGridView1.Rows[inc].Cells["cal_service_charge"].Value = dt_bill.Rows[0]["service_charge"].ToString();
                    }
                    else
                    {
                        item.dataGridView1.Rows[inc].Cells["cal_tax"].Value = "0.00";
                        item.dataGridView1.Rows[inc].Cells["cal_service_charge"].Value = "0.00";
                    }
                    item.dataGridView1.Rows[inc].Cells["cal_grand_total"].Value = dt.Rows[inc]["grand_total"].ToString();
                    item.dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dt.Rows[inc]["sales_type"].ToString();
                    item.dataGridView1.Rows[inc].Cells["cal_sales_id"].Value = dt.Rows[inc]["rest_sale_id"].ToString();
                    item.dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dt.Rows[inc]["table_no"].ToString();
                    item.dataGridView1.Rows[inc].Cells["cal_category_name"].Value = dt.Rows[inc]["category_name"].ToString();
                    item.dataGridView1.Rows[inc].Cells["cal_discount"].Value = dt.Rows[inc]["discount"].ToString();
                    item.dataGridView1.Rows[inc].Cells["cal_sub_total"].Value = dt.Rows[inc]["sub_total"].ToString();
                    item.dataGridView1.Rows[inc].Cells["cal_date2"].Value = dt.Rows[inc]["date2"].ToString();
                    item.dataGridView1.Rows[inc].Cells["cal_customer_pan"].Value = dt.Rows[inc]["customer_no"].ToString();
                    item.dataGridView1.Rows[inc].Cells["cal_customer_name"].Value = dt.Rows[inc]["customer_name"].ToString();
                
                }
                item.lbl_card_no.Text = txt_searchbox.Text;
                item.Show();

            }
            else
            {
                MessageBox.Show("Data is not available", "Data Empty !!");
            }
   
 

        }

        private void txt_searchbox_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }
        string fix_balance;
        private void txt_searchbox_KeyDown(object sender, KeyEventArgs e)
        {
           
                if (e.KeyCode == Keys.Enter)
            {
                if (txt_searchbox.Text == "")
                {
                    panel3.Hide();
                }
                else
                {
                    DataTable dt = customer.Searchbycard(txt_searchbox.Text);
                    if (dt.Rows.Count > 0)
                    {
                        lbl_name.Text = dt.Rows[0]["name"].ToString();
                        lbl_surname.Text = dt.Rows[0]["lastname"].ToString();
                        lbl_phone.Text = dt.Rows[0]["phone"].ToString();
                        lbl_card_type.Text = dt.Rows[0]["card_type"].ToString();
                        DataTable dt1 = customer.GetPreviousBalance(Convert.ToInt32(dt.Rows[0]["id"].ToString()));
                        if (dt1.Rows.Count > 0)
                        {
                            lbl_balance.Text = dt1.Rows[0]["customer_balance"].ToString();
                            if (dt1.Rows[0]["fix_spend_balance"].ToString() == "")
                            {
                                lbl_nonrefundable.Text = "0.00";
                            }
                            else
                            {
                                lbl_nonrefundable.Text = dt1.Rows[0]["fix_spend_balance"].ToString();
                            }
                            if (dt1.Rows[0]["fix_balance"].ToString() == "")
                            {
                                lbl_fix.Text = "0.00";
                            }
                            else
                            {
                                fix_balance = dt1.Rows[0]["fix_balance"].ToString();
                                lbl_fix.Text = fix_balance;
                            }
                            lbl_useable.Text = Convert.ToString(Convert.ToDecimal(lbl_balance.Text) - Convert.ToDecimal(fix_balance));
                            lbl_refundable.Text = lbl_useable.Text;
                            lbl_fix.Text = fix_balance;
                        }
                        else
                        {
                            lbl_balance.Text = "0.00";
                            lbl_fix.Text = "0.00";
                            lbl_useable.Text = "0.00";
                            lbl_nonrefundable.Text = "0.00";
                           
                        }
                    }
                    else
                    {
                        lbl_fix.Text = "0.00";
                        lbl_useable.Text = "0.00";
                        lbl_balance.Text = "0.00";
                        lbl_nonrefundable.Text = "0.00";
                        lbl_refundable.Text = "0.00";
                    }
                    CustomerCardDetail.Animate(panel3, CustomerCardDetail.Effect.Roll, 250, 90);
                }
            }
            else
            {
                if (txt_searchbox.Text == "")
                {
                    panel3.Hide();
                }
            }
        }

        private void btn_cash_back_Click(object sender, EventArgs e)
        {
            Control ctrl = this.Parent;

            DataTable dt = customer.getnamebyno(txt_searchbox.Text);
            CustomerCashBack ccb = new CustomerCashBack(Convert.ToInt32(dt.Rows[0]["id"].ToString()));

           
            this.Hide();
            ccb.ShowDialog();

        }
    
        public static int id;
        private void btn_add_Click(object sender, EventArgs e)
        {
            AdminAccess acc = new AdminAccess();
            acc.ShowDialog();
            if (acc.DialogResult == DialogResult.OK)
            {
                //CustomerCard_Info add = new CustomerCard_Info();

                DataTable dt = customer.getnamebyno(txt_searchbox.Text);
                if (dt.Rows.Count > 0)
                {
                    CustomerCard_Info add = new CustomerCard_Info(Convert.ToInt32(dt.Rows[0]["id"].ToString()));

                    //id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                    //add.txt_name.Text = lbl_name.Text;
                    //add.txt_card_type.Text = lbl_card_type.Text;
                    //this.Hide();
                    add.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Invalid Username or Password.", "Invalid Access!!!");
            }


        }

    
    }
}

