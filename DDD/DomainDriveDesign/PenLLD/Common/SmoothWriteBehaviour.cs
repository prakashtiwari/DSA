using PenLLD.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenLLD.Common
{
    internal class SmoothWriteBehaviour : IWriteBehaviour
    {
        public void Write()
        {
            Console.WriteLine("Gel Pen is write smoothely!!");
        }
    }
}
