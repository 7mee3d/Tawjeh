using JobApplicationTracker.Models;

namespace JobApplicationTracker.Services;

public class ApplicationService
{
    private List<Application> _applications = new();

    public ApplicationService()
    {
        _AddApplications();
    }

    private void _AddApplications()
    {
        _applications.Add(new Application(1, 1, 1));
        _applications.Add(new Application(2, 2, 2));
        _applications.Add(new Application(3, 3, 3));
        _applications.Add(new Application(4, 4, 4));
        _applications.Add(new Application(5, 5, 5));
    }
    public void PrintApplications()
    {
        foreach (var application in _applications)
        {
            Console.WriteLine($"ID          : {application.Id}");
            Console.WriteLine($"JobId       : {application.JobId}");
            Console.WriteLine($"CandidateId : {application.CandidateId}");
            Console.WriteLine($"AppliedDate : {application.AppliedDate}");
            Console.WriteLine($"Status      : {application.Status}");
            Console.WriteLine(new string('-', 40));
        }
    }

}