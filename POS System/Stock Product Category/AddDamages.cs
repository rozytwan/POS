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
    public partial class AddDamages : UserControl
    {
        public AddDamages()
        {
            InitializeComponent();
        }
        BLLdamage bld = new BLLdamage();
        BLLPurchase blpur = new BLLPurchase();
        BLLpurchasereturn blpr = new BLLpurchasereturn();
        BLLStockCategory blsc = new BLLStockCategory();
        BLLCategory blcat = new BLLCategory();
        BLLProduct blpro = new BLLProduct();
        BLLStock bls = new BLLStock();
  
        private void btn_back_Click(object sender, EventArgs e)
        {

        }
        public void category()
        {
            DataTable dt = blcat.getallcategory();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["category_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cbo_category.DataSource = dt;
                cbo_category.DisplayMember = "category_name";
                cbo_category.ValueMember = "category_id";
            }
        }
     
        private void AddDamages_Load(object sender, EventArgs e)
        {
          
         txt_username.Text= Login.sendtext;
          LoadDamage();
           // category();
        }
        public void LoadDamage()
        {
            DataTable dt = bld.GetDamage();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                   int category_id = Convert.ToInt32(dt.Rows[i]["category_id"].ToString());
                    DataTable dt1 = blsc.GetCategory(category_id);
                    dataGridView1.Rows[i].Cells["col_category_name"].Value = dt1.Rows[0]["category_name"].ToString();
                   int product_id = Convert.ToInt32(dt.Rows[i]["product_id"].ToString());
                    DataTable dt2 = blsc.GetQtybyProductid(product_id);
                    dataGridView1.Rows[i].Cells["col_product_name"].Value = dt2.Rows[0]["product_name"].ToString();
                    dataGridView1.Rows[i].Cells["col_unit"].Value = dt.Rows[i]["unit"].ToString();
                    dataGridView1.Rows[i].Cells["col_qty"].Value = dt.Rows[i]["quantity"].ToString();
                    dataGridView1.Rows[i].Cells["col_username"].Value = dt.Rows[i]["user_name"].ToString();
                    dataGridView1.Rows[i].Cells["col_date"].Value = dt.Rows[i]["date"].ToString();
                    dataGridView1.Rows[i].Cells["col_note"].Value = dt.Rows[i]["note"].ToString();
                }
            }

        }
       
        private void btnadd_Click(object sender, EventArgs e)
        {
            int category_id = Damages.category_id;
            int product_id = Damages.product_id;
            int department_id = Damages.department_id;
            var today = DateTime.Now.ToShortDateString();
            if ((txt_damage_qty.Text) == "" || cmb_damage_unit.Text == "" || txt_damage_qty.Text == "0.00" || rich_note.Text=="")
            {
                MessageBox.Show("Please fill required fields");
            }
            else
            {
                quantityConverter();
                int insert = bld.InsertDamage(category_id, product_id, txt_username.Text, Convert.ToDateTime(today),quantity, cmb_damage_unit.Text, rich_note.Text);
                int AddStockLog = bls.createstockLog(category_id, product_id, Convert.ToDecimal(txt_damage_qty.Text), department_id, lbl_location.Text, cmb_damage_unit.Text, Convert.ToDateTime(DateTime.Now.ToString()), "Damages");
                int update = blpr.updatestockdamage(category_id, product_id,lbl_location.Text, quantity);
                if (insert > 0)
                    {
                    MessageBox.Show("Inserted Successfully");
                    LoadDamage();
                    ClearallTextbox(this);
                    clearcombo(this);
                    rich_note.Text = "";
                    }
                if (cbo_category.Text == "" || cbo_product.Text == "")
                {
                    cbo_category.Enabled = false;
                    cbo_product.Enabled = false;
                    cmb_damage_unit.Enabled = false;
                    txt_damage_qty.Enabled = false;
                    rich_note.Enabled = false;
                    cmb_unit.Enabled = false;
                }
  }
        }
        decimal quantity = 0;
 
        public void quantityConverter()
        {
            if (cmb_damage_unit.Text.Length > 0)
            {
                DataTable dt = blsc.SearchProductbyName((cbo_product.Text));
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["inhouse_unit_1"].ToString() == cmb_damage_unit.Text)
                    {
                        if (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]) > 0)
                        {
                            quantity = (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_2"]) * Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]) * Convert.ToDecimal(txt_damage_qty.Text));
                        }
                        else if (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_2"]) > 0)
                        {
                            quantity = Convert.ToDecimal(dt.Rows[0]["inhouse_qty_2"]) * Convert.ToDecimal(txt_damage_qty.Text);
                        }
                        else
                        {
                            quantity = Convert.ToDecimal(txt_damage_qty.Text);
                        }
                    }
                    else if (dt.Rows[0]["inhouse_unit_2"].ToString() == cmb_damage_unit.Text)
                    {
                        if (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]) > 0)
                        {
                            quantity = (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]) * Convert.ToDecimal(txt_damage_qty.Text));
                        }
                        else
                        {
                            quantity = Convert.ToDecimal(txt_damage_qty.Text);
                        }
                    }
                    else
                    {
                        quantity = Convert.ToDecimal(txt_damage_qty.Text);
                    }
                }
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

        private void txt_damage_qty_TextChanged(object sender, EventArgs e)
        {
            if (cbo_product.Text != "Choose One")
            {
                int product_id = Damages.product_id;
                DataTable dt = blpur.getpurchasebyproduct(product_id);
                if (dt.Rows.Count > 0)
                {
                    cmb_damage_unit.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        cmb_damage_unit.Items.Add(dr["inhouse_unit_1"].ToString());
                        cmb_damage_unit.Items.Add(dr["inhouse_unit_2"].ToString());
                        cmb_damage_unit.Items.Add(dr["inhouse_unit_3"].ToString());
                    }
                }
            }
        }

        private void btn_back_Click_1(object sender, EventArgs e)
        {
            Control ctrl = this.Parent;
            Damages dm = new Damages();
            ctrl.Controls.Clear();
            ctrl.Controls.Add(dm);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col_edit"].Index && e.RowIndex >= 0)
 {
                txtquantity.Text = dataGridView1.CurrentRow.Cells["col_qty"].Value.ToString();
                cbo_category.Text = dataGridView1.CurrentRow.Cells["col_category_name"].Value.ToString();
                cbo_product.Text = dataGridView1.CurrentRow.Cells["col_product_name"].Value.ToString();

                txt_damage_qty.Text = dataGridView1.CurrentRow.Cells["col_qty"].Value.ToString();
                cmb_damage_unit.Text = dataGridView1.CurrentRow.Cells["col_unit"].Value.ToString();
                
            }
        }

        private void txt_damage_qty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmb_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_category.SelectedIndex != 0)
            {
                DataTable dt = blpro.getproductid(Convert.ToInt32(cbo_category.SelectedValue.ToString()));
                if (dt.Rows.Count > 0)
                {

                    DataRow dr = dt.NewRow();
                    dr["product_name"] = "Choose One";
                    dt.Rows.InsertAt(dr, 0);
                    cbo_product.DataSource = dt;
                    cbo_product.DisplayMember = "product_name";
                    cbo_product.ValueMember = "product_id";
                }
            }
        }

        private void cbo_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_product.SelectedIndex > 0 && cbo_product.Text != "Choose One")
            {
                DataTable dt = blpur.getpurchasebyproduct(Convert.ToInt32(cbo_product.SelectedValue));
                DataTable dt1 = blsc.GetDepartmentbyproduct_id(Convert.ToInt32(cbo_category.SelectedValue), Convert.ToInt32(cbo_product.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    cmb_damage_unit.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        cmb_damage_unit.Items.Add(dr["inhouse_unit_1"].ToString());
                        cmb_damage_unit.Items.Add(dr["inhouse_unit_2"].ToString());
                        cmb_damage_unit.Items.Add(dr["inhouse_unit_3"].ToString());
                    }
                }
                if (dt1.Rows.Count>0)
                {
                    txtquantity.Text = dt1.Rows[0]["qty"].ToString();
                 }
            }
          
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
