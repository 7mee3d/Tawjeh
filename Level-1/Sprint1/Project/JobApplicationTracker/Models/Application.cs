using JobApplicationTracker.Enums;

namespace JobApplicationTracker.Models;

public class Application : BaseEntity
{
    public Application(int jobId, int candidateId)
    {
        ChangeJobId(jobId);
        ChangeCandidateId(candidateId);

        AppliedDate = DateTime.Now;

    }
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
        if (!Enum.IsDefined(typeof(ApplicationStatus), status))
            throw new InvalidOperationException("Application status is invalid.");

        if (this.Status == ApplicationStatus.Accepted ||
            this.Status == ApplicationStatus.Rejected)
            throw new InvalidOperationException("Application status cannot be changed.");

        if (status == this.Status)
            throw new InvalidOperationException("Application already has this status.");

        this.Status = status;
    }
}