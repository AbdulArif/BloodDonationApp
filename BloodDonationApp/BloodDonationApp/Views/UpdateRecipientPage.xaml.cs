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
    public partial class UpdateRecipientPage : ContentPage
    {
        public UpdateRecipientPage(string userId)
        {
            InitializeComponent();
            GetRecipientAsync(userId);
        }
        public async void GetRecipientAsync(string userId)
        {
            var accessToken = Preferences.Get("accessToken", string.Empty);
            var recipient = await ApiService.GetRecipientByIdAsync(userId, accessToken);
            EntFirstName.Text = recipient.FirstName;
            EntLastName.Text = recipient.LastName;
            EntEmail.Text = recipient.Email;
            EntPhoneNumber.Text= (string)recipient.PhoneNumber;
            //EntBloodGroup.Text = recipient.BloodGroup;
            EntDistrict.Text= (string)recipient.District;
            EntCity.Text = (string)recipient.City;
            EntState.Text = (string)recipient.State;
            EntPIN.Text = (string)recipient.PIN;
            EntOrganizationName.Text = (string)recipient.OrganizationName;
        }
        private async void BtnUpdateRecipient_Clicked(object sender, EventArgs e)
        {
            DateTime date = DateTime.UtcNow;
            var accessToken = Preferences.Get("accessToken", string.Empty);
            var userId = Preferences.Get("userId", string.Empty);
            var recipient = new Recipient
            {
                RecipientId = userId,
                Email = EntEmail.Text,
                FirstName = EntFirstName.Text,
                LastName = EntLastName.Text,
                PhoneNumber = EntPhoneNumber.Text,
                //BloodGroup = EntBloodGroup.Text,
                District = EntDistrict.Text,
                City = EntCity.Text,
                State = EntState.Text,
                PIN = EntPIN.Text,
                OrganizationName = EntOrganizationName.Text,
                UpdatedDate = date
            };
            await ApiService.PutRecipientAsync(recipient, accessToken);

            await Navigation.PushModalAsync(new HomePage());
        }

        private void BtnCancelRecipient_Clicked(object sender, EventArgs e)
        {
            var userId = Preferences.Get("userId", string.Empty);
            GetRecipientAsync(userId);
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}