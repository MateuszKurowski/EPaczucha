﻿namespace EPaczucha.database
{
    public class PackagePrice
    {
        public int PackagePriceID { get; set; }
        public int Net { get; set; }
        public int VAT { get; set; }
        public int Gross { get; set; }
    }
}