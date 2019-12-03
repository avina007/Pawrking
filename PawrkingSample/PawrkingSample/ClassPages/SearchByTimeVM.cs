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
    public class SearchByTimeVM : INotifyPropertyChanged
    {
        string email;
        //string lotname;

        DateTime chosenTime;

        private int timeinhours;
        public int TimeInHours
        {
            get { return timeinhours; }
            set
            {
                timeinhours = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TimeInHours"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private int timeinmin;
        public int TimeInMin
        {
            get { return timeinmin; }
            set
            {
                timeinmin = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TimeInMin"));
            }
        }


        public SearchByTimeVM(string e)
        {
            email = e;
            //lotname = lname;
        }

        public Command PMCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (TimeInHours > 0 && TimeInHours <= 12 &&
                        TimeInMin > 0 && TimeInMin <= 59)
                        ShowPmAvailable();
                    else
                        App.Current.MainPage.DisplayAlert("", "Time must be between 0-12 and min between 0-59\nSorry", "OK");

                });
            }
        }

        public Command AMCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (TimeInHours > 0 && TimeInHours <= 12 &&
                        TimeInMin > 0 && TimeInMin <= 59)
                        ShowAmAvailable();
                    else
                        App.Current.MainPage.DisplayAlert("", "Time must be between 0-12 and min between 0-59\nSorry", "OK");

                });
            }
        }

        private async void ShowPmAvailable()
        {
            DateTime now = DateTime.Now;
            TimeInHours = TimeInHours + 12;
            chosenTime = new DateTime(now.Year, now.Month, now.Day, TimeInHours, TimeInMin, 00);
            App.Current.MainPage.Navigation.PushAsync(new ViewOpenSpacesPage(email));
        }

        private async void ShowAmAvailable()
        {
            DateTime now = DateTime.Now;
            chosenTime = new DateTime(now.Year, now.Month, now.Day, TimeInHours, TimeInMin, 00);

        }
    }
}
