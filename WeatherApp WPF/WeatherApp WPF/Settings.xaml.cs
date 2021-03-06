﻿using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace WeatherApp_WPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void SearchWeather(object sender, RoutedEventArgs e)
        {


            DateTime? selectedDate = DatePicker.SelectedDate;
            DateTime todayDate = DateTime.Now.Date;

            WeatherCast weatherCastWindow = new WeatherCast();
            string cityName = CityNameTextBox.Text;

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            cityName = textInfo.ToTitleCase(cityName);
            weatherCastWindow.Show();
            if (selectedDate.HasValue)
            {
                if (selectedDate > todayDate)
                {
                    Warning warning = new Warning(1);
                    this.Close();
                    weatherCastWindow.Close();
                    // throw new ArgumentOutOfRangeException("Date has to be from the past");                
                }
                string formattedDate = selectedDate.Value.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
                weatherCastWindow.GetWeatherByDate(cityName, formattedDate);
                this.Close();
            }
            else
            {
                weatherCastWindow.GetWeather(cityName);
                this.Close();
            }
        }
    }
}
