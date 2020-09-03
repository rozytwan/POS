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
    public class BLLhome_delivery
    {


        public DataTable getalldata()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from tbl_home_delivery", null);
            return dt;
        }
        public DataTable getalldatabykotId(decimal kotid)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@kotid",kotid)
            };
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from tbl_home_delivery where kotId =@kotid ", parm);
            return dt;
        }
        public DataTable getallHomedeliveryTables()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select DISTINCT hd_no from tbl_home_delivery_nos", null);
            return dt;
        }

        public int updateHomedeliveryStatus(string kotId)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@kotId",kotId)
            };
            return DAL.IDU("Update tbl_home_delivery set payment_status='Paid' where kotId=@kotId", parm);
        }
        public int deleteHomedeliveryStatus(string kotid)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@kotid",kotid)
            };
            return DAL.IDU("Delete from  tbl_orders where table_no=@kotid", parm);
        }

        public DataTable getDataFromKot(string kotId)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@kotId",kotId)
            };
            return DAL.getuser("select * from tbl_orders where table_no=@kotId", parm);

        }
        public int inserttheDeleverystats(decimal kotid, string customer_name, string customer_adress, string customer_phone, decimal grandtotal, string deliveryman, string payment_status, decimal delivery_charge, decimal total,int bill_no,string payment_type,decimal service_charge,decimal taxable_amount,decimal tax_amount,string fiscal_year,string discount)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@kotid",kotid),
                 new SqlParameter("@customer_name",customer_name),
                  new SqlParameter("@customer_adress",customer_adress),
                   new SqlParameter("@customer_phone",customer_phone),
                   new SqlParameter("@grandtotal",grandtotal),
                       new SqlParameter("@payment_status",payment_status),
                       new SqlParameter("@deliveryman",deliveryman),
                        new SqlParameter("@delivery_charge",delivery_charge),
                       new SqlParameter("@total",total),
                         new SqlParameter("@bill_no",bill_no),
                         new SqlParameter("@payment_type",payment_type),
                        new SqlParameter("@service_charge",service_charge),
                        new SqlParameter("@taxable_amount",taxable_amount),
                        new SqlParameter("@tax_amount",tax_amount),
                        new SqlParameter("@fiscal_year",fiscal_year),
                         new SqlParameter("@discount",discount)
            };
            return DAL.IDU("insert into  tbl_home_delivery (customer_name,customer_adress,customer_phone,grandtotal,payment_status,kotid,deliveryman,delivery_charge,total,bill_no,payment_type,service_charge,taxable_amount,tax_amount,fiscal_year,discount)values(@customer_name,@customer_adress,@customer_phone,@grandtotal,@payment_status,@kotid,@deliveryman,@delivery_charge,@total,@bill_no,@payment_type,@service_charge,@taxable_amount,@tax_amount,@fiscal_year,@discount)", parm);
        }
        public DataTable gethomedelevery()
        {
            return DAL.getuser("select MAX(hd_no) from tbl_home_delivery_nos", null);
        }
        public int inserthomedeleveryid(int hd_no)
        {
            SqlParameter[] parm = new SqlParameter[]
          {
            new SqlParameter("@hd_no",hd_no)

          };
            return DAL.IDU("insert into tbl_home_delivery_nos values(@hd_no)", parm);
        }
        public int deletehomedeleveryid(string hd_no)
        {
            SqlParameter[] parm = new SqlParameter[]
          {
            new SqlParameter("@hd_no",hd_no)

          };
            return DAL.IDU("delete from tbl_home_delivery_nos where hd_no=@hd_no", parm);
        }
        
        public int deletehomedeleveryvalue(decimal kotId)
        {
            SqlParameter[] parm = new SqlParameter[]
          {
            new SqlParameter("@kotId",kotId)

          };
            return DAL.IDU("delete from tbl_home_delivery where kotId=@kotId", parm);
        }

        public int DeleteHomedeliveryCustomer(string kot_id)
        {
            SqlParameter[] parm = new SqlParameter[]
          {
            new SqlParameter("@kot_id",kot_id)

          };
            return DAL.IDU("delete from tbl_homedeliveryCustomer where kot_id=@kot_id", parm);
        }
    }


}
