public class Program
{


    private static void PrintDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
     where TKey : notnull
    {
        foreach (var (key, value) in dictionary)
        {
            System.Console.WriteLine($"key : {key} | value : {value}");
        }
    }
    private static void Main(string[] args)
    {
        var students = new Dictionary<int, string>
{
    { 1, "Ahmad" },
    { 2, "Omar" },
    { 3, "Khaled" }
};

        PrintDictionary(students);
    }


}