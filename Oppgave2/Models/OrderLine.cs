using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppgave2.Models
{
    public class OrderLine
    {
        public Guid OrderLineId { get; private set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }

        public OrderLine(Guid orderId)
        {
            OrderLineId = Guid.NewGuid();
            OrderId = orderId;
        }

        public OrderLine(Guid orderId, Guid productId)
        {
            OrderLineId = Guid.NewGuid();
            OrderId = orderId;
            ProductId = productId;
        }

        /* public void AddProduct(Guid productId)
        {
            ProductId = productId;
        }*/
    }
}
