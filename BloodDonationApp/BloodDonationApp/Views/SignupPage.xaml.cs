using BloodDonationApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BloodDonationApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
    {
        string role;
        public SignupPage()
        {
            InitializeComponent();
        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            if (!EntPassword.Text.Equals(EntConfirmPassword.Text))
            {
                await DisplayAlert("Password mismatch", "Password and confirm password is not match", "Cancel");
            }
            else
            {
                
                var response = await ApiService.RegisterUser(EntEmail.Text, EntFirstName.Text, EntLastName.Text, role, EntPassword.Text,EntConfirmPassword.Text);
                if (response)
                {
                    await DisplayAlert("HI", "Your account has been created ", "OK");
                    if (role == "Donor")
                    {
                        await Navigation.PushModalAsync(new UpdateDonorPage());
                    }
                    if (role == "Recipient")
                    {
                        await Navigation.PushModalAsync(new UpdateRecipientPage());
                    }

                }
                else
                {
                    await DisplayAlert("Opps", "User already registered ", "Cancel");
                }
            }

        }
        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }

        private void Roles_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            //animalLabel.Text = $"You have chosen: {button.Text}";
            role = button.Text;
        }
    }
}