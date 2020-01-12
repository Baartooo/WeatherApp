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

namespace WeatherApp_WPF
{
    /// <summary>
    /// Interaction logic for Warning.xaml
    /// </summary>
    public partial class Warning : Window
    {
        public Warning(int errorCode)
        {
            InitializeComponent();
            FillErrorMessage(errorCode);
            this.Show();
        }

        private void TryAgain(object sender, RoutedEventArgs e)
        {
            Window1 settingsWindow = new Window1();
            settingsWindow.Show();
            FocusManager.SetFocusedElement(settingsWindow, settingsWindow.CityNameTextBox);
            this.Close();
        }
        private void FillErrorMessage(int errorCode)
        {
            switch (errorCode)
            {
                case 0:
                    WarningContent.Content = "Wrong location name. Try again";
                    break;
                case 1:
                    WarningContent.Content = "Wrong date: Date has to be from the past";
                    break;
                default:
                    WarningContent.Content = "Default...";
                    break;

            }
        }
    }
}
