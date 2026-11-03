using JobApplicationTracker.Data;
using JobApplicationTracker.Enums;
using JobApplicationTracker.Models;

namespace JobApplicationTracker.Services;

public class CompanyService
{
    private readonly DataContext _context;

    public CompanyService(DataContext context)
    {
        _context = context;
        _AddCompanies();
    }

    private void _AddCompanies()
    {
        _context.Companies.Add(new Company("Microsoft", "Software Development", "Redmond"));

        _context.Companies.Add(new Company("Google", "Technology", "Mountain View"));

        _context.Companies.Add(new Company("Amazon", "E-Commerce", "Seattle"));
    }

    private void _Print()
    {
        if (_context.Companies.GetAll().Count() == 0)
        {
            Console.WriteLine("No companies found.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine($"{"ID",-5} {"Name",-20} {"Industry",-25} {"City",-15} {"Status",-10}");
        Console.WriteLine("--------------------------------------------------------------------------");

        foreach (var company in _context.Companies.GetAll())
        {
            Console.WriteLine(
                $"{company.Id,-5} {company.Name,-20} {company.Industry,-25} {company.City,-15} {company.Status,-10}");
        }
    }

    private void _Add(string name, string industry, string city)
    {
        try
        {
            _context.Companies.Add(new Company(name, industry, city));
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
            bool isUpdated = _context.Companies.Update(id, new Company(name, industry, city, status));

            if (isUpdated)
                Console.WriteLine("Company updated successfully.");
            else
                Console.WriteLine($"Company with ID {id} does not exist.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void _Remove(int id)
    {
        try
        {
            bool isRemoved = _context.Companies.Remove(id);

            if (isRemoved)
                Console.WriteLine($"Company with ID {id} removed successfully.");
            else
                Console.WriteLine($"Company with ID {id} does not exist.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
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