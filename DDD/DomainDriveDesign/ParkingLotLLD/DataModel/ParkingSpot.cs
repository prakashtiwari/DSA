using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLLD.DataModel
{
    public class ParkingSpot
    {
        public SpotType SpotType { get; set; }
        public int SpotNumber { get; set; }

        public SpotStatus SpotStatus { get; set; }

    }
}
