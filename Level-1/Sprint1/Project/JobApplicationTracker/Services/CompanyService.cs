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

    public IEnumerable<Company> List()
    {
        return _context.Companies.GetAll();
    }

    public void Add(string name, string industry, string city)
    {
        if (
            string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(industry) ||
            string.IsNullOrWhiteSpace(city)
            )
            throw new ArgumentOutOfRangeException();

        _context.Companies.Add(new Company(name, industry, city));
    }

    public bool Update(int id, string name, string industry, string city, CompanyStatus status)
    {
        if (id <= 0)
            return false;

        return _context.Companies.Update(id, new Company(name, industry, city));
    }

    public bool Remove(int id)
    {
        var comp = GetById(id);
        if (comp is null)
            return false;

        return _context.Companies.Remove(id);
    }

    public Company? GetById(int companyId)
    {
        if (companyId <= 0)
            throw new ArgumentOutOfRangeException(nameof(companyId));

        return _context.Companies.GetById(companyId);
    }

    public void ChangeCompanyStatus(int companyId, CompanyStatus status)
    {
        if (companyId <= 0)
            throw new ArgumentOutOfRangeException(nameof(companyId));

        var comp = _context.Companies.GetById(companyId);

        if (comp is null)
            throw new ArgumentNullException(nameof(comp));

        comp.ChangeStatusCompany(status);
    }

    public List<Company> ListByStatus(CompanyStatus status)
    {
        if (!Enum.IsDefined(status))
            throw new InvalidOperationException(nameof(status));

        List<Company> companies = new();

        foreach (var item in _context.Companies.GetAll())
            if (item.Status == status)
                companies.Add(item);

        return companies;
    }
}