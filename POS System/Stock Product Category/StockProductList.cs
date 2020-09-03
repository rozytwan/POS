using BLLS;
using POS_Systems;
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
    public partial class StockProductList : UserControl
    {
        public StockProductList()
        {
            InitializeComponent();
        }
        BLLStockCategory blsc = new BLLStockCategory();
        private void tbl_stock_product_list_Load(object sender, EventArgs e)
        {
            LoadDataGridView();

        }
        public void LoadDataGridView()
        {
            DataTable dt = blsc.GetproductList();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_product_id"].Value = dt.Rows[i]["product_id"].ToString();

                    int category_id = Convert.ToInt32(dt.Rows[i]["category_id"].ToString());
                    DataTable dt1 = blsc.GetCategory(category_id);
                    dataGridView1.Rows[i].Cells["col_category_name"].Value = dt1.Rows[0]["category_name"].ToString();
                    dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();

                    int department_id = Convert.ToInt32(dt.Rows[i]["department_id"].ToString());
                    DataTable dt2 = blsc.GetDepartment(department_id);
                    dataGridView1.Rows[i].Cells["col_department_name"].Value = dt2.Rows[0]["department"].ToString();
                    dataGridView1.Rows[i].Cells["col_qty1"].Value = dt.Rows[i]["inhouse_qty_1"].ToString();
                    dataGridView1.Rows[i].Cells["col_unit1"].Value = dt.Rows[i]["inhouse_unit_1"].ToString();
                    dataGridView1.Rows[i].Cells["col_qty2"].Value = dt.Rows[i]["inhouse_qty_2"].ToString();

                    dataGridView1.Rows[i].Cells["col_unit2"].Value = dt.Rows[i]["inhouse_unit_2"].ToString();
                    dataGridView1.Rows[i].Cells["col_qty3"].Value = dt.Rows[i]["inhouse_qty_3"].ToString();

                    dataGridView1.Rows[i].Cells["col_unit3"].Value = dt.Rows[i]["inhouse_unit_3"].ToString();

                    //int inhouse_unit_1 = Convert.ToInt32(dt.Rows[i]["inhouse_unit_1"].ToString());
                    //DataTable dt3 = blsc.GetUnit1(inhouse_unit_1);
                    //if (inhouse_unit_1 == 0)
                    //{
                    //    dataGridView1.Rows[i].Cells["col_unit1"].Value = " 0";

                    //}
                    //else
                    //{
                    //    dataGridView1.Rows[i].Cells["col_unit1"].Value = dt3.Rows[0]["unit_name"].ToString();
                    //}
                    //int inhouse_unit_2 = Convert.ToInt32(dt.Rows[i]["inhouse_unit_2"].ToString());
                    //DataTable dt4 = blsc.GetUnit2(inhouse_unit_2);
                    //if (inhouse_unit_2 == 0)
                    //{
                    //    dataGridView1.Rows[i].Cells["col_unit2"].Value = " 0";

                    //}
                    //else
                    //{
                    //    dataGridView1.Rows[i].Cells["col_unit2"].Value = dt4.Rows[0]["unit_name"].ToString();
                    //}

                    //int inhouse_unit_3 = Convert.ToInt32(dt.Rows[i]["inhouse_unit_3"].ToString());
                    //DataTable dt5 = blsc.GetUnit3(inhouse_unit_3);
                    //if (inhouse_unit_3 == 0)
                    //{
                    //    dataGridView1.Rows[i].Cells["col_unit3"].Value = "0";

                    //}
                    //else
                    //{
                    //    dataGridView1.Rows[i].Cells["col_unit3"].Value = dt5.Rows[0]["unit_name"].ToString();
                    //}

                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public static int product_id;
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                {
                    product_id = Convert.ToInt32(dr.Cells["col_product_id"].Value);
                }
                Control ctls = this.Parent;
                UserControl_Product ucp = new UserControl_Product();
           
                ctls.Controls.Clear();
                ctls.Controls.Add(ucp);
                // ucp.Show();

            }
            else
            {
                MessageBox.Show("Please Select A Row", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            UserControl_Product ucp = new UserControl_Product();
            ctls.Controls.Clear();
            ctls.Controls.Add(ucp);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dig = MessageBox.Show("Are You Sure To Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dig == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                    {
                        product_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_product_id"].Value);
                        int deletePurchase = blsc.DeleteProductPurchase(product_id);
                        int deleteStock = blsc.DeleteProductStock(product_id);
                        int deleteIngredient = blsc.DeleteProductIngredient(product_id);
                        int deleteStocktransfer = blsc.DeleteProductTransfer(product_id);
                        int delete = blsc.DeleteProduct(product_id);
                        if (delete > 0)
                        {
                            MessageBox.Show("Successfully Deleted");
                            product_id = 0;
                        }

                        dataGridView1.Rows.RemoveAt(dr.Index);
                    }

                }
                else
                {
                    MessageBox.Show("Please select row first");
                }

            }

        }

        private void Addproduct_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            UserControl_Product ucp = new UserControl_Product();
            ctls.Controls.Clear();
            ctls.Controls.Add(ucp);
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (cmb_choose.SelectedIndex == -1)
            {
                cmb_choose.Text = "Choose unit";
            }
            if (cmb_choose.SelectedIndex == 0)
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

                        int category_id = Convert.ToInt32(dt.Rows[i]["category_id"].ToString());
                        DataTable dt1 = blsc.GetCategory(category_id);
                        dataGridView1.Rows[i].Cells["col_category_name"].Value = dt1.Rows[0]["category_name"].ToString();
                        dataGridView1.Rows[i].Cells["col_product_name"].Value = dt.Rows[i]["product_name"].ToString();

                        int department_id = Convert.ToInt32(dt.Rows[i]["department_id"].ToString());
                        DataTable dt2 = blsc.GetDepartment(department_id);
                        dataGridView1.Rows[i].Cells["col_department_name"].Value = dt2.Rows[0]["department"].ToString();
                        dataGridView1.Rows[i].Cells["col_qty1"].Value = dt.Rows[i]["inhouse_qty_1"].ToString();
                        dataGridView1.Rows[i].Cells["col_unit1"].Value = dt.Rows[i]["inhouse_unit_1"].ToString();
                        dataGridView1.Rows[i].Cells["col_qty2"].Value = dt.Rows[i]["inhouse_qty_2"].ToString();                      
                        dataGridView1.Rows[i].Cells["col_unit2"].Value = dt.Rows[i]["inhouse_unit_2"].ToString();
                        dataGridView1.Rows[i].Cells["col_qty3"].Value = dt.Rows[i]["inhouse_qty_3"].ToString();                    
                        dataGridView1.Rows[i].Cells["col_unit3"].Value = dt.Rows[i]["inhouse_unit_3"].ToString();
                        

                    }
                }
            }

            else if (cmb_choose.SelectedIndex == 1)
            {
                DataTable dtdepartment = blsc.Searchproductbydepartment(((txt_search.Text)));
                if (dtdepartment.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.ClearSelection();
                    for (int i = 0; i < dtdepartment.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();

                        dataGridView1.Rows[i].Cells["col_category_name"].Value = dtdepartment.Rows[i]["category_name"].ToString();
                        dataGridView1.Rows[i].Cells["col_product_name"].Value = dtdepartment.Rows[i]["product_name"].ToString();

                        dataGridView1.Rows[i].Cells["col_department_name"].Value = dtdepartment.Rows[i]["department"].ToString();
                        dataGridView1.Rows[i].Cells["col_qty1"].Value = dtdepartment.Rows[i]["inhouse_qty_1"].ToString();
                        dataGridView1.Rows[i].Cells["col_unit1"].Value = dtdepartment.Rows[i]["inhouse_unit_1"].ToString();
                        dataGridView1.Rows[i].Cells["col_qty2"].Value = dtdepartment.Rows[i]["inhouse_qty_2"].ToString();
                        dataGridView1.Rows[i].Cells["col_unit2"].Value = dtdepartment.Rows[i]["inhouse_unit_2"].ToString();
                        dataGridView1.Rows[i].Cells["col_qty3"].Value = dtdepartment.Rows[i]["inhouse_qty_3"].ToString();
                        dataGridView1.Rows[i].Cells["col_unit3"].Value = dtdepartment.Rows[i]["inhouse_unit_3"].ToString();


                    }
                }
            }
        }
    }


}
