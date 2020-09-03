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
    public partial class BillDetails : Form
    {
        public BillDetails()
        {
            InitializeComponent();
        }
        blllCustomerDetailednyo bllcustomer = new blllCustomerDetailednyo();
        BLL_Billing_Tax bltx = new BLL_Billing_Tax();
        BLL_Fiscal bllf = new BLL_Fiscal();
        DateTime date=AllCreditsLists.dates;
        private void BillDetails_Load(object sender, EventArgs e)
        {
            LoadBillDetail();
        }
        DataTable dt = new DataTable();
        public void LoadBillDetail()
        {
     
            dt = bllcustomer.GetSalesbyBillNo(Convert.ToInt32(lbl_bill_no.Text),AllCreditsLists.dates);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["col_item"].Value = dt.Rows[i]["item_name"].ToString();
                    dataGridView1.Rows[i].Cells["col_quantity"].Value = dt.Rows[i]["quantity"].ToString();
                    dataGridView1.Rows[i].Cells["col_cost"].Value = dt.Rows[i]["cost"].ToString();
                    dataGridView1.Rows[i].Cells["col_total"].Value = dt.Rows[i]["total"].ToString();
                }

                lbl_subtotal.Text = (dt.Rows[0]["sub_total"].ToString());
                lbl_discount.Text = (dt.Rows[0]["discount"].ToString());
                lbl_bill_date.Text = (dt.Rows[0]["date_of_sale"].ToString());
                lbl_cashier.Text = (dt.Rows[0]["cashier_name"].ToString());
                btn_payment.Text = (dt.Rows[0]["payment_mode"].ToString());
                lbl_tax.Text = (dt.Rows[0]["tax_amount"].ToString());
                lbl_service_charge.Text = (dt.Rows[0]["service_charge"].ToString());
                lbl_grand_total.Text = (dt.Rows[0]["grand_total"].ToString());
            }
        }
        public void grandtotalCalculation()
        {
            double sub_total = 0;
    
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
               
                 sub_total += Convert.ToDouble(dt.Rows[i]["total"].ToString());
                }
            }
            lbl_subtotal.Text = sub_total.ToString("#.##");
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

