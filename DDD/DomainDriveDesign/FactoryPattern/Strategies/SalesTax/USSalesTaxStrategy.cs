using FactoryPattern.Components;

namespace FactoryPattern.Strategies.SalesTax
{
    public class USSalesTaxStrategy : ISalesTaxStrategy
    {
        public decimal CalculateTaxFor(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
