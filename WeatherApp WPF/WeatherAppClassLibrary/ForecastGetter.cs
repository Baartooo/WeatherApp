using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppClassLibrary
{
    public static class ForecastGetter
    {
        public static async Task<Forecast> GetForecastForNextFiveDays(string cityName)
        {
            int woeid;
            string weatherJSON;
            Location location = new Location();
            woeid = await Task.Run(() => location.ConvertCityNameToId(cityName));

            using(WebClient client = new WebClient())
            {
                string json = await Task.Run(() => client.DownloadString("https://www.metaweather.com/api/location/" + woeid + '/'));
                weatherJSON = json;
            }
            weatherJSON = weatherJSON.Remove(weatherJSON.IndexOf(']') + 1) + '}';
            DataSet weatherDataSet = JsonConvert.DeserializeObject<DataSet>(weatherJSON);
            DataTable consolidated_weather = weatherDataSet.Tables["consolidated_weather"];
            Forecast forecast = new Forecast(consolidated_weather);

            return forecast;
        }
    }
}
