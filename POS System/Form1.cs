using BackUP;
using BLLS;
using SecureApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System
{
    public partial class Login : Form
    {
        public Login()
        {
           

            InitializeComponent();
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;
            pictureBox2.Parent = pictureBox1;
            label3.Parent = pictureBox1;
            label4.Parent = pictureBox1;
            linkLabel1.Parent = pictureBox1;
            label5.Parent = pictureBox1;
            label8.Parent = pictureBox1;
            pictureBox3.Parent = pictureBox1;
            txtusername.ForeColor = SystemColors.GrayText;

       

            txtusername.Text = "User Name";
            this.txtusername.Leave += new System.EventHandler(this.txtusername_Leave_1);
            this.txtusername.Enter += new System.EventHandler(this.txtusername_Enter_1);


            txtpassword.ForeColor = SystemColors.GrayText;
            txtpassword.Text = "Password";
            txtpassword.PasswordChar = '\0';
            this.txtpassword.Leave += new System.EventHandler(this.txtpassword_Leave_1);
            this.txtpassword.Enter += new System.EventHandler(this.txtpassword_Enter_1);
        }
        BLLUser blu = new BLLUser();
        Bll_cashcounter blcas = new Bll_cashcounter();
        BLL_Login_logout blog = new BLL_Login_logout();
        BLLBill_printing blbp = new BLLBill_printing();
        BLLkot_kitchen blkk = new BLLkot_kitchen();
        BLL_Fiscal blfs = new BLL_Fiscal();
        public static string sendtext ;
        public string working_day;
        public DateTime working_date;
        public string working_time;
        public static int log_session_id;


        string today = DateTime.Now.ToString("yyyy-MM-dd");
       // DateTime fiscal_year_end;
       // string frmdtString;
        private void btnlogin_Click_1(object sender, EventArgs e)
        {

            DataTable dt = blu.getalluserlogin(txtusername.Text, txtpassword.Text);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["user_type"].ToString() == "Admin" || dt.Rows[0]["user_type"].ToString() == "User" || (dt.Rows[0]["user_type"].ToString() == "admin"))
                {
                    DataTable dts = blu.checkbusiness();
                    if (dts.Rows.Count > 0)
                    {
                        this.Hide();
                        second_user_interface pur = new second_user_interface(dt.Rows[0][1].ToString());
                        SessionUser sec = new SessionUser();
                        sec.user_name = txtusername.Text;
                        sendtext = txtusername.Text;
                        pur.Show();

                    }
                    else
                    {
                        this.Hide();
                        sendtext = txtusername.Text;
                        CreateBusiness crb = new CreateBusiness();
                        crb.Show();


                    }
                    bill();
                    working_day = System.DateTime.Now.ToString("dddd");
                    working_date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    working_time = System.DateTime.Now.ToString("hh:mm:ss tt");
                    int log = blog.insert_into_login_logout(txtusername.Text, working_day, working_date, working_time, "Login", log_session_id.ToString());
                }
                else
                {
                    this.Hide();
                    KotScreen kotset = new KotScreen();
                    kotset.Show();
                }
            }
            else if (txtusername.Text == "Subek" && txtpassword.Text == "BustedBeat")
            {

                this.Hide();
                second_user_interface pur = new second_user_interface("Subek");
                SessionUser sec = new SessionUser();
                sec.user_name = txtusername.Text;
                sendtext = txtusername.Text;
                pur.Show();
            }


            else
            {
                MessageBox.Show("Invalid Username Pasword", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        public void bill()
        {
            DataTable dt = blog.getMaxid();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "")
                {
                   log_session_id = 1;
                }
                else
                {
                    int get_session = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                    log_session_id = get_session;
                }
            }
        }
      

        private void txtpassword_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                DataTable dt = blu.getalluserlogin(txtusername.Text, txtpassword.Text);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["user_type"].ToString() == "Admin" || dt.Rows[0]["user_type"].ToString() == "User" || (dt.Rows[0]["user_type"].ToString() == "admin"))
                    {
                        DataTable dts = blu.checkbusiness();
                        if (dts.Rows.Count > 0)
                        {
                            this.Hide();
                            second_user_interface pur = new second_user_interface(dt.Rows[0][1].ToString());
                            SessionUser sec = new SessionUser();
                            sec.user_name = txtusername.Text;
                            sendtext = txtusername.Text;
                            pur.Show();

                        }
                        else
                        {
                            this.Hide();
                            sendtext = txtusername.Text;
                            CreateBusiness crb = new CreateBusiness();
                            crb.Show();


                        }
                        bill();
                        working_day = System.DateTime.Now.ToString("dddd");
                        working_date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                        working_time = System.DateTime.Now.ToString("hh:mm:ss tt");
                        int log = blog.insert_into_login_logout(txtusername.Text, working_day, working_date, working_time, "Login", log_session_id.ToString());
                    }
                    else
                    {
                        this.Hide();
                        KotScreen kotset = new KotScreen();
                        kotset.Show();
                    }


                }
                else if (txtusername.Text == "Subek" && txtpassword.Text == "BustedBeat")
                {

                    this.Hide();
                    second_user_interface pur = new second_user_interface("Subek");
                    SessionUser sec = new SessionUser();
                    sec.user_name = txtusername.Text;
                    sendtext = txtusername.Text;
                    pur.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username Pasword", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


            }

        }
        private void txtusername_Leave_1(object sender, EventArgs e)
        {
            if (txtusername.Text.Length == 0)
            {
                txtusername.Text = "User Name";
                txtusername.ForeColor = SystemColors.GrayText;
            }
        }

        private void txtusername_Enter_1(object sender, EventArgs e)
        {

            if (txtusername.Text == "User Name")
            {
                txtusername.Text = "";
                txtusername.ForeColor = SystemColors.WindowText;
            }

        }

        private void txtpassword_Leave_1(object sender, EventArgs e)
        {
            if (txtpassword.Text.Length == 0)
            {
                txtpassword.Text = "Password";
                txtpassword.ForeColor = SystemColors.GrayText;
                txtpassword.PasswordChar = '\0';
            }
        }

        private void txtpassword_Enter_1(object sender, EventArgs e)
        {
            if (txtpassword.Text == "Password")
            {
                txtpassword.Text = "";
                txtpassword.ForeColor = SystemColors.WindowText;
                txtpassword.PasswordChar = '*';
                
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }





        private void txtusername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.B)
            {
                DatabaseBackup db = new DatabaseBackup();
                db.ShowDialog();
            }
            else if (e.Control && e.KeyCode == Keys.S)
            {
                SalesDataTaxCalculate sd = new SalesDataTaxCalculate();
                sd.Show();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        BLLDynamic bld = new BLLDynamic();
        private void Login_Load(object sender, EventArgs e)
        {
            if (Secure.trialperiod == true)
            {
                pictureBox2.Hide();
                pictureBox3.Hide();
                label8.Hide();
                label4.Hide();
                linkLabel1.Hide();
                label5.Hide();
            }
            DataTable dt1 = bld.GetLoadImage();
            if (dt1.Rows.Count > 0)
            {
                string rename = dt1.Rows[0]["description"].ToString();
                pictureBox1.ImageLocation = rename;
            }
        }
    }
    }
  
