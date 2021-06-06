using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для CreatorListFrame.xaml
    /// </summary>
    public partial class CreatorListFrame : Page
    {
        Creator creat = null;
        public CreatorListFrame(Creator creator)
        {
            InitializeComponent();
            creat = creator;
            DataContext = creator;
            listRestoran.ItemsSource = creator.Restaurants;
        }

        private void UpdateRestaurant(object sender, RoutedEventArgs e)
        {
            var item = ((Button)sender).DataContext as Restaurant;

            PageHoster ph = App.Current.MainWindow as PageHoster;
            ph.NavigationService.Navigate(new CreateRestoran(item));
        }

        private void DeleteRestaurant(object sender, RoutedEventArgs e)
        {
            DeleteRestoran dr = null;
            var item = ((Button)sender).DataContext as Restaurant;
            if (item != null)
            {
                dr = new DeleteRestoran(item);
                dr.ShowDialog();
            }
            if (dr != null)
            {
                Thread.Sleep(2000);
                listRestoran.ItemsSource = App.db.Restaurants.Where(i => i.CreatorId == creat.Id).ToList();
            }
        }
    }
}
