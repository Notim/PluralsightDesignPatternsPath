using System;

namespace Bridge.Before
{

    public abstract class MovieLicenseBase
    {

        public string Movie { get; }

        protected DateTime PurchaseTime { get; }

        protected MovieLicenseBase(string movie, DateTime purchaseTime) => (Movie, PurchaseTime) = (movie, purchaseTime);

        protected abstract decimal GetPrice();

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