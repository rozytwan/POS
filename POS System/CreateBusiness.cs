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
    public partial class CreateBusiness : Form
    {
        public CreateBusiness()
        {
            InitializeComponent();
        }
        BLLUser blu = new BLLUser();
        BLL_Tax bltx = new BLL_Tax();
        string tax_value = "False";
        string service_charge = "False";
        byte[] img = null;
        ImageConverter imgCon = new ImageConverter();
        private void btncreate_Click_1(object sender, EventArgs e)
        {
            if (txtname.Text == "" || txtaddress.Text == "" || txtphone.Text == "" || txtnote.Text == "")
            {
                MessageBox.Show("You Can't Leave Text Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txt_pan_no.Text.Length != 9 && txt_pan_no.Text.Length > 0)
            {
                MessageBox.Show("Invalid Pan No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (rbtn_english.Checked)
                {
                    img = (byte[])imgCon.ConvertTo(pictureBox2.Image, typeof(byte[]));
                    int i = blu.createbusiness(txtname.Text, txtaddress.Text, txtphone.Text, txtname.Text, txtnote.Text, txtnote2.Text ?? String.Empty, rbtn_english.Text, txt_pan_no.Text,img);

                    if (i > 0)
                    {
                       
                        int blt = bltx.insert_into_tax(1, tax_value, Convert.ToDecimal(txt_tax.Text), service_charge, Convert.ToDecimal(txt_service_charge.Text));
                        MessageBox.Show("Business Has Been Create Successfully", "Create", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        second_user_interface pur = new second_user_interface(null);
                        pur.Show();
                        this.Hide();
                    }
                }
                else if (rbtn_arabic.Checked)
                {
                    img = (byte[])imgCon.ConvertTo(pictureBox2.Image, typeof(byte[]));
                    int i = blu.createbusiness(txtname.Text, txtaddress.Text, txtphone.Text, txtname.Text, txtnote.Text, txtnote2.Text ?? String.Empty, rbtn_arabic.Text, txt_pan_no.Text,img);

                    if (i > 0)
                    {
                        int blt = bltx.insert_into_tax(1, tax_value, Convert.ToDecimal(txt_tax.Text), service_charge, Convert.ToDecimal(txt_service_charge.Text));
                        MessageBox.Show("Business Has Been Create Sucessfully", "Create", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        second_user_interface pur = new second_user_interface(null);
                        pur.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void txtname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();

                }
            }
        }

        private void txtaddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();

                }
            }
        }

        private void txtphone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();

                }
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void btnupload_Click(object sender, EventArgs e)
        //{
        //    string name = txtname.Text;
        //    OpenFileDialog openFileDialog1 = new OpenFileDialog();
        //    openFileDialog1.InitialDirectory = "c:\\Program File";
        //    openFileDialog1.Filter = "All files (*.*)|*.*";
        //    openFileDialog1.FilterIndex = 1;
        //    openFileDialog1.RestoreDirectory = true;


        //    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        //    {
        //        try
        //        {
        //            string subpath = "C:\\Pictures\\Image";
        //            bool exists = System.IO.Directory.Exists(subpath);
        //            if (!exists)
        //            {
        //                System.IO.Directory.CreateDirectory("C:\\Pictures\\Image");
        //                string path = "C:\\Pictures";
        //                if (txtname.Text.Length > 0)
        //                 {
        //                    System.IO.File.Copy(openFileDialog1.FileName, path + "\\Image\\" + name);
        //                }
        //                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        //                pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
        //            }
        //            else
        //            {
        //                string path = "C:\\Pictures";
        //                if (txtname.Text.Length > 0)
        //                {
        //                    System.IO.File.Copy(openFileDialog1.FileName, path + "\\Image\\" + name);
        //                }
        //                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        //                pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);

        //            }
        //        }
        //        catch ( Exception)
        //        {
        //            MessageBox.Show("Cant Upload Picture Please Check You Path");
        //        }
        //        }
           
        //}

        private void CreateBusiness_Load(object sender, EventArgs e)
        {
            txt_tax.Hide();
            txt_service_charge.Hide();
        }
      
        private void sbtn_tax_ValueChanged(object sender, EventArgs e)
        {
            if (sbtn_tax.Value == true)
            {
                txt_tax.Show();
                tax_value = "True";
                lbl_tax.Show();
            }
            else
            {
                txt_tax.Hide();
                tax_value = "False";
                lbl_tax.Hide();
            }
        }

        private void sbtn_service_charge_ValueChanged(object sender, EventArgs e)
        {
            if (sbtn_service_charge.Value == true)
            {
                txt_service_charge.Show();
                service_charge = "True";
                lbl_service_charge.Show();
            }
            else
            {
                txt_service_charge.Hide();
                service_charge = "False";
                lbl_service_charge.Hide();
            }
        }

        private void txt_tax_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_service_charge_KeyPress(object sender, KeyPressEventArgs e)
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
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        private void btn_upload_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "c:\\Program File";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            pictureBox2.Controls.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {             
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
                     
                   
                }
            }
    }
}
