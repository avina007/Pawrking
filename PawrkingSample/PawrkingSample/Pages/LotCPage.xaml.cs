using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PawrkingSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LotCPage : ContentPage
    {
        
        public LotCPage()
        {
            InitializeComponent();
             
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LotCProgressBar.Progress = .75;
        }

        public async void ReserveButton_Clicked(object sender, EventArgs e)
        {
           // await Navigation.PushAsync(new MainPage());
        }

        public async void CancelButton_Clicked(object sender, EventArgs e)
        {
             await Navigation.PushAsync(new SeeAllLotsPage());
        }

    }
}