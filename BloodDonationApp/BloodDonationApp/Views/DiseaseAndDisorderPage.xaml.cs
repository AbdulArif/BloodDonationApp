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
        List<string> disease = new List<string>();
        static readonly Random rnd = new Random();
        public DiseaseAndDisorderPage()
        {
            InitializeComponent();
        }
        private void ChangePosition(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            var value = checkBox.Text;
           // bool b2 = string.IsNullOrEmpty(value);
            if (!string.IsNullOrEmpty(value))
            {
                disease.Add(value);
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
    }
}