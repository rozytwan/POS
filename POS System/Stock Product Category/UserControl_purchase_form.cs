using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLS;
using POS_System.Stock_Product_Category;
using POS_System;

namespace POS_System
{
    public partial class UserControl_purchase_form : UserControl
    {
        public UserControl_purchase_form()
        {
            InitializeComponent();

            txt_tax_amount.Text = "0.00";
            this.txt_tax_amount.Leave += new System.EventHandler(this.txtpaidamount_Leave);
            this.txt_tax_amount.Enter += new System.EventHandler(this.txtpaidamount_Enter);

            txtdiscount.Text = "0.00";
            this.txtdiscount.Leave += new System.EventHandler(this.txtdiscount_Leave);
            this.txtdiscount.Enter += new System.EventHandler(this.txtdiscount_Enter);
            txt_tax_amount.Text = "0.00";
            this.txt_tax_amount.Leave += new System.EventHandler(this.txtremainingamount_Leave);
            this.txt_tax_amount.Enter += new System.EventHandler(this.txtremainingamount_Enter);

        }
        BLLInvoice blin = new BLLInvoice();
        BLLCategory blcat = new BLLCategory();
        BLLProduct blpro = new BLLProduct();
        BLLPurchase blpur = new BLLPurchase();
        BLLStock bls = new BLLStock();
        BLLSupplier_details blsupp = new BLLSupplier_details();
        BLLPurchase bllp = new BLLPurchase();
        BLLUser blu = new BLLUser();
        string bill_no = SupplierPayment.bill_no;
        string supplier_names = SupplierPurchase.supplier_name;
        DateTime purchase_date = SupplierPayment.purchase_date;
       
        int purchase_id;
        int product_id;
        string unit;
      
        private void UserControl_purchase_form_Load(object sender, EventArgs e)
        {
            string bill_no = SupplierPayment.bill_no;
            string supplier_names = SupplierPurchase.supplier_name;
                btn_edit.Visible = false;
                btnsave.Visible = true;
                txtcustomername.Focus();
                supplier_name();
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(11, 81, 126);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.ColumnHeadersHeight = 60;
                dtp_invoice.Text = DateTime.Today.ToShortDateString();
                userLoad();
                category();
                invoice_no();

            if (bill_no != "" && supplier_names != "" && supplier_names != "Choose One")
            {
                btn_edit.Visible = true;
                btnsave.Visible = false;
                DataTable dt = blpur.GetReturnPurchase(supplier_names, bill_no);
                txt_bill_no.Text = dt.Rows[0]["bill_no"].ToString();
                cbopono.Text = dt.Rows[0]["po_no"].ToString();
                txtcustomername.Text = dt.Rows[0]["supplier_name"].ToString();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                       
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["col_purchaseid"].Value = dt.Rows[i]["purchase_id"].ToString();
                        purchase_id = Convert.ToInt32(dt.Rows[i]["purchase_id"].ToString());
                        dataGridView1.Rows[i].Cells["calcategoryid"].Value = dt.Rows[i]["category_id"].ToString();
                        dataGridView1.Rows[i].Cells["calproductid"].Value = dt.Rows[i]["product_id"].ToString();
                        product_id = Convert.ToInt32(dt.Rows[i]["product_id"].ToString());
                        dataGridView1.Rows[i].Cells["calcategoryname"].Value = dt.Rows[i]["category_name"].ToString();
                        dataGridView1.Rows[i].Cells["calproductname"].Value = dt.Rows[i]["product_name"].ToString();
                        dataGridView1.Rows[i].Cells["cal_unit"].Value = dt.Rows[i]["unit"].ToString();
                        unit =(dt.Rows[i]["unit"].ToString());
                        DataTable dt1 = blpur.getpurchasebyproduct(Convert.ToInt32(product_id));
                        if (dt1.Rows.Count > 0)
                        {
                            if (dt1.Rows[0]["inhouse_unit_1"].ToString() == unit)
                            {
                                if (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]) > 0)
                                {
                                    quantity = (Convert.ToDecimal(dt1.Rows[0]["inhouse_qty_2"]) * Convert.ToDecimal(dt1.Rows[0]["inhouse_qty_3"]) * Convert.ToDecimal(dt.Rows[i]["qty"].ToString()));
                                }
                                else if (Convert.ToDecimal(dt1.Rows[0]["inhouse_qty_2"]) > 0)
                                { 
                                    quantity = Convert.ToDecimal(dt1.Rows[0]["inhouse_qty_2"]) * Convert.ToDecimal(dt.Rows[i]["qty"].ToString());
                                }
                                else
                                {
                                    quantity = Convert.ToDecimal(dt.Rows[i]["qty"].ToString());
                                }
                            }

                            else if (dt1.Rows[0]["inhouse_unit_2"].ToString() ==unit)
                            {
                                if (Convert.ToDecimal(dt1.Rows[0]["inhouse_qty_3"]) > 0)
                                {
                                    quantity = (Convert.ToDecimal(dt1.Rows[0]["inhouse_qty_3"]) * Convert.ToDecimal(dt.Rows[i]["qty"].ToString()));
                                }
                                else
                                {
                                    quantity = Convert.ToDecimal(dt.Rows[i]["qty"].ToString());
                                }
                            }
                            else
                            {
                                quantity = Convert.ToDecimal(dt.Rows[i]["qty"].ToString());
                            }

                        }

                        dataGridView1.Rows[i].Cells["calprice"].Value = dt.Rows[i]["price"].ToString();
                       
                        dataGridView1.Rows[i].Cells["calquantity"].Value = quantity;
                        dataGridView1.Rows[i].Cells["cal_bill_no"].Value = dt.Rows[i]["bill_no"].ToString();
                        dataGridView1.Rows[i].Cells["caltotal"].Value = dt.Rows[i]["total"].ToString();
                        dataGridView1.Rows[i].Cells["calexpirydate"].Value = dt.Rows[i]["expiry_date"].ToString();
                        dataGridView1.Rows[i].Cells["calponno"].Value = dt.Rows[i]["po_no"].ToString();
                        dataGridView1.Rows[i].Cells["calpurchase_date"].Value = dt.Rows[i]["purchase_date"].ToString();
                        dataGridView1.Rows[i].Cells["calsupplier_name"].Value = dt.Rows[i]["supplier_name"].ToString();
                        txtgrandtotal.Text = dt.Rows[0]["grand_total"].ToString();
                        //  dataGridView1.Rows[i].Cells["cal_static_qty"].Value = dt.Rows[i]["static_qty"].ToString();

                    }
                }
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


        public void category()
        {
            DataTable dt = blcat.getallcategory();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["category_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cbocategorynamess.DataSource = dt;
                cbocategorynamess.DisplayMember = "category_name";
                cbocategorynamess.ValueMember = "category_id";
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
                txtcustomername.DataSource = dt;
                txtcustomername.DisplayMember = "name";
                txtcustomername.ValueMember = "name";
            }
        }

        private void btnadd_Click_1(object sender, EventArgs e)
        {
            if (txtinvoiceno.Text == "" || cboproductname.Text == "Choose One" || cboproductname.Text == "" || txtquanitity.Text == "" || txtcustomername.Text == "" || cbocategorynamess.Text == "Choose one" || txtprice.Text == "" || cbopono.Text == "" || txtsingletotal.Text == "" || txtcustomername.Text == "Choose one" || cbo_unit.Text == "")
            {
                MessageBox.Show("Please Fill Required Fields");
            }
            else if (txt_bill_no.Text == "")
            {
                MessageBox.Show("Bill No. Is Required", "Bill No. Required Alert !!");
            }
            else
            {
                quanityConverter();
                int i=dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["calcategoryid"].Value = cbocategorynamess.SelectedValue.ToString();
                    dataGridView1.Rows[i].Cells["calproductid"].Value = cboproductname.SelectedValue.ToString();
                    dataGridView1.Rows[i].Cells["calcategoryname"].Value = cbocategorynamess.Text;
                    dataGridView1.Rows[i].Cells["calproductname"].Value = cboproductname.Text;
                    dataGridView1.Rows[i].Cells["calprice"].Value = txtprice.Text;
                    dataGridView1.Rows[i].Cells["cal_unit"].Value = cbo_unit.Text;
                    dataGridView1.Rows[i].Cells["calquantity"].Value = quantity.ToString();
                    dataGridView1.Rows[i].Cells["cal_bill_no"].Value = txt_bill_no.Text;
                    dataGridView1.Rows[i].Cells["caltotal"].Value = txtsingletotal.Text;
                    dataGridView1.Rows[i].Cells["calexpirydate"].Value = dtpexpirydate.Text;                  
                    dataGridView1.Rows[i].Cells["calponno"].Value = cbopono.Text;                  
                    dataGridView1.Rows[i].Cells["calpurchase_date"].Value =DateTime.Now.ToShortDateString();
                    dataGridView1.Rows[i].Cells["calsupplier_name"].Value = txtcustomername.Text;
                    dataGridView1.Rows[i].Cells["cal_static_qty"].Value = txtquanitity.Text;
                    dataGridView1.Rows[i].Cells["col_purchaseid"].Value = "";
                i++;
                    txtgrandtotal.Text = (Convert.ToDecimal(txtgrandtotal.Text) + Convert.ToDecimal(txtsingletotal.Text)).ToString();
                    txttotal.Text = txtgrandtotal.Text;                                     
                   ClearallTextbox(panelEx1);
                   clears();
                  // clearcombo(panelEx1);
                   // supplier_name();
                    category();
               
            }
        }
        decimal quantity = 0;
        public void quanityConverter()
        {
            if (cboproductname.SelectedIndex > 0 && cbo_unit.Text.Length > 0 || cbo_unit.SelectedIndex > 0)
            {
                DataTable dt = blpur.getpurchasebyproduct(Convert.ToInt32(cboproductname.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["inhouse_unit_1"].ToString() == cbo_unit.Text)
                    {
                        if (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]) > 0)
                        {
                            quantity = (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_2"]) * Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]) * Convert.ToDecimal(txtquanitity.Text));
                        }
                        else if (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_2"]) > 0)
                        {
                            quantity = Convert.ToDecimal(dt.Rows[0]["inhouse_qty_2"]) * Convert.ToDecimal(txtquanitity.Text);
                        }
                        else
                        {
                            quantity = Convert.ToDecimal(txtquanitity.Text);
                        }
                    }
                
                    else if (dt.Rows[0]["inhouse_unit_2"].ToString() == cbo_unit.Text)
                    {
                        if (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]) > 0)
                        {
                            quantity = (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]) * Convert.ToDecimal(txtquanitity.Text));
                        }
                        else
                        {
                            quantity = Convert.ToDecimal(txtquanitity.Text);
                        }
                    }
                    else
                    {
                        quantity = Convert.ToDecimal(txtquanitity.Text);
                    }

                }
                    
            }
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
        public void clears()
        {
            cbocategorynamess.SelectedIndex = 0;
            cboproductname.SelectedIndex = 0;
        }
        private void cbocategorynamess_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbocategorynamess.SelectedIndex != 0)
            {
                DataTable dt = blpro.getproductid(Convert.ToInt32(cbocategorynamess.SelectedValue.ToString()));
                if (dt.Rows.Count > 0)
                {
                 
                    DataRow dr = dt.NewRow();
                    dr["product_name"] = "Choose One";
                    dt.Rows.InsertAt(dr, 0);
                    cboproductname.DataSource = dt;
                    cboproductname.DisplayMember = "product_name";
                    cboproductname.ValueMember = "product_id";
                }
            }
        }
 
        private void txtprice_TextChanged(object sender, EventArgs e)
        {
            if (txtquanitity.Text.Length > 0&& txtprice.Text.Length > 0)
            {
                txtsingletotal.Text = (Convert.ToDecimal(txtquanitity.Text) * Convert.ToDecimal(txtprice.Text)).ToString();
            }
        }

        private void btnremove_Click(object sender, EventArgs e)
        {
           //foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
           //     {

           //     txttotal.Text = txtgrandtotal.Text;
           //     decimal total_to_be_remove = Convert.ToDecimal(dr.Cells["caltotal"].Value);
           //     txtgrandtotal.Text = (Convert.ToDecimal(txtgrandtotal.Text) - Convert.ToDecimal(total_to_be_remove)).ToString();
           //     dataGridView1.Rows.Remove(dr);

           // }
          
        }
       
        private void btnsave_Click(object sender, EventArgs e)
        {
            if (cboreceived_by.Text=="Choose One" || cboreceived_by.Text=="")
            {
                MessageBox.Show("Receiver Name is Required", "Receiver Name Alert !!");
            }
        
            else if (dataGridView1.Rows.Count > 0 || txttotal.Text != "" || txtgrandtotal.Text != "")
            {
               
               stock();
                purchase_add();
               // supplier_name();
                MessageBox.Show("Data has been saved");
                DataTable dt = bls.GetSupplier_Amount(txtcustomername.Text);
                decimal amount = Convert.ToDecimal(dt.Rows[0]["grand_total"].ToString());
                PurchasePay pp = new PurchasePay(txtcustomername.Text, amount);
                supplier_names = txtcustomername.Text;
                pp.Show();
                ClearallTextbox(panelEx1);
                clear();
                bill_no = "";
               txtcustomername.SelectedIndex=0;
                
            }
            else
            {
                MessageBox.Show("Add Data to Table First.", "Grid Row Empty error::");
            }
            invoice_no();
           
        }
        
        public void clear()
        {
            txttotal.Text = "0.00";
            txt_tax_amount.Text = "0.00";
            txtgrandtotal.Text = "0.00";
            txtdiscount.Text = "0.00";
            cboreceived_by.Text = "";
        }
        DataTable dt1 = new DataTable();
        DataTable dt = new DataTable();
        string fiscal_year;
            public void purchase_add()
            {
            int i = blin.createinvoice(Convert.ToInt32(txtinvoiceno.Text), Convert.ToDateTime(dtp_invoice.Text));
            if (i > 0)
            {
                        for (int j = 0; j < dataGridView1.Rows.Count; j++)
                        {
                            if (dataGridView1.Rows[j].Cells["col_purchaseid"].Value.ToString() == "")
                            {
                            int category_id = Convert.ToInt32(dataGridView1.Rows[j].Cells["calcategoryid"].Value.ToString());
                            int product_id = Convert.ToInt32(dataGridView1.Rows[j].Cells["calproductid"].Value.ToString());
                            string unit = (dataGridView1.Rows[j].Cells["cal_unit"].Value.ToString());
                            decimal price = Convert.ToDecimal(dataGridView1.Rows[j].Cells["calprice"].Value.ToString());
                            decimal qty = Convert.ToDecimal(dataGridView1.Rows[j].Cells["calquantity"].Value.ToString());
                            decimal total = Convert.ToDecimal(dataGridView1.Rows[j].Cells["caltotal"].Value.ToString());
                            DateTime expiry_date = Convert.ToDateTime(dataGridView1.Rows[j].Cells["calexpirydate"].Value.ToString());
                            string po_no = dataGridView1.Rows[j].Cells["calponno"].Value.ToString();
                            string supplier_name = dataGridView1.Rows[j].Cells["calsupplier_name"].Value.ToString();
                            string static_qty = dataGridView1.Rows[j].Cells["cal_static_qty"].Value.ToString();
                            int k = blpur.createpurhase(category_id, product_id, Convert.ToDecimal(static_qty), unit, Convert.ToInt32(txtinvoiceno.Text), price, Convert.ToDecimal(txtdiscount.Text), total, expiry_date, Convert.ToDateTime(dtp_invoice.Text), po_no, supplier_name, Convert.ToDecimal(txttotal.Text), Convert.ToDecimal(txt_tax_amount.Text), cboreceived_by.Text, Convert.ToDecimal(txtgrandtotal.Text), txt_bill_no.Text);
                            dt = bls.getfiscalyear();
                             dt1 = bls.GetInventoryCategory();
                        if (dt.Rows.Count > 0 && dt1.Rows.Count > 0)
                        {
                            fiscal_year = dt.Rows[0]["fiscal_year"].ToString();
                        }
                        int category_ids = Convert.ToInt32(dt1.Rows[0]["category_id"].ToString());
                        //int insert = bls.InsertTransaction(category_ids, "Inventory", Convert.ToDateTime(txtinvoicedate.Text), txtcustomername.Text, Convert.ToDecimal(txtgrandtotal.Text), fiscal_year, "Credit");

                    }

                }
               
                 dataGridView1.Rows.Clear();
            }
        }

        private void btncalculateamount_Click(object sender, EventArgs e)
        {
            clearcombo(this);
            ClearallTextbox(this);
            clear();
            dataGridView1.Rows.Clear();
            category();
            supplier_name();
        }
        BLLStockCategory blsc = new BLLStockCategory();
        int department_id;
        public void stock()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                
                    for (int l = 0; l < dataGridView1.Rows.Count; l++)
                        {
                            if (dataGridView1.Rows[l].Cells["col_purchaseid"].Value.ToString()=="")
                            {
                                int category_id = Convert.ToInt32(dataGridView1.Rows[l].Cells["calcategoryid"].Value.ToString());
                            int product_id = Convert.ToInt32(dataGridView1.Rows[l].Cells["calproductid"].Value.ToString());
                            string unit = (dataGridView1.Rows[l].Cells["cal_unit"].Value.ToString());
                            decimal quantity = Convert.ToDecimal(dataGridView1.Rows[l].Cells["calquantity"].Value.ToString());
                            DateTime expiry_date = Convert.ToDateTime(dataGridView1.Rows[l].Cells["calexpirydate"].Value.ToString());
                            string static_qty = dataGridView1.Rows[l].Cells["cal_static_qty"].Value.ToString();
                            DataTable dt = blsc.Getproductbyid(product_id.ToString());
                            if (dt.Rows.Count > 0)
                            {
                                department_id = Convert.ToInt32(dt.Rows[0]["department_id"].ToString());
                            }
                            int k = bls.createstock(category_id, product_id, quantity, department_id, "M", unit);
                            if (k > 0)
                            {
                                int addStockLog = bls.createstockLog(category_id, product_id, Convert.ToDecimal(static_qty), department_id, "M", unit, Convert.ToDateTime(DateTime.Now.ToString()), "Received");
                                ClearallTextbox(panelEx1);
                                //  clearcombo(panelEx1);
                            }
                        }
                    }
                }
            }
        
        private void btn_back_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            allmenu alls = new allmenu();
            ctls.Controls.Clear();
            ctls.Controls.Add(alls);
        }

        private void txtcustomername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();
                }
            }
        }

        private void cbocategorynamess_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();

                }
            }
        }

        private void txtprice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();

                }
            }
        }

        private void txtpaidamount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();

                }
            }
        }

        private void txttotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();

                }
            }
        }

      

        private void txtdiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtdiscount.Text.Length > 0 && txtdiscount.Text.Length > 0)
            {
                txtgrandtotal.Text = Convert.ToString(Convert.ToDecimal(txttotal.Text) + Convert.ToDecimal(txt_tax_amount.Text) - Convert.ToDecimal(txtdiscount.Text));
            }

        }

        private void txtquanitity_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtprice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtdiscount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtpaidamount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtremainingamount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txttotal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtgrandtotal_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtdiscount_Leave(object sender, EventArgs e)
        {
            if (txtdiscount.Text == "")
            {
                txtdiscount.Text = "0.00";
            }
        }

        private void txtdiscount_Enter(object sender, EventArgs e)
        {
            if (txtdiscount.Text == "0.00")
            {
                txtdiscount.Text = "";
            }
        }

        private void txtpaidamount_Leave(object sender, EventArgs e)
        {
            if (txt_tax_amount.Text == "")
            {
                txt_tax_amount.Text = "0.00";
            }
        }

        private void txtpaidamount_Enter(object sender, EventArgs e)
        {
            if (txt_tax_amount.Text == "0.00")
            {
                txt_tax_amount.Text = "";
            }
        }

        private void txtremainingamount_Leave(object sender, EventArgs e)
        {
            if (txt_tax_amount.Text == "")
            {
                txt_tax_amount.Text = "0.00";
            }
        }

        private void txtremainingamount_Enter(object sender, EventArgs e)
        {
            if (txt_tax_amount.Text == "0.00")
            {
                txt_tax_amount.Text = "";
            }
        }

        private void cboproductname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboproductname.SelectedIndex > 0 && cboproductname.Text != "Choose One")
            {
                DataTable dt = blpur.getpurchasebyproduct(Convert.ToInt32(cboproductname.SelectedValue));
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
        
        private void cbopono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        public void calculate_total()
        {
            decimal sum = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                if (dataGridView1.Rows[i].Cells["caltotal"].Value.ToString() != "")
                {
                    sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells["caltotal"].Value);
                }
            }
            txttotal.Text = sum.ToString("F");
            if (txt_tax_amount.Text.Length > 0 && txt_tax_amount.Text.Length > 0)
            {
                txtgrandtotal.Text = Convert.ToString(Convert.ToDecimal(txttotal.Text) + Convert.ToDecimal(txt_tax_amount.Text) - Convert.ToDecimal(txtdiscount.Text));
            }

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["cal_remove"].Index && e.RowIndex >= 0)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["col_purchaseid"].Value.ToString() != "")
                {
                  
                    int category_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["calcategoryid"].Value);
                    int product_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["calproductid"].Value);
                    string unit = dataGridView1.Rows[e.RowIndex].Cells["cal_unit"].Value.ToString();
                    string supplier_name = dataGridView1.Rows[e.RowIndex].Cells["calsupplier_name"].Value.ToString();
                    DataTable dt = blsc.Getproductbyid(product_id.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        department_id = Convert.ToInt32(dt.Rows[0]["department_id"].ToString());
                    }
                    decimal quantity = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["calquantity"].Value.ToString());
                    int k = bls.DecreaseStock(category_id, product_id, quantity, department_id, "M", unit);
                    int delete = bllp.DeletePurchase(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["col_purchaseid"].Value));
                   int update = bllp.UpdatePurchaseGrandtotal(supplier_name, bill_no, Convert.ToDecimal(txtgrandtotal.Text));
                    dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                    calculate_total();
                }
                else
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[e.RowIndex]);
                    calculate_total();
                }
            }
        }

        private void txt_tax_amount_TextChanged(object sender, EventArgs e)
        {
            if (txt_tax_amount.Text.Length > 0 && txt_tax_amount.Text.Length > 0)
            {
                txtgrandtotal.Text = Convert.ToString(Convert.ToDecimal(txttotal.Text) + Convert.ToDecimal(txt_tax_amount.Text)- Convert.ToDecimal(txtdiscount.Text));
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (cboreceived_by.Text == "Choose One" || cboreceived_by.Text == "")
            {
                MessageBox.Show("Receiver Name is Required", "Receiver Name Alert !!");
            }
            if (txt_bill_no.Text == "")
            {
                MessageBox.Show("Bill No. Is Required", "Bill No. Required Alert !!");
            }
            else if (dataGridView1.Rows.Count > 0 || txttotal.Text != "" || txtgrandtotal.Text != "")
            {

                stock();
                purchase_add();
                int update = bllp.UpdatePurchaseGrandtotal(txtcustomername.Text, bill_no, Convert.ToDecimal(txtgrandtotal.Text));
                // supplier_name();
                MessageBox.Show("Data has been saved");
              
                ClearallTextbox(panelEx1);
                clear();
                txt_bill_no.Text = "";
                cbopono.Text = "";
                txtcustomername.SelectedIndex = 0;

            }
            else
            {
                MessageBox.Show("Add Data to Table First.", "Grid Row Empty error::");
            }
            invoice_no();
        }
    }
 }
  
