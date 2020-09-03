using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Data;
using BLLS;

namespace POS_System.IRT
{
   public class IRDSalesReturnAPI
    {
        BLLUser blu = new BLLUser();
        BLL_Fiscal blfsc = new BLL_Fiscal();
        string pan_no = "";
        string fiscal_year = "";
        public int salesReturnAPI(string buyer_pan, string buyer_name, string ref_invoice_number, string credit_note_number, string credit_note_date, string reason_for_return, double total_sales, double taxable_sales_vat, double vat, bool realtime)
        {
            DataTable dtm = blu.checkbusiness();
            if (dtm.Rows.Count > 0)
            {
                pan_no = dtm.Rows[0]["pan_no"].ToString();
            }
            DataTable dt = blfsc.get_all_data_from_fiscal("True");
            if (dt.Rows.Count > 0)
            {
                fiscal_year = dt.Rows[0]["fiscal_year"].ToString();
            }
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                IRDSalesReturnModel isr = new IRDSalesReturnModel
                {
                    username = "Test_CBMS",
                    password = "test@321",
                    seller_pan = pan_no,
                    buyer_name = buyer_name,
                    buyer_pan = buyer_pan,
                    fiscal_year = fiscal_year,
                    ref_invoice_number = ref_invoice_number,
                    credit_note_date = credit_note_date,
                    credit_note_number = credit_note_number,
                    reason_for_return = reason_for_return,
                    total_sales = total_sales,
                    taxable_sales_vat = taxable_sales_vat,
                    vat = vat,
                    excisable_amount = 0,
                    excise = 0,
                    taxable_sales_hst = 0,
                    hst = 0,
                    amount_for_esf = 0,
                    esf = 0,
                    export_sales = 0,
                    tax_exempted_sales = 0,
                    isrealtime = realtime,
                    datetimeclient = DateTime.Now


                };
                var stringContent = new StringContent(JsonConvert.SerializeObject(isr), Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri("http://103.1.92.174:9050");
                var response = client.PostAsync("api/billreturn", stringContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync();
                    Console.Write(result.Result);
                    Console.ReadLine();
                    return result.Result.Count();
                }
                else
                {
                    return 0;
                }

            }
        }
    }
}
