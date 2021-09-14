namespace Bridge.After.DiscountVendors
{

    public class NoDiscount : Discount
    {

        public override int GetDiscount() => 0;

    }

}