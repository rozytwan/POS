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
    public class BllLedger_entry
    {
        public int insertledgerdebit(DateTime date, string description, decimal debit, decimal credit, string voucher_type, string ac_type, string main_account_type, int invoice_no,string narration)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@date",date),
                new SqlParameter("@description",description),
                new SqlParameter("@debit",debit),

                new SqlParameter("@voucher_type",voucher_type),
                new SqlParameter("@ac_type",ac_type),
                new SqlParameter("@main_account_type",main_account_type),
                                new SqlParameter("@invoice_no",invoice_no),
                                new SqlParameter("@credit",credit),
                                new SqlParameter("@narration",narration)



            };

            return DAL.IDU("insert into tbl_accounts_ledger(date,description,debit,credit,voucher_type,ac_type,main_account_type,invoice_no,narration) values(@date,@description,@debit,@credit,@voucher_type,@ac_type,@main_account_type,@invoice_no,@narration)", parm);
        }
        public int insertledgercredit(DateTime date, string description, decimal debit, decimal credit, string voucher_type, string ac_type, string main_account_type, int invoice_no, string narration)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@date",date),
                new SqlParameter("@description",description),

                new SqlParameter("@credit",credit),

                new SqlParameter("@voucher_type",voucher_type),
                new SqlParameter("@ac_type",ac_type),
                 new SqlParameter("@main_account_type",main_account_type),
                 new SqlParameter("@invoice_no",invoice_no),
                 new SqlParameter("@debit",debit),
                  new SqlParameter("@narration",narration)

            };

            return DAL.IDU("insert into tbl_accounts_ledger(date,description,debit,credit,voucher_type,ac_type,main_account_type,invoice_no,narration) values(@date,@description,@debit,@credit,@voucher_type,@ac_type,@main_account_type,@invoice_no,@narration)", parm);
        }

        public DataTable showalldata(string vouchertype) {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@vouchertype",vouchertype)
            };
            return DAL.getuser("select * from tbl_accounts_ledger where voucher_type = @vouchertype", parm);

        }

        public int deleteDataById(string id)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            return DAL.IDU("Delete from tbl_accounts_ledger where invoice_no=@id ", parm);

        }
        public DataTable getallDataById(string id)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            return DAL.getuser("select * from tbl_accounts_ledger where invoice_no=@id ", parm);

        }

        public DataTable showAvailableledgerAconCbo() {
            return DAL.getuser("SELECT ac_type, COUNT(*)FROM tbl_accounts_ledger GROUP BY ac_type HAVING COUNT(*) > 0", null);
            //SELECT ac_type, COUNT(*)FROM tbl_accounts_ledger GROUP BY ac_type HAVING COUNT(*) > 1

        }
        public DataTable showAvailableledgerAconCboBetweenDates(DateTime date1, DateTime date2)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@date1",date1),
                new SqlParameter("@date2",date2)
            };
            return DAL.getuser("SELECT ac_type, COUNT(*)FROM tbl_accounts_ledger  where date >= @date1 and date <= @date2 GROUP BY ac_type HAVING COUNT(*) > 0 ", parm);
            
        }

        public DataTable loadledgersBetweenDates(DateTime date1, DateTime date2, string voucher_type) {
            SqlParameter[] parm = new SqlParameter[] {
                //new SqlParameter("@voucher_type",voucher_type),
                new SqlParameter("@date1",date1),
                new SqlParameter("@date2",date2),
                new SqlParameter("@voucher_type",voucher_type)


            };
            return DAL.getuser("select * from tbl_accounts_ledger where voucher_type=@voucher_type And date between @date1 and @date2", parm);


        }
        public DataTable loadledgersBetweenDatesforactypes(DateTime date1, DateTime date2, string voucher_type)
        {
            SqlParameter[] parm = new SqlParameter[] {
                //new SqlParameter("@voucher_type",voucher_type),
                new SqlParameter("@date1",date1),
                new SqlParameter("@date2",date2),
                new SqlParameter("@voucher_type",voucher_type)


            };
            return DAL.getuser("select * from tbl_accounts_ledger where ac_type=@voucher_type And date between @date1 and @date2", parm);


        }

        public DataTable loardtransIfForNarratino(string ac_type)
        {
            SqlParameter[] parm = new SqlParameter[] {
                //new SqlParameter("@voucher_type",voucher_type),
                
                new SqlParameter("@ac_type",ac_type)


            };
            return DAL.getuser("select account_name from tbl_account_journal_entry where ac_type=@ac_type", parm);


        }


        public DataTable sumupallCreditsfromledgers(DateTime date1, DateTime date2, string ac_type) {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@date1",date1),
                new SqlParameter("@date2",date2),
                new SqlParameter("@ac_type",ac_type)
                };
            return DAL.getuser("select  sum(credit)-sum(debit) AS CreditTotal from tbl_accounts_ledger where ac_type=@ac_type And date between @date1 and @date2", parm);
        }

        public DataTable sumupallDebitsfromledgers(DateTime date1, DateTime date2, string ac_type)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@date1",date1),
                new SqlParameter("@date2",date2),
                new SqlParameter("@ac_type",ac_type)
                };
            return DAL.getuser("select  sum(debit)-sum(credit) AS DebitTotal  from tbl_accounts_ledger where ac_type=@ac_type And date between @date1 and @date2", parm);
        }

        public DataTable sumupallDebitsfromledgersforTrading(string ac_type)
        {
            SqlParameter[] parm = new SqlParameter[] {


                new SqlParameter("@ac_type",ac_type)
                };
            return DAL.getuser("select  sum(debit)-sum(credit) AS DebitTotal  from tbl_accounts_ledger where ac_type=@ac_type", parm);
        }

        public DataTable sumupallDebitsfromledgersforTrading_betweenDates(string ac_type, DateTime date1, DateTime date2)
        {
            SqlParameter[] parm = new SqlParameter[] {


                new SqlParameter("@ac_type",ac_type),
                new SqlParameter("@date1",date1),
                new SqlParameter("@date2",date2)
                };
            return DAL.getuser("select  sum(debit)-sum(credit) AS DebitTotal  from tbl_accounts_ledger where ac_type=@ac_type and date between @date1 and @date2", parm);
        }

        public DataTable sumupallDebitsfromledgersforTradingbetweendates(string ac_type,DateTime to, DateTime from)
        {
            SqlParameter[] parm = new SqlParameter[] {


                new SqlParameter("@ac_type",ac_type),
                 new SqlParameter("@to",to),
                 new SqlParameter("@from",from)
                };
            return DAL.getuser("select  sum(debit)-sum(credit) AS DebitTotal  from tbl_accounts_ledger where ac_type=@ac_type and date between @from and @to", parm);
        }

        public DataTable getTotalCapitaltocheck() {
            return DAL.getuser("select  sum(debit)-sum(credit) AS TotalCapital  from tbl_accounts_ledger where ac_type='cash'", null);
        }

        public DataTable getTotalEXPenses()
        {
            return DAL.getuser("select sum(debit) as exptotal from tbl_accounts_ledger where main_account_type='Expenses/Losses' ", null);
        }
        public DataTable getTotalrevenues()
        {
            return DAL.getuser("select sum(credit) as revtotal from tbl_accounts_ledger where main_account_type='Revenue/Income/Gain'", null);
        }
        public DataTable sumupallCreditsfromledgersforTrading(string ac_type)
        {
            SqlParameter[] parm = new SqlParameter[] {

             
                new SqlParameter("@ac_type",ac_type)
                };
            return DAL.getuser("select  sum(credit)-sum(debit) AS CreditTotal from tbl_accounts_ledger where ac_type=@ac_type", parm);
        }

        public DataTable sumupallCreditsfromledgersforTrading_betweenDates(string ac_type, DateTime date1, DateTime date2)
        {
            SqlParameter[] parm = new SqlParameter[] {


                new SqlParameter("@ac_type",ac_type),
                new SqlParameter("@date1",date1),
                new SqlParameter("@date2",date2)
                };
            return DAL.getuser("select  sum(credit)-sum(debit) AS CreditTotal from tbl_accounts_ledger where ac_type=@ac_type and date between @date1 and @date2", parm);
        }
    }
}
