using JobApplicationTracker.Interfaces;

namespace JobApplicationTracker.Models;

public abstract class BaseEntity : IEntity
{
    public int Id { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public void AssignId(int id)
    {
        if (this.Id != 0)
            throw new ArgumentException("Must assign id");

        if (id <= 0)
            throw new ArgumentOutOfRangeException(nameof(id));

        this.Id = id;
        this.CreatedAt = DateTime.Now;
    }
}