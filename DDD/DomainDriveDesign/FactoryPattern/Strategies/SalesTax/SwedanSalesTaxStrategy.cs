using FactoryPattern.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern.Strategies.SalesTax
{
    internal class SwedanSalesTaxStrategy : ISalesTaxStrategy
    {
        public decimal CalculateTaxFor(Order order)
        {
            return 1m;
        }
    }
}
