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
    /// Логика взаимодействия для ClientBooking.xaml
    /// </summary>
    public partial class ClientBooking : Page
    {
        Client cl = null;
        public ClientBooking(Client client)
        {
            InitializeComponent();
            cl = client;
            var booking = App.db.Bookings.Where(i => i.ClientId == client.Id).ToList();
            listBooking.ItemsSource = booking.OrderByDescending(i => i.Id);

            clientName.Text = client.Name.Substring(0, clientName.Text.Length).ToUpper();
        }

        private void BackBtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void DeleteBtnClick(object sender, RoutedEventArgs e)
        {
            DeleteBooking dr = null;
            var item = ((Button)sender).DataContext;

            if (item != null)
            {
                dr = new DeleteBooking(item as Booking);
                dr.ShowDialog();
            }
            if (dr != null)
            {
                Thread.Sleep(2000);
                listBooking.ItemsSource = App.db.Bookings.Where(i => i.ClientId == cl.Id).OrderByDescending(i => i.Id).ToList();
            }
        }

        private void ExitBtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StartScreen());
        }
    }
}
