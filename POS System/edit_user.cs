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
    public partial class edit_user : Form
    {
        public edit_user()
        {
            InitializeComponent();
        }
        BLLUser blus = new BLLUser();
        private void btnchange_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "" || txtpassword.Text == "" || txtrenewpassword.Text == "")
            {
                MessageBox.Show("The Inputs Can't be Empty.");
            }
            else
            {
                DataTable dt = new DataTable();
                dt = blus.getpasswordbyusername(txtpassword.Text);
                if (dt.Rows.Count > 0)
                {
                    if (txtnewpassword.Text == txtrenewpassword.Text)
                    {
                        if (txtrenewpassword.Text != txtpassword.Text)
                        {
                            int i = blus.newpassword(txtnewpassword.Text, txtusername.Text);
                            MessageBox.Show("Password Change");

                        }
                        else
                        {
                            MessageBox.Show("Past Password And New Password Is Same Try Diffrent");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password Incorrect");
                    }
                }
                else
                {
                    MessageBox.Show("Past password incorrect");
                }
            }
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {

           
        }

        private void edit_user_Load(object sender, EventArgs e)
        {
            txtusername.Focus();
        }

        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();

                }
            }
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();

                }
            }
        }

        private void txtnewpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();

                }
            }
        }

        private void txtrenewpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();

                }
            }
        }
    }
 
        }
   


