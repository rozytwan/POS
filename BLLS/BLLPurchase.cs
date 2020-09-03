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
    public class BLLPurchase
    {
        public int createpurhase(int category_id, int product_id, decimal qty, string unit, int invoice_no, decimal price, decimal discount, decimal total, DateTime expiry_date, DateTime purchase_date, string po_no, string supplier_name, decimal sub_total, decimal tax, string received_by, decimal grand_total, string bill_no)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
       new SqlParameter("@category_id",category_id),
       new SqlParameter("@product_id",product_id),
       new SqlParameter("@qty",qty),
       new SqlParameter("@invoice_no",invoice_no),
       new SqlParameter("@price",price),
       new SqlParameter("@discount",discount),
       new SqlParameter("@total",total),
       new SqlParameter("@expiry_date",expiry_date),
      // new SqlParameter("@paid_amount",paid_amount),
        new SqlParameter("@purchase_date",purchase_date),
         new SqlParameter("@unit",unit),
         new SqlParameter("@supplier_name",supplier_name),
          new SqlParameter("@sub_total",sub_total),
            new SqlParameter("@tax",tax),
         new SqlParameter("@received_by",received_by),
         new SqlParameter("@grand_total",grand_total),
         new SqlParameter("@po_no",po_no),
         new SqlParameter("@bill_no",bill_no)

            };
            return DAL.IDU("insert into tbl_purchase (category_id,product_id,qty,invoice_no,price,discount,total,expiry_date,purchase_date,unit,po_no,supplier_name,sub_total,tax,received_by,grand_total,bill_no) values(@category_id,@product_id,@qty,@invoice_no,@price,@discount,@total,@expiry_date,@purchase_date,@unit,@po_no,@supplier_name,@sub_total,@tax,@received_by,@grand_total,@bill_no)", parm);
        }
        public DataTable getallpurchase()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from tbl_purchases", null);
            return dt;
        }
        public DataTable getpurchasebycategory(string category_name)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@category_name",category_name)
            };
            return DAL.getuser("select * from tbl_purchases where category_name = @category_name", parm);
        }
        public DataTable getpurchasebyproduct(int  product_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            new SqlParameter("@product_id",product_id)
            };
            return DAL.getuser("select * from tbl_stock_products where product_id =@product_id ", parm);
        }
        
        public DataTable getallpurchaseiInvoiceNo()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select invoice_no , Count(*) from tbl_purchases group by invoice_no", null);
            return dt;
        }
        public DataTable get_all_supliers()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select name from tbl_supplier_details", null);
            return dt;
        }

        public DataTable searchpurchasebydateProducts(string productname, DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@productname",productname),
                new SqlParameter("@from",from),
                new SqlParameter("@to",to)

            };
            return DAL.getuser("select * from tbl_purchases where product_name like @productname + '%' and  purchase_date between @from and @to", parm);
        }
        public DataTable getpurchasebycategorybyDate(string category_name, DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@category_name",category_name),
              new SqlParameter("@from",from),
                new SqlParameter("@to",to)
            };
            return DAL.getuser("select * from tbl_purchases where category_name like @category_name + '%' and  purchase_date between @from and @to ", parm);
        }

        public DataTable getpurchasebycategorybyInvoices(string invoice, DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@invoice",invoice),
              new SqlParameter("@from",from),
                new SqlParameter("@to",to)
            };
            return DAL.getuser("select * from tbl_purchases where invoice_no like @invoice + '%' and  purchase_date between @from and @to ", parm);
        }
        public DataTable getpurchasebydate( DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
            
              new SqlParameter("@from",from),
                new SqlParameter("@to",to)
            };
            return DAL.getuser("select * from tbl_purchases where purchase_date between @from and @to ", parm);
        }
        public DataTable getpurchasebypurchase(string payment_type,DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@payment_type",payment_type),
              new SqlParameter("@from",from),
                new SqlParameter("@to",to)
            };
            return DAL.getuser("select * from tbl_purchases where payment_type=@payment_type and purchase_date between @from and @to ", parm);
        }
        public DataTable getpurchasebysupplier(string supplier_name, DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@supplier_name",supplier_name),
              new SqlParameter("@from",from),
                new SqlParameter("@to",to)
            };
            return DAL.getuser("select * from tbl_purchases where supplier_name=@supplier_name and purchase_date between @from and @to ", parm);
        }
        public DataTable QuantitySum()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select sum(qty),sum(grand_total) from tbl_purchase", null);
            return dt;
        }
        public DataTable GetCategorybyid(string category_name, DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@category_name",category_name),
              new SqlParameter("@from",from),
                new SqlParameter("@to",to)
            };
            return DAL.getuser("select c.category_name,p.bill_no,p.invoice_no,s.product_name,p.qty,p.price,p.discount,p.grand_total,p.tax,p.supplier_name ,p.purchase_date,p.expiry_date from tbl_purchase p inner join tbl_categorys c on p.category_id=c.category_id inner join tbl_stock_products s on p.product_id=s.product_id where c.category_name=@category_name and cast(purchase_date as date) between @from and @to ", parm);
        }

        public DataTable GetProductbyid(string product_name, DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@product_name",product_name),
              new SqlParameter("@from",from),
                new SqlParameter("@to",to)
            };
            return DAL.getuser("select c.category_name,s.product_name,p.qty,p.bill_no,p.invoice_no,p.price,p.discount,p.grand_total,p.tax,p.supplier_name ,p.purchase_date,p.expiry_date from tbl_purchase p inner join tbl_categorys c on p.category_id=c.category_id inner join tbl_stock_products s on p.product_id=s.product_id where s.product_name=@product_name and cast(purchase_date as date) between @from and @to", parm);
        }
        public DataTable GetAll(DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@from",from),
                new SqlParameter("@to",to)
            };
            return DAL.getuser("select c.category_name,s.product_name,p.bill_no,p.invoice_no,p.qty,p.price,p.discount,p.grand_total,p.tax,p.supplier_name ,p.purchase_date,p.expiry_date from tbl_purchase p inner join tbl_categorys c on p.category_id=c.category_id inner join tbl_stock_products s on p.product_id=s.product_id where cast(purchase_date as date) between @from and @to", parm);
        }
        public DataTable GetGrandTotalbyCategory(string category_name, DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@category_name",category_name),
              new SqlParameter("@from",from),
                new SqlParameter("@to",to)
            };
            return DAL.getuser("select distinct(bill_no),grand_total from tbl_purchase p inner join tbl_categorys c on p.category_id=c.category_id where category_name=@category_name and cast(purchase_date as date) between @from and @to ", parm);
        }
        public DataTable GetGrandTotalbyProduct(string product_name, DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@product_name",product_name),
              new SqlParameter("@from",from),
                new SqlParameter("@to",to)
            };
            return DAL.getuser("select distinct(bill_no),grand_total from tbl_purchase p inner join tbl_stock_products s on p.product_id=s.product_id where product_name=@product_name and cast(purchase_date as date) between @from and @to ", parm);
        }
        public DataTable GetGrandTotalbyAll(DateTime from, DateTime to)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
              new SqlParameter("@from",from),
                new SqlParameter("@to",to)
            };
            return DAL.getuser("select distinct(bill_no),grand_total from tbl_purchase where cast(purchase_date as date) between @from and @to ", parm);
        }
        public int createpurchasepay(int supplier_id, decimal total_purchase, decimal purchase_pay, decimal remaining, string status, DateTime pay_date)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
       new SqlParameter("@supplier_id",supplier_id),
       new SqlParameter("@total_purchase",total_purchase),
       new SqlParameter("@purchase_pay",purchase_pay),
       new SqlParameter("@remaining",remaining),
       new SqlParameter("@status",status),
       new SqlParameter("@pay_date",pay_date),
            };
            return DAL.IDU("insert into tbl_pay_purchase (supplier_id,total_purchase,purchase_pay,remaining,status,pay_date) values(@supplier_id,@total_purchase,@purchase_pay,@remaining,@status,@pay_date)", parm);
        }
        public int CreateTransactionPurchase(int category_id, string category_name, DateTime date, string description, decimal amount, string fiscal_year, string paymentmode)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
       new SqlParameter("@category_id",category_id),
       new SqlParameter("@category_name",category_name),
       new SqlParameter("@date",date),
       new SqlParameter("@description",description),
       new SqlParameter("@amount",amount),
       new SqlParameter("@fiscal_year",fiscal_year),
         new SqlParameter("@paymentmode",paymentmode),
            };
            return DAL.IDU("insert into acc_transactions (category_id,category_name,date,description,amount,fiscal_year,paymentmode) values(@category_id,@category_name,@date,@description,@amount,@fiscal_year,@paymentmode)", parm);
        }

        public DataTable GetTransactionCategory()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from account_category where category_name='Inventory Pay'", null);
            return dt;
        }
        public DataTable GetSupplierDetails()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select supplier_name,sum(distinct grand_total) as grand_total from tbl_purchase where status is null group by supplier_name", null);
            return dt;
        }
        public int DeletePurchase(int purchase_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@purchase_id",purchase_id)
            };
            return DAL.IDU("Delete from tbl_purchase where purchase_id = @purchase_id", parm);
        }
        public int UpdatePurchase(string supplier_name)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@supplier_name",supplier_name)
            };
            return DAL.IDU("Update tbl_purchase set status='Paid' where supplier_name = @supplier_name", parm);
        }
        public int UpdatePurchaseGrandtotal(string supplier_name, string bill_no, decimal grand_total)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@supplier_name",supplier_name),
             new SqlParameter("@bill_no",bill_no),
             new SqlParameter("@grand_total",grand_total)
            };
            return DAL.IDU("Update tbl_purchase set grand_total=@grand_total where supplier_name = @supplier_name and bill_no=@bill_no", parm);
        }
        public DataTable GetSuupplierPurchase(string supplier_name)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@supplier_name",supplier_name),

            };
            return DAL.getuser("select purchase_id,supplier_name,category_name,product_name,grand_total,bill_no,purchase_date from tbl_purchase p inner join tbl_stock_products sp on p.product_id=sp.product_id inner join tbl_categorys c on c.category_id=p.category_id where supplier_name=@supplier_name", parm);
        }
        public DataTable Getsupplier(string supplier_name)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@supplier_name",supplier_name)
            };
            return DAL.getuser("select * from tbl_supplier_details where name = @supplier_name", parm);
        }
        public DataTable GetPurchaseRemain(int supplier_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@supplier_id",supplier_id)
            };
            return DAL.getuser("SELECT TOP 1 * FROM tbl_pay_purchase where supplier_id=@supplier_id ORDER BY remaining asc", parm);
        }
        public DataTable SumPayment(int supplier_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@supplier_id",supplier_id)
            };
            return DAL.getuser("select sum(purchase_pay) as purcharse_pay from tbl_pay_purchase where supplier_id=@supplier_id", parm);
        }
        public DataTable GetReturnPurchase(string supplier_name, string bill_no)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@supplier_name",supplier_name),
              new SqlParameter("@bill_no",bill_no),

            };
            return DAL.getuser("select * from tbl_purchase p inner join tbl_categorys c on p.category_id=c.category_id inner join tbl_stock_products s on p.product_id=s.product_id where bill_no=@bill_no and supplier_name=@supplier_name", parm);
        }
        public DataTable GetViewPayment(int supplier_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@supplier_id",supplier_id)
            };
            return DAL.getuser("select * from tbl_pay_purchase where supplier_id = @supplier_id", parm);
        }
        public int DeletePayment(int supplier_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@supplier_id",supplier_id)
            };
            return DAL.IDU("Delete from tbl_pay_purchase where supplier_id = @supplier_id", parm);
        }
        public DataTable GetSupplierPay(int supplier_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
             new SqlParameter("@supplier_id",supplier_id)
            };
            return DAL.getuser("select sum(purchase_pay) as purchase_pay from tbl_pay_purchase where supplier_id = @supplier_id", parm);
        }
        public DataTable GetTransactioncashdrop()
        {
            DataTable dt = new DataTable();
            dt = DAL.getuser("select * from account_category where category_name='Cash Settlement'", null);
            return dt;
        }
    }
}
