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
    public partial class Cashcounter : Form
    {
        public Cashcounter()
        {
            InitializeComponent();
        }
        Bll_cashcounter bllcash = new Bll_cashcounter();
        Bll_CashwithDrawl bllwithdrawl = new Bll_CashwithDrawl();
        public void getsalestillnow() {
            string datenow = DateTime.Now.ToShortDateString();
            DataTable allsells = bllcash.getsellcashamount(Convert.ToDateTime(datenow));
            label_sale.Text = allsells.Rows[0][0].ToString();
            try {
                txt_opening.Text = (Convert.ToDecimal(label_sale.Text) + Convert.ToDecimal(lbl_todays.Text)).ToString();
            }
            catch (FormatException) {
            }

        }
        public void loadopening() {
            DataTable dt = bllcash.getalldata();
            try
            {
                if (dt.Rows[0][1].ToString() == "")
                {
                    txt_opening.Text = txt_closing.Text;
                    lbl_todays.Text = "Balance not set yet.";
                }
                else
                {
                    string opening = dt.Rows[0][1].ToString();
                    txt_opening.Text = opening;
                    lbl_todays.Text =opening;
                }
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Set Opening Balance");
            }
        }

        public void loadclosing()
        {
            DataTable dt = bllcash.getalldata();
            try
            {
                if (dt.Rows[0][3].ToString() == "")
                {

                    DateTime getdate = Convert.ToDateTime(dt.Rows[0][3].ToString());
                    DataTable datas = bllcash.getdatabydate(getdate);
                    txt_closing.Text = datas.Rows[0]["total"].ToString();
                }
                else
                {
                    txt_closing.Text = "0";
                }
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Set Opening Balance");
            }

        }
        public void checkTodayopningbalance() {
            DataTable dt = bllcash.getallclosingdata();
            if (dt.Rows.Count > 0)
            {
                DateTime getDBdate = Convert.ToDateTime(dt.Rows[0][3].ToString());
                DateTime todaydate = Convert.ToDateTime(DateTime.Now.ToLongDateString());
              
                  
                    DataTable getall = bllcash.getalldata();
                    if (getall.Rows[0]["closing_balc"].ToString() == "")
                    {
                        DateTime getdate = Convert.ToDateTime(dt.Rows[0][3].ToString());
                        DataTable datas = bllcash.getdatabydate(getdate);
                        txt_closing.Text = datas.Rows[0]["total"].ToString();
                    }
                    else {
                        txt_closing.Text = getall.Rows[0]["closing_balc"].ToString();
                        
                    }
                
               
            }

        }
        
        private void btn_set_Click(object sender, EventArgs e)
        {
            //DataTable checkdates = bllcash.checkexistingdate(Convert.ToDateTime(DateTime.Now.ToShortDateString()));

            //if (checkdates.Rows.Count>0) {
            //    DialogResult dialogResult = MessageBox.Show("Opening Balance Already set ", "Already Exists", MessageBoxButtons.YesNo);
            //    if (dialogResult == DialogResult.Yes)
            //    {
            //        decimal total = Convert.ToDecimal(txt_opening.Text) + Convert.ToDecimal(txt_closing.Text ?? String.Empty);

            //        int i = bllcash.insertinto(total, Convert.ToDateTime(lbl_datatime_now.Text));
            //        if (i > 0)
            //        {
            //            MessageBox.Show("Set Balance Successfully");
            //            Cashcounter acsload = new Cashcounter();
            //            this.Hide();
            //            acsload.ShowDialog(this);
            //        }
            //    }
            //    else if (dialogResult == DialogResult.No)
            //    {
            //        //do something else
            //    }
            //}
            //else {
            //    decimal total = Convert.ToDecimal(txt_opening.Text) + Convert.ToDecimal(txt_closing.Text ?? String.Empty);

            //    int i = bllcash.insertinto(total, Convert.ToDateTime(lbl_datatime_now.Text));
            //    if (i > 0) {
            //        MessageBox.Show("Set Balance Successfully");
            //        Cashcounter acsload = new Cashcounter();
            //        this.Hide();
            //        acsload.ShowDialog(this);
            //    } }
        }

        private void btn_closing_Click(object sender, EventArgs e)
        {
            int i = bllcash.insertclosing(Convert.ToDecimal(txt_closing.Text), Convert.ToDateTime(lbl_datatime_now.Text));
            if (i > 0)
            {
                MessageBox.Show("Set Closing Balance Successfully");
                Cashcounter acsload = new Cashcounter();
                this.Hide();
                acsload.ShowDialog(this);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Cashcounter_Load(object sender, EventArgs e)
        {

            lbl_datatime_now.Text = DateTime.Now.ToLongDateString();
            checkTodayopningbalance();
            loadopening();
            getsalestillnow();
            loadgrid();

        }
        public void loadgrid()
        {
            DataTable dtt = bllwithdrawl.getalldatas();
            for (int qw = 0; qw < dtt.Rows.Count; qw++)
            {
                dgv_all.Rows.Add();
                dgv_all.Rows[qw].Cells["caldate"].Value = dtt.Rows[qw]["date"].ToString();
                dgv_all.Rows[qw].Cells["calname"].Value = dtt.Rows[qw]["name"].ToString();
                dgv_all.Rows[qw].Cells["calamount"].Value = dtt.Rows[qw]["cash"].ToString();
                dgv_all.Rows[qw].Cells["calstatus"].Value = dtt.Rows[qw]["status"].ToString();
                dgv_all.Rows[qw].Cells["caldesc"].Value = dtt.Rows[qw]["withdrawl_type"].ToString();

            }
        }

        private void dgv_all_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Opening Balance Already set ", "Already Exists", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("hehehehe do you wnat to delete ?");   
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("you pressed no hehehe");
            }
        }
    }
}
