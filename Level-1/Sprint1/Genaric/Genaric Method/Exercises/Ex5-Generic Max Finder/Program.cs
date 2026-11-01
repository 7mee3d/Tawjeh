public class Program
{

    private static T FindMax<T>(IEnumerable<T> values) where T : IComparable<T>
    {

        if (values.Count() <= 0)
            return default(T);

        T maxValue = default(T);
        bool hasITems = false;

        foreach (T item in values)
        {
            if (!hasITems)
            {
                maxValue = item;
                hasITems = true;
                continue;
            }

            if (item.CompareTo(maxValue) > 0)
                maxValue = item;
        }

        return maxValue;
    }

    private static void Main(string[] args)
    {
        var numbers = new List<int> { 15, 80, 25, 100, 40 };

        var maxNumber = FindMax(numbers);

        Console.WriteLine(maxNumber); // 100
    }


}