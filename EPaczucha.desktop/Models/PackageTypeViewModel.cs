using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPaczucha.desktop.Models
{
    public class PackageTypeViewModel
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public decimal Price { get; set; }
    }
}
