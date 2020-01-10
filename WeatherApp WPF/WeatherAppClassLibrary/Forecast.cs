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
        public List<Weather> consolidated_weather;
        public Parent parent;
        public int errorCode = -1;

        public Weather GetTodaysWeather() => consolidated_weather[0];
        public Weather GetFirstDaysWeather() => consolidated_weather[1];
        public Weather GetSecondDaysWeather() => consolidated_weather[2];
        public Weather GetThirdDaysWeather() => consolidated_weather[3];
    }
}
