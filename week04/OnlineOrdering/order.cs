using System;
using System.Collections.Generic;
using System.Text;

public class Order
{
    // Member variables (private)
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    // Constructor
    public Order(Customer customer)
    {
        _customer = customer;
    }

    // Add a product to the order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Get list of products (read-only copy)
    public List<Product> GetProducts()
    {
        return new List<Product>(_products);
    }

    // Calculate the subtotal (sum of product totals)
    public double GetSubtotal()
    {
        double subtotal = 0.0;
        foreach (Product product in _products)
        {
            subtotal += product.GetTotalCost();
        }
        return subtotal;
    }

    // Calculate shipping cost (simple rule): $5 if USA, else $35
    public double GetShippingCost()
    {
        if (_customer.GetAddress().IsInUSA())
        {
            return 5.00;
        }
        else
        {
            return 35.00;
        }
    }

    // Calculate total cost (subtotal + shipping)
    public double GetTotalCost()
    {
        return GetSubtotal() + GetShippingCost();
    }

    // Get packing label (product names and ids and quantities)
    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Packing Label:");
        foreach (Product product in _products)
        {
            sb.AppendLine($" - {product.GetPackingInfo()}");
        }
        return sb.ToString();
    }

    // Get shipping label (customer name and address)
    public string GetShippingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Shipping Label:");
        sb.AppendLine(_customer.GetName());
        sb.AppendLine(_customer.GetAddress().GetFullAddress());
        return sb.ToString();
    }

    // Display order summary (packing, shipping, subtotal, shipping cost, total)
    public void DisplayOrderSummary()
    {
        Console.WriteLine(new string('=', 50));
        Console.WriteLine("ORDER SUMMARY");
        Console.WriteLine(new string('-', 50));
        Console.WriteLine(GetPackingLabel());
        Console.WriteLine(GetShippingLabel());
        Console.WriteLine($"Subtotal: ${GetSubtotal():0.00}");
        Console.WriteLine($"Shipping: ${GetShippingCost():0.00}");
        Console.WriteLine($"Total: ${GetTotalCost():0.00}");
        Console.WriteLine(new string('=', 50));
    }
}
