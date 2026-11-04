
using JobApplicationTracker.Data;
using JobApplicationTracker.Models;

namespace JobApplicationTracker.Services;

public class CandidateService
{
    private readonly DataContext _context;

    public CandidateService(DataContext context)
    {
        _context = context;
        _AddCandidates();
    }

    private void _AddCandidates()
    {
        _context.Candidates.Add(new Candidate("Ahmed Hassan", "ahmed@gmail.com", "01012345678", 2));
        _context.Candidates.Add(new Candidate("Omar Ali", "omar@gmail.com", "01023456789", 3));
        _context.Candidates.Add(new Candidate("Mohamed Adel", "mohamed@gmail.com", "01034567890", 1));
        _context.Candidates.Add(new Candidate("Sara Mohamed", "sara@gmail.com", "01045678901", 4));
        _context.Candidates.Add(new Candidate("Youssef Khaled", "youssef@gmail.com", "01056789012", 0));
    }

    public IEnumerable<Candidate> List()
    {
        return _context.Candidates.GetAll();
    }

    public void Add(string fullName, string email, string phone, int yearsOfExperience)
    {
        if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phone) || yearsOfExperience < 0)
            throw new ArgumentOutOfRangeException();

        _context.Candidates.Add(new Candidate(fullName, email, phone, yearsOfExperience));
    }

    public bool Update(int id, string fullName, string email, string phone, int yearsOfExperience)
    {
        if (id <= 0)
            return false;

        return _context.Candidates.Update(id, new Candidate(fullName, email, phone, yearsOfExperience));
    }

    public bool Remove(int id)
    {
        if (id <= 0)
            return false;

        return _context.Candidates.Remove(id);
    }
}
