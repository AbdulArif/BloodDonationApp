using BloodDonationApp.Models;
using BloodDonationApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BloodDonationApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchDonorsPage : ContentPage
    {
        public static ObservableCollection<Donor> DonorsCollection;
        public SearchDonorsPage()
        {
            InitializeComponent();
            DonorsCollection = new ObservableCollection<Donor>();
            GetAllDonors();
        }

        private async void GetAllDonors()
        {
          var accessToken =  Preferences.Get("accessToken", string.Empty);
          var donors =  await ApiService.GetAllDonor(accessToken);
            foreach(var donor in donors)
            {
                DonorsCollection.Add(donor);
            }
            DonorListView.ItemsSource = DonorsCollection;
        }

        private void TapBackArrow_Tapped(object sender, EventArgs e)
        {
          Navigation.PopModalAsync();

        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            DonorListView.ItemsSource = DonorsCollection
                        .Where(c => c.BloodGroup.ToLower().Contains(e.NewTextValue.ToLower())
                                 || c.City.ToLower().Contains(e.NewTextValue.ToLower())
                                 || c.FullName.ToLower().Contains(e.NewTextValue.ToLower())
                               );

        }

        //private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        //{
        //    string search = SearchBar.Text;
        //    //SearchDonorAsync(search);         
        //}

        //private async void SearchDonorAsync(string search)
        //{
        //    var accessToken = Preferences.Get("accessToken", string.Empty);
        //    var donorList = await ApiService.SearchDonor(search, accessToken);
        //}
    }
}