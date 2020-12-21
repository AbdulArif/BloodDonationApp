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
using CheckBox = Plugin.InputKit.Shared.Controls.CheckBox;


namespace BloodDonationApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiseaseAndDisorderPage : ContentPage
    {
        List<string> diseases = new List<string>();
        string DonorId = Preferences.Get("userId", string.Empty);
        //static readonly Random rnd = new Random();
        public DiseaseAndDisorderPage(string DonorId)
        {
            InitializeComponent();
        }
        // Check Box value store in a disease List 
        private void ChangePosition(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            var value = checkBox.Text;
            if (!string.IsNullOrEmpty(value))
            {
                diseases.Add(value);
            }
            //if (sender is CheckBox cb)
            //{
            //    cb.LabelPosition = cb.IsChecked ? Plugin.InputKit.Shared.LabelPosition.After :
            //                                      Plugin.InputKit.Shared.LabelPosition.Before;
            //}
        }

            private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void BtnCancelDisease_Clicked(object sender, EventArgs e)
        {
            //Navigation.PopModalAsync();
            Navigation.PushModalAsync(new DiseaseAndDisorderPage(DonorId));
        }

        private async void BtnSaveDisease_Clicked(object sender, EventArgs e)
        {
            DateTime date = DateTime.UtcNow;
            var accessToken = Preferences.Get("accessToken", string.Empty);
            var userName = Preferences.Get("userName", string.Empty);
            //Detele API service call DeleteDonorHealthAsync
            await ApiService.DeleteDonorHealthAsync(DonorId, accessToken);
            //disease.Count
            foreach (var disease in diseases)
            {
                Console.WriteLine(disease);
                var donorHealth = new DonorHealth
            {
                DonorId = DonorId,
                Disease = disease,
                AddedBy= userName,
                AddedDate = date,
                UpdatedBy= userName,
                UpdatedDate = date
            };
            await ApiService.PostDonorHealtAsync(donorHealth, accessToken);
            }
            diseases.Clear();
            Console.WriteLine(diseases);
            await DisplayAlert("Success", "Donor details saved Successfully", "OK");
            await Navigation.PushModalAsync(new HomePage());
        }
    }
}