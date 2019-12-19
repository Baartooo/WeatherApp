using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppClassLibrary
{
    public class Forecast
    {
        public List<Weather> forecast;

        public Forecast(DataTable consolidated_weather)
        {
            forecast = new List<Weather>();
            foreach(DataRow row in consolidated_weather.Rows)
            {
                Weather weather = new Weather()
                {
                    weather_state_name = Convert.ToString(row["weather_state_name"]),
                    applicable_date = Convert.ToString(row["applicable_date"]),
                    the_temp = Convert.ToDouble(row["the_temp"]),
                    min_temp = Convert.ToDouble(row["min_temp"]),
                    max_temp = Convert.ToDouble(row["max_temp"]),
                    air_pressure = Convert.ToDouble(row["air_pressure"]),
                    weather_state_abbr = Convert.ToString(row["weather_state_abbr"])
                };
                forecast.Add(weather);
            }
        }

        public Weather GetTodayWeather()
        {
            return forecast[0];
        }
    }
}
