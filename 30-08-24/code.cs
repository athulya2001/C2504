using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace Timer
{
    public delegate void Tim(int Time);
    internal class Program
    {
        public delegate void Timer(int Time);
        public static void SetTimer(int Time)
        {
            Console.WriteLine(Time);
        }
 static void Main(string[] args)
        {
            Tim T = SetTimer;
            Thread.Sleep(1000);
            T(100);
        }
    }
}

public static bool IsOdd(int number)
{
    return number % 2 != 0;
}
public static bool IsEven(int number)
{
    return number % 2 == 0;
}
public static void Check(int[] numbers,  Predicate<int> condition)
{
    foreach (var num in numbers)
    {
        if (condition(num))
        {
            Console.WriteLine(num);
        }
    }
}

 
