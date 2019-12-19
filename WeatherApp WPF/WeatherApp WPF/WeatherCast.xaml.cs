using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WeatherAppClassLibrary;

namespace WeatherApp_WPF
{
    /// <summary>
    /// Interaction logic for WeatherCast.xaml
    /// </summary>
    public partial class WeatherCast : Window
    {
        public WeatherCast()
        {
            InitializeComponent();
        }

        public async Task GetWeather(string cityName)
        {
            Forecast forecast = await ForecastGetter.GetForecastForNextFiveDays(cityName);
            CityCountryText.Content = cityName;

            FillWeatherInformations(forecast);

        }

        private void FillWeatherInformations(Forecast forecast)
        {
            Weather todayWeather = forecast.GetTodayWeather();
            TodayDate.Content = todayWeather.applicable_date;
        }
    }
}
