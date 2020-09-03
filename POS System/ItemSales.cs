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
    public partial class ItemSales : Form
    {
        public ItemSales()
        {
            InitializeComponent();
        }

        private void ItemSales_Load(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(DateTime.Now.ToString());
            dtp_from.Text = Convert.ToString(date);
            dtp_to.Text = Convert.ToString(date);
            searchPanel.Hide();
        }
        public DateTime today;
        blllCustomerDetailednyo customer = new blllCustomerDetailednyo();
        BillPrinting blp = new BillPrinting();
        BillPrinting80 blp_80 = new BillPrinting80();
        BillPrintingHotel bph = new BillPrintingHotel();
        BLL_Fiscal blfs = new BLL_Fiscal();
        BLLOrder blod = new BLLOrder();
        BLL_Billing_Tax blbt = new BLL_Billing_Tax();
        BLLRestSell blres = new BLLRestSell();
        BLLPrinterSetting blpst = new BLLPrinterSetting();
        BLLBill_printing blp_re = new BLLBill_printing();
        public void GetItemSales()
        {

        }
        string bill_no_print;
        string bill_no;
        bool save_after_print;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if ((e.ColumnIndex == dataGridView1.Columns["cal_print"].Index && e.RowIndex >= 0))
            {
                if (dataGridView1.CurrentRow.Cells["cal_sales_type"].Value.ToString() == "HR")
                {
                    bill_printing_for_hotel();
                }
                else
                {
                    bill_no_print = dataGridView1.CurrentRow.Cells["calbill_no"].Value.ToString();
                    int insert_abc = blp_re.insert_bill_reprint(bill_no_print);
                    int mv = blfs.update__materialized(bill_no_print);
                    DataTable dt_prt = blpst.getalldata();
                    if (dt_prt.Rows[0]["bill_printer"].ToString() == "80")
                    {
                        bill_printing_for_80();
                    }
                    else
                    {
                        bill_printing_for_58();
                    }
                }
            }
        }
        public void bill_printing_for_hotel()
        {
            string bill_no = dataGridView1.CurrentRow.Cells["calbill_no"].Value.ToString();
            bph.bill_no = bill_no;
            bph.cashier = dataGridView1.CurrentRow.Cells["calcashier_name"].Value.ToString();
            bph.cash_amount = dataGridView1.CurrentRow.Cells["calcashamt"].Value.ToString();
            bph.discount = dataGridView1.CurrentRow.Cells["cal_discount"].Value.ToString();
            bph.grand_total = dataGridView1.CurrentRow.Cells["cal_grand_total"].Value.ToString();
            bph.sub_total = dataGridView1.CurrentRow.Cells["cal_sub_total"].Value.ToString();
            bph.table_no = dataGridView1.CurrentRow.Cells["cal_table_no"].Value.ToString();
            bph.print_again = true;
            bph.duplicate_bill_print = true;
            bph.mobile_no = dataGridView1.CurrentRow.Cells["cal_customer_pan"].Value.ToString();
            bph.customer_name = dataGridView1.CurrentRow.Cells["cal_customer_name"].Value.ToString();
            DateTime date_of_billing = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["cal_date2"].Value);
            DataTable dt_bil = blbt.get_all_tax_by_bill_no(bill_no, date_of_billing);
            if (dt_bil.Rows.Count > 0)
            {
                bph.tax_amount = dt_bil.Rows[0]["tax_amount"].ToString();
                bph.service_charge = dt_bil.Rows[0]["service_charge"].ToString();
            }
            DataTable dt = blod.searchbybill2(bill_no);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bph.datagridview_item_name.Add(dt.Rows[i]["item_name"].ToString());
                bph.datagridview_item_price.Add(dt.Rows[i]["cost"].ToString());
                bph.datagridview_total.Add(dt.Rows[i]["total"].ToString());
                bph.datagridview_quantity.Add(dt.Rows[i]["quantity"].ToString());
            }
            bph.print();
            save_after_print = blp_80.save_after_print;
        }
        public void bill_printing_for_58()
        {

            blp.bill_no = bill_no_print;
            blp.cashier = dataGridView1.CurrentRow.Cells["calcashier_name"].Value.ToString();
            blp.cash_amount = dataGridView1.CurrentRow.Cells["calcashamt"].Value.ToString();
            blp.discount = dataGridView1.CurrentRow.Cells["cal_discount"].Value.ToString();
            blp.grand_total = dataGridView1.CurrentRow.Cells["cal_grand_total"].Value.ToString();
            blp.sub_total = dataGridView1.CurrentRow.Cells["cal_sub_total"].Value.ToString();
            blp.table_no = dataGridView1.CurrentRow.Cells["cal_table_no"].Value.ToString();
            DateTime date_of_billing = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["caldate"].Value);
            DataTable dt_bil = blbt.get_all_tax_by_bill_no(bill_no, date_of_billing);
            blp.print_again = true;

            if (dt_bil.Rows.Count > 0)
            {
                blp.tax_amount = dt_bil.Rows[0]["tax_amount"].ToString();
                blp.service_charge = dt_bil.Rows[0]["service_charge"].ToString();
            }
            DataTable dt = blod.searchbybill2(bill_no);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                blp.datagridview_item_name.Add(dt.Rows[i]["item_name"].ToString());
                blp.datagridview_item_price.Add(dt.Rows[i]["cost"].ToString());
                blp.datagridview_total.Add(dt.Rows[i]["total"].ToString());
                blp.datagridview_quantity.Add(dt.Rows[i]["quantity"].ToString());
            }
            blp.printtobill();
            save_after_print = blp.save_after_print;

        }
        public void bill_printing_for_80()
        {
            string bill_no = dataGridView1.CurrentRow.Cells["calbill_no"].Value.ToString();
            blp_80.bill_no = bill_no;
            blp_80.cashier = dataGridView1.CurrentRow.Cells["calcashier_name"].Value.ToString();
            blp_80.cash_amount = dataGridView1.CurrentRow.Cells["calcashamt"].Value.ToString();
            decimal discount = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_discount"].Value.ToString());
            blp_80.discount = discount.ToString();
            blp_80.grand_total = dataGridView1.CurrentRow.Cells["cal_grand_total"].Value.ToString();
            decimal subtotal = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_sub_total"].Value.ToString());
            blp_80.sub_total = subtotal.ToString();
            blp_80.table_no = dataGridView1.CurrentRow.Cells["cal_table_no"].Value.ToString();
            blp_80.print_again = true;
            blp_80.duplicate_bill_print = true;
            blp_80.discount_sub_total = (subtotal - discount).ToString();
            blp_80.tax_amount = dataGridView1.CurrentRow.Cells["cal_tax"].Value.ToString();
            decimal service_charge = Convert.ToDecimal(dataGridView1.CurrentRow.Cells["cal_service_charge"].Value.ToString());
            blp_80.service_charge = service_charge.ToString();
            blp_80.taxable_amount = (subtotal + service_charge - discount).ToString();
            blp_80.customer_PAN_no = dataGridView1.CurrentRow.Cells["cal_customer_pan"].Value.ToString();
            blp_80.customer_name = dataGridView1.CurrentRow.Cells["cal_customer_name"].Value.ToString();
            DateTime date_billing = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["caldate"].Value.ToString());
            blp_80.billing_date = date_billing;



            DataTable dt = blod.searchbybill_and_date(bill_no, date_billing);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    blp_80.datagridview_item_name.Add(dt.Rows[i]["item_name"].ToString());
                    blp_80.datagridview_item_price.Add(dt.Rows[i]["cost"].ToString());
                    blp_80.datagridview_total.Add(dt.Rows[i]["total"].ToString());
                    blp_80.datagridview_quantity.Add(dt.Rows[i]["quantity"].ToString());
                }
            }
            blp_80.printtobill();
            save_after_print = blp_80.save_after_print;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            searchPanel.Show();
        }

        private void cbo_searchTYpe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_show_Click(object sender, EventArgs e)
        {

        }

        private void btn_show_Click_1(object sender, EventArgs e)
        {

            searchPanel.Hide();
            backPanel.Show();
            DateTime datefrom = Convert.ToDateTime(dtp_from.Text);
            DateTime dateto = Convert.ToDateTime(dtp_to.Text);
            DateTime date = Convert.ToDateTime(DateTime.Now.ToString());
            DataTable dt = customer.GetItemsByDate(lbl_card_no.Text, datefrom, dateto);
            if (dt.Rows.Count > 0)
            {
                for (int inc = 0; inc < dt.Rows.Count; inc++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[inc].Cells["calquantity"].Value = dt.Rows[inc]["quantity"].ToString();
                    dataGridView1.Rows[inc].Cells["caltotal"].Value = dt.Rows[inc]["total"].ToString();
                    dataGridView1.Rows[inc].Cells["cal_cost"].Value = dt.Rows[inc]["cost"].ToString();
                    dataGridView1.Rows[inc].Cells["caldate"].Value = dt.Rows[inc]["date_of_sale"].ToString();
                    dataGridView1.Rows[inc].Cells["calcardamount"].Value = dt.Rows[inc]["card_amount"].ToString();
                    dataGridView1.Rows[inc].Cells["calcashamt"].Value = dt.Rows[inc]["cash_amount"].ToString();
                    dataGridView1.Rows[inc].Cells["calpaymode"].Value = dt.Rows[inc]["payment_mode"].ToString();
                    dataGridView1.Rows[inc].Cells["calcashier_name"].Value = dt.Rows[inc]["cashier_name"].ToString();
                    string bill_no = dt.Rows[inc]["bill_no"].ToString();
                    dataGridView1.Rows[inc].Cells["calbill_no"].Value = bill_no;
                    DateTime date_of_billing = Convert.ToDateTime(dt.Rows[inc]["date2"].ToString());
                    dataGridView1.Rows[inc].Cells["caldate"].Value = Convert.ToDateTime(dt.Rows[inc]["date_of_sale"].ToString());
                    DataTable dt_bill = blbt.get_all_tax_by_bill_no(bill_no, date_of_billing);
                    if (dt_bill.Rows.Count > 0)
                    {
                        dataGridView1.Rows[inc].Cells["cal_tax"].Value = dt_bill.Rows[0]["tax_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["cal_service_charge"].Value = dt_bill.Rows[0]["service_charge"].ToString();
                    }
                    else
                    {
                        dataGridView1.Rows[inc].Cells["cal_tax"].Value = "0.00";
                        dataGridView1.Rows[inc].Cells["cal_service_charge"].Value = "0.00";
                    }
                    dataGridView1.Rows[inc].Cells["cal_grand_total"].Value = dt.Rows[inc]["grand_total"].ToString();
                    dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dt.Rows[inc]["sales_type"].ToString();
                    dataGridView1.Rows[inc].Cells["cal_sales_id"].Value = dt.Rows[inc]["rest_sale_id"].ToString();
                    dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dt.Rows[inc]["table_no"].ToString();
                    dataGridView1.Rows[inc].Cells["cal_category_name"].Value = dt.Rows[inc]["category_name"].ToString();
                    dataGridView1.Rows[inc].Cells["cal_discount"].Value = dt.Rows[inc]["discount"].ToString();
                    dataGridView1.Rows[inc].Cells["cal_sub_total"].Value = dt.Rows[inc]["sub_total"].ToString();
                    dataGridView1.Rows[inc].Cells["cal_date2"].Value = dt.Rows[inc]["date2"].ToString();
                    dataGridView1.Rows[inc].Cells["cal_customer_pan"].Value = dt.Rows[inc]["customer_no"].ToString();
                    dataGridView1.Rows[inc].Cells["cal_customer_name"].Value = dt.Rows[inc]["customer_name"].ToString();

                }
            }
            else
            {
                MessageBox.Show("Data is not Available in this date", "Data Empty !!");
            }
            }
        }
    }

