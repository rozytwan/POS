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
    public partial class UserControl_purchase_return : Form
    {
        public UserControl_purchase_return()
        {
            InitializeComponent();
        }
        BLLUser blu = new BLLUser();
        BLLCategory blcat = new BLLCategory();
        BLLPurchase blpur = new BLLPurchase();
        BLLProduct blpro = new BLLProduct();
        BLLpurchasereturn blpr = new BLLpurchasereturn();
        BLLInvoice blin = new BLLInvoice();
        BLLStock bls = new BLLStock();
        BLLSupplier_details blsupp = new BLLSupplier_details();
        private void UserControl_purchase_return_Load(object sender, EventArgs e)
        {
            userLoad();
            category();
            supplier_name();
            invoice_no();
            //purchaseid();
        }
        public void userLoad()
        {
            DataTable dt = blu.getalluser();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["user_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cboreceived_by.DataSource = dt;
                cboreceived_by.DisplayMember = "user_name";
                cboreceived_by.ValueMember = "user_id";
            }
        }
        public void purchaseid()
        {
            DataTable dt = blpur.getallpurchase();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["purchase_id"] =0;
                dt.Rows.InsertAt(dr, 0);
                cbopono.DataSource = dt;
                cbopono.DisplayMember = "purchase_id";
                cbopono.ValueMember = "purchase_id";
            }
        }

        public void category()
        {
            DataTable dt = blcat.getallcategory();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["category_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cmb_category.DataSource = dt;
                cmb_category.DisplayMember = "category_name";
                cmb_category.ValueMember = "category_id";
            }
        }
        public void supplier_name()
        {
            DataTable dt = blsupp.Fectching_All_Table_data();
            if (dt.Rows.Count > 0)
            {

                DataRow dr = dt.NewRow();
                dr["name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cmb_supplier.DataSource = dt;
                cmb_supplier.DisplayMember = "name";
                cmb_supplier.ValueMember = "name";
            }
        }
        public void invoice_no()
        {
            DataTable dt = blin.getinvoiceno();
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "")
                {
                    txtinvoiceno.Text = "100";
                }
                else
                {
                    int getinvoiceno = Convert.ToInt32(dt.Rows[0][0].ToString()) + 1;
                    txtinvoiceno.Text = getinvoiceno.ToString();
                }
            }
        }
        public void Return()
        {

        }
        public void ClearallTextbox(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();

                else
                    ClearallTextbox(c);
            }

        }
        public void clearcombo(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is ComboBox)
                    ((ComboBox)c).ResetText();
                else
                    clearcombo(c);


            }
        }
      
   
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtinvoiceno.Text == "" || cmb_product.Text == "Choose one" || txtquanitity.Text == "" || cmb_supplier.Text == "" || cmb_category.Text == "Choose one" || txtprice.Text == "" || cbopono.Text == "" || txtsingletotal.Text == "")
            {
                MessageBox.Show("inputs are may be empty..");
            }
            else
            {
                quanityConverter();
                int i = dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["calcategoryid"].Value = cmb_category.SelectedValue.ToString();

                dataGridView1.Rows[i].Cells["calproductid"].Value = cmb_product.SelectedValue.ToString();
                dataGridView1.Rows[i].Cells["calcategoryname"].Value = cmb_category.Text;
                dataGridView1.Rows[i].Cells["calproductname"].Value = cmb_product.Text;
                dataGridView1.Rows[i].Cells["calprice"].Value = txtprice.Text;
                dataGridView1.Rows[i].Cells["cal_unit"].Value = cbo_unit.Text;
                dataGridView1.Rows[i].Cells["calquantity"].Value = quantity.ToString();
                dataGridView1.Rows[i].Cells["cal_bill_no"].Value = txt_bill_no.Text;
                dataGridView1.Rows[i].Cells["caltotal"].Value = txtsingletotal.Text;
                dataGridView1.Rows[i].Cells["calexpirydate"].Value = dtpexpirydate.Text;
                dataGridView1.Rows[i].Cells["calponno"].Value = cbopono.Text;
                dataGridView1.Rows[i].Cells["calpurchase_date"].Value = DateTime.Now.ToShortDateString();
                dataGridView1.Rows[i].Cells["calsupplier_name"].Value = cmb_supplier.Text;
                i++;
                txtgrandtotal.Text = (Convert.ToDecimal(txtgrandtotal.Text) + Convert.ToDecimal(txtsingletotal.Text)).ToString();
                txttotal.Text = txtgrandtotal.Text;
            }
        }
        decimal quantity = 0;
        public void quanityConverter()
        {
            if (cmb_product.SelectedIndex > 0 && cbo_unit.Text.Length > 0 && cbo_unit.SelectedIndex >= 0)
            {
                DataTable dt = blpur.getpurchasebyproduct(Convert.ToInt32(cmb_product.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["inhouse_unit_1"].ToString() == cbo_unit.Text)
                    {
                         quantity = (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_2"]) * Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]) * Convert.ToDecimal(txtquanitity.Text));
                    }
                    else if (dt.Rows[0]["inhouse_unit_2"].ToString() == cbo_unit.Text)
                    {
                         quantity = (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]) * Convert.ToDecimal(txtquanitity.Text));
                    }
                    else
                    {
                         quantity = Convert.ToDecimal(txtquanitity.Text);
                    }

                }

            }
        }
        private void cmb_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_category.SelectedIndex != 0)
            {
                DataTable dt = blpro.getproductid(Convert.ToInt32(cmb_category.SelectedValue.ToString()));
                if (dt.Rows.Count > 0)
                {

                    DataRow dr = dt.NewRow();
                    dr["product_name"] = "Choose One";
                    dt.Rows.InsertAt(dr, 0);
                    cmb_product.DataSource = dt;
                    cmb_product.DisplayMember = "product_name";
                    cmb_product.ValueMember = "product_id";
                }
            }
        }

        private void cmb_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_product.SelectedIndex > 0 && cmb_product.Text != "Choose One")
            {
                DataTable dt = blpur.getpurchasebyproduct(Convert.ToInt32(cmb_product.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    cbo_unit.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        cbo_unit.Items.Add(dr["inhouse_unit_1"].ToString());
                        cbo_unit.Items.Add(dr["inhouse_unit_2"].ToString());
                        cbo_unit.Items.Add(dr["inhouse_unit_3"].ToString());
                    }
                }
            }
        }

        private void txtprice_TextChanged(object sender, EventArgs e)
        {
            if (txtquanitity.Text.Length > 0)
            {
                txtsingletotal.Text = (Convert.ToDecimal(txtquanitity.Text) * Convert.ToDecimal(txtprice.Text)).ToString();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["cal_remove"].Index && e.RowIndex >= 0)
            {

                int purchase_return_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_product_return"].Value);
                int delete = blpr.DeleteProduct(Convert.ToInt32(purchase_return_id));
                if (delete > 0)
                {
                    MessageBox.Show("Successfully Deleted");
                }


            }

        }

        private void btn_back_Click(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txt_tax_amount.Text == "" || txt_bill_no.Text == "" || txtdiscount.Text == "")
            {
                txt_bill_no.Text = "0.00";
                txt_tax_amount.Text = "0.00";
                txtdiscount.Text = "0.00";
            }
            string today = DateTime.Now.ToString();
            int k = blpr.InsertPurchasereturn(Convert.ToInt32(cmb_category.SelectedValue), Convert.ToInt32(cmb_product.SelectedValue),quantity, cbo_unit.Text, Convert.ToDecimal(txtprice.Text), Convert.ToDecimal(txtdiscount.Text), Convert.ToDecimal(txtsingletotal.Text), Convert.ToDateTime(dtpexpirydate.Text), Convert.ToDecimal(txt_tax_amount.Text), Convert.ToDateTime(today), cbopono.Text, cmb_supplier.Text, Convert.ToDecimal(txttotal.Text), cboreceived_by.Text, Convert.ToDecimal(txtgrandtotal.Text), (txt_bill_no.Text));
            int update = blpr.updatestock(Convert.ToInt32(cmb_category.SelectedValue), Convert.ToInt32(cmb_product.SelectedValue),quantity);
            //if (update>0)
            //{
            //    MessageBox.Show("updated also");}

            if (k > 0)
            {
                MessageBox.Show("inserted successfully");
            }
            invoice_no();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        int purchase_id;
        private void cbopono_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  DataTable dt = blpr.getdatabypurchase(cbopono.SelectedValue));
            
            
        }
    }
}

