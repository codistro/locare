using System;
using Windows.ApplicationModel.Contacts;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Linq;
using Windows.ApplicationModel.Email;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Locare
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>


    public sealed partial class SmsSendPage : Page
    {
        public SmsSendPage()
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
            MyMap.MapServiceToken = "GlatgQZkWTkX5kEaPgD6Ag";
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
            else
            {

            }
            try
            {
                var locator = new Geolocator();
                locator.DesiredAccuracyInMeters = 50;

                var position = await locator.GetGeopositionAsync();
                await MyMap.TrySetViewAsync(position.Coordinate.Point, 18D);
            }
            catch { }
        }



        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var contactPicker = new ContactPicker();
                contactPicker.DesiredFieldsWithContactFieldType.Add(ContactFieldType.PhoneNumber);

                Contact contact = await contactPicker.PickContactAsync();
                string sms = string.Format("I need your help, The coordinates of my location are:- "+"Latitude:{0}  Longitude:{1}", MyMap.Center.Position.Latitude, MyMap.Center.Position.Longitude);
                ComposeSMS(contact, sms);
            }
            catch { }
        }
        private async void ComposeSMS(Contact contact, string message)
        {
            try {
                var chatMessage = new Windows.ApplicationModel.Chat.ChatMessage();
                chatMessage.Body = message;
                var phone = contact.Phones.FirstOrDefault<Windows.ApplicationModel.Contacts.ContactPhone>();
                chatMessage.Recipients.Add(phone.Number);
                await Windows.ApplicationModel.Chat.ChatMessageManager.ShowComposeSmsMessageAsync(chatMessage);
            }
            catch { }
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


