using JobApplicationTracker.Data;
using JobApplicationTracker.Enums;
using JobApplicationTracker.Models;
using JobApplicationTracker.Services;

namespace JobApplicationTracker.Presentation;


public class CompanyPresentation
{
    private readonly DataContext _context = new();

    private readonly CompanyService _service;

    public static void PrintSubMenu()
    {
        Console.WriteLine($"\n========== {"Company"} ==========");
        Console.WriteLine();
        Console.WriteLine("  1. Add");
        Console.WriteLine("  2. Update");
        Console.WriteLine("  3. List");
        Console.WriteLine("  4. Remove");
        Console.WriteLine("  5. Get");
        Console.WriteLine("  6. Change Status");
        Console.WriteLine("  0. Back");
        Console.WriteLine($"\n=============================");
    }

    public CompanyPresentation(DataContext context)
    {
        _context = context;
        _service = new CompanyService(_context);
    }

    private int _ReadId()
    {
        int id = 0;
        System.Console.WriteLine("Enter company id : ");
        while (!int.TryParse(Console.ReadLine(), out id))
            System.Console.WriteLine("Invalid company id , try again : ");

        return id;
    }

    private void _Add()
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

        _service.Add(name, industry, city);
        Console.WriteLine("Company added successfully.");
    }

    private void _Update()
    {
        int id = _ReadId();

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

        bool isUpdated = _service.Update(id, name, industry, city, companyStatus);

        Console.WriteLine(isUpdated ? "Company updated successfully." : "Company not found.");
    }

    private void _PrintCompanies(IEnumerable<Company> companies)
    {
        bool hasCompanies = false;

        Console.WriteLine();
        Console.WriteLine($"{"ID",-5} {"Name",-20} {"Industry",-25} {"City",-15} {"Status",-10}");
        Console.WriteLine("--------------------------------------------------------------------------");

        foreach (Company company in companies)
        {
            hasCompanies = true;
            Console.WriteLine($"{company.Id,-5} {company.Name,-20} " + $"{company.Industry,-25} {company.City,-15} {company.Status,-10}");
        }

        if (!hasCompanies)
            Console.WriteLine("No companies found.");

    }

    private void _Remove()
    {
        int id = _ReadId();

        bool isRemove = _service.Remove(id);
        Console.WriteLine(isRemove ? "Company removed successfully." : "Company not found.");
    }

    private void _GetCompany()
    {
        int id = _ReadId();

        Company? company = _service.GetById(id);

        if (company is null)
        {
            Console.WriteLine("Company not found.");
            return;
        }

        _PrintCompanies([company]);
    }

    private void _ChangeCompanyStatus()
    {
        try
        {
            int id = _ReadId();

            foreach (CompanyStatus status in Enum.GetValues<CompanyStatus>())
                Console.WriteLine($"{(byte)status} - {status}");

            byte statusValue;

            while (!byte.TryParse(Console.ReadLine(), out statusValue) ||
             !Enum.IsDefined(typeof(CompanyStatus), statusValue))
            {
                Console.Write("Invalid status, try again: ");
            }

            CompanyStatus companyStatus = (CompanyStatus)statusValue;

            _service.ChangeCompanyStatus(id, companyStatus);

            Console.WriteLine("Company status changed successfully.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }

    private void _ListByStatus()
    {
        foreach (CompanyStatus status in Enum.GetValues<CompanyStatus>())
            Console.WriteLine($"{(byte)status} - {status}");

        byte statusValue;

        while (!byte.TryParse(Console.ReadLine(), out statusValue) || !Enum.IsDefined(typeof(CompanyStatus), statusValue))
        {
            Console.Write("Invalid status, try again: ");
        }

        CompanyStatus companyStatus = (CompanyStatus)statusValue;

        var companiesAfterFilterByStatus = _service.ListByStatus(companyStatus);

        _PrintCompanies(companiesAfterFilterByStatus);
    }

    private void _UndoStatus()
    {

        bool isRestored = _service.UndoLastStatusChange();

        Console.WriteLine(isRestored ? "Company status restored successfully." : "Nothing to undo.");

    }

    public void Start()
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
                        _Add();
                        break;
                    }

                case MainOperation.Update:
                    {
                        _Update();
                        break;
                    }

                case MainOperation.List:
                    {
                        _PrintCompanies(_service.List());
                        break;
                    }

                case MainOperation.Remove:
                    {
                        _Remove();
                        break;
                    }

                case MainOperation.Get:
                    {
                        _GetCompany();
                        break;

                    }
                case MainOperation.ChangeStatus:
                    {
                        _ChangeCompanyStatus();
                        break;
                    }
                case MainOperation.ListByStatus:
                    {
                        _ListByStatus();
                        break;
                    }
                case MainOperation.UndoStatus:
                    {
                        _UndoStatus();
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