using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class Product
    {
        public string Name { get; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Product(string name, int quantity, decimal price)
        {
            Name = name;
            Quantity = quantity;
            Price = price;

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var product = new (string Name, int stock, bool threshold)[]
            {
                ("Roti", 30,true),
                ("Biscut", 45,true),
                ("Sweets", 55,false),
                ("Laddu", 38,true),
                ("Spices", 80,true),
            };
            foreach (var item in product)
            {
                Console.Write("Product : ");
                Console.WriteLine(item.Name);
                Console.Write("Stock : ");
                Console.WriteLine(item.stock);
                Console.Write("Threshold : ");
                Console.WriteLine(item.threshold);
            }
        }
    }
}



//tuple
var res = ToUpperAndLower("Hello World");
Console.WriteLine(res.Lower);
dictionary
var arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
foreach (var item in arr)
{
    Console.WriteLine(item);
}
string str = "string";
foreach (var item in str)
{
    Console.WriteLine(item);
}


//2D for array
int[,] array = new int[5, 3];
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Enter student {i + 1} 3 marks: ");
    for (int j = 0; j < 3; j++)
    {
        array[i, j] = int.Parse(Console.ReadLine());
    }

}

//foreach loop

foreach (var item in array)
{

    Console.WriteLine(item);
}
var studentMark = new (int English, int Malayalam, int Physiscs)[]
{
    (20,30,40),
    (20,30,40),
    (20,30,40),
    (20,30,40),
    (20,30,40),
};
foreach (var item in studentMark)
{
    Console.Write("English : ");
    Console.WriteLine(item.English);
    Console.Write("Malayalam : ");
    Console.WriteLine(item.Malayalam);
    Console.Write("Physics : ");
    Console.WriteLine(item.Physiscs);
}
Console.WriteLine(" ");



banking example

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    internal class Program
    {
        class AccountDetail
        {
            public long AccountNumber { get; set; }
            public string Name { get; set; }
            public double Balance { get; set; }
        }
        public class Bank
        {
            enum BankFunctions
            {
                Deposit = 1,
                ViewBalance ,
                Transaction ,
                CreateAccount
            }
            private List<AccountDetail> _accounts;
            public Bank()
            {
                _accounts = new List<AccountDetail>();
            }
            public void Deposit()
            {

            }
            public void ViewBalance() 
            { 

            }
            public void Transaction()
            {

            }
            public void CreateAccount()
            {

            }
        }
        static void Main(string[] args)
        {
            var bank = new Bank();
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. View Balance");
            Console.WriteLine("3. Transaction");
            Console.WriteLine("4. Create Account");

            var option = (Bank.BankFunctions)int.Parse(Console.ReadLine());
        }
    }
}
