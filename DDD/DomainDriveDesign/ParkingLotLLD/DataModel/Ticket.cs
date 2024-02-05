using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLLD.DataModel
{
    public class Ticket : Entity
    {
        public Operator CreatedByOperator { get; set; }
        public ParkingSpot ParkingSpot { get; set; }
        public ParkingFloor Floor { get; set; }
        public string EntryTime { get; set; }
        public Vehicle Vehicle { get; set; }

        public EntryGate EntryGate { get; set; }

    }
}
