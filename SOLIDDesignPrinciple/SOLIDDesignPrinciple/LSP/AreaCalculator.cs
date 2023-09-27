using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDDesignPrinciple.LSP
{
    public  class AreaCalculator
    {
        public int CalculateArea(Rectangle rect)
        { 
          return rect.Height *rect.Width;
        }
    }
}
