namespace JobApplicationTracker.Services;

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

}