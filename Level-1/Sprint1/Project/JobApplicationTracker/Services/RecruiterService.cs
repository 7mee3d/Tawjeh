using JobApplicationTracker.Models;

namespace JobApplicationTracker.Services;

public class RecruiterService
{
    private readonly List<Recruiter> _recruiters = new();

    public RecruiterService()
    {
        _AddRecruiters();
    }

    private void _AddRecruiters()
    {
        _recruiters.Add(new Recruiter(1, "John Smith", "john@microsoft.com", 1));
        _recruiters.Add(new Recruiter(2, "Sarah Johnson", "sarah@google.com", 2));
        _recruiters.Add(new Recruiter(3, "Michael Brown", "michael@amazon.com", 3));
    }

    public void PrintRecruiters()
    {
        foreach (var recruiter in _recruiters)
        {
            Console.WriteLine($"ID        : {recruiter.Id}");
            Console.WriteLine($"Name      : {recruiter.Name}");
            Console.WriteLine($"Email     : {recruiter.Email}");
            Console.WriteLine($"CompanyId : {recruiter.CompanyId}");
            Console.WriteLine(new string('-', 40));
        }
    }
}