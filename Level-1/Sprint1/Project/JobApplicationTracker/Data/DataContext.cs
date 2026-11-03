
using JobApplicationTracker.Models;

namespace JobApplicationTracker.Data;

public class DataContext
{
    public GenericDataStore<Application> Applications { get; } = new();
    public GenericDataStore<Candidate> Candidates { get; } = new();
    public GenericDataStore<Company> Companies { get; } = new();
    public GenericDataStore<Job> Jobs { get; } = new();
    public GenericDataStore<Recruiter> Recruiters { get; } = new();
}
