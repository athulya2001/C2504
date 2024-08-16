to get a 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
 
namespace LearnCSharp
{
    class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
 
        public override string ToString()
        {
            return $"Name: {Name} {Environment.NewLine}" +
                $"Email: {Email} {Environment.NewLine}" +
                $"Age: {Age}";
        }
    }
 
    internal class Program
    {
        static void Main()
        {
            var employees = new Employee[10];
            int count = 0;
 
            while (true)
            {
                Console.WriteLine("1. Add new employee");
                Console.WriteLine("2. Search employee");
                Console.Write("Please enter your option: ");
                var option = Console.ReadLine();
 
                switch (option)
                {
                    case "1":
                        var emp = new Employee();
                        Console.Write("Name: ");
                        emp.Name = Console.ReadLine();
                        Console.Write("Email: ");
                        emp.Email = Console.ReadLine();
                        Console.Write("Age: ");
                        emp.Age = int.Parse(Console.ReadLine());
                        employees[count] = emp;
                        count++;
                        break;
                    case "2":
                        Console.WriteLine("Email: ");
                        var email = Console.ReadLine();
 
                        for (int i = 0; i < count; i++)
                        {
                            var e = employees[i];
                            if (e.Email == email)
                            {
                                Console.WriteLine(e);
                                break;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
 
    }

}


  2. To get a string and change into 
      a. to upper
      b. to lower
      c. to trim
using enum string conversion


using System;

enum Convertion
{
    Upper,
    Lower,
    Trim
}

internal class Program
{
    static void Convert(string text, Convertion action)
    {
        // Using if-else to perform the conversion
        if (action == Convertion.Upper)
            Console.WriteLine(text.ToUpper());
        else if (action == Convertion.Lower)
            Console.WriteLine(text.ToLower());
        else if (action == Convertion.Trim)
            Console.WriteLine(text.Trim());

        // Using switch to perform the conversion
        switch (action)
        {
            case Convertion.Upper:
                Console.WriteLine(text.ToUpper());
                break;
            case Convertion.Lower:
                Console.WriteLine(text.ToLower());
                break;
            case Convertion.Trim:
                Console.WriteLine(text.Trim());
                break;
            default:
                break;
        }
    }

    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        Console.WriteLine("1. To Upper");
        Console.WriteLine("2. To Lower");
        Console.WriteLine("3. To Trim");

        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        Convertion action;

        switch (choice)
        {
            case 1:
                action = Convertion.Upper;
                break;
            case 2:
                action = Convertion.Lower;
                break;
            case 3:
                action = Convertion.Trim;
                break;
            default:
                Console.WriteLine("Invalid choice");
                return;
        }

        Convert(input, action);
    }
}
      
using System;

namespace StringManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Convert to uppercase");
            Console.WriteLine("2. Convert to lowercase");
            Console.WriteLine("3. Trim");

            int action = int.Parse(Console.ReadLine());
            string result = "";

            switch (action)
            {
                case 1:
                    result = input.ToUpper();
                    break;
                case 2:
                    result = input.ToLower();
                    break;
                case 3:
                    result = input.Trim();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }

            Console.WriteLine("Result: " + result);
        }
    }
}
