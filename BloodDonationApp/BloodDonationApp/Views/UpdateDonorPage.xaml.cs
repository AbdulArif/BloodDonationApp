using BloodDonationApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BloodDonationApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateDonorPage : ContentPage
    {
        public UpdateDonorPage(string userId)
        {
            InitializeComponent();
            GetDonorAsync(userId);
        }
        public async void GetDonorAsync(string userId)
        {
            var accessToken = Preferences.Get("accessToken", string.Empty);
            //var donorList = await ApiService.GetDonorByIdAsync(userId, Settings.AccessToken);
            var donor = await ApiService.GetDonorByIdAsync(userId, accessToken);
            EntFirstName.Text = donor.FirstName;
            EntLastName.Text = donor.LastName;
            EntEmail.Text = donor.Email;
        }

        private void BtnUpdate_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnDisease_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new DiseaseAndDisorderPage());
        }
    }
}