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
            CityCountryText.Content = $"{cityName}, {forecast.parent.title}";

            FillWeatherInformation(forecast);

        }
        public async Task GetWeatherByDate(string cityName, string formattedDate)
        {
            string[] dateArray = formattedDate.Split('.');
            List<Weather> forecast = await ForecastGetter.GetForecastByDate(cityName, dateArray);
            FillForecastByDateInformation(forecast);
            CityCountryText.Content = $"{cityName}, {forecast[0].applicable_date}";
        }

        private void FillForecastByDateInformation(List<Weather> forecast)
        {
            FillThreeOclocksWeather(forecast);
            FillNineOclocksWeather(forecast);
            FillFifteenOclocksWeather(forecast);
            FillTwentyOneOclocksWeather(forecast);
        }

        private void FillTwentyOneOclocksWeather(List<Weather> forecast)
        {
            Weather twentyOneOclocksWeather = forecast[0];
            FourthWeatherLabel.Content = "Hour: 21:00";
            TodayTemp.Content = ("Temp:  " + Math.Round(twentyOneOclocksWeather.the_temp, 1) + "°C");
            TodayAtm.Content = ("Atm:  " + Math.Round(twentyOneOclocksWeather.air_pressure) + " hPa");

            Uri uri = new Uri("https://www.metaweather.com//static/img/weather/png/" + twentyOneOclocksWeather.weather_state_abbr + ".png");
            TodayWeatherImage.Source = new BitmapImage(uri);
        }

        private void FillFifteenOclocksWeather(List<Weather> forecast)
        {
            Weather fifteenOclocksWeather = forecast[2];
            ThirdWeatherLabel.Content = "Hour: 15:00";
            DayThreeTemp.Content = ("Temp:  " + Math.Round(fifteenOclocksWeather.the_temp, 1) + "°C");
            DayThreeAtm.Content = ("Atm:  " + Math.Round(fifteenOclocksWeather.air_pressure) + " hPa");

            Uri uri = new Uri("https://www.metaweather.com//static/img/weather/png/" + fifteenOclocksWeather.weather_state_abbr + ".png");
            DayThreeWeatherImage.Source = new BitmapImage(uri);
        }

        private void FillNineOclocksWeather(List<Weather> forecast)
        {
            Weather nineOclocksWeather = forecast[4];
            SecondWeatherLabel.Content = "Hour: 09:00";
            DayTwoTemp.Content = ("Temp:  " + Math.Round(nineOclocksWeather.the_temp, 1) + "°C");
            DayTwoAtm.Content = ("Atm:  " + Math.Round(nineOclocksWeather.air_pressure) + " hPa");

            Uri uri = new Uri("https://www.metaweather.com//static/img/weather/png/" + nineOclocksWeather.weather_state_abbr + ".png");
            DayTwoWeatherImage.Source = new BitmapImage(uri);
        }

        private void FillThreeOclocksWeather(List<Weather> forecast)
        {
            Weather threeOclocksWeather = forecast[6];
            FirstWeatherLabel.Content = "Hour: 03:00";
            DayOneTemp.Content = ("Temp:  " + Math.Round(threeOclocksWeather.the_temp, 1) + "°C");
            DayOneAtm.Content = ("Atm:  " + Math.Round(threeOclocksWeather.air_pressure) + " hPa");

            Uri uri = new Uri("https://www.metaweather.com//static/img/weather/png/" + threeOclocksWeather.weather_state_abbr + ".png");
            DayOneWeatherImage.Source = new BitmapImage(uri);
        }

        private void FillWeatherInformation(Forecast forecast)
        {
            FillTodaysWeather(forecast);
            FillFirstDaysWeather(forecast);
            FillSecondDaysWeather(forecast);
            FillThirdDaysWeather(forecast);

        }

        private void FillThirdDaysWeather(Forecast forecast)
        {
            Weather thirdDaysWeather = forecast.GetThirdDaysWeather();
            ThirdWeatherLabel.Content = "DAY 3";
            DayThreeDate.Content = ("Date:  " + thirdDaysWeather.applicable_date);
            DayThreeTemp.Content = ("Temp:  " + Math.Round(thirdDaysWeather.the_temp, 1) + "°C");
            DayThreeAtm.Content = ("Atm:  " + Math.Round(thirdDaysWeather.air_pressure) + " hPa");

            Uri uri = new Uri("https://www.metaweather.com//static/img/weather/png/" + thirdDaysWeather.weather_state_abbr + ".png");
            DayThreeWeatherImage.Source = new BitmapImage(uri);
        }

        private void FillSecondDaysWeather(Forecast forecast)
        {
            Weather secondDaysWeather = forecast.GetSecondDaysWeather();
            SecondWeatherLabel.Content = "DAY 2";
            DayTwoDate.Content = ("Date:  " + secondDaysWeather.applicable_date);
            DayTwoTemp.Content = ("Temp:  " + Math.Round(secondDaysWeather.the_temp, 1) + "°C");
            DayTwoAtm.Content = ("Atm:  " + Math.Round(secondDaysWeather.air_pressure) + " hPa");

            Uri uri = new Uri("https://www.metaweather.com//static/img/weather/png/" + secondDaysWeather.weather_state_abbr + ".png");
            DayTwoWeatherImage.Source = new BitmapImage(uri);
        }

        private void FillFirstDaysWeather(Forecast forecast)
        {
            Weather firstDayWeather = forecast.GetFirstDaysWeather();
            FirstWeatherLabel.Content = "DAY 1";
            DayOneDate.Content = ("Date:  " + firstDayWeather.applicable_date);
            DayOneTemp.Content = ("Temp:  " + Math.Round(firstDayWeather.the_temp, 1) + "°C");
            DayOneAtm.Content = ("Atm:  " + Math.Round(firstDayWeather.air_pressure) + " hPa");

            Uri uri = new Uri("https://www.metaweather.com//static/img/weather/png/" + firstDayWeather.weather_state_abbr + ".png");
            DayOneWeatherImage.Source = new BitmapImage(uri);
        }

        private void FillTodaysWeather(Forecast forecast)
        {
            Weather todayWeather = forecast.GetTodaysWeather();
            FourthWeatherLabel.Content = "TODAY";
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
