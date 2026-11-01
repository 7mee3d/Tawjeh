
using System.Xml.Schema;

public class CountryServices
{
    private List<Country> _countries = new();

    public void ShowAllCountries()
    {
        if (!_countries.Any())
        {
            System.Console.WriteLine($"\t\t--Empty--");
            return;
        }

        System.Console.WriteLine($"\t\t{"Code",-10} {"Name",-20} {"Population",-10}");
        System.Console.WriteLine($"\t\t{new string('-', 40)}");

        foreach (var con in _countries)
            System.Console.WriteLine($"\t\t{con.Code,-10} {con.Name,-20} {con.Population,-10}");

        System.Console.WriteLine($"\t\t{new string('-', 40)}");

    }

    public void AddNewCountry(Country country)
    {

        if (country is null)
        {
            System.Console.WriteLine($"\t\tthe object is null");
            return;
        }

        if (string.IsNullOrWhiteSpace(country.Code) || string.IsNullOrWhiteSpace(country.Name) || string.IsNullOrWhiteSpace(country.Population))
        {
            System.Console.WriteLine($"\t\tcountry code or name or population is empty");
            return;
        }

        _countries.Add(country);
        System.Console.WriteLine($"\t\tThe country addedd successflly");

    }

    public void InsertCountry(Country country, int index)
    {
        if (index < 0)
        {
            System.Console.WriteLine("\t\tinvalid data index");
            return;
        }
        if (country is null)
        {
            System.Console.WriteLine($"\t\tthe object is null");
            return;
        }

        if (string.IsNullOrWhiteSpace(country.Code) || string.IsNullOrWhiteSpace(country.Name) || string.IsNullOrWhiteSpace(country.Population))
        {
            System.Console.WriteLine($"\t\tcountry code or name or population is empty");
            return;
        }

        _countries.Insert(index, country);

        System.Console.WriteLine($"\t\tThe country Inserted successflly at {index + 1}");

    }


    public void RemoveCountryByCode(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
        {
            System.Console.WriteLine("\t\tInvalid data code");
            return;
        }
        var countryByCode = _countries.Where(x => x.Code == code);

        if (countryByCode is null)
        {
            System.Console.WriteLine("\t\tThe country is not exists");
            return;
        }

        _countries.RemoveAll(x => x.Code == code);
        System.Console.WriteLine("\t\tThe country removed successfully");

    }

    public void SearchCountryByName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            System.Console.WriteLine("\t\tInvalid data name");
            return;
        }

        System.Console.WriteLine($"\t\t{"Code",-10} {"Name",-20} {"Population",-10}");
        System.Console.WriteLine($"\t\t{new string('-', 40)}");

        foreach (var con in _countries)
        {
            if (con.Name.Contains(name))
                System.Console.WriteLine($"\t\t{con.Code,-10} {con.Name,-20} {con.Population,-10}");

        }
        System.Console.WriteLine($"\t\t{new string('-', 40)}");

    }
    public void SHowCountAndCapcity()
    {
        System.Console.WriteLine($"\t\tCount : {_countries.Count}");
        System.Console.WriteLine($"\t\tCapcity : {_countries.Capacity}");
    }

    
}