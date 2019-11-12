using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PawrkingSample.Classes
{
    class ParkingLot
    {
        [PrimaryKey, Unique]
        string name { set; get; }
        int totalSpaces { set; get; }
        string availableSpaces { set; get; }
        
    }


}
