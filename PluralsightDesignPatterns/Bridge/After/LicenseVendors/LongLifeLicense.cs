using System;

namespace Bridge.After.LicenseVendors
{

    public class LongLifeLicense : MovieLicenseBase
    {

        public LongLifeLicense(string movie, DateTime purchaseTime, Discount discount) 
            : base(movie, purchaseTime, discount)
        { }

        protected override decimal GetPriceCore() => 8;

        protected override DateTime? GetExpirationDate() => null;

    }

}