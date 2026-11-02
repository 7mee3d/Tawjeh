using System.ComponentModel.DataAnnotations;
using JobApplicationTracker.Enums;

namespace JobApplicationTracker.Models;

public class Company
{
    public Company(int id, string name, string industry, string city)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id));

        this.Id = id ; 
        SetName(name);
        SetIndustry(industry);
        SetCity(city);
    }
    
    public int Id { get; private set; }
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
        if (!Enum.IsDefined(status))
            throw new InvalidOperationException("Status Company is invalid");

        this.Status = status;
    }

    public void SetIndustry(string industry)
    {
        if (string.IsNullOrWhiteSpace(industry))
            throw new ArgumentException("Industry is not valid");

        this.Industry = industry.Trim();
    }
}