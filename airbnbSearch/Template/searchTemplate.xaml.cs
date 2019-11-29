using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace airbnbSearch.Template
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class searchTemplate : DataTemplate
    {
        public searchTemplate()
        {
            InitializeComponent();
        }

        private void Delete_item(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var journey= menuItem.BindingContext as Model.journey;

            var page = (ContentPage)App.Current.MainPage;//.Navigation.NavigationStack.FirstOrDefault(x=>x.GetType()==typeof(MainPage));
            if (page != null)
            {
                var mainPage = (MainPage)page;
                mainPage.deleteData(journey);
            }
        }
    }
}