using Itmo.ObjectOrientedProgramming.Lab2.Utils;

namespace Itmo.ObjectOrientedProgramming.Lab2.LabworkDir;

public class LabWorkRepo : IRepo<LabWork>
{
    private readonly Dictionary<Guid, LabWork> _labWorks = new Dictionary<Guid, LabWork>();

    public void Add(LabWork item)
    {
        if (!_labWorks.TryAdd(item.LabId, item))
        {
            throw new Exception("Labwork with this id already exists");
        }
    }

    public LabWork GetById(Guid id)
    {
        return !_labWorks.TryGetValue(id, out LabWork? lab) ? throw new Exception("Labwork with this id does not exist") : lab;
    }

    public IEnumerable<LabWork> GetAll()
    {
        return _labWorks.Values;
    }
}