using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShadFrame.Models
{
    public class RequestPayments
    {
        public int RequestPaymentsId { get; set; }

        public string paymentmethod { get; set; }
        [StringLength(16)]
        public string CardNumber { get; set; }

        [StringLength(3)]
        public string CVVnumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }

        public string UserId { get; set; }

        public DateTime DateTimeofpayment { get; set; }

        public string TrackingNumberOfRequest { get; set; }
        public string Priceofrepair { get; set; }
    }
}