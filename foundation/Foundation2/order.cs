using System.Collections.Generic;

class Order
{
    private List<Product> _products;
    private Customer _customer;

    // Constructor
    public Order(List<Product> products, Customer customer)
    {
        _products = products;
        _customer = customer;
    }

    // Method to calculate the total price of the order
    public double CalculateTotal()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.GetTotalPrice();
        }

        // Add shipping cost based on the customer’s address
        if (_customer.GetAddress().InsideUsa())
        {
            total += 5.00; // Shipping cost within USA
        }
        else
        {
            total += 35.00; // Shipping cost outside USA
        }
        return total;
    }

    // Method to create a packing label
    public string PackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in _products)
        {
            //Console.WriteLine($"Product: {product}");
            label += product.PackingLabel() + "\n";
        }
        return label;
    }

    // Method to create a shipping label
    public string ShippingLabel()
    {
        string label = "Shipping Label:\n";
        label += $"Customer: {_customer.GetName()}\n";
        label += $"Address: {_customer.GetAddress().GetAddress()}\n";
        return label;
    }
}
