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
    public class BLLStock
    {
        public int createstock(int category_id, int product_id, decimal quantity, int dept_id, string loaction,string unit)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@category_id",category_id),
             new SqlParameter("@product_id",product_id),
             new SqlParameter("@qty",quantity),      
             new SqlParameter("@department_id",dept_id),           
             new SqlParameter("@unit",unit),
              new SqlParameter("@location",loaction)
            };
            return DAL.IUD_SP("sp_stock_data_insert",CommandType.StoredProcedure, parm);
        }
        public DataTable Searchbylocation(string location)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@location",location)
            };

            return DAL.getuser("select category_name,product_name,department,unit,qty,location,stock_id from tbl_stock s join tbl_categorys c on s.category_id=c.category_id join tbl_stock_products p on s.product_id=p.product_id join tbl_department d on s.department_id=d.id where location=@location", parm);
        }
        public DataTable getlocation()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select distinct location from tbl_stock", null);
            return dt;
        }
        public int createstockLog(int category_id, int product_id, decimal quantity, int dept_id, string loaction, string unit, DateTime dateOfSales, string status)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@category_id",category_id),
             new SqlParameter("@product_id",product_id),
             new SqlParameter("@qty",quantity),
             new SqlParameter("@department_id",dept_id),
             new SqlParameter("@unit",unit),
              new SqlParameter("@location",loaction),
              new SqlParameter("@dateOfSales",dateOfSales),
              new SqlParameter("@status",status)


            };
            return DAL.IUD_SP("sp_stock_data_insertLog", CommandType.StoredProcedure, parm);
        }

        public int insert_stockTransfer(int category_id, int product_id, decimal quantity, string loaction, string unit,string transfer_by,string transfer_to,DateTime transfer_date)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@category_id",category_id),
             new SqlParameter("@product_id",product_id),
             new SqlParameter("@qty",quantity),        
             new SqlParameter("@location",loaction),
             new SqlParameter("@unit",unit),
             new SqlParameter("@transfer_by",transfer_by),
             new SqlParameter("@transfer_to",transfer_to),
             new SqlParameter("@transfer_date",transfer_date)
            };
            return DAL.IDU("insert into tbl_stock_transfer (category_id,product_id,qty,location,unit,transfer_by,transfer_to,transfer_date) values (@category_id,@product_id,@qty,@location,@unit,@transfer_by,@transfer_to,@transfer_date)", parm);
        }
        public DataTable getallstockBYId(int stock_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@stock_id",stock_id)
                };
         
            return DAL.getuser("select * from tbl_stock s  join tbl_categorys c on (s.category_id=c.category_id) join tbl_stock_products p on (s.product_id=p.product_id) where stock_id=@stock_id", parm);
           
        }
        public int stockTransferQuanltityLess(int product_id, string loaction,decimal quantity)
        {
            SqlParameter[] parm = new SqlParameter[]
               {
                   new SqlParameter("@product_id",product_id),
                   new SqlParameter("@location",loaction),
                    new SqlParameter("@quantity",quantity)
               };
            return DAL.IDU("update tbl_stock set qty=qty-@quantity where product_id=@product_id and location=@location", parm);
        }
        public DataTable getallstock()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from tbl_stock", null);
            return dt;
        }


        public DataTable SearchbyProductname(string product_name)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@product_name",product_name)
            };

            return DAL.getuser("select category_name,product_name,department,unit,qty,location,stock_id from tbl_stock s join tbl_categorys c on s.category_id=c.category_id join tbl_stock_products p on s.product_id=p.product_id join tbl_department d on s.department_id=d.id where product_name like '%' +@product_name+ '%'", parm);

        }
        public DataTable SearchbyCategoryname(string category_name)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@category_name",category_name)
            };

            return DAL.getuser("select category_name,product_name,department,unit,qty,location,stock_id from tbl_stock s join tbl_categorys c on s.category_id=c.category_id join tbl_stock_products p on s.product_id=p.product_id join tbl_department d on s.department_id=d.id where category_name like '%' +@category_name+ '%'", parm);

        }
        public DataTable SearchbyCategoryId(int category_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@category_id",category_id)
            };

            return DAL.getuser("select category_name,product_name,department,unit,qty,location,stock_id from tbl_stock s join tbl_categorys c on s.category_id=c.category_id join tbl_stock_products p on s.product_id=p.product_id join tbl_department d on s.department_id=d.id where category_id=@category_id", parm);

        }
        public DataTable SearchbyDepartment(string department)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@department",department)
            };

            return DAL.getuser("select category_name,product_name,department,unit,qty,location,stock_id from tbl_stock s join tbl_categorys c on s.category_id=c.category_id join tbl_stock_products p on s.product_id=p.product_id join tbl_department d on s.department_id=d.id where department like '%' +@department+ '%'", parm);
        }
        public DataTable getallstockbyname(string category_name)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@category_name",category_name)
            };
            return DAL.getuser("select * from tbl_stock_products where product_name=@category_name", parm);
        }

      
        public DataTable GetProductDate(int product_id, DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
               new SqlParameter("@product_id",product_id),
             new SqlParameter("@from",from),
              new SqlParameter("@to",to),
           };
            return DAL.getuser("select s.stock_id,c.category_name,p.product_name, d.department, s.unit,s.qty, s.location,s.dateOfSales from tbl_stocklog s inner join tbl_stock_products p on s.product_id= p.product_id inner join tbl_categorys c on s.category_id= c.category_id inner join tbl_department d on s.department_id= d.id where p.product_id=@product_id and cast(dateOfSales as date)between @from and @to", parm);

        }
        public DataTable GetItemSales(int item_id, DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
               new SqlParameter("@item_id",item_id),
             new SqlParameter("@from",from),
              new SqlParameter("@to",to),
           };
            return DAL.getuser("select s.id,i.item_name,p.product_name, s.unit,s.qty,s.status, s.location,s.date_of_sales from tbl_stock_sales_log s inner join tbl_stock_products p on s.product_id= p.product_id inner join tbl_items i on s.item_id= i.item_id where i.item_id=@item_id and cast(date_of_sales as date)between @from and @to", parm);

        }
        public DataTable GetProductSales(int product_id, DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
               new SqlParameter("@product_id",product_id),
             new SqlParameter("@from",from),
              new SqlParameter("@to",to),
           };
            return DAL.getuser("select s.id,i.item_name,p.product_name, s.unit,s.qty,s.status, s.location,s.date_of_sales from tbl_stock_sales_log s inner join tbl_stock_products p on s.product_id= p.product_id inner join tbl_items i on s.item_id= i.item_id where p.product_id=@product_id and cast(date_of_sales as date)between @from and @to", parm);

        }
        public DataTable SumQuantity(DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
         {
             new SqlParameter("@from",from),
              new SqlParameter("@to",to),
         };
            DataTable dt = new DataTable();
            dt = DAL.getuser("select sum(qty) from tbl_stockLog where cast(dateOfSales as date) between @from and @to", parm);
            return dt;
        }
        public DataTable SumSalesQuantity(int product_id,DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
         {
             new SqlParameter("@product_id",product_id),
             new SqlParameter("@from",from),
              new SqlParameter("@to",to),
         };
            DataTable dt = new DataTable();
            dt = DAL.getuser("select sum(qty) as qty,unit from tbl_stock_sales_log where product_id=@product_id and date_of_sales between @from and @to group by qty,unit", parm);
            return dt;
        }
        public DataTable GetStockLog(DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
             new SqlParameter("@from",from),
              new SqlParameter("@to",to),
           };
            return DAL.getuser("select s.stock_id,c.category_name,p.product_name, d.department, s.unit,s.qty, s.location,s.dateOfSales from tbl_stocklog s inner join tbl_stock_products p on s.product_id= p.product_id inner join tbl_categorys c on s.category_id= c.category_id inner join tbl_department d on s.department_id= d.id where cast(dateOfSales as date)between @from and @to", parm);

        }
        public DataTable GetStockSales(DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
             new SqlParameter("@from",from),
              new SqlParameter("@to",to),
           };
            return DAL.getuser("select s.id,i.item_name,p.product_name, s.unit,s.qty,s.status, s.location,s.date_of_sales from tbl_stock_sales_log s inner join tbl_stock_products p on s.product_id= p.product_id inner join tbl_items i on s.item_id= i.item_id where cast(date_of_sales as date)between @from and @to", parm);

        }
        public DataTable GetCategoryDate(int category_id, DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
               new SqlParameter("@category_id",category_id),
             new SqlParameter("@from",from),
              new SqlParameter("@to",to),
           };
            return DAL.getuser("select s.stock_id,c.category_name,p.product_name, d.department, s.unit,s.qty, s.location,s.dateOfSales from tbl_stocklog s inner join tbl_stock_products p on s.product_id= p.product_id inner join tbl_categorys c on s.category_id= c.category_id inner join tbl_department d on s.department_id= d.id where c.category_id =@category_id and cast(dateOfSales as date)between @from and @to", parm);

        }
        public DataTable GetProduct(string product_name, DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
               new SqlParameter("@product_name",product_name),
             new SqlParameter("@from",from),
              new SqlParameter("@to",to),
           };
            return DAL.getuser("select (p.product_name),s.location,s.qty as purchase,s.dateOfSales,s.status,s.unit from tbl_stock_products p inner join tbl_stockLog s on p.product_id=s.product_id where cast(dateOfSales as date)between @from and @to and product_name=@product_name order by dateOfSales desc", parm);

        }
        public DataTable GetAllProduct(DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
           {
             new SqlParameter("@from",from),
              new SqlParameter("@to",to),
           };
            return DAL.getuser("select p.product_id,(p.product_name),s.location,s.qty as purchase,s.dateOfSales,s.status,s.unit from tbl_stock_products p inner join tbl_stockLog s on p.product_id=s.product_id where cast(dateOfSales as date) between @from and @to order by dateOfSales desc", parm);

        }
        public DataTable GetStock()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select s.stock_id,c.category_id,p.product_id,d.id,s.qty,s.location,c.category_name,p.product_name,d.department from tbl_stock s inner join tbl_categorys c on s.category_id=c.category_id inner join tbl_stock_products p on s.product_id=p.product_id inner join tbl_department d on s.department_id=d.id ", null);
            return dt;
        }
        public DataTable Getproduct()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from tbl_stock_products", null);
            return dt;
        }
        public int Decreasestock(int category_id, int product_id, decimal quantity, int dept_id, string location, string unit)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@category_id",category_id),
             new SqlParameter("@product_id",product_id),
             new SqlParameter("@qty",quantity),
             new SqlParameter("@department_id",dept_id),
             new SqlParameter("@unit",unit),
             new SqlParameter("@location",location)


            };
            return DAL.IUD_SP("sp_stock_data_decrease", CommandType.StoredProcedure, parm);
        }
        public DataTable getproductunit(int product_id, int category_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@product_id",product_id),
             new SqlParameter("@category_id",category_id)
            };
            return DAL.getuser("select inhouse_unit_1,inhouse_unit_2,inhouse_unit_3 from tbl_stock_products where product_id=@product_id and category_id=@category_id", parm);
        }
        public DataTable GetstockCalculation()
        {

            return DAL.getuser(" select sp.product_name, d.department, s.qty,s.product_id,s.location  from tbl_stock s inner join tbl_stock_products sp on s.product_id= sp.product_id inner join tbl_department d on d.id= s.department_id", null);

        }
        public DataTable StockProductCalculation(string product_name)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@product_name",product_name)
            };

            return DAL.getuser("select sp.product_name, d.department, s.qty,s.product_id from tbl_stock s inner join tbl_stock_products sp on s.product_id= sp.product_id inner join tbl_department d on d.id= s.department_id where product_name like '%' +@product_name+ '%'", parm);

        }
        public DataTable DepartmentStockCalculation(string department)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@department",department)
            };

            return DAL.getuser("select sp.product_name, d.department, s.qty,s.product_id from tbl_stock s inner join tbl_stock_products sp on s.product_id= sp.product_id inner join tbl_department d on d.id= s.department_id where department like '%' +@department+ '%'", parm);
        }

        public DataTable GetLatestPrice(int product_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@product_id",product_id)
                };

            return DAL.getuser("select top 1  purchase_date,price,unit from tbl_purchase where product_id = @product_id order by purchase_date desc", parm);

        }
        public DataTable GetCalculationQty()
        {
            return DAL.getuser("select min_stock,s.product_id,s.qty,product_name from tbl_stock_products p inner join tbl_stock s on p.product_id=s.product_id where qty=min_stock or qty<min_stock and location='M'", null);
        }
        public int DecreaseStock(int category_id, int product_id, decimal quantity, int dept_id, string loaction, string unit)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@category_id",category_id),
             new SqlParameter("@product_id",product_id),
             new SqlParameter("@qty",quantity),
             new SqlParameter("@department_id",dept_id),
             new SqlParameter("@unit",unit),
              new SqlParameter("@location",loaction)
            };
            return DAL.IUD_SP("sp_stock_data_decrease", CommandType.StoredProcedure, parm);
        }
        public DataTable getfiscalyear()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from tbl_fiscal_year where is_active='True'", null);
            return dt;
        }
        public DataTable GetInventoryCategory()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from account_category where category_name='Inventory'", null);
            return dt;
        }
        public DataTable GetSupplier_Amount(string supplier_name)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@supplier_name",supplier_name)
            };
            return DAL.getuser("select sum(distinct grand_total) as grand_total from tbl_purchase where supplier_name=@supplier_name", parm);
        }
        public int InsertTransaction(int category_id, string category_name, DateTime date, string description, Decimal amount, string fiscal_year, string payment_mode)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@category_id",category_id),
             new SqlParameter("@category_name",category_name),
             new SqlParameter("@date",date),
             new SqlParameter("@description",description),
             new SqlParameter("@amount",amount),
              new SqlParameter("@fiscal_year",fiscal_year),
               new SqlParameter("@payment_mode",payment_mode),
            };
            return DAL.IDU("insert into acc_transactions(category_id,category_name,date,description,amount,fiscal_year,paymentmode) values (@category_id,@category_name,@date,@description,@amount,@fiscal_year,@payment_mode)", parm);
        }
        public DataTable GetProductCalculationQty(int product_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                    new SqlParameter("@product_id",product_id)
                };
            return DAL.getuser("select * from tbl_stock_products p inner join tbl_stock s on p.product_id=s.product_id where qty=min_stock or qty<min_stock and location='M' and s.product_id=@product_id", parm);
        }
    }
}

        
  
    

