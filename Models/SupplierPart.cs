using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShadFrame.Models
{
    public class SupplierPart
    {
        //Foreign Key - Brand
        public int SupplierPartId { get; set; }
        public int PartsId { get; set; }
        public virtual Parts Parts { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public string PartSupplied_Date { get; set; }
        public int PartSupplied_Quantity { get; set; }
    }
}