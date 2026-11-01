
public class Program
{
    private static T FindFirst<T>(IEnumerable<T> items, T value)
    {
        return items.FirstOrDefault(x => EqualityComparer<T>.Default.Equals(x, value));

    }

    private static void Main(string[] args)
    {
        var numbers = new List<int> { 10, 20, 30, 40, 50 };

        var result = FindFirst(numbers, 30);
        System.Console.WriteLine(result);
    }
}