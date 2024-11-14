namespace Itmo.ObjectOrientedProgramming.Lab2.LectureDirectory;

public interface IPrototype<out T>
{
     T Clone();
}