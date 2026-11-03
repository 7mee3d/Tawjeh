using System.Net.Mail;

namespace JobApplicationTracker.Models;

public class Recruiter : BaseEntity
{
    public Recruiter(string name, string email, int companyId)
    {
        if (companyId <= 0)
            throw new ArgumentOutOfRangeException(nameof(companyId));

        ChangeName(name);
        ChangeEmail(email);
        ChangeCompany(companyId);
    }

    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public int CompanyId { get; private set; }

    public void ChangeName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.");

        this.Name = name.Trim();
    }

    public void ChangeEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required.");

        if (!MailAddress.TryCreate(email, out _))
            throw new ArgumentException("Invalid email format.");

        this.Email = email.Trim();
    }

    public void ChangeCompany(int companyId)
    {
        if (companyId <= 0)
            throw new ArgumentOutOfRangeException(nameof(companyId));

        CompanyId = companyId;
    }
}