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
 public  class BLLUserLevelDiscount
    {
        public DataTable getByDiscountUserLevel(string card_type,decimal total_amount)
        {
            SqlParameter[] parm = new SqlParameter[] {

                new SqlParameter("@card_type",card_type),
                 new SqlParameter("@total_amount",total_amount)
            };
            return DAL.getuser("select * from tbl_user_level_discount where card_type=@card_type and @total_amount between   dis_from and dis_to;", parm);
        }
        public DataTable GetUser()
        {
            return DAL.getuser("Select * from tbl_user_level_discount", null);
        }
        public int insert_user_discount(string card_type, decimal discount_from, decimal discount_to, string discount_percent)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                 new SqlParameter("@card_type",card_type),
                  new SqlParameter("@discount_from",discount_from),
                    new SqlParameter("@discount_to",discount_to),
                    new SqlParameter("@discount_percent",discount_percent),
              };
            return DAL.IDU("insert into tbl_user_level_discount (card_type,dis_from,dis_to,discount_percent) values(@card_type,@discount_from,@discount_to,@discount_percent)", parm);
        }
        public int Update_user_discount(string card_type, decimal discount_from, decimal discount_to, string discount_percent, int user_dis_id)
        {
            SqlParameter[] parm = new SqlParameter[]
                {
                 new SqlParameter("@card_type",card_type),
                  new SqlParameter("@discount_from",discount_from),
                    new SqlParameter("@discount_to",discount_to),
                    new SqlParameter("@discount_percent",discount_percent),
                     new SqlParameter("@user_dis_id",user_dis_id)
              };
            return DAL.IDU("update tbl_user_level_discount set card_type=@card_type,dis_from=@discount_from,dis_to=@discount_to,discount_percent=@discount_percent where user_dis_id=@user_dis_id", parm);
        }
        public DataTable Getuserbyid(int user_dis_id)
        {
            SqlParameter[] parm = new SqlParameter[]
            {
                new SqlParameter("@users_dis_id", user_dis_id)
            };
            return DAL.getuser("Select * from tbl_user_level_discount where user_dis_id = @users_dis_id", parm);
        }

    }
}

