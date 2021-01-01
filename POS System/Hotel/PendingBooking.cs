using BLLS.BLLHotel;
using BLLS.Hotel;
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
    public partial class PendingBooking : Form
    {
        public PendingBooking()
        {
            InitializeComponent();
        }
        BLL_Pending pend = new BLL_Pending();
        BLL_checkout blout = new BLL_checkout();
        private void PendingBooking_Load(object sender, EventArgs e)
        {
            LoadPendingBooking();
        }
        public static int pending_booking_id;
        public void LoadPendingBooking()
        {
            DataTable dt = pend.GetPendingBook();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    pending_booking_id = Convert.ToInt32(dt.Rows[i]["pending_booking_id"].ToString());
                    dataGridView1.Rows[i].Cells["col_pend_id"].Value = dt.Rows[i]["pending_booking_id"].ToString();
                    dataGridView1.Rows[i].Cells["col_customer_id"].Value = dt.Rows[i]["customer_id"].ToString();
                    DataTable dt1 = pend.GetName(Convert.ToInt32(dt.Rows[i]["customer_id"].ToString()));
                    if (dt1.Rows.Count > 0)
                    {
                        dataGridView1.Rows[i].Cells["col_name"].Value = dt1.Rows[0]["name"].ToString();
                    }
                    dataGridView1.Rows[i].Cells["col_booking_date"].Value = dt.Rows[i]["booking_date"].ToString();
                    dataGridView1.Rows[i].Cells["col_checkin"].Value = dt.Rows[i]["check_in"].ToString();
                    dataGridView1.Rows[i].Cells["col_check_out"].Value = dt.Rows[i]["check_out"].ToString();
                    dataGridView1.Rows[i].Cells["col_room_type"].Value = dt.Rows[i]["room_type"].ToString();
                    dataGridView1.Rows[i].Cells["col_no_of_guest"].Value = dt.Rows[i]["no_of_guest"].ToString();
                    dataGridView1.Rows[i].Cells["col_no_of_room"].Value = dt.Rows[i]["no_of_room"].ToString();

                }

            }
        }
        public int customer_id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col_view"].Index && e.RowIndex >= 0)
            {

                GetDetails ccb = new GetDetails();
                customer_id = Convert.ToInt32((dataGridView1.CurrentRow.Cells["col_customer_id"].Value.ToString()));
                pending_booking_id= Convert.ToInt32((dataGridView1.CurrentRow.Cells["col_pend_id"].Value.ToString()));
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            else if (e.ColumnIndex == dataGridView1.Columns["col_cancel"].Index && e.RowIndex >= 0)
            {

                DialogResult dig = MessageBox.Show("Are You Sure To Cancel Booking ??", "Delete Alert !!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dig == DialogResult.Yes)
                {
                string today = DateTime.Now.ToString();
                        customer_id = Convert.ToInt32((dataGridView1.CurrentRow.Cells["col_customer_id"].Value.ToString()));
                        int delete = pend.Cancelation(Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_pend_id"].Value.ToString()));
                    int deleteCustomer = pend.DeleteCustomer(customer_id);
                    int deleteDetails= pend.DeleteCustomer(customer_id);

                    if (delete>0)
                    {
                        MessageBox.Show("Successfully Deleted", "Delete Alert !!");
                        LoadPendingBooking();
                        
                    }
                
                    int insert = blout.Insert_Cancel(customer_id, 0, Convert.ToDateTime(today), "Booking Cancel");
                       
                    }
                }
            }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
