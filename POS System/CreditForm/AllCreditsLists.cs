using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLS;
using System.IO;

namespace POS_System
{
    public partial class AllCreditsLists : UserControl
    {
        public AllCreditsLists()
        {
            InitializeComponent();
        }

       //// decimal creditAdd = 0;
       // decimal cashadd = 0;
       // decimal creditleft = 0;
       // public string allItemNames;

      //  Bll_tblcredit btc = new Bll_tblcredit();
        BLLcustomer_credit blcc = new BLLcustomer_credit();
        BillPrintingHotel bph = new BillPrintingHotel();
        BLL_Billing_Tax blbt = new BLL_Billing_Tax();

        private static Creditpayform GetCrp()
        {
            Creditpayform crp = new Creditpayform();
            return crp;
        }
        int customer_id = CustomerDetail.customer_id;
        BLLcredit_clear blclear = new BLLcredit_clear();
        BLLOrder blod = new BLLOrder();
       string creditload = second_user_interface.creditload;
        BLLcustomer_credit blcustom = new BLLcustomer_credit();
      //  int customer_id = CustomerDetail.customer_id;
        private void AllCreditsLists_Load(object sender, EventArgs e)
        {
            LoadCustomerCredit();
            //CreditSum();
            //PaidSum();
            //  calculation();
          
            DataTable dt = blcc.Get_Customer_ById(customer_id);
                {
                if(dt.Rows.Count>0)
                {
                    Byte[] image = (byte[]) dt.Rows[0]["image"];
                    MemoryStream msstream = new MemoryStream(image);
                    picbox_user.Image = System.Drawing.Image.FromStream(msstream);
                    lbl_name.Text = dt.Rows[0]["name"].ToString();
                    lbl_phone.Text= dt.Rows[0]["phone"].ToString();
                    lbl_address.Text = dt.Rows[0]["address"].ToString();
                    lbl_city.Text = dt.Rows[0]["city"].ToString();
                    lbl_email.Text = dt.Rows[0]["email"].ToString();
                    lbl_id.Text = dt.Rows[0]["id"].ToString();
                lbl_remain.Text=(Convert.ToDecimal(lbl_total.Text)-Convert.ToDecimal(lbl_pay.Text)).ToString();
                }
            }

        }
       public void LoadCustomerCredit()
        {
            if (creditload=="Hotel Credit")
            {
                DataTable dt2 = blcustom.Get_Data_By_Customer_Id(customer_id);
                lbl_credit.Text = dt2.Rows[0]["sum_credit_amount"].ToString();
                lbl_creditfrom.Text = "Restro Crdt:";
               
                DataTable dt = blcc.Get_Hotel_credit_Customerid(customer_id);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int abc = dataGridView1.Rows.Add();
                        int customer_id = Convert.ToInt32(dt.Rows[i]["customer_id"].ToString());

                        DataTable dt1 = blcc.Get_Customer_ById(customer_id);
                        if (dt1.Rows.Count > 0)
                        {
                            dataGridView1.Rows[i].Cells["col_customername"].Value = dt1.Rows[0]["name"].ToString();
                        }
                        dataGridView1.Rows[i].Cells["col_bill_no"].Value = dt.Rows[i]["bill_no"].ToString();
                  
                            dataGridView1.Rows[i].Cells["col_credit_amount"].Value = dt.Rows[i]["credit_amount"].ToString();
                            dataGridView1.Rows[i].Cells["col_credit_by"].Value = dt.Rows[i]["credit_by"].ToString();
                            dataGridView1.Rows[i].Cells["col_credit_date"].Value = dt.Rows[i]["credit_date"].ToString();
                        
                    }
                }
                CreditHotelSum();
                PaidHotelSum();
            }
            else if (creditload=="")
           {
                DataTable dt2 = blcustom.Get_HotelData_By_Customer_Id(customer_id);
                lbl_credit.Text = dt2.Rows[0]["sum_credit_amount"].ToString();
                lbl_creditfrom.Text = "Hotel Credit:";
                 DataTable dt = blcc.Get_customer_credit_Customerid(customer_id);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int abc = dataGridView1.Rows.Add();
                        int customer_id = Convert.ToInt32(dt.Rows[i]["customer_id"].ToString());

                        DataTable dt1 = blcc.Get_Customer_ById(customer_id);
                        if (dt1.Rows.Count > 0)
                        {
                            dataGridView1.Rows[i].Cells["col_customername"].Value = dt1.Rows[0]["name"].ToString();
                        }
                        dataGridView1.Rows[i].Cells["col_bill_no"].Value = dt.Rows[i]["bill_no"].ToString();
                        //DataTable dtbill = blcc.Get_Credit(Convert.ToInt32(dt.Rows[i]["bill_no"].ToString()));
                        //if (dtbill.Rows.Count > 1)
                        //{
                        //    for (int j = 0; j < dtbill.Rows.Count; j++)
                        //    {
                        //        dataGridView1.Rows[j].Cells["col_credit_amount"].Value = dt.Rows[j]["credit_amount"].ToString();
                        //        dataGridView1.Rows[j].Cells["col_credit_by"].Value = dt.Rows[j]["credit_by"].ToString();
                        //        dataGridView1.Rows[j].Cells["col_credit_date"].Value = dt.Rows[j]["credit_date"].ToString();
                        //    }
                        //}
                     
                            dataGridView1.Rows[i].Cells["col_credit_amount"].Value = dt.Rows[i]["credit_amount"].ToString();
                            dataGridView1.Rows[i].Cells["col_credit_by"].Value = dt.Rows[i]["credit_by"].ToString();
                            dataGridView1.Rows[i].Cells["col_credit_date"].Value = dt.Rows[i]["credit_date"].ToString();
                        
                   

                    }
                }
                CreditSum();
                PaidSum();
            }
        }
  public void CreditSum()
        {
            DataTable dt = blcc.Get_Customer_creditsum(customer_id);

                {
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString().ToString() == "")
                    {
                        lbl_total.Text = "0.00";
                    }
                    else
                    {
                        lbl_total.Text = (Convert.ToDecimal(dt.Rows[0][0].ToString())).ToString();
                    }
                }
            
            }
        }
        public void CreditHotelSum()
        {
            DataTable dt = blcc.Get_hotel_creditsum(customer_id);

            {
                if (dt.Rows.Count > 0)
                {
                    lbl_total.Text = (Convert.ToDecimal(dt.Rows[0][0].ToString())).ToString();

                }

            }
        }
        public void PaidHotelSum()
        {
            DataTable dt = blcc.Get_hotelcustomer_paidsum(customer_id);
            {
                if (dt.Rows.Count > 0)
                {
                    DataTable dt1 = blcc.Check_HotelPaid_Customerid(customer_id);
                    if (dt1.Rows.Count > 0)
                    {
                        lbl_pay.Text = (1 * (Convert.ToDecimal(dt.Rows[0][0].ToString()))).ToString();

                    }
                    else
                    {
                        MessageBox.Show("No payment have been done till now", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }
            }
        }
        public void PaidSum()
        {
            DataTable dt = blcc.Get_Customer_paidsum(customer_id);
             {
                if (dt.Rows.Count > 0)
                {
                    DataTable dt1 = blcc.Check_NextTable_Customerid(customer_id);
                    if (dt1.Rows.Count > 0)
                    {
                        lbl_pay.Text = (1 * (Convert.ToDecimal(dt.Rows[0][0].ToString()))).ToString();

                    }
                    else
                    {
                        MessageBox.Show("No payment have been done till now", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }

                }  
            }
        }
      private void btn_clearall_Click_1(object sender, EventArgs e)
        {

            Creditpayform cl = new Creditpayform();
            cl.phone_no = lbl_phone.Text;
            cl.lbl_names.Text = lbl_name.Text;
            cl.ShowDialog();
        }
 private void Show_paid_credits_Click(object sender, EventArgs e)
        {
            Control ctl = this.Parent;
            CreditPaidForm cpf = new CreditPaidForm();
            ctl.Controls.Clear();
            ctl.Controls.Add(cpf);

        }
  private void btn_back_Click(object sender, EventArgs e)
        {
            Control ctl = this.Parent;
            CustomerDetail cd = new CustomerDetail();
            ctl.Controls.Clear();
            ctl.Controls.Add(cd);

        }
        BLLPrinterSetting blpst = new BLLPrinterSetting();
        public static DateTime dates;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["col_reprint"].Index && e.RowIndex >= 0)
            {
                printer_checker();
            }
            else if (e.ColumnIndex == dataGridView1.Columns["col_bill_no"].Index && e.RowIndex >= 0)
            {
                BillDetails detail = new BillDetails();
                detail.lbl_bill_no.Text = dataGridView1.CurrentRow.Cells["col_bill_no"].Value.ToString();
                dates= Convert.ToDateTime(dataGridView1.CurrentRow.Cells["col_credit_date"].Value.ToString());
                detail.Show();
            }
       
        }
     
        //public void bill_printing_for_hotel()
        //{
        //    string bill_no = dataGridView1.CurrentRow.Cells["col_bill_no"].Value.ToString();
        //    bph.bill_no = bill_no;
          
        //    bph.credit_amount = dataGridView1.CurrentRow.Cells["col_credit_amount"].Value.ToString();
        //    bph.customer_name = dataGridView1.CurrentRow.Cells["col_customername"].Value.ToString();
        //    bph.credit_by= dataGridView1.CurrentRow.Cells["col_credit_by"].Value.ToString();
        //    bph.credit_date = dataGridView1.CurrentRow.Cells["col_credit_date"].Value.ToString();
        //    //  bph.credit_by = dataGridView1.CurrentRow.Cells["col_customername"].Value.ToString();
           
        //    DateTime date_of_billing = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["col_credit_date"].Value);
        //    DataTable dt_bil = blbt.get_all_tax_by_bill_no(bill_no, date_of_billing);
        //    if (dt_bil.Rows.Count > 0)
        //    {
        //        bph.tax_amount = dt_bil.Rows[0]["tax_amount"].ToString();
        //        bph.service_charge = dt_bil.Rows[0]["service_charge"].ToString();
        //    }
        //    DataTable dt = blod.searchbybill2(bill_no);
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        bph.datagridview_item_name.Add(dt.Rows[i]["item_name"].ToString());
        //        bph.datagridview_item_price.Add(dt.Rows[i]["cost"].ToString());
        //        bph.datagridview_total.Add(dt.Rows[i]["total"].ToString());
        //        bph.datagridview_quantity.Add(dt.Rows[i]["quantity"].ToString());
        //      //  bph.datagridview_discount.Add(dt.Rows[i]["discount"].ToString());
        //        //bph.datagridview_grandtotal.Add(dt.Rows[i]["grand_total"].ToString());
        //    }
        //    bph.print();
        //  // save_after_print = blp_80.save_after_print;
        //}
           // bool save_after_print;
        public void printer_checker()
        {
            int bill_no = Convert.ToInt32(dataGridView1.CurrentRow.Cells["col_bill_no"].Value);

           // DataTable dt = blcc.Get_Credit_ByBillno(bill_no);
            DataTable dt_prt = blpst.getalldata();
            if (dt_prt.Rows.Count > 0)
            {
                if (dt_prt.Rows[0]["bill_printer"].ToString() == "80")
                {
                   // bill_printing_for_hotel();
                   bill_printing_for_80();
                }
                else if (dt_prt.Rows[0]["bill_printer"].ToString() == "76")
                {
                    bill_printing_for_76();
                }
                else
                {
                    bill_printing_for_58();
                }
            }
        }
        BillPrinting80 blp_80 = new BillPrinting80();
        BillPrinting blp = new BillPrinting();
        BillPrinting76 blp_76 = new BillPrinting76();
       // bool save_after_print;
        public void bill_printing_for_80()
        {
            string bill_no = dataGridView1.CurrentRow.Cells["col_bill_no"].Value.ToString();
            blp_80.bill_no = bill_no;

           // blp_80.c = dataGridView1.CurrentRow.Cells["col_credit_amount"].Value.ToString();
            blp_80.customer_name = dataGridView1.CurrentRow.Cells["col_customername"].Value.ToString();
            //blp_80.credit_by = dataGridView1.CurrentRow.Cells["col_credit_by"].Value.ToString();
            //blp_80.credit_date = dataGridView1.CurrentRow.Cells["col_credit_date"].Value.ToString();
            //  bph.credit_by = dataGridView1.CurrentRow.Cells["col_customername"].Value.ToString();

            DateTime date_of_billing = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["col_credit_date"].Value);
           
              
            DataTable dt = blod.searchbybill2(bill_no);
            blp_80.table_no = dt.Rows[0]["table_no"].ToString();
            blp_80.discount = dt.Rows[0]["discount"].ToString();
            blp_80.grand_total = dt.Rows[0]["grand_total"].ToString();
            blp_80.sub_total = dt.Rows[0]["sub_total"].ToString();
            blp_80.tax_amount = dt.Rows[0]["tax_amount"].ToString();
            blp_80.service_charge = dt.Rows[0]["service_charge"].ToString();

            blp_80.billing_date = Convert.ToDateTime(dt.Rows[0]["date_of_sale"]);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                blp_80.datagridview_item_name.Add(dt.Rows[i]["item_name"].ToString());
                blp_80.datagridview_item_price.Add(dt.Rows[i]["cost"].ToString());
                blp_80.datagridview_total.Add(dt.Rows[i]["total"].ToString());
                blp_80.datagridview_quantity.Add(dt.Rows[i]["quantity"].ToString());
                blp_80.datagridview_complementary.Add("");
           
            }
            blp_80.printtobill();
            //save_after_print = blp_80.save_after_print;
        }
        public void bill_printing_for_76()
        {

            string bill_no = dataGridView1.CurrentRow.Cells["col_bill_no"].Value.ToString();
            blp_76.bill_no = bill_no;

            //blp_76.credit_amount = dataGridView1.CurrentRow.Cells["col_credit_amount"].Value.ToString();
            blp_76.customer_name = dataGridView1.CurrentRow.Cells["col_customername"].Value.ToString();
            //blp_76.credit_by = dataGridView1.CurrentRow.Cells["col_credit_by"].Value.ToString();
            //blp_76.credit_date = dataGridView1.CurrentRow.Cells["col_credit_date"].Value.ToString();
            //  bph.credit_by = dataGridView1.CurrentRow.Cells["col_customername"].Value.ToString();

            DateTime date_of_billing = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["col_credit_date"].Value);
           
               
          
            DataTable dt = blod.searchbybill2(bill_no);
            blp_76.table_no = dt.Rows[0]["table_no"].ToString();
            blp_76.discount = dt.Rows[0]["discount"].ToString();
            blp_76.grand_total = dt.Rows[0]["grand_total"].ToString();
            blp_76.tax_amount = dt.Rows[0]["tax_amount"].ToString();
            blp_76.service_charge = dt.Rows[0]["service_charge"].ToString();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                blp_76.datagridview_item_name.Add(dt.Rows[i]["item_name"].ToString());
                blp_76.datagridview_item_price.Add(dt.Rows[i]["cost"].ToString());
                blp_76.datagridview_total.Add(dt.Rows[i]["total"].ToString());
                blp_76.datagridview_quantity.Add(dt.Rows[i]["quantity"].ToString());
             
            }
            blp_76.printtobill();

        }
        public void bill_printing_for_58()
        {
            string bill_no = dataGridView1.CurrentRow.Cells["col_bill_no"].Value.ToString();
            blp.bill_no = bill_no;

            //blp.credit_amount = dataGridView1.CurrentRow.Cells["col_credit_amount"].Value.ToString();
            blp.customer_name = dataGridView1.CurrentRow.Cells["col_customername"].Value.ToString();
            //blp.credit_by = dataGridView1.CurrentRow.Cells["col_credit_by"].Value.ToString();
            //blp.credit_date = dataGridView1.CurrentRow.Cells["col_credit_date"].Value.ToString();
            //  bph.credit_by = dataGridView1.CurrentRow.Cells["col_customername"].Value.ToString();

            DateTime date_of_billing = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["col_credit_date"].Value);
           
               
           
            DataTable dt = blod.searchbybill2(bill_no);
            blp.table_no = dt.Rows[0]["table_no"].ToString();
            blp.discount = dt.Rows[0]["discount"].ToString();
            blp.grand_total = dt.Rows[0]["grand_total"].ToString();
            blp.tax_amount = dt.Rows[0]["tax_amount"].ToString();
            blp.service_charge = dt.Rows[0]["service_charge"].ToString();
            blp.tax_amount = dt.Rows[0]["tax_amount"].ToString();
            blp.service_charge = dt.Rows[0]["service_charge"].ToString();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                blp.datagridview_item_name.Add(dt.Rows[i]["item_name"].ToString());
                blp.datagridview_item_price.Add(dt.Rows[i]["cost"].ToString());
                blp.datagridview_total.Add(dt.Rows[i]["total"].ToString());
                blp.datagridview_quantity.Add(dt.Rows[i]["quantity"].ToString());
     
            }
            blp.printtobill();


        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            CreditDetail detail = new CreditDetail();
            detail.lbl_credit_amount.Text = lbl_total.Text;
            detail.lbl_paid.Text = lbl_pay.Text;
            detail.lbl_customer_name.Text = dataGridView1.CurrentRow.Cells["col_customername"].Value.ToString();
            detail.lbl_customer_id.Text = (lbl_id.Text);
            detail.Show();
        }
    }
}
