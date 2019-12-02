using PawrkingSample.Classes;
using PawrkingSample.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public Command ReservationClicked
        {
            get
            {
                return new Command(() =>
                {
                    if (row == "" || col == -1)
                    {
                        App.Current.MainPage.DisplayAlert("Error", "You must select a spot first in order to make a reservation.", "OK");
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("Success", email+", you are about to make a reservation to Row:"+row+" Space:"+col, "OK");
<<<<<<< HEAD
                        App.Current.MainPage.Navigation.PushAsync(new ReservationPage(email, LotName,row,col));//to reservation page takes lot name and email
=======
                        //App.Current.MainPage.Navigation.PushAsync(new ReservationPage(LotName,row,col,email));//to reservation page
>>>>>>> 559113cbd6988569a07842c9e2374c4a87c141ee
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
        public List<string> Cat()
        {
            List<string> s = new List<string>();
            for(int i = 0; i< 5; i++){
            s.Add("cat");
            }
            return s;

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
