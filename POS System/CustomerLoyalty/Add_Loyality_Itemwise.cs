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
    public partial class Add_Loyality_Itemwise : UserControl
    {
        public Add_Loyality_Itemwise()
        {
            InitializeComponent();
        }
        BLLProduct blpro = new BLLProduct();
        BLLLoyalty blll = new BLLLoyalty();
        public void products()
        {
            DataTable dt = blpro.getallItems();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["item_name"] = "Choose One";
                dt.Rows.InsertAt(dr, 0);
                cbo_item.DataSource = dt;
                cbo_item.DisplayMember = "item_name";
                cbo_item.ValueMember = "item_id";

            }
        }
    
        private void Add_Loyality_Itemwise_Load(object sender, EventArgs e)
        {
            btn_save.Enabled = true;
            btn_update.Enabled = false;
            products();
            DataGridViewLoad();
        }
        public void DataGridViewLoad()
        {
            DataTable dt = blll.GetLoyalityItemwise();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_id"].Value = dt.Rows[i]["id"].ToString();
                    dataGridView1.Rows[i].Cells["col_item_id"].Value = dt.Rows[i]["item_id"].ToString();
                    dataGridView1.Rows[i].Cells["col_item"].Value = dt.Rows[i]["item_name"].ToString();  
                    dataGridView1.Rows[i].Cells["col_qty"].Value = dt.Rows[i]["qty"].ToString();
                    dataGridView1.Rows[i].Cells["col_points"].Value = dt.Rows[i]["points"].ToString();
                    dataGridView1.Rows[i].Cells["col_status"].Value = dt.Rows[i]["status"].ToString();
                }
            }
            dataGridView1.ClearSelection();
        }
        public void Clear()
        {
            cbo_item.Text = "";
            txt_qty.Text = "";
            txt_points.Text = "";
            rbn_true.Checked = true;
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            DataTable dt = blll.GetLoyalityItemId(Convert.ToInt32(cbo_item.SelectedValue));
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Data Already Exist Alert !!", "Exist Alert !!");
            }
            else
            {
                int save = blll.Insert_LoyalityItem(Convert.ToInt32(cbo_item.SelectedValue), Convert.ToDecimal(txt_qty.Text), Convert.ToInt32(txt_points.Text), status);
                if (save > 0)
                {
                    MessageBox.Show("Inserted Successfully !!", "Success Alert !!");
                    Clear();
                }
                DataGridViewLoad();
            }
        }
        private void btn_back_Click(object sender, EventArgs e)
        {

        }
        public int id;
        private void btn_edit_Click(object sender, EventArgs e)
        {
            btn_save.Enabled = false;
            btn_update.Enabled = true;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow dr in dataGridView1.SelectedRows)
                {
                    id = Convert.ToInt32(dr.Cells["col_id"].Value);
                    DataTable dt = blll.GetLoyalityId(id);
                    if (dt.Rows.Count > 0)
                    {
                        cbo_item.Text = dt.Rows[0]["item_name"].ToString();
                        txt_qty.Text = dt.Rows[0]["qty"].ToString();
                        txt_points.Text = dt.Rows[0]["points"].ToString();
                        if (dt.Rows[0]["status"].ToString() == "True")
                        {
                            rbn_true.Checked = true;
                        }
                        else
                        {
                            rbn_false.Checked = false;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select A Row", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (status == null)
            {
                status = "True";
            }
            int update = blll.Update_LoyalityItem(id,Convert.ToInt32(cbo_item.SelectedValue), Convert.ToDecimal(txt_qty.Text), Convert.ToInt32(txt_points.Text), status);
            if (update > 0)
            {
                MessageBox.Show("Updated Successfully !!", "Success Alert !!");
                Clear();
            }
            DataGridViewLoad();
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

        private void txt_points_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        string status;
        private void rbn_true_Click(object sender, EventArgs e)
        {
            rbn_true.Checked = true;
            status = "True";
        }

        private void rbn_false_Click(object sender, EventArgs e)
        {
            rbn_false.Checked = true;
            status = "False";
        }
    }
}
