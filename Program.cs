
namespace ConsoleApp1;

internal static class Program
{
    private static readonly List<double> MyData = new() { 7, 4, 5, 6, 3, 8, 10 };
    
    static void Main()
    {
        MyData
            .Select(AddOne)
            .Select(Square)
            .Select(SubtractTen)
            .ToList()
            .ForEach(Console.WriteLine);
        
        MyData
            .Select(AddOneSquareSubtractTen())
            .ToList()
            .ForEach(Console.WriteLine);

        Console.ReadLine();
    }

    private static Func<double, double> AddOneSquareSubtractTen()
    {
        Func<double, double> addOne = AddOne;
        Func<double, double> square = Square;
        Func<double, double> subtractTen = SubtractTen;
        
        return addOne.Compose(square).Compose(subtractTen);
    }

    private static double AddOne(double x)
    {
        return x + 1;
    }
    private static double Square(double x)
    {
        return x * x;
    }
    private static double SubtractTen(double x)
    {
        return x - 10;
    }

    private static Func<T1, T3> Compose<T1, T2, T3>(this Func<T1, T2> f, Func<T2, T3> g)
    {
        return x => g(f(x));
    }
}