using System.ComponentModel.DataAnnotations;
using JobApplicationTracker.Enums;

namespace JobApplicationTracker.Models;

public class Company : BaseEntity
{
    public Company(string name, string industry, string city, CompanyStatus status = CompanyStatus.Pending)
    {
        ChangeStatusCompany(status);
        SetName(name);
        SetIndustry(industry);
        SetCity(city);
    }

    [Required]
    public string Name { get; private set; } = string.Empty;
    public string Industry { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public CompanyStatus Status { get; private set; } = CompanyStatus.Pending;

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Comapny name is invalid");

        this.Name = name.Trim();
    }

    public void SetCity(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City name is invalid");

        this.City = city.Trim();
    }

    public void ChangeStatusCompany(CompanyStatus status)
    {
        if (!Enum.IsDefined(typeof(CompanyStatus), status))
            throw new InvalidOperationException("Status Company is invalid");

        if (this.Status != CompanyStatus.Pending)
            throw new InvalidOperationException("Company status cannot be changed.");

        this.Status = status;
    }

    public void SetIndustry(string industry)
    {
        if (string.IsNullOrWhiteSpace(industry))
            throw new ArgumentException("Industry is not valid");

        this.Industry = industry.Trim();
    }
}