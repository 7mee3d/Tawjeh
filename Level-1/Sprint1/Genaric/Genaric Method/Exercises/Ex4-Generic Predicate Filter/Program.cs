public class Program
{


    private static List<T> FilterItems<T>(IEnumerable<T> items, Predicate<T> predicate)
    {
        List<T> values = new();

        foreach (var item in items)
            if (predicate(item))
                values.Add(item);


        return values;
    }

    private static void Main(string[] args)
    {
        var numbers = new List<int> { 5, 10, 15, 20, 25, 30 };

        var result = FilterItems(numbers, number => number > 15);

        foreach (var item in result)
            System.Console.WriteLine(item);
    }


}