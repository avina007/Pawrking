using PawrkingSample.Classes;
using SQLite;
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
    public partial class ParkingReservationHistory : ContentPage
    {
        string email;
        public ParkingReservationHistory()
        {
            InitializeComponent();
        }
        public ParkingReservationHistory(string e)
        {
            InitializeComponent();
            email = e;
        }

        public async void CancelButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage(email));
        }
    }
}