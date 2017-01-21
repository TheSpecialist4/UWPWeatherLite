using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPWeatherLite
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e) {
            ProgressRing.Visibility = Visibility.Visible;
            ProgressRing.IsActive = true;

            var geoposition = await LocationManager.GetPositionAsync();

            if (geoposition == null) {
                WeatherTextBlock.Text = "Please enable location services for this app.";
                ProgressRing.IsActive = false;
                ProgressRing.Visibility = Visibility.Collapsed;
                return;
            }

            double latitude = geoposition.Coordinate.Point.Position.Latitude;

            double longitude = geoposition.Coordinate.Point.Position.Longitude;

            var weatherObject = await OpenWeatherMapAPI.GetWeatherForLatitudeAsync(latitude, longitude);
            //var weatherObject = await weatherObjectTask;
            WeatherTextBlock.Text = weatherObject.name + ": " + (int)weatherObject.main.temp;

            var iconPath = string.Format("ms-appx:///Assets/Weather/{0}.png", weatherObject.weather[0].icon);
            WeatherIconImage.Source = new BitmapImage(new Uri(iconPath, UriKind.Absolute));

            ProgressRing.Visibility = Visibility.Collapsed;
            ProgressRing.IsActive = false;
        }
    }
}
