using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLLD.DTO
{
    public class CreateParkingLotRequest
    {
        public string Address { get; set; }
        public int NumOfFloor { get; set; }
    }
}
