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
   public class Bll_Trading
    {

        public DataTable ChecktheAccountsforPlBlTD(string actype)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@actype",actype)
            };


            return  DAL.getuser("select * from tbl_accounting_accounttype where name=@actype ", parm);
        }

        public DataTable getallfromTradingTable() {
            return  DAL.getuser("select * from tbl_trading",null);

        }

        public DataTable getallIDTradingTable()
        {
            return  DAL.getuser("select trading_sn from tbl_trading", null);

        }

        public int insertintoTrading(decimal Gprofit,decimal Gloss) {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@Gprofit",Gprofit),
                new SqlParameter("@Gloss",Gloss),

            };
            return  DAL.IDU("insert into  tbl_trading(gross_profit,gross_loss) values(@Gprofit,@Gloss)", parm);

                
        }

        public int  updatentoTrading(decimal Gprofit,decimal Gloss,int pid)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@Gprofit",Gprofit),
                new SqlParameter("@Gloss",Gloss),
                new SqlParameter("@pid",pid)

            };
            return  DAL.IDU("update tbl_trading set gross_profit=@Gprofit,gross_loss=@Gloss where trading_sn=@pid", parm);


        }
    }
}
