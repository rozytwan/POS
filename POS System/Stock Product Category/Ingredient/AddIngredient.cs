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
    public partial class AddIngredient : UserControl
    {
        public AddIngredient()
        {
            InitializeComponent();
        }
        BLLMenuItem bllproduct = new BLLMenuItem();
        BLLStockCategory bllsc = new BLLStockCategory();
        private void ItemList_Load(object sender, EventArgs e)
        {
            Loaddatagridview();
            cmb_choose.Text = "Search By";
        }
        public void Loaddatagridview()
        {
            DataTable dt = bllproduct.getproductitemWithoutJoin();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.ClearSelection();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_item_id"].Value = dt.Rows[i]["item_id"].ToString();
                    int item_id = Convert.ToInt32(dt.Rows[i]["item_id"].ToString());
                    DataTable dtcal = bllproduct.GetLessIngredientByItem(item_id);
                    if (dtcal.Rows.Count > 0)
                    {
                        dataGridView1.Rows[i].Cells["col_add"].Value = Color.IndianRed;
                    }
                    dataGridView1.Rows[i].Cells["col_item_name"].Value = dt.Rows[i]["item_name"].ToString();
                    int categoryid = Convert.ToInt32(dt.Rows[i]["category_id"].ToString());
                    DataTable dt1 = bllproduct.getcategorybycategoryid(categoryid);
                    dataGridView1.Rows[i].Cells["col_category"].Value = dt1.Rows[0]["category_name"].ToString();
                    dataGridView1.Rows[i].Cells["col_price"].Value = dt.Rows[i]["item_cost_price"].ToString();
                    dataGridView1.Rows[i].Cells["col_selling_price"].Value = dt.Rows[i]["item_price"].ToString();
                    dataGridView1.Rows[i].Cells["col_kot"].Value = dt.Rows[i]["kot_print"].ToString();
                    DataTable dt2 = bllproduct.GetIngredient(Convert.ToInt32(dt.Rows[i]["item_id"].ToString()));
                    if (dt2.Rows.Count > 0)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }

                }
                dataGridView1.ClearSelection();
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
        }
        private void btn_back_Click(object sender, EventArgs e)
        {


        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (cmb_choose.SelectedIndex == -1)
            {
                cmb_choose.Text = "Search By";
            }
            if (cmb_choose.SelectedIndex == 0)
            {
                DataTable dt = bllproduct.getproductbyproductname(txt_search.Text);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.ClearSelection();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["col_item_id"].Value = dt.Rows[i]["item_id"].ToString();
                        dataGridView1.Rows[i].Cells["col_item_name"].Value = dt.Rows[i]["item_name"].ToString();

                        int categoryid = Convert.ToInt32(dt.Rows[i]["category_id"].ToString());
                        DataTable dt1 = bllproduct.getcategorybycategoryid(categoryid);
                        dataGridView1.Rows[i].Cells["col_category"].Value = dt1.Rows[0]["category_name"].ToString();
                        dataGridView1.Rows[i].Cells["col_price"].Value = dt.Rows[i]["item_cost_price"].ToString();
                        dataGridView1.Rows[i].Cells["col_selling_price"].Value = dt.Rows[i]["item_price"].ToString();
                        dataGridView1.Rows[i].Cells["col_kot"].Value = dt.Rows[i]["kot_print"].ToString();
                        DataTable dt2 = bllproduct.GetIngredient(Convert.ToInt32(dt.Rows[i]["item_id"].ToString()));
                        if (dt2.Rows.Count > 0)
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                            dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                        }
                        else
                        {
                            dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                            dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }
        public int product_id;
        public static int item_id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col_add"].Index && e.RowIndex >= 0)
            {
                Ingredient_Management ami = new Ingredient_Management();
                item_id =Convert.ToInt32( dataGridView1.CurrentRow.Cells["col_item_id"].Value.ToString());
                ami.txt_category_name.Text = dataGridView1.CurrentRow.Cells["col_category"].Value.ToString();
                ami.txt_item_name.Text = dataGridView1.CurrentRow.Cells["col_item_name"].Value.ToString();
                Control cts = this.Parent;
                cts.Controls.Clear();
                cts.Controls.Add(ami);

            }
        }
    }
}



