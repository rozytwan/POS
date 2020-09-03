using DOA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLS
{
  public  class BLL_Billing_Tax
    {
        public int billing_tax(int bill_no, decimal tax_amount, decimal service_charge,DateTime date_of_sales)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@bill_no",bill_no),
                new SqlParameter("@tax_amount",tax_amount),
                new SqlParameter("@service_charge",service_charge),
                 new SqlParameter("@date_of_sales",date_of_sales),

            };
            return DAL.IDU("insert into tbl_tax_service_billing (bill_no,tax_amount,service_charge,date_of_sales) values (@bill_no,@tax_amount,@service_charge,@date_of_sales)", parm);
        }
        public int irdCBMS(string buyer_pan,string buyer_name,string invoice_number,string invoice_date,string total_sales,string taxable_sales_vat,string vat,string excisable_amount,string excise,string taxable_sales_hst,string hst,string amount_for_esf,string esf,string export_sales,string tax_exempted_sales)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                new SqlParameter("@buyer_pan",buyer_pan),
                new SqlParameter("@buyer_name",buyer_name),
                new SqlParameter("@invoice_number",invoice_number),
                 new SqlParameter("@invoice_date",invoice_date),
                 new SqlParameter("@total_sales",total_sales),
                new SqlParameter("@taxable_sales_vat",taxable_sales_vat),
                new SqlParameter("@vat",vat),
                 new SqlParameter("@excisable_amount",excisable_amount),
                 new SqlParameter("@excise",excise),
                new SqlParameter("@taxable_sales_hst",taxable_sales_hst),
                new SqlParameter("@hst",hst),
                 new SqlParameter("@amount_for_esf",amount_for_esf),
                 new SqlParameter("@esf",esf),
                new SqlParameter("@export_sales",export_sales),
                 new SqlParameter("@tax_exempted_sales",tax_exempted_sales)

           };
            return DAL.IDU("insert into tbl_ird_cbms_offline (buyer_pan,buyer_name,invoice_number,invoice_date,total_sales,taxable_sales_vat,vat,excisable_amount,excise,taxable_sales_hst,hst,amount_for_esf,esf,export_sales,tax_exempted_sales)" +
               "values (@buyer_pan,@buyer_name,@invoice_number,@invoice_date,@total_sales,@taxable_sales_vat,@vat,@excisable_amount,@excise,@taxable_sales_hst,@hst,@amount_for_esf,@esf,@export_sales,@tax_exempted_sales )",parm);
        }
        public int irdCBMSsalesReturn(string buyer_pan, string buyer_name, string ref_invoice_number,string credit_note_number, string credit_note_date,string reason_for_return, string total_sales, string taxable_sales_vat, string vat, string excisable_amount, string excise, string taxable_sales_hst, string hst, string amount_for_esf, string esf, string export_sales, string tax_exempted_sales)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
                new SqlParameter("@buyer_pan",buyer_pan),
                new SqlParameter("@buyer_name",buyer_name),
                new SqlParameter("@ref_invoice_number",ref_invoice_number),
                 new SqlParameter("@credit_note_date",credit_note_date),
                    new SqlParameter("@credit_note_number",credit_note_number),
                 new SqlParameter("@total_sales",total_sales),
                new SqlParameter("@taxable_sales_vat",taxable_sales_vat),
                 new SqlParameter("@reason_for_return",reason_for_return),
               new SqlParameter("@vat",vat),
                 new SqlParameter("@excisable_amount",excisable_amount),
                 new SqlParameter("@excise",excise),
                new SqlParameter("@taxable_sales_hst",taxable_sales_hst),
                new SqlParameter("@hst",hst),
                 new SqlParameter("@amount_for_esf",amount_for_esf),
                 new SqlParameter("@esf",esf),
                new SqlParameter("@export_sales",export_sales),
                 new SqlParameter("@tax_exempted_sales",tax_exempted_sales)

           };
            return DAL.IDU("insert into tbl_ird_cbms_sr_offline (buyer_pan,buyer_name,ref_invoice_number,credit_note_date,credit_note_number,reason_for_return,total_sales,taxable_sales_vat,vat,excisable_amount,excise,taxable_sales_hst,hst,amount_for_esf,esf,export_sales,tax_exempted_sales)" +
               "values (@buyer_pan,@buyer_name,@ref_invoice_number,@credit_note_date,@credit_note_number,@reason_for_return,@total_sales,@taxable_sales_vat,@vat,@excisable_amount,@excise,@taxable_sales_hst,@hst,@amount_for_esf,@esf,@export_sales,@tax_exempted_sales )", parm);
        }
        public DataTable checkDataIRDCBMS()
        {
            return DAL.getuser("select * from tbl_ird_cbms_offline", null);
        }
        public DataTable checkDataIRDCBMSSalesReturn()
        {
            return DAL.getuser("select * from tbl_ird_cbms_sr_offline", null);
        }
        public int truncateIRDData()
        {
            return DAL.IDU("truncate table tbl_ird_cbms_offline", null);
        }
        public int deleteIrdData(int irdid)
        {
        SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@id",irdid),

                };
            return DAL.IDU("delete from tbl_ird_cbms_offline where ird_id=@id", parm);
        }
        public int truncateIRDDataSalesReturn()
        {
            return DAL.IDU("truncate table tbl_ird_cbms_sr_offline", null);
        }
        public DataTable get_all_tax_by_bill_no(string bill_no, DateTime date_of_sale)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@bill_no",bill_no),
                     new SqlParameter("@date_of_sale",date_of_sale)
                };
            return DAL.getuser("select * from tbl_tax_service_billing where bill_no=@bill_no and  date_of_sales=@date_of_sale ", parm);
        }

        public DataTable get_all_tax_by_bill_no(int bill_no)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@bill_no",bill_no),

                };
            return DAL.getuser("select * from tbl_tax_service_billing where bill_no=@bill_no", parm);
        }
        public DataTable get_service_charge(decimal service_charge,DateTime date)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@service_charge",service_charge),
                new SqlParameter("@date",date)
            };
            return DAL.getuser("select sum(service_charge) from tbl_tax_service_billing where @date=date_of_sales", parm);
        }
      
    }
}
