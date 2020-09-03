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
    public partial class SalesDataTaxCalculate : Form
    {
        public SalesDataTaxCalculate()
        {
            InitializeComponent();
        }
        BLLBillingTaxCalculate bbtc = new BLLBillingTaxCalculate();
        private void btn_run_Click(object sender, EventArgs e)
        {
            DataTable dt = bbtc.getAllNullData();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    decimal subtotal = Convert.ToDecimal(dt.Rows[i]["sub_total"]);
                    decimal discount = Convert.ToDecimal(dt.Rows[i]["discount"]);
                    string sales_type = dt.Rows[i]["sales_type"].ToString();
                    string bill_no = dt.Rows[i]["bill_no"].ToString();
                    DateTime date2 = Convert.ToDateTime(dt.Rows[i]["date2"].ToString());
                    if (subtotal >0)
                    {
                        decimal service_charge = 0;
                        decimal tax_amount = 0;                       
                        decimal subtotal_with_services;
                        decimal subtotalwithDiscount = subtotal - discount;                       
                        TaxCalculation tax = new TaxCalculation();
                        if (sales_type!="TA")
                        {
                            service_charge = tax.service_calculation(subtotalwithDiscount);
                        }
                        subtotal_with_services = (subtotalwithDiscount + service_charge);
                        tax_amount = tax.tax_calculation(Convert.ToDecimal(subtotal_with_services));
                        int upadateTax = bbtc.updatetaxandservice(bill_no,date2,tax_amount,service_charge,subtotal_with_services);                       
                    }
                }
            }
        }

        private void btn_run_all_Click(object sender, EventArgs e)
        {
            DataTable dt = bbtc.getAllData();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    decimal subtotal = Convert.ToDecimal(dt.Rows[i]["sub_total"]);
                    decimal discount = Convert.ToDecimal(dt.Rows[i]["discount"]);
                    string sales_type = dt.Rows[i]["sales_type"].ToString();
                    string bill_no = dt.Rows[i]["bill_no"].ToString();
                    DateTime date2 = Convert.ToDateTime(dt.Rows[i]["date2"].ToString());
                    if (subtotal > 0)
                    {
                        decimal service_charge = 0;
                        decimal tax_amount = 0;
                        decimal subtotal_with_services;
                        decimal subtotalwithDiscount = subtotal - discount;
                        TaxCalculation tax = new TaxCalculation();
                        if (sales_type != "TA" && service_chargeStatus == "True")
                        {
                            service_charge = tax.service_calculation(subtotalwithDiscount);
                        }
                        subtotal_with_services = (subtotalwithDiscount + service_charge);
                        tax_amount = tax.tax_calculation(Convert.ToDecimal(subtotal_with_services));
                        int upadateTax = bbtc.updatetaxandservice(bill_no, date2, tax_amount, service_charge, subtotal_with_services);
                        int upadateTaxmat = bbtc.updatetaxandserviceMet(bill_no, date2, tax_amount, subtotal_with_services);
                    }
                }
            }
        }

        string service_chargeStatus = "False";
        private void SalesDataTaxCalculate_Load(object sender, EventArgs e)
        {
            DataTable dtm = bbtc.getAllServiceTax();
            if (dtm.Rows.Count > 0)
            {
                if (dtm.Rows[0]["service_charge_value"].ToString() == "True")
                {
                    service_chargeStatus = "True";
                }
            }
        }
    }
}
