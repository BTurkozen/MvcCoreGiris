using MvcCoreGiris.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MvcCoreGiris.Services
{
    // c# call api : https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
    // json deserialize as dynamic (.net framework): https://stackoverflow.com/questions/3142495/deserialize-json-into-c-sharp-dynamic-object
    // json deserialize as dynamic (.net core): https://dotnetcoretutorials.com/2019/09/11/how-to-parse-json-in-net-core/ 
    public class OpenWeatherMapService : IWeatherService
    {
        static HttpClient client = new HttpClient();
        public decimal Temperature(string cityName)
        {
            var url =
                $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&appid=9d23df4b85b3b06819afdfeadee8a4f7&lang=tr&units=metric";

            HttpResponseMessage response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                dynamic data = JToken.Parse(json);

                return data.main.temp;
            }
            throw new Exception(" İştenilen değerlere ulaşılamamıştır, Daha sonra tekrar deneyiniz!!");
        }
    }
}
