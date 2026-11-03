using JobApplicationTracker.Data;
using JobApplicationTracker.Enums;
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

    private void _Print()
    {
        if (_context.Candidates.GetAll().Count() == 0)
        {
            Console.WriteLine("No candidates found.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine($"{"ID",-5} {"Full Name",-22} {"Email",-30} {"Phone",-15} {"Experience",-10}");
        Console.WriteLine("--------------------------------------------------------------------------------");

        foreach (var candidate in _context.Candidates.GetAll())
        {
            Console.WriteLine(
                $"{candidate.Id,-5} {candidate.FullName,-22} {candidate.Email,-30} {candidate.Phone,-15} {candidate.YearsOfExperience,-10}");
        }
    }

    private void _Add(string fullName, string email, string phone, int yearsOfExperience)
    {
        try
        {
            _context.Candidates.Add(new Candidate(fullName, email, phone, yearsOfExperience));

            Console.WriteLine("\nCandidate Added Successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void _Update(int id, string fullName, string email, string phone, int yearsOfExperience)
    {
        try
        {
            bool isUpdated = _context.Candidates.Update(id, new Candidate(fullName, email, phone, yearsOfExperience));

            if (isUpdated)
                Console.WriteLine("Candidate updated successfully.");
            else
                Console.WriteLine($"Candidate with ID {id} does not exist.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void _Remove(int id)
    {
        try
        {
            bool isRemoved = _context.Candidates.Remove(id);

            if (isRemoved)
                Console.WriteLine($"Candidate with ID {id} removed successfully.");
            else
                Console.WriteLine($"Candidate with ID {id} does not exist.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void StartupCandidateService()
    {
        while (true)
        {
            Console.Clear();
            Utility.Utility.PrintSubMenu("Candidate");

            byte choice = 0;

            Console.Write("Choose: ");
            while (!byte.TryParse(Console.ReadLine(), out choice))
                Console.Write("Invalid choice, try again: ");

            switch ((MainOperation)choice)
            {
                case MainOperation.Add:
                    {
                        Console.Write("Enter full name: ");
                        string fullName = Console.ReadLine()!;

                        Console.Write("Enter email: ");
                        string email = Console.ReadLine()!;

                        Console.Write("Enter phone: ");
                        string phone = Console.ReadLine()!;

                        Console.Write("Enter years of experience: ");
                        int yearsOfExperience;

                        while (!int.TryParse(Console.ReadLine(), out yearsOfExperience))
                            Console.Write("Invalid value, try again: ");

                        _Add(fullName, email, phone, yearsOfExperience);
                        break;
                    }

                case MainOperation.Update:
                    {
                        Console.Write("Enter candidate ID: ");
                        int id;

                        while (!int.TryParse(Console.ReadLine(), out id))
                            Console.Write("Invalid candidate ID, try again: ");

                        Console.Write("Enter new full name: ");
                        string fullName = Console.ReadLine()!;

                        Console.Write("Enter new email: ");
                        string email = Console.ReadLine()!;

                        Console.Write("Enter new phone: ");
                        string phone = Console.ReadLine()!;

                        Console.Write("Enter new years of experience: ");
                        int yearsOfExperience;

                        while (!int.TryParse(Console.ReadLine(), out yearsOfExperience))
                            Console.Write("Invalid value, try again: ");

                        _Update(id, fullName, email, phone, yearsOfExperience);
                        break;
                    }

                case MainOperation.List:
                    {
                        _Print();
                        break;
                    }

                case MainOperation.Remove:
                    {
                        Console.Write("Enter candidate ID: ");
                        int id;

                        while (!int.TryParse(Console.ReadLine(), out id))
                            Console.Write("Invalid candidate ID, try again: ");

                        _Remove(id);
                        break;
                    }

                case MainOperation.Back:
                    return;
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }
    }
}