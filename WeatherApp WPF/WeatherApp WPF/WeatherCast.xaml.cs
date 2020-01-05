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

            FillWeatherInformation(forecast);

        }

        private void FillWeatherInformation(Forecast forecast)
        {
            FillTodaysWeather(forecast);
            FillFirstDaysWeather(forecast);
            FillSecondDaysWeather(forecast);

            Weather thirdDaysWeather = forecast.GetThirdDaysWeather();
            DayThreeDate.Content = ("Date:  " + thirdDaysWeather.applicable_date);
            DayThreeTemp.Content = ("Temp:  " + Math.Round(thirdDaysWeather.the_temp, 1) + "°C");
            DayThreeAtm.Content = ("Atm:  " + Math.Round(thirdDaysWeather.air_pressure) + " hPa");

            Uri uri = new Uri("https://www.metaweather.com//static/img/weather/png/" + thirdDaysWeather.weather_state_abbr + ".png");
            DayThreeWeatherImage.Source = new BitmapImage(uri);

        }

        private void FillSecondDaysWeather(Forecast forecast)
        {
            Weather secondDaysWeather = forecast.GetSecondDaysWeather();
            DayTwoDate.Content = ("Date:  " + secondDaysWeather.applicable_date);
            DayTwoTemp.Content = ("Temp:  " + Math.Round(secondDaysWeather.the_temp, 1) + "°C");
            DayTwoAtm.Content = ("Atm:  " + Math.Round(secondDaysWeather.air_pressure) + " hPa");

            Uri uri = new Uri("https://www.metaweather.com//static/img/weather/png/" + secondDaysWeather.weather_state_abbr + ".png");
            DayTwoWeatherImage.Source = new BitmapImage(uri);
        }

        private void FillFirstDaysWeather(Forecast forecast)
        {
            Weather firstDayWeather = forecast.GetFirstDaysWeather();
            DayOneDate.Content = ("Date:  " + firstDayWeather.applicable_date);
            DayOneTemp.Content = ("Temp:  " + Math.Round(firstDayWeather.the_temp, 1) + "°C");
            DayOneAtm.Content = ("Atm:  " + Math.Round(firstDayWeather.air_pressure) + " hPa");

            Uri uri = new Uri("https://www.metaweather.com//static/img/weather/png/" + firstDayWeather.weather_state_abbr + ".png");
            DayOneWeatherImage.Source = new BitmapImage(uri);
        }

        private void FillTodaysWeather(Forecast forecast)
        {
            Weather todayWeather = forecast.GetTodaysWeather();
            TodayDate.Content = ("Date:  " + todayWeather.applicable_date);
            TodayMaxTemp.Content = ("Max Temp:  " + Math.Round(todayWeather.max_temp, 1) + "°C");
            TodayTemp.Content = ("Temp:  " + Math.Round(todayWeather.the_temp, 1) + "°C");
            TodayAtm.Content = ("Atm:  " + Math.Round(todayWeather.air_pressure) + " hPa");
            TodayMinTemp.Content = ("Min Temp:  " + Math.Round(todayWeather.min_temp, 1) + "°C");

            Uri uri = new Uri("https://www.metaweather.com//static/img/weather/png/" + todayWeather.weather_state_abbr + ".png");
            TodayWeatherImage.Source = new BitmapImage(uri);
        }

        private void SearchAgain_Click(object sender, RoutedEventArgs e)
        {
            Window1 settingsWindow = new Window1();
            settingsWindow.Show();
            FocusManager.SetFocusedElement(settingsWindow, settingsWindow.CityNameTextBox);
            this.Close();
        }
    }
}
