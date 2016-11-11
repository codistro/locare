using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Locare
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RecievePage : Page
    {
        public RecievePage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
            else
            {

            }
            RecieveMap.MapServiceToken = "GlatgQZkWTkX5kEaPgD6Ag";
            try {
                var locator = new Geolocator();
                locator.DesiredAccuracyInMeters = 50;

                var position = await locator.GetGeopositionAsync();
                await RecieveMap.TrySetViewAsync(position.Coordinate.Point, 18D);
            }
            catch { }

        }

        private async void SetPosition_Click(object sender, RoutedEventArgs e)
        {
            
            try {
               
                var myPosition = new BasicGeoposition();
                myPosition.Latitude = Double.Parse(Latitude.Text);
                myPosition.Longitude = Double.Parse(Longitude.Text);
                var mypoint = new Geopoint(myPosition);
                if (await RecieveMap.TrySetViewAsync(mypoint, 10D))
                {

                }
            }
            catch
            {

            }
        }

        private void appBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
            else
                Frame.Navigate(typeof(SendAndRecieve));
        }
    }
}
