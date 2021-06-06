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
    /// Логика взаимодействия для CreatorListFlow.xaml
    /// </summary>
    public partial class CreatorListFlow : Page
    {
        Creator selectCreator;
        public CreatorListFlow(Creator creator)
        {
            InitializeComponent();
            selectCreator = creator;
            DataContext = selectCreator;
            if (selectCreator.Restaurants.Count() == 0)
            {
                mainFlowForCreatorListFlow.Navigate(new CreatorListNullFrame(selectCreator));
            }
            else
            {
                mainFlowForCreatorListFlow.Navigate(new CreatorListFrame(selectCreator));
            }
        }

        private void ExitBtn(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StartScreen());
        }

        private void AddRestaurant(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateRestoran(selectCreator));
        }
    }
}
