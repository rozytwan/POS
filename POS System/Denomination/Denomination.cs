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
    public partial class Denomination : Form
    {
        public Denomination()
        {
            InitializeComponent();
        }
        public string total = "0.00";
        BLLdenomination bld = new BLLdenomination();

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ok_Click(object sender, EventArgs e)
        {

            total = txt_cal_total.Text;
            DenomonationStatic.ic = txt_ic.Text;
            DenomonationStatic.thousand = txt_thousand.Text;
            DenomonationStatic.fivehundred = txt_fivehundred.Text;
            DenomonationStatic.onehundred = txt_hundred.Text;
            DenomonationStatic.fifty = txt_fifty.Text;
            DenomonationStatic.twenty = txt_twenty.Text;
            DenomonationStatic.ten = txt_ten.Text;
            DenomonationStatic.five = txt_five.Text;
            DenomonationStatic.two = txt_two.Text;
            DenomonationStatic.one = txt_one.Text;
            this.Close();

          
         



        }
        public void clear()
        {
            if (txt_ic.Text == "" || txt_thousand.Text == "" || txt_fivehundred.Text == "" || txt_hundred.Text == "" || txt_fifty.Text == "" || txt_twenty.Text == "" || txt_ten.Text == "" || txt_five.Text == "" || txt_two.Text == "" || txt_one.Text == "")
            {
                txt_ic.Text = "0.00";
                txt_thousand.Text = "0.00";
                txt_fivehundred.Text = "0.00";
                txt_hundred.Text = "0.00";
                txt_fifty.Text = "0.00";
                txt_twenty.Text = "0.00";
                txt_ten.Text = "0.00";
                txt_five.Text = "0.00";
                txt_two.Text = "0.00";
                txt_one.Text = "0.00";
             
            }
        }
        private void Denomination_Load(object sender, EventArgs e)
        {
            txt_ic.Text = DenomonationStatic.ic;
            txt_thousand.Text = DenomonationStatic.thousand;
            txt_fivehundred.Text = DenomonationStatic.fivehundred;
            txt_hundred.Text = DenomonationStatic.onehundred;
            txt_fifty.Text = DenomonationStatic.fifty;
            txt_twenty.Text = DenomonationStatic.twenty;
            txt_ten.Text = DenomonationStatic.ten;
            txt_five.Text = DenomonationStatic.five;
            txt_two.Text = DenomonationStatic.two;
            txt_one.Text = DenomonationStatic.one;
            //txt_ic.Text = "0";
            //txt_thousand.Text = "0";
            //txt_fivehundred.Text = "0";
            //txt_hundred.Text = "0";
            //txt_fifty.Text = "0";
            //txt_twenty.Text = "0";
            //txt_ten.Text = "0";
            //txt_five.Text = "0";
            //txt_two.Text = "0";
            //txt_one.Text = "0";
      
        }

        private void txt_ic_TextChanged(object sender, EventArgs e)
        {
            if (txt_ic.Text == "")
            {
                txt_ic.Text = "";
                txt_cal_ic.Text = "0.00";
            }
            else if (txt_ic.Text != null)
            {
                txt_cal_ic.Text = (((Convert.ToDecimal(txt_ic.Text) * Convert.ToDecimal(1.6)).ToString()));
            }
        }


        private void txt_thousand_TextChanged(object sender, EventArgs e)
        {
            if (txt_thousand.Text == "")
            {
                txt_thousand.Text = "";
                txt_cal_thousand.Text = "0.00";
            }
            else if (txt_thousand.Text != null)
            {
                txt_cal_thousand.Text = ((Convert.ToDecimal(txt_thousand.Text) * Convert.ToDecimal(lbl_thousand.Text)).ToString());
            }
        }

        private void txt_fivehundred_TextChanged(object sender, EventArgs e)
        {
            if (txt_fivehundred.Text == "")
            {
                txt_fivehundred.Text = "";
                txt_cal_fivehundred.Text = "0.00";
            }
            else if (txt_cal_fivehundred.Text != null)
            {
                txt_cal_fivehundred.Text = ((Convert.ToDecimal(txt_fivehundred.Text) * Convert.ToDecimal(lbl_fivehundred.Text)).ToString());

            }
        }

        private void txt_hundred_TextChanged(object sender, EventArgs e)
        {
            if (txt_hundred.Text == "")
            {
                txt_hundred.Text = "";
                txt_cal_hundred.Text = "0.00";
            }
            else if (txt_cal_hundred.Text != null)
            {
                txt_cal_hundred.Text = ((Convert.ToDecimal(txt_hundred.Text) * Convert.ToDecimal(lbl_hundred.Text)).ToString());
            }

        }

        private void txt_fifty_TextChanged(object sender, EventArgs e)
        {
            if (txt_fifty.Text == "")
            {
                txt_fifty.Text = "";
                txt_cal_fifty.Text = "0.00";
            }
            else if (txt_cal_fifty.Text != null)
            {
                txt_cal_fifty.Text = ((Convert.ToDecimal(txt_fifty.Text) * Convert.ToDecimal(lbl_fifty.Text)).ToString());
            }

        }

        private void txt_twenty_TextChanged(object sender, EventArgs e)
        {
            if (txt_twenty.Text == "")
            {
                txt_twenty.Text = "";
                txt_cal_twenty.Text = "0.00";
            }
            else if (txt_cal_twenty.Text != null)
            {
                txt_cal_twenty.Text = ((Convert.ToDecimal(txt_twenty.Text) * Convert.ToDecimal(lbl_twenty.Text)).ToString());
            }

        }

        private void txt_ten_TextChanged(object sender, EventArgs e)
        {
            if (txt_ten.Text == "")
            {
                txt_ten.Text = "";
                txt_cal_ten.Text = "0.00";
            }
            else if (txt_cal_ten.Text != null)
            {
                txt_cal_ten.Text = ((Convert.ToDecimal(txt_ten.Text) * Convert.ToDecimal(lbl_ten.Text)).ToString());
            }
        }

        private void txt_five_TextChanged(object sender, EventArgs e)
        {
            if (txt_five.Text == "")
            {
                txt_five.Text = "";
                txt_cal_five.Text = "0.00";
            }
            else if (txt_cal_five.Text != null)
            {
                txt_cal_five.Text = ((Convert.ToDecimal(txt_five.Text) * Convert.ToDecimal(lbl_five.Text)).ToString());
            }

        }

        private void txt_two_TextChanged(object sender, EventArgs e)
        {
            if (txt_two.Text == "")
            {
                txt_two.Text = "";
                txt_cal_two.Text = "0.00";
            }
            else if (txt_cal_two.Text != null)
            {
                txt_cal_two.Text = ((Convert.ToDecimal(txt_two.Text) * Convert.ToDecimal(lbl_two.Text)).ToString());

            }
        }

        private void txt_one_TextChanged(object sender, EventArgs e)
        {
            if (txt_one.Text == "")
            {
                txt_one.Text = "";
                txt_cal_one.Text = "0.00";
            }
            else if (txt_one.Text != null)
            {
                txt_cal_one.Text = ((Convert.ToDecimal(txt_one.Text) * Convert.ToDecimal(lbl_one.Text)).ToString());

            }
        }

        private void txt_cal_ic_TextChanged(object sender, EventArgs e)
        {
            if (txt_one.Text != "" || txt_two.Text != "" || txt_five.Text != "" || txt_ten.Text != "" || txt_twenty.Text != "" || txt_fifty.Text != "" || txt_hundred.Text != "" || txt_fivehundred.Text != "" || txt_thousand.Text != "" || txt_ic.Text != "")
            {
                txt_cal_total.Text = (Convert.ToDecimal(txt_cal_one.Text) + Convert.ToDecimal(txt_cal_two.Text) + Convert.ToDecimal(txt_cal_five.Text) + Convert.ToDecimal(txt_cal_ten.Text) + Convert.ToDecimal(txt_cal_twenty.Text) + Convert.ToDecimal(txt_cal_fifty.Text) + Convert.ToDecimal(txt_cal_hundred.Text) + Convert.ToDecimal(txt_cal_fivehundred.Text) + Convert.ToDecimal(txt_cal_thousand.Text) + Convert.ToDecimal(txt_cal_ic.Text)).ToString();
            }
            else
                txt_cal_total.Text = "0.00";
        }

        private void txt_cal_thousand_TextChanged(object sender, EventArgs e)
        {
            if (txt_one.Text != "" || txt_two.Text != "" || txt_five.Text != "" || txt_ten.Text != "" || txt_twenty.Text != "" || txt_fifty.Text != "" || txt_hundred.Text != "" || txt_fivehundred.Text != "" || txt_thousand.Text != "" || txt_ic.Text != "")
            {
                txt_cal_total.Text = (Convert.ToDecimal(txt_cal_one.Text) + Convert.ToDecimal(txt_cal_two.Text) + Convert.ToDecimal(txt_cal_five.Text) + Convert.ToDecimal(txt_cal_ten.Text) + Convert.ToDecimal(txt_cal_twenty.Text) + Convert.ToDecimal(txt_cal_fifty.Text) + Convert.ToDecimal(txt_cal_hundred.Text) + Convert.ToDecimal(txt_cal_fivehundred.Text) + Convert.ToDecimal(txt_cal_thousand.Text) + Convert.ToDecimal(txt_cal_ic.Text)).ToString();
            }
            else
                txt_cal_total.Text = "0.00";
        }

        private void txt_cal_fivehundred_TextChanged(object sender, EventArgs e)
        {
            if (txt_one.Text != "" || txt_two.Text != "" || txt_five.Text != "" || txt_ten.Text != "" || txt_twenty.Text != "" || txt_fifty.Text != "" || txt_hundred.Text != "" || txt_fivehundred.Text != "" || txt_thousand.Text != "" || txt_ic.Text != "")
            {
                txt_cal_total.Text = (Convert.ToDecimal(txt_cal_one.Text) + Convert.ToDecimal(txt_cal_two.Text) + Convert.ToDecimal(txt_cal_five.Text) + Convert.ToDecimal(txt_cal_ten.Text) + Convert.ToDecimal(txt_cal_twenty.Text) + Convert.ToDecimal(txt_cal_fifty.Text) + Convert.ToDecimal(txt_cal_hundred.Text) + Convert.ToDecimal(txt_cal_fivehundred.Text) + Convert.ToDecimal(txt_cal_thousand.Text) + Convert.ToDecimal(txt_cal_ic.Text)).ToString();
            }
            else
                txt_cal_total.Text = "0.00";

        }

        private void txt_cal_hundred_TextChanged(object sender, EventArgs e)
        {

            if (txt_one.Text != "" || txt_two.Text != "" || txt_five.Text != "" || txt_ten.Text != "" || txt_twenty.Text != "" || txt_fifty.Text != "" || txt_hundred.Text != "" || txt_fivehundred.Text != "" || txt_thousand.Text != "" || txt_ic.Text != "")
            {
                txt_cal_total.Text = (Convert.ToDecimal(txt_cal_one.Text) + Convert.ToDecimal(txt_cal_two.Text) + Convert.ToDecimal(txt_cal_five.Text) + Convert.ToDecimal(txt_cal_ten.Text) + Convert.ToDecimal(txt_cal_twenty.Text) + Convert.ToDecimal(txt_cal_fifty.Text) + Convert.ToDecimal(txt_cal_hundred.Text) + Convert.ToDecimal(txt_cal_fivehundred.Text) + Convert.ToDecimal(txt_cal_thousand.Text) + Convert.ToDecimal(txt_cal_ic.Text)).ToString();
            }
            else
                txt_cal_total.Text = "0.00";
        }

        private void txt_cal_fifty_TextChanged(object sender, EventArgs e)
        {

            if (txt_one.Text != "" || txt_two.Text != "" || txt_five.Text != "" || txt_ten.Text != "" || txt_twenty.Text != "" || txt_fifty.Text != "" || txt_hundred.Text != "" || txt_fivehundred.Text != "" || txt_thousand.Text != "" || txt_ic.Text != "")
            {
                txt_cal_total.Text = (Convert.ToDecimal(txt_cal_one.Text) + Convert.ToDecimal(txt_cal_two.Text) + Convert.ToDecimal(txt_cal_five.Text) + Convert.ToDecimal(txt_cal_ten.Text) + Convert.ToDecimal(txt_cal_twenty.Text) + Convert.ToDecimal(txt_cal_fifty.Text) + Convert.ToDecimal(txt_cal_hundred.Text) + Convert.ToDecimal(txt_cal_fivehundred.Text) + Convert.ToDecimal(txt_cal_thousand.Text) + Convert.ToDecimal(txt_cal_ic.Text)).ToString();
            }
            else
                txt_cal_total.Text = "0.00";
        }

        private void txt_cal_twenty_TextChanged(object sender, EventArgs e)
        {

            if (txt_one.Text != "" || txt_two.Text != "" || txt_five.Text != "" || txt_ten.Text != "" || txt_twenty.Text != "" || txt_fifty.Text != "" || txt_hundred.Text != "" || txt_fivehundred.Text != "" || txt_thousand.Text != "" || txt_ic.Text != "")
            {
                txt_cal_total.Text = (Convert.ToDecimal(txt_cal_one.Text) + Convert.ToDecimal(txt_cal_two.Text) + Convert.ToDecimal(txt_cal_five.Text) + Convert.ToDecimal(txt_cal_ten.Text) + Convert.ToDecimal(txt_cal_twenty.Text) + Convert.ToDecimal(txt_cal_fifty.Text) + Convert.ToDecimal(txt_cal_hundred.Text) + Convert.ToDecimal(txt_cal_fivehundred.Text) + Convert.ToDecimal(txt_cal_thousand.Text) + Convert.ToDecimal(txt_cal_ic.Text)).ToString();
            }
            else
                txt_cal_total.Text = "0.00";
        }

        private void txt_cal_ten_TextChanged(object sender, EventArgs e)
        {

            if (txt_one.Text != "" || txt_two.Text != "" || txt_five.Text != "" || txt_ten.Text != "" || txt_twenty.Text != "" || txt_fifty.Text != "" || txt_hundred.Text != "" || txt_fivehundred.Text != "" || txt_thousand.Text != "" || txt_ic.Text != "")
            {
                txt_cal_total.Text = (Convert.ToDecimal(txt_cal_one.Text) + Convert.ToDecimal(txt_cal_two.Text) + Convert.ToDecimal(txt_cal_five.Text) + Convert.ToDecimal(txt_cal_ten.Text) + Convert.ToDecimal(txt_cal_twenty.Text) + Convert.ToDecimal(txt_cal_fifty.Text) + Convert.ToDecimal(txt_cal_hundred.Text) + Convert.ToDecimal(txt_cal_fivehundred.Text) + Convert.ToDecimal(txt_cal_thousand.Text) + Convert.ToDecimal(txt_cal_ic.Text)).ToString();
            }
            else
                txt_cal_total.Text = "0.00";
        }

        private void txt_cal_five_TextChanged(object sender, EventArgs e)
        {

            if (txt_one.Text != "" || txt_two.Text != "" || txt_five.Text != "" || txt_ten.Text != "" || txt_twenty.Text != "" || txt_fifty.Text != "" || txt_hundred.Text != "" || txt_fivehundred.Text != "" || txt_thousand.Text != "" || txt_ic.Text != "")
            {
                txt_cal_total.Text = (Convert.ToDecimal(txt_cal_one.Text) + Convert.ToDecimal(txt_cal_two.Text) + Convert.ToDecimal(txt_cal_five.Text) + Convert.ToDecimal(txt_cal_ten.Text) + Convert.ToDecimal(txt_cal_twenty.Text) + Convert.ToDecimal(txt_cal_fifty.Text) + Convert.ToDecimal(txt_cal_hundred.Text) + Convert.ToDecimal(txt_cal_fivehundred.Text) + Convert.ToDecimal(txt_cal_thousand.Text) + Convert.ToDecimal(txt_cal_ic.Text)).ToString();
            }
            else
                txt_cal_total.Text = "0.00";
        }

        private void txt_cal_two_TextChanged(object sender, EventArgs e)
        {

            if (txt_one.Text != "" || txt_two.Text != "" || txt_five.Text != "" || txt_ten.Text != "" || txt_twenty.Text != "" || txt_fifty.Text != "" || txt_hundred.Text != "" || txt_fivehundred.Text != "" || txt_thousand.Text != "" || txt_ic.Text != "")
            {
                txt_cal_total.Text = (Convert.ToDecimal(txt_cal_one.Text) + Convert.ToDecimal(txt_cal_two.Text) + Convert.ToDecimal(txt_cal_five.Text) + Convert.ToDecimal(txt_cal_ten.Text) + Convert.ToDecimal(txt_cal_twenty.Text) + Convert.ToDecimal(txt_cal_fifty.Text) + Convert.ToDecimal(txt_cal_hundred.Text) + Convert.ToDecimal(txt_cal_fivehundred.Text) + Convert.ToDecimal(txt_cal_thousand.Text) + Convert.ToDecimal(txt_cal_ic.Text)).ToString();
            }
            else
                txt_cal_total.Text = "0.00";

        }
        private void txt_cal_one_TextChanged(object sender, EventArgs e)
        {

            if (txt_one.Text != "" || txt_two.Text != "" || txt_five.Text != "" || txt_ten.Text != "" || txt_twenty.Text != "" || txt_fifty.Text != "" || txt_hundred.Text != "" || txt_fivehundred.Text != "" || txt_thousand.Text != "" || txt_ic.Text != "")
            {
                txt_cal_total.Text = (Convert.ToDecimal(txt_cal_one.Text) + Convert.ToDecimal(txt_cal_two.Text) + Convert.ToDecimal(txt_cal_five.Text) + Convert.ToDecimal(txt_cal_ten.Text) + Convert.ToDecimal(txt_cal_twenty.Text) + Convert.ToDecimal(txt_cal_fifty.Text) + Convert.ToDecimal(txt_cal_hundred.Text) + Convert.ToDecimal(txt_cal_fivehundred.Text) + Convert.ToDecimal(txt_cal_thousand.Text) + Convert.ToDecimal(txt_cal_ic.Text)).ToString();
            }
            else
                txt_cal_total.Text = "0.00";
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            txt_ic.Text = "0.00";
            txt_thousand.Text = "0.00";
            txt_fivehundred.Text = "0.00";
            txt_hundred.Text = "0.00";
            txt_fifty.Text = "0.00";
            txt_twenty.Text = "0.00";
            txt_ten.Text = "0.00";
            txt_five.Text = "0.00";
            txt_two.Text = "0.00";
            txt_one.Text = "0.00";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private void txt_ic_KeyPress(object sender, KeyPressEventArgs e)
        {





        }
    }
}
