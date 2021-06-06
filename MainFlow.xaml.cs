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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Restik
{
    /// <summary>
    /// Логика взаимодействия для MainFlow.xaml
    /// </summary>
    public partial class MainFlow : Page
    {
        public MainFlow()
        {
            InitializeComponent();
        }

        private void SingUpClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainFlow());
        }
    }
}
