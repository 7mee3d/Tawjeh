using JobApplicationTracker.Enums;

namespace JobApplicationTracker.Models;

public class Application
{
    public Application(int id, int jobId, int candidateId)
    {
        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id));

        ChangeJobId(jobId);
        ChangeCandidateId(candidateId);
        Id = id;
        AppliedDate = DateTime.Now;

    }
    public int Id { get; private set; }
    public int JobId { get; private set; }
    public int CandidateId { get; private set; }
    public DateTime AppliedDate { get; private set; }
    public ApplicationStatus Status { get; private set; } = ApplicationStatus.Submitted;

    public void ChangeJobId(int jobId)
    {
        if (jobId <= 0)
            throw new ArgumentOutOfRangeException(nameof(jobId));

        this.JobId = jobId;
    }

    public void ChangeCandidateId(int candidateId)
    {
        if (candidateId <= 0)
            throw new ArgumentOutOfRangeException(nameof(candidateId));

        this.CandidateId = candidateId;
    }

    public void ChangeStatus(ApplicationStatus status)
    {
        if (!Enum.IsDefined(status))
            throw new ArgumentOutOfRangeException(nameof(status));

        this.Status = status;
    }
}