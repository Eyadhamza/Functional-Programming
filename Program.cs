
namespace ConsoleApp1;

internal class Program
{
    private static List<double> _myData = new List<double>() { 7, 4, 5, 6, 3, 8, 10 };
    
    static void Main(string[] args)
    {
        _myData
            .Select(AddOne)
            .Select(Square)
            .Select(SubtractTen)
            .ToList()
            .ForEach(Console.WriteLine);
        
        Console.ReadLine();
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
}