
using BLLS;
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

namespace POS
{
    public partial class CV : Form
    {
        public CV()
        {
            InitializeComponent();
        }

        BLLUser blluser = new BLLUser();
        int user_id;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS " + "\\User Image\\";
        private void CV_Load(object sender, EventArgs e)
        {
            user_id = EditUpdateUser.user_id;
            if (user_id > 0)
            {
                DataTable dt = blluser.getuserdetailsby_user_id(user_id);
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        txt_firstname.Text = dt.Rows[0]["first_name"].ToString();
                        txt_lastname.Text = dt.Rows[0]["last_name"].ToString();
                        txt_gender.Text = dt.Rows[0]["gender"].ToString();
                        txt_dob.Text = dt.Rows[0]["date_of_birth"].ToString();
                        txt_dateofjoining.Text = dt.Rows[0]["date_of_joining"].ToString();
                        txt_addressline1.Text = dt.Rows[0]["address_line_1"].ToString();
                        txt_addressline2.Text = dt.Rows[0]["address_line_2"].ToString();
                        txt_phonenumber.Text = dt.Rows[0]["phone_number"].ToString();
                        txt_state.Text = dt.Rows[0]["state"].ToString();
                        txt_zipcode.Text = dt.Rows[0]["zip_code"].ToString();
                        txt_city.Text = dt.Rows[0]["city"].ToString();

                       
                        string user_image = dt.Rows[0]["user_image"].ToString();
                        if (user_image.Length > 0)
                        {
                            if (File.Exists(path + user_image))
                            {
                                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                                pictureBox1.Image = Image.FromFile(path + user_image);
                            }
                        }
                        else
                        {
                            pictureBox1.Image = null;
                        }
                    }
                }
            }
        }

        private void txt_addressline2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
        }
    }
}
