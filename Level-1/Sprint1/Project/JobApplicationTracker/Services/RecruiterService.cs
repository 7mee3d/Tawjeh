using JobApplicationTracker.Data;
using JobApplicationTracker.Enums;
using JobApplicationTracker.Models;

namespace JobApplicationTracker.Services;

public class RecruiterService
{
    private readonly DataContext _context;

    public RecruiterService(DataContext context)
    {
        _context = context;
        _AddRecruiters();
    }

    private void _AddRecruiters()
    {
        _context.Recruiters.Add(new Recruiter("John Smith", "john@microsoft.com", 1));
        _context.Recruiters.Add(new Recruiter("Sarah Johnson", "sarah@google.com", 2));
        _context.Recruiters.Add(new Recruiter("Michael Brown", "michael@amazon.com", 3));
    }

    private void _Print()
    {
        if (_context.Recruiters.GetAll().Count() == 0)
        {
            Console.WriteLine("No recruiters found.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine($"{"ID",-5} {"Name",-20} {"Email",-30} {"Company ID",-10}");
        Console.WriteLine("---------------------------------------------------------------------");

        foreach (var recruiter in _context.Recruiters.GetAll())
        {
            Console.WriteLine(
                $"{recruiter.Id,-5} {recruiter.Name,-20} {recruiter.Email,-30} {recruiter.CompanyId,-10}");
        }
    }

    private void _Add(string name, string email, int companyId)
    {
        try
        {
            _context.Recruiters.Add(new Recruiter(name, email, companyId));
            Console.WriteLine("\nRecruiter Added Successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void _Update(int id, string name, string email, int companyId)
    {
        try
        {
            bool isUpdated = _context.Recruiters.Update(id, new Recruiter(name, email, companyId));

            if (isUpdated)
                Console.WriteLine("Recruiter updated successfully.");
            else
                Console.WriteLine($"Recruiter with ID {id} does not exist.");
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
            bool isRemoved = _context.Recruiters.Remove(id);

            if (isRemoved)
                Console.WriteLine($"Recruiter with ID {id} removed successfully.");
            else
                Console.WriteLine($"Recruiter with ID {id} does not exist.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void StartupRecruiterService()
    {
        while (true)
        {
            Console.Clear();
            Utility.Utility.PrintSubMenu("Recruiter");

            byte choice = 0;

            Console.Write("Choose: ");
            while (!byte.TryParse(Console.ReadLine(), out choice))
                Console.Write("Invalid choice, try again: ");

            switch ((MainOperation)choice)
            {
                case MainOperation.Add:
                    {
                        Console.Write("Enter recruiter name: ");
                        string name = Console.ReadLine()!;

                        Console.Write("Enter recruiter email: ");
                        string email = Console.ReadLine()!;

                        Console.Write("Enter company ID: ");
                        int companyId;

                        while (!int.TryParse(Console.ReadLine(), out companyId))
                            Console.Write("Invalid company ID, try again: ");

                        _Add(name, email, companyId);
                        break;
                    }

                case MainOperation.Update:
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

                        _Update(id, name, email, companyId);
                        break;
                    }

                case MainOperation.List:
                    {
                        _Print();
                        break;
                    }

                case MainOperation.Remove:
                    {
                        Console.Write("Enter recruiter ID: ");
                        int id;

                        while (!int.TryParse(Console.ReadLine(), out id))
                            Console.Write("Invalid recruiter ID, try again: ");

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