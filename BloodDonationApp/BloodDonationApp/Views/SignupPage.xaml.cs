﻿using BloodDonationApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RadioButtonGroupView = Plugin.InputKit.Shared.Controls.RadioButtonGroupView;
using RadioButton = Plugin.InputKit.Shared.Controls.RadioButton;

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
                    var userId = Preferences.Get("userId", string.Empty);
                   // Preferences.Set("role", role);                    
                    if (role == "Donor")
                    {                       
                        //await Navigation.PushModalAsync(new UpdateDonorPage(userId));
                        await Navigation.PushAsync(new UpdateDonorPage(userId));
                    }
                    if (role == "Recipient")
                    {
                        await Navigation.PushModalAsync(new UpdateRecipientPage(userId));
                    }

                }
                else
                {
                    await DisplayAlert("Oops!", "User already registered ", "Cancel");
                }
            }

        }
        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }

        private void RadioButtonGroupView_SelectedItemChanged(object sender, EventArgs e)
        {
            RadioButtonGroupView radioButtonGroupView = sender as RadioButtonGroupView;
            var index = radioButtonGroupView.SelectedIndex;
            if (index == 0)
            {
                role = "Donor";
            }
            else
            {
                role = "Recipient";
            }
            Console.WriteLine(role);
        }

        //private void Roles_CheckedChanged(object sender, CheckedChangedEventArgs e)
        //{
        //    RadioButton button = sender as RadioButton;
        //    //animalLabel.Text = $"You have chosen: {button.Text}";
        //    role = button.Text;
        //}
    }
}