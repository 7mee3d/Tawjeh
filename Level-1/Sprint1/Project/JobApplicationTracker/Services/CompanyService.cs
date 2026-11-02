using JobApplicationTracker.Enums;
using JobApplicationTracker.Models;

namespace JobApplicationTracker.Services;

public class CompanyService
{
    private readonly List<Company> _companies = new();

    public CompanyService()
    {
        _AddCompanies();
    }

    private void _AddCompanies()
    {
        _companies.Add(new Company(1, "Microsoft", "Software Development", "Redmond"));

        _companies.Add(new Company(2, "Google", "Technology", "Mountain View"));

        _companies.Add(new Company(3, "Amazon", "E-Commerce", "Seattle"));
    }

    private void _PrintCompanies()
    {
        if (_companies.Count <= 0)
        {
            System.Console.WriteLine("No Data");
            return;
        }

        foreach (var company in _companies)
        {
            Console.WriteLine($"ID       : {company.Id}");
            Console.WriteLine($"Name     : {company.Name}");
            Console.WriteLine($"Industry : {company.Industry}");
            Console.WriteLine($"City     : {company.City}");
            Console.WriteLine($"Status   : {company.Status}");
            Console.WriteLine(new string('-', 40));
        }
    }

    private void _AddCompany(string name, string industry, string city)
    {
        try
        {
            var comp = _companies[^1];

            int lastId = comp.Id;

            if (lastId <= 0)
            {
                System.Console.WriteLine("Invalid id ");
                return;
            }

            int nextId = lastId + 1;

            var newComp = new Company(nextId, name, industry, city);

            _companies.Add(newComp);
            System.Console.WriteLine($"\n\nCompany Added Successfully");


        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }

    private void _UpdateCompany(int id, string name, string industry, string city)
    {
        try
        {

            foreach (var comp in _companies)
            {
                if (comp.Id == id)
                {
                    comp.SetName(name);
                    comp.SetCity(city);
                    comp.SetIndustry(industry);
                    System.Console.WriteLine($"\n\nCompany id {id} Updated Successfully");

                    return;

                }
            }

            System.Console.WriteLine("Company does not exists");

        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }

    private void _Remove(int id)
    {
        try
        {

            int index = _companies.FindIndex(x => x.Id == id);
            if (index == -1)
            {
                System.Console.WriteLine("Company does not exists");
                return;
            }

            _companies.RemoveAt(index);
            System.Console.WriteLine($"\n\nCompany id {id} Removed Successfully");

        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }

    public void StartupCompanyService()
    {
        while (true)
        {
            Console.Clear();
            Utility.Utility.PrintSubMenu("Company");

            byte choice = 0;
            Console.Write("Choose: ");
            while (!byte.TryParse(Console.ReadLine(), out choice))
                System.Console.WriteLine("Invlid , enter agian : ");

            switch ((MainOperation)choice)
            {
                case MainOperation.Add:
                    {
                        System.Console.WriteLine("\n");
                        string name = string.Empty;
                        System.Console.WriteLine("Enter name company : ");
                        name = Console.ReadLine()!;

                        string industry = string.Empty;
                        System.Console.WriteLine("Enter industry company : ");
                        industry = Console.ReadLine()!;

                        string city = string.Empty;
                        System.Console.WriteLine("Enter city company : ");
                        city = Console.ReadLine()!;

                        _AddCompany(name, industry, city);
                        break;
                    }

                case MainOperation.Update:
                    {
                        int id = 0;
                        System.Console.WriteLine("Enter company id : ");
                        while (!int.TryParse(Console.ReadLine(), out id))
                            System.Console.WriteLine("Invalid company id , try again : ");

                        System.Console.WriteLine("\n");
                        string name = string.Empty;
                        System.Console.WriteLine("Enter name company : ");
                        name = Console.ReadLine()!;

                        string industry = string.Empty;
                        System.Console.WriteLine("Enter industry company : ");
                        industry = Console.ReadLine()!;

                        string city = string.Empty;
                        System.Console.WriteLine("Enter city company : ");
                        city = Console.ReadLine()!;

                        _UpdateCompany(id, name, industry, city);
                        break;
                    }

                case MainOperation.List:
                    {
                        _PrintCompanies();
                        break;
                    }

                case MainOperation.Remove:
                    {
                        int id = 0;
                        System.Console.WriteLine("Enter company id : ");
                        while (!int.TryParse(Console.ReadLine(), out id))
                            System.Console.WriteLine("Invalid company id , try again : ");

                        _Remove(id);

                        break;
                    }

                case MainOperation.Back:
                    {
                        return;
                    }

            }

            System.Console.WriteLine("Enter any key to back main menu ");
            Console.ReadKey();

        }
    }
}