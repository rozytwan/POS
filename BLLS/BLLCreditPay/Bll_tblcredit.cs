using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOA;
using System.Data.SqlClient;
using System.Data;

namespace BLLS
{
    public class Bll_tblcredit
    {
        public DataTable getall() {
            return DAL.getuser("select *from tbl_credit",null);
        }
        public int insertinto(int billno, DateTime Date , string cashiername, string table_no,string customername, string customernumber, string item_name, int quantity, decimal cost, decimal total, string payment_mode, decimal cashamount, decimal creditamount, string cus_id, string sales_type,string x_report,string category) {

            SqlParameter[]  parameters = new SqlParameter []{
                new SqlParameter("@billno",billno),
                   new SqlParameter("@Date",Date),
                      new SqlParameter("@cashiername",cashiername),
                         new SqlParameter("@table_no",table_no),
                            new SqlParameter("@customername",customername),
                               new SqlParameter("@customernumber",customernumber),
                                     new SqlParameter("@item_name",item_name),
                                        new SqlParameter("@quantity",quantity),
                                           new SqlParameter("@cost",cost),
                                              new SqlParameter("@total",total),
                                                 new SqlParameter("@payment_mode",payment_mode),
                                                    new SqlParameter("@cashamount",cashamount),
                                                       new SqlParameter("@creditamount",creditamount),
                                                         new SqlParameter("@cus_id",cus_id),
                                                           new SqlParameter("@sales_type",sales_type),
                                                             new SqlParameter("@x_report",x_report),
                                                             new SqlParameter("@category",category)
            };
            return DAL.IDU("insert into tbl_credits values(@billno,@Date,@cashiername,@table_no,@customername,@customernumber,@item_name,@quantity,@cost,@total,@payment_mode,@cashamount,@creditamount,@cus_id,@sales_type,@x_report,@category)", parameters);
        }
        public int insertintotblcreditLeft(int billno, DateTime Date, string cashiername, string table_no, string customername, string customernumber, string item_name, int quantity, decimal cost, decimal total, string payment_mode, decimal cashamount, decimal creditamount, string cus_id, string sales_type, string x_report, string category)
        {

            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@billno",billno),
                   new SqlParameter("@Date",Date),
                      new SqlParameter("@cashiername",cashiername),
                         new SqlParameter("@table_no",table_no),
                            new SqlParameter("@customername",customername),
                               new SqlParameter("@customernumber",customernumber),
                                     new SqlParameter("@item_name",item_name),
                                        new SqlParameter("@quantity",quantity),
                                           new SqlParameter("@cost",cost),
                                              new SqlParameter("@total",total),
                                                 new SqlParameter("@payment_mode",payment_mode),
                                                    new SqlParameter("@cashamount",cashamount),
                                                       new SqlParameter("@creditamount",creditamount),
                                                         new SqlParameter("@cus_id",cus_id),
                                                           new SqlParameter("@sales_type",sales_type),
                                                             new SqlParameter("@x_report",x_report),
                                                             new SqlParameter("@category",category)
            };
            return DAL.IDU("insert into tbl_creditsLeft values(@billno,@Date,@cashiername,@table_no,@customername,@customernumber,@item_name,@quantity,@cost,@total,@payment_mode,@cashamount,@creditamount,@cus_id,@sales_type,@x_report,@category)", parameters);
        }
        public DataTable getallCreditLeftOver(string id) {
            SqlParameter [] parm  = new SqlParameter[] {
                new SqlParameter("@id", id)
            };
            return DAL.getuser("select *from tbl_creditsLeft where cus_id=@id",parm);
        }

        public int insertintotblcreditRecords(int billno, DateTime Date, string cashiername, string table_no, string customername, string customernumber, string item_name, int quantity, decimal cost, decimal total, string payment_mode, decimal cashamount, decimal creditamount, string cus_id, string sales_type, string x_report, string category)
        {

            SqlParameter[] parameters = new SqlParameter[]{
                new SqlParameter("@billno",billno),
                   new SqlParameter("@Date",Date),
                      new SqlParameter("@cashiername",cashiername),
                         new SqlParameter("@table_no",table_no),
                            new SqlParameter("@customername",customername),
                               new SqlParameter("@customernumber",customernumber),
                                     new SqlParameter("@item_name",item_name),
                                        new SqlParameter("@quantity",quantity),
                                           new SqlParameter("@cost",cost),
                                              new SqlParameter("@total",total),
                                                 new SqlParameter("@payment_mode",payment_mode),
                                                    new SqlParameter("@cashamount",cashamount),
                                                       new SqlParameter("@creditamount",creditamount),
                                                         new SqlParameter("@cus_id",cus_id),
                                                           new SqlParameter("@sales_type",sales_type),
                                                             new SqlParameter("@x_report",x_report),
                                                             new SqlParameter("@category",category)
            };
            return DAL.IDU("insert into tbl_creditsRecords values(@billno,@Date,@cashiername,@table_no,@customername,@customernumber,@item_name,@quantity,@cost,@total,@payment_mode,@cashamount,@creditamount,@cus_id,@sales_type,@x_report,@category)", parameters);
        }
        public DataTable getallCreditRecords(string id)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@id", id)
            };
            return DAL.getuser("select *from tbl_creditsRecords where cus_id=@id", parm);
        }


        public DataTable getallTblData() {
                return DAL.getuser("Select * from tbl_credits ",null);
            }

        public DataTable getallTblDatabyBillNo(string Bill_no)
        {
            SqlParameter[] parm = new SqlParameter[] {
            new SqlParameter("@Bill_no",Bill_no)};
            return DAL.getuser("Select * from tbl_credits where Bill_no=@Bill_no ", parm);
        }
        public DataTable getallcutomerNames() {
            return DAL.getuser("select * from tbl_customerDetailnyo",null);
        }

        public DataTable getallAvailabeUsernames() {
            return DAL.getuser("SELECT customername,cus_id, COUNT(cus_id) FROM tbl_credits group by customername, cus_id", null);
        }
        public DataTable getDataByCustomerId(string id,DateTime dtpfrom, DateTime dtpTo) {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@id",id),
                new SqlParameter("@dtpfrom",dtpfrom),
                new SqlParameter("@dtpTo",dtpTo)
            };
            return DAL.getuser("select *from tbl_credits where cus_id=@id and date between @dtpfrom and  @dtpTo ", parm);
        }

        public DataTable getDataByCustomerIdCountingBillno(string id, DateTime dtpfrom, DateTime dtpTo)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@id",id),
                new SqlParameter("@dtpfrom",dtpfrom),
                new SqlParameter("@dtpTo",dtpTo)
            };
            return DAL.getuser("select Bill_no,Count(Bill_no) from tbl_credits where cus_id=@id and date between @dtpfrom and  @dtpTo group by Bill_no ", parm);
        }
        public int DeletebyCusId(string id) {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            return DAL.IDU("delete from tbl_credits where cus_id=@id",parm);

        }
        public int DeletebyCusIdInCreditLeftover(string id)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            return DAL.IDU("delete from tbl_creditsLeft where cus_id=@id", parm);

        }
    }
}
