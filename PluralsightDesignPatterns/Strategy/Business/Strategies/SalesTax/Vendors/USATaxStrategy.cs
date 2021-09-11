using Strategy.Business.Models;

namespace Strategy.Business.Strategies.SalesTax.Vendors
{

    public class USATaxStrategy : ISalesTaxStrategy
    {

        public decimal GetTaxFor(Order order)
        {
            var baseValue = order.TotalValue * 5m;

            return baseValue;
        }

    }

}