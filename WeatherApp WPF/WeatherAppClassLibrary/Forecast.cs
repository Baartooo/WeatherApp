using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherAppClassLibrary
{
    /// <summary>
    /// The Forecast class represents model of recieved JSON data and methods for getting forecast on concrete days.
    /// </summary>
    public class Forecast
    {
        public List<Weather> consolidated_weather;
        public Parent parent;
        public int errorCode = -1;

        /// <summary>
        /// Get consolidated weather for today.
        /// </summary>
        /// <returns>Returns object of type Weather</returns>
        public Weather GetTodaysWeather() => consolidated_weather[0];
        /// <summary>
        /// Get consolidated weather for first day.
        /// </summary>
        /// <returns>Returns object of type Weather</returns>
        public Weather GetFirstDaysWeather() => consolidated_weather[1];
        /// <summary>
        /// Get consolidated weather for second day.
        /// </summary>
        /// <returns>Returns object of type Weather</returns>
        public Weather GetSecondDaysWeather() => consolidated_weather[2];
        /// <summary>
        /// Get consolidated weather for third day.
        /// </summary>
        /// <returns>Returns object of type Weather</returns>
        public Weather GetThirdDaysWeather() => consolidated_weather[3];
    }
}
