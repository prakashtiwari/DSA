using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskBooker.Core.Domain
{
    public class DeskBooking : DeskBookingBase
    {
        public int Id { get; set; }
        public int DeskId { get; set; }
       
    }
}
