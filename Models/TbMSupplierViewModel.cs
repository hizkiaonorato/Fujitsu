using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Fujitsu.Models
{
    public class TbMSupplierViewModel
    {
        public List<TbMSupplier>? tbMSuppliers { get; set; }
        public SelectList? Cities { get; set; }
        public SelectList? Provinces { get; set; }
        public string? dataCity { get; set; }
        public string? dataProvince { get; set; }
        public string? searchString { get; set; }
    }
}
