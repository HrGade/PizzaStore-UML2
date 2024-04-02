using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore_UML2
{
    internal class Order
    {
        public Pizza Pizza { get; set; }
        public Customer Customer { get; set; }

        public Order(Pizza pizza, Customer customer)
        {
            Pizza = pizza;
            Customer = customer;
        }

        public decimal CalculateTotalPrice()
        {
            decimal totalPrice = Pizza.Price + 40; // Adding delivery cost
            // Assume a fixed tax rate of 40%
            totalPrice *= 1.40m; // Adding 40% tax
            return totalPrice;
        }

        public override string ToString()
        {
            decimal totalPrice = CalculateTotalPrice();
            return $"{Pizza.Name} inkl. moms: {totalPrice}";
        }
    }
}
