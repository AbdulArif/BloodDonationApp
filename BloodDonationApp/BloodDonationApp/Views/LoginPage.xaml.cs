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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
        private void TapBackArrow_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            var accessToken = Preferences.Get("accessToken", string.Empty);
            var response = await ApiService.Login(EntEmail.Text, EntPassword.Text); 
            var role = await ApiService.GetRole(EntEmail.Text, accessToken);  // GetRole
            Preferences.Set("role", role.ToString());
            if (response)
            {
                Application.Current.MainPage = new NavigationPage(new HomePage());
            }
            else
            {
                await DisplayAlert("Oops", "Something went wrong", "Cancel");
            }
        }
    }
}