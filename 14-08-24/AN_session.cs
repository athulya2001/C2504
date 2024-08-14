1. Rectangle code
    class Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

        //public int Agre => Width * Height;

        public int Area() => Width * Height;

        public void IsOtherRectangleAreaGt(Rectangle rectangle)
        {
            if (rectangle.Area() > Area())
                Console.WriteLine("The other rectangle has more area.");
            else
                Console.WriteLine("This rectangle has more area.");
        }

        public override string ToString()
        {
            return $"Width = {Width} | Height = {Height}";
        }
    }

static void Main()
{
    var r1 = new Rectangle { Height = 10, Width = 20 };
    var r2 = new Rectangle { Height = 100, Width = 200 };

    //r1.IsOtherRectangleAreaGt(r2);

    Console.WriteLine(r1);
    Console.WriteLine(r2);
    string v = r1.ToString();
    Console.WriteLine(v);
}



2. Calcuator code


class Calculator
{
    private double _numOne;
    private double _numTwo;

    private void Add() => Console.WriteLine($"{_numOne} + {_numTwo} = {_numOne + _numTwo}");
    private void Sub() => Console.WriteLine($"{_numOne} - {_numTwo} = {_numOne - _numTwo}");
    private void Mul() => Console.WriteLine($"{_numOne} * {_numTwo} = {_numOne * _numTwo}");
    private void Div() => Console.WriteLine($"{_numOne} / {_numTwo} = {_numOne / _numTwo}");
    public void Run()
    {
        while (true)
        {
            Console.Write("Num 1: ");
            _numOne = double.Parse(Console.ReadLine());
            Console.Write("Num 2: ");
            _numTwo = double.Parse(Console.ReadLine());

            Add();
            Sub();
            Mul();
            Div();

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
