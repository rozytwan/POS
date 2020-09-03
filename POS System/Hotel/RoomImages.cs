using BLLS.BLLHotel;
using BLLS.Hotel;
using DocumentFormat.OpenXml.Drawing;
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

namespace POS_System.Hotel
{
    public partial class RoomImages : UserControl
    {
        public RoomImages()
        {
            InitializeComponent();
        }
        public string room_id;
        BLL_HotelCategory blhotel = new BLL_HotelCategory();
        BLLHotelRoom blhr = new BLLHotelRoom();
        private void RoomImages_Load(object sender, EventArgs e)
        {
            panel2.Hide();
            LoadImages();
            
            pictureBox1.Click += new System.EventHandler(this.pictureBox1_click);
        }
        string image_name;
        public int i = 0;
        DataTable dt = new DataTable();

        public void LoadImages()
        {
            dt = blhr.GetAllRoom(room_id);
            if (dt.Rows.Count > 0)
            {
                if (i <= -1)
                {
                    MessageBox.Show("No Previous image");
                }
                else
                {
                    if (dt.Rows.Count > i)
                    {
                        GetPictureboxImage();
                    }
                    else
                    {
                        i = 0;
                        GetPictureboxImage();
                    }
                }
            }

        }
        
        public System.Windows.Forms.FormWindowState WindowState { get; set; }
        private void pictureBox1_click(object sender, EventArgs e)
        {
            //pictureBox1.Size = new Size(pictureBox1.Width, Height - (Height * 5 / 100));
            //pheight = pictureBox1.Height;
            //pwidth = pictureBox1.Width;
            //FileStream stream = new FileStream("image_name", FileMode.Open, FileAccess.Read);
            //pictureBox1.Image = Image.FromStream(stream);
            //stream.Close();
          
            System.Drawing.Image img = System.Drawing.Image.FromFile(image_name);
            MessageBox.Show("Width: " + img.Width + ", Height: " + img.Height);
            Size size = new Size(img.Width, img.Height);
            float height = SystemInformation.VirtualScreen.Height;
            float width = SystemInformation.VirtualScreen.Width;
            pictureBox1.Size = size;
            pictureBox1.Size = new System.Drawing.Size(img.Width, img.Height);
            var image = System.Drawing.Image.FromFile(image_name);
            pictureBox1.Image = img;
        
          


            // System.Drawing.Image img = System.Drawing.Image.FromFile(image_name);
            //// String imagepath =image_name;
            // pictureBox1.BorderStyle = BorderStyle.None;
            // //pictureBox1.Dock = DockSytle.None;
            // pictureBox1.Width = this.Width;
            // pictureBox1.Height = this.Height;
            // pictureBox1.Left = SystemInformation.VirtualScreen.Width;
            // pictureBox1.Top = SystemInformation.VirtualScreen.Height;
            // WindowState = FormWindowState.Maximized;
            // pictureBox1.Image = img;
         //   WindowState = FormWindowState.Maximized;
            


        }

        private static System.Drawing.Image ScaleImage(System.Drawing.Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);
            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);
            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight); return newImage;
        }
        public void GetPictureboxImage()
        {
            image_name = dt.Rows[i]["room_image"].ToString();
            lbl_location.Text = image_name;
            lbl_description.Text = dt.Rows[i]["description"].ToString();
            label7.Text = lbl_description.Text;
            lbl_id.Text = dt.Rows[i]["image_id"].ToString();

            if (image_name.Length > 0)
            {
                if (File.Exists(image_name))// Just to check if path is valid
                {
                    var image = System.Drawing.Image.FromFile(image_name);
                    //pictureBox1.Size = new System.Drawing.Size(300, 300);
                    pictureBox1.BackgroundImage = ScaleImage(image, 707, 366);
                    pictureBox1.Image = image;
             
                }
            }
        }
        private void btn_next_Click(object sender, EventArgs e)
        {
            i = i + 1;
            LoadImages();
        }

        private void btn_previous_Click(object sender, EventArgs e)
        {

            i = i - 1;
            LoadImages();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            userpicbox.Image = pictureBox1.Image;
            txt_location.Text = lbl_location.Text;
            txt_richbox.Text = lbl_description.Text;
            panel2.Show();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (lbl_id.Text != "")
            {
                DialogResult dig = MessageBox.Show("Do You Like To Delete Table ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dig == DialogResult.Yes)
                {
                    int delete_image = blhr.DeleteImage(lbl_id.Text);
                    if (delete_image > 0)
                    {
                        MessageBox.Show("Successfully Deleted !!", "Success Alert !!");

                    }

                }
            }
        }
        public void clear()
        {
            txt_location.Text = "";
            txt_richbox.Text = "";

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            int update = blhotel.UpdateImage(lbl_id.Text, lbl_location.Text, lbl_description.Text);
            if (update > 0)
            {
                MessageBox.Show("Successfully Updated !!", "Update Alert !!");
                clear();
                panel2.Hide();
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }
    }
}
    

