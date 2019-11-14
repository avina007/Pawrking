using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PawrkingSample.Classes
{
    class ParkingLot
    {
        [PrimaryKey, Unique, AutoIncrement]
        public int lotId { get; set; }
        public string name { get; set; }
        public string row { get; set; }
        public int col { get; set; }
        public Boolean open { get; set; }
        
    }


}
