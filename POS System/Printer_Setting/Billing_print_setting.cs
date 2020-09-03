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



namespace POS_System
{
    public partial class Billing_print_setting : UserControl
    {
        public Billing_print_setting()
        {
            InitializeComponent();

        }
        BLLBill_printing blu = new BLLBill_printing();
        BLLUser blusr = new BLLUser();

        int kot_print_id = 1;
        private void Form1_Load(object sender, EventArgs e)
        {
            swh_store_name.Value = true;
            swh_table_name.Value = true;
           
            swh_date_and_time.Value = true;
            swh_cashier.Value = true;
           // swh_cashier.Value = true;
           
            swh_header.Value = true;
            swh_item.Value = true;
            swh_sub_total.Value = true;
            swh_received_amt.Value = true;
            swh_discount.Value = true;
            swh_change_amt.Value = true;
            swh_total.Value = true;
            swh_payment_mode.Value = true;
            swh_address.Value = true;

            DataTable dt_business = blusr.checkbusiness();
            if (dt_business.Rows.Count > 0)
            {
                lblbusiness_name.Text = dt_business.Rows[0]["business_name"].ToString();
                lbladdress.Text = dt_business.Rows[0]["address"].ToString();
                lblphone_no.Text = dt_business.Rows[0]["phone_no"].ToString();
            }
            DataTable dtb = blps.getallPrintingTimes();
            if (dtb.Rows.Count > 0)
            {
                cbo_k1.Text = dtb.Rows[0]["B1"].ToString();
            }


            DataTable dt = blu.getall_Printing_data();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["store_name"].ToString() == "False")
                {
                    store_name = dt.Rows[0]["store_name"].ToString();
                    swh_store_name.Value = false;
                    pnl_busines_name.Hide();

                }

                if
                    (dt.Rows[0]["table_name"].ToString() == "False")
                {
                    swh_table_name.Value = false;
                    pnl_table_name.Hide();
                }
           
                if
                     (dt.Rows[0]["date_and_time"].ToString() == "False")
                {
                    swh_date_and_time.Value = false;
                    pnl_date_and_time.Hide();
                }
                if
                    (dt.Rows[0]["cashier"].ToString() == "False")
                {
                    swh_cashier.Value = false;
                    pnl_cashier.Hide();
                }
               
                if
                  (dt.Rows[0]["header"].ToString() == "False")
                {
                    swh_header.Value = false;
                    pnl_header.Hide();
                }
                if
                      (dt.Rows[0]["items"].ToString() == "False")
                {
                    swh_item.Value = false;
                    pnl_item.Hide();
                }
                if
                      (dt.Rows[0]["sub_total"].ToString() == "False")
                {
                    swh_sub_total.Value = false;
                    pnl_sub_total.Hide();
                }
                if
                    (dt.Rows[0]["received_amt"].ToString() == "False")
                {
                    swh_received_amt.Value = false;
                    pnl_amt.Hide();
                }
                if
                   (dt.Rows[0]["discount"].ToString() == "False")
                {
                    swh_discount.Value = false;
                    pnl_discount.Hide();
                }
                if
                   (dt.Rows[0]["change_amt"].ToString() == "False")
                {
                    swh_change_amt.Value = false;
                    pnl_change_amt.Hide();
                }
                if
                 (dt.Rows[0]["total"].ToString() == "False")
                {
                    swh_total.Value = false;
                    pnl_total.Hide();
                }
                if
                 (dt.Rows[0]["payment_mode"].ToString() == "False")
                {
                    swh_payment_mode.Value = false;
                    pnl_payment_mode.Hide();
                }
              
                if (dt.Rows[0]["address"].ToString() == "False")
                {
                    address = dt.Rows[0]["address"].ToString();
                    swh_address.Value = false;
                    pnl_address.Hide();
                }
            }
        }




        string store_name;
        //string seat_name;
        string table_name;
        string date_and_time;
        string cashier;
        string header;
        string items;
        string sub_total;
        string received_amt;
        string discount;
        string change_amt;
        string total;
        string payment_mode;
        string address;





        private void switchButton1_ValueChanged(object sender, EventArgs e)
        {
            if (swh_store_name.Value == true)
            {
                pnl_busines_name.Show();
                store_name = "True";
              
            }
            else
            {
                pnl_busines_name.Hide();
                store_name = "False";
              
            }
        }

        private void sth_tablename_ValueChanged(object sender, EventArgs e)
        {
          

        }


        private void sth_header_ValueChanged(object sender, EventArgs e)
        {
            if (swh_header.Value == true)
            {
                pnl_header.Show();
                header = "True";
            }
            else
            {
                pnl_header.Hide();
                header = "False";

            }
        }

        private void sth_sub_total_ValueChanged(object sender, EventArgs e)
        {

            if (swh_sub_total.Value == true)
            {
                pnl_sub_total.Show();
                sub_total = "True";
            }
            else
            {
                pnl_sub_total.Hide();
                sub_total = "False";
            }
        }

        private void swh_table_ValueChanged(object sender, EventArgs e)
        {
            if (swh_table_name.Value == true)
            {
                pnl_table_name.Show();
                table_name = "True";
            }
            else
            {
                pnl_table_name.Hide();
                table_name = "False";
            }
        }

        private void swh_seat_ValueChanged(object sender, EventArgs e)
        {
         
        }



        private void swh_cashier_ValueChanged(object sender, EventArgs e)
        {
            if (swh_cashier.Value == true)
            {
                pnl_cashier.Show();
                cashier = "True";
            }
            else
            {
                pnl_cashier.Hide();
                cashier = "False";
            }
        }

        private void swh_item_ValueChanged(object sender, EventArgs e)
        {
            if (swh_item.Value == true)
            {
                pnl_item.Show();
                items = "True";
            }
            else
            {
                pnl_item.Hide();
                items = "False";
            }
        }

        private void swh_item_MouseHover(object sender, EventArgs e)
        {

        }




        private void swh_servicecharge_ValueChanged(object sender, EventArgs e)
        {
            if (swh_received_amt.Value == true)
            {
                pnl_received_amt.Show();
                received_amt = "True";
            }
            else
            {
                pnl_received_amt.Hide();
                received_amt = "False";
            }
        }

        private void swh_discount_ValueChanged(object sender, EventArgs e)
        {
            if (swh_discount.Value == true)
            {
                pnl_discount.Show();
                discount = "True";
            }
            else
            {
                pnl_discount.Hide();
                discount = "False";
            }
        }

        private void switchButton1_ValueChanged_1(object sender, EventArgs e)
        {
            if (swh_total.Value == true)
            {
                pnl_total.Show();
                total = "True";
            }
            else
            {
                pnl_total.Hide();
                total = "False";
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = blu.getall_Printing_data();

            if (dt.Rows.Count > 0)
            {
                int x = blu.update(store_name,table_name ,"False", date_and_time, cashier, "False", header, items, sub_total, received_amt, discount, change_amt, total, payment_mode, address, kot_print_id);
                // int business_id = Convert.ToInt32(getallbusiness.Rows[0]["business_id"].ToString());
                // int y = blu.updatetblbusiness(business_name.Text, address.Text, phone_no.Text, note_1.Text, "", "", business_id);
                if (x > 0)
                {
                    MessageBox.Show("Bill Printing Setting Has Been Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
        }
       
        private void swh_payment_mode_ValueChanged(object sender, EventArgs e)
        {

            if (swh_payment_mode.Value == true)
            {
                pnl_payment_mode.Show();
                payment_mode = "True";
            }
            else
            {
                pnl_payment_mode.Hide();
                payment_mode = "False";
            }
        }




        private void swh_change_amt_ValueChanged(object sender, EventArgs e)
        {

            if (swh_change_amt.Value == true)
            {
                pnl_change_amt.Show();
                change_amt = "True";
            }
            else
            {
                pnl_change_amt.Hide();
                change_amt = "False";
            }
        }

        private void business_name_Click(object sender, EventArgs e)
        {

        }

        private void pnl_payment_mode_Paint(object sender, PaintEventArgs e)
        {

        }

        private void swh_address_ValueChanged(object sender, EventArgs e)
        {


        }

        private void swh_address_ValueChanged_1(object sender, EventArgs e)
        {
            if (swh_address.Value == true)
            {
                pnl_address.Show();
                address = "True";
            }
            else
            {
                pnl_address.Hide();
                address = "False";
            }
        }

        private void pnl_address_Paint(object sender, PaintEventArgs e)
        {

        }

        private void swh_date_and_time_ValueChanged_1(object sender, EventArgs e)
        {
            if (swh_date_and_time.Value == true)
            {
                pnl_date_and_time.Show();
                date_and_time = "True";
            }
            else
            {
                pnl_date_and_time.Hide();
                date_and_time = "False";
            }
        }
        BLLPrinterSetting blps = new BLLPrinterSetting();
        private void btn_printing_times_Click(object sender, EventArgs e)
        {
            DataTable dt = blps.getallPrintingTimes();
            if (dt.Rows.Count > 0)
            {
                int updateBilling = blps.updateprintingTimes(cbo_k1.Text);
                MessageBox.Show("Bill Printing Setting Has Been Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int insertBilling = blps.insertPrintingTimes(cbo_k1.Text);
                MessageBox.Show("Bill Printing Setting Has Been Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
    






