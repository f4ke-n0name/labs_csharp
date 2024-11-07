namespace Itmo.ObjectOrientedProgramming.Lab2.LectureDir;

public class Lecture : IPrototype<Lecture>
{
    public static User? DefaultAuthor { get; }

    public Guid LectureId { get; }

    public Guid? BaseLectureId { get; private set; }

    public string LectureName { get; private set; }

    public string LectureDescription { get; private set; }

    public string LectureContent { get; private set; }

    public User Author { get; }

    public Lecture(string name, string description, string content, User author, Guid? baseLectureId = null)
    {
        if (DefaultAuthor == null && author == null)
        {
            throw new Exception("Default author must be set before creating lectures, or an author must be provided.");
        }

        LectureId = Guid.NewGuid();
        LectureName = name;
        LectureDescription = description;
        LectureContent = content;
        Author = author;
        BaseLectureId = baseLectureId;
    }

    public Lecture Clone()
    {
        return Author != null
            ? new Lecture(
                LectureName,
                LectureDescription,
                LectureContent,
                Author,
                LectureId)
            : throw new Exception("No author found.");
    }

    public void ChangeName(string newName, Guid authorId)
    {
        if (Author.GetUserId() != authorId)
        {
            throw new Exception("Only author can modify lecture materials.");
        }

        LectureName = newName;
    }

    public void ChangeDescription(string newDescription, Guid authorId)
    {
        if (Author.GetUserId() != authorId)
        {
            throw new Exception("Only author can modify lecture materials.");
        }

        LectureDescription = newDescription;
    }

    public void ChangeContent(string newContent, Guid authorId)
    {
        if (Author.GetUserId() != authorId)
        {
            throw new Exception("Only author can modify lecture materials.");
        }

        LectureContent = newContent;
    }
}