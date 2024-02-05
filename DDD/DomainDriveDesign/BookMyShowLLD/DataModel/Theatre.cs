using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyShowLLD.DataModel
{
    public class Theatre
    {
        public string Id { get; set; }
        private List<Auditorium> auditorium { get; set; }
        public Theatre()
        {
            auditorium = new List<Auditorium>();
        }
    }
}
