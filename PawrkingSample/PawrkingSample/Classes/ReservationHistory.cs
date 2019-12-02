using System;
using System.Collections.Generic;
using System.Text;

namespace PawrkingSample.Classes
{
    public class ReservationHistory
    {
        public string Email { set; get; }
        public string LotName { set; get; }
        public string Row { set; get; }
        public int Space { set; get; }
        public DateTime Start { set; get; }
        public DateTime End { set; get; }
    }
}
