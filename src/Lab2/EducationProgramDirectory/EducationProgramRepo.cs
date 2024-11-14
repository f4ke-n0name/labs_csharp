namespace Itmo.ObjectOrientedProgramming.Lab2.EducationProgramDirectory;

public class EducationProgramRepo
{
    private readonly Dictionary<Guid, EducationProgram> _educationPrograms = new();

    public void Add(EducationProgram item)
    {
        ArgumentNullException.ThrowIfNull(item);

        bool addedCorrectly = _educationPrograms.TryAdd(item.Id, item);
        if (!addedCorrectly)
        {
            throw new ArgumentException("Education program currently exists.", nameof(item));
        }
    }

    public EducationProgram GetById(Guid id)
    {
        if (_educationPrograms.TryGetValue(id, out EducationProgram? educationProgram))
        {
            return educationProgram;
        }

        throw new KeyNotFoundException("Education program not found.");
    }

    public IEnumerable<EducationProgram> GetAll()
    {
        return _educationPrograms.Values;
    }
}