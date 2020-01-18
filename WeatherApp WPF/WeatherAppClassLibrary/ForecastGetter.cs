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
    /// <summary>
    /// The ForecastGetter class contains methods to get forecast for next 3 days or by date.
    /// </summary>
    public static class ForecastGetter
    {
        /// <summary>
        /// Get Forecast for next 3 days.
        /// </summary>
        /// <param name="cityName">City name.</param>
        /// <returns> Forecast.</returns>
        public static async Task<Forecast> GetForecastForNextFiveDays(string cityName)
        {
            int woeid;
            string weatherJSON;
            Location location = new Location();
            woeid = await Task.Run(() => location.ConvertCityNameToId(cityName));

            if (woeid == 0)
                return null;

            using (WebClient client = new WebClient())
            {
                string json = await Task.Run(() => client.DownloadString("https://www.metaweather.com/api/location/" + woeid + '/'));
                weatherJSON = json;
            }
            Forecast forecast = JsonConvert.DeserializeObject<Forecast>(weatherJSON);
            return forecast;
        }
        /// <summary>
        /// Get forecast by date.
        /// </summary>
        /// <param name="cityName">City name.</param>
        /// <param name="date">Table of next 3 days.</param>
        /// <returns></returns>
        public static async Task<List<Weather>> GetForecastByDate(string cityName, string[] date)
        {
            int woeid;
            string weatherJSON;
            Location location = new Location();
            woeid = await Task.Run(() => location.ConvertCityNameToId(cityName));

            if (woeid == 0)
                return null;

            using (WebClient client = new WebClient())
            {
                string json = await Task.Run(() => client.DownloadString("https://www.metaweather.com/api/location/" + $"{woeid}/{date[2]}/{date[1]}/{date[0]}"));
                weatherJSON = json;
            }
            List<Weather> forecast = JsonConvert.DeserializeObject<List<Weather>>(weatherJSON);

            return forecast;
        }
    }
}
