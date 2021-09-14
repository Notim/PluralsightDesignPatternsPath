using System;

namespace Bridge.Before.Vendors_first_level
{

    public class TwoDaysLicense : MovieLicenseBase
    {

        public TwoDaysLicense(string movie, DateTime purchaseTime) : base(movie, purchaseTime)
        { }

        protected override decimal GetPrice()
        {
            return 4;
        }

        protected override DateTime? GetExpirationDate()
        {
            return PurchaseTime.AddDays(2);
        }

    }

    

}