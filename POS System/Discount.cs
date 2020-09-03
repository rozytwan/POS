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
    public partial class Discount : Form
    {
        public Discount()
        {
            InitializeComponent();
        }
        BLLdiscount blld = new BLLdiscount();

        private void Discount_Load(object sender, EventArgs e)
        {
            loaddiscount();
            btn_save.Enabled = true;
            btn_update.Enabled = false;
     

        }
        public void loaddiscount()
        {
            dataGridView1.Rows.Clear();
            DataTable dt = blld.GetDiscount();
            for (int qw = 0; qw < dt.Rows.Count; qw++)
            {
                dataGridView1.Rows.Add(dt.Rows[qw]["discount_id"].ToString(), dt.Rows[qw]["discount_name"].ToString(), dt.Rows[qw]["discount"].ToString());
 }
  }

        private void btn_save_Click(object sender, EventArgs e)
        {
            DataTable dt = blld.Select_name(txt_name.Text);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Already exists", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
               // txt_discount_holder.Text = dt.Rows[0]["discount"].ToString();

            int insert = blld.InsertDiscount(txt_name.Text, Convert.ToDecimal(txt_discount_amount.Text));
                loaddiscount();
                clear();
            }
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            int update = blld.UpdateDiscount(discount_id, txt_name.Text, Convert.ToDecimal(txt_discount_amount.Text));

            loaddiscount();
            clear();
        }
        public void clear()
        {
            txt_discount_amount.Text = "";
            txt_name.Text = "";
        }
        int discount_id;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col_edit"].Index && e.RowIndex >= 0)
            {
                discount_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_discount_id"].Value.ToString());
                txt_name.Text = dataGridView1.CurrentRow.Cells["col_discount_name"].Value.ToString();
                txt_discount_amount.Text = dataGridView1.CurrentRow.Cells["col_discount_amount"].Value.ToString();
                btn_update.Enabled = true;
                btn_save.Enabled = false;
            }
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            btn_save.Enabled = true;
            btn_update.Enabled = false;
            clear();

        }

        private void toggleSwitch1_Properties_Click(object sender, EventArgs e)
        {
            if (switch_discount_checker.IsOn)
            {
                txt_discount_amount.ReadOnly = false;
                txt_discount_percent.ReadOnly = true;
            }
            else
            {
                txt_discount_percent.ReadOnly = false;
                txt_discount_amount.ReadOnly = true;
            }
        }

    private void txt_discount_amount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_discount_amount_TextChanged(object sender, EventArgs e)
        {
            if (!switch_discount_checker.IsOn)
            {
                if (txt_discount_amount.Text != "")
                {
                    txt_discount_percent.Text = Convert.ToString(Convert.ToDecimal(txt_discount_amount.Text) / 100);

                }
                else
                {
                    txt_discount_percent.Text = "";
                }
            }
        }
        private void txt_discount_percent_TextChanged(object sender, EventArgs e)
        {
            if (switch_discount_checker.IsOn)
            {
                if (txt_discount_percent.Text != "")
                {
                    txt_discount_amount.Text = (Convert.ToDecimal(txt_discount_percent.Text) / 100).ToString("#.##");

                }
                else
                {
                    txt_discount_amount.Text = "";
                }
            }
        }
    }
}
