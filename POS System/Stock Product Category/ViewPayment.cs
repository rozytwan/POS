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
    public partial class ViewPayment : UserControl
    {
        public ViewPayment()
        {
            InitializeComponent();
        }
        BLLPurchase bllp = new BLLPurchase();
        int sup_id = SupplierPurchase.sup_id;
        string supplier_name = SupplierPurchase.supplier_name;
        private void ViewPayment_Load(object sender, EventArgs e)
        {
            DataGridViewLoad();
        }
        public void DataGridViewLoad()
        {
            DataTable dt = bllp.GetViewPayment(sup_id);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_payid"].Value = dt.Rows[i]["pay_id"].ToString();
                    dataGridView1.Rows[i].Cells["col_supplier"].Value = supplier_name;
                    dataGridView1.Rows[i].Cells["col_total_purchase"].Value = dt.Rows[i]["total_purchase"].ToString();
                    dataGridView1.Rows[i].Cells["col_pay"].Value = dt.Rows[i]["purchase_pay"].ToString();
                    dataGridView1.Rows[i].Cells["col_remain"].Value = dt.Rows[i]["remaining"].ToString();
                    dataGridView1.Rows[i].Cells["col_date"].Value = dt.Rows[i]["pay_date"].ToString();
                 
                }
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Control ctrl = this.Parent;
            SupplierPurchase sp = new SupplierPurchase();
            ctrl.Controls.Clear();
            ctrl.Controls.Add(sp);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == dataGridView1.Columns["col_edit"].Index)
            //{
            //    int pay_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_payid"].Value.ToString());
            //    //  txt_credit_id.Text = dataGridView2.CurrentRow.Cells["col_credit_pay_id"].Value.ToString();

            //    PurchasePay objfrm = new PurchasePay(supplier_name,);
            //    objfrm.pay_id = pay_id;
            //    objfrm.Show();


            //}
        }
    }
}
