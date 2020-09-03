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
    public partial class SupplierPayment : UserControl
    {
        public SupplierPayment()
        {
            InitializeComponent();
        }
        BLLPurchase bllp = new BLLPurchase();
       string supplier_name=SupplierPurchase.supplier_name;
        public static string bill_no;
        public static DateTime purchase_date;

        private void SupplierPayment_Load(object sender, EventArgs e)
        {
            DataGridviewLoad();
        }
        public void DataGridviewLoad()
        {
            DataTable dt = bllp.GetSuupplierPurchase(supplier_name);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_purchaseid"].Value = dt.Rows[i]["purchase_id"].ToString();
                    dataGridView1.Rows[i].Cells["col_supplier"].Value = dt.Rows[i]["supplier_name"].ToString();
                    dataGridView1.Rows[i].Cells["col_purhasedate"].Value = dt.Rows[i]["purchase_date"].ToString();
                    dataGridView1.Rows[i].Cells["col_grand_total"].Value = dt.Rows[i]["grand_total"].ToString();
                    dataGridView1.Rows[i].Cells["col_bill_no"].Value = dt.Rows[i]["bill_no"].ToString();
                    dataGridView1.Rows[i].Cells["col_categoryname"].Value = dt.Rows[i]["category_name"].ToString();
                    dataGridView1.Rows[i].Cells["col_productname"].Value = dt.Rows[i]["product_name"].ToString();
                  
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
            if (e.ColumnIndex == dataGridView1.Columns["col_return"].Index && e.RowIndex >= 0)
            {
                Control ctrl = this.Parent;
                supplier_name = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["col_supplier"].Value);
                bill_no = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["col_bill_no"].Value);
                purchase_date = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["col_purhasedate"].Value);
                UserControl_purchase_form upf = new UserControl_purchase_form();
                ctrl.Controls.Clear();
                ctrl.Controls.Add(upf);
            }
            else if (e.ColumnIndex == dataGridView1.Columns["col_payment"].Index && e.RowIndex >= 0)
            {
                //Control ctrl = this.Parent;
                //supplier_name = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["col_supplier"].Value);
                //bill_no = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["col_bill_no"].Value);
                //PurchasePay upf = new PurchasePay();
                //upf.Show();
            }
        }
    }
}
