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
    public class BLLOrder
    {
     
        public DataTable getalldatasFromSalesRecords()
        {
            return DAL.getuser("SELECT bill_no ,COUNT(*) FROM tbl_sales_record GROUP BY bill_no", null);
        }
        public DataTable getalldatasFromSalesRecords_delete_record()
        {
            return DAL.getuser("SELECT bill_no ,COUNT(*) FROM tbl_sales_record_delete GROUP BY bill_no", null);
        }
        public int insertorderfire(string user_name, decimal table_no, string item, decimal quantity, decimal total, decimal cost, string active, string category_name, string kot_print, string sales_type, string service_provider, int KOTId,string fire_type)
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
           new SqlParameter("@sales_type",sales_type),
             new SqlParameter("@service_provider",service_provider),
            new SqlParameter("@kot_id",KOTId),
            new SqlParameter("@fire_type",fire_type),
          };
          //  return DAL.IDU("insert into tbl_ordersFire(user_name,table_no,item,quantity,total,cost,active,category_name,kot_print,sales_type,service_provider,kot_id,fire_type) values(@user_name,@table_no,@item,@quantity,@total,@cost,@active,@category_name,@kot_print,@sales_type,@service_provider,@kot_id,@fire_type)", parm);
            return DAL.IUD_SP("dbo.sp_orders_fire", CommandType.StoredProcedure, parm);
        }

        public int insertorder_using_sp(string user_name, decimal table_no, string item, decimal quantity, decimal total, decimal cost, string active, string category_name, string kot_print, string phone,string service_provider,int KOTId)
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
           new SqlParameter("@service_provider",service_provider),
            new SqlParameter("@kot_id",KOTId)

            };
            return DAL.IUD_SP("dbo.sp_kitchen_orders", CommandType.StoredProcedure, parm);
        }
        public DataTable getalldata(decimal table_no)
        {
            SqlParameter[] parm = new SqlParameter[]{
         new SqlParameter("@table_no",table_no)
         };
            return DAL.getuser("select *,phone as sales_type from tbl_orders where table_no=@table_no", parm);

        }
        public DataTable getalldata_startup(string table_no)
        {
            SqlParameter[] parm = new SqlParameter[]{
         new SqlParameter("@table_no",table_no)
         };
            return DAL.getuser("select * from tbl_ordersFire where table_no=@table_no and fire_type='Startup'", parm);

        }
        public DataTable getalldata_maincourse(string table_no)
        {
            SqlParameter[] parm = new SqlParameter[]{
         new SqlParameter("@table_no",table_no)
         };
            return DAL.getuser("select * from tbl_ordersFire where table_no=@table_no and fire_type='Main course'", parm);

        }
        public DataTable getalldata_dessert(string table_no)
        {
            SqlParameter[] parm = new SqlParameter[]{
         new SqlParameter("@table_no",table_no)
         };
            return DAL.getuser("select * from tbl_ordersFire where table_no=@table_no and fire_type='Dessert'", parm);

        }
        public DataTable getalldata_order()
        {
            return DAL.getuser("select max(order_id) from tbl_orders", null);

        }
        public DataTable Get_Fire_Startup(string table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
          {
            new SqlParameter ("@table_no",table_no)
          };
            return DAL.getuser("select * from tbl_ordersFire where fire_type='Startup' and table_no=@table_no", parm);

        }
        public int deletefromtable(decimal table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
        new SqlParameter ("@table_no",table_no)
        };
            return DAL.IDU("delete from tbl_orders where table_no=@table_no", parm);
        }
        public int deletefromorder_id(int order_id)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
        new SqlParameter ("@order_id",order_id)
        };
            return DAL.IDU("delete from tbl_orders where order_id=@order_id", parm);
        }
        public int deletefromorderfire_id(int table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
        new SqlParameter ("@table_no",table_no)
        };
            return DAL.IDU("delete from tbl_ordersFire where table_no=@table_no", parm);
        }
        public DataTable getalldatafromitem(int category_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@category_id",category_id)
                };

            return DAL.getuser("select * from tbl_items where category_id=@category_id", parm);

        }
        public DataTable getallitemprice(int item_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
         new SqlParameter("@item_id",item_id)
           };
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from tbl_items where item_id=@item_id", parm);
            return dt;
        }
        public int update_table_for_customer(decimal table_no, string user_name,string phone)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
          new SqlParameter("@table_no",table_no),
          new SqlParameter("@user_name",user_name),
           new SqlParameter("@phone",phone)

        };
            return DAL.IDU("update  tbl_orders set user_name=@user_name,phone=@phone where table_no=@table_no", parm);

        }
       

       
        public int updateorderstable(decimal quantity, int order_id, decimal total)
        {
            SqlParameter[] parm = new SqlParameter[]
            {

          new SqlParameter("quantity",quantity),
          new SqlParameter("order_id",order_id),
          new SqlParameter("total",total)
            };

            return DAL.IDU("update tbl_orders set quantity=@quantity,total=@total where order_id=@order_id", parm);
        }
        public int updateorderstablewithQty(decimal quantity, decimal total,string table_no,string item_name)
        {
            SqlParameter[] parm = new SqlParameter[]
            {

          new SqlParameter("quantity",quantity),
          new SqlParameter("table_no",table_no),
          new SqlParameter("total",total),
             new SqlParameter("item_name",item_name)
            };

            return DAL.IDU("update tbl_orders set quantity=quantity+@quantity,total=total+@total where table_no=@table_no and item=@item_name", parm);
        }
        public int updateorderItemTransfer(int order_id,decimal table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
          new SqlParameter("order_id",order_id),
          new SqlParameter("table_no",table_no)
            };

            return DAL.IDU("update tbl_orders set table_no=@table_no where order_id=@order_id", parm);
        }

       
        public DataTable searchitembyname2_taX_SALES(string item_name, DateTime dateFrom, DateTime dataTo,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@item_name",item_name),
                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo)
            };
            return DAL.getuser("WITH summary AS ( SELECT *,ROW_NUMBER() OVER(PARTITION BY S.bill_no ORDER BY S.bill_no DESC) AS rk FROM tbl_sales_record S)SELECT s.*FROM summary s WHERE s.rk = 1 and item_name like @item_name +'%' and  bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true') and  date2 between @dateFrom and @dataTo", parm);
        }
        public DataTable searchitembyname_delete_record(string item_name, DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@item_name",item_name),
                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo)
            };
            return DAL.getuser("select * from tbl_sales_record_delete where item_name like @item_name +'%' and  delete_date between @dateFrom and @dataTo", parm);
        }
      
        public DataTable searchbycategory_for_tax_(string category_name, DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@category_name",category_name),
                 new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo)
            };
            return DAL.getuser("WITH summary AS ( SELECT *,ROW_NUMBER() OVER(PARTITION BY S.bill_no ORDER BY S.bill_no DESC) AS rk FROM tbl_sales_record S)SELECT s.*FROM summary s WHERE s.rk = 1 and category_name like @category_name +'%'  and  bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true') and  date2 between @dateFrom and @dataTo", parm);
        }
        public DataTable searchbycategory2_delete_record(string category_name, DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@category_name",category_name),
                 new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo)
            };
            return DAL.getuser("select * from tbl_sales_record_delete where category_name like @category_name +'%' and  date2 between @dateFrom and @dataTo", parm);
        }
       

       
        public DataTable get_all_category_category_id(int db_category_id,int db_category_id2)
        {
            SqlParameter[] parm = new SqlParameter[] 
            {
                new SqlParameter("@db_category_id",db_category_id),
                 new SqlParameter("@db_category_id2",db_category_id2)
            };
            DataTable dt = DAL.getuser("select * from (SELECT ROW_NUMBER() over (order by category_name) as Row,category_id,category_name,category_image,category_color,applicable_time from tbl_item_category where applicable_time !='False') as emp where row between @db_category_id and @db_category_id2  ", parm);
            return dt;
        }
        public DataTable get_all_categoryGroupingById(int db_category_id, int db_category_id2,int id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@db_category_id",db_category_id),
                 new SqlParameter("@db_category_id2",db_category_id2),
                  new SqlParameter("@id",id)
            };
            DataTable dt = DAL.getuser("select * from (SELECT ROW_NUMBER() over (order by category_name) as Row,category_id,category_name,category_image,category_color,applicable_time,id from tbl_item_category where applicable_time!='False') as emp where  id=@id", parm);
            return dt;
        }
        public DataTable getallcategory()
        {
            return DAL.getuser("SELECT * FROM tbl_item_category order by category_name ASC", null);
        }
       
       
        public DataTable getoccoupiedChairOne(string table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@table_no",table_no)

                };
            DataTable dt = DAL.getuser("select * from tbl_orders where table_no like @table_no + '%'", parm);
            return dt;
        }
      
        public DataTable get_item_by_cateogory_id(int category_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                       {
             new SqlParameter("@category_id",category_id),
            
                       };
            return DAL.getuser("select * from tbl_items where category_id=@category_id", parm);
        }
        public DataTable get_item_by_category_id2(int category_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                       {
             new SqlParameter("@category_id",category_id)
            
                       };
            return DAL.getuser("select * from tbl_items where category_id=@category_id", parm);
        }
        public DataTable getitembyitem_id(int item_id)
        {

                        SqlParameter[] parm = new SqlParameter[]
                        {
                        new SqlParameter("@item_id",item_id)
                        };
                        return DAL.getuser("select * from tbl_items where item_id=@item_id", parm);
        }
        public DataTable getallbyitem_name(string item_name)
        {

            SqlParameter[] parm = new SqlParameter[]
                        {
             new SqlParameter("@item_name",item_name)
                        };

            return DAL.getuser("select * from tbl_items where item_name=@item_name", parm);


        }
        public DataTable getallbyitem_nameandTableno(string item_name,string table_no)
        {

            SqlParameter[] parm = new SqlParameter[]
                        {
             new SqlParameter("@item_name",item_name),
             new SqlParameter("@table_no",table_no)
                        };

            return DAL.getuser("select * from tbl_orders where item=@item_name and table_no=@table_no", parm);


        }
        public DataTable getallfromtblorder(decimal table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@table_no",table_no)

                };
            DataTable dt = DAL.getuser("select * from tbl_orders where table_no=@table_no", parm);
            return dt;
        }
        public DataTable getallfromorder_id(int order_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@order_id",order_id)

                };
            DataTable dt = DAL.getuser("select * from tbl_orders where order_id=@order_id", parm);
            return dt;
        }
        public int deleteitemfromorder(int order_id)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
                    new SqlParameter("@order_id",order_id)

               };
            return DAL.IDU("delete from tbl_orders where order_id=@order_id", parm);
        }
        public DataTable searchbybill2(string bill_no)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@bill_no",bill_no),

            };
            return DAL.getuser("SELECT  sr.bill_no,sr.item_name,sr.quantity,sr.total,sr.date_of_sale,sr.payment_mode,sr.sub_total,sr.discount,sr.cost,sr.cashier_name,sr.date2,sr.rest_sale_id,sr.cash_amount,sr.card_amount, sr.service_charge, sr.tax_amount, sr.grand_total, sr.sales_type, sr.table_no, sr.category_name, sr.customer_no, sr.customer_name,sr.fiscal_year FROM tbl_sales_record sr   where   sr.bill_no = @bill_no  and  sr.bill_no NOT IN(SELECT void_bill_no FROM tbl_bill_void where void_status='true')", parm);
        }
        public DataTable searchbybill2Count(string bill_no)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@bill_no",bill_no),

            };
            return DAL.getuser("select count(bill_no) from tbl_sales_record where bill_no = @bill_no  and  bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true')", parm);
        }
        public DataTable searchbybill_and_date(string bill_no,DateTime date2)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@bill_no",bill_no),
                 new SqlParameter("@date2",date2)

            };
            return DAL.getuser("select * from tbl_sales_record where bill_no=@bill_no and date_of_sale=@date2", parm);
        }
        public DataTable searchbybill2_for_tax(string bill_no,DateTime date2)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@bill_no",bill_no),
                 new SqlParameter("@date2",date2)

            };
            return DAL.getuser("WITH summary AS ( SELECT *,ROW_NUMBER() OVER(PARTITION BY S.bill_no ORDER BY S.bill_no asc) AS rk FROM tbl_sales_record S where  datepart(month,date2) = datepart(month,date2) and datepart(year, date2) = datepart(year, @date2))SELECT s.*FROM summary s WHERE s.rk = 1 and bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true') and bill_no = @bill_no ", parm);
        }
        public DataTable searchbybill2_delete_record(string bill_no)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@bill_no",bill_no),

            };
            return DAL.getuser("select * from tbl_sales_record_delete where bill_no = @bill_no ", parm);
        }
        public DataTable searchALLSales(DateTime dateFrom, DateTime dataTo, int minpagesize,int intskip,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                 new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("SELECT  Top "+ minpagesize+ " * FROM    tbl_sales_record WHERE  date_of_sale  between @dateFrom and @dataTo and  bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status = 'true' and void_reason=@fiscal_year) and rest_sale_id not in (select top " + intskip+ " rest_sale_id from tbl_sales_record where date_of_sale  between @dateFrom and @dataTo  and  bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status ='true' and void_reason=@fiscal_year))", parm);
        }
        public DataTable searchALLSalesWithoutpagination(DateTime dateFrom, DateTime dataTo,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("SELECT  sr.bill_no,sr.item_name,sr.quantity,sr.total,sr.date_of_sale,sr.cost,sr.payment_mode,sr.sub_total,sr.discount,sr.cash_amount,sr.card_amount,sr.service_charge,sr.tax_amount,sr.grand_total,sr.sales_type,sr.cashier_name,sr.customer_name FROM    tbl_sales_record sr   WHERE   sr.bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status ='true' and void_reason=@fiscal_year)  and date_of_sale  between @dateFrom and @dataTo order by sr.bill_no asc ", parm);
        }
        public DataTable searchALLSalesRecord(DateTime dateFrom, DateTime dataTo,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                 new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("SELECT  Count(bill_no) FROM    tbl_sales_record WHERE   bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year) and date_of_sale  between @dateFrom and @dataTo ", parm);
        }
        public DataTable searchitembyname2(string item_name, DateTime dateFrom, DateTime dataTo, string column_name,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@item_name",item_name),
                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                new SqlParameter("@column_name",column_name),
                 new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("select * from tbl_sales_record where " + column_name + "=@item_name and  date_of_sale between @dateFrom and @dataTo  and  bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year)", parm);
        }
        public DataTable searchitembyname2Count(string item_name, DateTime dateFrom, DateTime dataTo, string column_name,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@item_name",item_name),
                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                new SqlParameter("@column_name",column_name),
                 new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("select count(bill_no) from tbl_sales_record where " + column_name + "=@item_name and  date_of_sale between @dateFrom and @dataTo  and  bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true'and void_reason=@fiscal_year)", parm);
        }
        public DataTable searchby_kot_type(string kot_type,DateTime dateFrom, DateTime dataTo, string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@kot_type",kot_type),
                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                 new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("select * from tbl_sales_record where kot_type=@kot_type and date2 between @dateFrom and @dataTo and  bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year)", parm);
        }
        public DataTable searchALL_for_tax(DateTime dateFrom, DateTime dateTo,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dateTo",dateTo),
                 new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("WITH summary AS ( SELECT *,ROW_NUMBER() OVER(PARTITION BY S.bill_no ORDER BY S.bill_no DESC) AS rk FROM tbl_sales_record S WHERE bill_no NOT IN(SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year) and  date2 between @dateFrom and @dateTo)SELECT s.* FROM summary s WHERE s.rk = 1; ", parm);
        }
        public DataTable total_kitchen_k1(DateTime dateFrom, DateTime dataTo, string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                   new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("select sum(sr.sub_total) as total,sum(sr.discount) as discount,SUM(sr.grand_total) as grand_total,SUM(sr.tax_amount)as tax_amount,SUM(sr.service_charge) as service_charge,sr.bill_no as bill_no from tbl_sales_record sr where kot_type='K1' and date2 between @dateFrom and @dataTo   and  sr.bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year ) group by sr.bill_no,sr.date2", parm);
        }
        public DataTable total_kitchen_k2(DateTime dateFrom, DateTime dataTo, string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                   new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("select sum(sr.sub_total) as total,sum(sr.discount) as discount,SUM(sr.grand_total) as grand_total,SUM(sr.tax_amount)as tax_amount,SUM(sr.service_charge) as service_charge,sr.bill_no as bill_no from tbl_sales_record sr  where kot_type='K2' and date2 between @dateFrom and @dataTo    and  sr.bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year) group by sr.bill_no,sr.date2", parm);
        }
        public DataTable total_kitchen_b1(DateTime dateFrom, DateTime dataTo, string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                   new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser(" select sum(sr.sub_total) as total,sum(sr.discount) as discount,SUM(sr.grand_total) as grand_total,SUM(sr.tax_amount)as tax_amount,SUM(sr.service_charge) as service_charge,sr.bill_no as bill_no from tbl_sales_record sr   where kot_type='B1' and date2 between @dateFrom and @dataTo  and  sr.bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year)  group by sr.bill_no,sr.date2", parm);
        }

    
        public DataTable searchALL_delete_record(DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo)
            };
            return DAL.getuser("select * from tbl_sales_record_delete where delete_date between @dateFrom and @dataTo ", parm);
        }
        public DataTable searchsale_type_for_tax(string sales_type, DateTime dateFrom, DateTime dataTo,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                  new SqlParameter("@sales_type",sales_type),
                    new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("WITH summary AS ( SELECT *,ROW_NUMBER() OVER(PARTITION BY S.bill_no ORDER BY S.bill_no DESC) AS rk FROM tbl_sales_record S)SELECT s.*FROM summary s WHERE s.rk = 1 and   bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year) and sales_type=@sales_type and date2 between @dateFrom and @dataTo ", parm);
        }
     
        public DataTable searchsale_type_delete(string sales_type, DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                  new SqlParameter("@sales_type",sales_type),
            };
            return DAL.getuser("select * from tbl_sales_record_delete where sales_type=@sales_type and date2 between @dateFrom and @dataTo ", parm);
        }
      
        public DataTable searchsale_by_user_for_tax(string cashier_name, DateTime dateFrom, DateTime dataTo,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                  new SqlParameter("@cashier_name",cashier_name),
                     new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("WITH summary AS ( SELECT *,ROW_NUMBER() OVER(PARTITION BY S.bill_no ORDER BY S.bill_no DESC) AS rk FROM tbl_sales_record S)SELECT s.*FROM summary s WHERE s.rk = 1 and   bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year) and cashier_name=@cashier_name and date2 between @dateFrom and @dataTo ", parm);
        }
        public DataTable searchsale_by_serviceprovider_for_tax(string service_provider, DateTime dateFrom, DateTime dataTo,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                  new SqlParameter("@service_provider",service_provider),
                   new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("WITH summary AS ( SELECT *,ROW_NUMBER() OVER(PARTITION BY S.bill_no ORDER BY S.bill_no DESC) AS rk FROM tbl_sales_record S)SELECT s.*FROM summary s WHERE s.rk = 1 and   bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true'  and void_reason=@fiscal_year) and service_provider=@service_provider and date2 between @dateFrom and @dataTo ", parm);
        }
        public DataTable searchsale_by_user_for_kot_type(string kot_type, DateTime dateFrom, DateTime dataTo, string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                  new SqlParameter("@kot_type",kot_type),
                   new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("WITH summary AS ( SELECT *,ROW_NUMBER() OVER(PARTITION BY S.bill_no ORDER BY S.bill_no DESC) AS rk FROM tbl_sales_record S)SELECT s.*FROM summary s WHERE s.rk = 1 and   bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year) and kot_type=@kot_type and date2 between @dateFrom and @dataTo ", parm);
        }
        public DataTable searchsale_by_user_delete(string cashier_name, DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                  new SqlParameter("@cashier_name",cashier_name),
            };
            return DAL.getuser("select * from tbl_sales_record_delete where cashier_name=@cashier_name and date2 between @dateFrom and @dataTo ", parm);
        }
      
        public DataTable searchpayment_mode_for_tax(string payment_mode, DateTime dateFrom, DateTime dataTo, string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                  new SqlParameter("@payment_mode",payment_mode),
                   new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("WITH summary AS ( SELECT *,ROW_NUMBER() OVER(PARTITION BY S.bill_no ORDER BY S.bill_no DESC) AS rk FROM tbl_sales_record S)SELECT s.*FROM summary s WHERE s.rk = 1 and payment_mode=@payment_mode and   bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year) and date2 between @dateFrom and @dataTo ", parm);
        }
        public DataTable searchpayment_mode_delete_record(string payment_mode, DateTime dateFrom, DateTime dataTo)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                  new SqlParameter("@payment_mode",payment_mode),
            };
            return DAL.getuser("select * from tbl_sales_record_delete where payment_mode=@payment_mode and date2 between @dateFrom and @dataTo ", parm);
        }

        public DataTable itemGroup(DateTime dateFrom, DateTime dataTo,string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                 new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("select SUM(quantity) as quantity ,SUM(cost) as cost,item_name,kot_type from tbl_sales_record where  bill_no NOT IN(SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year)  and  date2 between @dateFrom and @dataTo group by item_name,kot_type order by kot_type asc", parm);
        }

        public DataTable itemGroup()
        {
           
            return DAL.getuser("select SUM(quantity) as quantity, item_name, sum(total) as cost from tbl_sales_record where x_report = 'X' group by item_name", null);
        }
        public DataTable DifferentBillno()
        {
            return DAL.getuser("SELECT  distinct(bill_no) as bill_no FROM    tbl_sales_record WHERE   bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true')", null);
        }
        public DataTable cancelitemGroup(DateTime dateFrom)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@dateFrom",dateFrom),

            };
            return DAL.getuser("select SUM(quantity) as quantity ,item,cost,cancel_type from tbl_ordercancel where cast(date as date)=@dateFrom group by item,cost,cancel_type", parm);
        }
        public DataTable GetMaxKotId()
        {
            return DAL.getuser("select MAX(kot_id) from tbl_orderKotId", null);
        }
        public DataTable searchby_customername(string customer_name, DateTime dateFrom, DateTime dataTo, string fiscal_year)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@customer_name",customer_name),
                new SqlParameter("@dateFrom",dateFrom),
                new SqlParameter("@dataTo",dataTo),
                 new SqlParameter("@fiscal_year",fiscal_year)
            };
            return DAL.getuser("select * from tbl_sales_record where customer_name=@customer_name and date2 between @dateFrom and @dataTo and  bill_no NOT IN (SELECT void_bill_no FROM tbl_bill_void where void_status='true' and void_reason=@fiscal_year)", parm);
        }
        public DataTable getallfromcustomerorder(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@customer_id",customer_id)

                };
            DataTable dt = DAL.getuser("select * from tbl_customer_settlements where customer_id=@customer_id", parm);
            return dt;
        }
        public int deletefromcustomerorder_id(int order_id)
        {
            SqlParameter[] parm = new SqlParameter[]
        {
        new SqlParameter ("@order_id",order_id)
        };
            return DAL.IDU("delete from tbl_customer_settlements where order_id=@order_id", parm);
        }
        public DataTable GetCusotmerOrder(int customer_id)
        {
            SqlParameter[] parm = new SqlParameter[]{
         new SqlParameter("@customer_id",customer_id)
         };
            return DAL.getuser("select * from tbl_customer_settlements where customer_id=@customer_id", parm);

        }
        public int InsertOrder_Customer_sp(int customer_id, string user_name, decimal table_no, string item, decimal quantity, decimal total, decimal cost, string active, string category_name, string kot_print, string sales_type, string service_provider, int KOTId)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@customer_id",customer_id),
            new SqlParameter("@user_name",user_name),
        new SqlParameter("@table_no",table_no),
        new SqlParameter ("@item",item),
        new SqlParameter("@quantity",quantity),
        new SqlParameter("@total",total),
        new SqlParameter("@cost",cost),
         new SqlParameter("@active",active),
          new SqlParameter("@category_name",category_name),
           new SqlParameter("@kot_print",kot_print),
           new SqlParameter("@sales_type",sales_type),
           new SqlParameter("@service_provider",service_provider),
            new SqlParameter("@kot_id",KOTId)

            };
            return DAL.IUD_SP("dbo.sp_customer_orders", CommandType.StoredProcedure, parm);
        }

    }
}



