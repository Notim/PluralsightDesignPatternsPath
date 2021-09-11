using System;

using Strategy.Business.Strategies.SalesTax.Vendors;

namespace Strategy.Business.Strategies.SalesTax
{

    public interface ISalesTaxStrategyContext
    {

        ISalesTaxStrategy GetStrategy(string country);

    }

    public class SalesTaxStrategyContext : ISalesTaxStrategyContext
    {

        public ISalesTaxStrategy GetStrategy(string country) =>
            country switch{
                "USA" => new USATaxStrategy(),
                "BRA" => new BrazilTaxStrategy(),
                "SWD" => new SweedenTaxStrategy(),
                _ => throw new ArgumentException()
            };

    }

}