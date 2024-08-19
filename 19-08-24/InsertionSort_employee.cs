using System;
using System.Collections.Generic;

abstract class Employee
{
    public string Name { get; set; }
    public abstract double CalculateSalary();
}

class FullTimeEmployee : Employee
{
    public double BaseSalary { get; set; }
    public double BonusPercentage { get; set; }

    public override double CalculateSalary()
    {
        return BaseSalary + (BaseSalary * BonusPercentage / 100);
    }
}

class PartTimeEmployee : Employee
{
    public double HourlyRate { get; set; }
    public double HoursWorked { get; set; }

    public override double CalculateSalary()
    {
        return HourlyRate * HoursWorked;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Employee> employees = new List<Employee>();

        Console.Write("Enter the number of employees: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nEnter details for employee {i + 1}:");
            Console.Write("Enter employee type (FullTime or PartTime): ");
            string type = Console.ReadLine();

             Employee employee = null;
            if (type.ToLower() == "fulltime")
            {
                employee = new FullTimeEmployee();
                Console.Write("Enter name: ");
                employee.Name = Console.ReadLine();

                Console.Write("Enter base salary: ");
                ((FullTimeEmployee)employee).BaseSalary = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter bonus percentage: ");
                ((FullTimeEmployee)employee).BonusPercentage = Convert.ToDouble(Console.ReadLine());
            }
            else if (type.ToLower() == "parttime")
            {
                employee = new PartTimeEmployee();
                Console.Write("Enter name: ");
                employee.Name = Console.ReadLine();

                Console.Write("Enter hourly rate: ");
                ((PartTimeEmployee)employee).HourlyRate = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter hours worked: ");
                ((PartTimeEmployee)employee).HoursWorked = Convert.ToDouble(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Invalid employee type.");
                i--;
                continue;
            }

            employees.Add(employee);
        }

        Console.WriteLine("\nEmployees before sorting:");
        PrintEmployees(employees);

        InsertionSort(employees);

        Console.WriteLine("\nEmployees after sorting:");
        PrintEmployees(employees);
    }

    static void InsertionSort(List<Employee> employees)
    {
        for (int i = 1; i < employees.Count; i++)
        {
            Employee key = employees[i];
            double keySalary = key.CalculateSalary();
            int j = i - 1;

            while (j >= 0 && employees[j].CalculateSalary() > keySalary)
            {
                employees[j + 1] = employees[j];
                j = j - 1;
            }
            employees[j + 1] = key;
        }
    }
    // 23 1 12 5 I=1
    //static void InsertionSort(List<Employee> employees)
    //{
    //    for (int i = 1; i < employees.Count; i++)
    //    {
    //        Employee key = employees[i];
    //        int j = i - 1;

    //        // Shift elements of the sorted portion that are greater than the key
    //        while (j >= 0 && employees[j].CalculateSalary() > key.CalculateSalary())
    //        {
    //            employees[j + 1] = employees[j];
    //            j--;
    //        }

    //        // Place the key element in its correct position
    //        employees[j + 1] = key;
    //    }
    //}


    static void PrintEmployees(List<Employee> employees)
    {
        foreach (var employee in employees)
        {
            Console.WriteLine($"{employee.Name}, Salary: {employee.CalculateSalary():C}");
        }
    }
