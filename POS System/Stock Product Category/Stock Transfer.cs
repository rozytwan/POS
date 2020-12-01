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
    public partial class Stock_Transfer : Form
    {
        public Stock_Transfer()
        {
            InitializeComponent();
        }
        public int stock_id;
        DataTable dt;
        string firstLocation;
        int category_id;
        int product_id;
        int dept_id;

        BLLStockTransfer blst = new BLLStockTransfer();
        BLLStock blsk = new BLLStock();
        BLLPurchase blpur = new BLLPurchase();
        BLLUser blu = new BLLUser();
        private void Stock_Transfer_Load(object sender, EventArgs e)
        {

            lbltransferdate.Text = DateTime.Today.ToShortDateString();
            if (stock_id > 0)
            {
               dt = blsk.getallstockBYId(stock_id);
                if (dt.Rows.Count > 0)
                {
                    txtcategory_name.Text = dt.Rows[0]["category_name"].ToString();
                    txtproduct_name.Text = dt.Rows[0]["product_name"].ToString();
                    firstLocation = dt.Rows[0]["location"].ToString();
                    dept_id = Convert.ToInt32(dt.Rows[0]["department_id"].ToString());        
                        cbo_inhouse_unit.Controls.Clear();
                        foreach (DataRow dr in dt.Rows)
                        {
                            cbo_inhouse_unit.Items.Add(dr["inhouse_unit_1"].ToString());
                            cbo_inhouse_unit.Items.Add(dr["inhouse_unit_2"].ToString());
                            cbo_inhouse_unit.Items.Add(dr["inhouse_unit_3"].ToString());
                        }
                    cbo_inhouse_unit.SelectedIndex = 0;
                    category_id = Convert.ToInt32(dt.Rows[0]["category_id"]);
                    product_id = Convert.ToInt32(dt.Rows[0]["product_id"]);

                }
            }
            cbo_stock_transfer.SelectedIndex = 0;
            userLoad();
            userLoad2();


        }
        public void userLoad()
        {
            DataTable dt = blu.getalluser();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["user_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cbo_transfer_by.DataSource = dt;
                cbo_transfer_by.DisplayMember = "user_name";
                cbo_transfer_by.ValueMember = "user_id";
            }      
        }
        public void userLoad2()
        {
            DataTable dt = blu.getalluser();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["user_name"] = "Choose One";
                
                cbo_transfer_to.DataSource = dt;
                cbo_transfer_to.DisplayMember = "user_name";
                cbo_transfer_to.ValueMember = "user_id";
            }
        }

        private void btnsave_Click_1(object sender, EventArgs e)
        {
           
            if (lbltransferdate.Text == "" || txtcategory_name.Text == "" || txtproduct_name.Text == "" || txt_quanitity.Text == "" || cbo_transfer_by.Text == "" || cbo_transfer_to.Text == "" || txt_stock_quantity.Text == "")
            {
                MessageBox.Show("inputs are may be empty..");
            }
           
            else
            {
                //if (Convert.ToDecimal(txt_quanitity.Text) > Convert.ToDecimal(txt_stock_quantity.Text))
                //{
                //    MessageBox.Show("There Is Less Stock Than You Enter");
                //}
                 if (Convert.ToDecimal(txt_quanitity.Text) <= Convert.ToDecimal(txt_stock_quantity.Text))
                {
                    quanityConverter();
                    int k = blsk.createstock(category_id, product_id, quantity,1, cbo_stock_transfer.Text, unitName);
                    if (k > 0)
                    {
                       int b = blsk.insert_stockTransfer(category_id, product_id, quantity,cbo_stock_transfer.Text, unitName, cbo_transfer_by.Text,cbo_transfer_to.Text,Convert.ToDateTime(DateTime.Now.ToShortTimeString()));
                        int c = blsk.stockTransferQuanltityLess(product_id, firstLocation, quantity);
                        int AddStockLog = blsk.createstockLog(category_id, product_id, Convert.ToDecimal(txt_quanitity.Text), dept_id, cbo_stock_transfer.Text, cbo_inhouse_unit.Text, Convert.ToDateTime(DateTime.Now.ToString()), "Transfer");
                        this.Close();
                    }
                }
            }
        }


        decimal quantity = 0;
        string unitName;
        public void quanityConverter()
        {
            if (product_id>0)
            {
                DataTable dt = blpur.getpurchasebyproduct(product_id);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["inhouse_unit_1"].ToString() == cbo_inhouse_unit.Text)
                    {
                        if (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]) > 0)
                        {
                            quantity = (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_2"]) * Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]) * Convert.ToDecimal(txt_quanitity.Text));
                        }
                        else if (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_2"]) > 0)
                        {
                            quantity = Convert.ToDecimal(dt.Rows[0]["inhouse_qty_2"]) * Convert.ToDecimal(txt_quanitity.Text);
                        }
                        else
                        {
                            quantity = Convert.ToDecimal(txt_quanitity.Text);
                        }
                    }
                    else if (dt.Rows[0]["inhouse_unit_2"].ToString() == cbo_inhouse_unit.Text)
                    {
                        if (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]) > 0)
                        {
                            quantity = (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]) * Convert.ToDecimal(txt_quanitity.Text));
                        }
                        else
                        {
                            quantity = Convert.ToDecimal(txt_quanitity.Text);
                        }
                    }
                    else
                    {
                        quantity = Convert.ToDecimal(txt_quanitity.Text);
                    }
                    unitName = dt.Rows[0]["inhouse_unit_3"].ToString();
                }

            }
        }


        private void txttransferby_KeyDown(object sender, KeyEventArgs e)
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

        private void txttransferto_KeyDown(object sender, KeyEventArgs e)
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

        private void cbo_inhouse_unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_inhouse_unit.SelectedIndex >= 0 && cbo_inhouse_unit.Text != "")
            {
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["inhouse_unit_1"].ToString() == cbo_inhouse_unit.Text)
                    {
                        if (dt.Rows[0]["inhouse_unit_3"].ToString() != "" && dt.Rows[0]["inhouse_unit_2"].ToString() != "")
                        {
                            txt_stock_quantity.Text = (Convert.ToDecimal(dt.Rows[0]["qty"]) / (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_2"]) * Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]))).ToString();
                        }
                        else if (dt.Rows[0]["inhouse_unit_2"].ToString() != "")
                        {
                            txt_stock_quantity.Text = (Convert.ToDecimal(dt.Rows[0]["qty"]) / (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_2"]))).ToString();
                        }
                        else
                        {
                            txt_stock_quantity.Text = (Convert.ToDecimal(dt.Rows[0]["qty"])).ToString();
                        }
                    }
                    else if (dt.Rows[0]["inhouse_unit_2"].ToString() == cbo_inhouse_unit.Text)
                    {
                        if (dt.Rows[0]["inhouse_unit_2"].ToString() != "")
                        {
                            txt_stock_quantity.Text = (Convert.ToDecimal(dt.Rows[0]["qty"]) / (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_2"]))).ToString();
                        }
                        else
                        {
                            txt_stock_quantity.Text = (Convert.ToDecimal(dt.Rows[0]["qty"])).ToString();
                        }
                    }
                    else
                    {
                        txt_stock_quantity.Text = dt.Rows[0]["qty"].ToString();
                    }
                }
            }
        }

        private void cbo_transfer_by_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
