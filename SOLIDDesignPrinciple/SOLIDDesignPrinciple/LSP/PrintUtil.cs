using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDDesignPrinciple.LSP
{
    public class PrintUtil
    {
        public static void PrintManager(Manager manager)
        {
            Console.WriteLine($"Name: {manager.Name}, Share:{manager.Shares}");
        }
    }
}
