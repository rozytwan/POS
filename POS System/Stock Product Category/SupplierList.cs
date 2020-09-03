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
    public partial class SupplierList : UserControl
    {
        public SupplierList()
        {
            InitializeComponent();
        }
        BLLSupplier_details supp = new BLLSupplier_details();

        private void SupplierList_Load(object sender, EventArgs e)
        {
            Loaddatagrid();
            cmb_search.Text = "Search By";
        }
        public void Loaddatagrid()
        {
            DataTable dt = supp.Fectching_All_Table_data();
            if (dt.Rows.Count>0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["caltitle"].Value = dt.Rows[i]["title"].ToString();
                    dataGridView1.Rows[i].Cells["col_sup_id"].Value = dt.Rows[i]["sup_id"].ToString();
dataGridView1.Rows[i].Cells["calname"].Value = dt.Rows[i]["name"].ToString();
dataGridView1.Rows[i].Cells["caladress"].Value = dt.Rows[i]["adress"].ToString();
                    dataGridView1.Rows[i].Cells["calphone"].Value = dt.Rows[i]["phone"].ToString();
                    dataGridView1.Rows[i].Cells["calmobile"].Value = dt.Rows[i]["mobile"].ToString();
                    dataGridView1.Rows[i].Cells["calemail"].Value = dt.Rows[i]["email"].ToString();
                    dataGridView1.Rows[i].Cells["calcity"].Value = dt.Rows[i]["city"].ToString();
                    dataGridView1.Rows[i].Cells["caliban"].Value = dt.Rows[i]["iban"].ToString();
                    dataGridView1.Rows[i].Cells["calaccount_no"].Value = dt.Rows[i]["account_no"].ToString();
                    dataGridView1.Rows[i].Cells["calbank"].Value = dt.Rows[i]["bank"].ToString();
                    dataGridView1.Rows[i].Cells["calRemarks"].Value = dt.Rows[i]["remarks"].ToString();
                    dataGridView1.Rows[i].Cells["calecc_no"].Value = dt.Rows[i]["ecc_no"].ToString();
                    dataGridView1.Rows[i].Cells["calpan_no"].Value = dt.Rows[i]["pan_no"].ToString();
                    dataGridView1.Rows[i].Cells["calcst_no"].Value = dt.Rows[i]["cst_no"].ToString();


                }
            }
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

        private void Add_Supplier_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            Supplier_Details sd = new Supplier_Details();
            ctls.Controls.Clear();
            ctls.Controls.Add(sd);

        }
        public static int sup_id;
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                {
                    sup_id = Convert.ToInt32(dr.Cells["col_sup_id"].Value);
                }
                Control ctls = this.Parent;
               Supplier_Details sd = new Supplier_Details();
                ctls.Controls.Clear();
                ctls.Controls.Add(sd);
                // ucp.Show();

            }
            else
            {
                MessageBox.Show("Please Select A Row", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
  
        private void btn_delete_Click(object sender, EventArgs e)
        {
       
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dig = MessageBox.Show("Are You Sure To Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dig == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        sup_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_sup_id"].Value);
                        int delete = supp.Deletesupplier(sup_id);
                        if (delete > 0)
                        {
                            MessageBox.Show("Successfully Deleted");
                        }

                        dataGridView1.Rows.RemoveAt(dr.Index);
                    }

                }
                else
                {
                    MessageBox.Show("Please select row first");
                }

            }
        }

        private void txt_searchbox_TextChanged(object sender, EventArgs e)
        {
            if (cmb_search.SelectedIndex==-1)
            {
                cmb_search.Text = "Search By";
            }
            if (cmb_search.SelectedIndex==0)
            {
                DataTable dt = supp.GetSupplierbyname(txt_searchbox.Text);
                if (dt.Rows.Count > 0)
                {

                    dataGridView1.Rows.Clear();
                    dataGridView1.ClearSelection();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["col_sup_id"].Value = dt.Rows[i]["sup_id"].ToString();
                        dataGridView1.Rows[i].Cells["caltitle"].Value = dt.Rows[i]["title"].ToString();
                     
                        dataGridView1.Rows[i].Cells["calname"].Value = dt.Rows[i]["name"].ToString();
                        dataGridView1.Rows[i].Cells["caladress"].Value = dt.Rows[i]["adress"].ToString();
                        dataGridView1.Rows[i].Cells["calphone"].Value = dt.Rows[i]["phone"].ToString();
                        dataGridView1.Rows[i].Cells["calmobile"].Value = dt.Rows[i]["mobile"].ToString();
                        dataGridView1.Rows[i].Cells["calemail"].Value = dt.Rows[i]["email"].ToString();
                        dataGridView1.Rows[i].Cells["calcity"].Value = dt.Rows[0]["city"].ToString();
                        dataGridView1.Rows[i].Cells["caliban"].Value = dt.Rows[i]["iban"].ToString();
                        dataGridView1.Rows[i].Cells["calaccount_no"].Value = dt.Rows[i]["account_no"].ToString();
                        dataGridView1.Rows[i].Cells["calbank"].Value = dt.Rows[i]["bank"].ToString();
                        dataGridView1.Rows[i].Cells["calRemarks"].Value = dt.Rows[i]["remarks"].ToString();
                        dataGridView1.Rows[i].Cells["calecc_no"].Value = dt.Rows[i]["ecc_no"].ToString();
                        dataGridView1.Rows[i].Cells["calcst_no"].Value = dt.Rows[i]["cst_no"].ToString();
                        dataGridView1.Rows[i].Cells["calpan_no"].Value = dt.Rows[i]["pan_no"].ToString();

  }
                          
                }
              //  dataGridView1.ClearSelection();
               // Loaddatagrid();

            }
           
        }
        
    }
}
