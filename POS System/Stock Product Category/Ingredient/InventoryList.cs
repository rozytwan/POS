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
    public partial class InventoryList : UserControl
    {
        public InventoryList()
        {
            InitializeComponent();
        }
        BLLS.Bll_inventory.bll_inv biv = new BLLS.Bll_inventory.bll_inv();

        BLLOrder blod = new BLLOrder();
        BLLProduct blpur = new BLLProduct();
        BLLCategory blcat = new BLLCategory();
        private void InventoryList_Load(object sender, EventArgs e)
        {
            contents_panel.Hide();
            Menu_category();
            cbo_searchTYpe.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            allmenu alls = new allmenu();
            ctls.Controls.Clear();
            ctls.Controls.Add(alls);
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            allmenu alls = new allmenu();
            ctls.Controls.Clear();
            ctls.Controls.Add(alls);
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.SelectedIndex == 0 || txt_searchText.SelectedIndex == 0) {
                MessageBox.Show("Choose Menu Category and its Menu Names");
            }
            else
            {
                DataTable getExistingItem = biv.getalldatabyMunuId(txt_searchText.Text);
                if (getExistingItem.Rows.Count > 0)
                {
                    contents_panel.Show();

                    for (int i = 0; i < getExistingItem.Rows.Count; i++)
                    {
                        dataGridView1.Rows.Add(getExistingItem.Rows[i]["menu_cat_id"].ToString(), getExistingItem.Rows[i]["MenuName"].ToString(), getExistingItem.Rows[i]["inv_cat_id"].ToString(), getExistingItem.Rows[i]["inv_productName"].ToString(), getExistingItem.Rows[i]["unit"].ToString(), getExistingItem.Rows[i]["unitMeasures"].ToString());
                    }

                }
                else
                {
                    MessageBox.Show("No Data to Show.");
                }
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
                cbo_searchTYpe.DataSource = dt;
                cbo_searchTYpe.DisplayMember = "category_name";
                cbo_searchTYpe.ValueMember = "category_id";

            }
        }

        private void cbo_searchTYpe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_searchTYpe.SelectedIndex > 0)
            {
                DataTable dt = blod.getalldatafromitem(Convert.ToInt32(cbo_searchTYpe.SelectedValue.ToString()));
                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["item_name"] = "Choose One";
                    dt.Rows.InsertAt(dr, 0);
                    txt_searchText.DataSource = dt;
                    txt_searchText.ValueMember = "item_name";
                    txt_searchText.DisplayMember = "item_name";
                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            contents_panel.Hide();
            searchPanel.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
