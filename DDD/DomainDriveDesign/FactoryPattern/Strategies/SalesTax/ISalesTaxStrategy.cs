using FactoryPattern.Components;

namespace FactoryPattern.Strategies.SalesTax
{
    public interface ISalesTaxStrategy
    {
        public decimal CalculateTaxFor(Order order);
    }
}
