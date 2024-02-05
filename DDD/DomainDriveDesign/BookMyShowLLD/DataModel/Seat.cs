using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShowLLD.DataModel
{
    public class Seat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SeatType Type { get; set; }
    }
}
