using PenLLD.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenLLD.Interface
{
    public interface IRefillPen
    {
        Refill GetRefill();
        bool IsRefillable();

        void ChangeRefill(Refill refill);
    }
}
