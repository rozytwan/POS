using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DOA;

namespace BLLS
{
     public class Bll_allJournal_Lists
    {
       public  int insertintoals_alljournals( string account_name, string narration, decimal amount, int trans_id, DateTime date) {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@account_name",account_name),
                new SqlParameter("@narration",narration),
                new SqlParameter("@amount",amount),
                new SqlParameter("@trans_id",trans_id),
                new SqlParameter("@date",date)

            };
            return  DAL.IDU("insert into tbl_account_alljournalLists values(@account_name,@narration,@amount,@trans_id,@date)", parm);


        }
        public DataTable showalljournalsheaders()
        {
            return DAL.getuser("select * from tbl_account_alljournalLists ", null);

        }

        public int deleteDataById(string id)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            return  DAL.IDU("Delete from tbl_account_alljournalLists where trans_id=@id ", parm); 
  
        }
        public DataTable getallDataById(string id)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            return DAL.getuser("select * from tbl_account_alljournalLists where trans_id=@id ", parm);

        }

        public DataTable showalljournalsheadersOnSearch(string voucher_type)
        {
            SqlParameter[] meter = new SqlParameter[] {
                new SqlParameter("@voucher_type",voucher_type)

            }; return DAL.getuser("select * from tbl_account_alljournalLists  where account_name=@voucher_type", meter);

        }


        public DataTable getalldataByTransID(int trans_id)
        {
            SqlParameter[] meter = new SqlParameter[] {
                new SqlParameter("@trans_id",trans_id)

            }; return DAL.getuser("select * from tbl_account_journal_entry  where trans_id=@trans_id", meter);

        }



    }
}
