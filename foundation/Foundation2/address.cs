class Address
{
    private string _address;

    // Constructor
    public Address(string address)
    {
        _address = address;
    }

    // Method to check if the address is in the USA
    public bool InsideUsa()
    {
        return _address.Contains("USA"); // Basic check for "USA" in the address string
    }

    // Getter for address (used for shipping label)
    public string GetAddress()
    {
        return _address;
    }
}
