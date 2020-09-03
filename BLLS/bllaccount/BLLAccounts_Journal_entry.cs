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
   public class BLLAccounts_Journal_entry
    {
        public int  InsertIntoTable(DateTime date,string account_name,string narration,decimal debit,decimal credit,string voucher_type, int trans_id){
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@date",date),
                new SqlParameter("@account_name",account_name),
               
                new SqlParameter("@narration",narration),
                new SqlParameter("@debit",debit),
                new SqlParameter("@credit",credit),
                new SqlParameter("@voucher_type",voucher_type),
                new SqlParameter("@trans_id",trans_id)
               

            };
            return  DAL.IDU("insert into tbl_account_journal_entry values(@date,@account_name,@narration,@debit,@credit,@voucher_type,@trans_id)", parm);
            
            
            }

        public DataTable showalldata() {
           // return  DAL.getuser("select  voucher_type as VoucherType, date as DateOfEntry , dr_cr as DrCr ,account_name as AccountName, amount as Amount , narration as Narration, debit as Debit , credit as Credit from tbl_account_journal_entry", null);
            return  DAL.getuser("select * from  tbl_account_journal_entry",null);
        }
        public int deleteDataById(string id)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            return  DAL.IDU("Delete from tbl_account_journal_entry where trans_id=@id ", parm);

        }

        public DataTable getallDataById(string id)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            return  DAL.getuser("select * from tbl_account_journal_entry where trans_id=@id ", parm);

        }

        public DataTable showalldataINC()
        {
            // return  DAL.getuser("select  voucher_type as VoucherType, date as DateOfEntry , dr_cr as DrCr ,account_name as AccountName, amount as Amount , narration as Narration, debit as Debit , credit as Credit from tbl_account_journal_entry", null);
            return  DAL.getuser("select * from  tbl_account_journal_entry order by trans_id DESC", null);
        }
        //SELECT ac_type, COUNT(*)FROM tbl_accounts_ledger GROUP BY ac_type HAVING COUNT(*) > 0
        public DataTable showallatCombo()
        {
            return  DAL.getuser("SELECT account_name, COUNT(*)FROM tbl_account_journal_entry GROUP BY account_name HAVING COUNT(*) > 0", null);
        }
        public DataTable showOnlyoneTransId() {
            return  DAL.getuser("SELECT trans_id, COUNT(*) as 'count' FROM tbl_account_journal_entry GROUP BY trans_id HAVING COUNT(*) > 0", null);

        }
        public DataTable showjournalbyVourchertype(string vouchertype)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@vouchertype",vouchertype)

            };
            return  DAL.getuser("select * from  tbl_account_journal_entry where account_name=@vouchertype", parm);
        }

    }
}
