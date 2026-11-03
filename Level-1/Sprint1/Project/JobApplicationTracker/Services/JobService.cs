using JobApplicationTracker.Data;
using JobApplicationTracker.Enums;
using JobApplicationTracker.Models;

namespace JobApplicationTracker.Services;

public class JobService
{
    private readonly DataContext _context;

    public JobService(DataContext context)
    {
        _context = context;
        _AddJobs();
    }

    private void _AddJobs()
    {
        _context.Jobs.Add(new Job("Backend Developer", ".NET and ASP.NET Core development", 2500, "Redmond", 1, 1));
        _context.Jobs.Add(new Job("Software Engineer", "Build scalable software systems", 3000, "Redmond", 1, 1));
        _context.Jobs.Add(new Job("Frontend Developer", "React and modern JavaScript development", 2200, "Mountain View", 2, 2));
        _context.Jobs.Add(new Job("Data Engineer", "Design and maintain data pipelines", 3500, "Mountain View", 2, 2));
        _context.Jobs.Add(new Job("Cloud Engineer", "AWS infrastructure and cloud solutions", 3200, "Seattle", 3, 3));
        _context.Jobs.Add(new Job("DevOps Engineer", "CI/CD and infrastructure automation", 3000, "Seattle", 3, 3));
    }

    private void _Print()
    {
        if (_context.Jobs.GetAll().Count() == 0)
        {
            Console.WriteLine("No jobs found.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine($"{"ID",-5} {"Title",-20} {"Salary",-12} {"Location",-15} {"Is Open",-10} {"Company ID",-12} {"Recruiter ID",-12}");
        Console.WriteLine("----------------------------------------------------------------------------------------------");

        foreach (var job in _context.Jobs.GetAll())
        {
            Console.WriteLine(
                $"{job.Id,-5} {job.Title,-20} {job.Salary,-12:F2} {job.Location,-15} {job.IsOpen,-10} {job.CompanyId,-12} {job.RecruiterId,-12}");
        }
    }

    private void _Add(string title, string description, decimal salary, string location, int companyId, int recuiterId)
    {
        try
        {
            _context.Jobs.Add(new Job(title, description, salary, location, companyId, recuiterId));
            System.Console.WriteLine($"\n\nJob Added Successfully");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }

    private void _Update(int id, string title, string description, decimal salary, string location, int companyId, int recruiterId)
    {
        try
        {
            bool isUpdated = _context.Jobs.Update(id, new Job(title, description, salary, location, companyId, recruiterId));

            if (isUpdated)
                Console.WriteLine("Job updated successfully.");
            else
                Console.WriteLine($"Job with ID {id} does not exist.");
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
            bool isRemoved = _context.Jobs.Remove(id);

            if (isRemoved)
                Console.WriteLine($"Job with ID {id} removed successfully.");
            else
                Console.WriteLine($"Job with ID {id} does not exist.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public void StartupJobService()
    {
        while (true)
        {
            Console.Clear();
            Utility.Utility.PrintSubMenu("Job");

            byte choice = 0;

            Console.Write("Choose: ");
            while (!byte.TryParse(Console.ReadLine(), out choice))
                Console.Write("Invalid choice, try again: ");

            switch ((MainOperation)choice)
            {
                case MainOperation.Add:
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

                        _Add(title, description, salary, location, companyId, recruiterId);
                        break;
                    }

                case MainOperation.Update:
                    {
                        Console.Write("Enter job ID: ");
                        int id;
                        while (!int.TryParse(Console.ReadLine(), out id))
                            Console.Write("Invalid job ID, try again: ");

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

                        _Update(id, title, description, salary, location, companyId, recruiterId);
                        break;
                    }

                case MainOperation.List:
                    {
                        _Print();
                        break;
                    }

                case MainOperation.Remove:
                    {
                        Console.Write("Enter job ID: ");
                        int id;
                        while (!int.TryParse(Console.ReadLine(), out id))
                            Console.Write("Invalid job ID, try again: ");

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