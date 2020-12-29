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
        string userName = Preferences.Get("userName", string.Empty);
        string userId = Preferences.Get("userId", string.Empty);
        public HomePage()
        {
            InitializeComponent();
            Blink();
            LblUserName.Text = userName;
        }

        private async void ImgMenu_Tapped(object sender, EventArgs e)
        {
            GridOverlay.IsVisible = true;
            LblWelcome.IsVisible = false;
            await SlMenu.TranslateTo(0, 0, 400, Easing.Linear);
        }

        private async void TapCloseMenu_Tapped(object sender, EventArgs e)
        {
            await SlMenu.TranslateTo(-250, 0, 400, Easing.Linear);
            GridOverlay.IsVisible = false;
            LblWelcome.IsVisible = true;
        }

        private void TapContact_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ContactPage());
        }

        private void TapLogout_Tapped(object sender, EventArgs e)
        {
           //var b= Preferences.Get("userName", string.Empty);
            Preferences.Clear();
            Application.Current.MainPage = new NavigationPage(new SignupPage());
        }
        private void TapDonor_Tapped(object sender, EventArgs e)
        {
            if(role== "Donor")
            {
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
                //var userId = Preferences.Get("userId", string.Empty);
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

        private void TapUpdateDisease_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new DiseaseAndDisorderPage(userId));
        }
        private async void Blink()
        {
            while (true)
            {
                await Task.Delay(500);
                LblWelcome.TextColor = LblWelcome.TextColor == Color.Red ? Color.Green : Color.Red;
            }
        }


        //private void MenuTapped(object sender, ItemTappedEventArgs e)
        //{
        //    // TitleTxt.Text = ((sender as StackLayout).BindingContext as Menu).Title;
        //    var itm = (Menu)e.Item;   //or, e.Item as Menu

        //    var t1 = itm.Title;
        //    TitleTxt.Text = t1;

        //    switch (t1)
        //    {
        //        case "Update Donor":
        //            //Navigation.PushModalAsync(new AddTask()); //<-- has no Back button   //Navigation.PushAsync(new AddTask());  --> Has Back button
        //            Navigation.PushAsync(new UpdateDonorPage(userId));
        //            break;

        //        case "Update Recipient":
        //            Navigation.PushAsync(new UpdateRecipientPage(userId));
        //            break;

        //        case "Update Disease":
        //            Navigation.PushAsync(new DiseaseAndDisorderPage(userId));
        //            break;

        //        case "Search Donor":
        //            Navigation.PushAsync(new SearchDonorsPage());
        //            break;

        //        case "Contact":
        //            Navigation.PushAsync(new ContactPage());
        //            break;

        //        //case "Summary Report":
        //        //    Navigation.PushAsync(new SummaryReport());
        //        //    break;
        //        //case "Change Password":
        //        //    Navigation.PushAsync(new ChangePassword());
        //        //    break;

        //        case "Logout":
        //            // Navigation.PushAsync(new Logout());
        //            break;

        //        case "Log Out":
        //            Preferences.Clear();
        //            App.Current.MainPage = new NavigationPage(new LoginPage());
        //            break;

        //        default:
        //            Console.WriteLine("Default case");
        //            break;
        //    }
        //}

        //public class Menu
        //{
        //    public string Title { get; set; }
        //    public string Icon { get; set; }
        //    //public string Detail { get; set; }
        //}

        // Hide();
    }
    }
