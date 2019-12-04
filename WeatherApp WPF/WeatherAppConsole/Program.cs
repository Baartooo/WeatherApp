using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAppClassLibrary;

namespace WeatherAppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ForecastGetter.GetForecastForNextFiveDays("London");

            Console.ReadKey();
        }
    }
}
