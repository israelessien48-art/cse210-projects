using System;

public class Customer
{
    // Member variables (private)
    private string _name;
    private Address _address;

    // Constructor
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Properties
    public string Name { get { return _name; } }
    public Address Address { get { return _address; } }

    // Returns the customer's name (for shipping label)
    public string GetName()
    {
        return _name;
    }

    // Returns the customer's address
    public Address GetAddress()
    {
        return _address;
    }
}
