using PawrkingSample.Classes;
using PawrkingSample.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace PawrkingSample.ClassPages
{
    class LotVM
    {
        string email;
        string LotName;
        string row;
        int col = -1;
        public LotVM(string email2, string lot)
        {
            email = email2;
            LotName = lot;
        }

        private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        private void OnPropertyChanged(string v)
        {
            //throw new NotImplementedException();
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;
                    DateTime refresh = DateTime.Now;
                    await FBReservationHelper.RefreshReservations(refresh);
                    IsRefreshing = false;
                });
            }
        }

        public Command ReservationClicked
        {
            get
            {
                return new Command(async () =>
                {
                    if (row == "" || col == -1)
                    {
                        App.Current.MainPage.DisplayAlert("Error", "You must select a spot first in order to make a reservation.", "OK");
                    }
                    else if(await FBReservationHelper.userInUse(email))
                    {
                        App.Current.MainPage.DisplayAlert("ERROR", "You already have an active Reservation", "OOPS");
                        _ = App.Current.MainPage.Navigation.PushAsync(new ParkingReservationHistory(email));
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("Success", email+", you are about to make a reservation to Row:"+row+" Space:"+col, "OK");
                        App.Current.MainPage.Navigation.PushAsync(new ReservationPage(email, LotName,row,col));
                    }
                });
            }
        }
        public void SpaceChosen(string r, int c)
        {
            row = r;
            col = c;
        }

        

        public List<ParkingLot> Space
        {
            get
            {
                List<ParkingLot> p = new List<ParkingLot>();
                p = Task.Run(() => FBParkingHelper.GetLotOpen(LotName)).Result;
                return p;
            }
        }

        public static void Refresh()
        {
            DateTime refresh = DateTime.Now;
            FBReservationHelper.RefreshReservations(refresh);
        }

        public int GetFree
        {
            get
            {
                List<ParkingLot> p = new List<ParkingLot>();
                p = Space;
                return p.Count;
                
            }
        }

        public int GetAllSpotCount
        {
            get
            {
                List<ParkingLot> p = new List<ParkingLot>();
                p = Task.Run(() => FBParkingHelper.GetAllLotX(LotName)).Result;
                return p.Count;
            }
        }
       
        
        public Command CancelButtonClicked
        {
            get
            {
                return new Command(() =>
                {
                    
                    App.Current.MainPage.Navigation.PushAsync(new SeeAllLotsPage(email));
                });
            }
        }
    }
}
