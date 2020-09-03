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
    public partial class ProductList : UserControl
    {
        public ProductList()
        {
            InitializeComponent();
        }
        BLLProduct bllc = new BLLProduct();
        BLLStockCategory blsc = new BLLStockCategory();
      
        private void AddProduct_Load(object sender, EventArgs e)
        {
            LoadProduct();
        }

        public void LoadProduct()
        {
            DataTable dt = blsc.GetproductList();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_product_id"].Value = dt.Rows[i]["product_id"].ToString();
                    dataGridView1.Rows[i].Cells["col_category_id"].Value = dt.Rows[i]["category_id"].ToString();

                    int category_id = Convert.ToInt32(dt.Rows[i]["category_id"].ToString());
                    DataTable dt1 = blsc.GetCategory(category_id);

                    dataGridView1.Rows[i].Cells["col_category_name"].Value = dt1.Rows[0]["category_name"].ToString();
                    dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();

                    int department_id = Convert.ToInt32(dt.Rows[i]["department_id"].ToString());
                    DataTable dt2 = blsc.GetDepartment(department_id);
                    if (dt2.Rows.Count > 0)
                    {
                        dataGridView1.Rows[i].Cells["col_department_name"].Value = dt2.Rows[0]["department"].ToString();
                        dataGridView1.Rows[i].Cells["cal_dept_id"].Value = department_id;

                    }

                }
            }
        }
        public static int category_id;
        public static int product_id;
        public static int dept_id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col_add"].Index && e.RowIndex >= 0)
            {
                Control ctrl = this.Parent;
                OpeningStock ap = new OpeningStock();

                ap.txt_category.Text = dataGridView1.Rows[e.RowIndex].Cells["col_category_name"].Value.ToString();
                ap.txt_department.Text = dataGridView1.Rows[e.RowIndex].Cells["col_department_name"].Value.ToString();
                category_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["col_category_id"].Value.ToString());
                product_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["col_product_id"].Value.ToString());
                ap.txt_name.Text = dataGridView1.Rows[e.RowIndex].Cells["col_product_name"].Value.ToString();
                dept_id =Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["cal_dept_id"].Value);
                ctrl.Controls.Clear();
                ctrl.Controls.Add(ap);

            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {

        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = blsc.SearchProductbyName(txt_search.Text);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.ClearSelection();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_product_id"].Value = dt.Rows[i]["product_id"].ToString();
                    dataGridView1.Rows[i].Cells["col_category_id"].Value = dt.Rows[i]["category_id"].ToString();

                    int category_id = Convert.ToInt32(dt.Rows[i]["category_id"].ToString());
                    DataTable dt1 = blsc.GetCategory(category_id);
                    dataGridView1.Rows[i].Cells["col_category_name"].Value = dt1.Rows[0]["category_name"].ToString();
                    dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();

                    int department_id = Convert.ToInt32(dt.Rows[i]["department_id"].ToString());
                    DataTable dt2 = blsc.GetDepartment(department_id);
                    if (dt2.Rows.Count > 0)
                    {
                        dataGridView1.Rows[i].Cells["col_department_name"].Value = dt2.Rows[0]["department"].ToString();
                        dataGridView1.Rows[i].Cells["cal_dept_id"].Value = department_id;
                    }
                }

            }
        }
    }
}

