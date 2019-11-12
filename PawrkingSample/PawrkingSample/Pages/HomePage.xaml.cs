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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void SeeAllLotsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SeeAllLotsPage());
        }

        private async void SeeParkingReservationsButton_Clicked(object sender, EventArgs e)
        {//change when i make parking reservations history page
            await Navigation.PushAsync(new ParkingReservationHistory());
        }

        private async void LogOutButton_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new MainPage());
        }
    }
}