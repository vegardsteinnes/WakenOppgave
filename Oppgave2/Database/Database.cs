using Oppgave2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppgave2
{
    public static class Database
    {
        public static List<Customer> CustomerTable = new List<Customer>();
        public static List<Order> OrderTable = new List<Order>();
        public static List<OrderLine> OrderLineTable = new List<OrderLine>();
        public static List<Product> ProductTable = new List<Product>();
    }
}
