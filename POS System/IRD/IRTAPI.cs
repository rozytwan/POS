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
   public class IRTAPI
    {
        BLLUser blu = new BLLUser();
        BLL_Fiscal blfsc = new BLL_Fiscal();
        string pan_no="";
       
        public int posBilling(string buyer_pan,string buyer_name,string invoice_number,string invoice_date,double total_sales,double taxable_sales_vat,double vat,bool realtime,string fiscal_year,string user_name,string password)
        {
            DataTable dtm = blu.checkbusiness();
            if (dtm.Rows.Count > 0)
            {
                pan_no = dtm.Rows[0]["pan_no"].ToString();
            }
           
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                BillModel blm = new BillModel()
                {
                    username = user_name,
                    password = password,
                    seller_pan = pan_no,
                    buyer_pan = buyer_pan,                
                    buyer_name = buyer_name,
                    fiscal_year = fiscal_year,
                    invoice_number = invoice_number,
                    invoice_date = invoice_date,
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
                    datetimeClient = DateTime.Now
                };
             
                var stringContent = new StringContent(JsonConvert.SerializeObject(blm), Encoding.UTF8, "application/json");
                client.BaseAddress = new Uri("http://103.1.92.174:9050");
                
                //  var response = client.PostAsync("api/AgentCollection", new StringContent( new JavaScriptSerializer().Serialize(blm), Encoding.UTF8, "application/json")).Result;
                var response = client.PostAsync("api/bill", stringContent).Result;
               // var response = client.PostAsJsonAsync("api/bill", blm).Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync();
                     Console.WriteLine(result.Result);
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

