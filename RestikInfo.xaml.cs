using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.Entity;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Restik
{
    /// <summary>
    /// Логика взаимодействия для RestikInfo.xaml
    /// </summary>
    public partial class RestikInfo : Page
    {
        Client selectClient;
        Restaurant selectRestaurant;

        public RestikInfo(Client client, Restaurant restaurant)
        {
            InitializeComponent();
            selectClient = client;
            selectRestaurant = restaurant;
            clientName.Text = selectClient.Name.Substring(0, clientName.Text.Length).ToUpper();
            gridData.DataContext = restaurant;
            imageList.ItemsSource = restaurant.ImageInRestaurants.ToList();
        }

        private void BackBtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void WatchPlusMouseUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new CreateClientBooking(selectClient, selectRestaurant));
        }

        private void ClientMouseUp(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ClientBooking(selectClient));
        }

        private void BookingClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateClientBooking(selectClient, selectRestaurant));
        }
    }
}
