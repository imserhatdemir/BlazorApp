using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Shared
{
    public class Shipment
    {
        public int Id { get; set; }
        public string TrackingNumber { get; set; } = string.Empty;
        public Order? Order { get; set; }
        public int OrderId { get; set; }
        public string Sender { get; set; } = string.Empty;
        public string Recipient { get; set; } = string.Empty;
        [Column(TypeName = "decimal(10,2)")]
        public decimal Weight { get; set; }
        public DateTime ShippingDate { get; set; } = DateTime.Now;
        public DateTime ArrivalDate { get; set; }
        public bool Status { get; set; } = false;
        public bool Deleted { get; set; } = false;
        [NotMapped]
        public bool Editing { get; set; } = false;
        [NotMapped]
        public bool IsNew { get; set; } = false;


    }
}
