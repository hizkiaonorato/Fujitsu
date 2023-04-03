using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fujitsu.Models
{
    public partial class TbMSupplier
    {
        public string SupplierCode { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Pic { get; set; }
    }
}
