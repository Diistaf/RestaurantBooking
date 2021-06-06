using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для ClientListFlow.xaml
    /// </summary>
    public partial class ClientListFlow : Page
    {
        Client selectClient;
        bool filterRightNow = false;
        bool filterTerrace = false;
        bool filterUntilMorning = false;
        int valueSortCost = 0;
        int valueSortName = 0;
        int valueSortAddress = 0;
        int valueSortTime = 0;
        int valueSortNumberPlaces = 0;
        int valueSortRating = 0;

        public ClientListFlow(Client client)
        {
            selectClient = client;
            InitializeComponent();
            clientName.Text = client.Name.Substring(0, clientName.Text.Length).ToUpper();
            DataContext = client;
            listRestorans.ItemsSource = App.db.Restaurants.ToList();
            WeatherLoad();
        }
        public void WeatherLoad()
        {
            string url = "http://api.openweathermap.org/data/2.5/weather?q=Kazan&units=metric&appid=5e9ec2f8d2c09898bc3f5efce943d7f8";

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            string response;
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }

            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(response);
            Weather.DataContext = weatherResponse;
            //IconWeather.DataContext = "http://openweathermap.org/img/wn/" + weatherResponse.Weather[0].Icon + "@2x.png";
            switch(weatherResponse.Weather[0].Icon)
            {
                case "01d":
                    IconWeather.DataContext = "Assets/sunny.png";
                    break;
                case "02d":
                    IconWeather.DataContext = "Assets/clear-cloudy.png";
                    break;
                case "03d":
                    IconWeather.DataContext = "Assets/cloudy.png";
                    break;
                case "04d":
                    IconWeather.DataContext = "Assets/mostly-cloudy.png";
                    break;
                case "09d":
                    IconWeather.DataContext = "Assets/showers.png";
                    break;
                case "10d":
                    IconWeather.DataContext = "Assets/drizzle.png";
                    break;
                case "11d":
                    IconWeather.DataContext = "Assets/thunderstroms.png";
                    break;
                case "13d":
                    IconWeather.DataContext = "Assets/snow.png";
                    break;
                case "50d":
                    IconWeather.DataContext = "Assets/foggy.png";
                    break;

                default:
                    if(weatherResponse.Main.Temp >= 0)
                    {
                        IconWeather.DataContext = "Assets/hot.png";
                    }
                    else
                    {
                        IconWeather.DataContext = "Assets/cold.png";
                    }
                    break;
            }
        }

        private void ClickOnComboBoxFilterRightNow(object sender, MouseButtonEventArgs e)
        {
            var contenerComboBox = sender as Grid;
            var comboBoxChecked = (contenerComboBox.Children[1] as Image);
            if (comboBoxChecked.Visibility == Visibility.Hidden)
            {
                comboBoxChecked.Visibility = Visibility.Visible;
                filterRightNow = true;
            }
            else
            {
                comboBoxChecked.Visibility = Visibility.Hidden;
                filterRightNow = false;
            }
            UpdListFilter();
        }

        private void ClickOnComboBoxFilterTerrace(object sender, MouseButtonEventArgs e)
        {
            var contenerComboBox = sender as Grid;
            var comboBoxChecked = (contenerComboBox.Children[1] as Image);
            if (comboBoxChecked.Visibility == Visibility.Hidden)
            {
                comboBoxChecked.Visibility = Visibility.Visible;
                filterTerrace = true;
            }
            else
            {
                comboBoxChecked.Visibility = Visibility.Hidden;
                filterTerrace = false;
            }
            UpdListFilter();
        }

        private void ClickOnComboBoxFilterUntilMorning(object sender, MouseButtonEventArgs e)
        {
            var contenerComboBox = sender as Grid;
            var comboBoxChecked = (contenerComboBox.Children[1] as Image);
            if (comboBoxChecked.Visibility == Visibility.Hidden)
            {
                comboBoxChecked.Visibility = Visibility.Visible;
                filterUntilMorning = true;
            }
            else
            {
                comboBoxChecked.Visibility = Visibility.Hidden;
                filterUntilMorning = false;
            }
            UpdListFilter();
        }

        private void OpenClientProfile(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientBooking(selectClient));
        }

        private void UpdListFilter()
        {
            List<Restaurant> rest = App.db.Restaurants.ToList();

            if (FilterSearch.Text != "")
            {
                rest = rest.Where(r => r.Title.ToLower().Contains(FilterSearch.Text.ToLower())
                || r.Kitchen.ToLower().Contains(FilterSearch.Text.ToLower())
                || r.Keywords.ToLower().Contains(FilterSearch.Text.ToLower())).ToList();
            }
            if (FilterCountPerson.Text != "")
            {
                rest = rest.Where(r => r.NumberPlaces >= Convert.ToInt32(FilterCountPerson.Text)).ToList();
            }
            if (TimeBookingBox.Text != "")
            {
                TimeSpan ts = TimeSpan.Parse(TimeBookingBox.Text);
                rest = rest.Where(r => (r.EndWork < new TimeSpan(6, 0, 0) ? r.EndWork > ts : r.EndWork < ts) && r.StartWork < ts).ToList();
            }
            if (filterRightNow)
            {
                rest = rest.Where(r => (r.EndWork < new TimeSpan(6, 0, 0) ? r.EndWork < DateTime.Now.TimeOfDay : r.EndWork > DateTime.Now.TimeOfDay) && r.StartWork < DateTime.Now.TimeOfDay).ToList();
            }
            if (filterTerrace)
            {
                rest = rest.Where(r => r.IsTerrace == true).ToList();
            }
            if (filterUntilMorning)
            {
                rest = rest.Where(r => r.EndWork < new TimeSpan(6, 0, 0) && r.EndWork > new TimeSpan(0, 0, 0)).ToList();
            }

            listRestorans.ItemsSource = null;
            listRestorans.ItemsSource = rest;
        }

        private void listRestorans_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listRestorans.SelectedItem != null)
            {
                NavigationService.Navigate(new RestikInfo(selectClient, listRestorans.SelectedItem as Restaurant));
                listRestorans.SelectedItem = null;
            }
        }

        private void ReloadList(object sender, RoutedEventArgs e)
        {
            TimeFilterColumn.Width = new GridLength(90);
            TimeBookingBorder.Width = 53;
            FilterSearch.Text = "";
            FilterCountPerson.Text = "";
            TimeBookingBox.Text = "";
            filterRightNow = false;
            filterTerrace = false;
            filterUntilMorning = false;
            valueSortCost = 0;
            valueSortName = 0;
            valueSortAddress = 0;
            valueSortTime = 0;
            valueSortNumberPlaces = 0;
            valueSortRating = 0;
            UpdListFilter();
            HideIconSord();
        }

        private void FilterKeyUp(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                UpdListFilter();
            }
        }

        void HideIconSord()
        {
            costSortDown.Visibility = Visibility.Hidden;
            costSortUp.Visibility = Visibility.Hidden;
            nameSortDown.Visibility = Visibility.Hidden;
            nameSortUp.Visibility = Visibility.Hidden;
            addressSortDown.Visibility = Visibility.Hidden;
            addressSortUp.Visibility = Visibility.Hidden;
            timeSortDown.Visibility = Visibility.Hidden;
            timeSortUp.Visibility = Visibility.Hidden;
            numberPlacesSortDown.Visibility = Visibility.Hidden;
            numberPlacesSortUp.Visibility = Visibility.Hidden;
            ratingSortDown.Visibility = Visibility.Hidden;
            ratingSortUp.Visibility = Visibility.Hidden;
        }

        private void SortListRestorans(ref int value, string title, System.Windows.Shapes.Path pathDown, System.Windows.Shapes.Path pathUp)
        {
            value++;
            if (value == 3)
            {
                value = 0;
            }

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(listRestorans.ItemsSource);
            view.SortDescriptions.Clear();
            switch (value)
            {
                case 0:
                    break;
                case 1:
                    view.SortDescriptions.Add(new SortDescription(title, ListSortDirection.Ascending));
                    pathDown.Visibility = Visibility.Visible;
                    break;
                case 2:
                    view.SortDescriptions.Add(new SortDescription(title, ListSortDirection.Descending));
                    pathUp.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void CostSort(object sender, MouseButtonEventArgs e)
        {
            HideIconSord();
            valueSortName = 0;
            valueSortAddress = 0;
            valueSortTime = 0;
            valueSortNumberPlaces = 0;
            valueSortRating = 0;

            SortListRestorans(ref valueSortCost, "AverageCheck", costSortDown, costSortUp);
        }

        private void NameSort(object sender, MouseButtonEventArgs e)
        {
            HideIconSord();
            valueSortCost = 0;
            valueSortAddress = 0;
            valueSortTime = 0;
            valueSortNumberPlaces = 0;
            valueSortRating = 0;

            SortListRestorans(ref valueSortName, "Title", nameSortDown, nameSortUp);
        }

        private void AddressSort(object sender, MouseButtonEventArgs e)
        {
            HideIconSord();
            valueSortCost = 0;
            valueSortName = 0;
            valueSortTime = 0;
            valueSortNumberPlaces = 0;
            valueSortRating = 0;

            SortListRestorans(ref valueSortAddress, "Address", addressSortDown, addressSortUp);
        }

        private void TimeSort(object sender, MouseButtonEventArgs e)
        {
            HideIconSord();
            valueSortCost = 0;
            valueSortName = 0;
            valueSortAddress = 0;
            valueSortNumberPlaces = 0;
            valueSortRating = 0;

            SortListRestorans(ref valueSortTime, "EndWork", timeSortDown, timeSortUp);
        }

        private void NumberPlacesSort(object sender, MouseButtonEventArgs e)
        {
            HideIconSord();
            valueSortCost = 0;
            valueSortName = 0;
            valueSortAddress = 0;
            valueSortTime = 0;
            valueSortRating = 0;

            SortListRestorans(ref valueSortNumberPlaces, "NumberPlaces", numberPlacesSortDown, numberPlacesSortUp);
        }

        private void RatingSort(object sender, MouseButtonEventArgs e)
        {
            HideIconSord();
            valueSortCost = 0;
            valueSortName = 0;
            valueSortAddress = 0;
            valueSortTime = 0;
            valueSortNumberPlaces = 0;

            SortListRestorans(ref valueSortRating, "Rating", ratingSortDown, ratingSortUp);
        }

        private void TimeBookingBorderFilter(object sender, MouseButtonEventArgs e)
        {
            TimeFilterColumn.Width = new GridLength(166);
            TimeBookingBorder.Width = 129;
            TimeBookingBox.Visibility = Visibility.Visible;
        }

        private void TimeBookingBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                UpdListFilter();
                TimeFilterColumn.Width = new GridLength(90);
                TimeBookingBorder.Width = 53;
                TimeBookingBox.Visibility = Visibility.Hidden;
            }
        }
    }
}
