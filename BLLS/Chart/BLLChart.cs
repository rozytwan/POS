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
    public class BLLChart
    {
        public DataTable getallDataByPastweek(DateTime startDatetime, DateTime runningdatetime)
        {
            SqlParameter[] parm = new SqlParameter[]
                 {
                     new SqlParameter("@startdateTime",startDatetime),
                     new SqlParameter("@runningdatetime",runningdatetime)
                 };
            return DAL.getuser("SELECT * FROM ViewHourlySales(@startdateTime,@runningdatetime);", parm);
        }
        public DataTable getallDataByPastweekQty(DateTime startDatetime, DateTime runningdatetime)
        {
            SqlParameter[] parm = new SqlParameter[]
                 {
                     new SqlParameter("@startdateTime",startDatetime),
                     new SqlParameter("@runningdatetime",runningdatetime)
                 };
            return DAL.getuser("SELECT * FROM fnSalesQtySumPerHours(@startdateTime,@runningdatetime);", parm);
        }

        public DataTable getAllTable()
        {
            return DAL.getuser("select count(rest_table_no) from tbl_rest_table",null);
        }
        public DataTable getAllbusytableTable()
        {
            return DAL.getuser("select count(distinct(table_no)) from tbl_orders", null);
        }
    }
}
