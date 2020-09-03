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
    public partial class Item_Modifier : UserControl
    {
        public Item_Modifier()
        {
            InitializeComponent();
        }
        BLLOrder blod = new BLLOrder();
        BLLCategory blcat = new BLLCategory();
        BLLProduct blpro = new BLLProduct();
        BLLUser blu = new BLLUser();
        BLLItem_Modifier blmd = new BLLItem_Modifier();
        private void Item_Modifier_Load(object sender, EventArgs e)
        {
               category();
              grid_view_load();
            cbo_modifier_status.SelectedIndex = 0;

        }
       
        public void category()
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
        private void cbo_item_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_item_name.Text != "" && cbo_item_name.Text != "Choose One")
            {
                DataTable dt = blod.getallbyitem_name(cbo_item_name.Text);
                if (dt.Rows.Count > 0)
                {
                    txtitemprice.Text = dt.Rows[0]["item_price"].ToString();
                    txt_kot_type.Text = dt.Rows[0]["kot_print"].ToString();
                   

                }

            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {

            if (cbo_item_name.Text != "" && cbo_item_name.Text != "Choose One" && txtitemprice.Text != "" && cboitemcategory.Text != "" && txt_modifier_name.Text != ""&&cboitemcategory.Text!="Choose One")
            {
                int insert_modifier = blmd.insert_item_modifier_item(Convert.ToInt32(cbo_item_name.SelectedValue), cboitemcategory.Text, cbo_item_name.Text, Convert.ToDecimal(txtitemprice.Text), txt_modifier_name.Text,cbo_modifier_status.Text);
                if (insert_modifier > 0)
                {
                    grid_view_load();
                }

            }
            else
            {
                MessageBox.Show("Can't Complete Your Transaction. Please Check Your Input Box","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        public void grid_view_load()
        {
            DataTable dt = blmd.get_all_data();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; dt.Rows.Count > i; i++)
                {
                    int ibb = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["cal_sn"].Value = i + 1;
                    dataGridView1.Rows[i].Cells["cal_item_id"].Value = dt.Rows[i]["item_id"].ToString();
                    dataGridView1.Rows[i].Cells["cal_item_name"].Value = dt.Rows[i]["item_name"].ToString();
                    dataGridView1.Rows[i].Cells["cal_modifier_id"].Value = dt.Rows[i]["modifier_id"].ToString();
                    dataGridView1.Rows[i].Cells["cal_price"].Value = dt.Rows[i]["item_price"].ToString();
                    dataGridView1.Rows[i].Cells["cal_category_name"].Value = dt.Rows[i]["category_name"].ToString();
                    dataGridView1.Rows[i].Cells["cal_modifier_name"].Value = dt.Rows[i]["modifier_name"].ToString();

                }
            }
             
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["cal_update"].Index && e.RowIndex >= 0)
            {
                int update_modifier = blmd.update_item_modifier(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_modifier_id"].Value), dataGridView1.CurrentRow.Cells["cal_modifier_name"].Value.ToString(),cbo_modifier_status.Text);

            }
            else if (e.ColumnIndex == dataGridView1.Columns["cal_delete"].Index && e.RowIndex >= 0)
            {
                DialogResult result1 = MessageBox.Show("Delete Item Modifier", "Do You Like To Delete  "+ dataGridView1.CurrentRow.Cells["cal_modifier_name"].Value.ToString(), MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                if (result1 == DialogResult.Yes)
                {
                    int delete_modifier = blmd.delete_item_modifier(Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_modifier_id"].Value));
                    if (delete_modifier > 0)
                    {
                        grid_view_load();
                    }
                    
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

        private void cboitemcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboitemcategory.Text != "" && cboitemcategory.Text != "Choose One"&&cboitemcategory.SelectedIndex!=0)
            {
                DataTable dt = blod.get_item_by_cateogory_id(Convert.ToInt32((cboitemcategory.SelectedValue)));
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["item_name"] = "Choose One";
                    dt.Rows.InsertAt(dr, 0);
                    cbo_item_name.DataSource = dt;
                    cbo_item_name.DisplayMember = "item_name";
                    cbo_item_name.ValueMember = "item_id";
                }

            }
        }

        private void cboitemcategory_SelectionChangeCommitted(object sender, EventArgs e)
        {

            
        }
    }
}
