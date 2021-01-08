using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLS;

namespace POS_System
{
    public partial class ItemTransfer : Form
    {
        public ItemTransfer()
        {
            InitializeComponent();
        }
        BLLTable blta = new BLLTable();
        public List<string> datagridview_item_name = new List<string>();
        public List<string> datagridview_item_price = new List<string>();
        public List<string> datagridview_quantity = new List<string>();
        public List<string> datagridview_total = new List<string>();
        public List<string> datagridview_complementary = new List<string>();
        public List<string> datagridview_order_id = new List<string>();
        public List<string> datagridview_category = new List<string>();
        public List<string> datagridview_kotType = new List<string>();
        public string table_no;
        private void ItemTransfer_Load(object sender, EventArgs e)
        {
            from();
            for (int i = 0; i < datagridview_item_name.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["cal_item_name"].Value = datagridview_item_name[i];
                dataGridView1.Rows[i].Cells["cal_kot_type"].Value = datagridview_kotType[i];
                dataGridView1.Rows[i].Cells["cal_qty"].Value = datagridview_quantity[i];
                dataGridView1.Rows[i].Cells["cal_cost"].Value = datagridview_item_price[i];
                dataGridView1.Rows[i].Cells["cal_total"].Value = datagridview_total[i];
                dataGridView1.Rows[i].Cells["cal_order_id"].Value = datagridview_order_id[i];
                dataGridView1.Rows[i].Cells["cal_status"].Value = "";
                dataGridView1.Rows[i].Cells["cal_category_name"].Value = datagridview_category[i];
            }
            lbl_table_no.Text = table_no;
        }
        public void from()
        {
            DataTable dt = blta.getalltable();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["rest_table_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cbo_table_no_choose.DataSource = dt;
                cbo_table_no_choose.DisplayMember = "rest_table_name";
                cbo_table_no_choose.ValueMember = "rest_table_no";
            }
        }
        int i;
        private void btn_move_Click(object sender, EventArgs e)
        {
            bool Found = false;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //Check if the product Id exists with the same Price
                foreach (DataGridViewRow row in dataGridView2.Rows)
                {

                    if (row.Cells["cal_item_name2"].Value == dataGridView1.CurrentRow.Cells["cal_item_name"].Value)
                    {
                        row.Cells["cal_qty_2"].Value = Convert.ToString(1 + Convert.ToDecimal(row.Cells["cal_qty_2"].Value ?? String.Empty));
                        decimal cost = Convert.ToDecimal(row.Cells["cal_cost_2"].Value);
                        decimal quantitys = Convert.ToDecimal(row.Cells["cal_qty_2"].Value ?? String.Empty);
                        decimal total = quantitys * cost;
                        row.Cells["cal_total_2"].Value = total;
                        Found = true;
                        decimal qty = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_qty"].Value) - 1;
                        dataGridView1.CurrentRow.Cells["cal_qty"].Value = qty;
                        dataGridView1.CurrentRow.Cells["cal_total"].Value = (qty * Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_cost"].Value)).ToString();
                        dataGridView1.CurrentRow.Cells["cal_status"].Value = "Update";
                        if (dataGridView1.CurrentRow.Cells["cal_qty"].Value.ToString() == "0" || dataGridView1.CurrentRow.Cells["cal_qty"].Value.ToString() == "0.00")
                        {

                            row.Cells["cal_status_2"].Value = "I";
                            row.Cells["cal_order_id_2"].Value = dataGridView1.CurrentRow.Cells["cal_order_id"].Value;
                            row.Cells["cal_delete_status"].Value = "True";
                            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                        }
                    }
                }
                if (!Found)
                {
                    if (dataGridView1.CurrentRow.Cells["cal_qty"].Value.ToString() == "1.00" || dataGridView1.CurrentRow.Cells["cal_qty"].Value.ToString() == "1")
                    {
                        i = dataGridView2.Rows.Count;
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[i].Cells["cal_item_name2"].Value = dataGridView1.CurrentRow.Cells["cal_item_name"].Value;
                        dataGridView2.Rows[i].Cells["cal_kot_type_2"].Value = dataGridView1.CurrentRow.Cells["cal_kot_type"].Value;
                        dataGridView2.Rows[i].Cells["cal_qty_2"].Value = 1;
                        dataGridView2.Rows[i].Cells["cal_cost_2"].Value = dataGridView1.CurrentRow.Cells["cal_cost"].Value;
                        dataGridView2.Rows[i].Cells["cal_total_2"].Value = (Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_cost"].Value));
                        dataGridView2.Rows[i].Cells["cal_status_2"].Value = "I";
                        dataGridView2.Rows[i].Cells["cal_category_name2"].Value = dataGridView1.CurrentRow.Cells["cal_category_name"].Value;
                        dataGridView2.Rows[i].Cells["cal_order_id_2"].Value = dataGridView1.CurrentRow.Cells["cal_order_id"].Value;
                        dataGridView2.Rows[i].Cells["cal_delete_status"].Value = "True";
                        dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                    }
                    else
                    {
                        i = dataGridView2.Rows.Count;
                        dataGridView2.Rows.Add();
                        dataGridView2.Rows[i].Cells["cal_item_name2"].Value = dataGridView1.CurrentRow.Cells["cal_item_name"].Value;
                        dataGridView2.Rows[i].Cells["cal_kot_type_2"].Value = dataGridView1.CurrentRow.Cells["cal_kot_type"].Value;
                        dataGridView2.Rows[i].Cells["cal_qty_2"].Value = 1;
                        dataGridView2.Rows[i].Cells["cal_cost_2"].Value = dataGridView1.CurrentRow.Cells["cal_cost"].Value;
                        dataGridView2.Rows[i].Cells["cal_total_2"].Value = (Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_cost"].Value));
                        dataGridView2.Rows[i].Cells["cal_status_2"].Value = "I";
                        dataGridView2.Rows[i].Cells["cal_order_id_2"].Value = dataGridView1.CurrentRow.Cells["cal_order_id"].Value;
                        dataGridView2.Rows[i].Cells["cal_category_name2"].Value = dataGridView1.CurrentRow.Cells["cal_category_name"].Value;
                        decimal qty = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_qty"].Value) - 1;
                        dataGridView1.CurrentRow.Cells["cal_qty"].Value = qty;
                        dataGridView1.CurrentRow.Cells["cal_total"].Value = (qty * Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_cost"].Value)).ToString();
                        dataGridView1.CurrentRow.Cells["cal_status"].Value = "Update";
                        dataGridView2.Rows[i].Cells["cal_delete_status"].Value = "False";


                    }
                }

            }
        }

        private void tbn_cancle_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btn_move_all_row_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                i = dataGridView2.Rows.Count;
                dataGridView2.Rows.Add();
                dataGridView2.Rows[i].Cells["cal_item_name2"].Value = dataGridView1.CurrentRow.Cells["cal_item_name"].Value;
                dataGridView2.Rows[i].Cells["cal_kot_type_2"].Value = dataGridView1.CurrentRow.Cells["cal_kot_type"].Value;
                dataGridView2.Rows[i].Cells["cal_qty_2"].Value = dataGridView1.CurrentRow.Cells["cal_qty"].Value;
                dataGridView2.Rows[i].Cells["cal_cost_2"].Value = dataGridView1.CurrentRow.Cells["cal_cost"].Value;
                dataGridView2.Rows[i].Cells["cal_total_2"].Value = (Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_total"].Value));
                dataGridView2.Rows[i].Cells["cal_status_2"].Value = "I";
                dataGridView2.Rows[i].Cells["cal_category_name2"].Value = dataGridView1.CurrentRow.Cells["cal_category_name"].Value;
                dataGridView2.Rows[i].Cells["cal_order_id_2"].Value = dataGridView1.CurrentRow.Cells["cal_order_id"].Value;
                dataGridView2.Rows[i].Cells["cal_delete_status"].Value = "True";
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
            }
        }
        int j;
        private void btn_move_all_rows_left_Click(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count > 0)
            {
                i = dataGridView1.Rows.Count;
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells["cal_item_name"].Value = dataGridView2.CurrentRow.Cells["cal_item_name2"].Value;
                dataGridView1.Rows[i].Cells["cal_kot_type"].Value = dataGridView2.CurrentRow.Cells["cal_kot_type_2"].Value;
                dataGridView1.Rows[i].Cells["cal_qty"].Value = dataGridView2.CurrentRow.Cells["cal_qty_2"].Value;
                dataGridView1.Rows[i].Cells["cal_cost"].Value = dataGridView2.CurrentRow.Cells["cal_cost_2"].Value;
                dataGridView1.Rows[i].Cells["cal_total"].Value = (Convert.ToDecimal(dataGridView2.CurrentRow.Cells["cal_total_2"].Value));
                dataGridView1.Rows[i].Cells["cal_status"].Value = "U";
                dataGridView1.Rows[i].Cells["cal_category_name"].Value = dataGridView2.CurrentRow.Cells["cal_category_name2"].Value;
                dataGridView1.Rows[i].Cells["cal_order_id"].Value = dataGridView2.CurrentRow.Cells["cal_order_id_2"].Value;
                dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
            }
        }

        private void btn_move_left_Click(object sender, EventArgs e)
        {
            bool Found = false;
            if (dataGridView2.SelectedRows.Count > 0)
            {
                //Check if the product Id exists with the same Price
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {

                    if (row.Cells["cal_item_name"].Value == dataGridView2.CurrentRow.Cells["cal_item_name2"].Value)
                    {
                        row.Cells["cal_qty"].Value = Convert.ToString(1 + Convert.ToDecimal(row.Cells["cal_qty"].Value ?? String.Empty));
                        decimal cost = Convert.ToDecimal(row.Cells["cal_cost"].Value);
                        decimal quantitys = Convert.ToDecimal(row.Cells["cal_qty"].Value ?? String.Empty);
                        decimal total = quantitys * cost;
                        row.Cells["cal_total"].Value = total;
                        Found = true;
                        decimal qty = Convert.ToDecimal(dataGridView2.CurrentRow.Cells["cal_qty_2"].Value) - 1;
                        dataGridView2.CurrentRow.Cells["cal_qty_2"].Value = qty;
                        dataGridView2.CurrentRow.Cells["cal_total_2"].Value = (qty * Convert.ToDecimal(dataGridView2.CurrentRow.Cells["cal_cost_2"].Value)).ToString();
                        dataGridView2.CurrentRow.Cells["cal_status_2"].Value = "U";
                        if (dataGridView2.CurrentRow.Cells["cal_qty_2"].Value.ToString() == "0" || dataGridView2.CurrentRow.Cells["cal_qty_2"].Value.ToString() == "0.00")
                        {

                            row.Cells["cal_status"].Value = "Update";
                            row.Cells["cal_order_id"].Value = dataGridView2.CurrentRow.Cells["cal_order_id_2"].Value;
                            dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
                        }
                    }
                }
                if (!Found)
                {
                    if (dataGridView2.CurrentRow.Cells["cal_qty_2"].Value.ToString() == "1" || dataGridView2.CurrentRow.Cells["cal_qty_2"].Value.ToString() == "1.00")
                    {
                        i = dataGridView1.Rows.Count;
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["cal_item_name"].Value = dataGridView2.CurrentRow.Cells["cal_item_name2"].Value;
                        dataGridView1.Rows[i].Cells["cal_kot_type"].Value = dataGridView2.CurrentRow.Cells["cal_kot_type_2"].Value;
                        dataGridView1.Rows[i].Cells["cal_qty"].Value = 1;
                        dataGridView1.Rows[i].Cells["cal_cost"].Value = dataGridView2.CurrentRow.Cells["cal_cost_2"].Value;
                        dataGridView1.Rows[i].Cells["cal_total"].Value = (Convert.ToDecimal(dataGridView2.CurrentRow.Cells["cal_cost_2"].Value));
                        dataGridView1.Rows[i].Cells["cal_status"].Value = "Update";
                        dataGridView1.Rows[i].Cells["cal_category_name"].Value = dataGridView2.CurrentRow.Cells["cal_category_name2"].Value;
                        dataGridView1.Rows[i].Cells["cal_order_id"].Value = dataGridView2.CurrentRow.Cells["cal_order_id_2"].Value;
                        dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);

                    }
                    else
                    {
                        i = dataGridView1.Rows.Count;
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["cal_item_name"].Value = dataGridView2.CurrentRow.Cells["cal_item_name2"].Value;
                        dataGridView1.Rows[i].Cells["cal_kot_type"].Value = dataGridView2.CurrentRow.Cells["cal_kot_type_2"].Value;
                        dataGridView1.Rows[i].Cells["cal_qty"].Value = 1;
                        dataGridView1.Rows[i].Cells["cal_cost"].Value = dataGridView2.CurrentRow.Cells["cal_cost_2"].Value;
                        dataGridView1.Rows[i].Cells["cal_total"].Value = (Convert.ToDecimal(dataGridView2.CurrentRow.Cells["cal_cost_2"].Value));
                        dataGridView1.Rows[i].Cells["cal_status"].Value = "Update";
                        dataGridView1.Rows[i].Cells["cal_order_id"].Value = dataGridView2.CurrentRow.Cells["cal_order_id_2"].Value;
                        dataGridView1.Rows[i].Cells["cal_category_name"].Value = dataGridView2.CurrentRow.Cells["cal_category_name2"].Value;
                        decimal qty = Convert.ToDecimal(dataGridView2.CurrentRow.Cells["cal_qty_2"].Value) - 1;
                        dataGridView2.CurrentRow.Cells["cal_qty_2"].Value = qty;
                        dataGridView2.CurrentRow.Cells["cal_total_2"].Value = (qty * Convert.ToDecimal(dataGridView2.CurrentRow.Cells["cal_cost_2"].Value)).ToString();


                    }
                }

            }
        }
        BLLOrder blo = new BLLOrder();
        private void btn_item_transfer_Click(object sender, EventArgs e)
        {
            if (lbl_table_no.Text != Convert.ToString(cbo_table_no_choose.SelectedValue))
            {
                if (cbo_table_no_choose.Text != "Choose One" && cbo_table_no_choose.SelectedIndex > 0 && cbo_table_no_choose.Text != "")
                {
                    if (dataGridView2.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {

                            string order_id = dataGridView1.Rows[i].Cells["cal_order_id"].Value.ToString();
                            string qty = dataGridView1.Rows[i].Cells["cal_qty"].Value.ToString();
                            string total = dataGridView1.Rows[i].Cells["cal_total"].Value.ToString();
                            string status = dataGridView1.Rows[i].Cells["cal_status"].Value.ToString();
                            if (status == "Update")
                            {
                                int update = blo.updateorderstable(Convert.ToDecimal(qty), Convert.ToInt32(order_id), Convert.ToDecimal(total));//this stattement will update the item of datagridview1 
                            }
                        }
                        for (int i = 0; i < dataGridView2.Rows.Count; i++)
                        {
                            string order_id = dataGridView2.Rows[i].Cells["cal_order_id_2"].Value.ToString();
                            string qty = dataGridView2.Rows[i].Cells["cal_qty_2"].Value.ToString();
                            string total = dataGridView2.Rows[i].Cells["cal_total_2"].Value.ToString();
                            string category_name = dataGridView2.Rows[i].Cells["cal_category_name2"].Value.ToString();
                            string kot_type = dataGridView2.Rows[i].Cells["cal_kot_type_2"].Value.ToString();
                            string item_name = dataGridView2.Rows[i].Cells["cal_item_name2"].Value.ToString();
                            string cost = dataGridView2.Rows[i].Cells["cal_cost_2"].Value.ToString();
                            string status = dataGridView2.Rows[i].Cells["cal_status_2"].Value.ToString();
                            string table_no = cbo_table_no_choose.SelectedValue.ToString();
                            if (status == "I")
                            {
                                //DataTable dt = blo.getallbyitem_nameandTableno(item_name, table_no);
                                //if (dt.Rows.Count == 0)
                                //{
                                int insert_order = blo.insertorder_using_sp(Login.sendtext, Convert.ToDecimal(table_no), item_name, Convert.ToDecimal(qty), Convert.ToDecimal(total), Convert.ToDecimal(cost), "Y", category_name, kot_type, "TS", "0", 0);//this will insert data of datagridview2  

                                if (dataGridView2.Rows[i].Cells["cal_delete_status"].Value.ToString() == "True")
                                {
                                    int delete_item = blo.deletefromorder_id(Convert.ToInt32(order_id));
                                }
                                //else
                                //{ 
                                //int updateOrder = blo.updateorderItemTransfer(Convert.ToInt32(order_id), Convert.ToDecimal(table_no));
                                // }

                            }
                            else
                            {
                                int updateOrder = blo.updateorderItemTransfer(Convert.ToInt32(order_id), Convert.ToDecimal(table_no));//this will update datagridview2
                            }
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("There is no data to transfer.", "Invalid Item Transfer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                MessageBox.Show("Cannot Transfer Item In Same Table Or Choose Correct Table No. !!", "Invalid Table No Alert !!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
