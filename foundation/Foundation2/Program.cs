using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create some products
        Product product1 = new Product("Blue Lamp", 101, 100.00, 1);
        Product product2 = new Product("Red Lamp", 102, 100.00, 1);
        Product product3 = new Product("Art Deco Rug", 103, 100.00, 1);
        Product product4 = new Product("Faux Mink Pillow Set",104, 100.00, 1);
        Product product5 = new Product("Couch Throw",105, 100.00, 1);
        Product product6 = new Product("Beige Curtains",106, 100.00, 4);


        // Add products to the list
        List<Product> customer1List = new List<Product> { product1, product2, product3 };
        List<Product> customer2List = new List<Product> { product4, product5, product6 };
        // Create an address and customer
        Address custAddress1 = new Address("1050 East 200 South, SLC, Utah, USA");
        Customer customer1 = new Customer("Sarah Carter", custAddress1);
        Address custAddress2 = new Address("12 Rue de Rivoli, 75001 Paris, France");
        Customer customer2 = new Customer("Sophie Garrand", custAddress2);

        // Create an order
        Order order = new Order(customer1List, customer1);
        Order order2 = new Order(customer2List, customer2);

        // Display packing label, shipping label, and total cost
        Console.Clear();
        Console.WriteLine("Order 1");
        Console.WriteLine(order.PackingLabel());
        Console.WriteLine(order.ShippingLabel());
        Console.WriteLine($"Total Cost: ${order.CalculateTotal()}");
        Console.WriteLine("\nOrder 2");
        Console.WriteLine(order2.PackingLabel());
        Console.WriteLine(order2.ShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotal()}");

    }
}
