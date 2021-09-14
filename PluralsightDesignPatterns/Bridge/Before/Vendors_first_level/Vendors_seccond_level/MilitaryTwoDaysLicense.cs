using System;

namespace Bridge.Before.Vendors_first_level.Vendors_seccond_level
{

    public class MilitaryTwoDaysLicense : TwoDaysLicense
    {

        public MilitaryTwoDaysLicense(string movie, DateTime purchaseTime) : base(movie, purchaseTime)
        { }

        protected override decimal GetPrice()
        {
            return base.GetPrice() * 0.9m;
        }

    }

}