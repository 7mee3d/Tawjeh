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

    private void _Print()
    {
        if (_companies.Count == 0)
        {
            Console.WriteLine("No companies found.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine($"{"ID",-5} {"Name",-20} {"Industry",-25} {"City",-15} {"Status",-10}");
        Console.WriteLine("--------------------------------------------------------------------------");

        foreach (var company in _companies)
        {
            Console.WriteLine(
                $"{company.Id,-5} {company.Name,-20} {company.Industry,-25} {company.City,-15} {company.Status,-10}");
        }
    }
    
    private void _Add(string name, string industry, string city)
    {
        try
        {

            int lastId = _companies.Count == 0 ? 0 : _companies[^1].Id;

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

    private void _Update(int id, string name, string industry, string city, CompanyStatus status)
    {
        try
        {

            foreach (var comp in _companies)
            {
                if (comp.Id == id)
                {

                    comp.ChangeStatusCompany(status);
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

                        _Add(name, industry, city);
                        break;
                    }

                case MainOperation.Update:
                    {
                        int id = 0;
                        Console.Write("Enter company id: ");

                        while (!int.TryParse(Console.ReadLine(), out id))
                            Console.Write("Invalid company id, try again: ");

                        Console.Write("Enter new company name: ");
                        string name = Console.ReadLine()!;

                        Console.Write("Enter new company industry: ");
                        string industry = Console.ReadLine()!;

                        Console.Write("Enter new company city: ");
                        string city = Console.ReadLine()!;

                        Console.WriteLine("\nSelect Company Status:");

                        foreach (CompanyStatus status in Enum.GetValues<CompanyStatus>())
                            Console.WriteLine($"{(byte)status} - {status}");

                        byte statusValue;

                        while (!byte.TryParse(Console.ReadLine(), out statusValue) || !Enum.IsDefined(typeof(CompanyStatus), statusValue))
                        {
                            Console.Write("Invalid status, try again: ");
                        }

                        CompanyStatus companyStatus = (CompanyStatus)statusValue;

                        _Update(id, name, industry, city, companyStatus);
                        break;
                    }

                case MainOperation.List:
                    {
                        _Print();
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