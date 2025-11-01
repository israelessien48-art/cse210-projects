using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create first customer and order (USA)
        Address address1 = new Address("123 Maple St", "Boise", "ID", "USA");
        Customer customer1 = new Customer("Israel Essien", address1);
        Order order1 = new Order(customer1);

        // Add products to order1
        order1.AddProduct(new Product("Wireless Mouse", "WM-100", 19.99, 2));
        order1.AddProduct(new Product("USB-C Cable", "UC-200", 9.99, 3));
        order1.AddProduct(new Product("Laptop Sleeve", "LS-310", 25.00, 1));

        // Create second customer and order (International)
        Address address2 = new Address("27 King Street", "London", "Greater London", "United Kingdom");
        Customer customer2 = new Customer("Aisha Khan", address2);
        Order order2 = new Order(customer2);

        // Add products to order2
        order2.AddProduct(new Product("Noise-Cancelling Headphones", "NH-800", 150.00, 1));
        order2.AddProduct(new Product("Bluetooth Speaker", "BS-400", 49.99, 2));

        // Optionally: create a third order to show diversity (not required)
        // Address address3 = new Address("500 Queen Blvd", "Toronto", "ON", "Canada");
        // Customer customer3 = new Customer("Carlos Mendez", address3);
        // Order order3 = new Order(customer3);
        // order3.AddProduct(new Product("Smart Watch", "SW-700", 199.99, 1));
        // order3.AddProduct(new Product("Screen Protector", "SP-05", 7.50, 2));

        // Store orders in a list
        List<Order> orders = new List<Order> { order1, order2 /*, order3 */ };

        // Display order summaries
        Console.WriteLine("=== Online Ordering Program: Orders ===\n");
        foreach (Order order in orders)
        {
            order.DisplayOrderSummary();
            Console.WriteLine(); // extra spacing between orders
        }

        Console.WriteLine("End of program execution.");
    }
}
