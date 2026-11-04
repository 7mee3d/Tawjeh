
using JobApplicationTracker.Data;
using JobApplicationTracker.Enums;
using JobApplicationTracker.Models;
using JobApplicationTracker.Services;

namespace JobApplicationTracker.Presentation;

public class ApplicationPresentation
{
    private readonly ApplicationService _service;

    public ApplicationPresentation(DataContext context)
    {
        _service = new ApplicationService(context);
    }

    private void _Add()
    {
        Console.Write("Enter Job ID: ");
        int jobId;

        while (!int.TryParse(Console.ReadLine(), out jobId))
            Console.Write("Invalid Job ID, try again: ");

        Console.Write("Enter Candidate ID: ");
        int candidateId;

        while (!int.TryParse(Console.ReadLine(), out candidateId))
            Console.Write("Invalid Candidate ID, try again: ");

        _service.Add(jobId, candidateId);
        Console.WriteLine("Application Added Successfully");

    }

    private void _Update()
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

        int statusValue;

        while (!int.TryParse(Console.ReadLine(), out statusValue) || !Enum.IsDefined(typeof(ApplicationStatus), statusValue))
            Console.Write("Invalid Status, try again: ");

        ApplicationStatus newStatus = (ApplicationStatus)statusValue;


        bool isUpdated = _service.Update(id, jobId, candidateId, newStatus);

        if (isUpdated)
            Console.WriteLine("Application updated successfully.");
        else
            Console.WriteLine($"Application with ID {id} does not exist.");

    }

    private void _Remove()
    {
        Console.Write("Enter Application ID: ");
        int id;

        while (!int.TryParse(Console.ReadLine(), out id))
            Console.Write("Invalid Application ID, try again: ");


        bool isRemoved = _service.Remove(id);

        if (isRemoved)
            Console.WriteLine($"Application with ID {id} removed successfully.");
        else
            Console.WriteLine($"Application with ID {id} does not exist.");

    }

    private void _Print()
    {
        IEnumerable<Application> applications = _service.List();

        if (!applications.Any())
        {
            Console.WriteLine("No applications found.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine($"{"ID",-5} {"Job ID",-10} {"Candidate ID",-15} {"Applied Date",-15} {"Status",-15}");
        Console.WriteLine("----------------------------------------------------------------");

        foreach (Application application in applications)
            Console.WriteLine($"{application.Id,-5} {application.JobId,-10} {application.CandidateId,-15} {application.AppliedDate,-15:yyyy-MM-dd} {application.Status,-15}");
    }

    public void Start()
    {
        while (true)
        {
            Console.Clear();
            Utility.Utility.PrintBasicSubMenu("Application");

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
