using System;

public class Address
{
    // Member variables (private)
    private string _street;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    // Constructor
    public Address(string street, string city, string stateOrProvince, string country)
    {
        _street = street;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    // Properties
    public string Street { get { return _street; } }
    public string City { get { return _city; } }
    public string StateOrProvince { get { return _stateOrProvince; } }
    public string Country { get { return _country; } }

    // Returns the full formatted address (multi-line)
    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_stateOrProvince}\n{_country}";
    }

    // Helper: is the address in the USA? (used for shipping cost logic)
    public bool IsInUSA()
    {
        // Accept common variants
        return _country.Trim().ToUpper() == "USA" ||
               _country.Trim().ToUpper() == "UNITED STATES" ||
               _country.Trim().ToUpper() == "UNITED STATES OF AMERICA";
    }
}
