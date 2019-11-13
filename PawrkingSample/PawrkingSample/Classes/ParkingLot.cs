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
        int numOfRows { set; get; }
        int numOfCols { set; get; }
        int [][] availableSpaces { set; get; }
        
    }


}
