using PenLLD.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenLLD.Common
{
    public class PenFactory
    {
        public static GelPen.Builder CreateGetPen()
        {
            return new GelPen.Builder();
        }
    }
}
