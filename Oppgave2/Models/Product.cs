using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppgave2.Models
{
    public class Product
    {
        public Guid ProductId { get; private set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public Product(string name, int price)
        {
            ProductId = Guid.NewGuid();
            Name = name;
            Price = price;
        }
    }
}
