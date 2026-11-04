
using JobApplicationTracker.Data;
using JobApplicationTracker.Models;

namespace JobApplicationTracker.Services;

public class JobService
{
    private readonly DataContext _context;
    private Dictionary<int, Job> pairsJobs { get; } = new();

    public JobService(DataContext context)
    {
        _context = context;
        _AddJobs();
    }

    private void _AddJobs()
    {
        _context.Jobs.Add(new Job("Backend Developer", ".NET and ASP.NET Core development", 2500, "Redmond", 1, 1));
        _context.Jobs.Add(new Job("Software Engineer", "Build scalable software systems", 3000, "Redmond", 1, 1));
        _context.Jobs.Add(new Job("Frontend Developer", "React and modern JavaScript development", 2200, "Mountain View", 2, 2));
        _context.Jobs.Add(new Job("Data Engineer", "Design and maintain data pipelines", 3500, "Mountain View", 2, 2));
        _context.Jobs.Add(new Job("Cloud Engineer", "AWS infrastructure and cloud solutions", 3200, "Seattle", 3, 3));
        _context.Jobs.Add(new Job("DevOps Engineer", "CI/CD and infrastructure automation", 3000, "Seattle", 3, 3));

        foreach (var item in _context.Jobs.GetAll())
            pairsJobs.Add(item.Id, item);
    }

    public IEnumerable<Job> List()
    {
        return _context.Jobs.GetAll();
    }

    public Job? GetById(int id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id));

        if (pairsJobs.TryGetValue(id, out Job? job))
            return job;

        return null;
    }

    public void Add(string title, string description, decimal salary, string location, int companyId, int recruiterId)
    {
        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description) || salary <= 0 || string.IsNullOrWhiteSpace(location) || companyId <= 0 || recruiterId <= 0)
            throw new ArgumentOutOfRangeException();

        var company = _context.Companies.GetById(companyId);

        if (company is null)
            throw new ArgumentNullException(nameof(company));

        var recruiter = _context.Recruiters.GetById(recruiterId);

        if (recruiter is null)
            throw new ArgumentNullException(nameof(recruiter));

        var job = new Job(title, description, salary, location, companyId, recruiterId);

        _context.Jobs.Add(job);
        pairsJobs.Add(job.Id, job);
    }

    public bool Update(int id, string title, string description, decimal salary, string location, int companyId, int recruiterId)
    {
        if (id <= 0)
            return false;

        var company = _context.Companies.GetById(companyId);

        if (company is null)
            throw new ArgumentNullException(nameof(company));

        var recruiter = _context.Recruiters.GetById(recruiterId);

        if (recruiter is null)
            throw new ArgumentNullException(nameof(recruiter));
            
        var job = new Job(title, description, salary, location, companyId, recruiterId);

        bool isUpdated = _context.Jobs.Update(id, job);

        if (!isUpdated)
            return false;

        pairsJobs[id] = job;

        return true;

    }

    public bool Remove(int id)
    {

        if (id <= 0)
            return false;

        bool isRemove = _context.Jobs.Remove(id);

        if (!isRemove)
            return false;

        pairsJobs.Remove(id);

        return true;

    }
}
