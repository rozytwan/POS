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
            DataTable dt = bllc.getallproduct();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                 
                    dataGridView1.Rows[i].Cells["col_product_id"].Value = dt.Rows[i]["product_id"].ToString();
                    dataGridView1.Rows[i].Cells["col_category_id"].Value = dt.Rows[0]["category_id"].ToString();

                    int category_id = Convert.ToInt32(dt.Rows[i]["category_id"].ToString());
                    DataTable dt1 = blsc.GetCategory(category_id);
                    dataGridView1.Rows[i].Cells["col_category"].Value = dt1.Rows[0]["category_name"].ToString();
                    dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();
                    dataGridView1.Rows[i].Cells["col_price"].Value = dt.Rows[i]["price"].ToString();
                }
            }
        }
        public static int category_id;
        public static int product_id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col_add"].Index && e.RowIndex >= 0)
            {
                Control ctrl = this.Parent;
                AddProduct ap = new AddProduct();
              
                ap.txt_category.Text = dataGridView1.CurrentRow.Cells["col_category"].Value.ToString();
                product_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_product_id"].Value.ToString());

                category_id = Convert.ToInt32( dataGridView1.CurrentRow.Cells["col_category_id"].Value.ToString());
                ap.txt_name.Text = dataGridView1.CurrentRow.Cells["col_product_name"].Value.ToString();

                ctrl.Controls.Clear();
                ctrl.Controls.Add(ap);

            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {

        }
    }
}
