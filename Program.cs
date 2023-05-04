namespace ConsoleApp1;

internal class Program
{
    private static List<Order> _ordersForProcessing = new();

    static void Main(string[] args)
    {
        _ordersForProcessing = new List<Order>()
        {
            new(),
            new(),
            new(),
        };
        var ordersWithDiscounts = _ordersForProcessing
            .Select(order => GetOrderWithDiscount(order, GetDiscountRules()));
        
        
    }

    private static Order GetOrderWithDiscount(Order order, List<(Func<Order, bool> QualifyingCondition, Func<Order, decimal> GetDiscount)> rules)
    {
        var discount = rules
            .Where(a => a.QualifyingCondition(order))
            .Select(b => b.GetDiscount(order))
            .OrderBy(x => x)
            .Take(3)
            .Average();
        
        // this breaks a rule in FP called "immutability" - the order object is being changed TODO: fix this
        var neworder = new Order();
        neworder.Discount = discount;
        return neworder;
    }

    private static List<(Func<Order, bool> QualifyingCondition, Func<Order, decimal> GetDiscount)> GetDiscountRules()
    {
        List<(Func<Order, bool> QualifyingCondition, Func<Order, decimal> GetDiscount)> discountRules = 
            new List<(Func<Order, bool> QualifyingCondition, Func<Order, decimal> GetDiscount)>
            {
                (IsTypeOneQualified, ApplyTypeOneDiscount),
                (IsTypeTwoQualified, ApplyTypeTwoDiscount),
                (IsTypeThreeQualified, ApplyTypeThreeDiscount)
            };

        return discountRules;
    }


    private static bool IsTypeOneQualified(Order order)
    {
        return true;
    }
    
    private static decimal ApplyTypeOneDiscount(Order order)
    {
        return 1M;
    }
    private static bool IsTypeTwoQualified(Order order)
    {
        return true;
    }
    
    private static decimal ApplyTypeTwoDiscount(Order order)
    {
        return 1M;
    }
    private static bool IsTypeThreeQualified(Order order)
    {
        return true;
    }
    
    private static decimal ApplyTypeThreeDiscount(Order order)
    {
        return 1M;
    }
}