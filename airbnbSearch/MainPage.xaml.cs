using airbnbSearch.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace airbnbSearch
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<journey> _listOfStrings;
        public ObservableCollection<journey> ListOfStrings
        {
            get { return _listOfStrings; }
            set
            {
                _listOfStrings = value;

                OnPropertyChanged(nameof(ListOfStrings));
            }
        }


        public MainPage()
        {
            InitializeComponent();

            header.Text = "Recent Searches";

            listData.ItemsSource = getData();

        }

        private IEnumerable<journey> getData(string searchText = null)
        {
            ListOfStrings =  new ObservableCollection<journey>(new List<journey>
            {
                new journey
                {
                    id=1,
                    cityName="Bhopal",
                    country = "India",
                    startDate = new DateTime(2019, 11, 05),
                    endDate = new DateTime(2019, 11, 10)
                },
                new journey
                {
                    id=2,
                    cityName="Indore",
                    country = "India",
                    startDate = new DateTime(2019, 10, 15),
                    endDate = new DateTime(2019, 10, 30)
                },
                new journey
                {
                    id=3,
                    cityName="Gwalior",
                    country = "India",
                    startDate = new DateTime(2019, 11, 25),
                    endDate = new DateTime(2019, 12, 15)
                },
                new journey
                {
                    id=4,
                    cityName="Delhi",
                    country = "India",
                    startDate = new DateTime(2019, 11, 29),
                    endDate = new DateTime(2019, 12, 10)
                },
            });

            if(string.IsNullOrWhiteSpace(searchText)) return ListOfStrings;

            return ListOfStrings.Where(c => c.cityName.ToLower().Contains(searchText)); 
        }

        private async void pull_refresh(object sender, EventArgs e)
        {
            await Task.Delay(2000);
            listData.ItemsSource = getData();
            listData.EndRefresh();

        }

        public void deleteData(journey item) 
        {
            ListOfStrings.Remove(item);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

            listData.ItemsSource = getData((e.NewTextValue).ToLower());
            
        }
    }
}
