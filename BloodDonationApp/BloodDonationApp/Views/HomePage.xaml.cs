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
        string role = Preferences.Get("role", string.Empty);
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
           var b= Preferences.Get("userName", string.Empty);
            Preferences.Clear();
           var a= Preferences.Get("userName", string.Empty);
            Application.Current.MainPage = new NavigationPage(new SignupPage());
        }
        private void TapDonor_Tapped(object sender, EventArgs e)
        {
            if(role== "Donor")
            {
                var userId = Preferences.Get("userId", string.Empty);
                Navigation.PushModalAsync(new UpdateDonorPage(userId));
            }
            else
            {
                 DisplayAlert("Alert", "You can't update Donor details !", "Cancel");
            }
        }
        private void TapRecipient_Tapped(object sender, EventArgs e)
        {
            if (role == "Recipient")
            {
                var userId = Preferences.Get("userId", string.Empty);
                Navigation.PushModalAsync(new UpdateRecipientPage(userId));
            }
            else
            {
                DisplayAlert("Alert", "You can't update Recipient details !", "Cancel");
            }
        }

        private void TapSearchDonor_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SearchDonorsPage());
        }
    }
}