using System.Collections.Generic;
using System.Linq;

namespace Strategy.Business.Models
{

    public record Order(string ShipmentCountry, List<OrderItem> Items)
    {

        public decimal TotalValue => Items.Sum(item => item.Ammount * item.Quantity);

    };

    public record OrderItem(decimal Ammount, int Quantity, string Description);

}