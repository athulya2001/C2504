
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Calculator;
using LearnCSharp.Interfaces;
 
namespace LearnCSharp
{
    public class WorldClock
    {
        public DateTime IndianTime { get; set; }
        public DateTime UsTime { get; set; }
        public DateTime CanadaTime { get; set; }
 
        public WorldClock()
        {
            IndianTime = DateTime.Now;
            UsTime = DateTime.Now - TimeSpan.FromHours(12);
            CanadaTime = DateTime.Now - TimeSpan.FromHours(10);
        }
 
        public WorldClock(DateTime indianTime)
        {
            IndianTime = indianTime;
            UsTime = indianTime - TimeSpan.FromHours(12);
            CanadaTime = indianTime - TimeSpan.FromHours(10);
        }
    }
 
    internal class Program
    {
        static void Main()
        {
            var wc = new WorldClock();
            Console.WriteLine($"India: {wc.IndianTime}");
            Console.WriteLine($"US: {wc.UsTime}");
            Console.WriteLine($"Canada: {wc.CanadaTime}");
 
            var wcc = new WorldClock(DateTime.Now + TimeSpan.FromDays(365));
            Console.WriteLine($"India: {wcc.IndianTime}");
            Console.WriteLine($"US: {wcc.UsTime}");
            Console.WriteLine($"Canada: {wcc.CanadaTime}");
        }
 
    }
}
