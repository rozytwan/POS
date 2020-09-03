using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.IIT
{
    class BillViewModel
    {
        public class BillModel
        {
            public string username { get; set; }
            public string password { get; set; }
            public string buyer_pan { get; set; }
            public string fiscal_year { get; set; }
            public string buyer_name { get; set; }
            public string invoice_number { get; set; }
            public string invoice_date { get; set; }

        }
    }
}
