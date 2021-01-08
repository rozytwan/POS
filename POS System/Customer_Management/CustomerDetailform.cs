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
using BLLS;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Reflection;

namespace POS_System
{
    public partial class CustomerDetailform : UserControl
    {
        public CustomerDetailform( string statusCode)
        {
            InitializeComponent();
            status_code = statusCode;
        }
        string status_code;
        blllCustomerDetailednyo custor = new blllCustomerDetailednyo();


        private void CustomerDetailform_Load(object sender, EventArgs e)
        {

            //  txt_location.Text = " ";
            Combocardtype();
            btn_update.Enabled = false;
            rdo_male.Checked = true;
            rbn_less.Checked = true;
            lstview_customers.View = View.Details;
            lstview_customers.Columns.Add("Customer Lists", 200);
            lstview_customers.Items.Clear();
            loadimages();
           // RecentlyaddedCustomers();
            checkiftheshowdialouge();
            cbo_card_status.SelectedIndex = 0;

            userpicbox.Image = Properties.Resources.url;

        }
        public void checkiftheshowdialouge()
        {


        }
        public void Combocardtype()
        {
            DataTable dt = custor.GetCardType();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["card_type_name"] = "Choose Type";
                dt.Rows.InsertAt(dr, 0);
                txt_card_type.DataSource = dt;
                txt_card_type.DisplayMember = "card_type_name";
                txt_card_type.ValueMember = "card_type_id";
            }
        }

        private void lstview_customers_MouseClick(object sender, MouseEventArgs e)
        {

            btn_update.Enabled = true;
            String selected = lstview_customers.SelectedItems[0].SubItems[0].Text;
            int MyKey = Convert.ToInt32(this.lstview_customers.SelectedItems[0].Name);
            // MessageBox.Show(selected + " " + MyKey);

            DataTable receiveDatabyId = custor.getDataByitsId(MyKey);
            if (receiveDatabyId.Rows.Count > 0)
            {
                lbl_cutomerIdget.Text = receiveDatabyId.Rows[0]["id"].ToString();
                txt_name.Text = receiveDatabyId.Rows[0]["name"].ToString();
                txt_lastname.Text = receiveDatabyId.Rows[0]["lastname"].ToString();
                dtp_dob.Text = receiveDatabyId.Rows[0]["birthdate"].ToString();

                string maleorfelmalecheck = receiveDatabyId.Rows[0]["gender"].ToString();
                if (maleorfelmalecheck == "male")
                {
                    rdo_male.Checked = true;
                }
                else
                {
                    rdo_female.Checked = true;
                }
                string highlow = receiveDatabyId.Rows[0]["nationid"].ToString();
                if (highlow == "High")
                {
                    rbn_high.Checked = true;
                }
                else
                {
                    rbn_less.Checked = true;
                }
                txt_phone.Text = receiveDatabyId.Rows[0]["phone"].ToString();
                txtpan_no.Text = receiveDatabyId.Rows[0]["phone2"].ToString();
                txt_city.Text = receiveDatabyId.Rows[0]["city"].ToString();
                txt_country.Text = receiveDatabyId.Rows[0]["country"].ToString();
                txt_nationality.Text = receiveDatabyId.Rows[0]["nationality"].ToString();
                txt_nationalityidno.Text = receiveDatabyId.Rows[0]["nationid"].ToString();
                txt_email.Text = receiveDatabyId.Rows[0]["email"].ToString();
                txt_address.Text = receiveDatabyId.Rows[0]["address"].ToString();
                txt_card_no.Text = receiveDatabyId.Rows[0]["card_no"].ToString();
                txt_card_type.Text = receiveDatabyId.Rows[0]["card_type"].ToString();
                cbo_card_status.Text = receiveDatabyId.Rows[0]["status"].ToString();

                Byte[] image = (byte[])receiveDatabyId.Rows[0]["image"];
                if (image == null)
                {
                    userpicbox.Image = null;
                }
                else
                {
                    MemoryStream msstream = new MemoryStream(image);
                    userpicbox.Image = System.Drawing.Image.FromStream(msstream);

                }
              
            }
            btn_save.Visible = false;

        }
        HomeDeliveryModel hdm = new HomeDeliveryModel();
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (btn_save.Text == "Save")
            {
                if (txt_name.Text == "" || txt_lastname.Text == "" )
                {

                    MessageBox.Show("Name and Phone Number are Reuquired.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else if (txt_phone.Text == "")
                {
                    MessageBox.Show("Contact Number is required");
                    
                }
                
             
                else
                {
                    DataTable dt1 = custor.Getcustomerphone(txt_phone.Text);
                    if (dt1.Rows.Count > 0)
                    {
                        MessageBox.Show("Phone number is already exist", "Duplicate Phone no!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {

                        if (txt_card_no.Text.Length > 0 && txt_card_no.Text != "")
                        {
                            DataTable dt = custor.getnamebyno(txt_card_no.Text);
                            if (dt.Rows.Count != 0)
                            {
                                MessageBox.Show("Already created");

                            }
                            else
                            {
                                if (txt_card_type.Text != "" && txt_card_type.Text != "Choose Type")
                                {
                                    customerInsert();
                                }
                            }
                        }
                        else
                        {

                            customerInsert();

                        }


                    }
                }
            }

          
        }
    
        
    

        public void customerInsert()
        {
            byte[] img = null;
            ImageConverter imgCon = new ImageConverter();
            img = (byte[])imgCon.ConvertTo(userpicbox.Image, typeof(byte[]));
           
                string malefemale = null;
                if (rdo_male.Checked)
                {
                    malefemale = "Male";
                }
                else
                {
                    malefemale = "Female";
                }
            string highlow = null;
            if (rbn_high.Checked)
            {
                highlow = "High";
            }
            else
            {
                highlow = "Less";
            }
            int insertinto = custor.insertintotables(img, txt_name.Text, txt_lastname.Text, Convert.ToDateTime(dtp_dob.Text), malefemale, txt_address.Text, txt_phone.Text, txtpan_no.Text, txt_city.Text, txt_country.Text, txt_nationality.Text, highlow, txt_email.Text,cbo_card_status.Text, txt_card_no.Text, txt_card_type.Text);
                if (insertinto > 0)
                {
                    MessageBox.Show("Customer Has Been Saved");
                    Reload();
                    lstview_customers.Items.Clear();                 
                    loadimages();
                    userpicbox.Image = Properties.Resources.url;
                if(status_code== "HD")
                {
                    DataTable dt = custor.GetCustomerInsertedId();
                    if (dt.Rows.Count > 0)
                    {
                        HomeDeliveryModel.customer_id = Convert.ToInt32(dt.Rows[0][0]);
                    }

                    Control ctl = this.Parent;
                    KOTOrder cpf = new KOTOrder("520",null);
                    ctl.Controls.Clear();
                    ctl.Controls.Add(cpf);

                }
           }
        
        }
        public void Reload()
        {
            txt_name.Text = "";
            txt_lastname.Text = "";
            txt_phone.Text = "";
            txtpan_no.Text = "";
            txt_city.Text = "";
            txt_country.Text = "";
            txt_nationality.Text = "";
            txt_nationalityidno.Text = "";
            txt_email.Text = "";
            txt_address.Text = "";
            txt_card_type.Text = "";
            txt_card_no.Text = "";


        }
        int total_customer_tunining;
        public void loadimages()
        {

            DataTable dtimage = custor.getallcustomers();
            if (dtimage.Rows.Count > 0)
            {
                lstview_customers.Items.Clear();

                ImageList imgs = new ImageList();
                imgs.ImageSize = new Size(75, 75);


                lstview_customers.SmallImageList = imgs;
                if (dtimage.Rows.Count > 30)
                {
                    total_customer_tunining = 30;
                }
                else
                {
                    total_customer_tunining = dtimage.Rows.Count;
                }
                for (int i = 0; i < total_customer_tunining; i++)
                {
                    Byte[] byteBLOBData = (byte[])dtimage.Rows[i]["image"];
                    MemoryStream stream = new MemoryStream(byteBLOBData);
                    Image userimg = Image.FromStream(stream);
                    imgs.Images.Add(userimg);


                    ListViewItem lsvparent = new ListViewItem();
                    String username = dtimage.Rows[i]["name"].ToString();
                    String lastname = dtimage.Rows[i]["lastname"].ToString();
                    String unique_id = dtimage.Rows[i]["id"].ToString();
                    lstview_customers.Items.Add(unique_id, "    " + username + " " + lastname, imgs.Images.Count - 1);
                }

                Byte[] image = (byte[])dtimage.Rows[0]["image"];
                if (image == null)
                {
                    userpicbox.Image = null;
                }
                else
                {
                    MemoryStream msstream = new MemoryStream(image);
                    userpicbox.Image = System.Drawing.Image.FromStream(msstream);

                }
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
        private void btn_go_Click(object sender, EventArgs e)
        {
            if (txt_namesearch.Text == "")
            {
                MessageBox.Show("Input the Seach Fieds..");
                loadimages();
            }
       
            {
                lstview_customers.Items.Clear();
                DataTable searchdata = custor.search_By_Fullname(txt_namesearch.Text);
                if (searchdata.Rows.Count > 0)
                {

                    ImageList imgs = new ImageList();
                    imgs.ImageSize = new Size(75, 75);


                    lstview_customers.SmallImageList = imgs;
                    for (int i = 0; i < searchdata.Rows.Count; i++)
                    {
                        Byte[] byteBLOBData = (byte[])searchdata.Rows[i]["image"];
                        MemoryStream stream = new MemoryStream(byteBLOBData);
                        Image userimg = Image.FromStream(stream);
                        imgs.Images.Add(userimg);


                        ListViewItem lsvparent = new ListViewItem();
                        String username = searchdata.Rows[i]["name"].ToString();
                        String lastname = searchdata.Rows[i]["lastname"].ToString();
                        String unique_id = searchdata.Rows[i]["id"].ToString();

                        lstview_customers.Items.Add(unique_id, "    " + username + " " + lastname, imgs.Images.Count - 1);
                    }

                }
            }
            
        }

        private void txt_namesearch_TextChanged(object sender, EventArgs e)
        {
            if (txt_namesearch.Text.Length > 3)
            {
                lstview_customers.Items.Clear();
                DataTable searchdata = custor.search_By_Fullname(txt_namesearch.Text);
                if (searchdata.Rows.Count > 0)
                {
                    ImageList imgs = new ImageList();
                    imgs.ImageSize = new Size(75, 75);
                    lstview_customers.SmallImageList = imgs;
                    for (int i = 0; i < searchdata.Rows.Count; i++)
                    {
                        Byte[] byteBLOBData = (byte[])searchdata.Rows[i]["image"];
                        MemoryStream stream = new MemoryStream(byteBLOBData);
                        Image userimg = Image.FromStream(stream);
                        imgs.Images.Add(userimg);
                        ListViewItem lsvparent = new ListViewItem();
                        String username = searchdata.Rows[i]["name"].ToString();
                        String lastname = searchdata.Rows[i]["lastname"].ToString();
                        String unique_id = searchdata.Rows[i]["id"].ToString();
                       // txt_namesearch.Text = username + ' ' + lastname;
                        txt_emailsearch.Text = searchdata.Rows[i]["card_no"].ToString();
                        lstview_customers.Items.Add(unique_id, "    " + username + " " + lastname, imgs.Images.Count - 1);
                    }
                }
            }
            if (txt_namesearch.Text == "")
            {
                loadimages();
                txt_fone.Text = "";
                txt_emailsearch.Text = "";
            }
    
        
        }

        private void lstview_customers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String selected = lstview_customers.SelectedItems[0].SubItems[0].Text;
                int MyKey = Convert.ToInt32(this.lstview_customers.SelectedItems[0].Name);
                DataTable receiveDatabyId = custor.getDataByitsId(MyKey);
                if (receiveDatabyId.Rows.Count > 0)
                {

                    txt_name.Text = receiveDatabyId.Rows[0]["name"].ToString();
                    txt_lastname.Text = receiveDatabyId.Rows[0]["lastname"].ToString();
                    dtp_dob.Text = receiveDatabyId.Rows[0]["birthdate"].ToString();

                    string maleorfelmalecheck = receiveDatabyId.Rows[0]["gender"].ToString();
                    if (maleorfelmalecheck == "male")
                    {
                        rdo_male.Checked = true;
                    }
                    else
                    {
                        rdo_female.Checked = true;
                    }
                    string highlow = receiveDatabyId.Rows[0]["nationid"].ToString();
                    if (highlow == "High")
                    {
                        rbn_high.Checked = true;
                    }
                    else
                    {
                        rbn_less.Checked = true;
                    }
                    txt_phone.Text = receiveDatabyId.Rows[0]["phone"].ToString();
                    txtpan_no.Text = receiveDatabyId.Rows[0]["phone2"].ToString();
                    txt_city.Text = receiveDatabyId.Rows[0]["city"].ToString();
                    txt_country.Text = receiveDatabyId.Rows[0]["country"].ToString();
                    txt_nationality.Text = receiveDatabyId.Rows[0]["nationality"].ToString();
                    txt_nationalityidno.Text = receiveDatabyId.Rows[0]["nationid"].ToString();
                    txt_email.Text = receiveDatabyId.Rows[0]["email"].ToString();
                    txt_address.Text = receiveDatabyId.Rows[0]["address"].ToString();
                    txt_card_no.Text = receiveDatabyId.Rows[0]["card_no"].ToString();
                    txt_card_type.Text = receiveDatabyId.Rows[0]["card_type"].ToString();
                    cbo_card_status.Text = receiveDatabyId.Rows[0]["status"].ToString();

                    Byte[] image = (byte[])receiveDatabyId.Rows[0]["image"];
                    if (image == null)
                    {
                        userpicbox.Image = null;
                    }
                    else
                    {
                        MemoryStream msstream = new MemoryStream(image);
                        userpicbox.Image = System.Drawing.Image.FromStream(msstream);
                    }
                }
                btn_save.Visible = false;
            }
        }

        private void txt_fone_TextChanged(object sender, EventArgs e)
        {
            if (txt_fone.Text.Length > 0)
            {

                lstview_customers.Items.Clear();
                DataTable searchdata = custor.getDataByitsPhonenumbers(txt_fone.Text);
                if (searchdata.Rows.Count > 0)
                {

                    ImageList imgs = new ImageList();
                    imgs.ImageSize = new Size(75, 75);


                    lstview_customers.SmallImageList = imgs;
                    for (int i = 0; i < searchdata.Rows.Count; i++)
                    {
                        Byte[] byteBLOBData = (byte[])searchdata.Rows[i]["image"];
                        MemoryStream stream = new MemoryStream(byteBLOBData);
                        Image userimg = Image.FromStream(stream);
                        imgs.Images.Add(userimg);


                        ListViewItem lsvparent = new ListViewItem();
                        String username = searchdata.Rows[i]["name"].ToString();
                        String lastname = searchdata.Rows[i]["lastname"].ToString();
                        String unique_id = searchdata.Rows[i]["id"].ToString();
                        txt_namesearch.Text = username + ' ' + lastname;
                        txt_emailsearch.Text= searchdata.Rows[i]["card_no"].ToString();
                        lstview_customers.Items.Add(unique_id, "    " + username + " " + lastname, imgs.Images.Count - 1);
                    }
                }
            }
            else
            {
                loadimages();
                txt_namesearch.Text = "";
                txt_emailsearch.Text = "";
            }
        }

        private void txt_emailsearch_TextChanged(object sender, EventArgs e)
        {
            if (txt_emailsearch.Text.Length > 0)
            {

                lstview_customers.Items.Clear();
                DataTable searchdata = custor.getDataByitsemails(txt_emailsearch.Text);
                if (searchdata.Rows.Count > 0)
                {

                    ImageList imgs = new ImageList();
                    imgs.ImageSize = new Size(75, 75);


                    lstview_customers.SmallImageList = imgs;
                    for (int i = 0; i < searchdata.Rows.Count; i++)
                    {
                        Byte[] byteBLOBData = (byte[])searchdata.Rows[i]["image"];
                        MemoryStream stream = new MemoryStream(byteBLOBData);
                        Image userimg = Image.FromStream(stream);
                        imgs.Images.Add(userimg);


                        ListViewItem lsvparent = new ListViewItem();
                        String username = searchdata.Rows[i]["name"].ToString();
                        String lastname = searchdata.Rows[i]["lastname"].ToString();
                        String unique_id = searchdata.Rows[i]["id"].ToString();
                        txt_namesearch.Text = username + ' ' + lastname;
                        txt_emailsearch.Text = searchdata.Rows[i]["card_no"].ToString();
                        lstview_customers.Items.Add(unique_id, "    " + username + " " + lastname, imgs.Images.Count - 1);
                    }
                }
            }
            else
            {
                loadimages();
                txt_namesearch.Text = "";
                txt_fone.Text = "";
            }
        }

        private void btn_okay_Click(object sender, EventArgs e)
        {

            this.Hide();
        }
       

    

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txt_lastname.Text == "" || txt_name.Text == "" || txt_phone.Text == "")
            {

                MessageBox.Show("the fields cant be empty check again...");
            }


            else
            {
                DataTable dt1 = custor.Getcustomerphone(txt_phone.Text);
                if (dt1.Rows.Count > 0)
                {
                    if (lbl_cutomerIdget.Text == dt1.Rows[0]["id"].ToString())
                    {

                        UpdateCustomer();
                    }
                    else
                    {
                        MessageBox.Show("Phone number is already exist", "Duplicate Phone no!!");
                    }
                }
                else
                {


                    if (txt_card_no.Text.Length > 0 && txt_card_no.Text != "")
                    {
                        DataTable dt = custor.getnamebyno(txt_card_no.Text);

                        if (dt.Rows.Count > 0)
                        {
                            if (lbl_cutomerIdget.Text != dt.Rows[0]["id"].ToString())
                            {
                                MessageBox.Show("Already created");
                            }
                            else
                            {
                                if (txt_card_type.Text != "" && txt_card_type.Text != "Choose Type")
                                {
                                    UpdateCustomer();
                                }
                                else
                                {
                                    MessageBox.Show("Please choose card type.", "Invalid Card Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                        }
                        else
                        {
                            if (txt_card_type.Text != "" && txt_card_type.Text != "Choose Type")
                            {
                                UpdateCustomer();
                            }
                            else
                            {
                                MessageBox.Show("Please choose card type.", "Invalid Card Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                    }
                    else
                    {

                        UpdateCustomer();

                    }
                }
            }
        }
        public void UpdateCustomer()
        {
           
            string malefemale = null;
            if (rdo_male.Checked)
            {
                malefemale = "Male";
            }
            else
            {
                malefemale = "Female";
            }
            string highlow = null;
            if (rbn_high.Checked)
            {
                highlow = "High";
            }
            else
            {
                highlow = "Less";
            }
            byte[] img = null;
            ImageConverter imgCon = new ImageConverter();
            img = (byte[])imgCon.ConvertTo(userpicbox.Image, typeof(byte[]));
            string getusersIdtoupdate = lbl_cutomerIdget.Text;

            int update = custor.updateintotables(img, txt_name.Text, txt_lastname.Text, Convert.ToDateTime(dtp_dob.Text), malefemale, txt_address.Text, txt_phone.Text, txtpan_no.Text, txt_city.Text, txt_country.Text, txt_nationality.Text, highlow, txt_email.Text, getusersIdtoupdate,cbo_card_status.Text, txt_card_no.Text, txt_card_type.Text);
            if (update > 0)
            {
                MessageBox.Show("Your Customer Name " + txt_name.Text + " has been updated.", "Update Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reload();
                lstview_customers.Items.Clear();
               
                loadimages();
             
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            if (second_user_interface.BusinessType == "Parlour")
            {
                Parlour al = new Parlour();
                Control ctls = this.Parent;
                ctls.Controls.Clear();
                ctls.Controls.Add(al);
            }
            else
            {
                Control ctls = this.Parent;
                allmenu alls = new allmenu();
                ctls.Controls.Clear();
                ctls.Controls.Add(alls);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_name.Text = "";
            txt_lastname.Text = "";
            txt_phone.Text = "";
            txtpan_no.Text = "";
            txt_city.Text = "";
            txt_country.Text = "";
            txt_nationality.Text = "";
            txt_nationalityidno.Text = "";
            txt_email.Text = "";
            txt_address.Text = "";
            btn_update.Enabled = false;
            btn_save.Enabled = true;
            btn_save.Visible = true;
        }

        private void txt_phone_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_phone2_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

        }

        
        private void txt_emailsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_emailsearch.Text.Length > 0)
                {

                    lstview_customers.Items.Clear();
                    DataTable searchdata = custor.getDataByitsemails(txt_emailsearch.Text);
                    if (searchdata.Rows.Count > 0)
                    {

                        ImageList imgs = new ImageList();
                        imgs.ImageSize = new Size(75, 75);


                        lstview_customers.SmallImageList = imgs;
                        for (int i = 0; i < searchdata.Rows.Count; i++)
                        {
                            Byte[] byteBLOBData = (byte[])searchdata.Rows[i]["image"];
                            MemoryStream stream = new MemoryStream(byteBLOBData);
                            Image userimg = Image.FromStream(stream);
                            imgs.Images.Add(userimg);


                            ListViewItem lsvparent = new ListViewItem();
                            String username = searchdata.Rows[i]["name"].ToString();
                            String lastname = searchdata.Rows[i]["lastname"].ToString();
                            String unique_id = searchdata.Rows[i]["id"].ToString();

                            lstview_customers.Items.Add(unique_id, "    " + username + " " + lastname, imgs.Images.Count - 1);
                        }
                    }
                }
                else
                {
                    loadimages();
                }
            }
        }
    }
}