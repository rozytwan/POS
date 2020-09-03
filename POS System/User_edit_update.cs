
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using BLLS;

namespace POS
{
    public partial class EditUpdateUser : UserControl
    {
        public EditUpdateUser()
        {
            InitializeComponent();
        }

        public static int user_id;
        BLLUser blluser = new BLLUser();
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\User Image\\";
        private void EditUpdateUser_Load(object sender, EventArgs e)
        {
            DataTable dt = blluser.getalluserdetails();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int user_details = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_userid"].Value = dt.Rows[i]["user_id"].ToString();
                    dataGridView1.Rows[i].Cells["col_first_name"].Value = dt.Rows[i]["first_name"].ToString();
                    dataGridView1.Rows[i].Cells["col_lastname"].Value = dt.Rows[i]["last_name"].ToString();
                    dataGridView1.Rows[i].Cells["col_email"].Value = dt.Rows[i]["e_mail"].ToString();
                    dataGridView1.Rows[i].Cells["col_password"].Value = dt.Rows[i]["password"].ToString();
                    dataGridView1.Rows[i].Cells["col_gender"].Value = dt.Rows[i]["gender"].ToString();
                    dataGridView1.Rows[i].Cells["col_dob"].Value = dt.Rows[i]["date_of_birth"].ToString();
                    dataGridView1.Rows[i].Cells["col_dateofjoining"].Value = dt.Rows[i]["date_of_joining"].ToString();
                    dataGridView1.Rows[i].Cells["col_city"].Value = dt.Rows[i]["city"].ToString();
                    dataGridView1.Rows[i].Cells["col_addressline2"].Value = dt.Rows[i]["address_line_2"].ToString();
                    dataGridView1.Rows[i].Cells["col_addressline1"].Value = dt.Rows[i]["address_line_1"].ToString();
                    dataGridView1.Rows[i].Cells["col_usertype"].Value = dt.Rows[i]["user_type"].ToString();
                    dataGridView1.Rows[i].Cells["col_pin"].Value = dt.Rows[i]["pin"].ToString();
                    dataGridView1.Rows[i].Cells["col_zipcode"].Value = dt.Rows[i]["zip_code"].ToString();
                    dataGridView1.Rows[i].Cells["col_state"].Value = dt.Rows[i]["state"].ToString();
                    dataGridView1.Rows[i].Cells["col_username"].Value = dt.Rows[i]["user_name"].ToString();
                    dataGridView1.Rows[i].Cells["col_user_image"].Value = dt.Rows[i]["user_image"].ToString();
                }

            }

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                {

                    user_id = Convert.ToInt32(dr.Cells["col_userid"].Value.ToString());
                }
                user user = new user();
                panel1.Controls.Clear();
                panel1.Controls.Add(user);

                user.btn_save.Enabled = false;
                user.btn_update.Enabled = true;

            }
            else
            {
                MessageBox.Show("Please Select A Row", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dig = MessageBox.Show("Do You Like to Delete User", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dig == DialogResult.Yes)
                {

                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        string user_image_name = dr.Cells["col_user_image"].Value.ToString();
                        user_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_userid"].Value);
                        int delete_user = blluser.deleteuser(user_id);
                        if (delete_user > 0)
                        {
                            MessageBox.Show("Successfully Deleted", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (user_image_name.Length > 0)
                            {
                                bool s = File.Exists(path + user_image_name);
                                if (s == true)
                                {

                                    System.IO.File.Delete(path + user_image_name);
                                }
                            }
                        }
                        dataGridView1.Rows.RemoveAt(dr.Index);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select A Row", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                {
                    user_id = Convert.ToInt32(dr.Cells["col_userid"].Value.ToString());
                }
                CV cv = new CV();
                cv.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void btn_adduser_Click(object sender, EventArgs e)
        {
            user_id = 0;
            user user = new user();
            Control ctls = this.Parent;
            ctls.Controls.Clear();
            ctls.Controls.Add(user);
        }
    }
}
