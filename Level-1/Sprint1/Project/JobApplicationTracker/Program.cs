using JobApplicationTracker.Services;

//Load Data 

var companyService = new CompanyService();
var recruiterService = new RecruiterService();
var jobService = new JobService();
var candidateService = new CandidateService();
var applicationService = new ApplicationService();

//Print data every entity

companyService.PrintCompanies();
recruiterService.PrintRecruiters();
jobService.PrintJobs();
candidateService.PrintCandidates();
applicationService.PrintApplications();