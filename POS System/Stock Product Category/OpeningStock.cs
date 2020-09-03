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
    public partial class OpeningStock : UserControl

    {
        public OpeningStock()
        {
            InitializeComponent();
        }
        BLLStockCategory blsc = new BLLStockCategory();
        BLLStock bls = new BLLStock();
        //BLLProduct bllc = new BLLProduct();
        //BLLPurchase blpur = new BLLPurchase();
        int category_id;
        int product_id;
        int department_id;
        private void AddProduct_Load(object sender, EventArgs e)
        {
            department();
            product_id = ProductList.product_id;
            category_id = ProductList.category_id;
            cbo_location.SelectedIndex = 0;
        }

        public void clear()
        {
            txt_quantity.Text = "";
            txt_category.Text = "";
            txt_department.Text = "";
            txt_name.Text = "";
            cmb_unit.Text = "";
           
        }
        decimal quantity = 0;
        public void quantityConverter()
        {
            if (cmb_unit.Text.Length > 0)
            {
                DataTable dt = blsc.SearchProductbyName((txt_name.Text));
                if (dt.Rows.Count > 0)
                {
                    if ((dt.Rows[0]["inhouse_qty_3"]) == DBNull.Value)
                    {
                        (dt.Rows[0]["inhouse_qty_3"]) = 0;
                    }
                    if ((dt.Rows[0]["inhouse_qty_2"]) == DBNull.Value)
                    {
                        (dt.Rows[0]["inhouse_qty_2"]) = 0;
                    }
                    if (dt.Rows[0]["inhouse_unit_1"].ToString() == cmb_unit.Text)
                    {
                        if (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]) > 0)
                        {
                            quantity = (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_2"]) * Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]) * Convert.ToDecimal(txt_quantity.Text));
                        }
                        else if (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_2"]) > 0)
                        {
                            quantity = Convert.ToDecimal(dt.Rows[0]["inhouse_qty_2"]) * Convert.ToDecimal(txt_quantity.Text);
                        }
                        else
                        {
                            quantity = Convert.ToDecimal(txt_quantity.Text);
                        }
                    }
                    else if (dt.Rows[0]["inhouse_unit_2"].ToString() == cmb_unit.Text)
                    {
                        if (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]) > 0)
                        {
                            quantity = (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]) * Convert.ToDecimal(txt_quantity.Text));
                        }
                        else
                        {
                            quantity = Convert.ToDecimal(txt_quantity.Text);
                        }
                    }
                    else
                    {
                        quantity = Convert.ToDecimal(txt_quantity.Text);
                    }
                }
            }
        }
         public void department()
         {
            category_id = ProductList.category_id;
            product_id = ProductList.product_id;
            department_id = ProductList.dept_id;
            DataTable dt = blsc.GetDepartmentbyproduct_id(category_id, product_id);
            if (dt.Rows.Count > 0)
            {

                cbo_location.Text = Convert.ToString(dt.Rows[0]["location"].ToString());
            }
            DataTable dt1 = blsc.GetDepartment(department_id);
            if (dt1.Rows.Count > 0)
            {
                txt_department.Text = Convert.ToString(dt1.Rows[0]["department"].ToString());
            }

        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_quantity.Text == "" || cmb_unit.Text == "" || txt_department.Text == "" || cbo_location.Text == "")
            {
                MessageBox.Show("Quantity and Uint is Required");
            }

            else if (txt_quantity.Text != "" && cmb_unit.Text != "" && txt_department.Text != "" && cbo_location.Text != "")
            {
                quantityConverter();

                int k = bls.createstock(category_id, product_id, quantity, department_id, cbo_location.Text, cmb_unit.Text);
               
                if (k > 0)
                {
                    int AddStockLog = bls.createstockLog(category_id, product_id, Convert.ToDecimal(txt_quantity.Text), department_id, cbo_location.Text, cmb_unit.Text, Convert.ToDateTime(DateTime.Now.ToString()), "Opening");
                    MessageBox.Show("Added successfully to stock", "Add Stock", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                clear();
            }

        }


        private void txt_quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&(e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            ProductList pl = new ProductList();
            ctls.Controls.Clear();
            ctls.Controls.Add(pl);
            
        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {

            if (txt_name.Text != "")
            {
                DataTable dt = blsc.SearchProductbyName(txt_name.Text);
                if (dt.Rows.Count > 0)
                {
                    cmb_unit.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        cmb_unit.Items.Add(dr["inhouse_unit_1"].ToString());
                        cmb_unit.Items.Add(dr["inhouse_unit_2"].ToString());
                        cmb_unit.Items.Add(dr["inhouse_unit_3"].ToString());
                    }
                    cmb_unit.SelectedIndex = 0;
                }
            }
        }
    }
}
