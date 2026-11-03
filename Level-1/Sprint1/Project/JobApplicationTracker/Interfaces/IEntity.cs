namespace JobApplicationTracker.Interfaces;

public interface IEntity
{
    int Id { get; }

    void AssignId(int id);
}