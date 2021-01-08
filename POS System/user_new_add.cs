
using BLLS;
using DocumentFormat.OpenXml.CustomProperties;
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
    public partial class user : UserControl
    {
        public user()
        {
            InitializeComponent();
        }

        BLLUser blluser = new BLLUser();
        string gender;
        int user_id;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\POS\\User Image\\";
        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        private void btn_selectimage_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.InitialDirectory = "c:\\Program File";
                openFileDialog1.Filter = "All files(*.*)|*.*";
                //openFileDialog1.FilterIndex = 1;
                //openFileDialog1.RestoreDirectory = true;
                //pictureBox1.Controls.Clear();
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    string extension = System.IO.Path.GetExtension(openFileDialog1.SafeFileName);

                    if (!Directory.Exists(path))
                    {
                        System.IO.Directory.CreateDirectory(path);
                        if (btn_update.Enabled != true)
                        {
                            if (txt_firstname.Text != "")
                            {
                                System.IO.File.Copy(openFileDialog1.FileName, path + txt_firstname.Text);
                                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                            }
                            else
                            {
                                MessageBox.Show("Please Type The Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            DataTable dtb = blluser.getuser_imagenamebyuser_id(user_id);
                            string user_image = dtb.Rows[0]["user_image"].ToString();
                            if (user_image.Length > 0)
                            {
                                System.IO.File.Delete(user_image);
                                System.IO.File.Copy(openFileDialog1.FileName, path + txt_firstname.Text);
                                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                            }
                        }

                    }
                    else
                    {
                        if (btn_update.Enabled != true)
                        {
                            if (txt_firstname.Text != "")
                            {
                                System.IO.File.Copy(openFileDialog1.FileName, path + txt_firstname.Text);
                                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                            }
                            else
                            {
                                MessageBox.Show("Please Type The Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            DataTable dtb = blluser.getuser_imagenamebyuser_id(user_id);
                            if (dtb.Rows.Count > 0)
                            {

                                string user_image = dtb.Rows[0]["user_image"].ToString();
                                var sm = File.Exists(user_image);
                                if (sm == true)
                                {
                                    pictureBox1.Controls.Clear();
                                    pictureBox1.Image.Dispose();
                                    System.IO.File.Delete(user_image);
                                    System.IO.File.Copy(openFileDialog1.FileName, path + txt_firstname.Text);
                                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                                }
                                else
                                {
                                  //  System.IO.File.Delete(user_image);
                                    System.IO.File.Copy(openFileDialog1.FileName, path + txt_firstname.Text);
                                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                                }
                            }
                        }
                    }
                }
                txt_location.Text = (path + txt_firstname.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int save_user;
        private void btn_save_Click(object sender, EventArgs e)
        {
            byte[] img = null;
            ImageConverter imgCon = new ImageConverter();
            img = (byte[])imgCon.ConvertTo(pictureBox1.Image, typeof(byte[]));

            string extension = System.IO.Path.GetExtension(openFileDialog1.SafeFileName);
            if (txt_firstname.Text == "" || txt_lastname.Text == "" || txt_password.Text == "" || txt_confirmpassword.Text == "" || cbo_user_type.Text == "")
            {
                    MessageBox.Show("Please Fill The Required Fields","Fields Required",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    
            }
            else
            {
                if (txt_password.Text != txt_confirmpassword.Text)
                {
                    MessageBox.Show("Password Mismatch","Password Mismatch",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (pictureBox1.Image != null)
                    {
                        save_user = blluser.saveusers(txt_username.Text, txt_password.Text, cbo_user_type.Text, txt_email.Text, txt_firstname.Text, txt_lastname.Text, gender, Convert.ToDateTime(dtp_dob.Text), txt_phonenumber.Text, txt_pin.Text, Convert.ToDateTime(dtp_dateofjoining.Text), txt_addressline1.Text, txt_addressline2.Text, txt_city.Text, txt_state.Text, txt_zipcode.Text, txt_location.Text);
                    }
                    else
                    {
                        save_user = blluser.saveusers(txt_username.Text, txt_password.Text, cbo_user_type.Text, txt_email.Text, txt_firstname.Text, txt_lastname.Text, gender, Convert.ToDateTime(dtp_dob.Text), txt_phonenumber.Text, txt_pin.Text, Convert.ToDateTime(dtp_dateofjoining.Text), txt_addressline1.Text, txt_addressline2.Text, txt_city.Text, txt_state.Text, txt_zipcode.Text,"");
                    }
                    
                    if (save_user > 0)
                    {
                        MessageBox.Show("Successfully Saved","Save",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        txt_firstname.Text = "";
                        txt_lastname.Text = "";
                        txt_password.Text = "";
                        txt_phonenumber.Text = "";
                        txt_pin.Text = "";
                        txt_state.Text = "";
                        txt_username.Text = "";
                        txt_zipcode.Text = "";
                        cbo_user_type.Text = "Admin";
                        dtp_dateofjoining.Refresh();
                        dtp_dob.Refresh();
                        pictureBox1.Image = null;
                        txt_confirmpassword.Text = "";
                        txt_email.Text = "";
                        txt_city.Text = "";
                        txt_addressline1.Text = "";
                        txt_addressline2.Text = "";
                        editupdateuser.dataGridView1.Refresh();
                    }
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void user_Load(object sender, EventArgs e)
        {
            cbo_user_type.Text = "Admin";
            gender = "Male";
            btn_update.Enabled = false;
           
            user_id = EditUpdateUser.user_id;
            if (user_id > 0)
            {
                btn_save.Enabled = false;
                DataTable dt = blluser.getuserdetailsby_user_id(user_id);
                if (dt.Rows.Count > 0)
                {
                    if (user_id==1)
                    {
                        txt_username.ReadOnly = true;
                    }
                    txt_firstname.Text = dt.Rows[0]["first_name"].ToString();
                    txt_lastname.Text = dt.Rows[0]["last_name"].ToString();
                    txt_email.Text = dt.Rows[0]["e_mail"].ToString();
                    txt_password.Text = dt.Rows[0]["password"].ToString();
                    txt_confirmpassword.Text = txt_password.Text;
                    cbo_user_type.Text = dt.Rows[0]["user_type"].ToString();
                    dtp_dob.Text = dt.Rows[0]["date_of_birth"].ToString();
                    dtp_dateofjoining.Text = dt.Rows[0]["date_of_joining"].ToString();
                    txt_phonenumber.Text = dt.Rows[0]["phone_number"].ToString();
                    txt_pin.Text = dt.Rows[0]["pin"].ToString();
                    txt_state.Text = dt.Rows[0]["state"].ToString();
                    txt_username.Text = dt.Rows[0]["user_name"].ToString();
                    txt_zipcode.Text = dt.Rows[0]["zip_code"].ToString();
                    txt_city.Text = dt.Rows[0]["city"].ToString();
                    txt_addressline1.Text = dt.Rows[0]["address_line_1"].ToString();
                    txt_addressline2.Text = dt.Rows[0]["address_line_2"].ToString();

                             
                    string user_image = dt.Rows[0]["user_image"].ToString();
                    if (user_image.Length > 0)
                    {
                        var sm = File.Exists(user_image);
                        if (sm==true)
                        {
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                            pictureBox1.Image = Image.FromFile(user_image);
                        }
                    }
               
                }
            }

        }

        private void rb_male_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_male.Checked)
            {
                gender = "Male";
            }
        }

        private void rb_female_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_female.Checked)
            {
                gender = "Female";
            }
        }

        private void rb_other_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_other.Checked)
            {
                gender = "Other";
            }
        }

        private void txt_firstname_Leave(object sender, EventArgs e)
        {
            txt_username.Text = txt_firstname.Text;
        }

        private void cbo_user_type_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txt_confirmpassword_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        EditUpdateUser editupdateuser = new EditUpdateUser();
        private void btn_update_Click(object sender, EventArgs e)
        {
            byte[] img = null;
            ImageConverter imgCon = new ImageConverter();
            img = (byte[])imgCon.ConvertTo(pictureBox1.Image, typeof(byte[]));
            
          //  string image= Convert.ToBase64String(img);
            try
            {

                DataTable dtb = blluser.getuser_imagenamebyuser_id(user_id);
                if (dtb.Rows.Count > 0)
                {

                    string user_image = dtb.Rows[0]["user_image"].ToString();
                    var sm = File.Exists(path + user_image);
                    if (sm == true)
                    {
                        if (txt_firstname.Text != user_image)
                        {
                            pictureBox1.Controls.Clear();
                            pictureBox1.Image.Dispose();
                            System.IO.File.Delete(path + user_image);
                            System.IO.File.Copy(path + user_image, path + txt_firstname.Text);
                           
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                            pictureBox1.Image = Image.FromFile(path + txt_firstname.Text);
                        }
                    }
                    txt_location.Text = (path + txt_firstname.Text);

                }
                int update_users = blluser.update_users(user_id, txt_username.Text, txt_password.Text, cbo_user_type.Text, txt_email.Text, txt_firstname.Text, txt_lastname.Text, gender, Convert.ToDateTime(dtp_dob.Text), txt_phonenumber.Text, txt_pin.Text, Convert.ToDateTime(dtp_dateofjoining.Text), txt_addressline1.Text, txt_addressline2.Text, txt_city.Text, txt_state.Text, txt_zipcode.Text,txt_location.Text);
                if (update_users > 0)
                {

                    MessageBox.Show("Successfully Updated", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearallTextbox(this);
                    pictureBox1.Image = null;
                    editupdateuser.Show();
                    user_id = 0;

                    panel1.Controls.Clear();
                    panel1.Controls.Add(editupdateuser);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }

        public void ClearallTextbox(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();

                else
                    ClearallTextbox(c);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       

        private void btn_back_Click_1(object sender, EventArgs e)
        {
            EditUpdateUser editupdateuser = new EditUpdateUser();
            Control ctls = this.Parent;
            ctls.Controls.Clear();
            ctls.Controls.Add(editupdateuser);
        }
    }
}
