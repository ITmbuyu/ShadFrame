using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShadFrame.Models
{
    public class Request
    {
        public int RequestId { get; set; }

        //FK - Brand
        public string BrandName { get; set; }

        //FK - DeviceProblem
        public int DeviceProblemId { get; set; }
        public virtual DeviceProblem DeviceProblem { get; set; }

        //FK - DeviceName
        public int DeviceDescriptionId { get; set; }
        public virtual DeviceDescription DeviceDescription { get; set; }

        //FK - Storage
        public int StorageId { get; set; }
        public virtual Storage Storage { get; set; }

        //FK - ColourName
        public int ColourId { get; set; }
        public virtual Colour Colour { get; set; }

        [StringLength(15)]
        public string IMEI { get; set; }

        public double Price { get; set; }
        public DateTime RequestDateTime { get; set; }

        public string UserId { get; set; }

        //FK - Payment Status
        public int PaymentStatusId { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }

        //FK - Charge Approval
        public int CApprovalMessagesId { get; set; }
        public virtual CApprovalMessages CApprovalMessages { get; set; }

        //FK - Approval Of Request
        public int ApprovalMessagesId { get; set; }
        public virtual ApprovalMessages ApprovalMessages { get; set; }

        public string UserEmail { get; set; }


        //public double CalcPrice()
        //{
        //    ApplicationDbContext db = new ApplicationDbContext();

        //    var price =
        //        db.DeviceDescriptions.Find(DeviceDescriptionId).Brand.BrandRate *
        //        db.DeviceProblems.Find(DeviceProblemId).CostOfP;

        //    return price;
        //}
    }
}