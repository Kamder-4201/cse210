using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Address address2 = new Address("10 Downing St", "London", "England", "UK");

        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Mary Smith", address2);

        Product product1 = new Product("Laptop", "L001", 999.99, 1);
        Product product2 = new Product("Mouse", "M123", 25.50, 2);
        Product product3 = new Product("Keyboard", "K567", 45.00, 1);

        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():0.00}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():0.00}\n");
    }
}
