using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для SavePasswordPage.xaml
    /// </summary>
    public partial class SavePasswordPage : Page
    {
        Client selectClient;
        Creator selectCreator;

        public SavePasswordPage(object user)
        {
            if(user is Client)
            {
                selectClient = user as Client;
                DataContext = selectClient;
            }
            else if (user is Creator)
            {
                selectCreator = user as Creator;
                DataContext = selectCreator;
            }
            InitializeComponent();
        }

        private void SavePasswordClick(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.Filter = "Text documents (.txt)|*.txt|All Files (*.*)|*.*";
            dialog.FileName = "Password.txt";
            if (dialog.ShowDialog() == true)
            {
                File.WriteAllText(dialog.FileName, PasswordText.Text);
            }
        }

        private void SavePassword_Click(object sender, RoutedEventArgs e)
        {
            if (selectClient != null)
            {
                NavigationService.Navigate(new ClientListFlow(selectClient));
            }
            else
            {
                NavigationService.Navigate(new CreatorListFlow(selectCreator));
            }
        }
    }
}
