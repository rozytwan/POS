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

namespace POS_System
{
    public partial class Edit_Rest_details : Form
    {
        public Edit_Rest_details()
        {
            InitializeComponent();
        }
        BLLUser blods = new BLLUser();
        BLL_Tax blt = new BLL_Tax();
        string tax_value="False";
        string service_charge="False";
        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtaddress.Text == "" || txtname.Text == "" || txtphone.Text == ""||txtnote.Text=="")
            {
                MessageBox.Show("You Can't Leave Text Empty");
            }
            else if (txt_pan_no.Text.Length != 9 && txt_pan_no.Text.Length > 0)
            {
                MessageBox.Show("Invalid Pan No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int business_id = 1;
                int i = blods.updatebusiness(txtname.Text, txtaddress.Text, txtphone.Text, business_id,txtnote.Text,txtnote2.Text ?? String.Empty,txt_pan_no.Text);
                if (i > 0)
                {
                    DataTable dt = blt.get_all_tax_data();
                    if (dt.Rows.Count > 0)
                    {
                        int insert = blt.update_table_tax(1, tax_value, Convert.ToDecimal(txt_tax.Text), service_charge, Convert.ToDecimal(txt_service_charge.Text));

                    }
                    else
                    {
                        int bltax = blt.insert_into_tax(1, tax_value, Convert.ToDecimal(txt_tax.Text), service_charge, Convert.ToDecimal(txt_service_charge.Text));
                    }
                    
                    MessageBox.Show("Bussiness Has Been Edit");
                    this.Hide();
                }
            }
        }

        private void Edit_Rest_details_Load(object sender, EventArgs e)
        {
            DataTable dt = blods.checkbusiness();
            if (dt.Rows.Count > 0)
            {
                txtname.Text = dt.Rows[0]["business_name"].ToString();
                txtaddress.Text = dt.Rows[0]["address"].ToString();
                txtphone.Text = dt.Rows[0]["phone_no"].ToString();
                txtnote.Text = dt.Rows[0]["note_1"].ToString();
                txtnote2.Text = (dt.Rows[0]["note_2"] ?? String.Empty).ToString();
                txt_pan_no.Text = dt.Rows[0]["pan_no"].ToString();
                //if (dt.Rows[0]["blogo"] != null)
                //{
                //    Byte[] imge_byte = (byte[])dt.Rows[0]["blogo"];
                //    var stream = new MemoryStream(imge_byte);
                //    if (stream.Length > 0)
                //    {
                //        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                //        pictureBox2.Image = System.Drawing.Image.FromStream(stream);
                //    }
                //}
                tax_load();
            }

        }
        public void tax_load()
        {
            DataTable dt = blt.get_all_tax_data();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["tax_value"].ToString() == "True")
                {
                    sbtn_tax.Value = true;
                    txt_tax.Text = dt.Rows[0]["tax_amount"].ToString();
                }
                if (dt.Rows[0]["service_charge_value"].ToString() == "True")
                {
                    sbtn_service_charge.Value = true;
                    txt_service_charge.Text = dt.Rows[0]["service_charge_amount"].ToString();
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

