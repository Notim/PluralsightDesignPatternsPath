using System;

namespace Bridge
{

    public class Program
    {

        public static void Main(string[] args)
        {
            var license1 = new Before.Vendors_first_level.TwoDaysLicense("Secrets of life", DateTime.Now);
            var license2 = new Before.Vendors_first_level.LongLifeLicense("Matrix", DateTime.Now);
            
            var license1_1 = new Before.Vendors_first_level.Vendors_seccond_level.MilitaryTwoDaysLicense("movie 1", DateTime.Now);
            var license1_2 = new Before.Vendors_first_level.Vendors_seccond_level.MilitaryLongLifeLicense("movie 2", DateTime.Now);
            var license2_1 = new Before.Vendors_first_level.Vendors_seccond_level.SeniorTwoDaysLicense("movie 3", DateTime.Now);
            var license2_2 = new Before.Vendors_first_level.Vendors_seccond_level.SeniorLongLifeLicense("movie 4", DateTime.Now);

            Console.WriteLine(license1.ToString());
            Console.WriteLine(license2.ToString());
            Console.WriteLine(license1_1.ToString());
            Console.WriteLine(license1_2.ToString());
            Console.WriteLine(license2_1.ToString());
            Console.WriteLine(license2_2.ToString());
            
            Console.WriteLine("--------------------------------------------------------------------------------------");

            var noDiscount       = new After.DiscountVendors.NoDiscount();
            var militaryDiscount = new After.DiscountVendors.MilitaryDiscount();
            var seniorDiscount   = new After.DiscountVendors.SeniorDiscount();
            
            var licenseafter1 = new After.LicenseVendors.LongLifeLicense("Tropa de elite", DateTime.Now, noDiscount);
            var licenseafter2 = new After.LicenseVendors.LongLifeLicense("Secrets of life", DateTime.Now, militaryDiscount);
            var licenseafter3 = new After.LicenseVendors.TwoDaysLicense("Matrix", DateTime.Now, seniorDiscount);

            Console.WriteLine(licenseafter1.ToString());
            Console.WriteLine(licenseafter2.ToString());
            Console.WriteLine(licenseafter3.ToString());
        }

    }

}