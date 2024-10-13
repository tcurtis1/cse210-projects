using System;

class Product
{
    private string _name;
    private int _productId;
    private double _price;
    private int _quantity;

    // Constructor
    public Product(string name, int productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    // Method to get the total price of the product (price * quantity)
    public double GetTotalPrice()
    {
        return _price * _quantity;
    }

    // Packing label contains product details
    public string PackingLabel()
    {
        return $"{_name} (ID: {_productId}) - {_quantity} unit(s)";
    }
}
