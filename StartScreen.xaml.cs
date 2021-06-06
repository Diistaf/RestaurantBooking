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
    /// Логика взаимодействия для StartScreen.xaml
    /// </summary>
    public partial class StartScreen : Page
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void LogInClick(object sender, RoutedEventArgs e)
        {
            var creators = App.db.Creators.Where(c => c.PhoneNumber == UserNameText.Text).ToList();
            var clients = App.db.Clients.Where(c => c.PhoneNumber == UserNameText.Text).ToList();
            if (creators.Count() != 0 && creators.First().Password == PasswordBoxText.Password)
            {
                NavigationService.Navigate(new CreatorListFlow(creators.First()));
            }
            else if (clients.Count() != 0 && clients.First().Password == PasswordBoxText.Password)
            {
                NavigationService.Navigate(new ClientListFlow(clients.First()));
            }
            else
            {
                ErrorLogIn.Visibility = Visibility.Visible;
            }
        }

        private void SignUpClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainFlow());
        }

        private void ShowOnPassword(object sender, MouseButtonEventArgs e)
        {
            PrevPasswordBoxText.Visibility = Visibility.Visible;
            PasswordBoxText.Visibility = Visibility.Visible;
            ShowPasswordBoxText.Visibility = Visibility.Hidden;
            PasswordIcon.Fill = (Brush)new BrushConverter().ConvertFrom("#208C7F");
        }

        private void ShowOffPassword(object sender, MouseButtonEventArgs e)
        {
            PrevPasswordBoxText.Visibility = Visibility.Hidden;
            PasswordBoxText.Visibility = Visibility.Hidden;
            ShowPasswordBoxText.Visibility = Visibility.Visible;
            PasswordIcon.Fill = (Brush)new BrushConverter().ConvertFrom("#000000");
            ShowPasswordBoxText.Text = PasswordBoxText.Password;
        }

        private void UserNameTextFocus(object sender, RoutedEventArgs e)
        {
            if (UserNameText.Text != "" || UserNameText.IsKeyboardFocused == true)
            {
                UserNameText.Opacity = 1;
            }
            else
            {
                UserNameText.Opacity = 0;
            }
        }

        private void PasswordBoxTextFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBoxText.Password != "" || PasswordBoxText.IsKeyboardFocused == true)
            {
                PasswordBoxText.Opacity = 1;
            }
            else
            {
                PasswordBoxText.Opacity = 0;
            }
        }
    }
}
