using System.ComponentModel.DataAnnotations;

namespace JobApplicationTracker.Models;

public class Job
{
    public Job(int id, string title, string description, decimal salary, string location, int companyId, int recruiterId)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id), id, "Job ID must be greater than zero.");
        if (companyId <= 0)
            throw new ArgumentOutOfRangeException(nameof(companyId), companyId, "Company ID must be greater than zero.");
        if (recruiterId <= 0)
            throw new ArgumentOutOfRangeException(nameof(recruiterId), recruiterId, "Recruiter ID must be greater than zero.");
        if (salary <= 0)
            throw new ArgumentOutOfRangeException(nameof(salary), salary, "Salary must be greater than zero.");

        ChangeDescription(description);
        ChangeLocation(location);
        ChangeTitle(title);

        Id = id;
        Salary = salary;
        PostedDate = DateTime.Now;
        CompanyId = companyId;
        RecruiterId = recruiterId;
    }

    public int Id { get; private set; }
    [Required]
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    [Range(typeof(decimal), "0.01", "9999999999999999.99")] public decimal Salary { get; private set; }
    public string Location { get; private set; } = string.Empty;
    public bool IsOpen { get; private set; } = true;
    public DateTime PostedDate { get; private set; }
    public int CompanyId { get; private set; }
    public int RecruiterId { get; private set; }


    public void ChangeTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is reqired");

        this.Title = title.Trim();

    }

    public void ChangeDescription(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
            throw new ArgumentException("Description is reqired");

        this.Description = description.Trim();
    }

    public void ChangeLocation(string location)
    {
        if (string.IsNullOrWhiteSpace(location))
            throw new ArgumentException("Location is reqired");

        this.Location = location.Trim();
    }

    public void SetOpen()
    {
        if (this.IsOpen)
            throw new InvalidOperationException("The Job Already opened ");

        this.IsOpen = true;
    }

    public void SetClose()
    {
        if (!this.IsOpen)
            throw new InvalidOperationException("The Job Already closed ");

        this.IsOpen = false;
    }
    public void ChangeCompany(int companyId)
    {
        CompanyId = companyId;
    }

    public void ChangeRecruiter(int recruiterId)
    {
        RecruiterId = recruiterId;
    }

}