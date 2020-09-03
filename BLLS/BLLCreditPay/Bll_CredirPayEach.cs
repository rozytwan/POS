using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DOA;

namespace BLLS.creditPay
{
  public  class Bll_CredirPayEach
    {
        public int inserintotb(int cusid, decimal creditAmt, DateTime dates, string checkedby, int noOfItemsChecked,string itemList)
        {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@cusid",cusid),
                new SqlParameter("@creditAmt",creditAmt),
                new SqlParameter("@dates",dates),
                new SqlParameter("@checkedby",checkedby),
                new SqlParameter("@noOfItemsChecked",noOfItemsChecked),
                new SqlParameter("@itemList",itemList)
            };
            return DAL.IDU("insert into tbl_UserCreditamt values(@cusid,@creditAmt,@dates,@checkedby,@noOfItemsChecked,@itemList)", parm);

        }
        public DataTable getallTbbyId(string id) {
            SqlParameter[] parm = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            return DAL.getuser("select *from tbl_UserCreditamt where cus_id = @id",parm);
        }

    }
}
