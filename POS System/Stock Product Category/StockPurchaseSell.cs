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
    public partial class StockPurchaseSell : UserControl
    {
        public StockPurchaseSell()
        {
            InitializeComponent();
        }
        BLLPurchase blpur = new BLLPurchase();
        BLLStock blstock = new BLLStock();
        private void StockPurchaseSell_Load(object sender, EventArgs e)
        {
            LoadPrice();
        }
       public static int sell_id;
        int product_id;
        public void LoadPrice()
        {
            DataTable dt = blpur.GetPurchasePrice();
            if (dt.Rows.Count>0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_sellid"].Value = dt.Rows[i]["sell_id"].ToString();
                    dataGridView1.Rows[i].Cells["col_product_id"].Value = dt.Rows[i]["product_id"].ToString();
                    product_id= Convert.ToInt32(dt.Rows[i]["product_id"].ToString());
                    DataTable dt1 = blstock.Getstockbyproduct_id(product_id);
                    if (dt1.Rows.Count>0)
                    {
                        dataGridView1.Rows[i].Cells["col_qty"].Value = dt1.Rows[0]["qty"].ToString();
                    }
                    dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();
                    dataGridView1.Rows[i].Cells["col_price"].Value = dt.Rows[i]["product_cost_price"].ToString();
                    dataGridView1.Rows[i].Cells["col_sellprice"].Value = dt.Rows[i]["product_sell_price"].ToString();
                }
               
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col_edit"].Index)
            {
                sell_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_sellid"].Value.ToString());
                Control ctls = this.Parent;
                Stock_Product_Sellprice cl = new Stock_Product_Sellprice();
                ctls.Controls.Clear();
                ctls.Controls.Add(cl);

            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {

        }

        private void btn_product_price_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            Stock_Product_Sellprice cl = new Stock_Product_Sellprice();
            ctls.Controls.Clear();
            ctls.Controls.Add(cl);
            
        }
    }
}
