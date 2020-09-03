using DOA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLS
{
   public  class BLLBusinessDyanmic
    {
        public DataTable selectAllData()
        {
            return DAL.getuser("select * from tbl_business_dyanmic", null);
        }
    }
}
