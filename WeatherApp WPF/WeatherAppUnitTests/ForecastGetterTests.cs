using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherAppClassLibrary;

namespace WeatherAppUnitTests
{
    [TestClass]
    public class ForecastGetterTests
    {

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

        //Test for GetForecastForNextFiveDays() method

        [TestMethod]
        public void ReturnNullIfEmptyCityName()
        {
            var wrapper = new TestWrapper();
            var wm = new WrapperMethod(wrapper);

            string cityName = "";

            Task expectedOutput = null;
            var result = wm.GetForecastForNextFiveDaysMockup(cityName).Result;


            Assert.AreEqual(expectedOutput, result);

        }
        [TestMethod]
        public void ReturnNullIfWoeidEqualsZero()
        {
            var wrapper = new TestWrapper();
            var wm = new WrapperMethod(wrapper);

            string cityName = "Lodnon";

            Task expectedOutput = null;
            var result = wm.GetForecastForNextFiveDaysMockup(cityName).Result;


            Assert.AreEqual(expectedOutput, result);

        }

        [TestMethod]
        public void ReturnForecast()
        {
            var wrapper = new TestWrapper();
            var wm = new WrapperMethod(wrapper);

            string cityName = "Busan";

            Forecast forecast = new Forecast();

            var result = wm.GetForecastForNextFiveDaysMockup(cityName).Result;

            Assert.ReferenceEquals(forecast, result);


        }

        [TestMethod]
        public void checkIfConsolidedWetherHasFiveRecords()
        {
            var wrapper = new TestWrapper();
            var wm = new WrapperMethod(wrapper);

            string cityName = "London";
            int expectedNumber = 5;

            var output = wm.GetForecastForNextFiveDaysMockup(cityName).Result;

            int result = output.consolidated_weather.Count - 1;

            Assert.AreEqual(expectedNumber, result);


        }


        //Test for GetForecastByDate() method


        [TestMethod]
        public void ReturnNullBecauseOfEmptyCityName()
        {
            var wrapper = new TestWrapper();
            var wm = new WrapperMethod(wrapper);

            string cityName = "";
            string[] date = { "2020-01-24" };

            Task expectedOutput = null;
            var result = wm.GetForecastByDateMockup(cityName, date).Result;


            Assert.AreEqual(expectedOutput, result);

        }
        [TestMethod]
        public void ReturnNullBecauseOfWoeidEqualsZero()
        {
            var wrapper = new TestWrapper();
            var wm = new WrapperMethod(wrapper);

            string cityName = "Lodnon";
            string[] date = { "2020-01-24" };

            Task expectedOutput = null;
            var result = wm.GetForecastByDateMockup(cityName, date).Result;


            Assert.AreEqual(expectedOutput, result);

        }





    }
}
