
using JobApplicationTracker.Data;
using JobApplicationTracker.Enums;
using JobApplicationTracker.Models;

namespace JobApplicationTracker.Services;

public class ApplicationService
{
    private readonly DataContext _context;
    private readonly HashSet<(int JobId, int CandidateId)> _uniqueJobs = new();

    public ApplicationService(DataContext context)
    {
        _context = context;
        _AddApplications();
    }

    private void _AddApplications()
    {
        _context.Applications.Add(new Application(1, 1));
        _context.Applications.Add(new Application(2, 2));
        _context.Applications.Add(new Application(3, 3));
        _context.Applications.Add(new Application(4, 4));
        _context.Applications.Add(new Application(5, 5));

        foreach (var item in _context.Applications.GetAll())
            _uniqueJobs.Add((item.JobId, item.CandidateId));
    }

    public IEnumerable<Application> List()
    {
        return _context.Applications.GetAll();
    }

    public Application? GetById(int id)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id));

        return _context.Applications.GetById(id);
    }

    public void Add(int jobId, int candidateId)
    {
        var job = _context.Jobs.GetById(jobId);

        if (job is null)
            throw new ArgumentNullException(nameof(job));

        var candidate = _context.Candidates.GetById(candidateId);

        if (candidate is null)
            throw new ArgumentNullException(nameof(candidate));

        if (_uniqueJobs.Contains((jobId, candidateId)))
            throw new InvalidOperationException("This candidate has already applied to this job.");

        if (!job.IsOpen)
            throw new InvalidOperationException("This job is closed.");

        var company = _context.Companies.GetById(job.CompanyId);

        if (company is null || company.Status != CompanyStatus.Approved)
            throw new InvalidOperationException("The company is not approved.");

        _context.Applications.Add(new Application(jobId, candidateId));
        _uniqueJobs.Add((jobId, candidateId));
    }

    public bool Update(int id, int jobId, int candidateId, ApplicationStatus status)
    {
        if (id <= 0)
            return false;
        var app = GetById(id);

        if (app is null)
            return false;

        var job = _context.Jobs.GetById(jobId);

        if (job is null)
            throw new ArgumentNullException(nameof(job));

        var candidate = _context.Candidates.GetById(candidateId);

        if (candidate is null)
            throw new ArgumentNullException(nameof(candidate));


        var oldKey = (app.JobId, app.CandidateId);
        var newKey = (jobId, candidateId);

        if (oldKey != newKey && _uniqueJobs.Contains(newKey))
            throw new InvalidOperationException("This candidate has already applied to this job.");

        bool isUpdated = _context.Applications.Update(id, new Application(jobId, candidateId, status));

        if (!isUpdated)
            return false;

        if (oldKey != newKey)
        {
            _uniqueJobs.Remove(oldKey);
            _uniqueJobs.Add(newKey);
        }

        return true;
    }

    public bool Remove(int id)
    {
        if (id <= 0)
            return false;

        var app = GetById(id);
        if (app is null)
            return false;

        bool isRemoved = _context.Applications.Remove(id);

        if (!isRemoved)
            return false;

        _uniqueJobs.Remove((app.JobId, app.CandidateId));

        return true;

    }
}
