using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDDesignPrinciple.LSP
{
    public class Manager:Employee
    {
        public int Shares { get; set; }
        //public static void Print(Manager manager)
        //{
        //    Console.WriteLine($"Name: {manager.Name}, Share:{manager.Shares}");
        //}
    }
}
