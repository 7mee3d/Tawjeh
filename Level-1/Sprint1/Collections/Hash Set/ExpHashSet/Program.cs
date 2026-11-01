
public class Program
{
    private static void Main(string[] args)
    {
        HashSet<string> ArishWantedPlates = new HashSet<string>()
        {
            "Arish-123",
            "Arish-456" ,
            "Arish-789"
        };

        HashSet<string> BlacklistArish = new HashSet<string>
        {
              "Arish-123"
        };

        //Add
        var isAdded = ArishWantedPlates.Add("Arish-123"); //Uniqueness 
        System.Console.WriteLine($"{isAdded}");

        //Contain 
        var blackCarArish = "Arish-123";
        if (BlacklistArish.Contains(blackCarArish))
        {
            System.Console.WriteLine($"This car {blackCarArish} in blacklsit");
        }
        else
        {
            System.Console.WriteLine($"This car {blackCarArish} is not in blacklsit");
        }

        //UnionWith 
        HashSet<string> CairoWantedPlates = new HashSet<string>
        {
            "Arish-123",
            "Arish-321" ,
            "Arish-654"
        };

        HashSet<string> UnionTwoHashSet = new HashSet<string>(ArishWantedPlates);
        UnionTwoHashSet.UnionWith(CairoWantedPlates);
        System.Console.WriteLine("\n\n");
        foreach (var item in UnionTwoHashSet)
            System.Console.WriteLine(item);

        //IntersectWith 

        HashSet<string> IntersectWith = new HashSet<string>()
        {
            "Arish-456"
        };

        ArishWantedPlates.IntersectWith(IntersectWith);
        System.Console.WriteLine("\n\nIntersectWith ");
        foreach (var item in ArishWantedPlates)
        {
            System.Console.WriteLine(item);
        }

        HashSet<string> ExceptWith = new HashSet<string>()
        {
            "Arish-456"
        };

        ArishWantedPlates.ExceptWith(BlacklistArish);
        System.Console.WriteLine("\n\nExceptWith ");
        foreach (var item in ArishWantedPlates)
        {
            System.Console.WriteLine(item);
        }


    }
}