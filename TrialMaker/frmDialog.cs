using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SoftwareLocker
{
    public partial class frmDialog : Form
    {
        private string _Pass;
        public static string trial_code;
        public static string trial_gen_code;
        public static string sebBaseString_value;
        public static string sebBasePassword_value;
        public frmDialog(string BaseString,string Password,int DaysToEnd, string info)
        {
            InitializeComponent();
            sebBaseString_value = BaseString;
            _Pass = Password;
            trial_code = Password;
            trial_gen_code = BaseString;
            lblDays.Text = DaysToEnd.ToString() + " Day(s)";
           
            //lblText.Text = info;
            if (DaysToEnd <= 0)
            {
                lblDays.Text = "Finished";            
                btnTrial.Enabled = false;
            }

           
        
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_Pass == sebBasePassword_value)
            {
                MessageBox.Show("Password is correct", "Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Password is incorrect", "Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnTrial_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
        }

        private void frmDialog_Load(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}