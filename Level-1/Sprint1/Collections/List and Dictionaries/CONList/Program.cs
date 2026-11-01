using System.Runtime.InteropServices;

public class Program
{
    private static void Main(string[] args)
    {
        var egypt = new Country { Name = "Egypt", ISOCode = "EGY" };
        var jordan = new Country { Name = "Jordan", ISOCode = "JOR" };
        var iraq = new Country { Name = "Iraq", ISOCode = "IRQ" };

        // Create array o country to be store this country objects 

        Country[] countries =
        {
            egypt ,
            jordan ,
            iraq
        };


        //Countractor List 

        //THe list in the name space -> System.Collections.Genaric 

        List<Country> listCountries = new List<Country>();



        Print(listCountries);

        // Methods 

        //1- Add New Country in the list 
        // the add method require the object of country 
        listCountries.Add(new Country { Name = "Brazel", ISOCode = "BRA" }); // O(1) 

        Print(listCountries);
        //2- Add Range 
        //Add range send the array of country 

        listCountries.AddRange(countries);// O(1) 
        listCountries.Insert(1, new Country { Name = "Palestine", ISOCode = "PAL" });

        Print(listCountries);

    }

    private static void Print(List<Country> countries)
    {
        foreach (var c in countries)
            System.Console.WriteLine(c);

        //Properites 
        System.Console.WriteLine($"Count : {countries.Count}");
        System.Console.WriteLine($"Capcity : {countries.Capacity}");
    }

    public class Country
    {

        public string Name { get; set; }
        public string ISOCode { get; set; } // Egypt (EGY)

        public override string ToString()
        {
            return $"Name : {Name} - ISO Code : ({ISOCode})";
        }
    }
}