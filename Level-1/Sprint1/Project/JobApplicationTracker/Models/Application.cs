using JobApplicationTracker.Enums;

namespace JobApplicationTracker.Models;

public class Application
{
    public Application(int id, int jobId, int candidateId)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id));

        if (jobId <= 0)
            throw new ArgumentOutOfRangeException(nameof(jobId));

        if (candidateId <= 0)
            throw new ArgumentOutOfRangeException(nameof(candidateId));

        Id = id;
        JobId = jobId;
        CandidateId = candidateId;
        AppliedDate = DateTime.Now;
    }

    public int Id { get; private set; }
    public int JobId { get; private set; }
    public int CandidateId { get; private set; }
    public DateTime AppliedDate { get; private set; }
    public ApplicationStatus Status { get; private set; } = ApplicationStatus.Submitted;

    public void ChangeStatus(ApplicationStatus status)
    {
        if (!Enum.IsDefined(status))
            throw new ArgumentOutOfRangeException(nameof(status));

        this.Status = status;
    }
}