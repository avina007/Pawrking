using PawrkingSample.Classes;
using PawrkingSample.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PawrkingSample.ClassPages
{
    class HomePageVM : INotifyPropertyChanged
    {
        string email;

        public event PropertyChangedEventHandler PropertyChanged;

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

        /*public async Task<bool> adminAccessAsync()
        {
            FirebaseHelper fh = new FirebaseHelper();
            var u = FirebaseHelper.GetUser(email).ConfigureAwait(false);
            //Users user = FirebaseHelper.getInstance().getCurrentUser();

            if (user.isAdmin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/
    }
}
