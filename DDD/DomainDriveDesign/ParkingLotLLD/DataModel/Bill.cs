using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotLLD.DataModel
{
    public class Bill
    {
        public Ticket Ticket { get; set; }
        public int Amount { get; set; }
        public string ExitTime { get; set; }

        public Payment payment { get; set; }
        public BillStatus BillStatus { get; set; }
    }
}
