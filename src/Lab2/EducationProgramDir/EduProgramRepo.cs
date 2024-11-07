namespace Itmo.ObjectOrientedProgramming.Lab2.EducationProgramDir;

public class EduProgramRepo
{
    private readonly Dictionary<Guid, EduProgram> _educationPrograms = new();

    public void Add(EduProgram item)
    {
        ArgumentNullException.ThrowIfNull(item);

        bool addedCorrectly = _educationPrograms.TryAdd(item.Id, item);
        if (!addedCorrectly)
        {
            throw new ArgumentException("Education program currently exists.", nameof(item));
        }
    }

    public EduProgram GetById(Guid id)
    {
        if (_educationPrograms.TryGetValue(id, out EduProgram? educationProgram))
        {
            return educationProgram;
        }

        throw new KeyNotFoundException("Education program not found.");
    }

    public IEnumerable<EduProgram> GetAll()
    {
        return _educationPrograms.Values;
    }
}