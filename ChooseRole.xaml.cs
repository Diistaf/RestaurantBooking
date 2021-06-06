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
    /// Логика взаимодействия для ChooseRole.xaml
    /// </summary>
    public partial class ChooseRole : Page
    {
        public ChooseRole()
        {
            InitializeComponent();
        }

        private void RadioButtonNavigate(object sender, MouseButtonEventArgs e)
        {
            //СУПЕР МЕГА ВЕЛОСИПЕД
            Image selectImage = sender as Image;
            switch (selectImage.Name)
            {
                case "RadioButtonTrueOn":
                    Thread.Sleep(800);
                    NavigationService.Navigate(new CreateAccount(true));
                    break;
                case "RadioButtonFalseOn":
                    Thread.Sleep(800);
                    NavigationService.Navigate(new CreateAccount(false));
                    break;
            }
        }

        private void RadioButtonLoad(object sender, MouseButtonEventArgs e)
        {
            Image selectImage = sender as Image;
            switch (selectImage.Name)
            {
                case "RadioButtonTrueOff":
                    RadioButtonTrueOff.Visibility = Visibility.Hidden;
                    RadioButtonTrueOn.Visibility = Visibility.Visible;
                    break;
                case "RadioButtonFalseOff":
                    RadioButtonFalseOff.Visibility = Visibility.Hidden;
                    RadioButtonFalseOn.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
