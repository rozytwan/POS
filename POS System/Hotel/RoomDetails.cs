using BLLS.BLLHotel;
using BLLS.Hotel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_System
{
    public partial class RoomDetails : UserControl
    {
        public RoomDetails()
        {
            InitializeComponent();
        }
        BLL_HotelCategory hotel = new BLL_HotelCategory();
        BLLHotelRoom blhr = new BLLHotelRoom();
        int room_id;
        public string image_id;
        private void RoomDetails_Load(object sender, EventArgs e)
        {

            LoadCategory();
            LoadPackage();
            LoadDataGridView();
            cmb_status.SelectedIndex = 0;
           // cmb_complementry.SelectedIndex = 0;
           panelDescription.Hide();

            //cmb_category.SelectedIndex = 0;
        }
        public void LoadCategory()
        {
            DataTable dt = hotel.GetCategory();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["category_name"] = "Choose Category";
                dt.Rows.InsertAt(dr, 0);
                cmb_category.DataSource = dt;
                cmb_category.DisplayMember = "category_name";
                cmb_category.ValueMember = "room_category_id";
            }
            btn_save.Visible = true;
            btn_update.Visible = false;
        }
        public void LoadPackage()
        {
            //DataTable dt = hotel.GetRoomPackage();
            //if (dt.Rows.Count > 0)
            //{
            //    DataRow dr = dt.NewRow();
            //    dr["package_name"] = "Choose Package";
            //    dt.Rows.InsertAt(dr, 0);
            //    cmb_package.DataSource = dt;
            //    cmb_package.DisplayMember = "package_name";
            //    cmb_package.ValueMember = "package_id";
            //}
          
        }
        public void LoadDataGridView()
        {
            DataTable dt = hotel.GetRoomDetails();
            {
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["col_id"].Value = dt.Rows[i]["room_id"].ToString();
                        int room_category_id = Convert.ToInt32(dt.Rows[i]["room_category_id"].ToString());
                     
                        DataTable dt1 = hotel.GetCategoryById(room_category_id);
                      
                        if (dt1.Rows.Count > 0)
                        {
                            dataGridView1.Rows[i].Cells["col_category"].Value = dt1.Rows[0]["category_name"].ToString();
                        }
                     
                        dataGridView1.Rows[i].Cells["col_room_no"].Value = dt.Rows[i]["room_no"].ToString();
                        dataGridView1.Rows[i].Cells["col_room_price"].Value = dt.Rows[i]["price"].ToString();
                        dataGridView1.Rows[i].Cells["col_status"].Value = dt.Rows[i]["status"].ToString();

                    }
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            byte[] img = null;
            ImageConverter imgCon = new ImageConverter();
            img = (byte[])imgCon.ConvertTo(userpicbox.Image, typeof(byte[]));
            if (cmb_category.Text == "Choose Category" || txt_price.Text == "" || txt_room_no.Text == "" || cmb_status.Text == "Choose Status" || cmb_status.Text == "")
            {
                MessageBox.Show("Room Details Not Completed", "Room Details Alert !!");
            }
            else
            {
               int insert_room = hotel.Insert_Room(Convert.ToInt32(cmb_category.SelectedValue),(txt_room_no.Text), Convert.ToDecimal(txt_price.Text), cmb_status.Text, img);
                if (insert_room > 0)
                {
                    MessageBox.Show("Successfully Inserted", "Success Alert !!");
                    LoadDataGridView();
                    clear();
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                lbl_room_id.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["col_id"].Value);
                int room_id = Convert.ToInt32(lbl_room_id.Text);
                cmb_category.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["col_category"].Value);
                txt_price.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["col_room_price"].Value);
                txt_room_no.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["col_room_no"].Value);
                cmb_status.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["col_status"].Value);
           
                    DataTable dt = hotel.GetRoomNo(room_id);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["image"].ToString() != "")
                    {
                        Byte[] image = (byte[])dt.Rows[0]["image"];
                        if (image != null)
                        {
                            MemoryStream msstream = new MemoryStream(image);
                            userpicbox.Image = System.Drawing.Image.FromStream(msstream);
                        }
                    }
                    else
                    {
                        userpicbox.Image = global::POS_System.Properties.Resources.hotel;
                    }
                    
                }
                btn_save.Visible = false;
                btn_update.Visible = true;
            }
            else
            {
                MessageBox.Show("Select The Row Update", "Select Row A lerts !!");
            }
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (cmb_category.Text == "Choose Category" || txt_price.Text == "" || txt_room_no.Text == "" || cmb_status.Text == "Choose Status" || cmb_status.Text == "")
            {
                MessageBox.Show("Room Details Not Completed", "Room Details Alert !!");
            }
            else
            { 
                byte[] img = null;
                ImageConverter imgCon = new ImageConverter();
                img = (byte[])imgCon.ConvertTo(userpicbox.Image, typeof(byte[]));
                room_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_id"].Value);
                int update_room = hotel.Update_Room(room_id, Convert.ToInt32(cmb_category.SelectedValue), txt_room_no.Text, Convert.ToDecimal(txt_price.Text), cmb_status.Text, img);
                if (update_room > 0)
                {
                    MessageBox.Show("Successfully Updated", "Success Alert !!");
                    LoadDataGridView();
                    clear();
                
                    // image_id = "";
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        public void clear()
        {
            txt_room_no.Text = "";
            cmb_status.Text = "Choose Status";
          txt_price.Text = "";
            txt_richbox.Text = "";
            cmb_category.SelectedIndex = 0;
            //userpicbox.Image = Properties.Resources.url;
            // cmb_category.SelectedIndex = 0;
        }


        private void btn_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            ofg.Title = "Choose Image File";


            if (ofg.ShowDialog() == DialogResult.OK)
            {
                txt_location.Text = ofg.FileName;
                userpicbox.ImageLocation = ofg.FileName;

            }
            else
            {
                MessageBox.Show("image not selected");
            }
        }
        
        string imgpath;
       
        private void btn_delete_Click_1(object sender, EventArgs e)
        {
            room_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_id"].Value);
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataTable dt = hotel.GetBookingId(room_id);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Room Booked Cannot Delete", "Booked Room Alert !!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    DialogResult dig = MessageBox.Show("Are You Sure To Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dig == DialogResult.Yes)
                    {
                        int delete_room = hotel.DeleteRoom(room_id);
                        if (delete_room > 0)
                        {
                            MessageBox.Show("Successfully Deleted", "Success Alert !!");
                            LoadDataGridView();
                            clear();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Select The Row Update", "Select Row Alerts !!");
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == dataGridView1.Columns["col_add"].Index && e.RowIndex >= 0))
            {
                btn_save.Hide();
                room_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_id"].Value);
                cmb_category.Text = dataGridView1.CurrentRow.Cells["col_category"].Value.ToString();
                txt_room_no.Text = dataGridView1.CurrentRow.Cells["col_category"].Value.ToString();
                txt_price.Text = dataGridView1.CurrentRow.Cells["col_category"].Value.ToString();
                cmb_status.Text = dataGridView1.CurrentRow.Cells["col_category"].Value.ToString();
                DataTable dt = hotel.GetRoomNo(room_id);
                if (dt.Rows.Count > 0)
                {
                    Byte[] image = (byte[])dt.Rows[0]["image"];
                    if (image != null)
                    {

                        MemoryStream msstream = new MemoryStream(image);
                        userpicbox.Image = System.Drawing.Image.FromStream(msstream);

                    }
                    else
                    {
                        userpicbox.Image = global::POS_System.Properties.Resources.hotel;
                    }
                }

                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

                if (open.ShowDialog() == DialogResult.OK)
                {
                    userpicbox.Image = new Bitmap(open.FileName);
                    imgpath = open.FileName;
                   panelDescription.Show();
                  
                }
            }
        }
  
private void btn_oks_Click(object sender, EventArgs e)
        {
            int insert = hotel.Insert_RoomImage(room_id, imgpath, txt_richbox.Text);
            if (insert > 0)
            {
                MessageBox.Show("Successfully Inserted !!", "Insert Alert !!");
                panelDescription.Hide();
                clear();
            }
    }

        private void txt_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
    
    

