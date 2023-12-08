using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskBooker.Core.DataInterface
{
    public interface IDeskRepository
    {
        List<Desk> GetAvailableDesks();
    }
}
