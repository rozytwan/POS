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
    public partial class Donation_Event : Control
    {
        public Donation_Event()
        {
            InitializeComponent();
        }
        BLL_donation blld = new BLL_donation();
        private void Donation_Load(object sender, EventArgs e)
        {
            datagridviewLoad();
            cbo_status.SelectedIndex = 0;
        }
        public void datagridviewLoad()
        {
            DataTable dt = blld.GetDonation();
            if (dt.Rows.Count>0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int sd = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_donation_id"].Value = dt.Rows[i]["donation_id"].ToString();
                    dataGridView1.Rows[i].Cells["col_title"].Value = dt.Rows[i]["title"].ToString();
                    dataGridView1.Rows[i].Cells["col_remark"].Value = dt.Rows[i]["remarks"].ToString();
                    dataGridView1.Rows[i].Cells["col_date"].Value = dt.Rows[i]["date"].ToString();
                    dataGridView1.Rows[i].Cells["col_amount"].Value = dt.Rows[i]["amount"].ToString();
                    dataGridView1.Rows[i].Cells["col_organizer"].Value = dt.Rows[i]["organizer"].ToString();
                    dataGridView1.Rows[i].Cells["col_status"].Value = dt.Rows[i]["status"].ToString();

                }
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            int insert=blld.InsertDonation(txt_title.Text,txt_remark.Text,Convert.ToDecimal(txt_amount.Text),txt_organizer.Text,cbo_status.Text,Convert.ToDateTime(dtp_date.Text));
            if (insert>0)
            {
                MessageBox.Show("Successfully Inserted Alert !!","Success Alert !!");
                datagridviewLoad();
            }
           
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int update = blld.UpdateDonation(donation_id,txt_title.Text, txt_remark.Text, Convert.ToDecimal(txt_amount.Text), txt_organizer.Text, cbo_status.Text, Convert.ToDateTime(dtp_date.Text));
            if (update > 0)
            {
                MessageBox.Show("Successfully Updated Alert !!", "Success Alert !!");
                datagridviewLoad();
            }
        }
        int donation_id;
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                btn_save.Enabled = false;
                btn_update.Enabled = true;
                foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                {
                     donation_id = Convert.ToInt32(dr.Cells["col_donation_id"].Value);
                    DataTable dt = blld.SeleteDonation(donation_id);

                    if (dt.Rows.Count > 0)
                    {
                        
                      txt_title.Text = dt.Rows[0]["title"].ToString();
                        txt_remark.Text= dt.Rows[0]["remarks"].ToString();
                       dtp_date.Text = dt.Rows[0]["date"].ToString();
                        txt_amount.Text= dt.Rows[0]["amount"].ToString();
                       txt_organizer.Text= dt.Rows[0]["organizer"].ToString();
                        cbo_status.Text = dt.Rows[0]["status"].ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Choose Row First Alert !!", "Select Row Alert !!");
            }
        }
        private void txt_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                {
                    int donation_id = Convert.ToInt32(dr.Cells["col_donation_id"].Value);
                    int delete = blld.DeleteDonation(donation_id);
                    if (delete > 0)
                    {
                        MessageBox.Show("Successfully Deleted Alert !!", "Success Alert !!");
                    }
                }
                datagridviewLoad();
            }
            else
            {
                MessageBox.Show("Please Choose Row First Alert !!", "Select Row Alert !!");
            }
        }
    }
}
