﻿namespace EPaczucha.core
{
    public class PackagePriceDto
    {
        public int Id { get; set; }
        public decimal Net { get; set; }
        public int VAT { get; set; }
        public decimal Gross { get; set; }
    }
}