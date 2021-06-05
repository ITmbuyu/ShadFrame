using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShadFrame.Models
{
    public class DeviceStatus
    {
        [Key]
        public string TrackingNumber { get; set; }

        //FK - Brand
        public string Brand { get; set; }

        //FK - DeviceProblem
        public string DeviceProblem { get; set; }

        //FK - DeviceName
        public string DeviceName { get; set; }

        //FK - Storage
        public string Capacity { get; set; }

        //FK - ColourName
        public string Colour { get; set; }

        public string IMEI { get; set; }

        public double Price { get; set; }

        public int RepairStatusId { get; set; }
        public virtual RepairStatus RepairStatus { get; set; }

        public string PaymentStatus { get; set; }

        public DateTime RequestDateTime { get; set; }
        public string UserId { get; set; }
        public string TechnicianId { get; set; }
        public bool ApprovalOfRequest { get; set; }
        public bool ApprovalOfCharge { get; set; }
    }
}