
using JobApplicationTracker.Data;
using JobApplicationTracker.Enums;
using JobApplicationTracker.Models;
using JobApplicationTracker.Services;

namespace JobApplicationTracker.Presentation;

public class JobPresentation
{
    private readonly JobService _service;

    public JobPresentation(DataContext context)
    {
        _service = new JobService(context);
    }

    private int _ReadId()
    {
        Console.Write("Enter job ID: ");
        int id;

        while (!int.TryParse(Console.ReadLine(), out id))
            Console.Write("Invalid job ID, try again: ");

        return id;
    }

    private void _Add()
    {
        Console.Write("Enter job title: ");
        string title = Console.ReadLine()!;

        Console.Write("Enter job description: ");
        string description = Console.ReadLine()!;

        Console.Write("Enter salary: ");
        decimal salary;

        while (!decimal.TryParse(Console.ReadLine(), out salary))
            Console.Write("Invalid salary, try again: ");

        Console.Write("Enter location: ");
        string location = Console.ReadLine()!;

        Console.Write("Enter company ID: ");
        int companyId;

        while (!int.TryParse(Console.ReadLine(), out companyId))
            Console.Write("Invalid company ID, try again: ");

        Console.Write("Enter recruiter ID: ");
        int recruiterId;

        while (!int.TryParse(Console.ReadLine(), out recruiterId))
            Console.Write("Invalid recruiter ID, try again: ");

        _service.Add(title, description, salary, location, companyId, recruiterId);
        Console.WriteLine("\nJob Added Successfully");
    }

    private void _Update()
    {

        int id = _ReadId();
        Console.Write("Enter new job title: ");
        string title = Console.ReadLine()!;

        Console.Write("Enter new job description: ");
        string description = Console.ReadLine()!;

        Console.Write("Enter new salary: ");
        decimal salary;

        while (!decimal.TryParse(Console.ReadLine(), out salary))
            Console.Write("Invalid salary, try again: ");

        Console.Write("Enter new location: ");
        string location = Console.ReadLine()!;

        Console.Write("Enter new company ID: ");
        int companyId;

        while (!int.TryParse(Console.ReadLine(), out companyId))
            Console.Write("Invalid company ID, try again: ");

        Console.Write("Enter new recruiter ID: ");
        int recruiterId;

        while (!int.TryParse(Console.ReadLine(), out recruiterId))
            Console.Write("Invalid recruiter ID, try again: ");

        bool isUpdated = _service.Update(id, title, description, salary, location, companyId, recruiterId);

        if (isUpdated)
            Console.WriteLine("Job updated successfully.");
        else
            Console.WriteLine($"Job with ID {id} does not exist.");
    }

    private void _Remove()
    {
        int id = _ReadId();

        bool isRemoved = _service.Remove(id);

        if (isRemoved)
            Console.WriteLine($"Job with ID {id} removed successfully.");
        else
            Console.WriteLine($"Job with ID {id} does not exist.");
    }

    private void _Print(IEnumerable<Job> jobs)
    {

        bool hasJobs = false;
        Console.WriteLine();
        Console.WriteLine($"{"ID",-5} {"Title",-20} {"Salary",-12} {"Location",-15} {"Is Open",-10} {"Company ID",-12} {"Recruiter ID",-12}");
        Console.WriteLine("----------------------------------------------------------------------------------------------");


        foreach (var job in jobs)
        {
            hasJobs = true;
            Console.WriteLine($"{job.Id,-5} {job.Title,-20} {job.Salary,-12:F2} {job.Location,-15} {job.IsOpen,-10} {job.CompanyId,-12} {job.RecruiterId,-12}");
        }

        if (!hasJobs)
            Console.WriteLine("No jobs found.");
    }

    private void _Get()
    {
        int id = _ReadId();

        Job? job = _service.GetById(id);

        if (job is null)
        {
            Console.WriteLine("No job found.");
            return;
        }

        _Print([job]);
    }

    public void Start()
    {
        while (true)
        {
            Console.Clear();
            Utility.Utility.PrintBasicSubMenu("Job");

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
                        _Print(_service.List());
                        break;

                    case MainOperation.Remove:
                        _Remove();
                        break;
                    case MainOperation.Get:
                        _Get();
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
