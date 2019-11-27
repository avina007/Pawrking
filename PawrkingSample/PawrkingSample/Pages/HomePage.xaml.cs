using PawrkingSample.Classes;
using PawrkingSample.ClassPages;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PawrkingSample.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        HomePageVM homePageVM;
        
        public HomePage(string email)
        {
           InitializeComponent();
            homePageVM = new HomePageVM(email);
            BindingContext = homePageVM;
            
            Users u = Task.Run( ()=> FirebaseHelper.GetUser(email)).Result;
            
            if (u.isAdmin)
            {
                CreateParkingLot_Button.IsVisible = true;
            }
            else
            {
                CreateParkingLot_Button.IsVisible = false;
                SpacingLabel.IsVisible = true;
            }
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();

            
        }
        
        /*private async void CreateLot_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateParkingLot());
        }
        private async void SeeAllLotsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SeeAllLotsPage(user.Email));
        }

        private async void SeeParkingReservationsButton_Clicked(object sender, EventArgs e)
        {//change when i make parking reservations history page
            await Navigation.PushAsync(new ParkingReservationHistory(user.Email));
        }*/
        
        
    }
}