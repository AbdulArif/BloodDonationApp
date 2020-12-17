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
    public partial class SearchDonorsPage : ContentPage
    {
        public SearchDonorsPage()
        {
            InitializeComponent();
        }

        private void TapBackArrow_Tapped(object sender, EventArgs e)
        {
          Navigation.PopModalAsync();

        }
    }
}