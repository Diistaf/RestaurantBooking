using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
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
    /// Логика взаимодействия для CreateRestoran.xaml
    /// </summary>
    public partial class CreateRestoran : Page
    {
        bool isRedaction;
        Restaurant rest;
        public CreateRestoran(Creator creator)
        {
            InitializeComponent();
            isRedaction = false;
            endBorder.Text = "ОТПРАВИТЬ";
            perehod.Text = "Добавление";

            rest = new Restaurant() 
            { 
                AverageCheck = 2,
                CreatorId = creator.Id
            };
            gridPPC.DataContext = rest;
        }
        public CreateRestoran(Restaurant restaurant)
        {
            InitializeComponent();
            isRedaction = true;
            rest = restaurant;
            gridPPC.DataContext = restaurant;

            endBorder.Text = "СОХРАНИТЬ";
            perehod.Text = "Управление";

            CheckText(NameRestoranText);
            CheckText(InfoRestoranText);
            CheckText(AddressRestoranText);
            CheckText(CountPlacesRestoranText);
            CheckText(PhoneNumberRestoranText);
            CheckText(OperatingModeStartText);
            CheckText(OperatingModeEndText);
            CheckText(KitchenRestoranText);

            if (restaurant.IsTerrace == true)
            {
                TerraceTrueOn.Visibility = Visibility.Hidden;
                TerraceTrueOff.Visibility = Visibility.Visible;
                TerraceFalseOn.Visibility = Visibility.Hidden;
                TerraceFalseOff.Visibility = Visibility.Visible;
            }
            else
            {
                TerraceTrueOn.Visibility = Visibility.Hidden;
                TerraceTrueOff.Visibility = Visibility.Visible;
                TerraceFalseOn.Visibility = Visibility.Visible;
                TerraceFalseOff.Visibility = Visibility.Hidden;
            }

            if (TerraceTrueOn.Visibility == Visibility.Visible || TerraceFalseOn.Visibility == Visibility.Visible)
            {
                EllipseTerrace.Fill = (Brush)new BrushConverter().ConvertFrom("#19A964");
            }
            else
            {
                EllipseTerrace.Fill = (Brush)new BrushConverter().ConvertFrom("#D3D3D3");
            }


        }
        private void CheckText(TextBox textBox)
        {
            if (textBox.Text != null)
            {
                textBox.Opacity = 1;
            }
            else
            {
                textBox.Opacity = 0;
            }
        }

        private void CustomRadioButtonChange(object sender, MouseButtonEventArgs e)
        {
            //СУПЕР МЕГА ВЕЛОСИПЕД
            Image selectImage = sender as Image;
            switch (selectImage.Name)
            {
                case "TerraceTrueOff":
                    TerraceTrueOff.Visibility = Visibility.Hidden;
                    TerraceTrueOn.Visibility = Visibility.Visible;
                    TerraceFalseOff.Visibility = Visibility.Visible;
                    TerraceFalseOn.Visibility = Visibility.Hidden;

                    EllipseTerrace.Fill = (Brush)new BrushConverter().ConvertFrom("#19A964");

                    //тут будет код который будет менять переменную
                    break;
                case "TerraceTrueOn":
                    TerraceTrueOff.Visibility = Visibility.Visible;
                    TerraceTrueOn.Visibility = Visibility.Hidden;
                    TerraceFalseOff.Visibility = Visibility.Visible;
                    TerraceFalseOn.Visibility = Visibility.Hidden;

                    EllipseTerrace.Fill = (Brush)new BrushConverter().ConvertFrom("#D3D3D3");

                    //тут будет код который будет менять переменную
                    break;
                case "TerraceFalseOff":
                    TerraceTrueOff.Visibility = Visibility.Visible;
                    TerraceTrueOn.Visibility = Visibility.Hidden;
                    TerraceFalseOff.Visibility = Visibility.Hidden;
                    TerraceFalseOn.Visibility = Visibility.Visible;

                    EllipseTerrace.Fill = (Brush)new BrushConverter().ConvertFrom("#19A964");

                    //тут будет код который будет менять переменную
                    break;
                case "TerraceFalseOn":
                    TerraceTrueOff.Visibility = Visibility.Visible;
                    TerraceTrueOn.Visibility = Visibility.Hidden;
                    TerraceFalseOff.Visibility = Visibility.Visible;
                    TerraceFalseOn.Visibility = Visibility.Hidden;

                    EllipseTerrace.Fill = (Brush)new BrushConverter().ConvertFrom("#D3D3D3");

                    //тут будет код который будет менять переменную
                    break;
            }
        }

        private void Focus(TextBox textbox)
        {
            if (textbox.Text != "" || textbox.IsKeyboardFocused == true)
            {
                textbox.Opacity = 1;
            }
            else
            {
                textbox.Opacity = 0;
            }
        }

        private void StringTextChange(TextBox textbox, Ellipse ellipse)
        {
            if (textbox.Text != "")
            {
                ellipse.Fill = (Brush)new BrushConverter().ConvertFrom("#19A964");
            }
            else
            {
                ellipse.Fill = (Brush)new BrushConverter().ConvertFrom("#D3D3D3");
            }
        }

        private void PrevNameRestoranFocus(object sender, RoutedEventArgs e)
        {
            Focus(NameRestoranText);
        }

        private void NameRestoranTextTextChanged(object sender, TextChangedEventArgs e)
        {
            Focus(NameRestoranText);
            StringTextChange(NameRestoranText, EllipseNameRestoran);
        }

        private void InfoRestoranTextFocus(object sender, RoutedEventArgs e)
        {
            Focus(InfoRestoranText);
        }

        private void InfoRestoranTextTextChanged(object sender, TextChangedEventArgs e)
        {
            Focus(InfoRestoranText);
            StringTextChange(InfoRestoranText, EllipseInfoRestoran);
        }

        private void AddressRestoranTextTextChanged(object sender, TextChangedEventArgs e)
        {
            Focus(AddressRestoranText);
            StringTextChange(AddressRestoranText, EllipseAddressRestoran);
        }

        private void AddressRestoranTextFocus(object sender, RoutedEventArgs e)
        {
            Focus(AddressRestoranText);
        }

        private void CountPlacesRestoranTextTextChanged(object sender, TextChangedEventArgs e)
        {
            Focus(CountPlacesRestoranText);
            StringTextChange(CountPlacesRestoranText, EllipseCountPlaces);
        }

        private void CountPlacesRestoranTextFocus(object sender, RoutedEventArgs e)
        {
            Focus(CountPlacesRestoranText);
        }

        private void ImageRestoranTextTextChanged(object sender, TextChangedEventArgs e)
        {
            Focus(ImageRestoranText);
            StringTextChange(ImageRestoranText, EllipseImageRestoran);
        }

        private void ImageRestoranTextFocus(object sender, RoutedEventArgs e)
        {
            Focus(ImageRestoranText);
        }

        private void PhoneNumberRestoranTextTextChanged(object sender, TextChangedEventArgs e)
        {
            Focus(PhoneNumberRestoranText);
            StringTextChange(PhoneNumberRestoranText, EllipsePhoneNumber);
        }

        private void PhoneNumberRestoranTextFocus(object sender, RoutedEventArgs e)
        {
            Focus(PhoneNumberRestoranText);
        }

        private void KitchenRestoranTextTextChanged(object sender, TextChangedEventArgs e)
        {
            Focus(KitchenRestoranText);
            StringTextChange(KitchenRestoranText, EllipseKitchen);
        }

        private void KitchenRestoranTextFocus(object sender, RoutedEventArgs e)
        {
            Focus(KitchenRestoranText);
        }

        private void OperatingModeStartTextTextChanged(object sender, TextChangedEventArgs e)
        {
            if (OperatingModeEndText.Text != "" && OperatingModeStartText.Text != "")
            {
                EllipseOperatingMode.Fill = (Brush)new BrushConverter().ConvertFrom("#19A964");
            }
            else
            {
                EllipseOperatingMode.Fill = (Brush)new BrushConverter().ConvertFrom("#D3D3D3");
            }
        }

        private void OperatingModeStartTextFocus(object sender, RoutedEventArgs e)
        {
            Focus(OperatingModeStartText);
        }

        private void OperatingModeEndTextTextChanged(object sender, TextChangedEventArgs e)
        {
            if (OperatingModeEndText.Text != "" && OperatingModeStartText.Text != "")
            {
                EllipseOperatingMode.Fill = (Brush)new BrushConverter().ConvertFrom("#19A964");
            }
            else
            {
                EllipseOperatingMode.Fill = (Brush)new BrushConverter().ConvertFrom("#D3D3D3");
            }
        }

        private void OperatingModeEndTextFocus(object sender, RoutedEventArgs e)
        {
            Focus(OperatingModeEndText);
        }

        private void Border_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (isRedaction)
            {
                var result = App.db.Restaurants.Where(r => r.Id == rest.Id).FirstOrDefault();
                if (result != null)
                {
                    App.db.Restaurants.Attach(rest);
                    App.db.Entry(rest).State = EntityState.Modified;
                    App.db.SaveChanges();
                }
                NavigationService.GoBack();
            }
            else
            {
                if (rest != null)
                {
                    App.db.Restaurants.Add(rest);
                    App.db.SaveChanges();
                }
            }
        }

        private void BackStackPanel(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ImageOpen(object sender, RoutedEventArgs e)
        {
            //        OpenFileDialog openFileDialog = new OpenFileDialog();
            //        if (openFileDialog.ShowDialog() == true)
            //        {
            //            var path = openFileDialog.FileName;

            //            string appFolderPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            //            string resourcesFolderPath = System.IO.Path.Combine(
            //Directory.GetParent(appFolderPath).Parent.FullName, "Images");

            //            File.Copy(resourcesFolderPath, path);
        }
    }
}
