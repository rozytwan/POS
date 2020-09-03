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
    public partial class CardCreditRecord : UserControl
    {
        public CardCreditRecord()
        {
            InitializeComponent();
        }
        BLL_Card_Credit bllcredit = new BLL_Card_Credit();
        BLLcustomer_credit blcustom = new BLLcustomer_credit();
        private void CardCreditRecord_Load(object sender, EventArgs e)
        {
            LoadCustomerCredit();
        }
        public static int customer_id;
        public void LoadCustomerCredit()
        {
            DataTable dt = bllcredit.Get_Data_ByGrouping_Customer_Id(customer_id);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int abc = dataGridView1.Rows.Add();
                    int customer_id = Convert.ToInt32(dt.Rows[i]["customer_id"].ToString());
                    DataTable dt1 = blcustom.Get_Customer_ById(customer_id);
                    if (dt1.Rows.Count > 0)
                    {
                        dataGridView1.Rows[i].Cells["col_customer_id"].Value = dt1.Rows[0]["id"].ToString();

                        dataGridView1.Rows[i].Cells["col_customer_name"].Value = dt1.Rows[0]["name"].ToString();
                        dataGridView1.Rows[i].Cells["col_customer_phone"].Value = dt1.Rows[0]["phone"].ToString();
                        dataGridView1.Rows[i].Cells["col_customer_address"].Value = dt1.Rows[0]["address"].ToString();
                    }
                    dataGridView1.Rows[i].Cells["col_credit_amount"].Value = dt.Rows[i]["sum_credit_amount"].ToString();
                }


            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col_view"].Index)
            {

                customer_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_customer_id"].Value);

                Control ctls = this.Parent;
                AllCardCredit cl = new AllCardCredit();
                ctls.Controls.Clear();
                ctls.Controls.Add(cl);
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {

        }
    }
}
