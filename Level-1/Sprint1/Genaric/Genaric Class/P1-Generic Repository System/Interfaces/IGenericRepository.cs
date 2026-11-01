namespace Interfaces ;

public interface IGenericRepository<T> where T : BaseEntity
{
    void Add(T item);
    T? GetById(int id);
    IEnumerable<T> GetAll();
    bool Update(int id , T item);
    bool Delete(int id);
    bool Exists(int id);
}