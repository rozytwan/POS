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
  public class BLLTrialBalance
    {
        public int insertintoTrial(int sn, string account_head,int lf, string debit,string credit) {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@sn",sn),
                new SqlParameter("@account_head",account_head),
                new SqlParameter("@lf",lf),
                new SqlParameter("@debit",debit),
                new SqlParameter("@credit",credit)

            };
            return  DAL.IDU("insert into tbl_trialBalance(sn,account_head,lf,debit,credit) values (@sn,@account_head,@lf,@debit,@credit)", parm);
           


        }
       public  DataTable getallTrialAcname(string ac_name)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@ac_name",ac_name)
            };
         
            return  DAL.getuser("select * from tbl_trialbalance where account_head=@ac_name",parm);

        }

        public int insertintoTrialcredit(string account_head,string credit,DateTime endofthemonth)
        {
            SqlParameter[] parm = new SqlParameter[] {
              
                new SqlParameter("@account_head",account_head),
                new SqlParameter("@credit",credit),
                 new SqlParameter("@endofthemonth",endofthemonth)

            };
            return  DAL.IDU("insert into tbl_trialBalance(account_head,credit,endofMonthDate) values (@account_head,@credit,@endofthemonth)", parm);
         
        }
        public int updateintoTrialcredit(string account_head, string credit, DateTime endofthemonth)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@account_head",account_head),
              new SqlParameter("@endofthemonth",endofthemonth),
                new SqlParameter("@credit",credit)

            };
         return  DAL.IDU("update tbl_trialBalance set account_head = @account_head,credit=@credit,endofMonthDate=@endofthemonth where endofMonthDate=@endofthemonth", parm);



        }


        public int insertintoTrialDebit( string account_head, string debit, DateTime endofthemonth)
        {
            SqlParameter[] parm = new SqlParameter[] {
               
                new SqlParameter("@account_head",account_head),
                new SqlParameter("@debit",debit),
                new SqlParameter("@endofthemonth",endofthemonth)
              

            };
           return  DAL.IDU("insert into tbl_trialBalance(account_head,debit,endofMonthDate) values (@account_head,@debit,@endofthemonth)", parm);
        }

        public int udpateintoTrialDebit(string account_head, string debit, DateTime endofthemonth)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@account_head",account_head),
                new SqlParameter("@debit",debit),
                 new SqlParameter("@endofthemonth",endofthemonth)


            };
            return  DAL.IDU("update tbl_trialBalance set account_head = @account_head,debit=@debit,endofMonthDate=@endofthemonth where  endofMonthDate=@endofthemonth", parm);

        }
        public DataTable getallTrials() {


            return  DAL.getuser("select * from tbl_trialBalance", null);
        }

        public DataTable getallTrialsAccordingtoDate(DateTime trialsDate)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@trialsDate",trialsDate)
            };


            return  DAL.getuser("select endofMonthDate from tbl_trialBalance where endofMonthDate=@trialsDate", parm);
        }
        public DataTable Checktheactypeonce(String actype)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@actype",actype)
            };


            return  DAL.getuser("select main_account_type from tbl_accounts_ledger where ac_type=@actype ", parm);
        }

      
        public DataTable truncatealldb() {
           return  DAL.getuser("truncate table tbl_trialBalance", null);

        }

    }

}
