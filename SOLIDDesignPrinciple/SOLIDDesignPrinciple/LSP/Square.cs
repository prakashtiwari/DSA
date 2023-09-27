using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDDesignPrinciple.LSP
{
    public class Square: Rectangle
    {
        private int _height;
        public override int Height { get { return _height; } set { Width = value; _height = value; } }
    }
}
