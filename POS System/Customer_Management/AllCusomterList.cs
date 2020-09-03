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
    public partial class AllCusomterList : UserControl
    {
        string orderpattern;
        public AllCusomterList(string pattern)
        {
            orderpattern = pattern;
            InitializeComponent();
        }
        blllCustomerDetailednyo bllcustomer = new blllCustomerDetailednyo();
        private void AllCusomterList_Load(object sender, EventArgs e)
        {
            Loadcustomer();
            cmb_search.SelectedIndex = 0;
        }
        public void Loadcustomer()
        {
            
          DataTable  dt = bllcustomer.getallcustomersWithOutPakges();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_id"].Value = dt.Rows[i]["id"].ToString();
                    int customer_id = Convert.ToInt32(dataGridView1.Rows[i].Cells["col_id"].Value.ToString());
                    dataGridView1.Rows[i].Cells["col_name"].Value = dt.Rows[i]["name"].ToString();
                    dataGridView1.Rows[i].Cells["col_last_name"].Value = dt.Rows[i]["lastname"].ToString();
                    dataGridView1.Rows[i].Cells["col_phone"].Value = dt.Rows[i]["phone"].ToString();
                    dataGridView1.Rows[i].Cells["col_address"].Value = dt.Rows[i]["address"].ToString();
                    DataTable dt1 = bllcustomer.getDeliveryByitsusername_phone(customer_id);
                    if (dt1.Rows.Count > 0)
                    {
                        dataGridView1.Rows[i].Cells["col_status"].Value = "Ordered";
                    }
                }
            }
       }
   private void txt_search_by_TextChanged(object sender, EventArgs e)
        {
            if (txt_search_by.Text.Length > 4)
            {
                if (cmb_search.Text == "Name")
                {
                  
                   DataTable dt = bllcustomer.search_By_Fullname(txt_search_by.Text);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["col_id"].Value = dt.Rows[i]["id"].ToString();
                            int customer_id = Convert.ToInt32(dataGridView1.Rows[i].Cells["col_id"].Value.ToString());
                            dataGridView1.Rows[i].Cells["col_name"].Value = dt.Rows[i]["name"].ToString();
                            dataGridView1.Rows[i].Cells["col_last_name"].Value = dt.Rows[i]["lastname"].ToString();
                            dataGridView1.Rows[i].Cells["col_phone"].Value = dt.Rows[i]["phone"].ToString();
                            dataGridView1.Rows[i].Cells["col_address"].Value = dt.Rows[i]["address"].ToString();
                            DataTable dt1 = bllcustomer.getDeliveryByitsusername_phone(customer_id);
                            if (dt1.Rows.Count > 0)
                            {
                                dataGridView1.Rows[i].Cells["col_status"].Value = "Ordered";
                            }

                        }
                    }
                }
                else if (cmb_search.Text == "Phone")
                {
                    DataTable dt = bllcustomer.GetCusotmerPhone(txt_search_by.Text);
                    if (dt.Rows.Count > 0)
                    {
                        dataGridView1.Rows.Clear();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["col_id"].Value = dt.Rows[i]["id"].ToString();
                            int customer_id = Convert.ToInt32(dataGridView1.Rows[i].Cells["col_id"].Value.ToString());
                            dataGridView1.Rows[i].Cells["col_name"].Value = dt.Rows[i]["name"].ToString();
                            dataGridView1.Rows[i].Cells["col_last_name"].Value = dt.Rows[i]["lastname"].ToString();
                            dataGridView1.Rows[i].Cells["col_phone"].Value = dt.Rows[i]["phone"].ToString();
                            dataGridView1.Rows[i].Cells["col_address"].Value = dt.Rows[i]["address"].ToString();
                            DataTable dt1 = bllcustomer.getDeliveryByitsusername_phone(customer_id);
                            if (dt1.Rows.Count > 0)
                            {
                                dataGridView1.Rows[i].Cells["col_status"].Value = "Ordered";
                            }
                        }
                    }
                }
            }
        }
        HomeDeliveryModel hdm = new HomeDeliveryModel();
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col_select"].Index && e.RowIndex >= 0)
            {
                HomeDeliveryModel.customer_id= Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_id"].Value.ToString());
                Control ctls = this.Parent;
                KOTOrder vieret = new KOTOrder("520", null);
                ctls.Controls.Clear();
                ctls.Controls.Add(vieret);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
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
                Control ctl = this.Parent;
                CustomerDetailform cpf = new CustomerDetailform("HD");
                ctl.Controls.Clear();
                ctl.Controls.Add(cpf);
            }
        }
        string take_away_id;
        BLLTakeAway bltk = new BLLTakeAway();
        BLLDynamic bld = new BLLDynamic();
        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (orderpattern == "HomeDelivery")
            {
              
                Control ctls = this.Parent;
                KOTOrder vieret = new KOTOrder("520", null);
                ctls.Controls.Clear();
                ctls.Controls.Add(vieret);
            }
            else if (orderpattern == "Token")
            {
               
                DataTable dt = bld.EnableTokenBilling();
                if (dt.Rows.Count > 0)
                {
                    Control ctls = this.Parent;
                    FastBilling fb = new FastBilling();
                    ctls.Controls.Clear();
                    ctls.Controls.Add(fb);
                }
            }
            else if (orderpattern == "TableLoad")
            {
               
                Control ctls = this.Parent;
                Table_Management.Table_Billing winfor = new Table_Management.Table_Billing();
                ctls.Controls.Clear();
                ctls.Controls.Add(winfor);
            }
            else if (orderpattern == "TakeAway")
            {
                DataTable dt = bltk.getmaxNo();
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() == "")
                    {
                        take_away_id = "1001";
                    }
                    else
                    {
                        int getinvoiceno = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                        take_away_id = getinvoiceno.ToString();
                        DataTable dtm = bltk.getallfromtable();
                    }
                }

                Control ctls = this.Parent;
                KOTOrder vieret = new KOTOrder(take_away_id, "TA");
                ctls.Controls.Clear();
                ctls.Controls.Add(vieret);
            }
        }
    }
}
