using BLLS;
using POS_System;
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
    public partial class Supplier_Details : UserControl
    {
        public Supplier_Details()
        {
            InitializeComponent();
        }
        BLLSupplier_details supp = new BLLSupplier_details();
        int sup_id;
        private void Supplier_Details_Load(object sender, EventArgs e)
        {
          
            //btn_update.Enabled = false;
            cbo_title.SelectedIndex = 0;
            sup_id = SupplierList.sup_id;
            if (sup_id > 0)
            {
                Add_Supplier.Enabled = false;
            }
            else
            {
                Add_Supplier.Enabled = true;
            }
            DataTable dt1 = supp.Getsupplierbyid(sup_id);
            if (dt1.Rows.Count>0)
            {
                cbo_title.Text = dt1.Rows[0]["title"].ToString();
                txt_name.Text = dt1.Rows[0]["name"].ToString();
                txt_adress.Text = dt1.Rows[0]["adress"].ToString();

                txt_phone.Text = dt1.Rows[0]["phone"].ToString();

                txt_mobile.Text = dt1.Rows[0]["mobile"].ToString();
                txt_email.Text = dt1.Rows[0]["email"].ToString();

                txt_city.Text = dt1.Rows[0]["city"].ToString();

                txt_iban.Text = dt1.Rows[0]["iban"].ToString();
                txt_AcNo.Text = dt1.Rows[0]["account_no"].ToString();
                txt_bank.Text = dt1.Rows[0]["bank"].ToString();
                txt_remarks.Text = dt1.Rows[0]["remarks"].ToString();

                txt_eccno.Text = dt1.Rows[0]["ecc_no"].ToString();

                txt_cst.Text = dt1.Rows[0]["cst_no"].ToString();
                txt_pan.Text = dt1.Rows[0]["pan_no"].ToString();

 }
            SupplierList.sup_id = 0;
        }
  
        private void btn_exit_Click(object sender, EventArgs e)
        {
           // this.Close();
        }
        
    
        public void clearAllTextbox(Control Con) {
            foreach (Control c in Con.Controls) {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else
                    clearAllTextbox(c);
                               
            }


        }
        public void clearAllCombobox(Control con) {
            foreach (Control c in con.Controls) {
                if (c is ComboBox)
                    ((ComboBox)c).ResetText();
                else
                    clearAllCombobox(c);

            }

        }
        
        private void btn_back_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            SupplierList alls = new SupplierList();
            ctls.Controls.Clear();
            ctls.Controls.Add(alls);
        }

        private void txt_cst_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_eccno_KeyPress(object sender, KeyPressEventArgs e)
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
       
        private void Add_Supplier_Click(object sender, EventArgs e)
        {
            if (cbo_title.Text == "" || txt_name.Text == ""||txt_adress.Text==""|| txt_mobile.Text=="")
            {
                MessageBox.Show("Please Fill all the required fields");
            }

            else
            {
                int supply = supp.InsertIntoSupplierDetails(cbo_title.Text, txt_name.Text, txt_adress.Text, txt_phone.Text, txt_mobile.Text, txt_email.Text, txt_city.Text, txt_eccno.Text, txt_cst.Text, txt_pan.Text, txt_iban.Text, txt_AcNo.Text, txt_bank.Text, txt_remarks.Text);
                if (supply > 0)
                {
                    MessageBox.Show("New Supplier Has Been Add");
                     clearAllTextbox(this);
  }
                else
                {
                    MessageBox.Show("Unable to add this supplier");
                }
            }
        }

        private void supplier_list_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            SupplierList sl = new SupplierList();
            ctls.Controls.Clear();
            ctls.Controls.Add(sl);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (cbo_title.Text == "" || txt_name.Text == "" || txt_adress.Text == "" || txt_mobile.Text == "")
            {
                MessageBox.Show("Please Fill all the required fields");
            }
            else
            {
                int update = supp.UpdateIntoSupplierDetail(sup_id, cbo_title.Text, txt_name.Text, txt_adress.Text, txt_phone.Text, txt_mobile.Text, txt_email.Text, txt_city.Text, txt_iban.Text, txt_AcNo.Text, txt_bank.Text, txt_remarks.Text,txt_eccno.Text, txt_cst.Text,txt_pan.Text);
                if (update > 0)
                {
                    MessageBox.Show("Successfully Updated");
                    clearAllTextbox(this);
                }
                else
                {
                    MessageBox.Show("Unable to update");
                }
            }
        }
        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void txt_mobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txt_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
    }
    }

