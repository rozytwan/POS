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
    public partial class Search : UserControl
    {
        public Search()
        {
            InitializeComponent();
        }
        BLL_HotelCustomer customer = new BLL_HotelCustomer();
        private void Search_Load(object sender, EventArgs e)
        {
            dtp_search.Show();
            cmb_search.Hide();
            LoadSearch();
  }
        public void LoadContact()
        {
            DataTable dt = customer.GetCustomerName();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["contact"] = "Choose Contact";
                dt.Rows.InsertAt(dr, 0);
cmb_search.DataSource = dt;
                cmb_search.DisplayMember = "contact";
                cmb_search.ValueMember = "customer_id";
            }
        }
        public void LoadCustomerName()
        {
            DataTable dt = customer.GetCustomerName();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["f_name"] = "Choose Name";
                dt.Rows.InsertAt(dr, 0);
                cmb_search.DataSource = dt;
                cmb_search.DisplayMember = "f_name";
                cmb_search.ValueMember = "customer_id";
            }
        }

        public void LoadSearch()
        {
            if (rbn_name.Checked == true)
            {
                DataTable dtname = customer.GetCustomerbyname(cmb_search.Text);
                if (dtname.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < dtname.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        int customer_id = Convert.ToInt32(dtname.Rows[i]["customer_id"].ToString());
                        dataGridView1.Rows[i].Cells["col_id"].Value = dtname.Rows[i]["customer_id"].ToString();
                        dataGridView1.Rows[i].Cells["col_fname"].Value = dtname.Rows[i]["f_name"].ToString();
                        dataGridView1.Rows[i].Cells["col_lname"].Value = dtname.Rows[i]["l_name"].ToString();
                        dataGridView1.Rows[i].Cells["col_mobile"].Value = dtname.Rows[i]["contact"].ToString();
                       
                        DataTable dtbook = customer.GetBooking(customer_id);
                        if (dtbook.Rows.Count>0)
                        {
                            dataGridView1.Rows[i].Cells["col_booking_date"].Value = dtbook.Rows[0]["booking_date"].ToString();
                            dataGridView1.Rows[i].Cells["col_room_type"].Value = dtbook.Rows[0]["room_type"].ToString();
                            dataGridView1.Rows[i].Cells["col_checkin"].Value = dtbook.Rows[0]["check_in"].ToString();
                            dataGridView1.Rows[i].Cells["col_check_out"].Value = dtbook.Rows[0]["check_out"].ToString();
                        }
                     
                    }
                }
            }
            else if (rbn_checkin.Checked==true)
            {
                DataTable dt = customer.GetCheckIn(Convert.ToDateTime(dtp_search.Text));
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["col_booking_date"].Value = dt.Rows[0]["booking_date"].ToString();
                        dataGridView1.Rows[i].Cells["col_room_type"].Value = dt.Rows[0]["room_type"].ToString();
                        dataGridView1.Rows[i].Cells["col_checkin"].Value = dt.Rows[0]["check_in"].ToString();
                        dataGridView1.Rows[i].Cells["col_check_out"].Value = dt.Rows[0]["check_out"].ToString();
                        int customer_id = Convert.ToInt32(dt.Rows[i]["customer_id"].ToString());
                        dataGridView1.Rows[i].Cells["col_id"].Value = dt.Rows[0]["customer_id"].ToString();

                        DataTable dt1 = customer.Getcheckincustomer(customer_id);
                        if (dt1.Rows.Count > 0)
                        {
                            dataGridView1.Rows[i].Cells["col_fname"].Value = dt1.Rows[0]["f_name"].ToString();
                            dataGridView1.Rows[i].Cells["col_lname"].Value = dt1.Rows[0]["l_name"].ToString();
                            dataGridView1.Rows[i].Cells["col_mobile"].Value = dt1.Rows[0]["contact"].ToString();
                        }

                    }
                }
            }
            else if (rbn_phone.Checked == true)
            {

                DataTable dtname = customer.GetCustomerbycontact(cmb_search.Text);
                if (dtname.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < dtname.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        int customer_id = Convert.ToInt32(dtname.Rows[i]["customer_id"].ToString());
                        dataGridView1.Rows[i].Cells["col_id"].Value = dtname.Rows[i]["customer_id"].ToString();
                        dataGridView1.Rows[i].Cells["col_fname"].Value = dtname.Rows[i]["f_name"].ToString();
                        dataGridView1.Rows[i].Cells["col_lname"].Value = dtname.Rows[i]["l_name"].ToString();
                        dataGridView1.Rows[i].Cells["col_mobile"].Value = dtname.Rows[i]["contact"].ToString();
                 
                        DataTable dtbook = customer.GetBooking(customer_id);
                        if (dtbook.Rows.Count>0)
                        {
                            dataGridView1.Rows[i].Cells["col_booking_date"].Value = dtbook.Rows[0]["booking_date"].ToString();
                            dataGridView1.Rows[i].Cells["col_room_type"].Value = dtbook.Rows[0]["room_type"].ToString();
                            dataGridView1.Rows[i].Cells["col_checkin"].Value = dtbook.Rows[0]["check_in"].ToString();
                            dataGridView1.Rows[i].Cells["col_checkout"].Value = dtbook.Rows[0]["check_out"].ToString();
                        }

                    }
                }
            }
            }
   

        
 
        private void rbn_name_Click(object sender, EventArgs e)
        {
            LoadCustomerName();
            dtp_search.Hide();
            cmb_search.Show();
        }

        private void rbn_phone_Click(object sender, EventArgs e)
        {
            LoadContact();
            dtp_search.Hide();
            cmb_search.Show();
        }

        private void rbn_checkin_Click(object sender, EventArgs e)
        {
            dtp_search.Show();
            cmb_search.Hide();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (rbn_name.Checked==true)
            {
                LoadSearch();
            }
            if (rbn_phone.Checked==true)
            {
                LoadSearch();
            }
            if (rbn_checkin.Checked==true)
            {
                LoadSearch();
            }
        }
        
    }

    }

