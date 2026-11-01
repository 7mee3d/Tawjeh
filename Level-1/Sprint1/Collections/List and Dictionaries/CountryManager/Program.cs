
public class Program
{
    private static void PrintMenu()
    {
        Console.WriteLine("\t\t========== COUNTRY MANAGER ==========");
        Console.WriteLine("\t\t1. Show All Countries");
        Console.WriteLine("\t\t2. Add Country");
        Console.WriteLine("\t\t3. Insert Country");
        Console.WriteLine("\t\t4. Remove Country by Code");
        Console.WriteLine("\t\t5. Search Country by Name");
        Console.WriteLine("\t\t6. Remove Countries by Condition");
        Console.WriteLine("\t\t7. Show Count and Capacity");
        Console.WriteLine("\t\t8. Convert to Dictionary");
        Console.WriteLine("\t\t0. Exit");
        Console.Write("\t\tChoose an option: ");
    }

    private static void Main(string[] args)
    {

        CountryServices services = new CountryServices();

        while (true)
        {
            Console.Clear();

            PrintMenu();
            byte choice = 0;
            while (!byte.TryParse(Console.ReadLine(), out choice))
                System.Console.WriteLine("\t\tInvalid Choice !! : ");
            switch (choice)
            {
                case 1:
                    services.ShowAllCountries();
                    break;

                case 2:
                    {
                        Console.Write("Enter Country Code: ");
                        string code = Console.ReadLine()!;

                        Console.Write("Enter Country Name: ");
                        string name = Console.ReadLine()!;

                        Console.Write("Enter Country Population: ");
                        string population = Console.ReadLine()!;

                        Country country = new Country(code, name, population);

                        services.AddNewCountry(country);
                        break;
                    }

                case 3:
                    {
                        Console.Write("Enter Country Code: ");
                        string code = Console.ReadLine()!;

                        Console.Write("Enter Country Name: ");
                        string name = Console.ReadLine()!;

                        Console.Write("Enter Country Population: ");
                        string population = Console.ReadLine()!;

                        Console.Write("Enter Index: ");
                        int index = int.Parse(Console.ReadLine()!);

                        Country country = new Country(code, name, population);

                        services.InsertCountry(country, index);
                        break;
                    }

                case 4:
                    {
                        Console.Write("Enter Country Code to Remove: ");
                        string code = Console.ReadLine()!;

                        services.RemoveCountryByCode(code);
                        break;
                    }

                case 5:
                    {
                        Console.Write("Enter Country Name to Search: ");
                        string name = Console.ReadLine()!;

                        services.SearchCountryByName(name);
                        break;
                    }

                case 6:
                    {
                        Console.Write("Enter ending text to remove countries: ");
                        string ending = Console.ReadLine()!;

                        break;
                    }

                case 7:
                    services.SHowCountAndCapcity();
                    break;

                case 8:

                    break;

                case 0:
                    Console.WriteLine("Exiting Country Manager...");
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

            System.Console.WriteLine("\t\t ENter Any Key");
            Console.ReadKey();
        }
    }
}