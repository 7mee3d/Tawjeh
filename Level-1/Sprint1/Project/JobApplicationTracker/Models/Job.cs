using System.ComponentModel.DataAnnotations;

namespace JobApplicationTracker.Models;

public class Job : BaseEntity
{
    public Job(string title, string description, decimal salary, string location, int companyId, int recruiterId)
    {
        ChangeDescription(description);
        ChangeLocation(location);
        ChangeTitle(title);
        ChangeRecruiter(recruiterId);
        ChangeCompany(companyId);
        ChangeSalary(salary);

        PostedDate = DateTime.Now;

    }

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
        if (companyId <= 0)
            throw new ArgumentOutOfRangeException(nameof(companyId));

        this.CompanyId = companyId;
    }

    public void ChangeRecruiter(int recruiterId)
    {
        if (recruiterId <= 0)
            throw new ArgumentOutOfRangeException(nameof(recruiterId));

        this.RecruiterId = recruiterId;
    }
    public void ChangeSalary(decimal salary)
    {
        if (salary <= 0)
            throw new ArgumentOutOfRangeException(nameof(salary));

        this.Salary = salary;
    }

}