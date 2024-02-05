using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLLD.DataModel
{
    public class ElectricParkingSpot: ParkingSpot
    {
        public ElectricCharger ElectricCharger { get; set; }
        public ElectricParkingSpot(ElectricCharger electricCharger)
        { 
         this.ElectricCharger = electricCharger;
        }

    }
}
