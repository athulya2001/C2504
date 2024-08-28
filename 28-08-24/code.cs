using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview_prep
{
   
    internal class Program
    {
        
        static void Main()
        {
            Console.Write("Enter string :");
            var s = Console.ReadLine();
            string data = "           this is some text          ";
            //to remove spaces
            Console.WriteLine(data.Trim());
            Console.WriteLine(data.TrimStart());
            Console.WriteLine(data.TrimEnd());

            Console.WriteLine(data.StartsWith(" "));
            Console.WriteLine(data.EndsWith(" "));

            Console.WriteLine(data.Contains(" "));
            Console.WriteLine(data.Remove(0, 3));
            Console.WriteLine(data.Replace(" ", "_"));
            Console.WriteLine(data.IndexOf("text"));
            Console.WriteLine(data.Contains("is"));

            Console.WriteLine(data.Split(' '));

            data = data.Trim().Replace(" ", "_").Replace("text", "data");
            Console.WriteLine(data);

            var numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, };
            Console.WriteLine(numbers[0]);
            Console.WriteLine(numbers[numbers.Length - 1]);
            Console.WriteLine(numbers.Last());
            Console.WriteLine(numbers.First());
            Console.WriteLine(numbers.Min());
            Console.WriteLine(numbers.Max());
            Console.WriteLine(numbers.Average());
            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.OrderBy(m => m));

            var largest = numbers.Take(5).Max();
            Array.Sort(numbers);
            Array.Reverse(numbers);
            Array.Sort(numbers);

        }
    }
}
var groups = s.GroupBy(mm);
foreach (var it2 in groups)
{
    Console.WriteLine($"{it2.Key} exists {it2.count()} times ");
}
var @counted = new List<int>();
foreach (var @item in s)
{
    if (counted.Contains(@item))
        continue;
    counted.Add(@item);
    Console.Write($"Count of {item} is ");
    int count = 0;
    foreach (var item1 in s)
    {
        if (item1 == item)
            count++;
    }

    Console.WriteLine($"{count}");
}

static int FindCharArray(char[] letters, int N, char target)
{
    foreach (var item in letters)
    {
        int index = 0;
        if (item == target)
        {
            return index;
        }
        index++;
    }
    return -1;
}
Console.WriteLine("Enter String :");
string sentence = Console.ReadLine();
char[] letters = new char[1000];
int numOfLetters = 0;
int[] counts = new int[1000];
foreach (var ch in sentence)
{
    int pos = FindCharArray(letters, numOfLetters, ch);
    if (pos != -1)
    {
        counts[pos]++;
        continue;
    }
    letters[numOfLetters] = ch;
    counts[numOfLetters] += 1;
    numOfLetters++;
}
for (int i = 0; i < numOfLetters; i++)
{
    Console.WriteLine($"{letters[i]} occured {counts[i]} times");
}
