using BLLS;
using POS;
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
    public partial class UserAccess : UserControl
    {
        public UserAccess()
        {
            InitializeComponent();
        }
        BLLUser blu = new BLLUser();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == cal_all.Index && e.RowIndex != -1)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells[1];
                chk.Value = !(chk.Value == null ? false : (bool)chk.Value);
                DataGridViewCheckBoxCell chk2 = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells[2];
                chk2.Value = !(chk2.Value == null ? false : (bool)chk2.Value);
                DataGridViewCheckBoxCell chk3 = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells[3];
                chk3.Value = !(chk3.Value == null ? false : (bool)chk3.Value);
                DataGridViewCheckBoxCell chk4 = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells[4];
                chk4.Value = !(chk4.Value == null ? false : (bool)chk4.Value);
                DataGridViewCheckBoxCell chk5 = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells[5];
                chk5.Value = !(chk5.Value == null ? false : (bool)chk5.Value);
                DataGridViewCheckBoxCell chk6 = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells[6];
                chk6.Value = !(chk6.Value == null ? false : (bool)chk6.Value);
                DataGridViewCheckBoxCell chk7 = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells[7];
                chk7.Value = !(chk7.Value == null ? false : (bool)chk7.Value);
                DataGridViewCheckBoxCell chk8 = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells[8];
                chk8.Value = !(chk8.Value == null ? false : (bool)chk8.Value);
                DataGridViewCheckBoxCell chk9 = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells[9];
                chk9.Value = !(chk9.Value == null ? false : (bool)chk9.Value);
                DataGridViewCheckBoxCell chk10 = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells["col_table_transfer"];
                chk10.Value = !(chk10.Value == null ? false : (bool)chk10.Value);
                DataGridViewCheckBoxCell chk11 = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells["col_takeaway"];
                chk11.Value = !(chk11.Value == null ? false : (bool)chk11.Value);
                DataGridViewCheckBoxCell chk12 = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells["col_homedelivery"];
                chk12.Value = !(chk10.Value == null ? false : (bool)chk12.Value);
                DataGridViewCheckBoxCell chk13 = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells["col_dayend"];
                chk13.Value = !(chk13.Value == null ? false : (bool)chk13.Value);
                DataGridViewCheckBoxCell chk14 = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells["col_cashdrop"];
                chk14.Value = !(chk14.Value == null ? false : (bool)chk14.Value);
                DataGridViewCheckBoxCell chk15 = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells["col_menuupdate"];
                chk15.Value = !(chk15.Value == null ? false : (bool)chk15.Value);
                DataGridViewCheckBoxCell chk16 = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells["col_itemcancel"];
                chk16.Value = !(chk16.Value == null ? false : (bool)chk16.Value);
                DataGridViewCheckBoxCell chk17 = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells["col_restaurant"];
                chk17.Value = !(chk17.Value == null ? false : (bool)chk17.Value);
                DataGridViewCheckBoxCell chk18 = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells["col_hotel"];
                chk18.Value = !(chk18.Value == null ? false : (bool)chk18.Value);
            }
        }
        string account = "False";
        string sales = "False";
        string report = "False";
        string stock = "False";
        string admin = "False";
        string discount="False";
        string billing = "False";
        string multibilling = "False";
        string itemtransfer = "False";
        string tabletransfer = "False";
        string takeaway = "False";
        string homedelivery = "False";
        string dayend = "False";
        string cashdrop = "False";
        string menuupdate = "False";
        string itemcancel = "False";
        string restaurant = "False";
        string hotel = "False";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if ((dataGridView1.CurrentRow.Cells["cal_user_name"].Value).ToString() == "admin")
            //{

            //    DataGridViewCheckBoxCell chk10 = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells[1];
            //    chk10.Value =true;
          
            //    //if (chk1.Checked == true || checkBox.Checked == false)
            //    //{
            //    //    chk1.CheckState = CheckState.Checked;
            //    //    chk1.CheckState = CheckState.Indeterminate;
            //    //    //or 
            //    //    checkBox.CheckState = CheckState.Checked;
            //    //}
            //}
            if (e.ColumnIndex == dataGridView1.Columns["cal_update"].Index && e.RowIndex >= 0)
            {
                //DataGridViewCheckBoxCell chk1 = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells[1];
                //DataGridViewCheckBoxCell chk2 = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells[2];
                //DataGridViewCheckBoxCell chk3 = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells[3];
                //DataGridViewCheckBoxCell chk4 = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells[4];
                //DataGridViewCheckBoxCell chk5 = (DataGridViewCheckBoxCell)dataGridView1.CurrentRow.Cells[5];
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[1].Value) == true)
                {
                    account = "True";
                }
                else
                {
                    account = "False";
                }           
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[2].Value) == true)
                {
                    sales = "True";
                }
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[4].Value) == true)
                {
                    stock = "True";
                }
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[3].Value) == true)
                {
                    report = "True";
                }
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[6].Value) == true)
                {
                    admin = "True";
                }
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[5].Value) == true)
                {
                    discount = "True";
                }
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[7].Value) == true)
                {
                    billing = "True";
                }
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[8].Value) == true)
                {
                    multibilling = "True";
                }
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[9].Value) == true)
                {
                    itemtransfer = "True";
                }
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells["col_table_transfer"].Value) == true)
                {
                    tabletransfer = "True";
                }
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells["col_takeaway"].Value) == true)
                {
                    takeaway = "True";
                }
                else
                {
                    takeaway = "False";
                }
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells["col_homedelivery"].Value) == true)
                {
                    homedelivery = "True";
                }
                else
                {
                    homedelivery = "False";
                }
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells["col_dayend"].Value) == true)
                {
                    dayend = "True";
                }
                else
                {
                    dayend = "False";
                }
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells["col_cashdrop"].Value) == true)
                {
                    cashdrop = "True";
                }
                else
                {
                    cashdrop = "False";
                }
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells["col_menuupdate"].Value) == true)
                {
                    menuupdate = "True";
                }
                else
                {
                    menuupdate = "False";
                }
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells["col_itemcancel"].Value) == true)
                {
                    itemcancel = "True";
                }
                else
                {
                    itemcancel = "False";
                }
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells["col_restaurant"].Value) == true)
                {
                    restaurant = "True";
                }
                else
                {
                    restaurant = "False";
                }
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells["col_hotel"].Value) == true)
                {
                    hotel = "True";
                }
                else
                {
                    hotel = "False";
                }
                DataTable dtm = blu.getuserbyuser_idntype(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_user_id"].Value));
                if (dtm.Rows.Count > 0)
                {
                    int update_access = blu.updateuser_access(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_user_id"].Value), admin, account, sales, report, stock,discount,billing,multibilling,itemtransfer,tabletransfer,takeaway,homedelivery,dayend,cashdrop,menuupdate,itemcancel,restaurant,hotel);
                    if (update_access > 0)
                    {
                        MessageBox.Show("User Access Has Been Update");
                    }
                }
                else
                {
                    int ins = blu.insert_user_id(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_user_id"].Value), admin, account, sales, report, stock,discount,billing,multibilling,itemtransfer,tabletransfer, takeaway, homedelivery, dayend, cashdrop, menuupdate, itemcancel,restaurant,hotel);
                    MessageBox.Show("User Access Has Been Update");
                }
            }

        }

        private void UserAccess_Load(object sender, EventArgs e)
        {
            grid_view_load();
        }
        public void grid_view_load()
        {
            DataTable dt = blu.getalluser();
            for (int i = 0; dt.Rows.Count > i; i++)
            {
                int bc = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["cal_user_id"].Value = dt.Rows[i]["user_id"].ToString();
                dataGridView1.Rows[i].Cells["cal_user_name"].Value = dt.Rows[i]["user_name"].ToString();
                DataTable dtm = blu.getuserbyuser_idntype(Convert.ToInt32(dt.Rows[i]["user_id"].ToString()));
                if (dtm.Rows.Count > 0)
                {
                    DataGridViewCheckBoxCell chk5 = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["cal_account"];
                    DataGridViewCheckBoxCell chk4 = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["cal_admin"];
                    DataGridViewCheckBoxCell chk3 = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["cal_sales"];
                    DataGridViewCheckBoxCell chk2 = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["cal_stock"];
                    DataGridViewCheckBoxCell chk1 = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["cal_report"];
                    DataGridViewCheckBoxCell chk6 = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["cal_discount"];
                    DataGridViewCheckBoxCell chk7 = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["col_billing"];
                    DataGridViewCheckBoxCell chk8 = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["col_multibilling"];
                    DataGridViewCheckBoxCell chk9 = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["col_itemtransfer"];
                    DataGridViewCheckBoxCell chk10 = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["col_table_transfer"];
                    DataGridViewCheckBoxCell chk11 = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["col_takeaway"];
                    DataGridViewCheckBoxCell chk12 = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["col_homedelivery"];
                    DataGridViewCheckBoxCell chk13= (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["col_dayend"];
                    DataGridViewCheckBoxCell chk14 = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["col_cashdrop"];
                    DataGridViewCheckBoxCell chk15 = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["col_menuupdate"];
                    DataGridViewCheckBoxCell chk16= (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["col_itemcancel"];
                    DataGridViewCheckBoxCell chk17 = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["col_restaurant"];
                    DataGridViewCheckBoxCell chk18 = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["col_hotel"];
                    if (dtm.Rows[0]["account"].ToString() == "True")
                    {
                        chk5.Value = true;
                    }
                    if (dtm.Rows[0]["admin"].ToString() == "True")
                    {
                        chk4.Value = true;
                    }
                    if (dtm.Rows[0]["sales"].ToString() == "True")
                    {
                        chk3.Value = true;
                    }
                    if (dtm.Rows[0]["stock"].ToString() == "True")
                    {
                        chk2.Value = true;
                    }
                    if (dtm.Rows[0]["report"].ToString() == "True")
                    {
                        chk1.Value = true;
                    }
                    if (dtm.Rows[0]["discount"].ToString() == "True")
                    {
                        chk6.Value = true;
                    }
                    if (dtm.Rows[0]["billing"].ToString() == "True")
                    {
                        chk7.Value = true;
                    }
                    if (dtm.Rows[0]["multibilling"].ToString() == "True")
                    {
                        chk8.Value = true;
                    }
                    if (dtm.Rows[0]["itemtransfer"].ToString() == "True")
                    {
                        chk9.Value = true;
                    }
                    if (dtm.Rows[0]["tabletransfer"].ToString() == "True")
                    {
                        chk10.Value = true;
                    }
                    if (dtm.Rows[0]["takeaway"].ToString() == "True")
                    {
                        chk11.Value = true;
                    }
                    if (dtm.Rows[0]["homedelivery"].ToString() == "True")
                    {
                        chk12.Value = true;
                    }
                    if (dtm.Rows[0]["dayend"].ToString() == "True")
                    {
                        chk13.Value = true;
                    }
                    if (dtm.Rows[0]["cashdrop"].ToString() == "True")
                    {
                        chk14.Value = true;
                    }
                    if (dtm.Rows[0]["menuupdate"].ToString() == "True")
                    {
                        chk15.Value = true;
                    }
                    if (dtm.Rows[0]["itemcancel"].ToString() == "True")
                    {
                        chk16.Value = true;
                    }
                    if (dtm.Rows[0]["restaurant"].ToString() == "True")
                    {
                        chk17.Value = true;
                    }
                    if (dtm.Rows[0]["hotel"].ToString() == "True")
                    {
                        chk18.Value = true;
                    }
                }
            }
        }
        public bool edit = true;
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (edit == true)
            {
                dataGridView1.Columns["cal_update"].Visible = true;
                edit = false;
                btn_edit.Text = "Save";
            }
            else if (edit == false)
            {
                dataGridView1.Columns["cal_update"].Visible = false;
                edit = true;
                btn_edit.Text = "Edit";
            }
        }
         
        private void btn_add_new_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            EditUpdateUser vieret = new EditUpdateUser();
            ctls.Controls.Clear();
            ctls.Controls.Add(vieret);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}


