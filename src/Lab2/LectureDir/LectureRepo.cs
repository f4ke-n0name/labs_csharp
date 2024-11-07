using Itmo.ObjectOrientedProgramming.Lab2.Utils;

namespace Itmo.ObjectOrientedProgramming.Lab2.LectureDir;

public class LectureRepo : IRepo<Lecture>
{
    private readonly Dictionary<Guid, Lecture> _lectures = new Dictionary<Guid, Lecture>();

    public void Add(Lecture item)
    {
        if (!_lectures.TryAdd(item.LectureId, item))
        {
            throw new Exception("Lecture with this id already exists");
        }
    }

    public Lecture GetById(Guid id)
    {
        return !_lectures.TryGetValue(id, out Lecture? lecture) ? throw new Exception("Lecture with this id does not exist") : lecture;
    }

    public IEnumerable<Lecture> GetAll()
    {
        return _lectures.Values;
    }
}