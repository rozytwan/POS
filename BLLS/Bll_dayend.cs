using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOA;
using System.Data;
using System.Data.SqlClient;

namespace BLLS
{
   public  class Bll_dayend
    {
        public int insertintdailyend(string endby, string openingbalc, string subtotal, string totalCashsales, string totalcardsales, string clubcardsales, string totalCareo, string totalcashincounter, decimal discount, decimal service_charge, decimal tax, decimal grand_total, decimal credit, decimal credit_paid, decimal counting_cash, decimal excess_shortage, decimal cash_settlement, decimal closing_blc, string status, DateTime date, string shift_change, string total_cancel, string total_order, decimal comp_amount)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@endby",endby),
                new SqlParameter("@openingbalc",openingbalc),
                new SqlParameter("@subtotal",subtotal),
                new SqlParameter("@totalCashsales",totalCashsales),
                new SqlParameter("@totalcardsales",totalcardsales),
                new SqlParameter("@clubcardsales",clubcardsales),
                new SqlParameter("@totalCareo",totalCareo),
                new SqlParameter("@totalcashincounter",totalcashincounter),
                new SqlParameter("@discount",discount),
                new SqlParameter("@service_charge",service_charge),
                new SqlParameter("@tax",tax),
                new SqlParameter("@grand_total",grand_total),
                new SqlParameter("@credit",credit),
                new SqlParameter("@credit_paid",credit_paid),
                new SqlParameter("@counting_cash",counting_cash),
                new SqlParameter("@excess_shortage",excess_shortage),
                new SqlParameter("@cash_settlement",cash_settlement),
                new SqlParameter("@closing_blc",closing_blc),
                new SqlParameter("@status",status),
                new SqlParameter("@date",date),
                new SqlParameter("@shift_change",shift_change),
                new SqlParameter("@total_cancel",total_cancel),
                new SqlParameter("@total_order",total_order),
                new SqlParameter("@comp_amount",comp_amount)
            };
            return DAL.IDU("insert into tbl_dailyend (endby,openingbalc,subtotal,totalCashsales,totalcardsales,club_card_sales,totalCareof,totalcashincounter,discount,service_charge,tax,grand_total,credit,credit_paid,counting_cash,excess_shortage,cash_sattlement,closing_blc,status,date,shift_change,total_cancel,total_order,comp_amount) values(@endby,@openingbalc,@subtotal,@totalCashsales,@totalcardsales,@clubcardsales,@totalCareo,@totalcashincounter,@discount,@service_charge,@tax,@grand_total,@credit,@credit_paid,@counting_cash,@excess_shortage,@cash_settlement,@closing_blc,@status,@date,@shift_change,@total_cancel,@total_order,@comp_amount)", parm);
        }
        public DataTable getallDailyreports() {

            return DAL.getuser("select * from tbl_dailyend",null);

        }


        public DataTable SearchDayEndByDate(DateTime date)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@date",date)
            };
            return DAL.getuser("select sum(cast(subtotal as decimal(18,2))),sum(discount),sum(tax),sum(service_charge),sum(grand_total),sum(cast(totalcashsales as decimal(18,2))),sum(cast(totalcardsales as decimal(18,2))),sum(credit),sum(cast(totalCashinCounter as decimal(18,2))),sum(counting_cash),sum(cash_sattlement),sum(excess_shortage),sum(closing_blc), sum(cast(openingbalc as decimal(18,2))),sum(cast(totalCareof as decimal(18,2))),sum(credit_paid) from tbl_dailyend where cast(date as date)=@date", parm);
        }
        public DataTable SearchByDate(DateTime date)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@date",date)
            };
            return DAL.getuser("select * from tbl_dailyend where cast(date as date)=@date", parm);
        }
        public DataTable DayendbyId(int id)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@id",id)
            };
            return DAL.getuser("select * from tbl_dailyend where id=@id", parm);
        }

        public DataTable SearchByDateDetail(DateTime date, DateTime date2)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@date",date),
                new SqlParameter("@date2",date2)
            };
            return DAL.getuser("select * from tbl_dailyend where cast(date as date) between @date and @date2", parm);
        }

    }
}
