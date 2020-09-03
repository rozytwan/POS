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
   public class BLLComplementry
    {
        public int complementryInsert(int bill_no, string item_name, decimal qty, decimal cost, DateTime com_date, string user_name,string status,int comp_invoice)
        {
            SqlParameter [] parm  = new SqlParameter[]
            {
                                                new SqlParameter("@bill_no",bill_no),
                                                new SqlParameter("@item_name",item_name),
                                                new SqlParameter("@qty",qty),
                                                new SqlParameter("@cost",cost),
                                                new SqlParameter("@com_date",com_date),
                                                new SqlParameter("@user_name",user_name),
                                                new SqlParameter("@status",status),
                                                 new SqlParameter("@comp_invoice",comp_invoice)
            };
            return DAL.IDU("insert into tbl_complementry_tracking (bill_no,item_name,qty,cost,com_date,com_user,status,comp_invoice) values (@bill_no,@item_name,@qty,@cost,@com_date,@user_name,@status,@comp_invoice)", parm);
        }
        public DataTable GetComplementry()
        {
            return DAL.getuser("select * from tbl_complementry_tracking", null);
        }
        public DataTable GetItem()
        {
            return DAL.getuser("select distinct(item_name) from tbl_complementry_tracking", null);
        }
        public DataTable GetUser()
        {
            return DAL.getuser("select distinct(com_user) from tbl_complementry_tracking", null);
        }
        public DataTable GetCustomer()
        {
            return DAL.getuser("select distinct(customer_name) from tbl_complementry_sales", null);
        }
        public DataTable GetBill()
        {
            return DAL.getuser("select distinct(bill_no) from tbl_complementry_tracking", null);
        }
        public DataTable GetBillComplementry(int bill_no)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
                new SqlParameter("@bill_no",bill_no),

        };
            return DAL.getuser("select * from tbl_complementry_tracking where bill_no=@bill_no", parm);
        }
        public DataTable GetItemComplementry(string item_name,DateTime datefrom,DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
                new SqlParameter("@item_name",item_name),
                 new SqlParameter("@datefrom",datefrom),
                  new SqlParameter("@dateto",dateto),

        };
            return DAL.getuser("select * from tbl_complementry_tracking where item_name=@item_name and cast(com_date as date) between @datefrom and @dateto", parm);
        }
        public DataTable GetUserComplementry(string com_user, DateTime datefrom, DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
                new SqlParameter("@com_user",com_user),
                 new SqlParameter("@datefrom",datefrom),
                  new SqlParameter("@dateto",dateto),

        };
            return DAL.getuser("select * from tbl_complementry_tracking where com_user=@com_user and cast(com_date as date) between @datefrom and @dateto", parm);
        }
        public DataTable GetAllComplementry(DateTime datefrom, DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
            
                 new SqlParameter("@datefrom",datefrom),
                  new SqlParameter("@dateto",dateto),

        };
            return DAL.getuser("select * from tbl_complementry_tracking where cast(com_date as date)between @datefrom and @dateto", parm);
        }

        public DataTable GetCategoryComplementry(string category_name, DateTime datefrom, DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
                new SqlParameter("@category_name",category_name),
                    new SqlParameter("@datefrom",datefrom),
                  new SqlParameter("@dateto",dateto),


        };
            return DAL.getuser("select * from tbl_complementry_sales where category_name=@category_name and cast(date_of_sales as date) between @datefrom and @dateto", parm);
        }
        public DataTable GetHotelCategoryComplementry(string category_name, DateTime datefrom, DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
                new SqlParameter("@category_name",category_name),
                    new SqlParameter("@datefrom",datefrom),
                  new SqlParameter("@dateto",dateto),


        };
            return DAL.getuser("select * from tbl_complementry_sales where category_name=@category_name and status='HC' and cast(date_of_sales as date) between @datefrom and @dateto", parm);
        }
   
        public DataTable GetItemComplementrysales(string item_name, DateTime datefrom, DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
                new SqlParameter("@item_name",item_name),
                 new SqlParameter("@datefrom",datefrom),
                  new SqlParameter("@dateto",dateto),

        };
            return DAL.getuser("select * from tbl_complementry_sales where item_name=@item_name and cast(date_of_sales as date) between @datefrom and @dateto", parm);
        }
        public DataTable GetHotelItemComplementrysales(string item_name, DateTime datefrom, DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
                new SqlParameter("@item_name",item_name),
                 new SqlParameter("@datefrom",datefrom),
                  new SqlParameter("@dateto",dateto),

        };
            return DAL.getuser("select * from tbl_complementry_sales where item_name=@item_name and status='HC'and cast(date_of_sales as date) between @datefrom and @dateto", parm);
        }
        public DataTable GetCashierComplementry(string cashier_name, DateTime datefrom, DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
                new SqlParameter("@cashier_name",cashier_name),
                 new SqlParameter("@datefrom",datefrom),
                  new SqlParameter("@dateto",dateto),

        };
            return DAL.getuser("select * from tbl_complementry_sales where cashier_name=@cashier_name and cast(date_of_sales as date) between @datefrom and @dateto", parm);
        }
        public DataTable GetHotelCashierComplementry(string cashier_name, DateTime datefrom, DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
                new SqlParameter("@cashier_name",cashier_name),
                 new SqlParameter("@datefrom",datefrom),
                  new SqlParameter("@dateto",dateto),

        };
            return DAL.getuser("select * from tbl_complementry_sales where cashier_name=@cashier_name and status='HC'and cast(date_of_sales as date) between @datefrom and @dateto", parm);
        }
        public DataTable GetCustomerComplementry(string customer_name, DateTime datefrom, DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
                new SqlParameter("@customer_name",customer_name),
                 new SqlParameter("@datefrom",datefrom),
                  new SqlParameter("@dateto",dateto),

        };
            return DAL.getuser("select * from tbl_complementry_sales where customer_name=@customer_name and cast(date_of_sales as date) between @datefrom and @dateto", parm);
        }
        public DataTable GetHotelCustomerComplementry(string customer_name, DateTime datefrom, DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
                new SqlParameter("@customer_name",customer_name),
                 new SqlParameter("@datefrom",datefrom),
                  new SqlParameter("@dateto",dateto),

        };
            return DAL.getuser("select * from tbl_complementry_sales where customer_name=@customer_name and status='HC' and cast(date_of_sales as date) between @datefrom and @dateto", parm);
        }
        public DataTable GetAllComplementrysales(DateTime datefrom, DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
        {

                 new SqlParameter("@datefrom",datefrom),
                  new SqlParameter("@dateto",dateto),

        };
            return DAL.getuser("select * from tbl_complementry_sales where cast(date_of_sales as date)between @datefrom and @dateto", parm);
        }
        public DataTable GetAllHotelComplementrysales(DateTime datefrom, DateTime dateto)
        {
            SqlParameter[] parm = new SqlParameter[]
        {

                 new SqlParameter("@datefrom",datefrom),
                  new SqlParameter("@dateto",dateto),

        };
            return DAL.getuser("select * from tbl_complementry_sales where status='HC' and cast(date_of_sales as date)between @datefrom and @dateto", parm);
        }
        public DataTable getinvoiceno()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select max(comp_invoice) from tbl_complementry_sales", null);
            return dt;
        }

        public int insertcomplementry_using_sp(DateTime date_of_sales, string cashier_name, string item_name, decimal quantity, decimal cost, string kot_type, string category_name, string customer_name, string customer_no,string status,string x_report,decimal total,int comp_invoice)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@date_of_sales",date_of_sales),
        new SqlParameter("@cashier_name",cashier_name),
        new SqlParameter ("@item_name",item_name),
        new SqlParameter("@quantity",quantity),
        new SqlParameter("@cost",cost),
         new SqlParameter("@kot_type",kot_type),
          new SqlParameter("@category_name",category_name),
           new SqlParameter("@customer_name",customer_name),
          new SqlParameter("@customer_no",customer_no),
          new SqlParameter("@status",status),
           new SqlParameter("@x_report",x_report),
          new SqlParameter("@total",total),
           new SqlParameter("@comp_invoice",comp_invoice)

            };
            return DAL.IUD_SP("dbo.sp_complementry_sales", CommandType.StoredProcedure, parm);
        }
        public DataTable GetCategory()
        {
            return DAL.getuser("select distinct(category_name) from tbl_complementry_sales", null);
        }
        public DataTable GetComplementryitem()
        {
            return DAL.getuser("select distinct(item_name) from tbl_complementry_sales", null);
        }
    }
}
