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
            TodayDate.Content = ("Date:  " + todayWeather.applicable_date);
            TodayMaxTemp.Content = ("Max Temp:  " + Math.Round(todayWeather.max_temp,1) + "°C");
            TodayTemp.Content = ("Temp:  " + Math.Round(todayWeather.the_temp,1) + "°C");
            TodayAtm.Content = ("Atm:  " + Math.Round(todayWeather.air_pressure) + " hPa");
            TodayMinTemp.Content = ("Min Temp:  " + Math.Round(todayWeather.min_temp,1) + "°C");

            Uri uri = new Uri("https://www.metaweather.com//static/img/weather/png/64/" + todayWeather.weather_state_abbr + ".png");
            TodayWeatherImage.Source = new BitmapImage(uri);

        }
        private void SearchAgain_Click(object sender, RoutedEventArgs e)
        {
            Window1 settingsWindow = new Window1();
            settingsWindow.Show();
            this.Close();
        }
    }
}
