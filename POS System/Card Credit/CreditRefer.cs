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
    public partial class CreditRefer : Form
    {
        public CreditRefer()
        {
            InitializeComponent();
        }
        BLL_Card_Credit bllcredit = new BLL_Card_Credit();
        private void CreditRefer_Load(object sender, EventArgs e)
        {
            LoadFirstName();
        }
        string today = DateTime.Now.Date.ToShortDateString();
        public void LoadFirstName()
        {
      
            DataTable dt = bllcredit.GetCustomer();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cmb_first.DataSource = dt;
                cmb_first.DisplayMember = "name";
        }

    }
      public void LoadLastName()
        {

            DataTable dt = bllcredit.GetLastName(cmb_first.Text);
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["lastname"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cmb_last.DataSource = dt;
                cmb_last.DisplayMember = "lastname";
            }

        }
 private void cmb_first_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLastName();

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            int insert = bllcredit.InsertReferCustomer(cmb_first.Text, cmb_last.Text, txt_phone.Text, Convert.ToDecimal(txt_refer_balance.Text));
            int insertcredit = bllcredit.InsertCredit(Convert.ToInt32(lbl_cutomerId.Text), Convert.ToDecimal(txt_refer_balance.Text), Convert.ToDateTime(today), Login.sendtext, cmb_first.Text+ " " + cmb_last.Text);
            if (insert>0 && insertcredit>0)
            {
                 MessageBox.Show("Successfully Inserted");
                this.Hide();
            }
        }

        private void cmb_last_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_last.SelectedIndex > 0 && cmb_last.Text != "Choose One")
            {
                DataTable dt = bllcredit.GetDetails(cmb_first.Text, cmb_last.Text);
                txt_phone.Text = dt.Rows[0]["phone"].ToString();
            }
          
        }
 private void cmb_last_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void cmb_last_Click(object sender, EventArgs e)
        {
           
        }

        private void txt_phone_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = bllcredit.GetCustomerByPhone(txt_phone.Text);
            if (dt.Rows.Count>0)
            {
                cmb_first.Text = dt.Rows[0]["name"].ToString();
                cmb_last.Text = dt.Rows[0]["lastname"].ToString();
            }
            else
            {
                MessageBox.Show("No Customer Found With This Contact", "Customer Not Found Alert !!");
            }
        }
    }
}
