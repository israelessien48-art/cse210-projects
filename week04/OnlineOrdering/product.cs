using System;

public class Product
{
    // Member variables (private)
    private string _name;
    private string _id;
    private double _price;
    private int _quantity;

    // Constructor
    public Product(string name, string id, double price, int quantity)
    {
        _name = name;
        _id = id;
        _price = price;
        _quantity = quantity;
    }

    // Properties (read-only accessors)
    public string Name { get { return _name; } }
    public string Id { get { return _id; } }
    public double Price { get { return _price; } }
    public int Quantity { get { return _quantity; } }

    // Behavior: compute total cost for this product (price * quantity)
    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    // Return a short packing info string for this product
    public string GetPackingInfo()
    {
        return $"{_name} (ID: {_id}) x{_quantity}";
    }
}
