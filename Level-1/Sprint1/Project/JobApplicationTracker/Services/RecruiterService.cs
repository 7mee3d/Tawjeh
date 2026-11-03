
using JobApplicationTracker.Enums;
using JobApplicationTracker.Models;

namespace JobApplicationTracker.Services;

public class RecruiterService
{
    private readonly List<Recruiter> _recruiters = new();

    public RecruiterService()
    {
        _AddRecruiters();
    }

    private void _AddRecruiters()
    {
        _recruiters.Add(new Recruiter(1, "John Smith", "john@microsoft.com", 1));
        _recruiters.Add(new Recruiter(2, "Sarah Johnson", "sarah@google.com", 2));
        _recruiters.Add(new Recruiter(3, "Michael Brown", "michael@amazon.com", 3));
    }

    private void _Print()
    {
        if (_recruiters.Count == 0)
        {
            Console.WriteLine("No recruiters found.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine($"{"ID",-5} {"Name",-20} {"Email",-30} {"Company ID",-10}");
        Console.WriteLine("---------------------------------------------------------------------");

        foreach (var recruiter in _recruiters)
        {
            Console.WriteLine(
                $"{recruiter.Id,-5} {recruiter.Name,-20} {recruiter.Email,-30} {recruiter.CompanyId,-10}");
        }
    }

    private void _Add(string name, string email, int companyId)
    {
        try
        {
            int nextId = _recruiters.Count == 0
                ? 1
                : _recruiters[^1].Id + 1;

            var newRecruiter = new Recruiter(nextId, name, email, companyId);

            _recruiters.Add(newRecruiter);

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
            foreach (var recruiter in _recruiters)
            {
                if (recruiter.Id == id)
                {
                    recruiter.ChangeName(name);
                    recruiter.ChangeEmail(email);
                    recruiter.ChangeCompany(companyId);

                    Console.WriteLine($"\nRecruiter ID {id} Updated Successfully");
                    return;
                }
            }

            Console.WriteLine("Recruiter does not exist");
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
            int index = _recruiters.FindIndex(x => x.Id == id);

            if (index == -1)
            {
                Console.WriteLine("Recruiter does not exist");
                return;
            }

            _recruiters.RemoveAt(index);

            Console.WriteLine($"\nRecruiter ID {id} Removed Successfully");
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
