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

namespace POS_System.Customer_Management
{
    public partial class EditAppointment : UserControl
    {
        public EditAppointment()
        {
            InitializeComponent();
        }
        BLLAppointmentGraph blgraph = new BLLAppointmentGraph();

        private void ViewAppointment_Load(object sender, EventArgs e)
        {
            LoadAppointment();
        }
        public void LoadAppointment()
        {
            DataTable dt = blgraph.GetAllAppointment();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_id"].Value = dt.Rows[i]["appo_id"].ToString();
                   // dataGridView1.Rows[i].Cells["col_customerid"].Value = dt.Rows[i]["customer_id"].ToString();
                    int customer_id = Convert.ToInt32(dt.Rows[i]["customer_id"].ToString());
                    DataTable dt1 = blgraph.GetCustomer(customer_id);
                    if (dt1.Rows.Count>0)
                    {
                        dataGridView1.Rows[i].Cells["col_customerid"].Value = dt1.Rows[0]["name"].ToString();
                    }
              dataGridView1.Rows[i].Cells["col_tableno"].Value = dt.Rows[i]["table_no"].ToString();
                    dataGridView1.Rows[i].Cells["col_starttime"].Value = dt.Rows[i]["start_time"].ToString();
                    dataGridView1.Rows[i].Cells["col_endtime"].Value = dt.Rows[i]["end_time"].ToString();
                    dataGridView1.Rows[i].Cells["col_remaining"].Value = dt.Rows[i]["Reminder"].ToString();
                    dataGridView1.Rows[i].Cells["col_remaintime"].Value = dt.Rows[i]["reminder_time"].ToString();
                    dataGridView1.Rows[i].Cells["col_remark"].Value = dt.Rows[i]["remarks"].ToString();
                    dataGridView1.Rows[i].Cells["col_status"].Value = dt.Rows[i]["status"].ToString();
                }
            }
        }
        public static int appo_id;
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                {
                    appo_id = Convert.ToInt32(dr.Cells["col_id"].Value);
                }
                AppointmentBooking booking = new AppointmentBooking();
                booking.Show();
            }
            else
            {
                MessageBox.Show("Please Select A Row", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
     
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dig = MessageBox.Show("Are You Sure To Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dig == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
appo_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_id"].Value);
                        int delete = blgraph.DeleteAppointment(appo_id);
                        if (delete > 0)
                        {
                            MessageBox.Show("Successfully Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        dataGridView1.Rows.RemoveAt(dr.Index); //removes the deleted row
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select A Row", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
      
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col_edit"].Index && e.RowIndex >= 0)
            {
               appo_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_id"].Value.ToString());
                AppointmentBooking booking = new AppointmentBooking();
                booking.ShowDialog();
                
            }
            else if (e.ColumnIndex == dataGridView1.Columns["col_delete"].Index && e.RowIndex >= 0)
            {
              
                    DialogResult dig = MessageBox.Show("Are You Sure To Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dig == DialogResult.Yes)
                    {
                         appo_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_id"].Value);
                            int delete = blgraph.DeleteAppointment(appo_id);
                            if (delete > 0)
                            {
                                MessageBox.Show("Successfully Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAppointment();
                            }
                         
                    }
                }
                else
                {
                    MessageBox.Show("Please Select A Row", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }

