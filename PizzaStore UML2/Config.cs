using PizzaStore_UML2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PizzaStore_UML2
{
    internal class Config

    {
        public void CreateOrder()
        {
            Store store = new Store();  
            store.Start();
            Console.WriteLine();
            Console.WriteLine("Welcome to Pizza Store!");
            Console.WriteLine();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Remove Customer");
            Console.WriteLine("3. Search Customer");
            Console.WriteLine("4. Add Pizza");
            Console.WriteLine("5. Remove Pizza");
            Console.WriteLine("6. Search Pizza");
            Console.WriteLine("7. Place Order");
            Console.WriteLine("8. Exit");

            bool UntilOrderConfirm = true;
            while (UntilOrderConfirm)
            {
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine()!;

                switch (input)
                {
                    case "1":
                        Console.Write("Enter customer name: ");
                        string name = Console.ReadLine()!;
                        Console.Write("Enter customer address: ");
                        string address = Console.ReadLine()!;
                        store.AddCustomer(new Customer(name, address));
                        Console.WriteLine("Customer added successfully!");

                        break;

                    case "2":
                        Console.Write("Enter customer name to remove: ");
                        string nameToRemove = Console.ReadLine()!;
                        Customer customerToRemove = store.SearchCustomer(nameToRemove);
                        if (customerToRemove != null)
                        {
                            store.DeleteCustomer(customerToRemove);
                            Console.WriteLine("Customer removed successfully!");
                        }

                        else
                        {
                            Console.WriteLine("Customer not found!");
                        }
                        break;

                    case "3":
                        Console.Write("Enter customer name to search: ");
                        Console.Write("You can add up to three customers:");
                        string nameSearch = Console.ReadLine()!;
                        Customer searchedCustomer = store.SearchCustomer(nameSearch);
                        if (searchedCustomer != null)
                        {
                            Console.WriteLine($"Customers found: {searchedCustomer}");
                        }

                        else
                        {
                            Console.WriteLine("No customers found!");
                        }

                        break;

                    case "4":
                        Console.Write("Enter pizza name: ");
                        string pizzaName = Console.ReadLine()!;
                        Console.Write("Enter pizza price: ");
                        decimal pizzaPrice;
                        while (!decimal.TryParse(Console.ReadLine(), out pizzaPrice))
                        {
                            Console.WriteLine("Invalid input! Please enter a valid price.");
                        }
                        store.CreatePizza(new Pizza(pizzaName, pizzaPrice));
                        Console.WriteLine("Pizza added successfully!");
                        break;

                    case "5":
                        Console.Write("Enter pizza name to remove: ");
                        string removePizzaName = Console.ReadLine()!;
                        Pizza removePizza = store.PizzaSearch(removePizzaName);
                        if (removePizza != null)
                        {
                            store.DeletePizza(removePizza);
                            Console.WriteLine("Pizza removed successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Pizza not found!");
                        }
                        break;

                    case "6":
                        Console.Write("Enter pizza name to search: ");
                        string pizzaNameToSearch = Console.ReadLine()!;
                        Pizza searchedPizza = store.PizzaSearch(pizzaNameToSearch);
                        if (searchedPizza != null)
                        {
                            Console.WriteLine($"Pizza found: {searchedPizza}");
                        }
                        else
                        {
                            Console.WriteLine("Pizza not found!");
                        }
                        break;

                    case "7":
                        Console.WriteLine("Placing Order:");
                        Console.WriteLine("Available Customers:");
                        store.PrintCustomerList();
                        Console.Write("Enter customer name: ");

                        string customerName = Console.ReadLine()!;
                        Customer selectedCustomer = store.SearchCustomer(customerName);
                        if (selectedCustomer == null)
                        {
                            Console.WriteLine("Customer not found!");
                            break;
                        }

                        Console.WriteLine("Available Pizzas: ");
                        store.ShowPizza();
                        Console.Write("Enter a name of a pizza: ");
                        string pizzaNameForOrder = Console.ReadLine()!;
                        Pizza selectedPizza = store.PizzaSearch(pizzaNameForOrder);

                        if (selectedPizza == null)
                        {
                            Console.WriteLine("Pizza not found!");
                            break;
                        }

                        Order newOrder = new Order(selectedPizza, selectedCustomer);
                        store.CreateOrder(newOrder);
                        Console.WriteLine("Order placed successfully!");
                        break;

                    case "8":
                        UntilOrderConfirm = false;
                        Console.WriteLine("Exiting Pizza Store. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Not possible! Please enter a number from 1 to 7");
                        break;
                }
            }
        }
    }
}
