using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLLD.DataModel
{
    public class ParkingFloor: Entity
    {
        List<ParkingSpot> listSpot;
        public int FloorNumber { get; set; }


    }
}
