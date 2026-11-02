namespace JobApplicationTracker.Models;

public class Candidate
{
    public Candidate(int id,string fullName,string email,string phone,int yearsOfExperience)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id));

        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("Full name is required.", nameof(fullName));

        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required.", nameof(email));

        if (yearsOfExperience < 0)
            throw new ArgumentOutOfRangeException(nameof(yearsOfExperience));


        ChangeName(fullName);
        ChangeEmail(email);

        Id = id;
        Phone = phone;
        YearsOfExperience = yearsOfExperience;
    }

    public int Id { get; private set; }
    public string FullName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public int YearsOfExperience { get; private set; }

    public void ChangeName(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException(
                "Full name is required.", nameof(fullName));

        this.FullName = fullName.Trim();
    }

    public void ChangeEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required.", nameof(email));

        if (!System.Net.Mail.MailAddress.TryCreate(email, out _))
            throw new ArgumentException("Invalid email format.", nameof(email));

        this.Email = email.Trim();
    }
}