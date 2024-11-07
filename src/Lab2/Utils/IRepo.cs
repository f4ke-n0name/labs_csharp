namespace Itmo.ObjectOrientedProgramming.Lab2.Utils;

public interface IRepo<T>
{
    void Add(T item);

    T GetById(Guid id);

    IEnumerable<T> GetAll();
}
