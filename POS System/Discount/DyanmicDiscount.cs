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

namespace POS_System.Discount
{
    public partial class DyanmicDiscount : UserControl
    {
        public DyanmicDiscount()
        {
            InitializeComponent();
        }



        BLLDyanmicDiscount bdd = new BLLDyanmicDiscount();
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txt_discount_type.Text != "")
            {
                DataTable dt = bdd.GetDyanmiDiscountby(txt_discount_type.Text, txt_discount_percent.Text);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("This discount type and discount percent is already exists..");
                }
                else
                {
                    int insert_ihhouse = bdd.inserDyanmicDiscount(txt_discount_type.Text, txt_discount_percent.Text);
                    data_grid_load();
                    txt_discount_type.Text = "";
                    txt_discount_percent.Text = "";
                }

            }
        }
        int discount_id;
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txt_discount_type.Text != "")
            {

                int update_inhouse = bdd.UpdateDyanmicDiscount(txt_discount_type.Text, txt_discount_percent.Text, discount_id);
                if (update_inhouse > 0)
                {
                    MessageBox.Show("Dyanmic Discount Has Been Update");
                    data_grid_load();
                    txt_discount_type.Text = "";
                    txt_discount_percent.Text = "";


                }
            }
        }
        public void data_grid_load()
        {
            DataTable dt = bdd.get_all_data();
            dataGridView1.Rows.Clear();
            if (dt.Rows.Count > 0)
            {

                for (int i = 0; dt.Rows.Count > i; i++)
                {
                    int abc = dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["cal_sn"].Value = i + 1;
                    dataGridView1.Rows[i].Cells["cal_discount_type"].Value = dt.Rows[i]["discount_type"].ToString();
                    dataGridView1.Rows[i].Cells["cal_discount_percent"].Value = dt.Rows[i]["discount_percent"].ToString();
                    dataGridView1.Rows[i].Cells["cal_discount_id"].Value = dt.Rows[i]["id"].ToString();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["cal_edit"].Index && e.RowIndex >= 0)
            {
                btnadd.Hide();
                btn_update.Show();
                txt_discount_type.Text = dataGridView1.CurrentRow.Cells["cal_discount_type"].Value.ToString();
                 txt_discount_percent.Text = dataGridView1.CurrentRow.Cells["cal_discount_percent"].Value.ToString();
                discount_id= Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_discount_id"].Value.ToString());
               
            }
            else if (e.ColumnIndex == dataGridView1.Columns["cal_delete"].Index && e.RowIndex >= 0)
            {
                discount_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["cal_discount_id"].Value.ToString());
                int delete_unit = bdd.delete_dyanmicDiscount(discount_id);
                if (delete_unit > 0)
                {
                    MessageBox.Show("Dyanmic Discount Has Been Delete");
                    data_grid_load();
                }
            }
        }

        private void DyanmicDiscount_Load(object sender, EventArgs e)
        {
            btn_update.Hide();
            data_grid_load();
           
        }

        private void txt_discount_percent_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
