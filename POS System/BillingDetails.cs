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
    public partial class BillingDetails : Form
    {
        public BillingDetails()
        {
            InitializeComponent();
        }
        BillPrinting80 blp_80 = new BillPrinting80();
        BillPrinting blp = new BillPrinting();
        BLLPrinterSetting blpst = new BLLPrinterSetting();
        BLLBill_printing blp_re = new BLLBill_printing();
        BLLTakeAway bltk = new BLLTakeAway();
        public string bill_no_print;
        public string grand_total;
        public string remaining_amount;
        public string received_amount;
        public string take_away_id;
        public string bill_no;
        public string cashier;
        public string cash_amount;
        public string discount;
        public string sub_total;
        public string table_no;
        public string customer_pan_no;
        public string customer_name;
        public string discount_percent;
        public string tax_amount;
        public string service_charge;
        public string area_name;
        public string change_amount;
        public string billing_date;
        public string taxable_amount;
        public string discount_sub_total;
        public List<string> item_name= new List<string>();
        public List<string> item_price=new List<string>();
        public List<string> total=new List<string>();
        public List<string> quantity= new List<string>();
        public List<string> Complementry = new List<string>();
        private void btn_current_page_Click(object sender, EventArgs e)
        {
            btn_create_new_billing.DialogResult = DialogResult.None;
            this.Close();
        }

        private void btn_reprint_Click(object sender, EventArgs e)
        {
            //DataTable dt_prt = blpst.getalldata();
            //if (dt_prt.Rows[0]["bill_printer"].ToString() == "80")
            //{
            //    int insert_abc = blp_re.insert_bill_reprint(bill_no_print);
            //    blp_80.print_again = true;
            //    blp_80.printtobill();
            //}
            //else
            //{
            //    int insert_abc = blp_re.insert_bill_reprint(bill_no_print);
            //    blp.print_again = true;
            //    blp.printtobill();
            //}
            btn_create_new_billing.DialogResult = DialogResult.None;
            billing_data();
        }

        public void billing_data()
        {

            blp_80.bill_no = bill_no;
            blp_80.cashier = cashier;
            blp_80.cash_amount = cash_amount;
            blp_80.discount = discount;
            blp_80.grand_total = grand_total;
            blp_80.sub_total = sub_total;
            blp_80.table_no = table_no;
            blp_80.customer_PAN_no = customer_pan_no;
            blp_80.customer_name = customer_name;
            blp_80.discount_percent = discount_percent;
            blp_80.tax_amount = tax_amount;
            blp_80.service_charge = service_charge;
            blp_80.area_name = area_name;
            if (change_amount != "")
            {
                blp_80.change_amount = change_amount;
            }
            blp_80.billing_date = Convert.ToDateTime(billing_date);
            blp_80.taxable_amount = taxable_amount;
            blp_80.discount_sub_total = Convert.ToDecimal(sub_total).ToString("#.##");

            for (int i = 0; i < item_name.Count; i++)
            {
                blp_80.datagridview_item_name.Add(item_name[i]);
                blp_80.datagridview_quantity.Add(quantity[i]);
                blp_80.datagridview_total.Add(total[i]);
                blp_80.datagridview_item_price.Add(item_price[i]);
                blp_80.datagridview_complementary.Add(Complementry[i]);
            }
            blp_80.printtobill();

        }
    
        private void BillingDetails_Load(object sender, EventArgs e)
        {
            lbl_change_amount.Text = remaining_amount;
            lbl_grand_total.Text = grand_total;
            lbl_received_amount.Text = received_amount;
        }

        private void btn_create_new_billing_Click(object sender, EventArgs e)
        {
            btn_create_new_billing.DialogResult = DialogResult.OK;
            this.Hide();
        }
    }
}
