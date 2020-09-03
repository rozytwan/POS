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

namespace POS_Systems
{
    public partial class UserControl_Product : UserControl
    {
        public UserControl_Product()
        {
            InitializeComponent();
        }
        int product_id;

        BLLStockCategory blsc = new BLLStockCategory();
        private void UserControl_Product_Load(object sender, EventArgs e)
        {
            LoadCategory();
            LoadDepartment();
            //cmb_unit1.Text = "Choose Unit";
            //cmb_unit2.Text = "Choose Unit";
            //cmb_unit3.Text = "Choose Unit";
            LoadUnit1();

            LoadUnit2();
            LoadUnit3();
            product_id = StockProductList.product_id;
            btn_update.Hide();
            if (product_id > 0)
            {
                btn_save.Hide();
                btn_update.Show();
                DataTable dt = blsc.Getproductbyid(Convert.ToString(product_id));
                txt_product_name.Text = dt.Rows[0]["product_name"].ToString();
                int category_id = Convert.ToInt32(dt.Rows[0]["category_id"].ToString());
                DataTable dt1 = blsc.GetCategory(category_id);
                cmb_category.Text = dt1.Rows[0]["category_name"].ToString();
                int department_id = Convert.ToInt32(dt.Rows[0]["department_id"].ToString());
                DataTable dt2 = blsc.GetDepartment(department_id);
                cmb_department.Text = dt2.Rows[0]["department"].ToString();
                txt_quantity1.Text = dt.Rows[0]["inhouse_qty_1"].ToString();
                
                cmb_unit1.Text = dt.Rows[0]["inhouse_unit_1"].ToString();
                txt_quantity2.Text = dt.Rows[0]["inhouse_qty_2"].ToString();
                cmb_unit2.Text = dt.Rows[0]["inhouse_unit_2"].ToString();
                txt_quantity3.Text = dt.Rows[0]["inhouse_qty_3"].ToString();
                txt_min_stock.Text = dt.Rows[0]["min_stock"].ToString();
                cmb_unit3.Text = dt.Rows[0]["inhouse_unit_3"].ToString();

            }
           StockProductList.product_id = 0;
            //  btn_update.Enabled = false;
        }

        public void LoadCategory()
        {
            DataTable dt = blsc.GetCategories();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["category_name"] = "Choose Category";
                dt.Rows.InsertAt(dr, 0);

                cmb_category.DataSource = dt;
                cmb_category.DisplayMember = "category_name";
                cmb_category.ValueMember = "category_id";
            }
        }
        public void LoadDepartment()
        {
            DataTable dt = blsc.GetDepartment();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["department"] = "Choose Department";
                dt.Rows.InsertAt(dr, 0);

                cmb_department.DataSource = dt;
                cmb_department.DisplayMember = "department";
                cmb_department.ValueMember = "id";
            }
        }
        public void LoadUnit1()
        {
            DataTable dt = blsc.GetUnit();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["unit_name"] = "Choose unit";
                dt.Rows.InsertAt(dr, 0);
                cmb_unit1.DataSource = dt;
                cmb_unit1.DisplayMember = "unit_name";
                cmb_unit1.ValueMember = "inhouse_unit_id";
            }
        }
        public void LoadUnit2()
        {
            DataTable dt = blsc.GetUnit();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["unit_name"] = "Choose unit";
                dt.Rows.InsertAt(dr, 0);
                cmb_unit2.DataSource = dt;
                cmb_unit2.DisplayMember = "unit_name";
                cmb_unit2.ValueMember = "inhouse_unit_id";
            }
        }
        public void LoadUnit3()
        {
            DataTable dt = blsc.GetUnit();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["unit_name"] = "Choose unit";
                dt.Rows.InsertAt(dr, 0);

                cmb_unit3.DataSource = dt;
                cmb_unit3.DisplayMember = "unit_name";
                cmb_unit3.ValueMember = "inhouse_unit_id";
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            btn_update.Enabled = false;
            if (cmb_category.Text == "Choose Category" || txt_product_name.Text == "" || cmb_department.Text == "Choose Department" || txt_quantity1.Text != "" && cmb_unit1.Text == "Choose unit")
            {
                MessageBox.Show("Please fill the required fields");
            }
       
            if (txt_quantity2.Text!=""&& cmb_unit2.Text=="Choose unit")
            {
                MessageBox.Show("Choose Unit Is Required");
            }
            if (txt_quantity3.Text != "" && cmb_unit3.Text == "Choose unit")
            {
                MessageBox.Show("Choose Unit Is Required");
            }
        
           
            if (txt_min_stock.Text == "")
            {
                MessageBox.Show("Minimun Stock is required");
            }
            DataTable dt = blsc.SearchProductName(txt_product_name.Text);
            if (dt.Rows.Count > 0)
            {
                DialogResult dig = MessageBox.Show("This Product is already exist. Do you Like to Insert ??", "Already exist Alert !!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dig == DialogResult.Yes)
                {
                    int product_id = Convert.ToInt32(dt.Rows[0]["product_id"].ToString());
                    int delete = blsc.ActivateProduct(product_id);
                }

            }
          else if (cmb_category.Text != "Choose Category" && txt_product_name.Text != "" && cmb_department.Text != "Choose Department" && txt_quantity1.Text != "" && cmb_unit1.Text != "" && txt_quantity2.Text != "" && cmb_unit2.Text != "Choose unit" && txt_quantity3.Text != "" && cmb_unit3.Text != "Choose unit")
                {

                    int insert = blsc.InsertProduct(Convert.ToInt32(cmb_category.SelectedValue), txt_product_name.Text, Convert.ToInt32(cmb_department.SelectedValue), Convert.ToDecimal(txt_quantity1.Text), cmb_unit1.Text, Convert.ToDecimal(txt_quantity2.Text), cmb_unit2.Text, Convert.ToDecimal(txt_quantity3.Text), cmb_unit3.Text, txt_min_stock.Text);
                    if (insert > 0)
                    {
                        MessageBox.Show("Data inserted successfully");
                    }
                    clear();
                }
                else if (cmb_category.Text != "Choose Category" && txt_product_name.Text != "" && cmb_department.Text != "Choose Department" && txt_quantity1.Text != "" && cmb_unit1.Text != "Choose unit" && txt_quantity2.Text == "" && cmb_unit2.Text == "Choose unit" && txt_quantity3.Text == "" && cmb_unit3.Text == "Choose unit")
                {


                int insert = blsc.InsertProduct(Convert.ToInt32(cmb_category.SelectedValue), txt_product_name.Text, Convert.ToInt32(cmb_department.SelectedValue), Convert.ToDecimal(txt_quantity1.Text), cmb_unit1.Text, Convert.ToDecimal("0.00"), cmb_unit2.Text = "", Convert.ToDecimal("0.00"), cmb_unit3.Text = "", txt_min_stock.Text);
                    if (insert > 0)
                    {
                        MessageBox.Show("Data inserted successfully");
                    }
                    clear();
                }

                else if (cmb_category.Text != "" && txt_product_name.Text != "" && cmb_department.Text != "" && txt_quantity1.Text != "" && cmb_unit1.Text != "Choose unit" && txt_quantity2.Text != "" && cmb_unit2.Text != "Choose unit" && txt_quantity3.Text == "" && cmb_unit3.Text == "Choose unit")
                {
                if (cmb_unit3.Text == "Choose unit")
                {
                    cmb_unit3.Text = "";
                }
                int insert = blsc.InsertProduct(Convert.ToInt32(cmb_category.SelectedValue), txt_product_name.Text, Convert.ToInt32(cmb_department.SelectedValue), Convert.ToDecimal(txt_quantity1.Text), cmb_unit1.Text, Convert.ToDecimal(txt_quantity2.Text), cmb_unit2.Text, Convert.ToDecimal("0.00"), cmb_unit3.Text = "", txt_min_stock.Text);
                    if (insert > 0)
                    {
                        MessageBox.Show("Data inserted successfully");
                    }
                    clear();
                }


            }
  
        private void btn_back_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            StockProductList spl = new StockProductList();
            ctls.Controls.Clear();
            ctls.Controls.Add(spl);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (product_id > 0)
            {

                if (cmb_category.Text == "Choose Category" && txt_product_name.Text == "" && cmb_department.Text == "Choose Department" && txt_quantity1.Text == "" && cmb_unit1.Text == "Choose unit")
                {
                    MessageBox.Show("Please fill the required fields");
                }
                if (txt_quantity2.Text != "" && txt_quantity2.Text != "0.00" && txt_quantity2.Text != "0" && cmb_unit2.Text == "Choose unit")
                {
                    MessageBox.Show("Choose Unit Is Required");
                }
                if (txt_quantity3.Text != "" &&txt_quantity3.Text!="0.00"&&txt_quantity3.Text!="0" && cmb_unit3.Text == "Choose unit")
                {
                    MessageBox.Show("Choose Unit Is Required");
                }
                else if (cmb_category.Text != "Choose Category" && txt_product_name.Text != "" && cmb_department.Text != "Choose Department" && txt_quantity1.Text != "" && cmb_unit1.Text != "Choose unit" && txt_quantity2.Text != "" && cmb_unit2.Text != "Choose unit" && txt_quantity3.Text != "0.00" && cmb_unit3.Text != "Choose unit")
                {
                    int update = blsc.UpdateProduct(product_id, Convert.ToInt32(cmb_category.SelectedValue), txt_product_name.Text, Convert.ToInt32(cmb_department.SelectedValue), Convert.ToDecimal(txt_quantity1.Text), (cmb_unit1.Text), Convert.ToDecimal(txt_quantity2.Text), (cmb_unit2.Text), Convert.ToDecimal(txt_quantity3.Text), (cmb_unit3.Text), txt_min_stock.Text);
                    if (update > 0)
                    {
                        MessageBox.Show("Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    clear();
                    btn_update.Hide();
                    btn_save.Show();
                }
                else if (cmb_category.Text != "Choose Category" && txt_product_name.Text != "" && cmb_department.Text != "Choose Department" && txt_quantity1.Text != "" && cmb_unit1.Text != "Choose unit" && txt_quantity2.Text == "0.00"|| txt_quantity2.Text == "" && cmb_unit2.Text == "Choose unit" && txt_quantity3.Text == "0.00"|| txt_quantity3.Text == "" && cmb_unit3.Text == "Choose unit")
                {
                    int update = blsc.UpdateProduct(product_id, Convert.ToInt32(cmb_category.SelectedValue), txt_product_name.Text, Convert.ToInt32(cmb_department.SelectedValue), Convert.ToDecimal(txt_quantity1.Text), (cmb_unit1.Text), Convert.ToDecimal("0.00"), "", Convert.ToDecimal("0.00"), cmb_unit3.Text = "", txt_min_stock.Text);
                    if (update > 0)
                    {
                        MessageBox.Show("Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    clear();
                    btn_update.Hide();
                    btn_save.Show();
                }
                else if (cmb_category.Text != "Choose Category" && txt_product_name.Text != "" && cmb_department.Text != "Choose Department" && txt_quantity1.Text != "" && cmb_unit1.Text != "Choose unit" && txt_quantity2.Text != "" && cmb_unit2.Text != "Choose unit" && txt_quantity3.Text == "0.00"|| txt_quantity3.Text == "" && cmb_unit3.Text == "Choose unit")
                {
                    int update = blsc.UpdateProduct(product_id, Convert.ToInt32(cmb_category.SelectedValue), txt_product_name.Text, Convert.ToInt32(cmb_department.SelectedValue), Convert.ToDecimal(txt_quantity1.Text), (cmb_unit1.Text), Convert.ToDecimal(txt_quantity2.Text), (cmb_unit2.Text), Convert.ToDecimal("0.00"),"", txt_min_stock.Text);
                    if (update > 0)
                    {
                        MessageBox.Show("Updated Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    clear();
                    btn_update.Hide();
                    btn_save.Show();
                }
            
                
            }
            StockProductList.product_id = 0;
        }
        public void clear()
        {
            cmb_category.Text = "Choose Category";
            txt_product_name.Text = "";
            cmb_department.Text = "Choose Department";
            txt_quantity1.Text = "";
            txt_quantity2.Text = "";
            txt_quantity3.Text = "";
            txt_min_stock.Text = "";
            LoadUnit1();
            LoadUnit2();
            LoadUnit3();

        }

        private void List_Click(object sender, EventArgs e)
        {

            Control ctls = this.Parent;
            StockProductList spl = new StockProductList();
            ctls.Controls.Clear();
            ctls.Controls.Add(spl);
        }

        private void cmb_unit1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_back_Click_1(object sender, EventArgs e)
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
                StockProductList ucp = new StockProductList();
                ctls.Controls.Clear();
                ctls.Controls.Add(ucp);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
