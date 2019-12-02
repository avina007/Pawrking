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
    public class ReservationVM : INotifyPropertyChanged
    {
        string email;
        string lotname;
        string row;
        int col = -1;
        DateTime starttime;
        DateTime endtime;

        private int timelength;
        public int TimeLength
        {
            get { return timelength; }
            set
            {
                timelength = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TimeLength"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public ReservationVM(string lname, string r, int c, string e)
        {
            email = e;
            lotname = lname;
            row = r;
            col = c;
        }

        public Command ConfirmReservationCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (TimeLength >= 0 && TimeLength <= 12)
                        ConfirmReservation();
                    else
                        App.Current.MainPage.DisplayAlert("", "Time must be between 1-12\nSorry", "OK");
                });
            }
        }

        private async void ConfirmReservation()
        {
            starttime = DateTime.Now;
            endtime = starttime.AddHours(TimeLength);
            var reservation = await FBReservationHelper.AddReservation(lotname, row, col, email, TimeLength, starttime, endtime);
            var reserved = await FBParkingHelper.UpdateLotTaken(lotname, row, col);

            if(reservation && reserved)
            {
                await App.Current.MainPage.DisplayAlert("Reservation Confirmed", "", "Ok");
                await App.Current.MainPage.Navigation.PushAsync(new ParkingReservationHistory(email));
            }
            else
                await App.Current.MainPage.DisplayAlert("Reservation UNSUCCESFUL", "", "Ok");
        }
    }
}
