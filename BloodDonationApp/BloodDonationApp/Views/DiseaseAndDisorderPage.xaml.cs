using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CheckBox = Plugin.InputKit.Shared.Controls.CheckBox;


namespace BloodDonationApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiseaseAndDisorderPage : ContentPage
    {
        static readonly Random rnd = new Random();
        public DiseaseAndDisorderPage()
        {
            InitializeComponent();
        }
        
        //private void ChangePosition(object sender, EventArgs e)
        //{
        //    if (sender is CheckBox cb)
        //    {
        //        cb.LabelPosition = cb.IsChecked ? Plugin.InputKit.Shared.LabelPosition.After :
        //                                          Plugin.InputKit.Shared.LabelPosition.Before;
        //    }
        //}

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        //private void CheckBox_CheckChanged(object sender, EventArgs e)
        //{
        //    string status = ((Plugin.InputKit.Shared.Controls.CheckBox)sender).Text;
        //}
    }
}