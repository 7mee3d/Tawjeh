
using JobApplicationTracker.Data;
using JobApplicationTracker.Enums;
using JobApplicationTracker.Models;
using JobApplicationTracker.Services;

namespace JobApplicationTracker.Presentation;

public class CandidatePresentation
{
    private readonly CandidateService _service;

    public CandidatePresentation(DataContext context)
    {
        _service = new CandidateService(context);
    }

    private void _Add()
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

        _service.Add(fullName, email, phone, yearsOfExperience);
        Console.WriteLine("\nCandidate Added Successfully");
    }

    private void _Update()
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

        bool isUpdated = _service.Update(id, fullName, email, phone, yearsOfExperience);

        if (isUpdated)
            Console.WriteLine("Candidate updated successfully.");
        else
            Console.WriteLine($"Candidate with ID {id} does not exist.");
    }

    private void _Remove()
    {
        Console.Write("Enter candidate ID: ");
        int id;

        while (!int.TryParse(Console.ReadLine(), out id))
            Console.Write("Invalid candidate ID, try again: ");

        bool isRemoved = _service.Remove(id);

        if (isRemoved)
            Console.WriteLine($"Candidate with ID {id} removed successfully.");
        else
            Console.WriteLine($"Candidate with ID {id} does not exist.");
    }

    private void _Print()
    {
        IEnumerable<Candidate> candidates = _service.List();
        bool hasCandidates = false;

        foreach (var candidate in candidates)
        {
            if (!hasCandidates)
            {
                Console.WriteLine();
                Console.WriteLine($"{"ID",-5} {"Full Name",-22} {"Email",-30} {"Phone",-15} {"Experience",-10}");
                Console.WriteLine("--------------------------------------------------------------------------------");
                hasCandidates = true;
            }

            Console.WriteLine($"{candidate.Id,-5} {candidate.FullName,-22} {candidate.Email,-30} {candidate.Phone,-15} {candidate.YearsOfExperience,-10}");
        }

        if (!hasCandidates)
            Console.WriteLine("No candidates found.");
    }

    public void Start()
    {
        while (true)
        {
            Console.Clear();
            Utility.Utility.PrintBasicSubMenu("Candidate");

            byte choice = 0;

            Console.Write("Choose: ");
            while (!byte.TryParse(Console.ReadLine(), out choice))
                Console.Write("Invalid choice, try again: ");

            try
            {
                switch ((MainOperation)choice)
                {
                    case MainOperation.Add:
                        _Add();
                        break;

                    case MainOperation.Update:
                        _Update();
                        break;

                    case MainOperation.List:
                        _Print();
                        break;

                    case MainOperation.Remove:
                        _Remove();
                        break;

                    case MainOperation.Back:
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
