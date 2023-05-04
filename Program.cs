
namespace ConsoleApp1;

internal class Program
{
    private static Func<int, (double x1, double x2)> _productParameterFoodDelegate = ProductParameterFood;
    private static Func<int, (double x1, double x2)> _productParameterBeverageDelegate = ProductParameterBeverage;
    private static Func<int, (double x1, double x2)> _productParameterRawMaterialDelegate = ProductParameterRawMaterial;
    private static Order _order = new() {OrderId = 10, ProductIndex = 100, Quantity = 20, UnitPrice = 4};
    static void Main(string[] args)
    {
        var product = ProductType.Food;
        
        Func<int, (double x1, double x2)> productParameterCalc = product switch
        {
            ProductType.Food => _productParameterFoodDelegate,
            ProductType.Beverage => _productParameterBeverageDelegate,
            ProductType.RawMaterial => _productParameterRawMaterialDelegate,
            _ => throw new ArgumentOutOfRangeException(nameof(product), product, null)
        };
        
        Console.WriteLine(CalculateDiscount(productParameterCalc, _order));
    }

    private static double CalculateDiscount(Func<int, (double x1, double x2)> productParameterCalc, Order order)
    {
        (double x1, double x2) parameters = productParameterCalc(order.ProductIndex);
        
        return parameters.x1 * order.Quantity + parameters.x2 * order.UnitPrice;
    }
    
    private static (double x1, double x2) ProductParameterFood(int productIndex)
    {
        return (x1:productIndex / (double) (productIndex + 100), x2:productIndex / (double) (productIndex + 200));
    }

    private static (double x1, double x2) ProductParameterBeverage(int productIndex)
    {
        return (x1:productIndex / (double) (productIndex + 200), x2:productIndex / (double) (productIndex + 300));
    }
    private static (double x1, double x2) ProductParameterRawMaterial(int productIndex)
    {
        return (x1:productIndex / (double) (productIndex + 300), x2:productIndex / (double) (productIndex + 400));
    }

}
