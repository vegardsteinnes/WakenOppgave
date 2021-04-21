using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppgave2.Models
{
    public class Order
    {
        public Guid OrderId { get; private set; }
        public Guid CustomerId { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public int TotalPrice { get; set; }

        public Order(Guid customerId, DateTime from, DateTime to)
        {
            OrderId = Guid.NewGuid();
            CustomerId = customerId;
            ValidFrom = from;
            ValidTo = to;
        }
    }
}
