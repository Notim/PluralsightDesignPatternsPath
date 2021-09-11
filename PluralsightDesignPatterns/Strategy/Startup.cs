using System;
using System.Collections.Generic;
using System.Text.Json;

using Strategy.Business.Models;
using Strategy.Business.Strategies.SalesTax;

namespace Strategy
{

    internal class Startup
    {

        private readonly ISalesTaxStrategyContext _context;

        public Startup()
        {
            _context = new SalesTaxStrategyContext();
        }

        public void Start(string[] args)
        {
            var order_usa = new Order("USA", new List<OrderItem>{
                new((decimal) 2.5, 5, "beans"),
                new((decimal) 5.2, 2, "rice"),
                new((decimal) 6.75, 1, "meet")
            });

            var order_swd = new Order("SWD", new List<OrderItem>{
                new((decimal) 2.5, 5, "beans"),
                new((decimal) 5.2, 2, "rice"),
                new((decimal) 6.75, 1, "meet")
            });

            var order_bra = new Order("BRA", new List<OrderItem>{
                new((decimal) 2.5, 5, "beans"),
                new((decimal) 5.2, 2, "rice"),
                new((decimal) 6.75, 1, "meet")
            });

            var bra_tax = _context.GetStrategy(order_bra.ShipmentCountry).GetTaxFor(order_bra);
            var swd_tax = _context.GetStrategy(order_swd.ShipmentCountry).GetTaxFor(order_swd);
            var usa_tax = _context.GetStrategy(order_usa.ShipmentCountry).GetTaxFor(order_usa);

            Console.WriteLine(JsonSerializer.Serialize(order_bra));
            Console.WriteLine(bra_tax);

            Console.WriteLine(JsonSerializer.Serialize(order_usa));
            Console.WriteLine(usa_tax);

            Console.WriteLine(JsonSerializer.Serialize(order_swd));
            Console.WriteLine(swd_tax);
        }

    }

}