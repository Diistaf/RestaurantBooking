using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Restik
{
    /// <summary>
    /// Логика взаимодействия для DeleteRestoran.xaml
    /// </summary>
    public partial class DeleteRestoran : Window
    {
        Restaurant rest = null;
        public DeleteRestoran(Restaurant restaurant)
        {
            InitializeComponent();
            rest = restaurant;
        }

        private void CancelBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DeleteBtn(object sender, RoutedEventArgs e)
        {
            App.db.Restaurants.Attach(rest);
            App.db.Entry(rest).State = EntityState.Deleted;
            App.db.SaveChanges();
            this.Close();
        }
    }
}
