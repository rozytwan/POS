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
    public partial class PurchaseOrder : Form
    {
        public PurchaseOrder()
        {
            InitializeComponent();
        }
        BLLCategory blcat = new BLLCategory();
        BLLProduct blpro = new BLLProduct();
        BLLPurchase blpur = new BLLPurchase();
        private void PurchaseOrder_Load(object sender, EventArgs e)
        {
            category();
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
                    cmb_unit.Items.Clear();
                    foreach (DataRow dr in dt.Rows)
                    {
                        cmb_unit.Items.Add(dr["inhouse_unit_1"].ToString());
                        cmb_unit.Items.Add(dr["inhouse_unit_2"].ToString());
                        cmb_unit.Items.Add(dr["inhouse_unit_3"].ToString());
                    }
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            //int insert = blpur.InsertpurchaseOrder(txt_po_no.Text, Convert.ToInt32(cmb_category.SelectedValue), Convert.ToInt32(cmb_product.SelectedValue), Convert.ToDecimal(txt_qty.Text), cmb_unit.Text);
            //if (insert>0)
            //{
            //    MessageBox.Show("Successfully Inserted !!","Success Alert !!");
            //}
        }
    }
}
