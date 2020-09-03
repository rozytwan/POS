using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLLS;
using System.Windows.Forms;
using System.Collections;
using BLLS.Bll_mess_days;

namespace POS_System.Customer_Management
{
    public partial class setCustomerPakages : Form
    {
        public setCustomerPakages()
        {
            InitializeComponent();
        }
        blllCustomerDetailednyo bllcus = new blllCustomerDetailednyo();
        bll_customer_mess Bllmess = new bll_customer_mess();
        Bll_mess_dailyrecord bllmessdaily = new Bll_mess_dailyrecord();
        private void setCustomerPakages_Load(object sender, EventArgs e)
        {
            loaddDatagrid();
            loaddallpakages();
           
          
        }


        public void loaddallpakages()
        {
            bll_customer_mess Bllmess = new bll_customer_mess();
            DataTable getpakage = Bllmess.getallPakagesLists();

            if (getpakage.Rows.Count > 0)
            {
                DataRow dr = getpakage.NewRow();
                dr["name"] = "Choose Package";
                getpakage.Rows.InsertAt(dr,0);
                colpakagename.DataSource = getpakage;
                colpakagename.DisplayMember = "name";
            }

        }
        public void loaddDatagrid()
        {

            DataTable getallcustomer = bllcus.getallcustomersWithOutPakges();
            if (getallcustomer.Rows.Count > 0)
            {
                dgv_customers.Rows.Clear();
                
                for (int j = 0; j < getallcustomer.Rows.Count; j++)
                {
                    if (getallcustomer.Rows[j]["pakage_name"].ToString() != "Choose Package")
                    {
                       
                        dgv_customers.Rows.Add(getallcustomer.Rows[j]["id"].ToString(), getallcustomer.Rows[j]["name"].ToString(), getallcustomer.Rows[j]["lastname"].ToString(), getallcustomer.Rows[j]["gender"].ToString(), getallcustomer.Rows[j]["address"].ToString(), getallcustomer.Rows[j]["phone"].ToString(), getallcustomer.Rows[j]["phone2"].ToString(), getallcustomer.Rows[j]["nationality"].ToString(), getallcustomer.Rows[j]["pakage_name"].ToString());
                      
                    }
                    else if(getallcustomer.Rows[j]["pakage_name"].ToString() == "Choose Package")
                    {
                        dgv_customers.Rows.Add(getallcustomer.Rows[j]["id"].ToString(), getallcustomer.Rows[j]["name"].ToString(), getallcustomer.Rows[j]["lastname"].ToString(), getallcustomer.Rows[j]["gender"].ToString(), getallcustomer.Rows[j]["address"].ToString(), getallcustomer.Rows[j]["phone"].ToString(), getallcustomer.Rows[j]["phone2"].ToString(), getallcustomer.Rows[j]["nationality"].ToString(), getallcustomer.Rows[j]["pakage_name"].ToString());
                      
                    }
                }

            }
        }

        private void dgv_customers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv_customers.Columns["colSet"].Index && e.RowIndex >= 0)
            {
                try {
                    if (dgv_customers.CurrentRow.Cells["colpakagename"].Value.ToString() == "Choose Package" || dgv_customers.CurrentRow.Cells["colnoofdays"].Value.ToString() == "" || dgv_customers.CurrentRow.Cells["colnoofdays"].Value.ToString() == "0")
                    {
                        MessageBox.Show("Inputs are Empty or Categgory is not set. check... ");
                    }
                    else if ((Convert.ToDateTime(dgv_customers.CurrentRow.Cells["colStartingDate"].Value)).ToShortDateString() == "") {
                        MessageBox.Show("Date not Set Properly");
                    }
                    else
                    {
                        string getid = dgv_customers.CurrentRow.Cells["colID"].Value.ToString();
                        String getStartingDate = Convert.ToDateTime(dgv_customers.CurrentRow.Cells["colStartingDate"].Value.ToString()).ToShortDateString();
                        int getnoofDays = Convert.ToInt32(dgv_customers.CurrentRow.Cells["colnoofDays"].Value.ToString());
                        String getpackageName = dgv_customers.CurrentRow.Cells["colpakagename"].Value.ToString();
                        
                        DialogResult doalig = MessageBox.Show("Setting " + getpackageName + " Package For " + dgv_customers.CurrentRow.Cells["colName"].Value.ToString(), "Setting Package Name", MessageBoxButtons.YesNo);
                        if (doalig == DialogResult.Yes)
                        {
                            int update = bllcus.pakageUpdate(getid, getpackageName, getStartingDate, getnoofDays);
                            if (update > 0)
                            {
                                MessageBox.Show("Package Set for " + dgv_customers.CurrentRow.Cells["colName"].Value.ToString() + " " + dgv_customers.CurrentRow.Cells["colLastName"].Value.ToString());
                                loaddDatagrid();
                                this.Hide();
                                this.DialogResult = DialogResult.OK;
                            }
                        }
                        else if (doalig == DialogResult.No)
                        {

                        }

                    }
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message + "\n"+ "Empty Fields..please Check" );
                }

                }
            if (e.ColumnIndex == dgv_customers.Columns["colcancel"].Index && e.RowIndex >= 0) {
                string pushCustomserId = dgv_customers.CurrentRow.Cells["colID"].Value.ToString();
                string push_packagename = dgv_customers.CurrentRow.Cells["colpakagename"].Value.ToString();
                string Customername = dgv_customers.CurrentRow.Cells["colName"].Value.ToString();
                string customerlastname = dgv_customers.CurrentRow.Cells["colLastname"].Value.ToString();

                DataTable dt = bllcus.GetpackagenotsetCustomer(pushCustomserId);
                if (dt.Rows[0]["pakage_name"].ToString()== "Choose Package") {
                    MessageBox.Show("Package is not set for this Customer","Packagge not fou");
                }
                else {
                    
                    DialogResult dialougge = MessageBox.Show("Cancel " + push_packagename + " Package For " + dgv_customers.CurrentRow.Cells["colName"].Value.ToString(), "Cancel Package for ", MessageBoxButtons.YesNo);
                    if (dialougge == DialogResult.Yes) {

                        bllmessdaily.deletebyCustomerpackaeNamefrombreakfastdaily(push_packagename, pushCustomserId);
                        bllmessdaily.deletebyCustomerpackaeNamefromDinnerdaily(push_packagename, pushCustomserId);
                        bllmessdaily.deletebyCustomerpackaeNamefromlunchdaily(push_packagename, pushCustomserId);
                        bllmessdaily.deletebyCustomerpackaeNamefromsnacksdaily(push_packagename, pushCustomserId);
                        bllcus.updateCustomerAfterCancelled(pushCustomserId);
                        MessageBox.Show(push_packagename + " Packae cancelled for " + Customername + " " + customerlastname);
                        this.Hide();
                        this.DialogResult = DialogResult.OK;

                    }
                    else if (dialougge == DialogResult.No) {

                    }

                }
            }
            }
           
        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
