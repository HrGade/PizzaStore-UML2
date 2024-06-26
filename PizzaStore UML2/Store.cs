﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore_UML2
{
    internal class Store
    {
        private List<Customer> customers;
        private List<Pizza> pizzas;
        private List<Order> orders;

        public Store()
        {
            customers = new List<Customer>();
            pizzas = new List<Pizza>();
            orders = new List<Order>();
        }
        
        //Adds customer
        public void AddCustomer(Customer customer) 
        {
            customers.Add(customer);
        }

        //Deletes a Customer 
        public void DeleteCustomer(Customer customer)
        {
            customers.Remove(customer);
        }

        public void UpdateCustomer(Customer oldCustomer, Customer newCustomer)
        {
            //This deletes an already existing Customer, and creates a new Customer
            int index = customers.IndexOf(oldCustomer);
            if (index != -1)
            {
                customers[index] = newCustomer;
            }
        }

        //Search for an customer-name
        public Customer SearchCustomer(string name)
        {
            return customers.FirstOrDefault(customer => customer.Name.Equals(name))!;
        }

        //Create a pizza
        public void CreatePizza(Pizza pizza)
        {
            pizzas.Add(pizza);
        }

        //Delete a pizza
        public void DeletePizza(Pizza pizza)
        {
            pizzas.Remove(pizza);
        }

        //This deletes an already existing pizza, and creates a new pizza
        public void UpdatePizza(Pizza oldPizza, Pizza newPizza) 
        {
            int index = pizzas.IndexOf(oldPizza);
            if (index != -1)
            {
                pizzas[index] = newPizza;
            }
        }

        //Show the available pizzas
        public void ShowPizza()
        {
            foreach (Pizza pizza in pizzas)
            {
                Console.WriteLine(pizza);
            }
        }

        //Searches available pizzas
        public Pizza SearchPizza(string name)
        {
            return pizzas.FirstOrDefault(pizza => pizza.Name.Equals(name))!;
        }

        //Create an order for customer 
        public void OrderCreate(Order order)
        {
            orders.Add(order);
        }

        //Delete an order
        public void DeleteOrder(Order order)
        {
            orders.Remove(order);
        }

        //This deletes an old order, and puts in a new order
        public void Update(Order oldOrder, Order newOrder)
        {
            int index = orders.IndexOf(oldOrder);
            if (index != -1)
            {
                orders[index] = newOrder;
            }
        }

        //Search for an order
        public Order SearchOrder(Func<Order, bool> OrderSearch)
        {
            return orders.FirstOrDefault(OrderSearch)!;
        }

        //Shows available orders
        public void ShowOrderList()
        {
            foreach (Order order in orders)
            {
                Console.WriteLine(order);
            }
        }

        public void Start()
        {
            // Making new pizzas & orders.
            Pizza pizza1 = new Pizza("Margherita", 100);
            Pizza pizza2 = new Pizza("Salat Pizza", 120);
            Pizza pizza3 = new Pizza("Greek Pizza", 110);

            Customer customer1 = new Customer("Peter", "Jyllinge");
            Customer customer2 = new Customer("Torben", "Brønshøj");
            Customer customer3 = new Customer("Niels", "Herlev");

            Order order1 = new Order(pizza1, customer1);
            Order order2 = new Order(pizza2, customer2);
            Order order3 = new Order(pizza3, customer3);

            /* Adding Customer, pizzas & orders to the menu of the*/

            Console.WriteLine("Welcome to Pizza Store!");
            Console.WriteLine("Which pizza do you like?");
            Console.WriteLine("What is your name & address?");
            Console.WriteLine();

            CreatePizza(pizza1);
            CreatePizza(pizza2);
            CreatePizza(pizza3);

            AddCustomer(customer1);
            AddCustomer(customer2); 
            AddCustomer(customer3);

            OrderCreate(order1);
            OrderCreate(order2);
            OrderCreate(order3);
            Console.WriteLine("Pizza List:");
            ShowOrderList();
            
        }


        public void PrintCustomerList()
        {
            foreach (Customer customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
