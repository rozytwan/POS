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
    public partial class HotelVoidSales : UserControl
    {
        public HotelVoidSales()
        {
            InitializeComponent();
        }
        BLLRestSell order = new BLLRestSell();
        DateTime today = Convert.ToDateTime(DateTime.Now.Date.ToShortDateString());
        public void LoadVoidBill()
        {
            DataTable dt = order.GetVoidBill();
            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.NewRow();
                dr["void_bill_no"] = ("0000");
                dt.Rows.InsertAt(dr, 0);
                cmb_find.DataSource = dt;
                cmb_find.DisplayMember = "new_bill_no";
                cmb_find.ValueMember = "void_id";
            }
        }
        private void HotelVoidSales_Load(object sender, EventArgs e)
        {
            cmb_search.SelectedIndex = 0;

            searchPanel.Show();
            Backpanel.Hide();
            dtp_from.Text = Convert.ToString(today);
            dtp_to.Text = Convert.ToString(today);
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Backpanel.Hide();
            searchPanel.Show();
        }
        decimal tax_amount = 0;
        decimal service_charge_amount = 0;
        decimal subtotal = 0;
        decimal discount = 0;
        decimal tax_sale_amount_with_discount = 0;
        decimal net_sales_with_service = 0;
        public void grandtotal()
        {
            double grandtotal = 0;
            double grand_total = 0;
            double sales_amount = 0;
            double service_charge = 0;
            double tax = 0;

            for (int x = 0; x < dataGridView1.Rows.Count; x++)
            {

                grandtotal += Convert.ToDouble(dataGridView1.Rows[x].Cells["cal_grand_total"].Value.ToString());
                sales_amount += Convert.ToDouble(dataGridView1.Rows[x].Cells["cal_total_sales_amount"].Value.ToString());
                service_charge += Convert.ToDouble(dataGridView1.Rows[x].Cells["cal_service_charge"].Value.ToString());
            }

            lbl_grandtotal.Text = grandtotal.ToString();
            lbl_service_charge.Text = service_charge.ToString();
            lbl_sales_amount.Text = sales_amount.ToString();
        }
        private void btn_show_Click(object sender, EventArgs e)
        {

            string dateOne = Convert.ToDateTime(dtp_from.Text).ToShortDateString();
            string datetwo = Convert.ToDateTime(dtp_to.Text).ToShortDateString();
            if (cmb_search.Text == "Void Bill No")
            {
                DataTable dt = order.SearchBy(cmb_find.Text);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int inc = 0; inc < dt.Rows.Count; inc++)
                    {
                        int ac = dataGridView1.Rows.Add();

                        DateTime date_of_sales = Convert.ToDateTime(dt.Rows[inc]["Date2"].ToString());
                        dataGridView1.Rows[inc].Cells["cal_date2"].Value = date_of_sales;
                        dataGridView1.Rows[inc].Cells["caldate"].Value = dt.Rows[inc]["date_of_sale"].ToString();
                        string bill_nos = dt.Rows[inc]["bill_no"].ToString();
                        dataGridView1.Rows[inc].Cells["calbill_no"].Value = bill_nos;
                        dataGridView1.Rows[inc].Cells["calcashamt"].Value = dt.Rows[inc]["cash_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["calpaymode"].Value = dt.Rows[inc]["payment_mode"].ToString();

                        subtotal = Convert.ToDecimal(dt.Rows[inc]["sub_total"].ToString());

                        dataGridView1.Rows[inc].Cells["cal_sub_total"].Value = subtotal.ToString();
                        discount = Convert.ToDecimal(dt.Rows[inc]["discount"].ToString());
                        dataGridView1.Rows[inc].Cells["cal_discount"].Value = discount.ToString();
                        tax_sale_amount_with_discount = subtotal - discount;
                        dataGridView1.Rows[inc].Cells["cal_total_sales_amount"].Value = tax_sale_amount_with_discount.ToString();

                        tax_amount = Convert.ToDecimal(dt.Rows[0]["tax_amount"].ToString());
                        service_charge_amount = Convert.ToDecimal(dt.Rows[0]["service_charge"].ToString());
                        dataGridView1.Rows[inc].Cells["cal_tax"].Value = tax_amount.ToString();
                        dataGridView1.Rows[inc].Cells["cal_service_charge"].Value = service_charge_amount.ToString();

                        string fiscal_year = dt.Rows[inc]["fiscal_year"].ToString();
                        DataTable dtvoid = order.GetBillVoid(bill_nos, fiscal_year);
                        if (dtvoid.Rows.Count > 0)
                        {
                            dataGridView1.Rows[inc].Cells["col_voidbill"].Value = dtvoid.Rows[0]["void_bill_no"].ToString();
                            dataGridView1.Rows[inc].Cells["col_voiduser"].Value = dtvoid.Rows[0]["void_user"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_date2"].Value = dtvoid.Rows[0]["void_date"].ToString();
                        }

                        net_sales_with_service = tax_sale_amount_with_discount + service_charge_amount;
                        dataGridView1.Rows[inc].Cells["cal_net_sales"].Value = net_sales_with_service;
                        dataGridView1.Rows[inc].Cells["cal_grand_total"].Value = dt.Rows[inc]["grand_total"].ToString();
                        // dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dt.Rows[inc]["sales_type"].ToString();
                        // dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dt.Rows[inc]["table_no"].ToString();

                        dataGridView1.Rows[inc].Cells["cal_date2"].Value = dt.Rows[inc]["date2"].ToString();

                    }
                    //dataGridView1.ClearSelection();
                    Backpanel.Show();
                    searchPanel.Hide();
                }
            }
            else if (cmb_search.Text == "ALL")
            {
                DataTable dt1 = order.GetAllVoids(Convert.ToDateTime(dateOne), Convert.ToDateTime(datetwo));
                if (dt1.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int inc = 0; inc < dt1.Rows.Count; inc++)
                    {
                        int ac = dataGridView1.Rows.Add();

                        DateTime date_of_sales = Convert.ToDateTime(dt1.Rows[inc]["Date2"].ToString());
                        dataGridView1.Rows[inc].Cells["cal_date2"].Value = date_of_sales;
                        dataGridView1.Rows[inc].Cells["caldate"].Value = dt1.Rows[inc]["date_of_sale"].ToString();
                        string bill_nos = dt1.Rows[inc]["bill_no"].ToString();
                        dataGridView1.Rows[inc].Cells["calbill_no"].Value = bill_nos;
                        dataGridView1.Rows[inc].Cells["calcashamt"].Value = dt1.Rows[inc]["cash_amount"].ToString();
                        dataGridView1.Rows[inc].Cells["calpaymode"].Value = dt1.Rows[inc]["payment_mode"].ToString();

                        subtotal = Convert.ToDecimal(dt1.Rows[inc]["sub_total"].ToString());

                        dataGridView1.Rows[inc].Cells["cal_sub_total"].Value = subtotal.ToString();
                        discount = Convert.ToDecimal(dt1.Rows[inc]["discount"].ToString());
                        dataGridView1.Rows[inc].Cells["cal_discount"].Value = discount.ToString();
                        tax_sale_amount_with_discount = subtotal - discount;
                        dataGridView1.Rows[inc].Cells["cal_total_sales_amount"].Value = tax_sale_amount_with_discount.ToString();

                        tax_amount = Convert.ToDecimal(dt1.Rows[0]["tax_amount"].ToString());
                        service_charge_amount = Convert.ToDecimal(dt1.Rows[0]["service_charge"].ToString());
                        dataGridView1.Rows[inc].Cells["cal_tax"].Value = tax_amount.ToString();
                        dataGridView1.Rows[inc].Cells["cal_service_charge"].Value = service_charge_amount.ToString();

                        string fiscal_year = dt1.Rows[inc]["fiscal_year"].ToString();
                        DataTable dtvoid = order.GetBillVoid(bill_nos, fiscal_year);
                        if (dtvoid.Rows.Count > 0)
                        {
                            dataGridView1.Rows[inc].Cells["col_voidbill"].Value = dtvoid.Rows[0]["void_bill_no"].ToString();
                            dataGridView1.Rows[inc].Cells["col_voiduser"].Value = dtvoid.Rows[0]["void_user"].ToString();
                            dataGridView1.Rows[inc].Cells["cal_date2"].Value = dtvoid.Rows[0]["void_date"].ToString();
                        }
                        net_sales_with_service = tax_sale_amount_with_discount + service_charge_amount;
                        dataGridView1.Rows[inc].Cells["cal_net_sales"].Value = net_sales_with_service;
                        dataGridView1.Rows[inc].Cells["cal_grand_total"].Value = dt1.Rows[inc]["grand_total"].ToString();
                        // dataGridView1.Rows[inc].Cells["cal_sales_type"].Value = dt.Rows[inc]["sales_type"].ToString();
                        // dataGridView1.Rows[inc].Cells["cal_table_no"].Value = dt.Rows[inc]["table_no"].ToString();

                        dataGridView1.Rows[inc].Cells["cal_date2"].Value = dt1.Rows[inc]["date2"].ToString();

                    }

                    // dataGridView1.ClearSelection();
                    Backpanel.Show();
                    searchPanel.Hide();
                }
            }
            grandtotal();
        }

        private void cmb_search_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_search.Text == "Void Bill No")
            {
                LoadVoidBill();
            }
            else if (cmb_search.Text == "ALL")
            {
                cmb_find.Text = "ALL";

            }
        }
    }
}
