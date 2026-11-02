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
        _companies.Add(new Company(1, "Microsoft", "Software Development","Redmond" ));

        _companies.Add(new Company(2, "Google", "Technology","Mountain View"));

        _companies.Add(new Company(3, "Amazon", "E-Commerce","Seattle"));
    }

    public void PrintCompanies()
    {
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
}