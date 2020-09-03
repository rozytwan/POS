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
using BLLS.Bll_mess_days;

namespace POS_System.Customer_Management
{
    public partial class xtraform : Form
    {
        public xtraform()
        {
            InitializeComponent();
        }
        Bll_customerMess_record cmrs = new Bll_customerMess_record();

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_cusname.Text == "" || cbo_combo.SelectedIndex == 0 || txt_amount.Text == "")
            {
                MessageBox.Show("Input Required Fields..");
            }
            else
            {
                DataTable getallby = cmrs.getallby(lbl_id.Text, lbl_day.Text, Convert.ToDateTime(lbl_date.Text), lbl_package.Text);
                if (getallby.Rows.Count > 0)
                {
                    int i = cmrs.updateamount(lbl_id.Text, lbl_day.Text, Convert.ToDateTime(lbl_date.Text), lbl_package.Text, Convert.ToDecimal(txt_amount.Text));
                }
                else
                {
                    int insert = cmrs.inserinto(lbl_id.Text, lbl_day.Text, Convert.ToDateTime(lbl_date.Text), lbl_package.Text, Convert.ToDecimal(txt_amount.Text), txt_cusname.Text,cbo_combo.Text);
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void xtraform_Load(object sender, EventArgs e)
        {
            cbo_combo.SelectedIndex = 0;
        }

        private void txt_cusname_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
