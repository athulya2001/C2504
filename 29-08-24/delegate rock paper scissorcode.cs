public class Rectangle
{
    public double Width { get; set; }
    public double Height { get; set; }

    // Constructor
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    // IsGreater method signature
    public bool IsGreater(Rectangle other)
    {
        double thisArea = this.Width * this.Height;
        double otherArea = other.Width * other.Height;
        return thisArea > otherArea;
    }
}

2
using System;

class Product
{
    public string Name { get; set; }
    public double Price { get; set; }

    // Virtual method for displaying product details
    public virtual void Display()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Price: {Price}");
    }
}

class ElectronicProduct : Product
{
    public int WarrantyPeriod { get; set; } // Warranty period in months

    // Override the Display method to include WarrantyPeriod
    public override void Display()
    {
        base.Display(); // Call the base class Display method
        Console.WriteLine($"Warranty Period: {WarrantyPeriod} months");
    }
}

class GroceryProduct : Product
{
    public DateTime ExpiryDate { get; set; }

    // Override the Display method to include ExpiryDate
    public override void Display()
    {
        base.Display(); // Call the base class Display method
        Console.WriteLine($"Expiry Date: {ExpiryDate.ToShortDateString()}");
    }
}

class Program
{
    static void Main()
    {
        // Create an ElectronicProduct object
        ElectronicProduct laptop = new ElectronicProduct
        {
            Name = "Laptop",
            Price = 1200.99,
            WarrantyPeriod = 24
        };

        // Create a GroceryProduct object
        GroceryProduct milk = new GroceryProduct
        {
            Name = "Milk",
            Price = 2.99,
            ExpiryDate = new DateTime(2024, 9, 10)
        };

        // Display details of both products
        Console.WriteLine("Electronic Product Details:");
        laptop.Display();

        Console.WriteLine("\nGrocery Product Details:");
        milk.Display();
    }
}
