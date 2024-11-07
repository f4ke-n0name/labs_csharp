namespace Itmo.ObjectOrientedProgramming.Lab2.LectureDir;

public interface IPrototype<out T>
{
     T Clone();
}