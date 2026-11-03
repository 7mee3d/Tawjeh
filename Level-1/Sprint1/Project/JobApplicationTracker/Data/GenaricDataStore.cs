using JobApplicationTracker.Interfaces;

namespace JobApplicationTracker.Data;

public class GenericDataStore<T> : IDataStore<T> where T : class, IEntity
{
    private readonly List<T> _items = new();

    private int _Id = 0;

    public void Add(T item)
    {
        if (item is null)
            ArgumentNullException.ThrowIfNull(item);

        int nextId = _Id + 1;
        item.AssignId(nextId);
        _items.Add(item);

        _Id = nextId;
    }

    public IEnumerable<T> GetAll()
    {
        return new List<T>(_items);
    }

    public T? GetById(int id)
    {
        CheckId(id);

        if (_items.Count == 0)
            return null;

        foreach (var item in _items)
            if (item.Id == id)
                return item;
        return null;
    }

    public bool Remove(int id)
    {
        CheckId(id);

        if (_items.Count == 0)
            return false;

        int index = _items.FindIndex(x => x.Id == id);

        if (index == -1)
            return false;

        _items.RemoveAt(index);

        return true;
    }

    public bool Update(int id, T item)
    {
        CheckId(id);

        if (_items.Count == 0)
            return false;

        if (item is null)
            ArgumentNullException.ThrowIfNull(item);

        int index = _items.FindIndex(x => x.Id == id);

        if (index == -1)
            return false;

        item.AssignId(id);

        _items[index] = item;
        return true;

    }

    private void CheckId(int id)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
    }
}