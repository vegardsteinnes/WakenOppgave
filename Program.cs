using Oppgave2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oppgave2
{
    class Program
    {
        static void Main(string[] args)
        {
            PopulateDatabase();
            PrintOrder("Vegard Arvid Steinnes");
            PrintOrder("Stegard Veinnes");
            PrintOrder("Per Olsen");

            Console.WriteLine("-----FORNYET ORDRE----- \n");

            RenewOrder("Vegard Arvid Steinnes", new DateTime(2022, 04, 21), new DateTime(2023, 04, 21));
            PrintOrder("Vegard Arvid Steinnes");
            Console.ReadLine();
        }

        private static void PopulateDatabase()
        {
            Database.CustomerTable.Add(new Customer("Vegard Arvid Steinnes", "vegard.steinnes@gmail.com", "97169495"));
            Database.CustomerTable.Add(new Customer("Stegard Veinnes", "stegard.veinnes@gmail.com", "86058384"));
            Database.CustomerTable.Add(new Customer("Per Olsen", "per.olsen@gmail.com", "12345678"));

            Database.ProductTable.Add(new Product("Husforsikring", 975));
            Database.ProductTable.Add(new Product("Bilforsikring", 500));
            Database.ProductTable.Add(new Product("Innboforsikring", 750));
            Database.ProductTable.Add(new Product("Reiseforsikring", 300));
            Database.ProductTable.Add(new Product("Helseforsikring", 600));

            // Gets the CustomerId by searching for the first match of the Customer "Name" input.
            Database.OrderTable.Add(new Order(Database.CustomerTable.Where(x => x.Name == "Vegard Arvid Steinnes").First().CustomerId,
                new DateTime(2021, 05, 20), new DateTime(2022, 05, 20)));
            Database.OrderTable.Add(new Order(Database.CustomerTable.Where(x => x.Name == "Stegard Veinnes").First().CustomerId,
                new DateTime(2021, 07, 30), new DateTime(2022, 07, 30)));
            Database.OrderTable.Add(new Order(Database.CustomerTable.Where(x => x.Name == "Per Olsen").First().CustomerId,
                new DateTime(2021, 06, 03), new DateTime(2022, 06, 03)));

            // Gets the OrderId by matching OrderIds and getting the OrderTable OrderId by matching CustomerIds by their Customer "Name".
            // Gets the ProductId by searching for the first match of the Product "Name" input.
            Database.OrderLineTable.Add(new OrderLine(Database.OrderTable.Where(x => x.CustomerId ==
                Database.CustomerTable.Where(z => z.Name == "Vegard Arvid Steinnes").First().CustomerId).First().OrderId,
                Database.ProductTable.Where(x => x.Name == "Husforsikring").First().ProductId));

            Database.OrderLineTable.Add(new OrderLine(Database.OrderTable.Where(x => x.CustomerId ==
                Database.CustomerTable.Where(z => z.Name == "Vegard Arvid Steinnes").First().CustomerId).First().OrderId,
                Database.ProductTable.Where(x => x.Name == "Bilforsikring").First().ProductId));

            Database.OrderLineTable.Add(new OrderLine(Database.OrderTable.Where(x => x.CustomerId ==
                Database.CustomerTable.Where(z => z.Name == "Stegard Veinnes").First().CustomerId).First().OrderId,
                Database.ProductTable.Where(x => x.Name == "Bilforsikring").First().ProductId));

            Database.OrderLineTable.Add(new OrderLine(Database.OrderTable.Where(x => x.CustomerId ==
                Database.CustomerTable.Where(z => z.Name == "Per Olsen").First().CustomerId).First().OrderId,
                Database.ProductTable.Where(x => x.Name == "Innboforsikring").First().ProductId));
        }

        private static void RenewOrder(string name, DateTime from, DateTime to)
        {
            // A new List to hold the orderlines that are to be renewed.
            List<OrderLine> OrderLineCopy = new List<OrderLine>();

            // Find the correct orderlines by matching OrderIds and getting the OrderTable OrderId by matching CustomerIds by their Customer "Name"
            // and then adds them to the OrderLineCopy list.
            foreach (OrderLine oL in Database.OrderLineTable)
                if (oL.OrderId == Database.OrderTable.Where(x => x.CustomerId == (Database.CustomerTable.Where(z => z.Name == name).First().CustomerId)).First().OrderId)
                    OrderLineCopy.Add(oL);

            // Adds the new order to the OrderTable.
            Database.OrderTable.Add(new Order(Database.CustomerTable.Where(x => x.Name == name).First().CustomerId,
                from, to));

            // Connects the old Orderlines to the new Order.
            foreach (OrderLine oL in OrderLineCopy)
                Database.OrderLineTable.Add(new OrderLine(Database.OrderTable.Where(x => x.CustomerId ==
                (Database.CustomerTable.Where(z => z.Name == name).First().CustomerId)).Last().OrderId, oL.ProductId));
        }

        private static void PrintOrder(string name)
        {
            // A new List to hold the OrderLines we want to print and know the total price of.
            List<OrderLine> OrderLineCopy = new List<OrderLine>();

            Console.WriteLine("Kunde: " + name);

            // Find the correct orderlines by matching OrderIds and getting the OrderTable OrderId by matching CustomerIds by their Customer "Name"
            // and then adds them to the OrderLineCopy list.
            foreach (OrderLine oL in Database.OrderLineTable)
                if (oL.OrderId == Database.OrderTable.Where(x => x.CustomerId == (Database.CustomerTable.Where(z => z.Name == name).First().CustomerId)).First().OrderId)
                    OrderLineCopy.Add(oL);

            // Prints out OrderId, ValidFrom and ValidTo
            foreach (Order oR in Database.OrderTable)
                if (oR.OrderId == Database.OrderTable.Where(x => x.CustomerId == (Database.CustomerTable.Where(z => z.Name == name).First().CustomerId)).Last().OrderId)
                    Console.WriteLine("Ordre ID:" + $" { oR.OrderId } " + "\n" + "Valid from:" + $" {oR.ValidFrom.ToShortDateString() } " + "\n" + "To:" + $" {oR.ValidTo.ToShortDateString() } ");

            // A new list to hold just the price of the OrderLines.
            List<int> TotalPrice = new List<int>();

            // Loops through the ProductTable looking for matching productIds that are in the OrderLineCopy.
            // Adds the price from the OrderLines to the TotalPrice list.
            // Prints out the individual prices of the products.
            for (int i = 0; i < Database.ProductTable.Count();)
            {
                foreach (OrderLine oL in OrderLineCopy)
                    if (Database.ProductTable[i].ProductId == oL.ProductId)
                        TotalPrice.Add(Database.ProductTable[i].Price);
                foreach (OrderLine oL in OrderLineCopy)
                    if (Database.ProductTable[i].ProductId == oL.ProductId)
                        Console.WriteLine("Price:" + $" {Database.ProductTable[i].Price} ");

                i++;
            }

            // Prints out the total sum of the OrderLines
            Console.WriteLine("Total price:" + $" { TotalPrice.Sum(x => Convert.ToInt32(x)) } ");
            Console.WriteLine();
        }
    }
}
