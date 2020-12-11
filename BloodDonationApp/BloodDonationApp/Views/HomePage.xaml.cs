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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void ImgMenu_Tapped(object sender, EventArgs e)
        {
            GridOverlay.IsVisible = true;
            await SlMenu.TranslateTo(0, 0, 400, Easing.Linear);
        }

        private async void TapCloseMenu_Tapped(object sender, EventArgs e)
        {
            await SlMenu.TranslateTo(-250, 0, 400, Easing.Linear);
            GridOverlay.IsVisible = false;
        }

        private void TapContact_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ContactPage());
        }

        private void TapLogout_Tapped(object sender, EventArgs e)
        {
            Preferences.Set("accessToken", string.Empty);
            Preferences.Set("userName", string.Empty);
            Preferences.Set("tokenExpirationTime", 0);
            Application.Current.MainPage = new NavigationPage(new SignupPage());
        }

        private void TapDonor_Tapped(object sender, EventArgs e)
        {
            var userId = Preferences.Get("userId", string.Empty);
            Navigation.PushModalAsync(new UpdateDonorPage(userId));
        }
        private void TapRecipient_Tapped(object sender, EventArgs e)
        {
            var userId = Preferences.Get("userId", string.Empty);
            Navigation.PushModalAsync(new UpdateRecipientPage(userId));
        }
       
    }
}