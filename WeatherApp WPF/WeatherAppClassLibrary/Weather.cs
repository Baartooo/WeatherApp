using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppClassLibrary
{
    public class Weather
    {
        public string weather_state_name { get; set; }
        public string applicable_date { get; set; }
        public double the_temp { get; set; }

        public override string ToString()
        {
            return $"applicable_date: { this.applicable_date}\n" +
                   $"weather_state_name: {this.weather_state_name}\n" +
                   $"the_temp: {this.the_temp}\n\n";
        }
    }
}
