using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppClassLibrary
{
    /// <summary>
    /// The Location class contains location variables and getting location from JSON.
    /// </summary>
    public class Location
    {
        public string title { get; set; }
        public int woeid { get; set; }
        private string locationJSON;

        /// <summary>
        /// Download cityName from input to convert it to ID.
        /// </summary>
        /// <param name="cityName">Name of city.</param>
        /// <returns>Returns possible Location</returns>
        public async Task<int>ConvertCityNameToId(string cityName)
        {
           
            if (cityName == "")
                cityName = "default";
         
            using(WebClient client=new WebClient())
            {
                try
                {
                    string json = await Task.Run(() => client.DownloadString("https://www.metaweather.com/api/location/search/?query=" + cityName));
                    locationJSON = json;
                }
                catch(WebException exception)
                {
                    return 0;
                }

            }
            List<Location> possibleLocations = JsonConvert.DeserializeObject<List<Location>>(locationJSON);

            if (possibleLocations.Count == 1)
                return possibleLocations[0].woeid;
            else
                return 0;
        }
    }
}
