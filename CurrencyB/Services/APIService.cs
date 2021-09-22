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


        public Models.CurrencyConvert main = new Models.CurrencyConvert();



        public async Task<bool> GetCurrencyConvertor()
        {


            HttpClient client = new HttpClient();

            try
            {
                HttpResponseMessage response = await client.GetAsync($"http://api.exchangeratesapi.io/v1/latest?access_key=684f4eae3418819feab5f4f575fe13d4&symbols=USD,AUD,CAD,PLN,MXN,EUR&format=1");


                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {

                    return false;

                }
                else
                {
                    string content = await response.Content.ReadAsStringAsync();

                    main = JsonConvert.DeserializeObject<Models.CurrencyConvert>(content);


                    return true;

                }

            }
            catch
            {
                return false;
            }



            



        }

    }
}
