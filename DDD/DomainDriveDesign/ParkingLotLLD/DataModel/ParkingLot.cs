using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLLD.DataModel
{
    public class ParkingLot: Entity
    {
        public string Address { get; set; }
        public List<Gate> Gates { get; set; }
        public List<ParkingFloor> ParkingFloors { get; set; }
    }
}
