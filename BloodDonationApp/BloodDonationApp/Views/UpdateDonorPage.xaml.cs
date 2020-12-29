using BloodDonationApp.Models;
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
            var donor = await ApiService.GetDonorByIdAsync(userId, accessToken);
            EntFirstName.Text = donor.FirstName;
            EntLastName.Text = donor.LastName;
            EntEmail.Text = donor.Email;
            EntPhoneNumber.Text = donor.PhoneNumber;
            EntBloodGroup.Text = (string)donor.BloodGroup;
            EntDistrict.Text = (string)donor.District;
            EntCity.Text = (string)donor.City;
            EntState.Text = (string)donor.State;
            EntPIN.Text = (string)donor.PIN;
            EntNearByHospitals.Text = (string)donor.NearByHospitals;
            EntBirthYear.Text = (string)donor.BirthYear;
            //BtnDisease.Text = (string)donor.ChronicDisease;
        }

        private async void BtnUpdateDonor_Clicked(object sender, EventArgs e)
        {
            DateTime date = DateTime.UtcNow;
            int currentYear = date.Year;
            var accessToken = Preferences.Get("accessToken", string.Empty);
            var userId = Preferences.Get("userId", string.Empty);
            int birthYear = Int32.Parse(EntBirthYear.Text);
            int age = currentYear - birthYear;
            var donor = new Donor
            {
                DonorId = userId,
                Email = EntEmail.Text,
                FirstName = EntFirstName.Text,
                LastName = EntLastName.Text,
                PhoneNumber = EntPhoneNumber.Text,
                BloodGroup = EntBloodGroup.Text,
                District = EntDistrict.Text,
                City = EntCity.Text,
                State = EntState.Text,
                PIN = EntPIN.Text,
                NearByHospitals = EntNearByHospitals.Text,
                BirthYear = EntBirthYear.Text,
                Age= age.ToString(),
                //Disease = EntDisease.Text,
                UpdatedDate = date
            };
            await ApiService.PutDonorAsync(donor, accessToken);
            await DisplayAlert("Success!", "Donor details saved successfully", "OK");
            await Navigation.PushModalAsync(new HomePage());
        }
        //private void BtnDisease_Clicked(object sender, EventArgs e)
        //{
        //    Navigation.PushModalAsync(new DiseaseAndDisorderPage());
        //}
        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void BtnCancelDonor_Clicked(object sender, EventArgs e)
        {
            var userId = Preferences.Get("userId", string.Empty);
            GetDonorAsync(userId);
        }
    }
}