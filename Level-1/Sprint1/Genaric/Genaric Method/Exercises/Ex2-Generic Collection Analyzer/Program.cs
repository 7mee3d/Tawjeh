public class Program
{

    private static clsAnalyzeCollection<T> AnalyzeCollection<T>(IEnumerable<T> values)
    {
        int count = 0;
        T first = default;
        T last = default;
        bool hasItems = false;

        foreach (var item in values)
        {
            if (!hasItems)
            {
                first = item;
                hasItems = true;
            }

            last = item;
            count++;
        }
        return new clsAnalyzeCollection<T>(count, first, last, hasItems);
    }

    private static void Main(string[] args)
    {
        var numbers = new List<int> { 10, 20, 30, 40, 50 };

        var result = AnalyzeCollection(numbers);

        Console.WriteLine($"Count: {result.Count}");
        Console.WriteLine($"First: {result.First}");
        Console.WriteLine($"Last: {result.Last}");
        Console.WriteLine($"Has Items: {result.HasItems}");
    }

    public class clsAnalyzeCollection<T>
    {
        public int Count { get; private set; }
        public T First { get; private set; }
        public T Last { get; private set; }
        public bool HasItems { get; private set; }

        public clsAnalyzeCollection(int count, T first, T last, bool hasItems)
        {
            this.Count = count;
            this.First = first;
            this.Last = last;
            this.HasItems = hasItems;
        }
    }
}