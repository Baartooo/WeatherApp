using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppClassLibrary
{
    /// <summary>
    /// The Weather class handle weathercast elements.
    /// </summary>
    public class Weather
    {
        public string weather_state_name { get; set; }
        public string weather_state_abbr { get; set; }
        public string applicable_date { get; set; }
        public double the_temp { get; set; }
        public double min_temp { get; set; }
        public double max_temp { get; set; }
        public double air_pressure { get; set; }
    }
}
