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
    public partial class Department : UserControl
    {
        public Department()
        {
            InitializeComponent();
        }
        BLLdepartment bld = new BLLdepartment();
        private void Department_Load(object sender, EventArgs e)
        {
            loaddepartment();
            btn_update.Enabled = false;
        }
        public void loaddepartment()
        {
            DataTable dt = bld.Getdepartment();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_department_name"].Value = dt.Rows[i]["department"].ToString();
                    dataGridView1.Rows[i].Cells["col_id"].Value = dt.Rows[i]["id"].ToString();

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = bld.get_department_by_name(txt_department_name.Text);

            if (txt_department_name.Text == "")
            {
                MessageBox.Show("Field cannot be empty");
            }
           else if (dt.Rows.Count == 0)
            {
                int insert = bld.InsertDepartment(txt_department_name.Text);
                if (insert > 0)
                {
                    MessageBox.Show("inserted");
                    loaddepartment();
                    txt_department_name.Text = "";
                }

            }

            else 
            {
                MessageBox.Show("Already exist in database");
            }
        }
        public static int id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col_edit"].Index && e.RowIndex >= 0)
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_id"].Value.ToString());
                txt_department_name.Text = dataGridView1.CurrentRow.Cells["col_department_name"].Value.ToString();
                button2.Enabled = false;
                btn_update.Enabled = true;

            }
            else if (e.ColumnIndex == dataGridView1.Columns["col_delete"].Index && e.RowIndex >= 0)
            {
                var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_id"].Value.ToString());

                    int delete = bld.DeleteDepartment(id);
                    if (delete > 0)
                    {
                        MessageBox.Show("Department is deleted successfully");

                        loaddepartment();
                    }
                }
                if (confirmResult == DialogResult.No)
                {

                }
             
            }
        }
        private void btn_back_Click(object sender, EventArgs e)
        {

        }
       
        private void btn_update_Click(object sender, EventArgs e)
        {
            DataTable dt = bld.get_department_by_name(txt_department_name.Text);
            if (txt_department_name.Text == "")
            {
                MessageBox.Show("Fields cannot be empty", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (dt.Rows.Count == 0)
                {
                    int update = bld.UpdateDepartment(id, txt_department_name.Text);
                    if (update > 0)
                    {
                        MessageBox.Show("Updated susccessfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_department_name.Text = "";

                        loaddepartment();
                    }
                }
                else
                {
                    MessageBox.Show("Already exist in database", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
       
            }
        
        }
    }

