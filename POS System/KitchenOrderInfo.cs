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
using POS_System.Table_Management;

namespace POS_System
{
    public partial class KitchenOrderInfo : Form
    {
        public KitchenOrderInfo()
        {
            InitializeComponent();
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.Enter += textBox_Enter;
            }
        }
        BLLKitchenOrderInfo blkoi = new BLLKitchenOrderInfo();
      
        public string table_no ;
        private void KitchenOrderInfo_Load(object sender, EventArgs e)
        {
          
            lbl_table_no.Text = table_no;
            if (table_no != "")
            {
                DataTable dt = blkoi.GetAlltableInfo(table_no);
                if (dt.Rows.Count > 0)
                {
                    txt_adult.Text = dt.Rows[0]["no_of_adult"].ToString();
                    txt_children.Text = dt.Rows[0]["no_of_children"].ToString();
                    btn_ok.Text = "Update";
                }
            }
        }
        public static string adult;
        public static string kid;
        private void buttonX3_Click(object sender, EventArgs e)
        {

            if (txt_adult.Text.Length > 0 && txt_adult.Text != "" && txt_children.Text != "" && txt_children.Text.Length > 0 && lbl_total.Text.Length > 0)
            {
                if (btn_ok.Text == "Update")
                {
                    int insert = blkoi.UpdateKitchenInfo(table_no, Convert.ToInt32(txt_adult.Text), Convert.ToInt32(txt_children.Text), Convert.ToInt32(lbl_total.Text));
                    adult = txt_adult.Text;
                    kid = txt_children.Text;
                    this.Hide();
                }
                else
                {
                    int insert = blkoi.InsertKitchenInfo(table_no, Convert.ToInt32(txt_adult.Text), Convert.ToInt32(txt_children.Text), Convert.ToInt32(lbl_total.Text));
                    adult = txt_adult.Text;
                    kid = txt_children.Text;
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Invalid Input", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txt_adult_TextChanged(object sender, EventArgs e)
        {
            if (txt_adult.Text.Length > 0 && txt_adult.Text != "")
            {
                lbl_total.Text = (Convert.ToInt32(txt_adult.Text) + Convert.ToInt32(txt_children.Text)).ToString();
            }
        }

        private void txt_children_TextChanged(object sender, EventArgs e)
        {
            if (txt_children.Text.Length > 0 && txt_children.Text != "")
            {
                lbl_total.Text = (Convert.ToInt32(txt_adult.Text) + Convert.ToInt32(txt_children.Text)).ToString();
            }
        }

        private void txt_adult_Enter(object sender, EventArgs e)
        {
            if (txt_adult.Text == "0")
            {
                txt_adult.Text = "";
            }
        }

        private void txt_adult_Leave(object sender, EventArgs e)
        {
            if (txt_adult.Text == "")
            {
                txt_adult.Text = "0";
            }
        }

        private void txt_children_Enter(object sender, EventArgs e)
        {
            if (txt_children.Text == "0")
            {
                txt_children.Text = "";
            }
        }

        private void txt_children_Leave(object sender, EventArgs e)
        {
            if (txt_children.Text == "")
            {
                txt_children.Text = "0";
            }
        }

        private void lbl_total_Click(object sender, EventArgs e)
        {

        }

        //numberPad
        object lastFocused = null;
        void textBox_Enter(object sender, EventArgs e)
        {
            (lastFocused) = (TextBox)sender;
        }

        private void btnone_Click(object sender, EventArgs e)
        {
            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0")
                    {
                        ((TextBox)lastFocused).Clear();

                        ((TextBox)lastFocused).Text += "1";
                    }
                    else
                    {
                        ((TextBox)lastFocused).Text += "1";
                    }
                }

            }
        }

        private void btntwo_Click(object sender, EventArgs e)
        {

            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0")
                    {
                        ((TextBox)lastFocused).Clear();

                        ((TextBox)lastFocused).Text += "2";
                    }
                    else
                    {
                        ((TextBox)lastFocused).Text += "2";
                    }
                }
            }
        }

        private void btnthree_Click(object sender, EventArgs e)
        {

            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0")
                    {
                        ((TextBox)lastFocused).Clear();

                        ((TextBox)lastFocused).Text += "3";
                    }
                    else
                    {
                        ((TextBox)lastFocused).Text += "3";
                    }
                }
              
            }
        }

        private void btnfour_Click(object sender, EventArgs e)
        {
            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0")
                    {
                        ((TextBox)lastFocused).Clear();

                        ((TextBox)lastFocused).Text += "4";
                    }
                    else
                    {
                        ((TextBox)lastFocused).Text += "4";
                    }
                }
               
            }
        }

        private void btnfive_Click(object sender, EventArgs e)
        {
            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0")
                    {
                        ((TextBox)lastFocused).Clear();

                        ((TextBox)lastFocused).Text += "5";
                    }
                    else
                    {
                        ((TextBox)lastFocused).Text += "5";
                    }
                }
               
            }
        }

        private void btnsix_Click(object sender, EventArgs e)
        {
            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0")
                    {
                        ((TextBox)lastFocused).Clear();

                        ((TextBox)lastFocused).Text += "6";
                    }
                    else
                    {
                        ((TextBox)lastFocused).Text += "6";
                    }
                }
              
            }
        }

        private void btnseven_Click(object sender, EventArgs e)
        {

            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0")
                    {
                        ((TextBox)lastFocused).Clear();

                        ((TextBox)lastFocused).Text += "7";
                    }
                    else
                    {
                        ((TextBox)lastFocused).Text += "7";
                    }
                }
              
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0")
                    {
                        ((TextBox)lastFocused).Clear();

                        ((TextBox)lastFocused).Text += "8";
                    }
                    else
                    {
                        ((TextBox)lastFocused).Text += "8";
                    }
                }
              
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0")
                    {
                        ((TextBox)lastFocused).Clear();

                        ((TextBox)lastFocused).Text += "9";
                    }
                    else
                    {
                        ((TextBox)lastFocused).Text += "9";
                    }
                }
               
            }
        }



        private void btnzero_Click(object sender, EventArgs e)
        {

            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0")
                    {
                        ((TextBox)lastFocused).Clear();

                        ((TextBox)lastFocused).Text += "0";
                    }
                    else
                    {
                        ((TextBox)lastFocused).Text += "0";
                    }
                }
                
            }
        }

    

        private void btnbackspace_Click(object sender, EventArgs e)
        {
            if (lastFocused != null)
            {
                if (lastFocused is TextBox)
                {
                    if (((TextBox)lastFocused).Text == "0")
                    {
                        int i = ((TextBox)lastFocused).Text.Length;
                        ((TextBox)lastFocused).Text = ((TextBox)lastFocused).Text.Substring(0, i - 1);
                    }
                    else
                    {
                        int i = ((TextBox)lastFocused).Text.Length;
                        if (i > 0)
                        {
                            ((TextBox)lastFocused).Text = ((TextBox)lastFocused).Text.Substring(0, i - 1);
                        }
                    }
                }
              
            }

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
