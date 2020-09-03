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
    public class BLLPrinterSetting
    {
        public DataTable getalldata()
        {
            return DAL.getuser("select * from tbl_printer",null);
        }
        public DataTable getallPrintingTimes()
        {
            return DAL.getuser("select * from tbl_printing_times", null);
        }
        public int updateprintingTimes(string k1, string k2, string BOT)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@k1",k1),
                new SqlParameter("@k2",k2),
                new SqlParameter("@BOT",BOT)
            };
            return DAL.IDU("update tbl_printing_times set k1=@k1,k2=@k2,BOT=@BOT", parm);
        }
        public int updateprintingTimes(string B1)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@B1",B1),
                
            };
            return DAL.IDU("update tbl_printing_times set B1=@B1", parm);
        }
        public int insertPrintingTimes(string k1, string k2, string BOT)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@k1",k1),
                new SqlParameter("@k2",k2),
                new SqlParameter("@BOT",BOT)
            };
            return DAL.IDU("insert into  tbl_printing_times (k1,k2,bot) values (@k1,@k2,@BOT)", parm);
        }
        public int insertPrintingTimes(string B1)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@B1",B1),
               
            };
            return DAL.IDU("insert into  tbl_printing_times (B1) values (@B1)", parm);
        }


        public int InsertQuotation(string table_no, decimal receive_amount, string username, DateTime date_of_sales)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@table_no",table_no),
                new SqlParameter("@receive_amount",receive_amount),
                new SqlParameter("@username",username),
                 new SqlParameter("@date_of_sales",date_of_sales),

            };
            return DAL.IDU("insert into tbl_quotation (table_no,received_amount,username,date_of_sales) values (@table_no,@receive_amount,@username,@date_of_sales)", parm);
        }
        public DataTable GetAllQuotationByTableNO(string table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@table_no",table_no),

            };
            return DAL.getuser("select * from tbl_quotation where table_no=@table_no", parm);
        }
        public int DeleteQuotation(string table_no)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@table_no",table_no),

            };
            return DAL.IDU("delete from tbl_quotation where table_no=@table_no", parm);
        }
        public int UpdatePrinter(string bill)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@bill",bill),

            };
            return DAL.IDU("update tbl_printer set bill_printer=@bill", parm);
        }
        public int UpdateKotPrinter(string kot)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@kot",kot),

            };
            return DAL.IDU("update tbl_printer set kot_printer=@kot", parm);
        }

    }
}
