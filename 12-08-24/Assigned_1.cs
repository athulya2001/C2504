using System;

class YahkoopV2
{
    static void ReadDoctorSalaryTillMinus1()
    {
        int[] salaries = new int[50]; // assuming max 100 salaries
        int count = 0;
        Console.Write("Enter salary: ");

        do
        {
         
            int salary = int.Parse(Console.ReadLine());

            if (salary == -1) // to stop input cond
            {
                break;
            }
            if (salary < 0) // validation
            {
                Console.WriteLine("Invalid salary");
                continue;
            }

            salaries[count] = salary;
            count++;
        } while (true);

        int sum = CalculateSum(salaries, count);
        int avg = CalculateAverage(sum, count);
        int primeCount = CountPrimeSalaries(salaries, count);
        int minFourDigitsCount = CountMinimumFourDigitsSalaries(salaries, count);
        int max = FindMaximumSalary(salaries, count);
        int oddSum = CalculateOddSalariesSum(salaries, count);
        int minOdd = FindMinimumOddSalary(salaries, count);
        int secondMinOdd = FindSecondMinimumOddSalary(salaries, count);

        bool isMaxPrime = IsPrime(max);

        Console.WriteLine($"Average Salary: {avg}");
        Console.WriteLine($"Prime Salaries#: {primeCount}");
        Console.WriteLine($"Min Four Digits Salaries#: {minFourDigitsCount}");
        Console.WriteLine($"Max Salary#: {max}");
        Console.WriteLine($"Odd Salaries Sum#: {oddSum}");
        Console.WriteLine($"Min Odd Salary#: {minOdd}");
        Console.WriteLine($"Second Min Odd Salary#: {secondMinOdd}");
        if (isMaxPrime) // check if maximum salary is prime
        {
            Console.WriteLine("Maximum salary is also prime ");
        }
        else
        {
            Console.WriteLine("Maximum salary is not prime ");
        }
    }

    static int CalculateSum(int[] salaries, int count)
    {
        int sum = 0;
        for (int i = 0; i < count; i++)
        {
            sum += salaries[i];
        }
        return sum;
    }

    static int CalculateAverage(int sum, int count)
    {
        return sum / count;
    }

    static int CountPrimeSalaries(int[] salaries, int count)
    {
        int primeCount = 0;
        for (int i = 0; i < count; i++)
        {
            if (IsPrime(salaries[i]))
            {
                primeCount++;
            }
        }
        return primeCount;
    }

    static int CountMinimumFourDigitsSalaries(int[] salaries, int count)
    {
        int minFourDigitsCount = 0;
        for (int i = 0; i < count; i++)
        {
            if (IsMinimumFourDigits(salaries[i]))
            {
                minFourDigitsCount++;
            }
        }
        return minFourDigitsCount;
    }

    static int FindMaximumSalary(int[] salaries, int count)
    {
        int max = salaries[0];
        for (int i = 1; i < count; i++)
        {
            if (salaries[i] > max)
            {
                max = salaries[i];
            }
        }
        return max;
    }

    static int CalculateOddSalariesSum(int[] salaries, int count)
    {
        int oddSum = 0;
        for (int i = 0; i < count; i++)
        {
            if (IsOdd(salaries[i]))
            {
                oddSum += salaries[i];
            }
        }
        return oddSum;
    }

    static int FindMinimumOddSalary(int[] salaries, int count)
    {
        int minOdd = int.MaxValue;
        for (int i = 0; i < count; i++)
        {
            if (IsOdd(salaries[i]) && salaries[i] < minOdd)
            {
                minOdd = salaries[i];
            }
        }
        return minOdd;
    }

    static int FindSecondMinimumOddSalary(int[] salaries, int count)
    {
        int minOdd = int.MaxValue;
        int secondMinOdd = int.MaxValue;
        for (int i = 0; i < count; i++)
        {
            if (IsOdd(salaries[i]) && salaries[i] < minOdd)
            {
                secondMinOdd = minOdd;
                minOdd = salaries[i];
            }
            else if (IsOdd(salaries[i]) && salaries[i] < secondMinOdd && salaries[i] != minOdd)
            {
                secondMinOdd = salaries[i];
            }
        }
        return secondMinOdd;
    }

    static bool IsPrime(int salary)
            {
                bool isPrime = true;
                int sqrtSal = (int)Math.Sqrt((double)salary);
                for (int i = 2; i <= sqrtSal; i++)
                {
                    if (salary % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                return isPrime;
            }

        static bool IsMinimumFourDigits(int salary)
        {
            return salary >= 1000;
        }

        static bool IsOdd(int salary)
        {
            return salary % 2 != 0;
        }

        static void TestReadDoctorSalaryTillMinus1()
        {
            ReadDoctorSalaryTillMinus1();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("-----TestReadDoctorSalaryTillMinus1-----");
            TestReadDoctorSalaryTillMinus1();
            Console.WriteLine("-----End TestReadDoctorSalaryTillMinus1-----");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
