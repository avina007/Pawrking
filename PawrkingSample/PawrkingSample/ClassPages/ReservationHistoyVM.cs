using PawrkingSample.Classes;
using PawrkingSample.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PawrkingSample.ClassPages
{
    class ReservationHistoyVM
    {
        string email;
        public ReservationHistoyVM(string e)
        {
            email = e;
        }
        public List<ReservationHistory> MyHistory
        {
            get
            {
                List<ReservationHistory> rh = new List<ReservationHistory>();
                rh = Task.Run(() => ReservationHistoryHelper.GetMyReservations(email)).Result;
                return rh;
            }
        }

        public string TopLabel
        {
            get
            {
                return "Reservation History for " + email;
            }
        }

        public Command CancelButtonClicked
        {
            get
            {
                return new Command(() =>
                {
                    App.Current.MainPage.Navigation.PushAsync(new HomePage(email));
                });
            }
        }
    }
}
