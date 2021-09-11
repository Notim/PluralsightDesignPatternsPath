using Strategy.Business.Models;

namespace Strategy.Business.Strategies.SalesTax.Vendors
{

    public class SweedenTaxStrategy : ISalesTaxStrategy
    {

        public decimal GetTaxFor(Order order)
        {
            var baseValue = order.TotalValue * 1m;

            return baseValue;
        }

    }

}