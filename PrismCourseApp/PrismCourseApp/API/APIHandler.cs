using Newtonsoft.Json;
using PrismCourseApp.Models;
using System.Net.Http;

namespace PrismCourseApp.API
{
    public class APIHandler
    {
        public RootObject GetData(string cityName)
        {
            HttpClient client = new HttpClient();
            var vals = client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={cityName}&APPID=2f8babaca9500fbe56bb525ac0eb6179").Result;
            var result = vals.Content.ReadAsStringAsync().Result;
            var seriliaze = JsonConvert.DeserializeObject<RootObject>(result);
            return seriliaze;
        }
    }

    public interface IAPIHandler
    {
        RootObject GetData(string cityName);
    }
}
