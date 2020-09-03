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
    public partial class RoomCategory : UserControl
    {
        public RoomCategory()
        {
            InitializeComponent();
        }
        BLL_HotelCategory category = new BLL_HotelCategory();
        private void RoomCategory_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 11);
           
            LoadCategory();
            btn_save.Enabled = true;
            btn_update.Enabled = false;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_category.Text == "" || txt_beds.Text == "")
            {
                MessageBox.Show("Room Details Not Completed", "Room Details Alert !!");
            }
            else
            {
                int insert_category = category.Insert_Category(txt_category.Text, Convert.ToInt32(txt_beds.Text), rich_description.Text);
                if (insert_category > 0)
                {
                    MessageBox.Show("Successfully Inserted", "Data Inserted Alert !!");
                    LoadCategory();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Oops Not Inserted", "Unsuccess Insert Alert !!");
                }
            }
        
        }
        public void LoadCategory()
        {
            DataTable dt = category.GetCategory();
            if (dt.Rows.Count>0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)

                {
                    dataGridView1.Rows.Add();

                    dataGridView1.Rows[i].Cells["col_id"].Value = dt.Rows[i]["room_category_id"].ToString();
                    dataGridView1.Rows[i].Cells["col_category"].Value = dt.Rows[i]["category_name"].ToString();
                    dataGridView1.Rows[i].Cells["col_description"].Value = dt.Rows[i]["description"].ToString();

                    dataGridView1.Rows[i].Cells["col_bed_no"].Value = dt.Rows[i]["no_of_bed"].ToString();
                 }
            }
        }
        int room_category_id;
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count>0)
            {
                room_category_id = (Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_id"].Value));
                DataTable dt = category.GetCategoryById(room_category_id);
                if (dt.Rows.Count>0)
                {
                    txt_category.Text = dt.Rows[0]["category_name"].ToString();
                   // txt_price.Text = dt.Rows[0]["category_price"].ToString();
                    txt_beds.Text = dt.Rows[0]["no_of_bed"].ToString();
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
            int update = category.UpdateCategory(room_category_id, txt_category.Text, Convert.ToInt32(txt_beds.Text), rich_description.Text);

            if (update>0)
            {
                MessageBox.Show("Updated Successfully", "Success Alert !!");
            LoadCategory();
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
            //if (dataGridView1.SelectedRows.Count>0)
            //{
            //    room_category_id = (Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_id"].Value));
            //    DataTable dt = category.GetCategoryById(room_category_id);
            //    if (dt.Rows.Count > 0)
            //    {
            //        txt_category.Text = dt.Rows[0]["category_name"].ToString();
            //       // txt_price.Text = dt.Rows[0]["category_price"].ToString();
            //        txt_beds.Text = dt.Rows[0]["no_of_bed"].ToString();
            //        rich_description.Text = dt.Rows[0]["description"].ToString();
            //    }
            //    DialogResult dig = MessageBox.Show("Are You Sure To Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (dig == DialogResult.Yes)
            //    {
            //        int delete = category.DeleteCategory((Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_id"].Value)));
            //        if (delete>0)
            //        {
            //            MessageBox.Show("Successfully Deleted", "Delete Alert !!");
            //            LoadCategory();

            //        }

            //    }

            //}
            //else
            //{
            //    MessageBox.Show("Select Row To Be Edited", "Select Data Alert !!");
            //}
            MessageBox.Show("Your Room Category cannot be delete", " Data Alert !!");

        }
        public void Clear()
        {
            txt_beds.Text = "";
            txt_category.Text = "";
            rich_description.Text = "";
        }
        private void Cleantextbox()
        {
            foreach (var c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = String.Empty;
                }
            }
        }
        private void txt_beds_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_price_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
