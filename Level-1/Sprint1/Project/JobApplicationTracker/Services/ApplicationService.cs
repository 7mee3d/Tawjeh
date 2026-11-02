
using JobApplicationTracker.Enums;
using JobApplicationTracker.Models;

namespace JobApplicationTracker.Services;

public class ApplicationService
{
    private List<Application> _applications = new();

    public ApplicationService()
    {
        _AddApplications();
    }

    private void _AddApplications()
    {
        _applications.Add(new Application(1, 1, 1));
        _applications.Add(new Application(2, 2, 2));
        _applications.Add(new Application(3, 3, 3));
        _applications.Add(new Application(4, 4, 4));
        _applications.Add(new Application(5, 5, 5));
    }

    public void PrintApplications()
    {
        foreach (var application in _applications)
        {
            Console.WriteLine($"ID          : {application.Id}");
            Console.WriteLine($"JobId       : {application.JobId}");
            Console.WriteLine($"CandidateId : {application.CandidateId}");
            Console.WriteLine($"AppliedDate : {application.AppliedDate}");
            Console.WriteLine($"Status      : {application.Status}");
            Console.WriteLine(new string('-', 40));
        }
    }

    private void _AddApplication(int jobId, int candidateId)
    {
        try
        {
            var application = _applications[^1];

            int lastId = application.Id;

            if (lastId <= 0)
            {
                Console.WriteLine("Invalid ID");
                return;
            }

            int nextId = lastId + 1;

            var newApplication = new Application(nextId, jobId, candidateId);

            _applications.Add(newApplication);

            Console.WriteLine("\nApplication Added Successfully");
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
            int index = _applications.FindIndex(x => x.Id == id);

            if (index == -1)
            {
                Console.WriteLine("Application does not exist");
                return;
            }

            _applications.RemoveAt(index);

            Console.WriteLine($"\nApplication ID {id} Removed Successfully");
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

                        _AddApplication(jobId, candidateId);
                        break;
                    }

                case MainOperation.List:
                    {
                        PrintApplications();
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
