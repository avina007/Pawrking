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
                    //App.Current.MainPage.Navigation.PushAsync(new ReservationPage(LotName,email));//to reservation page takes lot name and email
                });
            }
        }

        public List<ParkingLot> Space
        {
            get
            {
                List<ParkingLot> p = new List<ParkingLot>();
                List<string> s = new List<string>();
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
