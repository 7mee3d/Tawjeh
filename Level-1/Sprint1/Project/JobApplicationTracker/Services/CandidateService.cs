using JobApplicationTracker.Models;

namespace JobApplicationTracker.Services;

public class CandidateService
{
    private List<Candidate> _candidates = new();

    public CandidateService()
    {
        _AddCandidates();
    }

    private void _AddCandidates()
    {
        _candidates.Add(new Candidate(1, "Ahmed Hassan", "ahmed@gmail.com", "01012345678", 2));
        _candidates.Add(new Candidate(2, "Omar Ali", "omar@gmail.com", "01023456789", 3));
        _candidates.Add(new Candidate(3, "Mohamed Adel", "mohamed@gmail.com", "01034567890", 1));
        _candidates.Add(new Candidate(4, "Sara Mohamed", "sara@gmail.com", "01045678901", 4));
        _candidates.Add(new Candidate(5, "Youssef Khaled", "youssef@gmail.com", "01056789012", 0));
    }

    public void PrintCandidates()
    {
        foreach (var candidate in _candidates)
        {
            Console.WriteLine($"ID                 : {candidate.Id}");
            Console.WriteLine($"FullName           : {candidate.FullName}");
            Console.WriteLine($"Email              : {candidate.Email}");
            Console.WriteLine($"Phone              : {candidate.Phone}");
            Console.WriteLine($"YearsOfExperience  : {candidate.YearsOfExperience}");
            Console.WriteLine(new string('-', 40));
        }
    }
}