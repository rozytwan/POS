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

namespace POS_System.Loyality
{
    public partial class Loyality_Itemwise : UserControl
    {
        public Loyality_Itemwise()
        {
            InitializeComponent();
        }
        public static int item_id;
        BLLMenuItem bllproduct = new BLLMenuItem();
        private void Loyality_Itemwise_Load(object sender, EventArgs e)
        {
            item_id = 0;
           
            DataTable dt = bllproduct.getproductitems();
            if (dt.Rows.Count > 0)
            {
                dgv_productitems.Rows.Clear();


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int sd = dgv_productitems.Rows.Add();

                    dgv_productitems.Rows[i].Cells["col_itemid"].Value = dt.Rows[i]["item_id"].ToString();
                    dgv_productitems.Rows[i].Cells["col_productitem"].Value = dt.Rows[i]["item_name"].ToString();
                    int categoryid = Convert.ToInt32(dt.Rows[i]["category_id"].ToString());
                    DataTable dt1 = bllproduct.getcategorybycategoryid(categoryid);
                    dgv_productitems.Rows[i].Cells["col_category"].Value = dt1.Rows[0]["category_name"].ToString();
                    dgv_productitems.Rows[i].Cells["col_costprice"].Value = dt.Rows[i]["item_cost_price"].ToString();
                    dgv_productitems.Rows[i].Cells["col_sellingprice"].Value = dt.Rows[i]["item_price"].ToString();
                    dgv_productitems.Rows[i].Cells["col_kotprint"].Value = dt.Rows[i]["kot_print"].ToString();
                    dgv_productitems.Rows[i].Cells["col_applicable_time_period"].Value = dt.Rows[i]["applicable_time_period"].ToString();

                }
                dgv_productitems.ClearSelection();
            }
            else
            {
                dgv_productitems.Rows.Clear();
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dgv_productitems.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dr in dgv_productitems.SelectedRows)
                {
                    item_id = Convert.ToInt32(dr.Cells["col_itemid"].Value);
                }
                ADDMenuItem addproitems = new ADDMenuItem();
                panel1.Controls.Clear();
                panel1.Controls.Add(addproitems);
            }
            else
            {
                MessageBox.Show("Please Select A Row", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgv_productitems.SelectedRows.Count > 0)
            {
                DialogResult dig = MessageBox.Show("Are You Sure To Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dig == DialogResult.Yes)
                {
                    foreach (DataGridViewRow dr in dgv_productitems.SelectedRows)
                    {

                        item_id = Convert.ToInt32(dgv_productitems.CurrentRow.Cells["col_itemid"].Value);
                        int deletefrom_tbl_dayswise = bllproduct.deleterecords(item_id);
                        int absmc = bllproduct.deleteproductitems(item_id);
                        if (absmc > 0)
                        {
                            MessageBox.Show("Successfully Deleted", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        dgv_productitems.Rows.RemoveAt(dr.Index); //removes the deleted row
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select A Row", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txt_searchbox_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                DataTable dt = bllproduct.getproductbyproductname(txt_searchbox.Text);
                if (dt.Rows.Count > 0)
                {

                    dgv_productitems.Rows.Clear();
                    dgv_productitems.ClearSelection();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dgv_productitems.Rows.Add();
                        dgv_productitems.Rows[i].Cells["col_itemid"].Value = dt.Rows[i]["item_id"].ToString();
                        dgv_productitems.Rows[i].Cells["col_productitem"].Value = dt.Rows[i]["item_name"].ToString();
                        int categoryid = Convert.ToInt32(dt.Rows[i]["category_id"].ToString());
                        DataTable dt1 = bllproduct.getcategorybycategoryid(categoryid);
                        dgv_productitems.Rows[i].Cells["col_category"].Value = dt1.Rows[0]["category_name"].ToString();
                        dgv_productitems.Rows[i].Cells["col_costprice"].Value = dt.Rows[i]["item_cost_price"].ToString();
                        dgv_productitems.Rows[i].Cells["col_sellingprice"].Value = dt.Rows[i]["item_price"].ToString();
                        dgv_productitems.Rows[i].Cells["col_kotprint"].Value = dt.Rows[i]["kot_print"].ToString();
                        dgv_productitems.Rows[i].Cells["col_applicable_time_period"].Value = dt.Rows[i]["applicable_time_period"].ToString();

                    }
                }

            }
            else if (comboBox1.SelectedIndex == 1)
            {
                DataTable dtb = bllproduct.getcategorybycategoryNames(txt_searchbox.Text);

                if (dtb.Rows.Count > 0)
                {
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        DataTable dtb1 = bllproduct.getcategoryDetailsByCategoryIds(Convert.ToInt32(dtb.Rows[i]["category_id"].ToString()));
                        //if (txt_searchbox.Text == category_Id)
                        //{
                        if (dtb1.Rows.Count > 0)
                        {
                            dgv_productitems.Rows.Clear();
                            for (int j = 0; j < dtb1.Rows.Count; j++)
                            {
                                DataTable getcategoryName = bllproduct.getcategorybycategoryid(Convert.ToInt32(dtb1.Rows[j]["category_id"].ToString()));
                                string SetCategoryname = getcategoryName.Rows[0]["category_name"].ToString();
                                dgv_productitems.Rows.Add();
                                dgv_productitems.Rows[j].Cells["col_itemid"].Value = dtb1.Rows[j]["item_id"].ToString();
                                dgv_productitems.Rows[j].Cells["col_productitem"].Value = dtb1.Rows[j]["item_name"].ToString();
                                dgv_productitems.Rows[j].Cells["col_category"].Value = SetCategoryname;
                                dgv_productitems.Rows[j].Cells["col_costprice"].Value = dtb1.Rows[j]["item_cost_price"].ToString();
                                dgv_productitems.Rows[j].Cells["col_sellingprice"].Value = dtb1.Rows[j]["item_price"].ToString();
                                dgv_productitems.Rows[j].Cells["col_kotprint"].Value = dtb1.Rows[j]["kot_print"].ToString();
                                dgv_productitems.Rows[j].Cells["col_applicable_time_period"].Value = dtb1.Rows[j]["applicable_time_period"].ToString();
                            }
                        }
                        dgv_productitems.ClearSelection();
                        //}
                    }
                }
            }
            // } for loop
        }

        private void dgv_productitems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgv_productitems.Columns["col_loyality"].Index && e.RowIndex >= 0)
            {

            }
            }
        }
}
