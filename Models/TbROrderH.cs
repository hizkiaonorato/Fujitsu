using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Fujitsu.Models
{
    public partial class TbROrderH
    {
        public string OrderNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public string SupplierCode { get; set; }
        public decimal? Amount { get; set; }
    }
}
