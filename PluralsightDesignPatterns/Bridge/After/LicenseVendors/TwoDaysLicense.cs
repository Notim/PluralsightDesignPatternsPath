using System;

namespace Bridge.After.LicenseVendors
{

    public class TwoDaysLicense : MovieLicenseBase
    {

        public TwoDaysLicense(string movie, DateTime purchaseTime, Discount discount) 
            : base(movie, purchaseTime, discount)
        {
            
        }

        protected override decimal GetPriceCore() => 4;

        protected override DateTime? GetExpirationDate() => PurchaseTime.AddDays(2);

    }

}