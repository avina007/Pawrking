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
                    App.Current.MainPage.Navigation.PushAsync(new ParkingReservationHistory(email));
                });
            }
        }

        public Command CreateParkingLotClicked
        {
            get
            {
                return new Command(() =>
                {
                    App.Current.MainPage.Navigation.PushAsync(new CreateParkingLot(email));
                });
            }
        }
        public Command SearchByTimeClicked
        {
            get
            {
                return new Command(() =>
                {
                    App.Current.MainPage.Navigation.PushAsync(new SearchByTimePage(email));
                });
            }
        }

       
        public Command LogoutCommand
        {
            get
            {
                return new Command(() =>
                {
                    App.Current.MainPage.Navigation.PushAsync(new MainPage());
                });
            }
            
        }
    }
}
