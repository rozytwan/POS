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
    public partial class Stock_Product_Sellprice : UserControl
    {
        public Stock_Product_Sellprice()
        {
            InitializeComponent();
        }
        BLLStockCategory blsc = new BLLStockCategory();
        BLLPurchase blpur = new BLLPurchase();
        BLLStock blstock = new BLLStock();
        int sell_id = StockPurchaseSell.sell_id;
      
        private void Stock_Product_Sellprice_Load(object sender, EventArgs e)
        {
            LoadProduct();
            btn_save.Enabled = true;
            btn_update.Enabled = false;
            cmb_product.Text = "Choose One";
            txt_sellprice.Text = "";
            txt_costprice.Text = "";
            if (sell_id>0)
            {
                btn_save.Enabled = false;
                btn_update.Enabled = true;
                DataTable dt = blstock.GetDetails(sell_id);
                if (dt.Rows.Count>0)
                {
                    product_id = Convert.ToInt32(dt.Rows[0]["product_id"].ToString());
                    DataTable dt1 = blpur.getpurchasebyproduct(product_id);
                    if (dt.Rows.Count>0)
                    {
                        cmb_product.Text = dt1.Rows[0]["product_name"].ToString();
                    }
                    txt_costprice.Text = dt.Rows[0]["product_cost_price"].ToString();
                    txt_sellprice.Text = dt.Rows[0]["product_sell_price"].ToString();
                }
            }
            
        
        }
        public void LoadProduct()
        {

            DataTable dt = blsc.GetproductList();
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
        int product_id;
        private void cmb_product_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = blstock.getallstockbyname(cmb_product.Text);
            if (dt.Rows.Count > 0)
            {
                product_id = Convert.ToInt32(dt.Rows[0][0].ToString());
                DataTable dt1 = blstock.GetLatestPrice(product_id);
                if (dt1.Rows.Count > 0)
                {
                    txt_costprice.Text = dt1.Rows[0]["price"].ToString();
                }
            }
        }
        private void btn_back_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            StockPurchaseSell cl = new StockPurchaseSell();
            ctls.Controls.Clear();
            ctls.Controls.Add(cl);
            clear();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            int insert = blstock.Insert_Sellingprice(product_id, Convert.ToDecimal(txt_costprice.Text), Convert.ToDecimal(txt_sellprice.Text));
            if (insert>0)
            {
                MessageBox.Show("Successfully Inserted !!", "Inserted Alert !!");
                clear();
            }

        }
        public void clear()
        {
            cmb_product.Text = "Choose One";
            txt_sellprice.Text = "";
            txt_costprice.Text = "";
            sell_id = 0;
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
       
            int update = blstock.Update_selling(sell_id,Convert.ToInt32(cmb_product.SelectedValue),1, Convert.ToDecimal(txt_costprice.Text),Convert.ToDecimal(txt_sellprice.Text));
            if (update > 0)
            {
                MessageBox.Show("Successfully Updated !!", "Updated Alert !!");
                clear();
            }
        }
    }
}
