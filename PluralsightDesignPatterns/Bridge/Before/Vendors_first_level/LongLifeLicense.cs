using System;

namespace Bridge.Before.Vendors_first_level
{

    public class LongLifeLicense : MovieLicenseBase
    {

        public LongLifeLicense(string movie, DateTime purchaseTime) : base(movie, purchaseTime)
        { }

        protected override decimal GetPrice()
        {
            return 8;
        }

        protected override DateTime? GetExpirationDate()
        {
            return null;
        }

    }

}