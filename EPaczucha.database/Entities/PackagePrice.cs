﻿namespace EPaczucha.database
{
    public class PackagePrice : BaseEntity
    {
        public int Net { get; set; }
        public int VAT { get; set; }
        public int Gross { get; set; }
    }
}