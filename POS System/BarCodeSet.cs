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
    public partial class BarCodeSet : UserControl
    {
        public BarCodeSet()
        {
            InitializeComponent();
        }
        BLLInhouse_Unit blin = new BLLInhouse_Unit();
        BLLOrder blod = new BLLOrder();
        BLLProduct blpur = new BLLProduct();
        BLLCategory blcat = new BLLCategory();
        BLLBarCode blbar = new BLLBarCode();
        private void BarCodeSet_Load(object sender, EventArgs e)
        {
            Menu_category();
            category_product();
            datagridviewload();
        }
        public void category_product()
        {
            DataTable dt = blcat.getallcategory();
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
        public void Menu_category()
        {
            DataTable dt = blod.getallcategory();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["category_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cboitemcategory.DataSource = dt;
                cboitemcategory.DisplayMember = "category_name";
                cboitemcategory.ValueMember = "category_id";

            }
        }

        private void cbocategorynamess_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbocategorynamess.Text != "" && cbocategorynamess.Text != "Choose One" && cbocategorynamess.SelectedIndex != 0)
            {
                DataTable dt = blpur.getproductid(Convert.ToInt32(cbocategorynamess.SelectedValue.ToString()));
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["product_name"] = "Choose One";
                    cboproductname.DataSource = dt;
                    cboproductname.ValueMember = "product_id";
                    cboproductname.DisplayMember = "product_name";
                }
            }
        }

        private void cboitemcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboitemcategory.Text != "" && cboitemcategory.Text != "Choose One" && cboitemcategory.SelectedIndex != 0)
            {
                DataTable dt = blod.getalldatafromitem(Convert.ToInt32(cboitemcategory.SelectedValue.ToString()));
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["item_name"] = "Choose One";
                    dt.Rows.InsertAt(dr, 0);
                    cboItem_Name.DataSource = dt;
                    cboItem_Name.ValueMember = "item_id";
                    cboItem_Name.DisplayMember = "item_name";
                }
            }
        }

        public void datagridviewload()
        {
            try
            {
                DataTable dt = blbar.get_all_item_barcode();
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int i = 0; dt.Rows.Count > i; i++)
                    {
                        int abc = dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells["cal_sn"].Value = i + 1;
                        dataGridView1.Rows[i].Cells["cal_product_id"].Value = dt.Rows[i]["product_id"].ToString();
                        int product_id = Convert.ToInt32(dataGridView1.Rows[i].Cells["cal_product_id"].Value);
                        DataTable dt_product_id = blpur.getallproductid(product_id);
                        dataGridView1.Rows[i].Cells["cal_product_name"].Value = dt_product_id.Rows[0]["product_name"].ToString();
                        dataGridView1.Rows[i].Cells["calitem_id"].Value = dt.Rows[i]["item_id"].ToString();
                        int item_id = Convert.ToInt32(dataGridView1.Rows[i].Cells["calitem_id"].Value);
                        DataTable dt_item_name = blod.getallitemprice(item_id);
                        dataGridView1.Rows[i].Cells["calitem_name"].Value = dt_item_name.Rows[0]["item_name"].ToString();
                        dataGridView1.Rows[i].Cells["cal_bar_code"].Value = dt.Rows[i]["bar_code"].ToString();
                        dataGridView1.Rows[i].Cells["cal_bar_code_id"].Value = dt.Rows[i]["bar_code_id"].ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (cbocategorynamess.Text != "" && cbocategorynamess.Text != "Choose One" && cbocategorynamess.SelectedIndex != 0)
            {
                if (cboitemcategory.Text != "" && cboitemcategory.Text != "Choose One" && cboitemcategory.SelectedIndex != 0)
                {
                    if (txtbar_code.Text != "")
                    {
                        DataTable dt = blbar.get_all_byitenm_id(Convert.ToInt32(cboItem_Name.SelectedValue));
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Bar Code Has Been Already Saved", "Data Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            int insert_bar_code = blbar.insert_bar_code(Convert.ToInt32(cboproductname.SelectedValue), Convert.ToInt32(cboItem_Name.SelectedValue), txtbar_code.Text);
                            if (insert_bar_code > 0)
                            {
                                MessageBox.Show("Bar Code Has Been Sucessfully Saved", "Data Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cboItem_Name.Text = "";
                                cboproductname.Text = "";
                                txtbar_code.Text = "";
                                Menu_category();
                                category_product();
                                datagridviewload();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bar Code Textbox Is Empty.Please Check The Value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Menu Item Textbox Is Empty.Please Check The Value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Stock Product Textbox Is Empty.Please Check The Value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["cal_update"].Index && e.RowIndex >= 0)
            {
                if (dataGridView1.CurrentRow.Cells["cal_bar_code"].Value.ToString() != "")
                {
                    int update_bar_code = blbar.update_barcode(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_bar_code_id"].Value), dataGridView1.CurrentRow.Cells["cal_bar_code"].Value.ToString());
                    if (update_bar_code > 0)
                    {
                        MessageBox.Show("Bar Code Has Been Update", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else if (e.ColumnIndex == dataGridView1.Columns["cal_delete"].Index && e.RowIndex > 0)
            {
                DialogResult dig = MessageBox.Show("Do You Like To Delete", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dig == DialogResult.Yes)
                {
                    int delete_barcode = blbar.delete_barcode(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_bar_code_id"].Value));
                    if (delete_barcode > 0)
                    {
                        MessageBox.Show("Bar Code Has Been Delete", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            allmenu als = new allmenu();
            ctls.Controls.Clear();
            ctls.Controls.Add(als);
        }
    }
}
