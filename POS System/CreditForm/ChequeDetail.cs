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
    public partial class ChequeDetail : Form
    {
        public ChequeDetail(string paystatus)
        {
          pay_status = paystatus;
            InitializeComponent();
            
        }
        BLLcustomer_credit blcc = new BLLcustomer_credit();
        BLLUser blu = new BLLUser();
        DateTime date_now = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        string pay_status;
        private void Check_Detail_Load(object sender, EventArgs e)
        {
            User();
            lbl_date.Text = Convert.ToString(date_now);
            cmb_receiver.SelectedIndex = 0;
        }
        public void User()
        {
            DataTable dt = blu.getalluser();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["user_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cmb_receiver.DataSource = dt;
                cmb_receiver.DisplayMember = "user_name";
                cmb_receiver.ValueMember = "user_name";
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_amount.Text == "" || txt_chequeholder.Text == "" || txt_payto.Text == "" || txt_chequeno.Text == "" || rich_bankname.Text == "" || cmb_receiver.Text == "Choose One")
            {
                MessageBox.Show("Fill The Required Field Alert !!");
            }
            else
            {
                int i = blcc.Insert_Cheque_Detail(rich_bankname.Text, txt_chequeno.Text, Convert.ToDecimal(txt_amount.Text), (txt_payto.Text), txt_chequeholder.Text, cmb_receiver.Text, pay_status, date_now);
                if (i > 0)
                {
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Insert Unsucessfull Alert !!");
                }
            }
        }

        private void txt_amount_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txt_amount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_chequeno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
         
        }
    }
}
