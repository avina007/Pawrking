using PawrkingSample.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PawrkingSample.ClassPages
{
    class HomePageVM
    {
        string email;
        public HomePageVM(string email2)
        {
            email = email2;
        }

        public Command SeeAllLotsClicked
        {
            get
            {
                return new Command(() =>
                {
                     App.Current.MainPage.Navigation.PushAsync(new SeeAllLotsPage(email));
                });
            }
        }

        public Command SeeParkingReservationsClicked
        {
            get
            {
                return new Command(() =>
                {
                    //App.Current.MainPage.Navigation.PushAsync(new ReservationHistory(email));
                });
            }
        }

        public Command CreateParkingLotClicked
        {
            get
            {
                return new Command(() =>
                {
                    App.Current.MainPage.Navigation.PushAsync(new CreateParkingLot());
                });
            }
        }
        public Command LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    App.Current.MainPage.Navigation.PopAsync();
                });
            }
        }
    }
}
