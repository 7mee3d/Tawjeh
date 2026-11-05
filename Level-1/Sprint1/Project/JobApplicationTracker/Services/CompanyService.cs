using JobApplicationTracker.Data;
using JobApplicationTracker.Enums;
using JobApplicationTracker.Models;

namespace JobApplicationTracker.Services;

public class CompanyService
{
    private readonly DataContext _context;
    private readonly Stack<(int companyId, CompanyStatus status)> _statusCompanies = new();

    public CompanyService(DataContext context)
    {
        _context = context;
        _AddCompanies();
    }

    private void _AddCompanies()
    {
        _context.Companies.Add(new Company("Microsoft", "Software Development", "Redmond", CompanyStatus.Approved));
        _context.Companies.Add(new Company("Google", "Technology", "Mountain View", CompanyStatus.Approved));
        _context.Companies.Add(new Company("Amazon", "E-Commerce", "Seattle", CompanyStatus.Pending));

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

        var company = GetById(id);

        if (company is null)
            return false;

        company.SetName(name);
        company.SetIndustry(industry);
        company.SetCity(city);

        if (company.Status != status)
            ChangeCompanyStatus(id, status);

        return true;
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
            throw new ArgumentException("Invalid company ID.");

        Company? company = _context.Companies.GetById(companyId);

        if (company is null)
            throw new InvalidOperationException("Company not found.");

        CompanyStatus previousStatus = company.Status;

        company.ChangeStatusCompany(status);

        _statusCompanies.Push((companyId, previousStatus));
    }

    public bool UndoLastStatusChange()
    {
        if (!_statusCompanies.TryPeek(out var previous))
            return false;

        Company? company = GetById(previous.companyId);

        if (company is null)
            throw new InvalidOperationException("Company not found.");

        company.RestoreStatus(previous.status);

        _statusCompanies.Pop();

        return true;
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