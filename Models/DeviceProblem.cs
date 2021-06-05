using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShadFrame.Models
{
    public class DeviceProblem
    {
        public int DeviceProblemId { get; set; }
        public string Description { get; set; }
        public double CostOfP { get; set; }
    }
}