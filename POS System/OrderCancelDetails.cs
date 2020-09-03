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
    public partial class OrderCancelDetails : Form
    {
        public OrderCancelDetails()
        {
            InitializeComponent();
        }
        BLLOrder blod = new BLLOrder();
        private void OrderCancelDetails_Load(object sender, EventArgs e)
        {
            LoadDatagrid();
            lbl_today.Text = DateTime.Now.ToString();
        }
        public void LoadDatagrid()
        {
            DataTable dt = blod.cancelitemGroup(Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            if (dt.Rows.Count > 0)
            {

                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_item"].Value = dt.Rows[i]["item"].ToString();
                    dataGridView1.Rows[i].Cells["col_quantity"].Value = dt.Rows[i]["quantity"].ToString();
                    dataGridView1.Rows[i].Cells["col_cost"].Value = dt.Rows[i]["cost"].ToString();

                }
            }
            // itm.printcalcel();
            //this.Close();
            //DayEndReport dayer = new DayEndReport();
            //dayer.ShowDialog();
            //  exportItemQuantity();
        }
        DataTable dti = new DataTable();
        ItemPrint itm = new ItemPrint();
        private void btn_order_cancel_Click(object sender, EventArgs e)
        {
            dti = blod.cancelitemGroup(Convert.ToDateTime(DateTime.Now.ToShortDateString()));
            if (dti.Rows.Count > 0)
            {
                itm.cashier = Login.sendtext;
                itm.date_from = DateTime.Now.ToShortDateString();

                for (int i = 0; i < dti.Rows.Count; i++)
                {
                    itm.datagridview_name.Add(dti.Rows[i]["item"].ToString());

                    itm.datagridview_qty.Add(dti.Rows[i]["quantity"].ToString());
                    itm.datagridview_cost.Add(dti.Rows[i]["cost"].ToString());
                    //  itm.datagridview_name.Add(dti.Rows[i]["cancel_type"].ToString());

                }
                itm.printcalcel();
                this.Close();
                //DayEndReport dayer = new DayEndReport();
                //dayer.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

