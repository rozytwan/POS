using BLLS;
using BLLS.BLLHotel;
using BLLS.Hotel;
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
    public partial class GetDetails : UserControl
    {
        public GetDetails()
        {
            InitializeComponent();
        }
        BLL_HotelDetails hotel = new BLL_HotelDetails();
        BLL_HotelCategory category = new BLL_HotelCategory();
        BLL_Pending pend = new BLL_Pending();
        blllCustomerDetailednyo custor = new blllCustomerDetailednyo();
        string today = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();
        Hotel.Hotel hb = new Hotel.Hotel();
        public string room_id;

        private void GetDetails_Load(object sender, EventArgs e)
        {
            panelPackage.Hide();
            dtp_birth.Text = DateTime.Now.ToLongDateString();
            LoadPendingBooking();
            LoadPackage();
            LoadCategory();
            cmb_package.SelectedIndex = 0;

        }
        public void LoadCategory()
        {
            DataTable dt = category.GetCategory();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["category_name"] = "Choose Category";
                dt.Rows.InsertAt(dr, 0);
                cmb_room_type.DataSource = dt;
                cmb_room_type.DisplayMember = "category_name";
                cmb_room_type.ValueMember = "room_category_id";
            }
        }
        public void LoadPackage()
        {
            DataTable dt = category.GetRoomPackage();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["package_name"] = "Choose Package";
                dt.Rows.InsertAt(dr, 0);
                cmb_package.DataSource = dt;
                cmb_package.DisplayMember = "package_name";
                cmb_package.ValueMember = "package_id";
            }

        }
        public void LoadPendingBooking()
        {
            //DataTable dt = hotel.GetCustomerName();

            //if (dt.Rows.Count > 0)
            //{
            //    DataRow dr = dt.NewRow();
            //    dr["name"] = "Choose Name";
            //    dt.Rows.InsertAt(dr, 0);
            //    cmb_name.DataSource = dt;
            //    cmb_name.DisplayMember = "name";
            //    cmb_name.ValueMember = "customer_id";
            //}
        }
        string gender;
        string username = Login.sendtext;
       
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            int pending_booking_id = PendingBooking.pending_booking_id;
            byte[] img = null;
            ImageConverter imgCon = new ImageConverter();
            img = (byte[])imgCon.ConvertTo(customer_pic.Image, typeof(byte[]));
         if (txt_fname.Text == "" || txt_lname.Text == "" || txt_mobile.Text == "" || txt_country.Text == "")
            {
                MessageBox.Show("Your Information is not Completed", "Confirm Information Alert !!");
            }
            else
            {
                if (customer_id == 0)
                {

                    if (rbn_female.Checked == true)
                    {
                        gender = "Female";
                    }
                    else if (rbn_male.Checked == true)
                    {
                        gender = "Male";
                    }
                    else
                    {
                        gender = "Others";
                    }
                    int insert_customer = hotel.Insert_Customer(txt_fname.Text, txt_lname.Text, txt_mobile.Text, txt_country.Text, txt_email.Text, gender, txt_house.Text, txt_city.Text, txt_state.Text, txt_id_type.Text, txt_id_number.Text, img, Convert.ToDateTime(dtp_birth.Text));
                    int insertinto = custor.insertintotables(img, txt_fname.Text, txt_lname.Text, Convert.ToDateTime(dtp_birth.Text), gender, txt_city.Text, txt_mobile.Text, "", txt_city.Text, txt_country.Text, txt_id_type.Text, txt_id_number.Text, txt_email.Text, "Hotel Cusomter", "", "");

                    DataTable dt = hotel.GetID(txt_fname.Text, txt_lname.Text);
                    customer_id = Convert.ToInt32(dt.Rows[0]["customer_id"].ToString());
                    if (txt_come.Text != "" || txt_go.Text != "" || txt_visit.Text != "")
                    {
                        int insert_details = hotel.Insert_Customer_details(customer_id, txt_come.Text, txt_go.Text, txt_visit.Text);
                    }
                    if (lbl_room_no.Text != "" && lbl_room_no.Text != "0")
                    {
                        int insert_booking = hotel.Insert_Booking(customer_id, Convert.ToDateTime(today), Convert.ToDateTime(dtp_check_in.Text), cmb_room_type.Text, Convert.ToInt32(txt_guest.Text), Convert.ToDateTime(dtp_checkout.Text), txt_roomno.Text, room_id,cmb_package.SelectedIndex);
                        int delete = pend.CancelationCustomer(Convert.ToInt32(customer_id));
                        MessageBox.Show("Your hotel have been Reserved", "Hotel Reserved Alert !!");
                    }
                    else
                    {
                        int insert_booking = hotel.Insert_Pending_booking(customer_id, Convert.ToDateTime(today), Convert.ToDateTime(dtp_check_in.Text), cmb_room_type.Text, Convert.ToInt32(txt_guest.Text), Convert.ToDateTime(dtp_checkout.Text), txt_roomno.Text, lbl_room_no.Text, username, Convert.ToDateTime(today));
                        MessageBox.Show("Your hotel have been Booked", "Hotel Booking Alert !!");
                    }
                }
                else
                {
                    if (txt_come.Text != "" || txt_go.Text != "" || txt_visit.Text != "")
                    {
                        int insert_details = hotel.Insert_Customer_details(customer_id, txt_come.Text, txt_go.Text, txt_visit.Text);
                    }
                    if (lbl_room_no.Text != "" && lbl_room_no.Text != "0")
                    {
                        if (cmb_package.Text=="Choose Package" || cmb_package.SelectedIndex<=0)
                        {
                            cmb_package.SelectedValue = 0;
                        }
                        int insert_booking = hotel.Insert_Booking(customer_id, Convert.ToDateTime(today), Convert.ToDateTime(today), cmb_room_type.Text, Convert.ToInt32(txt_guest.Text), Convert.ToDateTime(dtp_checkout.Text), txt_roomno.Text, room_id,Convert.ToInt32(cmb_package.SelectedValue));
                        // int updateroom = category.UpdateRoombyid(Convert.ToInt32(room_id));
                        DataTable dt = pend.GetpendingDetails(pending_booking_id);
                        if (Convert.ToInt32(dt.Rows[0]["no_of_room"].ToString()) > 1)
                        {
                            int updatepending = pend.Updatepending(pending_booking_id);
                        }
                        else
                        {
                            int delete = pend.CancelationCustomer(Convert.ToInt32(customer_id));
                            MessageBox.Show("Your hotel have been Reserved", "Hotel Reserved Alert !!");
                        }
                    }
                }

                Hotel.Hotel hko = new Hotel.Hotel();
                Control crl = this.Parent;
                crl.Controls.Clear();
                crl.Controls.Add(hko);
            }
        }
        int customer_id;
       public void GetCustomer()
        {
            DataTable dt = hotel.GetID(txt_fname.Text, txt_lname.Text);
            customer_id = Convert.ToInt32(dt.Rows[0]["customer_id"].ToString());
        }
        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {

            PendingBooking book = new PendingBooking();
            book.ShowDialog();
            if (book.DialogResult == DialogResult.OK)
            {
                customer_id = book.customer_id;
                DataTable dt1 = pend.GetReturnCustomerId(customer_id);
                if (dt1.Rows.Count > 0)
                {
                    txt_fname.Text = dt1.Rows[0]["f_name"].ToString();
                    txt_lname.Text = dt1.Rows[0]["l_name"].ToString();
                    txt_mobile.Text = dt1.Rows[0]["contact"].ToString();
                    txt_country.Text = dt1.Rows[0]["country"].ToString();
                    txt_state.Text = dt1.Rows[0]["state"].ToString();
                    txt_city.Text = dt1.Rows[0]["city"].ToString();
                    txt_guest.Text = dt1.Rows[0]["no_of_guest"].ToString();
                    cmb_room_type.Text = dt1.Rows[0]["room_type"].ToString();
                    txt_roomno.Text = dt1.Rows[0]["no_of_room"].ToString();
                    dtp_check_in.Text= dt1.Rows[0]["check_in"].ToString();
                    dtp_checkout.Text = dt1.Rows[0]["check_out"].ToString();

                }
            }
        }

        private void dtp_birth_onValueChanged(object sender, EventArgs e)
        {
         
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog();
            ofg.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            ofg.Title = "Choose Image File";


            if (ofg.ShowDialog() == DialogResult.OK)
            {
                //txt_location.Text = ofg.FileName;
                customer_pic.ImageLocation = ofg.FileName;

            }
            else
            {
                MessageBox.Show("image not selected");
            }
        }

        private void txt_id_number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_guest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_roomno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
              (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void dtp_checkout_onValueChanged(object sender, EventArgs e)
        {

        }

        private void txt_search_phone_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void btn_menu_Click(object sender, EventArgs e)
        {
           if (lbl_room_no.Text=="0")
            {
                panelPackage.Hide();
            }
            else
            {
                panelPackage.Show();
            }
        }
        
    }
}
