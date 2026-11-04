
using JobApplicationTracker.Data;
using JobApplicationTracker.Enums;
using JobApplicationTracker.Models;

namespace JobApplicationTracker.Services;

public class ApplicationService
{
    private readonly DataContext _context;

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

        _context.Applications.Add(new Application(jobId, candidateId));
    }

    public bool Update(int id, int jobId, int candidateId, ApplicationStatus status)
    {
        if (id <= 0)
            return false;

        return _context.Applications.Update(id, new Application(jobId, candidateId));
    }

    public bool Remove(int id)
    {
        if (id <= 0)
            return false;

        return _context.Applications.Remove(id);
    }
}
