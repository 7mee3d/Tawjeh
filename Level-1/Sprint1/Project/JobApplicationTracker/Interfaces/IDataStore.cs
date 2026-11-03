namespace JobApplicationTracker.Interfaces;

public interface IDataStore<T> where T : class , IEntity
{

    void Add(T item);
    bool Update(int id, T item);
    bool Remove(int id);
    T ? GetById(int id);
    IEnumerable<T> GetAll();


}