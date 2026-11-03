using JobApplicationTracker.Data;
using JobApplicationTracker.Enums;
using JobApplicationTracker.Models;

namespace JobApplicationTracker.Services;

public class ApplicationService
{
    private readonly DataContext _context;

    public ApplicationService(DataContext context)
    {
        _context = context;
        _AddApplications();
    }

    private void _AddApplications()
    {
        _context.Applications.Add(new Application(1, 1));
        _context.Applications.Add(new Application(2, 2));
        _context.Applications.Add(new Application(3, 3));
        _context.Applications.Add(new Application(4, 4));
        _context.Applications.Add(new Application(5, 5));
    }

    private void _Print()
    {
        if (_context.Applications.GetAll().Count() == 0)
        {
            Console.WriteLine("No applications found.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine($"{"ID",-5} {"Job ID",-10} {"Candidate ID",-15} {"Applied Date",-15} {"Status",-15}");
        Console.WriteLine("----------------------------------------------------------------");

        foreach (var application in _context.Applications.GetAll())
        {
            Console.WriteLine(
                $"{application.Id,-5} {application.JobId,-10} {application.CandidateId,-15} {application.AppliedDate,-15:yyyy-MM-dd} {application.Status,-15}");
        }
    }

    private void _Add(int jobId, int candidateId)
    {
        try
        {
            _context.Applications.Add(new Application(jobId, candidateId));

            Console.WriteLine("\nApplication Added Successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void _Update(int id, int jobId, int candidateId, ApplicationStatus status)
    {
        try
        {
            bool isUpdated = _context.Applications.Update(id, new Application(jobId, candidateId, status));

            if (isUpdated)
                Console.WriteLine("Application updated successfully.");
            else
                Console.WriteLine($"Application with ID {id} does not exist.");
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
            bool isRemoved = _context.Applications.Remove(id);

            if (isRemoved)
                Console.WriteLine($"Application with ID {id} removed successfully.");
            else
                Console.WriteLine($"Application with ID {id} does not exist.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void StartupApplicationService()
    {
        while (true)
        {
            Console.Clear();
            Utility.Utility.PrintSubMenu("Application");

            byte choice = 0;

            Console.Write("Choose: ");
            while (!byte.TryParse(Console.ReadLine(), out choice))
                Console.Write("Invalid choice, try again: ");

            switch ((MainOperation)choice)
            {
                case MainOperation.Add:
                    {
                        Console.Write("Enter Job ID: ");
                        int jobId;
                        while (!int.TryParse(Console.ReadLine(), out jobId))
                            Console.Write("Invalid Job ID, try again: ");

                        Console.Write("Enter Candidate ID: ");
                        int candidateId;
                        while (!int.TryParse(Console.ReadLine(), out candidateId))
                            Console.Write("Invalid Candidate ID, try again: ");

                        _Add(jobId, candidateId);
                        break;
                    }

                case MainOperation.Update:
                    {
                        Console.Write("Enter Application ID: ");
                        int id;
                        while (!int.TryParse(Console.ReadLine(), out id))
                            Console.Write("Invalid Application ID, try again: ");

                        Console.Write("Enter New Job ID: ");
                        int jobId;
                        while (!int.TryParse(Console.ReadLine(), out jobId))
                            Console.Write("Invalid Job ID, try again: ");

                        Console.Write("Enter New Candidate ID: ");
                        int candidateId;
                        while (!int.TryParse(Console.ReadLine(), out candidateId))
                            Console.Write("Invalid Candidate ID, try again: ");

                        Console.WriteLine("Select New Application Status:");

                        foreach (ApplicationStatus status in Enum.GetValues<ApplicationStatus>())
                            Console.WriteLine($"{(int)status} - {status}");

                        ApplicationStatus newStatus;
                        int statusValue;

                        while (!int.TryParse(Console.ReadLine(), out statusValue) || !Enum.IsDefined(typeof(ApplicationStatus), statusValue))
                        {
                            Console.Write("Invalid Status, try again: ");
                        }

                        newStatus = (ApplicationStatus)statusValue;

                        _Update(id, jobId, candidateId, newStatus);

                        break;
                    }

                case MainOperation.List:
                    {
                        _Print();
                        break;
                    }

                case MainOperation.Remove:
                    {
                        Console.Write("Enter Application ID: ");
                        int id;
                        while (!int.TryParse(Console.ReadLine(), out id))
                            Console.Write("Invalid Application ID, try again: ");

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