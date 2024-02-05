using FactoryPattern.Strategies.SalesTax;

namespace FactoryPattern.Components
{
    public class Order
    {
        private readonly ISalesTaxStrategy _salesTaxStrategy;
        // public Order()
        public decimal GetTax()
        {
            if (_salesTaxStrategy == null)
                return 0m;
            return _salesTaxStrategy.CalculateTaxFor(this);

        }
    }
}
