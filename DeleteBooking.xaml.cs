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
    /// Логика взаимодействия для DeleteBooking.xaml
    /// </summary>
    public partial class DeleteBooking : Window
    {
        Booking book = null;
        public DeleteBooking(Booking booking)
        {
            InitializeComponent();
            book = booking;
        }

        private void CancelBtnClick(object sender, RoutedEventArgs e)
        {
            App.db.Bookings.Attach(book);
            App.db.Entry(book).State = EntityState.Deleted;
            App.db.SaveChanges();
            this.Close();
        }

        private void BackBtnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
