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
    public partial class HotelUserAccess : UserControl
    {
        public HotelUserAccess()
        {
            InitializeComponent();
        }
        BLLUser blu = new BLLUser();
        string room_access = "False";
        string sales = "False";
        string report = "False";
     
        string admin = "False";
        string discount = "False";

        private void HotelUserAccess_Load(object sender, EventArgs e)
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
                DataTable dtm = blu.Getuserhotelaccess(Convert.ToInt32(dt.Rows[i]["user_id"].ToString()));
                if (dtm.Rows.Count > 0)
                {
                    DataGridViewCheckBoxCell chk5 = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["cal_room_access"];
                    DataGridViewCheckBoxCell chk4 = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["cal_admin"];
                    DataGridViewCheckBoxCell chk3 = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["cal_sales"];
                  
                    DataGridViewCheckBoxCell chk1 = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["cal_report"];
                    DataGridViewCheckBoxCell chk6 = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["cal_discount"];
                    if (dtm.Rows[0]["room_access"].ToString() == "True")
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
               
                    if (dtm.Rows[0]["report"].ToString() == "True")
                    {
                        chk1.Value = true;
                    }
                    if (dtm.Rows[0]["discount"].ToString() == "True")
                    {
                        chk6.Value = true;
                    }

                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["cal_update"].Index && e.RowIndex >= 0)
            {
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[1].Value) == true)
                {
                    sales = "True";
                }

                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[2].Value) == true)
                {
                    report = "True";
                }
           
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[3].Value) == true)
                {
                    room_access = "True";
                }
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[4].Value) == true)
                {
                    discount = "True";
                }
            
                if (Convert.ToBoolean(dataGridView1.CurrentRow.Cells[5].Value) == true)
                {
                    admin = "True";
                }
           
                DataTable dtm = blu.Getuserhotelaccess(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_user_id"].Value));
                if (dtm.Rows.Count > 0)
                {
                    int update_access = blu.updatehotel_access(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_user_id"].Value), admin, room_access, sales, report, discount);
                    if (update_access > 0)
                    {
                        MessageBox.Show("User Access Has Been Update");
                    }
                }
                else
                {
                    int ins = blu.insert_access_user(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_user_id"].Value), admin, room_access, sales, report, discount);
                    MessageBox.Show("User Access Has Been Update");
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
            }
        }
    }
}
