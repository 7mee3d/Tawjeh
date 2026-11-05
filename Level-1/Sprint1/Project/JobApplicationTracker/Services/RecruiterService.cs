
using JobApplicationTracker.Data;
using JobApplicationTracker.Models;

namespace JobApplicationTracker.Services;

public class RecruiterService
{
    private readonly DataContext _context;

    public RecruiterService(DataContext context)
    {
        _context = context;
        _AddRecruiters();
    }

    private void _AddRecruiters()
    {
        _context.Recruiters.Add(new Recruiter("John Smith", "john@microsoft.com", 1));
        _context.Recruiters.Add(new Recruiter("Sarah Johnson", "sarah@google.com", 2));
        _context.Recruiters.Add(new Recruiter("Michael Brown", "michael@amazon.com", 3));
    }

    public IEnumerable<Recruiter> List()
    {
        return _context.Recruiters.GetAll();
    }

    public void Add(string name, string email, int companyId)
    {
        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || companyId <= 0)
            throw new ArgumentOutOfRangeException();

        var company = _context.Companies.GetById(companyId);

        if (company is null)
            throw new ArgumentNullException(nameof(company));

        _context.Recruiters.Add(new Recruiter(name, email, companyId));
    }

    public bool Update(int id, string name, string email, int companyId)
    {
        if (id <= 0)
            return false;

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) ||companyId <= 0)
            throw new ArgumentOutOfRangeException();

        var company = _context.Companies.GetById(companyId);

        if (company is null)
            throw new InvalidOperationException("Company not found.");

        return _context.Recruiters.Update(id, new Recruiter(name, email, companyId));
    }

    public bool Remove(int id)
    {
        if (id <= 0)
            return false;

        return _context.Recruiters.Remove(id);
    }
}
