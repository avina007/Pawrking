using System;
using System.Collections.Generic;
using System.Text;

namespace PawrkingSample.Classes
{
    public class Reservation
    {
        public string LotName { set; get; }
        public string Row { set; get; }
        public int Col { set; get; }
        
        public string Email { set; get; }
        public int TimeLength { set; get; }
        public DateTime StartTime { set; get; }
        public DateTime EndTime { set; get; }
    }
}
