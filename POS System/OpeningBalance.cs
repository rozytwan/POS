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
    public partial class OpeningBalance : Form
    {
        string opening_blc;
        public OpeningBalance(string openning)
        {
            opening_blc = openning;
            InitializeComponent();
        }
        Bll_cashcounter blcash = new Bll_cashcounter();
        private void OpeningBalance_Load(object sender, EventArgs e)
        {
            // string openingblc=txt_opening_balance.Text;
            if (opening_blc=="Restaurant")
            {
                DataTable dt1 = blcash.getlatestopeningblc();
                if (dt1.Rows.Count > 0)
                {
                    txt_opening_balance.Text = dt1.Rows[0][0].ToString();
                    txt_add_amount_TextChanged(null, null);
                }
                txt_set_by.Text = Login.sendtext;

                DataTable dt = blcash.get_oening_balance_details();
                if (dt.Rows.Count > 0)
                {
                    btn_set.Text = "ADD";
                }
            }
            else
            {
                DataTable dt1 = blcash.getlatestopeningblchotel();
                if (dt1.Rows.Count > 0)
                {
                    txt_opening_balance.Text = dt1.Rows[0][0].ToString();
                    txt_add_amount_TextChanged(null, null);
                }
                txt_set_by.Text = Login.sendtext;

                DataTable dt = blcash.get_oening_balance_detailshotel();
                if (dt.Rows.Count > 0)
                {
                    btn_set.Text = "ADD";
                }
            }
          
        }

        private void btn_set_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (opening_blc == "Restaurant")
            {
                if (txt_opening_balance.Text != "" && txt_set_by.Text != "" && txt_add_amount.Text != "")
                {
                    DateTime dt_time = Convert.ToDateTime(DateTime.Now.ToString());
                    txt_opening_balance.Text = Convert.ToString(Convert.ToDecimal(txt_opening_balance.Text) + Convert.ToDecimal(txt_add_amount.Text));
                    int iop = blcash.delete_opening_balancerestaurant();
                    int i = blcash.insertinto(Convert.ToDecimal(txt_opening_balance.Text), dt_time, txt_set_by.Text, "OB");

                }
                else if (txt_opening_balance.Text != "" && txt_set_by.Text != "" && txt_add_amount.Text == "")
                {
                    DateTime dt_time = Convert.ToDateTime(DateTime.Now.ToString());
                    txt_opening_balance.Text = Convert.ToString(Convert.ToDecimal(txt_opening_balance.Text));
                    int iop = blcash.delete_opening_balancerestaurant();
                    int i = blcash.insertinto(Convert.ToDecimal(txt_opening_balance.Text), dt_time, txt_set_by.Text, "OB");
                }
            }
            else
            {
                if (txt_opening_balance.Text != "" && txt_set_by.Text != "" && txt_add_amount.Text != "")
                {
                    DateTime dt_time = Convert.ToDateTime(DateTime.Now.ToString());
                    txt_opening_balance.Text = Convert.ToString(Convert.ToDecimal(txt_opening_balance.Text) + Convert.ToDecimal(txt_add_amount.Text));
                    int iop = blcash.delete_opening_balancehotel();
                    int i = blcash.insertinto(Convert.ToDecimal(txt_opening_balance.Text), dt_time, txt_set_by.Text, "OBH");

                    //if (i > 0)
                    //{

                    //    DataTable dt = blcash.get_oening_balance_details();
                    //    if (dt.Rows.Count > 0)
                    //    {
                    //        MessageBox.Show("Opening Balance Has Been Add"); 
                    //        this.Hide();
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("New Opening Balance Has Been Set");
                    //        this.Hide();

                    //    }
                    //}
                }
                else if (txt_opening_balance.Text != "" && txt_set_by.Text != "" && txt_add_amount.Text == "")
                {
                    DateTime dt_time = Convert.ToDateTime(DateTime.Now.ToString());
                    txt_opening_balance.Text = Convert.ToString(Convert.ToDecimal(txt_opening_balance.Text));
                    int iop = blcash.delete_opening_balancehotel();
                    int i = blcash.insertinto(Convert.ToDecimal(txt_opening_balance.Text), dt_time, txt_set_by.Text, "OBH");
                }
                //{
                //    MessageBox.Show("Cannot Complete The Transaction Please Check Your Input");  
                //}
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
      
        private void txt_opening_balance_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_add_amount_TextChanged(object sender, EventArgs e)
        {
            if (txt_add_amount.Text != "" && txt_add_amount.Text.Length > 0 && txt_opening_balance.Text != "" && txt_opening_balance.Text.Length>0)
            {
                lbl_total_balance.Text = (Convert.ToDecimal(txt_opening_balance.Text) + Convert.ToDecimal(txt_add_amount.Text)).ToString();
            }

        }

        private void txt_add_amount_KeyPress(object sender, KeyPressEventArgs e)
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
    }
    }

