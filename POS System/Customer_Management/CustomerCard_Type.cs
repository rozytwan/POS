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
namespace POS_System.Customer_Management
{
    public partial class CustomerCard_Type : UserControl
    {
        public CustomerCard_Type()
        {
            InitializeComponent();
        }
        blllCustomerDetailednyo customer = new blllCustomerDetailednyo();
        private void CustomerCard_Type_Load(object sender, EventArgs e)
        {
            Loadcardtype();
            btn_update.Enabled = false;
        }
        public void Loadcardtype()
        {
            DataTable dt = customer.GetCardType();
                if(dt.Rows.Count>0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_id"].Value = dt.Rows[i]["card_type_id"].ToString();

                    dataGridView1.Rows[i].Cells["col_card_type"].Value = dt.Rows[i]["card_type_name"].ToString();
                }
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txt_card_type.Text == "")
            {
                MessageBox.Show("Choose Card Type first");
            }
            else
            {
                DataTable dt = customer.SearchCardType(txt_card_type.Text);
                {
                    if (dt.Rows.Count == 0)
                    {
                        int insert = customer.InsertCardType(txt_card_type.Text);
                        Loadcardtype();
                        refresh();
                    }
                    else
                    {
                        MessageBox.Show("This Card Type is already exist");
                    }
                }
            }
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (txt_card_type.Text == "")
            {
                MessageBox.Show("Choose Card Type first");
            }
            else
            {
                int update = customer.UpdateCardType(id, txt_card_type.Text);
                Loadcardtype();
                refresh();
                btn_add.Enabled = true;
                btn_update.Enabled = false;
            }
        }
        private void btn_back_Click(object sender, EventArgs e)
        {

        }
        public void refresh()
        {
            txt_card_type.Text = "";
            id = 0;
        }
        public static int id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col_edit"].Index && e.RowIndex > 0)
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_id"].Value.ToString());

                txt_card_type.Text = dataGridView1.CurrentRow.Cells["col_card_type"].Value.ToString();
                btn_add.Enabled = false;
                btn_update.Enabled = true;
            }
            else if (e.ColumnIndex == dataGridView1.Columns["col_delete"].Index && e.RowIndex >= 0)
            {
                var confirmResult = MessageBox.Show("Are you sure to delete this item ??",
                                     "Confirm Delete!!",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                     id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_id"].Value.ToString());

                    int delete = customer.DeleteCardType(id);
                    if (delete > 0)
                    {
                        MessageBox.Show("Card Type is deleted successfully");

                        Loadcardtype();
                    }
                }
                if (confirmResult == DialogResult.No)
                {

                }

            }
            
        }

   
    }
}
