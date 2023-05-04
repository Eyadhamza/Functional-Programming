
namespace ConsoleApp1;

internal class Program
{
    
    static void Main(string[] args)
    {
        Func<double, double> dlgtTest1 = Test1;
        Func<double, double> dlgtTest2 = Test2;

        List<Func<double, double>> delegates = new List<Func<double, double>>
        {
            dlgtTest1,
            dlgtTest2
        };
        // these are not considered higher order functions.
        // the function only accepts a double and returns a double.
        Console.WriteLine(Test2(Test1(5)).ToString());
        Console.WriteLine(Test1(Test2(5)).ToString());

        // invocation through the delegates
        Console.WriteLine(delegates[0](5).ToString()); 
        Console.WriteLine(delegates[1](5).ToString());
        
        // higher order functions
        Console.WriteLine(Test3(Test1, 5).ToString());
        Console.WriteLine(Test3(Test2, 5).ToString());
        Console.ReadLine();
    }

    private static double Test1(double x)
    {
        return x / 2;
    }
    private static double Test2(double x)
    {
        return x / 4 + 1;
    }
    private static double Test3(Func<double, double> func, double value)
    {
        return func(value) + value;
    }
}