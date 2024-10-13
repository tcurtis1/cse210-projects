class Customer
{
    private string _name;
    private Address _address;

    // Constructor
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Getter for customer name
    public string GetName()
    {
        return _name;
    }

    // Getter for customer address
    public Address GetAddress()
    {
        return _address;
    }
}
