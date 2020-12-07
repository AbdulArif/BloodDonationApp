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
    public partial class UpdateDonorPage : ContentPage
    {
        public UpdateDonorPage()
        {
            InitializeComponent();
        }

        private void BtnSignUp_Clicked(object sender, EventArgs e)
        {

        }

        private void BtnDisease_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new DiseaseAndDisorderPage());
        }
    }
}