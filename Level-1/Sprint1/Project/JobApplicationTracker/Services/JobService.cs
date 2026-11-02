namespace JobApplicationTracker.Services;

using JobApplicationTracker.Enums;
using JobApplicationTracker.Models;
public class JobService
{
    private List<Job> _jobs = new();

    public JobService()
    {
        _AddJobs();
    }

    private void _AddJobs()
    {
        _jobs.Add(new Job(1, "Backend Developer", ".NET and ASP.NET Core development", 2500, "Redmond", 1, 1));
        _jobs.Add(new Job(2, "Software Engineer", "Build scalable software systems", 3000, "Redmond", 1, 1));
        _jobs.Add(new Job(3, "Frontend Developer", "React and modern JavaScript development", 2200, "Mountain View", 2, 2));
        _jobs.Add(new Job(4, "Data Engineer", "Design and maintain data pipelines", 3500, "Mountain View", 2, 2));
        _jobs.Add(new Job(5, "Cloud Engineer", "AWS infrastructure and cloud solutions", 3200, "Seattle", 3, 3));
        _jobs.Add(new Job(6, "DevOps Engineer", "CI/CD and infrastructure automation", 3000, "Seattle", 3, 3));
    }

    public void PrintJobs()
    {
        foreach (var job in _jobs)
        {
            Console.WriteLine($"ID          : {job.Id}");
            Console.WriteLine($"Title       : {job.Title}");
            Console.WriteLine($"Description : {job.Description}");
            Console.WriteLine($"Salary      : {job.Salary}");
            Console.WriteLine($"Location    : {job.Location}");
            Console.WriteLine($"IsOpen      : {job.IsOpen}");
            Console.WriteLine($"PostedDate  : {job.PostedDate}");
            Console.WriteLine($"CompanyId   : {job.CompanyId}");
            Console.WriteLine($"RecruiterId : {job.RecruiterId}");
            Console.WriteLine(new string('-', 40));
        }
    }

    private void _AddJob(string title, string description, decimal salary, string location, int companyId, int recuiterId)
    {
        try
        {
            var job = _jobs[^1];

            int lastId = job.Id;

            if (lastId <= 0)
            {
                System.Console.WriteLine("Invalid id ");
                return;
            }

            int nextId = lastId + 1;

            var newJob = new Job(nextId, title, description, salary, location, companyId, recuiterId);

            _jobs.Add(newJob);
            System.Console.WriteLine($"\n\nJob Added Successfully");


        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }

    private void _UpdateJob(int id, string title, string description, decimal salary, string location, int companyId, int recuiterId)
    {
        try
        {

            foreach (var job in _jobs)
            {
                if (job.Id == id)
                {
                    job.ChangeTitle(title);
                    job.ChangeDescription(description);
                    job.ChangeLocation(location);
                    job.ChangeRecruiter(recuiterId);
                    job.ChangeCompany(companyId);
                    System.Console.WriteLine($"\n\nJob id {id} Updated Successfully");

                    return;

                }
            }

            System.Console.WriteLine("Company does not exists");

        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }

    private void _Remove(int id)
    {
        try
        {

            int index = _jobs.FindIndex(x => x.Id == id);
            if (index == -1)
            {
                System.Console.WriteLine("Job does not exists");
                return;
            }

            _jobs.RemoveAt(index);
            System.Console.WriteLine($"\n\nJob id {id} Removed Successfully");

        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
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

                        _AddJob(title, description, salary, location, companyId, recruiterId);
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

                        _UpdateJob(id, title, description, salary, location, companyId, recruiterId);
                        break;
                    }

                case MainOperation.List:
                    {
                        PrintJobs();
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