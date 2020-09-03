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
    public partial class SupplierPurchase : UserControl
    {
        public SupplierPurchase()
        {
            InitializeComponent();
        }
        BLLPurchase bllp = new BLLPurchase();
        private void SupplierPurchase_Load(object sender, EventArgs e)
        {
            DataGridViewLoad();
        }
        decimal purchase_pay;
        public void DataGridViewLoad()
        {
            DataTable dt = bllp.GetSupplierDetails();
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    string supplier_name = dt.Rows[i]["supplier_name"].ToString();
                    dataGridView1.Rows[i].Cells["col_supplier"].Value = dt.Rows[i]["supplier_name"].ToString();
                    dataGridView1.Rows[i].Cells["col_grand_total"].Value = dt.Rows[i]["grand_total"].ToString();

                     DataTable dt2 = bllp.Getsupplier(supplier_name);
                    if (dt2.Rows.Count > 0)
                    {
                        dataGridView1.Rows[i].Cells["col_sup_id"].Value = dt2.Rows[0]["sup_id"].ToString();
                        int supplier_id = Convert.ToInt32(dt2.Rows[0]["sup_id"].ToString());
                        DataTable dt3 = bllp.SumPayment(supplier_id);
                        if (dt3.Rows.Count>0)
                        {
                            if (dt3.Rows[0]["purcharse_pay"].ToString()=="")
                            {
                                purchase_pay = 0;
                            }
                            else
                            {
                                purchase_pay = Convert.ToDecimal(dt3.Rows[0]["purcharse_pay"].ToString());
                            }
                                dataGridView1.Rows[i].Cells["col_remain"].Value =Convert.ToDecimal(dt.Rows[i]["grand_total"].ToString())-purchase_pay;
                        }
                            dataGridView1.Rows[i].Cells["col_contact"].Value = dt2.Rows[0]["mobile"].ToString();
                        dataGridView1.Rows[i].Cells["col_address"].Value = dt2.Rows[0]["adress"].ToString();
                    }

                }
            }
        }
        public static string supplier_name;
        public static decimal grand_total;
        public static int sup_id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col_details"].Index && e.RowIndex >= 0)
            {
                Control ctl = this.Parent;
                supplier_name = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["col_supplier"].Value);
                SupplierPayment sp = new SupplierPayment();
                ctl.Controls.Clear();
                ctl.Controls.Add(sp);

            }
           else if (e.ColumnIndex == dataGridView1.Columns["col_payment"].Index && e.RowIndex >= 0)
            {
                Control ctrl = this.Parent;
                grand_total = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["col_grand_total"].Value);
                supplier_name = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["col_supplier"].Value);
                PurchasePay sp = new PurchasePay(supplier_name,grand_total);
                sp.Show();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["col_view"].Index && e.RowIndex >= 0)
            {
                Control ctrl = this.Parent;
                sup_id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["col_sup_id"].Value);
                supplier_name = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["col_supplier"].Value);
                ViewPayment sp = new ViewPayment();
                ctrl.Controls.Clear();
                ctrl.Controls.Add(sp);
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
           
        }
    }
}
