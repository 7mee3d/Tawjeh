using Interfaces;

public class GenericRepository<T> : IGenericRepository<T>
    where T : BaseEntity
{
    private readonly List<T> _values = new();

    public void Add(T item)
    {
        if (Exists(item.Id))
            throw new Exception("This id already exists");

        _values.Add(item);
    }

    private bool HasElements()
    {
        return _values.Count > 0;
    }

    public bool Delete(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        if (!HasElements())
            return false;

        int index = _values.FindIndex(x => x.Id == id);

        if (index == -1)
            return false;
        
        _values.RemoveAt(index);
        return true ; 

    }

    public bool Exists(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        foreach (var item in _values)
            if (item.Id == id)
                return true;

        return false;
    }

    public IEnumerable<T> GetAll()
    {
        return _values;
    }

    public T? GetById(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);

        foreach (var item in _values)
        {
            if (item.Id == id)
                return item;
        }
        return default(T);
    }

    public bool Update(int id, T item)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);


        int index = _values.FindIndex(x => x.Id == id);

        if (index == -1)
            return false;

        if (item.Id != id)
            throw new ArgumentException("The item ID must match the requested ID.");

        _values[index] = item;
        return true;
    }
}