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


namespace POS_System
{
    public partial class CreditPaidForm : UserControl
    {
        public CreditPaidForm()
        {
            InitializeComponent();
        }
        BLLcredit_clear blclear = new BLLcredit_clear();
      
        blllCustomerDetailednyo BCD = new blllCustomerDetailednyo();
        BLLcustomer_credit blcc = new BLLcustomer_credit();
       
     
        int customer_id = CustomerDetail.customer_id;
   string creditload=second_user_interface.creditload;
        private void CreditPaidForm_Load(object sender, EventArgs e)
        {
            if (creditload == "Hotel Credit")
            {
                DataTable dthotel = blcc.Get_HotelCreditPaid_Customerid(customer_id);
                {
                    if (dthotel.Rows.Count > 0)
                    {

                        dataGridView2.Rows.Clear();
                        for (int i = 0; i < dthotel.Rows.Count; i++)
                        {
                            dataGridView2.Rows.Add();
                            DataTable dt1 = blcc.Get_Customer_ById(customer_id);
                            {
                                int customer_id = Convert.ToInt32(dthotel.Rows[i]["customer_id"].ToString());
                                dataGridView2.Rows[i].Cells["col_customername"].Value = dt1.Rows[0]["name"].ToString() + dt1.Rows[0]["lastname"].ToString();

                            }
                            dataGridView2.Rows[i].Cells["col_credit_pay_id"].Value = dthotel.Rows[i]["creditpay_id"].ToString();

                            dataGridView2.Rows[i].Cells["col_creditamount"].Value = dthotel.Rows[i]["credit_amount"].ToString();
                            dataGridView2.Rows[i].Cells["col_creditpaid"].Value = dthotel.Rows[i]["credit_paid"].ToString();

                            dataGridView2.Rows[i].Cells["col_creditleft"].Value = dthotel.Rows[i]["credit_left"].ToString();

                            dataGridView2.Rows[i].Cells["col_checkedby"].Value = dthotel.Rows[i]["credit_checked_by"].ToString();

                            dataGridView2.Rows[i].Cells["col_checkeddate"].Value = dthotel.Rows[i]["checked_date"].ToString();
                        }

                    }
                    else
                    {
                        MessageBox.Show("No paid amount till now", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
           
            else
            {
                DataTable dt = blcc.Get_CreditPaid_Customerid(customer_id);
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
                                dataGridView2.Rows[i].Cells["col_customername"].Value = dt1.Rows[0]["name"].ToString() + dt1.Rows[0]["lastname"].ToString();

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
        }

        private void close_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            AllCreditsLists cd = new AllCreditsLists();
            ctls.Controls.Clear();
            ctls.Controls.Add(cd);

        }
        public static int creditpay_id;
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView2.Columns["col_view"].Index)
            {
               int creditpay_id = Convert.ToInt32(dataGridView2.CurrentRow.Cells["col_credit_pay_id"].Value.ToString());
                //  txt_credit_id.Text = dataGridView2.CurrentRow.Cells["col_credit_pay_id"].Value.ToString();

                Creditpayform objfrm = new Creditpayform();
                objfrm.creditpay_id = creditpay_id;
                objfrm.Show();


            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Control ctls = this.Parent;
            AllCreditsLists vieret = new AllCreditsLists();
            ctls.Controls.Clear();
            ctls.Controls.Add(vieret);
        }
        //    DataTable dt = blclear.Get_Credit_Clear();
        //    if(dt.Rows.Count>0)
        //    {
        //        dataGridView1.Rows.Clear();
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //        { dataGridView1.Rows.Add();

        //            int  customer_id = Convert.ToInt32(dt.Rows[i]["customer_id"].ToString());
        //            DataTable dt1 = blcc.Get_Customer_ById(customer_id);
        //            {
        //                dataGridView1.Rows[i].Cells["col_customer_id"].Value = dt1.Rows[0]["name"].ToString();
        //            }
        //            dataGridView1.Rows[i].Cells["col_credit_amount"].Value = dt.Rows[i]["credit_amount"].ToString();
        //            dataGridView1.Rows[i].Cells["col_credit_paid"].Value = dt.Rows[i]["credit_paid"].ToString();
        //            dataGridView1.Rows[i].Cells["col_debit_amount"].Value = dt.Rows[i]["debit_amount"].ToString();
        //            dataGridView1.Rows[i].Cells["col_checked_by"].Value = dt.Rows[i]["checked_by"].ToString();
        //            dataGridView1.Rows[i].Cells["col_date"].Value = dt.Rows[i]["checked_date"].ToString();

        //            dataGridView1.Rows[i].Cells["col_remark"].Value = dt.Rows[i]["remark"].ToString();

        //        }
        //    }



    }
}
