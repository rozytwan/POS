using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace POS_System.FonePayApi
{
    public class FonePayApi
    {
        public string posFonePay(string pamount, string premarks1, string premarks2, string pprn, string pmerchantCode, string pdataValidation, string pusername, string ppassword)
        {

            //ServicePointManager.Expect100Continue = true;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://merchantapi.fonepay.com/api/merchant/merchantDetailsForThirdParty/thirdPartyDynamicQrDownload");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";


            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = new JavaScriptSerializer().Serialize(new
                {
                    amount = pamount,
                    remarks1 = premarks1,
                    remarks2 = premarks2,
                    prn = pprn,
                    merchantCode = pmerchantCode,
                    dataValidation = pdataValidation,
                    username = pusername,
                    password = ppassword


                });
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = streamReader.ReadLine();
                return result;

            }

        }
        private static HttpClient _httpClient = new HttpClient();
        public string posFonePayTest(string pamount, string premarks1, string premarks2, string pprn, string pmerchantCode, string pdataValidation, string pusername, string ppassword)
        {
            string json;
            string url = "https://merchantapi.fonepay.com/api/merchant/merchantDetailsForThirdParty/thirdPartyDynamicQrDownload";

            json = new JavaScriptSerializer().Serialize(new
            {
                amount = pamount,
                remarks1 = premarks1,
                remarks2 = premarks2,
                prn = pprn,
                merchantCode = pmerchantCode,
                dataValidation = pdataValidation,
                username = pusername,
                password = ppassword


            });
            var content = new StringContent(
             json,
             System.Text.Encoding.UTF8,
             "application/json"
             );
            using (var contents = new StringContent(json, System.Text.Encoding.UTF8, "application/json"))
            {
                HttpResponseMessage result = _httpClient.PostAsync(url, contents).Result;
                if (result.StatusCode == System.Net.HttpStatusCode.Created)
                    return "true";
                string returnValue = result.Content.ReadAsStringAsync().Result;
                throw new Exception($"Failed to POST data: ({result.StatusCode}): {returnValue}");
            }
        }

        public string FonepayApiTest2(string pamount, string premarks1, string premarks2, string pprn, string pmerchantCode, string pdataValidation, string pusername, string ppassword)
        {
          

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string json;
                    string url = "https://merchantapi.fonepay.com/api/merchant/merchantDetailsForThirdParty/thirdPartyDynamicQrDownload";

                    json = new JavaScriptSerializer().Serialize(new
                    {
                        amount = pamount,
                        remarks1 = premarks1,
                        remarks2 = premarks2,
                        prn = pprn,
                        merchantCode = pmerchantCode,
                        dataValidation = pdataValidation,
                        username = pusername,
                        password = ppassword


                    });
                    var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                    client.BaseAddress = new Uri(url);

                    //  var response = client.PostAsync("api/AgentCollection", new StringContent( new JavaScriptSerializer().Serialize(blm), Encoding.UTF8, "application/json")).Result;
                    var response = client.PostAsJsonAsync("application/json", stringContent).Result;
                    // var response = client.PostAsJsonAsync("api/bill", blm).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync();
                        Console.WriteLine(result.Result);
                        Console.ReadLine();
                        return result.Result;
                    }
                    return null;
                }
            

          
        }
    }
        
}

    


