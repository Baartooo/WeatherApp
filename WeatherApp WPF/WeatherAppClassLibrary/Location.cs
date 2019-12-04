using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppClassLibrary
{
    public class Location
    {
        public string title { get; set; }
        public int woeid { get; set; }
        private string locationJSON;

        public async Task<int>ConvertCityNameToId(string cityName)
        {
            using(WebClient client=new WebClient())
            {
                string json = await Task.Run(() => client.DownloadString("https://www.metaweather.com/api/location/search/?query=" + cityName));
                locationJSON = json;
            }
            locationJSON=locationJSON.Trim('[').Trim(']');
            Location loc = JsonConvert.DeserializeObject<Location>(locationJSON);
            return loc.woeid;
        }
    }
}
