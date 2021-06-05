using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShadFrame.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string Supplier_Name { get; set; }
        public string Supplier_Address { get; set; }
        public string Supplier_CellNumber { get; set; }
    }
}