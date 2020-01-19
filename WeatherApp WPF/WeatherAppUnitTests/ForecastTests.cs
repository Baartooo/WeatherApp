using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using WeatherAppClassLibrary;
using WeatherAppUnitTests;

namespace WeatherAppUnitTests
{
    [TestClass]
    public class ForecastTests
    {
        // expample weather list

        public async Task<Forecast> GetWeatherForLondon()
        {
            string weatherJSON;

            using (WebClient client = new WebClient())
            {
                string json = await Task.Run(() => client.DownloadString("https://www.metaweather.com/api/location/" + 44418 + '/'));
                weatherJSON = json;
            }
            Forecast forecast = JsonConvert.DeserializeObject<Forecast>(weatherJSON);
            return forecast;


        }


        // Mockup for ForecastGetter static methods
        public interface IForecastGetterOperations
        {
            Task<Forecast> GetForecastForNextFiveDaysWrapper(string cityName);
            Task<List<Weather>> GetForecastByDateWrapper(string cityName, string[] date);
        }

        private class TestWrapper : IForecastGetterOperations
        {
            public async Task<List<Weather>> GetForecastByDateWrapper(string cityName, string[] date)
            {
                return await ForecastGetter.GetForecastByDate(cityName, date);
            }

            public async Task<Forecast> GetForecastForNextFiveDaysWrapper(string cityName)
            {
                return await ForecastGetter.GetForecastForNextFiveDays(cityName);
            }
        }

        public class WrapperMethod
        {
            IForecastGetterOperations _wrapper;

            public WrapperMethod(IForecastGetterOperations wrapper)
            {
                _wrapper = wrapper;
            }

            public async Task<List<Weather>> GetForecastByDateMockup(string cityName, string[] date)
            {
                return await _wrapper.GetForecastByDateWrapper(cityName, date);
            }

            public async Task<Forecast> GetForecastForNextFiveDaysMockup(string cityName)
            {
                return await _wrapper.GetForecastForNextFiveDaysWrapper(cityName);
            }
        }



        [TestMethod]
        public void ReturnTodaysWeather()
        {
          
            Forecast forecastExample = GetWeatherForLondon().Result;

            var wrapper = new TestWrapper();
            var wm = new WrapperMethod(wrapper);

            string cityName = "London";

           Forecast forecast = wm.GetForecastForNextFiveDaysMockup(cityName).Result;

            var weather_state_name = forecast.consolidated_weather[0].weather_state_name;
            var max_tmp = forecast.consolidated_weather[0].max_temp;
            var min_tmp = forecast.consolidated_weather[0].min_temp;
            var tmp = forecast.consolidated_weather[0].the_temp;
            var applicable_date = forecast.consolidated_weather[0].applicable_date;
            var air_pressure = forecast.consolidated_weather[0].air_pressure;



            Assert.AreEqual(forecastExample.consolidated_weather[0].weather_state_name, weather_state_name);
            Assert.AreEqual(forecastExample.consolidated_weather[0].max_temp, max_tmp);
            Assert.AreEqual(forecastExample.consolidated_weather[0].min_temp, min_tmp);
            Assert.AreEqual(forecastExample.consolidated_weather[0].the_temp, tmp);
            Assert.AreEqual(forecastExample.consolidated_weather[0].applicable_date, applicable_date);
            Assert.AreEqual(forecastExample.consolidated_weather[0].air_pressure, air_pressure);


        }

        [TestMethod]
        public void ReturnFirstDayWeather()
        {

            Forecast forecastExample = GetWeatherForLondon().Result;

            var wrapper = new TestWrapper();
            var wm = new WrapperMethod(wrapper);

            string cityName = "London";

            Forecast forecast = wm.GetForecastForNextFiveDaysMockup(cityName).Result;

            var weather_state_name = forecast.consolidated_weather[1].weather_state_name;
            var max_tmp = forecast.consolidated_weather[1].max_temp;
            var min_tmp = forecast.consolidated_weather[1].min_temp;
            var tmp = forecast.consolidated_weather[1].the_temp;
            var applicable_date = forecast.consolidated_weather[1].applicable_date;
            var air_pressure = forecast.consolidated_weather[1].air_pressure;



            Assert.AreEqual(forecastExample.consolidated_weather[1].weather_state_name, weather_state_name);
            Assert.AreEqual(forecastExample.consolidated_weather[1].max_temp, max_tmp);
            Assert.AreEqual(forecastExample.consolidated_weather[1].min_temp, min_tmp);
            Assert.AreEqual(forecastExample.consolidated_weather[1].the_temp, tmp);
            Assert.AreEqual(forecastExample.consolidated_weather[1].applicable_date, applicable_date);
            Assert.AreEqual(forecastExample.consolidated_weather[1].air_pressure, air_pressure);


        }

        [TestMethod]
        public void ReturnSecondDayWeather()
        {

            Forecast forecastExample = GetWeatherForLondon().Result;

            var wrapper = new TestWrapper();
            var wm = new WrapperMethod(wrapper);

            string cityName = "London";

            Forecast forecast = wm.GetForecastForNextFiveDaysMockup(cityName).Result;

            var weather_state_name = forecast.consolidated_weather[2].weather_state_name;
            var max_tmp = forecast.consolidated_weather[2].max_temp;
            var min_tmp = forecast.consolidated_weather[2].min_temp;
            var tmp = forecast.consolidated_weather[2].the_temp;
            var applicable_date = forecast.consolidated_weather[2].applicable_date;
            var air_pressure = forecast.consolidated_weather[2].air_pressure;



            Assert.AreEqual(forecastExample.consolidated_weather[2].weather_state_name, weather_state_name);
            Assert.AreEqual(forecastExample.consolidated_weather[2].max_temp, max_tmp);
            Assert.AreEqual(forecastExample.consolidated_weather[2].min_temp, min_tmp);
            Assert.AreEqual(forecastExample.consolidated_weather[2].the_temp, tmp);
            Assert.AreEqual(forecastExample.consolidated_weather[2].applicable_date, applicable_date);
            Assert.AreEqual(forecastExample.consolidated_weather[2].air_pressure, air_pressure);


        }

        [TestMethod]
        public void ReturnThirdDayWeather()
        {

            Forecast forecastExample = GetWeatherForLondon().Result;

            var wrapper = new TestWrapper();
            var wm = new WrapperMethod(wrapper);

            string cityName = "London";

            Forecast forecast = wm.GetForecastForNextFiveDaysMockup(cityName).Result;

            var weather_state_name = forecast.consolidated_weather[3].weather_state_name;
            var max_tmp = forecast.consolidated_weather[3].max_temp;
            var min_tmp = forecast.consolidated_weather[3].min_temp;
            var tmp = forecast.consolidated_weather[3].the_temp;
            var applicable_date = forecast.consolidated_weather[3].applicable_date;
            var air_pressure = forecast.consolidated_weather[3].air_pressure;



            Assert.AreEqual(forecastExample.consolidated_weather[3].weather_state_name, weather_state_name);
            Assert.AreEqual(forecastExample.consolidated_weather[3].max_temp, max_tmp);
            Assert.AreEqual(forecastExample.consolidated_weather[3].min_temp, min_tmp);
            Assert.AreEqual(forecastExample.consolidated_weather[3].the_temp, tmp);
            Assert.AreEqual(forecastExample.consolidated_weather[3].applicable_date, applicable_date);
            Assert.AreEqual(forecastExample.consolidated_weather[3].air_pressure, air_pressure);


        }





    }

}