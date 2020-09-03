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
    public partial class Ingredient_Management : UserControl
    {
        public Ingredient_Management()
        {
            InitializeComponent();
        }
        BLLInhouse_Unit blin = new BLLInhouse_Unit();
        BLLStock blls = new BLLStock();
        BLLOrder blod = new BLLOrder();
        BLLProduct blpur = new BLLProduct();
        BLLCategory blcat = new BLLCategory();
        BLLS.Bll_inventory.bll_inv BIV = new BLLS.Bll_inventory.bll_inv();
        BLLStock bst = new BLLStock();
        BLLStockCategory bllsc = new BLLStockCategory();
        BLLIngredientManagement blim = new BLLIngredientManagement();
        int item_id;
        private void Ingredient_Management_Load(object sender, EventArgs e)
        {
           // inhouse_unit();
            Menu_category();
            lbl_err.Hide();
            cmb_location.SelectedIndex = 0;
            panel_calculation.Hide();
            item_id = AddIngredient.item_id;              
            DataTable dt_cost = BIV.GetItemCost(item_id);
            if (dt_cost.Rows.Count > 0)
            {

                lbl_total_cost.Text = dt_cost.Rows[0]["total_cost"].ToString();
                txt_labour.Text = dt_cost.Rows[0]["labour_cost"].ToString();
                txt_overhead.Text = dt_cost.Rows[0]["overhead_cost"].ToString();
                txt_labour.ReadOnly = true;
                txt_overhead.ReadOnly = true;
                if (dt_cost.Rows[0]["overhead_cost"].ToString() == "0.00" && dt_cost.Rows[0]["labour_cost"].ToString() == "0.00")
                {
                    panel_calculation.Hide();
                    txt_labour.ReadOnly = false; 
                    txt_overhead.ReadOnly = false;
                }
                else
                {
                    panel_calculation.Show();
                    //if (dt_cost.Rows[0]["labour_cost"].ToString() == "0.00")
                    //{
                    //    txt_labour.ReadOnly = false;
                    //}
                    //if (dt_cost.Rows[0]["overhead_cost"].ToString() == "0.00")
                    //{
                    //    txt_overhead.ReadOnly = false;
                    //}
                }
            }
             DataTable dt = blim.getAllIngredientWithJoin(item_id);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int xa = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_product_id"].Value = dt.Rows[i]["product_id"].ToString();
                    int product_id =Convert.ToInt32(dataGridView1.Rows[i].Cells["col_product_id"].Value);
                    dataGridView1.Rows[i].Cells["colinvProductName"].Value = dt.Rows[i]["product_name"].ToString();
                    DataTable dtcal = blls.GetProductCalculationQty(product_id);
                    if (dtcal.Rows.Count > 0)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.IndianRed;
                    }
                    dataGridView1.Rows[i].Cells["colunit"].Value = dt.Rows[i]["unit"].ToString();
                    dataGridView1.Rows[i].Cells["col_location"].Value = dt.Rows[i]["location"].ToString();
                    dataGridView1.Rows[i].Cells["colunitMeasures"].Value = dt.Rows[i]["qty"].ToString();
                    dataGridView1.Rows[i].Cells["col_cost"].Value = dt.Rows[i]["price"].ToString();
                    dataGridView1.Rows[i].Cells[ "col_id"].Value = dt.Rows[i]["ingredient_id"].ToString();
                }
                
            }
            calculate_total();
        }
        //public void inhouse_unit()
        //{
        //    DataTable dt = blin.get_all_data();
        //    if (dt.Rows.Count > 0)
        //    {
        //        DataRow dr = dt.NewRow();
        //        dr["unit_name"] = "Unit";
        //        dt.Rows.InsertAt(dr, 0);
        //        cbo_unit.DataSource = dt;
        //        cbo_unit.ValueMember = "unit_name";
        //        cbo_unit.DisplayMember = "unit_name";
        //    }
        //}
        public void Menu_category()
        {
            DataTable dt = bllsc.GetCategories();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["category_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cbocategorynamess.DataSource = dt;
                cbocategorynamess.DisplayMember = "category_name";
                cbocategorynamess.ValueMember = "category_id";

            }
        }
       
        private void cbo_unit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboproductname.SelectedIndex > 0)
            //{
            //    string getUnit = cbo_unit.Text;
            //    DataTable CheckStocks = bst.getallstockbyname(cboproductname.Text);
            //    if (CheckStocks.Rows.Count > 0)
            //    {
            //        lbl_err.Hide();
            //        btnadd.Enabled = true;
            //        string getUnitonStocks = CheckStocks.Rows[0]["unit"].ToString();
            //        if (getUnit != getUnitonStocks)
            //        {

            //            lbl_err.Show();
            //            lbl_err.Text = "Error:: Unit Not Matched Use" + "( " + getUnitonStocks + " )";
            //            btnadd.Enabled = false;

            //        }
            //    }
            //}
        }

        private void cboitemcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (txt_category_name.Text != ""  && txt_item_name.Text != "")
            //{
            //    DataTable dt = blod.getalldatafromitem(Convert.ToInt32(txt_item_name.Text.));
            //    if (dt.Rows.Count > 0)
            //    {
            //        DataRow dr = dt.NewRow();
            //        dr["item_name"] = "Choose One";
            //        dt.Rows.InsertAt(dr, 0);
            //        cboItem_Name.DataSource = dt;
            //        cboItem_Name.ValueMember = "item_name";
            //        cboItem_Name.DisplayMember = "item_name";
            //    }
            //}
        }
       int category_id;
        private void cbocategorynamess_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbocategorynamess.Text != "" && cbocategorynamess.Text != "Choose One" && cbocategorynamess.SelectedIndex != 0)
            {
                DataTable dt = bllsc.GetProductByCategoryid(Convert.ToInt32(cbocategorynamess.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["product_name"] = "Choose One";
                    dt.Rows.InsertAt(dr, 0);
                    cboproductname.DataSource = dt;
                    cboproductname.ValueMember = "product_id";
                    cboproductname.DisplayMember = "product_name";
                }
            }
        }
        int errConfig = 0;
        int x;
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txt_category_name.Text == "" || txt_item_name.Text == "" || cbocategorynamess.Text == "Choose one" || txt_units.Text == "" || txt_unit.Text == "Choose one")
            {
                MessageBox.Show("Inputs are Required.");
            }

            else
            {
                if (lbl_cost.Text == "" || lbl_cost.Text == "0.00")
                {
                    lbl_cost.Text = "0.00";
                }
                x = dataGridView1.Rows.Count;
                int xa = dataGridView1.Rows.Add();
                dataGridView1.Rows[x].Cells["colinvProductName"].Value = cboproductname.Text;
                dataGridView1.Rows[x].Cells["colunit"].Value = txt_unit.Text;
                dataGridView1.Rows[x].Cells["col_location"].Value = cmb_location.Text;
                dataGridView1.Rows[x].Cells["colunitMeasures"].Value = txt_units.Text;
                dataGridView1.Rows[x].Cells["col_product_id"].Value = cboproductname.SelectedValue;
                dataGridView1.Rows[x].Cells["colinvCategoryId"].Value = cbocategorynamess.SelectedValue;
                dataGridView1.Rows[x].Cells["col_cost"].Value = lbl_cost.Text;
                dataGridView1.Rows[x].Cells["colMenuId"].Value = item_id;
                dataGridView1.Rows[x].Cells["col_id"].Value = "";
            }
            calculate_total();
            lbl_cost.Text = "";
        }
        //public void UpdaeStocks()
        //{  BLLStock bst = new BLLStock();
        //    int updatestcks = 0;
        //    for (int j = 0; j < dataGridView1.Rows.Count; j++)
        //    {
        //        DataTable getallSelectedStocks = bst.getallstockbyname(dataGridView1.Rows[j].Cells["colinvProductName"].Value.ToString());
        //        if (getallSelectedStocks.Rows.Count > 0)
        //        {
        //             updatestcks = bst.UpdateStockFrmInventory(Convert.ToDecimal(dataGridView1.Rows[j].Cells["colunit"].Value.ToString()), dataGridView1.Rows[j].Cells["colinvProductName"].Value.ToString());                            
        //        } 
        //    }
        //}
        int inserts;
        public void insertandSave()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["col_id"].Value.ToString() == "")
                {
             
                    inserts = BIV.InsertIngredient(item_id, Convert.ToInt32(row.Cells["colinvCategoryId"].Value), Convert.ToInt32(row.Cells["col_product_id"].Value), row.Cells["col_location"].Value.ToString(), Convert.ToDecimal(row.Cells["colunitMeasures"].Value), row.Cells["colunit"].Value.ToString(), Convert.ToDecimal(row.Cells["col_cost"].Value));
                }
            }
            if (inserts > 0)
            {
                if (lbl_cost.Text != "0.00" || txt_labour.Text != "" || txt_overhead.Text != "" || txt_labour.Text != "0.00" || txt_overhead.Text != "0.00")
                {
                    DataTable dt_cost = BIV.GetItemCost(item_id);
                    if (dt_cost.Rows.Count > 0)
                    {
                        int update_cal = BIV.UpdateIngredientCalculation(item_id, Convert.ToDecimal(lbl_totalcost.Text), Convert.ToDecimal(txt_labour.Text), Convert.ToDecimal(txt_overhead.Text), Convert.ToDecimal(lbl_total_cost.Text));

                    }
                    else
                    {
                        DataTable dt = BIV.GetIngredientId();
                        if (dt.Rows.Count > 0)
                        {
                            int ingredient_id = Convert.ToInt32(dt.Rows[0][0].ToString());
                            if (txt_labour.Text == "")
                            {
                                txt_labour.Text = "0.00";
                            }
                            if (txt_overhead.Text == "")
                            {
                                txt_overhead.Text = "0.00";
                            }
                            int insert_cal = BIV.InsertIngredientCalculation(ingredient_id, item_id, Convert.ToDecimal(lbl_totalcost.Text), Convert.ToDecimal(txt_labour.Text), Convert.ToDecimal(txt_overhead.Text), Convert.ToDecimal(lbl_total_cost.Text));
                        }
                    }
                }

                dataGridView1.Rows.Clear();
                MessageBox.Show("Data Saved.");
                txt_units.Text = "";
                lbl_cost.Text = "0.00";
                lbl_manuName.Text = ":";
                panel_calculation.Hide();
               // second_user_interface.ingredient = "";
            }
            else
            {
                DataTable dt = BIV.GetItemCost(item_id);
                if (dt.Rows.Count > 0)
                {
                    int update_cals = BIV.UpdateIngredientCalculation(item_id, Convert.ToDecimal(lbl_totalcost.Text), Convert.ToDecimal(txt_labour.Text), Convert.ToDecimal(txt_overhead.Text), Convert.ToDecimal(lbl_total_cost.Text));
                }
     

                dataGridView1.Rows.Clear();
                MessageBox.Show("Update Saved.");
                txt_units.Text = "";
                lbl_cost.Text = "0.00";
                lbl_manuName.Text = ":";
                panel_calculation.Hide();
              //  second_user_interface.ingredient = "";
            }
        }
    
        private void button3_Click(object sender, EventArgs e)
        {
            int item_id = AddIngredient.item_id;
            if (item_id > 0)
            {
                insertandSave();
            }
        }

        private void txt_cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txt_units_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["colremove"].Index && e.RowIndex >= 0)
            {
               
                if (dataGridView1.Rows[e.RowIndex].Cells["col_id"].Value.ToString() != "")
                {
                    int deleteIngridient = blim.deleteIngrendent(Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["col_id"].Value));
                }
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }

     

        private void button1_Click(object sender, EventArgs e)
        {


            txt_units.Text = "";
            cboproductname.Text = "";

            
        }
        BLLStock blstock = new BLLStock();
    IngridentCostCalculation icc = new IngridentCostCalculation();
        private void txt_units_TextChanged(object sender, EventArgs e)
        {
            if (cboproductname.SelectedIndex > 0 && cboproductname.Text != "Choose One")
            {
                DataTable dt = blstock.GetLatestPrice(Convert.ToInt32(cboproductname.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                    if (txt_units.Text != "")
                    {
                        decimal cost = Convert.ToDecimal(dt.Rows[0]["price"].ToString());
                        decimal totalPrice=icc.IngredintCostCalculation(txt_unit.Text, cost, Convert.ToInt32(cboproductname.SelectedValue), dt.Rows[0]["unit"].ToString());
                        lbl_cost.Text = Convert.ToString((Convert.ToDecimal(txt_units.Text)) * totalPrice);
                    }
                    else
                    {
                        lbl_cost.Text = "0.00";
                    }
                }
                //if (txt_units.Text.Length > 0)
                //{
                //    decimal EnteredUnits = Convert.ToDecimal(txt_units.Text);
                //    DataTable CheckStocks = bst.getallstockbyname(cboproductname.Text);
                //    if (CheckStocks.Rows.Count > 0)
                //    {
                //        btnadd.Enabled = true;
                //        txt_units.ForeColor = Color.Black;
                //        lbl_err.Hide();
                //       //decimal getRemainedStocks = Convert.ToDecimal(CheckStocks.Rows[0]["inhouse_qty_1"].ToString());
                //       // if (EnteredUnits > getRemainedStocks)
                //       // {
                //       //     btnadd.Enabled = false;
                //       //     txt_units.ForeColor = Color.Red;
                //       //     lbl_err.Show();
                //       //     lbl_err.Text = "Error:: Stock Limit Reached.";

                //       // }
                //    }

                //}
            }
        }
       public int product_id;
        private void cboproductname_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            if(cboproductname.SelectedIndex > 0 && cboproductname.Text != "Choose One")
            {
                DataTable dt = bllsc.Getunitbyproductid(Convert.ToInt32(cboproductname.SelectedValue));
                if (dt.Rows.Count > 0)
                {
                     if (dt.Rows[0]["inhouse_unit_3"].ToString() != "")
                        {
                            txt_unit.Text= dt.Rows[0]["inhouse_unit_3"].ToString();
                        }
                        else if (dt.Rows[0]["inhouse_unit_2"].ToString() != "")
                        {
                            txt_unit.Text= dt.Rows[0]["inhouse_unit_2"].ToString();
                        }
                        else
                        {
                            txt_unit.Text= dt.Rows[0]["inhouse_unit_1"].ToString();
                        }
                          
                      
                    }
              
                }
               
        
         }


        private void btn_back_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            AddIngredient il = new AddIngredient();
            ctls.Controls.Clear();
            ctls.Controls.Add(il);
        }

        private void cmb_location_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_calculation_Click(object sender, EventArgs e)
        {
            panel_calculation.Show();
        }

        private void lbl_cost_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        public void calculate_total()
        {
            decimal sum = 0;

            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                if (dataGridView1.Rows[i].Cells["col_cost"].Value.ToString() != "")
                {
                    sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells["col_cost"].Value);
                }
            }
            lbl_totalcost.Text = sum.ToString();
        }
        private void lbl_cost_TextChanged(object sender, EventArgs e)
        {
         
            lbl_total_cost.Text = Convert.ToString(Convert.ToDecimal(txt_overhead.Text) + Convert.ToDecimal(txt_labour.Text) + Convert.ToDecimal(lbl_totalcost.Text));
            calculate_total();
        }

        private void lbl_totalcost_TextChanged(object sender, EventArgs e)
        {
            lbl_total_cost.Text = Convert.ToString(Convert.ToDecimal(txt_overhead.Text) + Convert.ToDecimal(txt_labour.Text) + Convert.ToDecimal(lbl_totalcost.Text));
        }

        private void txt_labour_TextChanged(object sender, EventArgs e)
        {
            if (txt_labour.Text!="")
            {
                lbl_total_cost.Text = Convert.ToString(Convert.ToDecimal(txt_overhead.Text) + Convert.ToDecimal(txt_labour.Text) + Convert.ToDecimal(lbl_totalcost.Text));

            }
            else
            {
                txt_labour.Text = "0.00";
            }
        }

        private void txt_overhead_TextChanged(object sender, EventArgs e)
        {
            if (txt_overhead.Text != "")
            {
                lbl_total_cost.Text = Convert.ToString(Convert.ToDecimal(txt_overhead.Text) + Convert.ToDecimal(txt_labour.Text) + Convert.ToDecimal(lbl_totalcost.Text));

            }
            else
            {
                txt_overhead.Text = "0.00";
            }
        }

        private void lbl_cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
