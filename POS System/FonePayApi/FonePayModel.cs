using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System.FonePayApi
{
    public  class FonePayModel
    {
        public string amount { get; set; }
        public string remarks1 { get; set; }
        public string remarks2 { get; set; }
        public string prn { get; set; }
        public string merchantCode { get; set; }
        public string dataValidation { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string taxAmount { get; set; }
        public string taxRefund { get; set; }
    }
}
