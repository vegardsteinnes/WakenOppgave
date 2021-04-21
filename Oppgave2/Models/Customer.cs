using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppgave2.Models
{
    public class Customer
    {
        public Guid CustomerId { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Customer(string name, string email, string phone)
        {
            CustomerId = Guid.NewGuid();
            Name = name;
            Email = email;
            Phone = phone;
        }

    }
}
