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
        string accessToken = Preferences.Get("accessToken", string.Empty);
        string userName = Preferences.Get("userName", string.Empty);
        //static readonly Random rnd = new Random();
        public DiseaseAndDisorderPage(string DonorId)
        {
            InitializeComponent();
            GetAllDisease();
        }

        private async void GetAllDisease()
        {
            var diseaseList = await ApiService.GetDiseaseAsync(accessToken);
            int no = diseaseList.Count();
                ChkOption0.Text = diseaseList[0].DiseaseName;
                ChkOption1.Text = diseaseList[1].DiseaseName;
                ChkOption2.Text = diseaseList[2].DiseaseName;
                ChkOption3.Text = diseaseList[3].DiseaseName;
                ChkOption4.Text = diseaseList[4].DiseaseName;

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
            diseases.Clear();
            //Navigation.PopAsync();
        }

        private async void BtnSaveDisease_Clicked(object sender, EventArgs e)
        {
            DateTime date = DateTime.UtcNow;
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
            await DisplayAlert("Success!", "Donor details saved successfully", "OK");
            await Navigation.PushModalAsync(new HomePage());
        }
    }
}