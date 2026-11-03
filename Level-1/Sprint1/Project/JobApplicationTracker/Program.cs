
using JobApplicationTracker.Services;
using JobApplicationTracker.Enums;

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


CompanyService companyService = new();
RecruiterService recruiterService = new();
JobService jobService = new();
CandidateService candidateService = new();
ApplicationService applicationService = new();


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
            companyService.StartupCompanyService();
            break;

        case MainMenuOption.Recruiters:
            recruiterService.StartupRecruiterService();
            break;

        case MainMenuOption.Jobs:
            jobService.StartupJobService();
            break;

        case MainMenuOption.Candidates:
            candidateService.StartupCandidateService();
            break;

        case MainMenuOption.Applications:
            applicationService.StartupApplicationService();
            break;

        case MainMenuOption.Exit:
            Console.WriteLine("\nThank you");
            return;

        default:
            Console.WriteLine("\nInvalid choice!");
            Console.ReadKey();
            break;
    }
}