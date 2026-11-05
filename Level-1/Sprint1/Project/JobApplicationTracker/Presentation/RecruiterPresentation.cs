
using JobApplicationTracker.Data;
using JobApplicationTracker.Enums;
using JobApplicationTracker.Models;
using JobApplicationTracker.Services;

namespace JobApplicationTracker.Presentation;

public class RecruiterPresentation
{
    private readonly RecruiterService _service;

    public RecruiterPresentation(DataContext context)
    {
        _service = new RecruiterService(context);
    }

    private void _Add()
    {
        Console.Write("Enter recruiter name: ");
        string name = Console.ReadLine()!;

        Console.Write("Enter recruiter email: ");
        string email = Console.ReadLine()!;

        Console.Write("Enter company ID: ");
        int companyId;

        while (!int.TryParse(Console.ReadLine(), out companyId))
            Console.Write("Invalid company ID, try again: ");

        _service.Add(name, email, companyId);
        Console.WriteLine("\nRecruiter Added Successfully");
    }

    private void _Update()
    {
        Console.Write("Enter recruiter ID: ");
        int id;

        while (!int.TryParse(Console.ReadLine(), out id))
            Console.Write("Invalid recruiter ID, try again: ");

        Console.Write("Enter new recruiter name: ");
        string name = Console.ReadLine()!;

        Console.Write("Enter new recruiter email: ");
        string email = Console.ReadLine()!;

        Console.Write("Enter new company ID: ");
        int companyId;

        while (!int.TryParse(Console.ReadLine(), out companyId))
            Console.Write("Invalid company ID, try again: ");

        bool isUpdated = _service.Update(id, name, email, companyId);

        if (isUpdated)
            Console.WriteLine("Recruiter updated successfully.");
        else
            Console.WriteLine($"Recruiter with ID {id} does not exist.");
    }

    private void _Remove()
    {
        Console.Write("Enter recruiter ID: ");
        int id;

        while (!int.TryParse(Console.ReadLine(), out id))
            Console.Write("Invalid recruiter ID, try again: ");

        bool isRemoved = _service.Remove(id);

        if (isRemoved)
            Console.WriteLine($"Recruiter with ID {id} removed successfully.");
        else
            Console.WriteLine($"Recruiter with ID {id} does not exist.");
    }

    private void _Print()
    {
        IEnumerable<Recruiter> recruiters = _service.List();
        bool hasRecruiters = false;

        Console.WriteLine();
        Console.WriteLine($"{"ID",-5} {"Name",-20} {"Email",-30} {"Company ID",-10}");
        Console.WriteLine("---------------------------------------------------------------------");

        foreach (var recruiter in recruiters)
        {
            hasRecruiters = true;
            Console.WriteLine($"{recruiter.Id,-5} {recruiter.Name,-20} {recruiter.Email,-30} {recruiter.CompanyId,-10}");
        }

        if (!hasRecruiters)
            Console.WriteLine("No recruiters found.");
    }

    public void Start()
    {
        while (true)
        {
            Console.Clear();
            Utility.Utility.PrintBasicSubMenu("Recruiter");

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
