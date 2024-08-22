using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DetailsPrint
{
    enum AddressType
    {
        Home,
        Office
    }
    class Country
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
    class Address
    {
        public  AddressType AddressTypes { get; set; }
        public String FullAddress {  get; set; }
        public Country[] Country { get; set; }
    }
    class Experience
    {
        public string CompanyName { get; set; }
        public string Website { get; set; }
        public Address[] CompanyAddresses { get; set; }
        public int ExperienceInYears { get; set; }

    }
    class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Address[] Addresses { get; set; }
        public Experience[] Experiences { get; set; }
        public long PhoneNumber {  get; set; }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var Ath = new Employee
            {
                Name = "Athulya Shaji",
                Email = "sathulya2001@gmail.com",
                Addresses = new Address[]
            {
                new Address
                {
                    AddressTypes = AddressType.Home,
                    FullAddress = "Muthirakkalayil",
                    Country = new Country[]
                    {
                        new Country
                        {
                            Name = "India",
                            Code = "+91"
                        }
                    }
                }
            },
                Experiences = new Experience[]
            {
                new Experience
                {
                    CompanyName = "QuestGloabal",
                    Website = "www.questglobal.in",
                    CompanyAddresses = new Address[]
                    {
                        new Address
                        {
                            AddressTypes = AddressType.Office,
                            FullAddress = "QuestGLobal LTD,",
                            Country = new Country[]
                            {
                                new Country
                                {
                                    Name = "India",
                                    Code = "+91"
                                }
                            }
                        }
                    }
                }
            },
                PhoneNumber = 9856321478
            };
            Console.WriteLine("Employee Details:");
            Console.WriteLine($"Name: {Ath.Name}");
            Console.WriteLine($"Email: {Ath.Email}");
            Console.WriteLine("Addresses");
            foreach (var address in Ath.Addresses)
            {
                Console.WriteLine($"{address.AddressTypes}: {address.FullAddress}, {address.Country[0].Name} ({address.Country[0].Code})");
            }
            Console.WriteLine("Experiences");
            foreach (var experience in Ath.Experiences)
            {
                Console.WriteLine($"Company: {experience.CompanyName}, Website: {experience.Website}");
                Console.WriteLine("Company Addresses:");
                foreach (var companyAddress in experience.CompanyAddresses)
                {
                    Console.WriteLine($"{companyAddress.AddressTypes}: {companyAddress.FullAddress}, {companyAddress.Country[0].Name} ({companyAddress.Country[0].Code})");
                }
            }
            Console.WriteLine($"Phone Number: {Ath.PhoneNumber}");
        }
    }
}
