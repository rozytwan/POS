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
    public partial class Damages : UserControl
    {
        public Damages()
        {
            InitializeComponent();
        }
        BLLStock blls = new BLLStock();
        BLLStockCategory blsc = new BLLStockCategory();
        private void btn_back_Click(object sender, EventArgs e)
        {

        }

        private void Damages_Load(object sender, EventArgs e)
        {
            LoadStock();
            cmb_choose.SelectedIndex = 0;
        }
        public void LoadStock()
        {
            DataTable dt = blls.getallstock();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_stock_id"].Value = dt.Rows[i]["stock_id"].ToString();
                    dataGridView1.Rows[i].Cells["col_category_id"].Value = dt.Rows[i]["category_id"].ToString();
                    dataGridView1.Rows[i].Cells["col_product_id"].Value = dt.Rows[i]["product_id"].ToString();
                    dataGridView1.Rows[i].Cells["col_departmentid"].Value = dt.Rows[i]["department_id"].ToString();
                    int category_id = Convert.ToInt32(dt.Rows[i]["category_id"].ToString());
                    DataTable dt1 = blsc.GetCategory(category_id);
                    if (dt1.Rows.Count>0)
                    {
                        dataGridView1.Rows[i].Cells["col_category_name"].Value = dt1.Rows[0]["category_name"].ToString();
                    }
                    int product_id = Convert.ToInt32(dt.Rows[i]["product_id"].ToString());
                    DataTable dt2 = blsc.GetQtybyProductid(product_id);
                    if (dt2.Rows.Count>0)
                    {
                        dataGridView1.Rows[i].Cells["col_product_name"].Value = dt2.Rows[0]["product_name"].ToString();
                    }
                  int department_id = Convert.ToInt32(dt.Rows[i]["department_id"].ToString());
                    DataTable dt3 = blsc.GetDepartment(department_id);
                    if (dt3.Rows.Count>0)
                    {
                        dataGridView1.Rows[i].Cells["col_department_name"].Value = dt3.Rows[0]["department"].ToString();
                    }
                
                    dataGridView1.Rows[i].Cells["col_unit"].Value = dt.Rows[i]["unit"].ToString();

                    dataGridView1.Rows[i].Cells["col_qty"].Value = dt.Rows[i]["qty"].ToString();

                    dataGridView1.Rows[i].Cells["col_location"].Value = dt.Rows[i]["location"].ToString();

                }
            }
        }
        public static int stock_id,category_id,product_id,department_id;

        private void cmb_choose_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            DataTable dt1 = blsc.GetCategory(category_id);
            DataTable dt2 = blsc.GetQtybyProductid(product_id);
            DataTable dt3 = blsc.GetDepartment(department_id);
            if (cmb_choose.SelectedIndex == -1)
            {
                cmb_choose.Text = "Search By";
            }
            if (cmb_choose.Text == "Product Name")
            {

                DataTable dt = blls.SearchbyProductname(txt_search.Text);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.ClearSelection();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["col_stock_id"].Value = dt.Rows[i]["stock_id"].ToString();
                        dataGridView1.Rows[i].Cells["col_category_id"].Value = dt.Rows[i]["category_id"].ToString();
                        dataGridView1.Rows[i].Cells["col_product_id"].Value = dt.Rows[i]["product_id"].ToString();
                        dataGridView1.Rows[i].Cells["col_departmentid"].Value = dt.Rows[i]["department_id"].ToString();
                        dataGridView1.Rows[i].Cells["col_category_name"].Value = dt.Rows[i]["category_name"].ToString();
                        dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();
                        dataGridView1.Rows[i].Cells["col_department_name"].Value = dt.Rows[i]["department"].ToString();
                        dataGridView1.Rows[i].Cells["col_stock_id"].Value = dt.Rows[i]["stock_id"].ToString();

                        dataGridView1.Rows[i].Cells["col_unit"].Value = dt.Rows[i]["unit"].ToString();
                        dataGridView1.Rows[i].Cells["col_qty"].Value = dt.Rows[i]["qty"].ToString();
                        dataGridView1.Rows[i].Cells["col_location"].Value = dt.Rows[i]["location"].ToString();
                    }
                }
            }
            else if (cmb_choose.Text == "Category Name")
            {

                DataTable dt = blls.SearchbyCategoryname(txt_search.Text);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.ClearSelection();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["col_stock_id"].Value = dt.Rows[i]["stock_id"].ToString();
                        dataGridView1.Rows[i].Cells["col_category_id"].Value = dt.Rows[i]["category_id"].ToString();
                        dataGridView1.Rows[i].Cells["col_product_id"].Value = dt.Rows[i]["product_id"].ToString();
                        dataGridView1.Rows[i].Cells["col_departmentid"].Value = dt.Rows[i]["department_id"].ToString();
                        dataGridView1.Rows[i].Cells["col_category_name"].Value = dt.Rows[i]["category_name"].ToString();
                        dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();
                        dataGridView1.Rows[i].Cells["col_department_name"].Value = dt.Rows[i]["department"].ToString();
                        dataGridView1.Rows[i].Cells["col_stock_id"].Value = dt.Rows[i]["stock_id"].ToString();

                        dataGridView1.Rows[i].Cells["col_unit"].Value = dt.Rows[i]["unit"].ToString();
                        dataGridView1.Rows[i].Cells["col_qty"].Value = dt.Rows[i]["qty"].ToString();
                        dataGridView1.Rows[i].Cells["col_location"].Value = dt.Rows[i]["location"].ToString();
                    }
                }
            }
            else if (cmb_choose.Text == "Department ")
            {

                DataTable dt = blls.SearchbyDepartment(txt_search.Text);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.ClearSelection();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["col_stock_id"].Value = dt.Rows[i]["stock_id"].ToString();
                        dataGridView1.Rows[i].Cells["col_category_id"].Value = dt.Rows[i]["category_id"].ToString();
                        dataGridView1.Rows[i].Cells["col_product_id"].Value = dt.Rows[i]["product_id"].ToString();
                        dataGridView1.Rows[i].Cells["col_departmentid"].Value = dt.Rows[i]["department_id"].ToString();
                        dataGridView1.Rows[i].Cells["col_category_name"].Value = dt.Rows[i]["category_name"].ToString();
                        dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();
                        dataGridView1.Rows[i].Cells["col_department_name"].Value = dt.Rows[i]["department"].ToString();
                        dataGridView1.Rows[i].Cells["col_stock_id"].Value = dt.Rows[i]["stock_id"].ToString();

                        dataGridView1.Rows[i].Cells["col_unit"].Value = dt.Rows[i]["unit"].ToString();
                        dataGridView1.Rows[i].Cells["col_qty"].Value = dt.Rows[i]["qty"].ToString();
                        dataGridView1.Rows[i].Cells["col_location"].Value = dt.Rows[i]["location"].ToString();
                    }
                }
            }

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            //AddDamages adddamage = new AddDamages();
            //adddamage.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col_damage"].Index && e.RowIndex >= 0)
            {
               Control cntl = this.Parent;
                AddDamages ad = new AddDamages();
              stock_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_stock_id"].Value.ToString());
                category_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_category_id"].Value.ToString());
                product_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_product_id"].Value.ToString());
                department_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_departmentid"].Value.ToString());
                ad.cbo_category.Text=(dataGridView1.CurrentRow.Cells["col_category_name"].Value.ToString());
              ad.lbl_department.Text= (dataGridView1.CurrentRow.Cells["col_department_name"].Value.ToString());
                ad.lbl_location.Text = (dataGridView1.CurrentRow.Cells["col_location"].Value.ToString());
                ad.cbo_product.Text = (dataGridView1.CurrentRow.Cells["col_product_name"].Value.ToString());
                ad.txtquantity.Text = (dataGridView1.CurrentRow.Cells["col_qty"].Value.ToString());

                ad.cmb_unit.Text = (dataGridView1.CurrentRow.Cells["col_unit"].Value.ToString());
                cntl.Controls.Clear();
                cntl.Controls.Add(ad);



            }
        }

        private void btn_back_Click_1(object sender, EventArgs e)
        {

        }
    }
}
