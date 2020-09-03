using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLS;
using System.IO;

namespace POS_System.Customer_Management
{
    public partial class CustomerAttendance : UserControl
    {
        public CustomerAttendance()
        {
            InitializeComponent();
        }

        bll_customer_mess bllmess = new bll_customer_mess();
        blllCustomerDetailednyo bllcus = new blllCustomerDetailednyo();
        private void CustomerAttendance_Load(object sender, EventArgs e)
        {
            loadAllPakagesCustomers();
        }
        public void loadAllPakagesCustomers()
        {
            DataTable getaallpakages = bllmess.getallPakagesLists();

            if (getaallpakages.Rows.Count > 0)
            {
                dgv_customers.Rows.Clear();
                for (int i = 0; i < getaallpakages.Rows.Count; i++)
                {
                    DataTable getallcustomer = bllcus.getallcustomersbyPakages(getaallpakages.Rows[i]["name"].ToString());
                    if (getallcustomer.Rows.Count > 0)
                    {
                        for (int j = 0; j < getallcustomer.Rows.Count; j++)
                        {
                            dgv_customers.Rows.Add(getallcustomer.Rows[j]["id"].ToString(), (byte[])getallcustomer.Rows[j]["image"], getallcustomer.Rows[j]["name"].ToString(), getallcustomer.Rows[j]["lastname"].ToString(), getallcustomer.Rows[j]["gender"].ToString(), getallcustomer.Rows[j]["pakage_name"].ToString(), getallcustomer.Rows[j]["address"].ToString(), getallcustomer.Rows[j]["phone"].ToString(), getallcustomer.Rows[j]["phone2"].ToString(), getallcustomer.Rows[j]["startingDate"].ToString(), getallcustomer.Rows[j]["noofdays"].ToString());
                        }
                    }
                }
            }
        }

        private void txt_customername_TextChanged(object sender, EventArgs e)
        {
            if (txt_customername.Text.Length > 0)
            {
                DataTable getaallpakages = bllmess.getallPakagesLists();

                if (getaallpakages.Rows.Count > 0)
                {
                    for (int i = 0; i < getaallpakages.Rows.Count; i++)
                    {
                        DataTable getallcustomer = bllcus.searchallcustomersbyPakages(getaallpakages.Rows[i]["name"].ToString(), txt_customername.Text);
                        if (getallcustomer.Rows.Count > 0)
                        {
                            dgv_customers.Rows.Clear();
                            for (int j = 0; j < getallcustomer.Rows.Count; j++)
                            {
                                dgv_customers.Rows.Add(getallcustomer.Rows[j]["id"].ToString(), (byte[])getallcustomer.Rows[j]["image"], getallcustomer.Rows[j]["name"].ToString(), getallcustomer.Rows[j]["lastname"].ToString(), getallcustomer.Rows[j]["gender"].ToString(), getallcustomer.Rows[j]["pakage_name"].ToString(), getallcustomer.Rows[j]["address"].ToString(), getallcustomer.Rows[j]["phone"].ToString(), getallcustomer.Rows[j]["phone2"].ToString());
                            }
                        }
                    }
                }
            }
            else
            {
                loadAllPakagesCustomers();
            }
        }

        private void txt_package_TextChanged(object sender, EventArgs e)
        {
            if (txt_package.Text.Length > 0)
            {
                DataTable getallcustomer = bllcus.getDataByitspackagename(txt_package.Text);
                dgv_customers.Rows.Clear();
                if (getallcustomer.Rows.Count > 0)
                {
                    for (int j = 0; j < getallcustomer.Rows.Count; j++)
                    {
                        dgv_customers.Rows.Add(getallcustomer.Rows[j]["id"].ToString(), (byte[])getallcustomer.Rows[j]["image"], getallcustomer.Rows[j]["name"].ToString(), getallcustomer.Rows[j]["lastname"].ToString(), getallcustomer.Rows[j]["gender"].ToString(), getallcustomer.Rows[j]["pakage_name"].ToString(), getallcustomer.Rows[j]["address"].ToString(), getallcustomer.Rows[j]["phone"].ToString(), getallcustomer.Rows[j]["phone2"].ToString());
                    }
                }
                else
                {
                    loadAllPakagesCustomers();
                }
            }
        }

        private void dgv_customers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==dgv_customers.Columns["colsetAttendance"].Index &&e.RowIndex >=0) {
                
                ShowAttendance SwAttend = new ShowAttendance();
                SwAttend.lbl_Fullname.Text = dgv_customers.CurrentRow.Cells["colName"].Value.ToString() + " " + dgv_customers.CurrentRow.Cells["colLastName"].Value.ToString();
                SwAttend.lbl_adress.Text = "Address: "+dgv_customers.CurrentRow.Cells["coladdress"].Value.ToString();
                SwAttend.lbl_Phone.Text = "Contacts: " + dgv_customers.CurrentRow.Cells["colphone"].Value.ToString() + " " + dgv_customers.CurrentRow.Cells["colmobile"].Value.ToString(); ;
                SwAttend.lbl_package.Text = dgv_customers.CurrentRow.Cells["colpakagename"].Value.ToString();
                SwAttend.lbl_custoemrid.Text = dgv_customers.CurrentRow.Cells["colID"].Value.ToString();
               
                SwAttend.ShowDialog();
            }
            if(e.ColumnIndex==dgv_customers.Columns["colViewDetails"].Index && e.RowIndex >=0){
                Mess_detail_record mdr = new Mess_detail_record();
                mdr.lbl_Fullname.Text = dgv_customers.CurrentRow.Cells["colName"].Value.ToString() + " " + dgv_customers.CurrentRow.Cells["colLastName"].Value.ToString();
                mdr.lbl_adress.Text = "Address: " + dgv_customers.CurrentRow.Cells["coladdress"].Value.ToString();
                mdr.lbl_Phone.Text = "Contacts: " + dgv_customers.CurrentRow.Cells["colphone"].Value.ToString() + " " + dgv_customers.CurrentRow.Cells["colmobile"].Value.ToString();
                mdr.lbl_packages.Text = dgv_customers.CurrentRow.Cells["colpakagename"].Value.ToString();
                mdr.lbl_noofdays.Text = dgv_customers.CurrentRow.Cells["colnoofdays"].Value.ToString();
                mdr.lbl_dates.Text = dgv_customers.CurrentRow.Cells["colstartingdate"].Value.ToString();
                mdr.lbl_cusId.Text = dgv_customers.CurrentRow.Cells["colID"].Value.ToString();
                mdr.ShowDialog();

            }
        }
    }
}
