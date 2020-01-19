using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherAppClassLibrary;

namespace WeatherAppUnitTests
{

    [TestClass]



    public class LocationTests
    {

        [TestMethod]
        public async Task CheckConvertingCityLondonToId()
        {
            Location l = new Location();
            string cityName = "London";
            int expectedWoeid = 44418;

            int actualWoeid = await l.ConvertCityNameToId(cityName);


            Assert.AreEqual(expectedWoeid, actualWoeid);

        }

        [TestMethod]
        public async Task CheckConvertingCitySantiagoToId()
        {
            Location l = new Location();
            string cityName = "Santiago";
            int expectedWoeid = 349859;

            int actualWoeid = await l.ConvertCityNameToId(cityName);


            Assert.AreEqual(expectedWoeid, actualWoeid);

        }

        [TestMethod]
        public async Task ReturnZeroIfNoPossibleLocationsFound()
        {
            Location l = new Location();
            string cityName = "Lodnon";
            int expectedResult = 0;

            int result = await l.ConvertCityNameToId(cityName);


            Assert.AreEqual(expectedResult, result);

        }

        [TestMethod]
        public async Task ReturnZeroIfCityNameIsEmpty()
        {
            Location l = new Location();
            string cityName = "";
            int expectedResult = 0;

            int result = await l.ConvertCityNameToId(cityName);


            Assert.AreEqual(expectedResult, result);

        }

        [TestMethod]
        public async Task ReturnZeroIfPossibleLocationsCountNotEqualOne()
        {
            Location l = new Location();
            string cityName = "san";
            int expectedResult = 0;

            int result = await l.ConvertCityNameToId(cityName);


            Assert.AreEqual(expectedResult, result);

        }




        [TestMethod]
        public async Task ReturnZeroIfWebException()
        {
            Location l = new Location();
            string cityName = "London";
            int expectedResult = 0;

            // To test this method you need to uncomment line belowe to simulate lack of internet connection 
            // Warning: Rest of the unit tests will throw errors because of it

            //System.Diagnostics.Process.Start("ipconfig", "/release");

            int result = await l.ConvertCityNameToId(cityName);

            // 'Return' web connection
            //System.Diagnostics.Process.Start("ipconfig", "/renew");


            Assert.AreEqual(expectedResult, result);

        }

      

    }

    
}
