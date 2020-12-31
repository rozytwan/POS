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
    public partial class UserControl_product_add : UserControl
    {
        public UserControl_product_add()
        {
            InitializeComponent();
        }
        BLLCategory blcat = new BLLCategory();

        BLLCategoryGrouping blcg = new BLLCategoryGrouping();
        private void UserControl_product_add_Load_1(object sender, EventArgs e)
        {
            showallcartegory();
            loadcategory();
            dgv_category.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(11, 81, 126);
            dgv_category.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv_category.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            dgv_category.EnableHeadersVisualStyles = false;
            dgv_category.ColumnHeadersHeight = 60;
        }
        public void loadcategory()
        {
            DataTable dt = blcg.GetStockGrouping();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["group_name"] = "Choose Grouping";
                dr["id"] = "0";
                dt.Rows.InsertAt(dr, 0);

                cbo_group_category.DataSource = dt;
                cbo_group_category.DisplayMember = "group_name";
                cbo_group_category.ValueMember = "id";
            }
        }
        public void showallcartegory()
        {
            DataTable dt = blcat.getallcategorydecending();
            if (dt.Rows.Count > 0)
            {
                dgv_category.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int abc = dgv_category.Rows.Add();
                    dgv_category.Rows[i].Cells["calcategory"].Value = dt.Rows[i]["category_name"].ToString();
                    dgv_category.Rows[i].Cells["cal_category_id"].Value = dt.Rows[i]["category_id"].ToString();

                }
            }

        }


        private void btncategoryadd_Click(object sender, EventArgs e)
        {
            if (txtaddcategory.Text == "" && txtaddcategory.Text == null)
            {
                MessageBox.Show("Insert reuqired field..", "TextBox Is Empty", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else
            {
                if (btncategoryadd.Text == "Update")
                {
                    if (category_id > 0)
                    {
                        int abc = blcat.updatecategory(category_id, txtaddcategory.Text, Convert.ToInt32(cbo_group_category.SelectedValue));
                        if (abc > 0)
                        {
                            showallcartegory();
                            txtaddcategory.Text = "";
                            cbo_group_category.SelectedIndex = 0;
                            btncategoryadd.Text = "Add Category";
                        }

                    }
                }
                else
                {
                    if (MessageBox.Show("Are you sure want to Add?", "Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        DataTable dt = blcat.checkcategory(txtaddcategory.Text);
                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0][1].ToString() == txtaddcategory.Text)
                            {

                                MessageBox.Show("This Category Has Been Already Insert", "Already Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                        }
                        else
                        {
                            int i = blcat.addcategory(txtaddcategory.Text, Convert.ToInt32(cbo_group_category.SelectedValue));
                            if (i > 0)
                            {
                                showallcartegory();
                            }
                        }
                    }
                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            if (second_user_interface.BusinessType == "Parlour")
            {
                Parlour al = new Parlour();
                Control ctls = this.Parent;
                ctls.Controls.Clear();
                ctls.Controls.Add(al);
            }
            else
            {
                Control ctls = this.Parent;
                allmenu alls = new allmenu();
                ctls.Controls.Clear();
                ctls.Controls.Add(alls);
            }
        }
        private void txtaddcategory_KeyDown(object sender, KeyEventArgs e)
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

        private void txtcategory_search_TextChanged(object sender, EventArgs e)
        {

            if (txtcategory_search.Text != "" && txtcategory_search.Text.Length > 0)
            {
                DataTable dt = blcat.getallitemcategory_byitemscategory(txtcategory_search.Text);
                if (dt.Rows.Count > 0)
                {
                    dgv_category.Rows.Clear();
                    for (int inc = 0; inc < dt.Rows.Count; inc++)
                    {
                        int b = dgv_category.Rows.Add();
                        dgv_category.Rows[inc].Cells["calcategory"].Value = dt.Rows[inc]["category_name"].ToString();
                        dgv_category.Rows[inc].Cells["cal_category_id"].Value = dt.Rows[inc]["category_id"].ToString();
                    }
                }
            }
            else if (txtcategory_search.Text == "")
            {
                showallcartegory();
            }
        }


        int category_id;
        private void dgv_category_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == dgv_category.Columns["cal_edit"].Index && e.RowIndex >= 0))
            {
                if (dgv_category.Rows.Count > 0)
                {
                    category_id = Convert.ToInt32(dgv_category.CurrentRow.Cells["cal_category_id"].Value);
                    txtaddcategory.Text = dgv_category.CurrentRow.Cells["calcategory"].Value.ToString();
                    DataTable dt = blcg.GetStockCategoryById(category_id);
                    if (dt.Rows.Count > 0)
                    {
                        int id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                        DataTable dt1 = blcg.GetAllProductGrouping(id);
                        if (dt1.Rows.Count > 0)
                        {
                            cbo_group_category.Text = dt1.Rows[0]["group_name"].ToString();
                        }
                        else
                        {
                            if (cbo_group_category.Text != "")
                                cbo_group_category.SelectedIndex = 0;
                        }
                        btncategoryadd.Text = "Update";
                    }
                }
            }
        }
    }
}
