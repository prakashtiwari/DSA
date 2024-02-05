using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLLD.DataModel
{
    public abstract class Gate
    {
        public GateType GateType { get; set; }
        public int GateNUmber { get; set; }

        public Operator Operator { get; set; }
    }
}
