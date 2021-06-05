using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShadFrame.Models
{
    public class DeviceDescription
    {
        public int DeviceDescriptionId { get; set; }

        //Foreign Key - Brand
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public string DeviceName { get; set; }
    }
}