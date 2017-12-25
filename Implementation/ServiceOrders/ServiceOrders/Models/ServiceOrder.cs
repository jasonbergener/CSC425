using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOrders.Models
{
    public class ServiceOrder
    {
        public int ServiceOrderID { get; set; }
        public int CustomerID { get; set; }
        public string Status { get; set; }
        public DateTime Opened { get; set; }
        public DateTime Updated { get; set; }
        public string PhysicalAddress { get; set; }
        public string Requested { get; set; }
        public string Notes { get; set; }

        public Customer Customer { get; set; }
    }
}
