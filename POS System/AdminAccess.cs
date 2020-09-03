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
    public partial class AdminAccess : Form
    {
        public AdminAccess()
        {
            InitializeComponent();
        }
        public static bool discount_access_value;
        public static bool AccountAccess;
        public bool Admin_access_value;
        BLLUser blu = new BLLUser();
        public static string username;

        private void AdminAccess_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txt_user_name.Text != "" && txtpassword.Text != "")
            {
                DataTable dt = blu.getusername(txt_user_name.Text);
                if (dt.Rows.Count > 0)
                {               
                        DataTable dtm = blu.getalluserlogin(txt_user_name.Text, txtpassword.Text);
                        if (dtm.Rows.Count > 0)
                        {
                        DataTable dt_acc = blu.get_user_and_type_inner(Convert.ToInt32(dt.Rows[0]["user_id"].ToString()));
                        if (dt_acc.Rows[0]["discount"].ToString() == "True")
                        {
                            discount_access_value = true;
                            this.Close();
                        }
                      else
                        {
                            MessageBox.Show("You Have No Access To Discount,Please Contact To Your Admin", "Discount Access", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        if (dt_acc.Rows[0]["Account"].ToString() == "True")
                        {
                            AccountAccess = true;
                            this.Close();
                        }
                      else
                        {
                            AccountAccess = false;
                            MessageBox.Show("You Have No Access To Account,Please Contact To Your Admin", "Account Access", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                        }
                        if (dt_acc.Rows[0]["admin"].ToString() == "True")
                        {
                            Admin_access_value = true;
                            username = txt_user_name.Text;
                            this.DialogResult = DialogResult.OK;
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Sorry You Have No Permission To Access","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                        }

                        }
                    else
                    {
                        MessageBox.Show("Invalid UserName Or Password","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid UserName Or Password","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Input Field Is Empty","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void bth_panel_close_Click(object sender, EventArgs e)
        {
          
            this.Close();
            AccountAccess = false;
        }
    }
}
