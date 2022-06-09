using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPaczucha.desktop.Models
{
    public class PackagePriceViewModel
    {
         public int Id { get; set; }
        public decimal Net { get; set; }
        public decimal VAT { get; set; }
        public decimal Gross { get; set; }
    }
}
