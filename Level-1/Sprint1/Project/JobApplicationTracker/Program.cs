using JobApplicationTracker.Enums;
using JobApplicationTracker.Data;
using JobApplicationTracker.Presentation;

void PrintMainMenu()
{
    Console.WriteLine();
    Console.WriteLine("========================================");
    Console.WriteLine("       JOB APPLICATION TRACKER");
    Console.WriteLine("========================================");
    Console.WriteLine("  [1] Companies");
    Console.WriteLine("  [2] Recruiters");
    Console.WriteLine("  [3] Jobs");
    Console.WriteLine("  [4] Candidates");
    Console.WriteLine("  [5] Applications");
    Console.WriteLine("  [0] Exit");
    Console.WriteLine("========================================");
    Console.Write("  Select an option: ");
}

DataContext context = new();

CompanyPresentation company = new(context);
RecruiterPresentation recruiter = new(context);
JobPresentation job = new(context);
CandidatePresentation candidate = new(context);
ApplicationPresentation application = new(context);

while (true)
{
    Console.Clear();
    PrintMainMenu();

    if (!byte.TryParse(Console.ReadLine(), out byte choice))
    {
        Console.WriteLine("\nInvalid input!");
        Console.ReadKey();
        continue;
    }

    switch ((MainMenuOption)choice)
    {
        case MainMenuOption.Companies:
            company.Start();
            break;

        case MainMenuOption.Recruiters:
            recruiter.Start();
            break;

        case MainMenuOption.Jobs:
            job.Start();
            break;

        case MainMenuOption.Candidates:
            candidate.Start();
            break;

        case MainMenuOption.Applications:
            application.Start();
            break;

        case MainMenuOption.Exit:
            return;

        default:
            Console.WriteLine("\nInvalid choice!");
            Console.ReadKey();
            break;
    }
}
