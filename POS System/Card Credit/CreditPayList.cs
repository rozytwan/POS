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
    public partial class CreditPayList : UserControl
    {
        public CreditPayList()
        {
            InitializeComponent();
        }
        BLL_Card_Credit bllcredit = new BLL_Card_Credit();
        BLLcustomer_credit blcc = new BLLcustomer_credit();
        int customer_id = CardCreditRecord.customer_id;
        private void CreditPayList_Load(object sender, EventArgs e)
        {

            DataTable dt = bllcredit.GetPaid(customer_id);
            {
                if (dt.Rows.Count > 0)
                {

                    dataGridView2.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dataGridView2.Rows.Add();
                        DataTable dt1 = blcc.Get_Customer_ById(customer_id);
                        {
                            int customer_id = Convert.ToInt32(dt.Rows[i]["customer_id"].ToString());
                            dataGridView2.Rows[i].Cells["col_customername"].Value = dt1.Rows[0]["name"].ToString();

                        }
                        dataGridView2.Rows[i].Cells["col_credit_pay_id"].Value = dt.Rows[i]["creditpay_id"].ToString();

                        dataGridView2.Rows[i].Cells["col_creditamount"].Value = dt.Rows[i]["credit_amount"].ToString();
                        dataGridView2.Rows[i].Cells["col_creditpaid"].Value = dt.Rows[i]["credit_paid"].ToString();

                        dataGridView2.Rows[i].Cells["col_creditleft"].Value = dt.Rows[i]["credit_left"].ToString();

                        dataGridView2.Rows[i].Cells["col_checkedby"].Value = dt.Rows[i]["credit_checked_by"].ToString();

                        dataGridView2.Rows[i].Cells["col_checkeddate"].Value = dt.Rows[i]["checked_date"].ToString();
                    }

                }
                else
                {
                    MessageBox.Show("No paid amount till now", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            AllCardCredit cl = new AllCardCredit();
            ctls.Controls.Clear();
            ctls.Controls.Add(cl);
        }
    }
}
