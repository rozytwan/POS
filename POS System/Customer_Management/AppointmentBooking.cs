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


namespace POS_System.Customer_Management
{
    public partial class AppointmentBooking : Form
    {

        public AppointmentBooking()
        {
            InitializeComponent();
        }
        BLLAppointmentGraph blappoint = new BLLAppointmentGraph();
        blllCustomerDetailednyo blcd = new blllCustomerDetailednyo();
        BLLTable blta = new BLLTable();
        int appo_id = EditAppointment.appo_id;
        private void AppointmentBooking_Load(object sender, EventArgs e)
        {
            Customer_name();
            Table_No();
            dtp_enddate.Text = DateTime.Now.ToShortDateString();
            dtp_startdate.Text = DateTime.Now.ToShortDateString();
            btnOk.Enabled = true;
            btnCancel.Enabled = true;
            btn_update.Enabled = false;
           
            if (appo_id > 0)
            {
                btnOk.Enabled = false;
                btnCancel.Enabled = true;
                btn_update.Enabled = true;
                DataTable dt = blappoint.GetAppointment(appo_id);
                if (dt.Rows.Count > 0)
                {
                    cmb_customer.Text = (dt.Rows[0]["name"].ToString());
                    cmb_tableno.Text = dt.Rows[0]["table_no"].ToString();
                    dtp_startdate.Text = Convert.ToDateTime(dt.Rows[0]["start_time"].ToString()).ToString("yyyy-MM-dd");
                    dtp_enddate.Text = Convert.ToDateTime(dt.Rows[0]["end_time"].ToString()).ToString("yyyy-MM-dd");
                    cmb_starttime.EditValue = Convert.ToDateTime(dt.Rows[0]["start_time"].ToString()).ToString("HH:mm:ss tt");
                    cmb_endtime.EditValue = Convert.ToDateTime(dt.Rows[0]["end_time"].ToString()).ToString("HH:mm:ss tt");
                    if (dt.Rows[0]["table_no"].ToString() == "true")
                    {
                        chkReminder.Checked = true;
                    }
                    else
                    {
                        chkReminder.Checked = false;
                    }

                    cmb_reminder.Text = dt.Rows[0]["reminder_time"].ToString();
                    tbDescription.Text = dt.Rows[0]["Remarks"].ToString();
                }
            }

        }
        public void Customer_name()
        {
            DataTable dt = blcd.getallcustomersPhoneNoName();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cmb_customer.DataSource = dt;
                cmb_customer.DisplayMember = "name";
                cmb_customer.ValueMember = "id";
            }
        }
        public void Table_No()
        {
            DataTable dt = blta.getalltable();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["rest_table_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cmb_tableno.DataSource = dt;
                cmb_tableno.DisplayMember = "rest_table_name";
                cmb_tableno.ValueMember = "rest_table_no";
            }
        }
        public void clear()
        {
            cmb_customer.Text = "Choose One";
            cmb_tableno.Text = "Choose One";
            dtp_enddate.Text = DateTime.Now.ToShortDateString();
            dtp_startdate.Text = DateTime.Now.ToShortDateString();
         
            tbDescription.Text = "";


        }
   
        private void btnOk_Click(object sender, EventArgs e)
        {
            string stime = Convert.ToString(cmb_starttime.EditValue);
            DateTime dts = DateTime.Parse(stime);
            string starttime = dts.ToString("HH:mm:ss tt");
            string time = Convert.ToString(cmb_endtime.EditValue);
            DateTime dt = DateTime.Parse(time);
            string endtime = dt.ToString("HH:mm:ss tt");
            string startdate = dtp_startdate.Text + " " + (starttime);
            string enddate = dtp_enddate.Text + " " + (endtime);
            TimeSpan minus = Convert.ToDateTime(enddate) - (Convert.ToDateTime(startdate));
            int remainder_time = (int)minus.TotalMinutes;

            if (cmb_customer.Text == "Choose One" || cmb_customer.Text == "")
            {
                MessageBox.Show("Customer Name Required");
            }
            else
            {
                if (chkReminder.Checked==true)
                {
                    int insert = blappoint.InsertAppointment(Convert.ToInt32(cmb_customer.SelectedValue), cmb_tableno.Text, Convert.ToDateTime(startdate), Convert.ToDateTime(enddate), "true", cmb_reminder.Text, (tbDescription.Text), '1');
                    if (insert > 0)
                    {
                        MessageBox.Show("Appointment Registered");
                        clear();
                        this.Close();
                    }
                }
                else
                {
                    int insert = blappoint.InsertAppointment(Convert.ToInt32(cmb_customer.SelectedValue), cmb_tableno.Text, Convert.ToDateTime(startdate), Convert.ToDateTime(enddate), "false", cmb_reminder.Text, (tbDescription.Text), '1');
                    if (insert > 0)
                    {
                        MessageBox.Show("Appointment Registered");
                        clear();
                        this.Close();
                    }
                }
            
             
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
           
        }

        private void dateEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
          
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            DataTable dt5 = blappoint.GetAppointment(appo_id);
            if (dt5.Rows.Count > 0)
            {
                int customer_id = Convert.ToInt32(dt5.Rows[0]["customer_id"].ToString());
                DataTable dt1 = blappoint.GetCustomer(customer_id);
                cmb_customer.Text = (dt1.Rows[0]["name"].ToString());
                // int appo_id = EditAppointment.appo_id;
                string stime = Convert.ToString(cmb_starttime.EditValue);
                DateTime dts = DateTime.Parse(stime);
                string starttime = dts.ToString("HH:mm:ss tt");
                string time = Convert.ToString(cmb_endtime.EditValue);
                DateTime dt = DateTime.Parse(time);
                string endtime = dt.ToString("HH:mm:ss tt");
                string startdate = dtp_startdate.Text + " " + (starttime);
                string enddate = dtp_enddate.Text + " " + (endtime);
                TimeSpan minus = Convert.ToDateTime(enddate) - (Convert.ToDateTime(startdate));
                int remainder_time = (int)minus.TotalMinutes;
                if (cmb_customer.Text == "Choose One" || cmb_customer.Text == "")
                {
                    MessageBox.Show("Customer Name Required");
                }

                else
                {
                    if (cmb_customer.SelectedValue == System.DBNull.Value)
                    {
                        cmb_customer.SelectedValue = customer_id;
                    }
                    if (chkReminder.Checked == true)
                    {
                        int update = blappoint.UpdateAppointment(appo_id, Convert.ToInt32(cmb_customer.SelectedValue), cmb_tableno.Text, Convert.ToDateTime(startdate), Convert.ToDateTime(enddate), "true", Convert.ToInt32(cmb_reminder.Text), (tbDescription.Text), '1');
                        if (update > 0)
                        {
                            MessageBox.Show("Appointment Successfully Updated !!", "Update Alert !!");
                           
                          EditAppointment.appo_id=0;
                       clear();
                            this.Close();
                        }
                    }
                    else
                    {
                        int update = blappoint.UpdateAppointment(appo_id, Convert.ToInt32(cmb_customer.SelectedValue), cmb_tableno.Text, Convert.ToDateTime(startdate), Convert.ToDateTime(enddate), "false", Convert.ToInt32(cmb_reminder.Text), (tbDescription.Text), '1');
                        if (update > 0)
                        {
                            MessageBox.Show("Appointment Successfully Updated !!", "Update Alert !!");
                     EditAppointment.appo_id = 0;
                             clear();
                            this.Close();
                        }
                    }
                }
            }
        }
      }
    }

