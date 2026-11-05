
using JobApplicationTracker.Data;
using JobApplicationTracker.Models;

namespace JobApplicationTracker.Services;

public class CandidateService
{
    private readonly DataContext _context;
    private readonly HashSet<string> _uniqueEmails = new(StringComparer.OrdinalIgnoreCase);

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

        foreach (var candidate in _context.Candidates.GetAll())
            _uniqueEmails.Add(candidate.Email);
    }

    public IEnumerable<Candidate> List()
    {
        return _context.Candidates.GetAll();
    }

    public void Add(string fullName, string email, string phone, int yearsOfExperience)
    {
        if (string.IsNullOrWhiteSpace(fullName) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(phone) ||
            yearsOfExperience < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        var candidate = new Candidate(fullName, email, phone, yearsOfExperience);

        if (_uniqueEmails.Contains(candidate.Email))
            throw new InvalidOperationException("This email is already registered.");

        _context.Candidates.Add(candidate);
        _uniqueEmails.Add(candidate.Email);
    }

    public bool Update(int id, string fullName, string email, string phone, int yearsOfExperience)
    {
        if (id <= 0)
            return false;

        var existingCandidate = _context.Candidates.GetById(id);

        if (existingCandidate is null)
            return false;

        if (string.IsNullOrWhiteSpace(fullName) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(phone) ||
            yearsOfExperience < 0)
        {
            throw new ArgumentOutOfRangeException();
        }

        var candidate = new Candidate(fullName, email, phone, yearsOfExperience);

        if (!string.Equals(existingCandidate.Email,candidate.Email, StringComparison.OrdinalIgnoreCase) && _uniqueEmails.Contains(candidate.Email))
            throw new InvalidOperationException("This email is already registered.");
            
        bool isUpdated = _context.Candidates.Update(id, candidate);

        if (!isUpdated)
            return false;

        _uniqueEmails.Remove(existingCandidate.Email);
        _uniqueEmails.Add(candidate.Email);

        return true;
    }

    public bool Remove(int id)
    {
        if (id <= 0)
            return false;

        var candidate = _context.Candidates.GetById(id);

        if (candidate is null)
            return false;

        bool isRemoved = _context.Candidates.Remove(id);

        if (!isRemoved)
            return false;

        _uniqueEmails.Remove(candidate.Email);

        return true;
    }
}
