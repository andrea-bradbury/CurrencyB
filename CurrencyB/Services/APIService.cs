using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CurrencyB.Services
{
    public class APIService
    {
        
        string apiKey = "684f4eae3418819feab5f4f575fe13d4";

            
        HttpClient client = new HttpClient();


        public async Task<double> GetCurrencyConvertor()
        {
             HttpResponseMessage response = await client.GetAsync($"http://api.exchangeratesapi.io/v1/latest?access_key={apiKey}&symbols=USD,AUD,CAD,PLN,MXN&format=1");


             if (response.StatusCode == System.Net.HttpStatusCode.OK)
             {
                string  content = await response.Content.ReadAsStringAsync();

                JObject main = JsonConvert.DeserializeObject<JObject>(content);

                main = (JObject)main.GetValue("rates");

                double conversionRate = (double)main.GetValue("rates");

                return conversionRate;
             }

             return 0;
        }
        
    }
}
