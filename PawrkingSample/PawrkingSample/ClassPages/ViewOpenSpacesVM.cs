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
    public class ViewOpenSpacesVM
    {
        string email;
        string LotName;
        string row;
        int col = -1;

        public ViewOpenSpacesVM(string e)
        {
            email = e;
        }

        internal void SpaceChosen(string r, int c)
        {
            row = r;
            col = c;

        }

        public List<ParkingLot> Space
        {
            get
            {
                List<ParkingLot> p = new List<ParkingLot>();
                p = Task.Run(() => FBParkingHelper.GetAllLotOpen()).Result;
                return p;
            }
        }

        public static void Refresh()
        {
            DateTime refresh = DateTime.Now;
            FBReservationHelper.RefreshReservations(refresh);
        }
    }
}
