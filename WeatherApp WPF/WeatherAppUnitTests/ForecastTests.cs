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

        public async Task<Forecast> GetWeather()
        {
            var wrapper = new TestWrapper();
            var wm = new WrapperMethod(wrapper);

            string cityName = "London";

            return wm.GetForecastForNextFiveDaysMockup(cityName).Result;

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

        // TO DO

        //[TestMethod]
        //public void ReturnTodaysWeather()
        //{
            

        //    Forecast forecastExample = GetWeather().Result;

        //    var wrapper = new TestWrapper();
        //    var wm = new WrapperMethod(wrapper);

        //    string cityName = "London";

        //   Forecast forecast = wm.GetForecastForNextFiveDaysMockup(cityName).Result;

        //    var result = forecast.consolidated_weather[0];

  

        //    Assert.AreSame(forecastExample.consolidated_weather[0], result);
              

        //}



    }

}