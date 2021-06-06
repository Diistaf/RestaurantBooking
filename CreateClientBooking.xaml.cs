using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Restik
{
    /// <summary>
    /// Логика взаимодействия для CreateClientBooking.xaml
    /// </summary>
    public partial class CreateClientBooking : Page
    {
        Booking booking;
        Client selectClient;
        Restaurant selectRestaurant;

        public CreateClientBooking(Client client, Restaurant restaurant)
        {
            InitializeComponent();
            selectClient = client;
            selectRestaurant = restaurant;
            clientName.Text = client.Name.Substring(0, clientName.Text.Length).ToUpper();
            booking = new Booking()
            {
                ClientId = selectClient.Id,
                Client = selectClient,
                RestaurantId = selectRestaurant.Id,
                Restaurant = selectRestaurant,
                ArrivalDatetime = DateTime.Now
            };
            DataContext = booking;
        }

        private void ContinueClick(object sender, RoutedEventArgs e)
        {
            if (ArrivalTimeText.Text != "" && CountPeopleText.Text != "")
            {
                galka.Opacity = 1;
                App.db.Bookings.Add(booking);
                App.db.SaveChanges();
            }
            else
            {
                prodol.Opacity = 1;
            }
        }

        private void ArrivalTimeTextFocus(object sender, RoutedEventArgs e)
        {
            if (ArrivalTimeText.Text != "" || ArrivalTimeText.IsKeyboardFocused == true)
            {
                ArrivalTimeText.Opacity = 1;
            }
            else
            {
                ArrivalTimeText.Opacity = 0;
            }
        }

        private void CountPeopleTextFocus(object sender, RoutedEventArgs e)
        {
            if (CountPeopleText.Text != "" || CountPeopleText.IsKeyboardFocused == true)
            {
                CountPeopleText.Opacity = 1;
            }
            else
            {
                CountPeopleText.Opacity = 0;
            }
        }

        private void ButtonGoBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void OpenClientProfile(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ClientBooking(selectClient));
        }
    }
}
