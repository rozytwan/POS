using BLLS.BLLHotel;
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
    public partial class RoomPackage : UserControl
    {
        public RoomPackage()
        {
            InitializeComponent();
        }
        BLL_HotelCategory blhc = new BLL_HotelCategory();
        private void RoomPackage_Load(object sender, EventArgs e)
        {
            LoadRoomPackage();
            btn_update.Enabled = false;
            btn_save.Enabled = true;
        }
        public void LoadRoomPackage()
        {
            DataTable dt = blhc.GetRoomPackage();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)

                {
                    dataGridView1.Rows.Add();

                    dataGridView1.Rows[i].Cells["col_id"].Value = dt.Rows[i]["package_id"].ToString();
                    dataGridView1.Rows[i].Cells["col_package"].Value = dt.Rows[i]["package_name"].ToString();
                    dataGridView1.Rows[i].Cells["col_price"].Value = dt.Rows[i]["price"].ToString();
                    dataGridView1.Rows[i].Cells["col_description"].Value = dt.Rows[i]["description"].ToString();
                    
                }
            }
        }
        int package_id;
        public void Clear()
        {
             txt_package.Text = "";
            rich_description.Text = "";
            txt_price.Text = "";
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_package.Text == "" || rich_description.Text == "")
            {
                MessageBox.Show("Room Package Information Not Completed", "Room Package Alert !!");
            }
            else
            {
                int insert_package = blhc.Insert_Room_Package(txt_package.Text,Convert.ToDecimal(txt_price.Text),rich_description.Text);
                if (insert_package > 0)
                {
                    MessageBox.Show("Successfully Inserted", "Data Inserted Alert !!");
                    LoadRoomPackage();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Oops Not Inserted", "Unsuccess Insert Alert !!");
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                package_id = (Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_id"].Value));
                DataTable dt = blhc.GetRoompackageById(package_id);
                if (dt.Rows.Count > 0)
                {
                    txt_package.Text = dt.Rows[0]["package_name"].ToString();
                  txt_price.Text= dt.Rows[0]["price"].ToString();
                    rich_description.Text = dt.Rows[0]["description"].ToString();
                    btn_update.Enabled = true;
                    btn_save.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Select Row To Be Edited", "Select Data Alert !!");
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int update = blhc.UpdatePackage(package_id, txt_package.Text,Convert.ToDecimal(txt_price.Text),rich_description.Text);

            if (update > 0)
            {
                MessageBox.Show("Updated Successfully", "Success Alert !!");
                LoadRoomPackage();
                Clear();
                btn_save.Enabled = true;
                btn_update.Enabled = false;

            }
            else
            {
                MessageBox.Show("Oops Not Updated", "Unsuccess Alert !!");
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                package_id = (Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_id"].Value));
                DataTable dt = blhc.GetRoompackageById(package_id);
                if (dt.Rows.Count > 0)
                {
                    txt_package.Text = dt.Rows[0]["package_name"].ToString();
            
                    rich_description.Text = dt.Rows[0]["description"].ToString();
                }
                DialogResult dig = MessageBox.Show("Are You Sure To Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dig == DialogResult.Yes)
                {
                    int delete = blhc.DeleteRoomPackage((Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_id"].Value)));
                    if (delete > 0)
                    {
                        MessageBox.Show("Successfully Deleted", "Delete Alert !!");
                        LoadRoomPackage();

                    }

                }

            }
            else
            {
                MessageBox.Show("Select Row To Be Edited", "Select Data Alert !!");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_price_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
