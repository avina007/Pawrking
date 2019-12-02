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

        private string timelength;
        public string TimeLength;

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
                    if(TimeLength >= 0 && )
                });
            }
        }
    }
}
