using System.Linq;

using Strategy.Business.Models;

namespace Strategy.Business.Strategies.SalesTax.Vendors
{

    public class BrazilTaxStrategy : ISalesTaxStrategy
    {

        public decimal GetTaxFor(Order order)
        {
            var baseValue = order.TotalValue * 25m;
            
            return baseValue + order.Items.Sum(item => (item.Ammount * item.Quantity) * 12m);
        }

    }

}