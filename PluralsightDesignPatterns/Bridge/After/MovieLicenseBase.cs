using System;

namespace Bridge.After
{

    public abstract class MovieLicenseBase
    {

        private readonly Discount _discount;

        protected string Movie { get; }
        protected DateTime PurchaseTime { get; }

        protected MovieLicenseBase(string movie, DateTime purchaseTime, Discount discount) 
            => (Movie, PurchaseTime, _discount) = (movie, purchaseTime, discount);

        protected decimal GetPrice()
        {
            var discountAmmount = _discount.GetDiscount();
            var multiplier = 1 - discountAmmount / 100m;

            return GetPriceCore() * multiplier;
        }
        
        protected abstract decimal GetPriceCore();

        protected abstract DateTime? GetExpirationDate();

        public override string ToString() => $"Movie: {Movie} \n - {PurchaseTime:g} \n - {this.GetPrice():C} \n - {this.ExpirationDateToString()}";

        public string ExpirationDateToString()
        {
            if (this.GetExpirationDate() is null) {
                return "Forever";
            }

            var timespan = this.GetExpirationDate().Value - DateTime.Now;

            return $"{timespan.Days}d {timespan.Hours}h {timespan.Minutes}m";
        }

    }
    
}