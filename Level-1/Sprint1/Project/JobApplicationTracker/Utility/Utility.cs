
namespace JobApplicationTracker.Utility;

public static class Utility
{
    public static void PrintSubMenu(string title)
    {
        Console.WriteLine($"\n========== {title} ==========");
        Console.WriteLine();
        Console.WriteLine("  1. Add");
        Console.WriteLine("  2. Update");
        Console.WriteLine("  3. List");
        Console.WriteLine("  4. Remove");
        Console.WriteLine("  5. Get");
        Console.WriteLine("  6. Change Status");
        Console.WriteLine("  7. List By Status");
        Console.WriteLine("  8. Undo Status");
        Console.WriteLine("  0. Back");
        Console.WriteLine($"\n=============================");
    }

    public static void PrintBasicSubMenu(string title)
    {
        Console.WriteLine($"\n========== {title} ==========");
        Console.WriteLine();
        Console.WriteLine("  1. Add");
        Console.WriteLine("  2. Update");
        Console.WriteLine("  3. List");
        Console.WriteLine("  4. Remove");
        Console.WriteLine("  5. Get");
        Console.WriteLine("  0. Back");
        Console.WriteLine($"\n=============================");
    }
}