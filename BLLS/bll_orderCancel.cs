using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DOA;

namespace BLLS
{
    public class bll_orderCancel
    {
        public int insertordercancellation(string user_name, decimal table_no, string item, decimal quantity, decimal total, decimal cost, string active, string category_name, string kot_print, string phone, DateTime date,string cancel_type,string delete_type)
        {
            SqlParameter[] parm = new SqlParameter[]
          {
            new SqlParameter("@user_name",user_name),
        new SqlParameter("@table_no",table_no),
        new SqlParameter ("@item",item),
        new SqlParameter("@quantity",quantity),
        new SqlParameter("@total",total),
        new SqlParameter("@cost",cost),
         new SqlParameter("@active",active),
          new SqlParameter("@category_name",category_name),
           new SqlParameter("@kot_print",kot_print),
           new SqlParameter("@phone",phone),
           new SqlParameter("@date",date),
            new SqlParameter("@cancel_type",cancel_type),
            new SqlParameter("@delete_type",delete_type)
          };
            return DAL.IDU("insert into tbl_ordercancel (category,table_no,item,quantity,total,cost,user_name,kot_print,phone,active,date,cancel_type,delete_type)values(@category_name,@table_no,@item,@quantity,@total,@cost,@user_name,@kot_print,@phone,@active,@date,@cancel_type,@delete_type)", parm);
        }
        public DataTable getallCancelOrders()
        {
            return DAL.getuser("select * from tbl_ordercancel", null);
        }

        public DataTable getalltableno()
        {
            return DAL.getuser("SELECT COUNT(DISTINCT table_no),table_no FROM tbl_ordercancel group by table_no ", null);
        }
        public DataTable getallcategory()
        {
            return DAL.getuser("SELECT COUNT(DISTINCT table_no),category FROM tbl_ordercancel group by category ", null);
        }
        public DataTable getalitems()
        {
            return DAL.getuser("SELECT COUNT(DISTINCT table_no),item FROM tbl_ordercancel group by item ", null);
        }

        public DataTable getbyTablesearch(string tableno, DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {
                 new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                new SqlParameter("@tableno",tableno)
            };
            return DAL.getuser("select * from tbl_ordercancel where table_no=@tableno and date between @dateFrom and @dataTo", parm);
        }

        public DataTable getbyitems(string item, DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {
                 new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                new SqlParameter("@item",item)
            };
            return DAL.getuser("select * from tbl_ordercancel where item=@item  and date between @dateFrom and @dataTo", parm);
        }
        public DataTable getbycategory(string category, DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {
                  new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                new SqlParameter("@category",category)
            };
            return DAL.getuser("select * from tbl_ordercancel where category=@category  and date between @dateFrom and @dataTo", parm);
        }
        public DataTable getallCancelOrdersbydates(DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {
            new SqlParameter("@dateFrom", dateFrom),
                new SqlParameter("@dataTo", dataTo),
            };
            return DAL.getuser("select * from tbl_ordercancel  where date between @dateFrom and @dataTo", parm);
        }
        public DataTable getby_sales_type(string sales_type, DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {
                  new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                new SqlParameter("@sales_type",sales_type)
            };
            return DAL.getuser("select * from tbl_ordercancel where delete_type=@sales_type  and date between @dateFrom and @dataTo", parm);
        }
        
     public DataTable getbyitemsorder(string item)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@item",item)
            };
            return DAL.getuser("select * from tbl_orders where item=@item ", parm);
        }
        public DataTable getbyHotelitemsorder(string item)
        {
            SqlParameter[] parm = new SqlParameter[] {
               
                new SqlParameter("@item",item)
            };
            return DAL.getuser("select * from hotel_order where item=@item ", parm);
        }
        public DataTable getbycategoryorder(string category)
        {
            SqlParameter[] parm = new SqlParameter[] {
                  
                new SqlParameter("@category",category)
            };
            return DAL.getuser("select * from tbl_orders where category_name=@category ", parm);
        }
        public DataTable getbyHotelcategoryorder(string category)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@category",category)
            };
            return DAL.getuser("select * from hotel_order where category_name=@category ", parm);
        }
        public DataTable getallOrdersbydates()
        { 
            
            return DAL.getuser("select * from tbl_orders", null);
        }
        public DataTable getallHotelOrdersbydates()
        {

            return DAL.getuser("select * from hotel_order", null);
        }
        public DataTable getby_sales_typeOrder(string sales_type)
        {
            SqlParameter[] parm = new SqlParameter[] {
                 
                new SqlParameter("@sales_type",sales_type)
            };
            return DAL.getuser("select * from tbl_orders where delete_type=@sales_type", parm);
        }
        public DataTable getby_Hotelsales_typeOrder(string sales_type)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@sales_type",sales_type)
            };
            return DAL.getuser("select * from hotel_order where sales_type=@sales_type", parm);
        }
        public DataTable getbytable_no(decimal table_no)
        {
            SqlParameter[] parm = new SqlParameter[] {
               
                new SqlParameter("@table_no",table_no)
            };
            return DAL.getuser("select * from tbl_ordercancel where table_no=@table_no", parm);
        }
    }
}
