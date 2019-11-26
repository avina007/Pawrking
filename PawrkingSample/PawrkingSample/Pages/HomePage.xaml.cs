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
    public partial class HomePage : ContentPage
    {
        Student user;

        public HomePage()
        {
            InitializeComponent();
        }
        public HomePage(string email)
        {
            InitializeComponent();
            using (SQLiteConnection conn = new SQLiteConnection(App.FilePath))
            {
                conn.CreateTable<Student>();
                user = conn.FindWithQuery<Student>("select * from Student where Id=?", email);
            }
        }
        /*
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if ( user.isAdmin == false)
            {
                CreateParkingLot_Button.IsVisible = false;
            }
            else
            {
                SpacingLabel.IsVisible = true;
            }
        }*/
        
        private async void CreateLot_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateParkingLot());
        }/*
        private async void SeeAllLotsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SeeAllLotsPage(user.Email));
        }

        private async void SeeParkingReservationsButton_Clicked(object sender, EventArgs e)
        {//change when i make parking reservations history page
            await Navigation.PushAsync(new ParkingReservationHistory(user.Email));
        }*/
        
        private async void LogOutButton_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new MainPage());
        }
    }
}