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
    public partial class CreditDetail : Form
    {
        public CreditDetail()
        {
            InitializeComponent();
        }
        BLLcustomer_credit blcc = new BLLcustomer_credit();
        BLLRestSell bllsale = new BLLRestSell();
        BLL_Billing_Tax blbt = new BLL_Billing_Tax();
        blllCustomerDetailednyo blcd = new blllCustomerDetailednyo();
        // public int customer_id;
       
     
       // int bill_no;
        public int customer_no;
        string creditload = second_user_interface.creditload;
        private void CreditDetail_Load(object sender, EventArgs e)
        {
            if (lbl_customer_id.Text == "")
            {
                lbl_customer_id.Text = "0";
            }
           int customer_id = Convert.ToInt32(lbl_customer_id.Text);
                int customer_no = CheckCard.customer_no;

            if (customer_id != 0)

            {
                lbl_credit.Show();
                panel_sales.Hide();
                panel_credit.Show();
                panel_date.Hide();
                DataTable dt1 = blcc.Get_Customer_ById(customer_id);
                if (dt1.Rows.Count > 0)
                {
                    string name = dt1.Rows[0]["name"].ToString() + " " + dt1.Rows[0]["lastname"].ToString();
                    if (creditload == "Hotel Credit")
                    {
                        DataTable dt = bllsale.GetHotelCredit(name);
                        if (dt.Rows.Count > 0)
                        {
                            dataGridView1.Rows.Clear();
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dataGridView1.Rows.Add();
                                dataGridView1.Rows[i].Cells["calbill_no"].Value = dt.Rows[i]["bill_no"].ToString();
                                // dataGridView1.Rows[i].Cells["calbill_no"].Value = bill_no;
                                dataGridView1.Rows[i].Cells["calitem"].Value = dt.Rows[i]["item_name"].ToString();
                                dataGridView1.Rows[i].Cells["calquantity"].Value = dt.Rows[i]["quantity"].ToString();
                                dataGridView1.Rows[i].Cells["cal_cost"].Value = dt.Rows[i]["cost"].ToString();
                                dataGridView1.Rows[i].Cells["caltotal"].Value = dt.Rows[i]["total"].ToString();
                                dataGridView1.Rows[i].Cells["caldate"].Value = dt.Rows[i]["date2"].ToString();

                                dataGridView1.Rows[i].Cells["cal_tax"].Value = dt.Rows[0]["tax_amount"].ToString();
                                dataGridView1.Rows[i].Cells["cal_service_charge"].Value = dt.Rows[0]["service_charge"].ToString();


                                dataGridView1.Rows[i].Cells["cal_grand_total"].Value = dt.Rows[i]["grand_total"].ToString();
                                dataGridView1.Rows[i].Cells["calcashier_name"].Value = dt.Rows[i]["cashier_name"].ToString();

                            }
                        }

                    }
                    else
                    {
                        DataTable dt = bllsale.GetCredit(name);
                        if (dt.Rows.Count > 0)
                        {
                            dataGridView1.Rows.Clear();
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                dataGridView1.Rows.Add();
                                dataGridView1.Rows[i].Cells["calbill_no"].Value = dt.Rows[i]["bill_no"].ToString();
                                // dataGridView1.Rows[i].Cells["calbill_no"].Value = bill_no;
                                dataGridView1.Rows[i].Cells["calitem"].Value = dt.Rows[i]["item_name"].ToString();
                                dataGridView1.Rows[i].Cells["calquantity"].Value = dt.Rows[i]["quantity"].ToString();
                                dataGridView1.Rows[i].Cells["cal_cost"].Value = dt.Rows[i]["cost"].ToString();
                                dataGridView1.Rows[i].Cells["caltotal"].Value = dt.Rows[i]["total"].ToString();
                                dataGridView1.Rows[i].Cells["caldate"].Value = dt.Rows[i]["date2"].ToString();

                                dataGridView1.Rows[i].Cells["cal_tax"].Value = dt.Rows[0]["tax_amount"].ToString();
                                dataGridView1.Rows[i].Cells["cal_service_charge"].Value = dt.Rows[0]["service_charge"].ToString();


                                dataGridView1.Rows[i].Cells["cal_grand_total"].Value = dt.Rows[i]["grand_total"].ToString();
                                dataGridView1.Rows[i].Cells["calcashier_name"].Value = dt.Rows[i]["cashier_name"].ToString();

                            }
                        }
                    }
                }
            }
            else
            {
                SearchSales();
                lbl_credit.Hide();
                panel_credit.Hide();
                panel_sales.Show();
                panel_date.Show();
            }

            
        }
        List<string> transaction_date = new List<string>();
        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void SearchSales()
        {
            string dateOne = Convert.ToDateTime(lbl_from.Text).ToShortDateString();
            string datetwo = Convert.ToDateTime(lbl_to.Text).ToShortDateString();
        
           int customer_no = CheckCard.customer_no;
            DataTable dt = blcd.SearchCustomerSales(customer_no, Convert.ToDateTime(dateOne), Convert.ToDateTime(datetwo));
            if (dt.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells["calbill_no"].Value = dt.Rows[i]["bill_no"].ToString();
                    // dataGridView1.Rows[i].Cells["calbill_no"].Value = bill_no;
                    dataGridView1.Rows[i].Cells["calitem"].Value = dt.Rows[i]["item_name"].ToString();
                    dataGridView1.Rows[i].Cells["calquantity"].Value = dt.Rows[i]["quantity"].ToString();
                    dataGridView1.Rows[i].Cells["cal_cost"].Value = dt.Rows[i]["cost"].ToString();
                    dataGridView1.Rows[i].Cells["caltotal"].Value = dt.Rows[i]["total"].ToString();
                    dataGridView1.Rows[i].Cells["caldate"].Value = dt.Rows[i]["date2"].ToString();
                  
                        dataGridView1.Rows[i].Cells["cal_tax"].Value = dt.Rows[0]["tax_amount"].ToString();
                        dataGridView1.Rows[i].Cells["cal_service_charge"].Value = dt.Rows[0]["service_charge"].ToString();
                   
                    dataGridView1.Rows[i].Cells["cal_grand_total"].Value = dt.Rows[i]["grand_total"].ToString();
                    dataGridView1.Rows[i].Cells["calcashier_name"].Value = dt.Rows[i]["cashier_name"].ToString();

                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
        }
 
