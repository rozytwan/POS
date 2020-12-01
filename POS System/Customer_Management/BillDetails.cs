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
        DateTime date = AllCreditsLists.dates;
        private void BillDetails_Load(object sender, EventArgs e)
        {
            LoadBillDetail();
        }
        DataTable dt = new DataTable();
        public void LoadBillDetail()
        {

            dt = bllcustomer.GetSalesbyBillNo(Convert.ToInt32(lbl_bill_no.Text), AllCreditsLists.dates);
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
                lbl_fiscal_year.Text= (dt.Rows[0]["fiscal_year"].ToString());
            }
        }
        string fiscal_year;
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
        BLLPrinterSetting blpst = new BLLPrinterSetting();
        string bill_no_print;
        private void btn_print_Click(object sender, EventArgs e)
        {
          //  bill_no_print = dataGridView1.CurrentRow.Cells["col_bill_no"].Value.ToString();
            
            DataTable dt_prt = blpst.getalldata();
            if (dt_prt.Rows[0]["bill_printer"].ToString() == "80")
            {
                bill_printing_for_80();

            }

            else if (dt_prt.Rows[0]["bill_printer"].ToString() == "76")
            {
                bill_printing_for_76();
            }

        }
        BillPrinting80 blp_80 = new BillPrinting80();
        blllCustomerDetailednyo blcd = new blllCustomerDetailednyo();
        BLLOrder blod = new BLLOrder();
        bool save_after_print;
        string printer_name;
        public void bill_printing_for_80()
        {
            blp_80.Headerstatus = true;
            blp_80.bill_no = lbl_bill_no.Text;
            blp_80.table_no = "1";
            blp_80.cashier = lbl_cashier.Text;
            blp_80.print_again = true;
            blp_80.printer_name = "Billing";
            blp_80.fiscal_year = lbl_fiscal_year.Text;
            blp_80.discount = Convert.ToDecimal(lbl_discount.Text).ToString("#.##");
            blp_80.grand_total = Convert.ToDecimal(lbl_grand_total.Text).ToString("#.##");
            blp_80.sub_total = Convert.ToDecimal(lbl_subtotal.Text).ToString("#.##");
            blp_80.billing_date = date;
            dtd = blcd.getDataByitsId(Convert.ToInt32(lbl_customer_id.Text));
            if (dtd.Rows.Count > 0)
            {
                blp_80.customer_address = dtd.Rows[0]["address"].ToString();
                blp_80.customer_name = dtd.Rows[0]["name"].ToString() + " " + dtd.Rows[0]["lastname"].ToString();
                blp_80.customer_PAN_no = dtd.Rows[0]["phone2"].ToString();
                blp_80.customer_phone_no = dtd.Rows[0]["phone"].ToString();
            }
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                blp_80.datagridview_item_name.Add(dataGridView1.Rows[i].Cells["col_item"].Value.ToString());
                blp_80.datagridview_item_price.Add(dataGridView1.Rows[i].Cells["col_cost"].Value.ToString());
                blp_80.datagridview_total.Add(dataGridView1.Rows[i].Cells["col_total"].Value.ToString());
                blp_80.datagridview_quantity.Add(dataGridView1.Rows[i].Cells["col_quantity"].Value.ToString());
              
            }
            blp_80.printtobill();
            save_after_print = blp_80.save_after_print;
        }
        BillPrinting76 blp_76 = new BillPrinting76();
        DataTable dtd = new DataTable();
        public void bill_printing_for_76()
        {
            blp_76.Headerstatus = true;
            blp_76.bill_no = lbl_bill_no.Text;
            blp_76.table_no = "1";
            blp_76.cashier = lbl_cashier.Text;
            blp_76.print_again = true;
            blp_76.printer_name = "Billing";
            blp_76.fiscal_year = lbl_fiscal_year.Text;
            //blp_76.customer_name = lbl_customer_name.Text;
            blp_76.discount = Convert.ToDecimal(lbl_discount.Text).ToString("#.##");
            blp_76.grand_total = Convert.ToDecimal(lbl_grand_total.Text).ToString("#.##");
            blp_76.sub_total = Convert.ToDecimal(lbl_subtotal.Text).ToString("#.##");
            dtd = blcd.getDataByitsId(Convert.ToInt32(lbl_customer_id.Text));
            if (dtd.Rows.Count>0)
            {
                blp_76.customer_address =dtd.Rows[0]["address"].ToString() ;
                blp_76.customer_name = dtd.Rows[0]["name"].ToString()+" "+ dtd.Rows[0]["lastname"].ToString();
                blp_76.customer_PAN_no = dtd.Rows[0]["phone2"].ToString();
                blp_76.customer_phone_no = dtd.Rows[0]["phone"].ToString();
            }
            blp_76.billing_date = date;
           
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    blp_76.datagridview_item_name.Add(dataGridView1.Rows[i].Cells["col_item"].Value.ToString());
                    blp_76.datagridview_item_price.Add(dataGridView1.Rows[i].Cells["col_cost"].Value.ToString());
                    blp_76.datagridview_total.Add(dataGridView1.Rows[i].Cells["col_total"].Value.ToString());
                    blp_76.datagridview_quantity.Add(dataGridView1.Rows[i].Cells["col_quantity"].Value.ToString());
                   // blp_76.datagridview_complementary.Add(dataGridView1.Rows[i].Cells["cal_comp_status"].Value.ToString());
                }
                blp_76.printtobill();
                save_after_print = blp_76.save_after_print;
            }
  
        }
    }


