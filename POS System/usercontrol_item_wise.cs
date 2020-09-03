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
    public partial class usercontrol_item_wise : UserControl
    {
        public usercontrol_item_wise()
        {
            InitializeComponent();
        }
        BLLCustomer_wise cs = new BLLCustomer_wise();

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "")
            {
                MessageBox.Show("inputs are empty");
            }
            else
            {

                if (txtusername.Text.Length > 0)
                {
                    DataTable dt = new DataTable();
                    dt = cs.getitembyitemname(txtusername.Text);

                    for (int bb = 0; bb < dt.Rows.Count; bb++)
                    {
                        decimal total = Convert.ToDecimal(dt.Rows[bb]["paid_amount"]) * Convert.ToInt32(dt.Rows[bb]["quantity"]);


                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[bb].Cells["calcustomer"].Value = dt.Rows[bb]["username"].ToString();
                        dataGridView1.Rows[bb].Cells["caltable"].Value = dt.Rows[bb]["table_no"].ToString();
                        dataGridView1.Rows[bb].Cells["calitem"].Value = dt.Rows[bb]["items"].ToString();
                        dataGridView1.Rows[bb].Cells["calquantity"].Value = dt.Rows[bb]["quantity"].ToString();
                        dataGridView1.Rows[bb].Cells["caldate"].Value = dt.Rows[bb]["date"].ToString();
                        dataGridView1.Rows[bb].Cells["calitemprice"].Value = dt.Rows[bb]["paid_amount"].ToString();
                        dataGridView1.Rows[bb].Cells["caltotal"].Value = total.ToString();
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

        private void usercontrol_item_wise_Load(object sender, EventArgs e)
        {
            txtusername.Focus();
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(11, 81, 126);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersHeight = 60;
        }
    }
}
