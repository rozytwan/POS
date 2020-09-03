using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLS;

namespace POS_System
{
    public partial class StockAdjustments : UserControl
    {
        public StockAdjustments()
        {
            InitializeComponent();
        }
        BLLCategory blcat = new BLLCategory();
        BLLProduct blpro = new BLLProduct();
        BLLStock bls = new BLLStock();
        BLLStockCategory blsc = new BLLStockCategory();
        BLLS.Bll_inventory.Bll_stockAdjustments bsa = new BLLS.Bll_inventory.Bll_stockAdjustments();

        private void StockAdjustments_Load(object sender, EventArgs e)
        {
            stockview();
            Nav_panel.Hide();
            ShowAdjusted_stockPanel.Hide();
            rdo_minus.Checked = true;
        }
        public int category_id;
        public int product_id;
        public int department_id;
        public void stockview()
        {

            DataTable dt = new DataTable();
            dt = bls.GetStock();
            if (dt.Rows.Count > 0)
            {
 dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["calstock_id"].Value = dt.Rows[i]["stock_id"].ToString();
                    dataGridView1.Rows[i].Cells["col_categoryid"].Value = dt.Rows[i]["category_id"].ToString();
                    dataGridView1.Rows[i].Cells["col_productid"].Value = dt.Rows[i]["product_id"].ToString();
                    dataGridView1.Rows[i].Cells["col_departmentid"].Value = dt.Rows[i]["id"].ToString();
                    dataGridView1.Rows[i].Cells["calcategory_name"].Value = dt.Rows[i]["category_name"].ToString();
                    dataGridView1.Rows[i].Cells["calproduct_name"].Value = dt.Rows[i]["product_name"].ToString();
                    dataGridView1.Rows[i].Cells["col_department"].Value = dt.Rows[i]["department"].ToString();
                    dataGridView1.Rows[i].Cells["col_location"].Value = dt.Rows[i]["location"].ToString();
                    dataGridView1.Rows[i].Cells["calquantity"].Value = dt.Rows[i]["qty"].ToString();

                }
            }

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            allmenu alls = new allmenu();
            ctls.Controls.Clear();
            ctls.Controls.Add(alls);
        }
        public bool user_access_check;
    
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["colAdjust"].Index && e.RowIndex >= 0)
            {
                AdminAccess acc = new AdminAccess();
                acc.ShowDialog();
                user_access_check = AdminAccess.discount_access_value;
                if (user_access_check == true)
                {
                    
                    category_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_categoryid"].Value.ToString());
                    product_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_productid"].Value.ToString());
                    department_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_departmentid"].Value.ToString());
                    lbl_productName.Text = dataGridView1.CurrentRow.Cells["calproduct_name"].Value.ToString();
                    lbl_stockonHand.Text = dataGridView1.CurrentRow.Cells["calquantity"].Value.ToString();
                    lbl_stockid.Text = dataGridView1.CurrentRow.Cells["calstock_id"].Value.ToString();
                    cbo_location.Text = dataGridView1.CurrentRow.Cells["col_location"].Value.ToString();
                    lbl_department.Text = dataGridView1.CurrentRow.Cells["col_department"].Value.ToString();
                    DataTable dt = bls.getproductunit(product_id, category_id);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["inhouse_unit_3"].ToString() != "")
                        {
                            lbl_unit.Text = dt.Rows[0]["inhouse_unit_3"].ToString();
                        }
                        else if (dt.Rows[0]["inhouse_unit_2"].ToString() != "")
                        {
                            lbl_unit.Text = dt.Rows[0]["inhouse_unit_2"].ToString();
                        }
                        else
                        {
                            lbl_unit.Text = dt.Rows[0]["inhouse_unit_1"].ToString();
                        }
                    }
                    Nav_panel.BringToFront();
                    Nav_panel.Show();
                }
                else
                {
                    Nav_panel.SendToBack();
                   Nav_panel.Hide();
                    clear();
                    StockAdjustments_Load(null, null);
                }
            }
            if (e.ColumnIndex == dataGridView1.Columns["colviewAdjusts"].Index && e.RowIndex >= 0)
            {
           
                    string id = dataGridView1.CurrentRow.Cells["calstock_id"].Value.ToString();
                    string productname = dataGridView1.CurrentRow.Cells["calproduct_name"].Value.ToString();
                    DataTable getalldata = bsa.getallAdStocksbyId(id);
                    if (getalldata.Rows.Count > 0)
                    {
                        lbl_productnames.Text = productname;
                        dgv_stocks.Rows.Clear();
                        dgv_stocks.ClearSelection();
                        for (int ink = 0; ink < getalldata.Rows.Count; ink++)
                        {
                            dgv_stocks.Rows.Add(getalldata.Rows[ink]["stock_id"].ToString(), productname, getalldata.Rows[ink]["qty"].ToString()+ " "+ getalldata.Rows[ink]["unit"].ToString(), getalldata.Rows[ink]["unit"].ToString(), Convert.ToDecimal(getalldata.Rows[ink]["stockon_hand"].ToString()), getalldata.Rows[ink]["username"].ToString(), getalldata.Rows[ink]["adjust_date"].ToString(), getalldata.Rows[ink]["status"].ToString());
                        }
                        ShowAdjusted_stockPanel.BringToFront();
                        ShowAdjusted_stockPanel.Show();
                    }

                    else
                    {
                        MessageBox.Show("No Adjustments on Selected Product", "No Adjustments Notice:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        public void clear()
        {
            lbl_department.Text = "";
            lbl_onhand.Text = "";
            lbl_productName.Text = "";
            lbl_productnames.Text = "";
            lbl_stockid.Text = "";
            lbl_stockonHand.Text = "";
            lbl_unit.Text = "";
            txt_notes.Text = "";
            txt_qty.Text = "";
            rdo_minus.Checked = true;
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
          
            Nav_panel.SendToBack();
            Nav_panel.Hide();
            clear();
            StockAdjustments_Load(null, null);
        }
        decimal quantity = 0;
        public void quantityConverter()
        {
            if (cmb_unit.Text.Length > 0)
            {
                DataTable dt = blsc.SearchProductbyName((lbl_productName.Text));
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["inhouse_unit_1"].ToString() == cmb_unit.Text)
                    {
                        if (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]) > 0)
                        {
                            quantity = (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_2"]) * Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]) * Convert.ToDecimal(txt_qty.Text));
                        }
                        else if (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_2"]) > 0)
                        {
                            quantity = Convert.ToDecimal(dt.Rows[0]["inhouse_qty_2"]) * Convert.ToDecimal(txt_qty.Text);
                        }
                        else
                        {
                            quantity = Convert.ToDecimal(txt_qty.Text);
                        }
                    }
                    else if (dt.Rows[0]["inhouse_unit_2"].ToString() == cmb_unit.Text)
                    {
                        if (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]) > 0)
                        {
                            quantity = (Convert.ToDecimal(dt.Rows[0]["inhouse_qty_3"]) * Convert.ToDecimal(txt_qty.Text));
                        }
                        else
                        {
                            quantity = Convert.ToDecimal(txt_qty.Text);
                        }
                    }
                    else
                    {
                        quantity = Convert.ToDecimal(txt_qty.Text);
                    }
                }
            }
        }
        string today = DateTime.Now.ToShortDateString();
        decimal stockonhand;
    
        private void btn_save_Click(object sender, EventArgs e)
        {
            string username = AdminAccess.username;
            if (txt_qty.Text == "0" || txt_notes.Text == "" )
            {
                MessageBox.Show("Input is Wrong.", "Input Error Notice:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(rdo_minus.Checked==true)
            {
                quantityConverter();
    
                stockonhand =Convert.ToDecimal(lbl_stockonHand.Text)-quantity;
                int m = bls.Decreasestock(category_id, product_id, quantity, 1,cbo_location.Text, cmb_unit.Text);
                if (m > 0)
                {
                  int i = bsa.InsertAdjustStock(Convert.ToInt32(lbl_stockid.Text), Convert.ToDateTime(today), cmb_unit.Text, Convert.ToDecimal(txt_qty.Text), stockonhand, txt_notes.Text,"Decreased",username);
                    int AddStockLog = bls.createstockLog(category_id, product_id, Convert.ToDecimal(txt_qty.Text), department_id,cbo_location.Text, cmb_unit.Text, Convert.ToDateTime(DateTime.Now.ToString()), "Decrease Adjust");
                    MessageBox.Show("Product Decreased Successfully .", "Decrease Success Alert !!", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Nav_panel.Hide();
                    stockview();
                }
            }
            else if (rdo_plus.Checked == true)
            {
                quantityConverter();
                 stockonhand = Convert.ToDecimal(lbl_stockonHand.Text) + quantity;
                int p = bls.createstock(category_id, product_id, quantity,department_id, cbo_location.Text, cmb_unit.Text);
                if (p > 0)
                {
                    int i = bsa.InsertAdjustStock(Convert.ToInt32(lbl_stockid.Text), Convert.ToDateTime(today), cmb_unit.Text, Convert.ToDecimal(txt_qty.Text), stockonhand, txt_notes.Text,"Added",username);
                    int AddStockLog = bls.createstockLog(category_id, product_id, Convert.ToDecimal(txt_qty.Text), department_id, cbo_location.Text, cmb_unit.Text, Convert.ToDateTime(DateTime.Now.ToString()), "Add Adjust");
                    MessageBox.Show("Product Added Successfully .", "Add Success Alert !!", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Nav_panel.Hide();
                    stockview();
                }
            }
            clear();
        }

        private void txt_qty_TextChanged(object sender, EventArgs e)
        {
            if ( txt_qty.Text != "0" || txt_qty.Text == "")
            {
           
                 btn_save.Enabled = true;
            }
            else
                btn_save.Enabled = false;

        }

        private void txt_qty_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            ShowAdjusted_stockPanel.Hide();

        }

        private void lbl_productName_TextChanged(object sender, EventArgs e)
        {
            if (lbl_productName.Text != "")
            {
                DataTable dt = blsc.SearchProductbyName(lbl_productName.Text);
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

        private void txt_qty_Leave(object sender, EventArgs e)
        {
            if (txt_qty.Text=="")
            {
                txt_qty.Text = "0";
            }
        }

        private void txt_qty_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_qty.Text == " ")
            {
                txt_qty.Text = "0";
            }
        }
    }
}
