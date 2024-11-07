using Itmo.ObjectOrientedProgramming.Lab2.Utils;

namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;

public class SubjectRepo : IRepo<Subject>
{
    private readonly Dictionary<Guid, Subject> _subjects = new Dictionary<Guid, Subject>();

    public void Add(Subject item)
    {
        bool addedCorrectly = _subjects.TryAdd(item.SubjectId, item);
        if (!addedCorrectly)
        {
            throw new ArgumentException("Subject with this id currently exists.");
        }
    }

    public Subject GetById(Guid id)
    {
        if (_subjects.TryGetValue(id, out Subject? subject))
        {
            return subject;
        }

        throw new KeyNotFoundException("Subject not found.");
    }

    public IEnumerable<Subject> GetAll()
    {
        return _subjects.Values;
    }
}