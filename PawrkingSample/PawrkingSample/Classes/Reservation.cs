using System;
using System.Collections.Generic;
using System.Text;

namespace PawrkingSample.Classes
{
    public class Reservation
    {
        public ParkingLot Lot { set; get; }
        public string Email { set; get; }
        public int Timer { set; get; }
    }
}
