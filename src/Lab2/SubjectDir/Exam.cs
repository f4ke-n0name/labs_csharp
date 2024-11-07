namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;

public class Exam : IAssessmentType
{
    public AssessmentResult Result => AssessmentResult.Exam;

    public double Points { get; }

    public Exam(double points)
    {
        if (points <= 0)
        {
            throw new ArgumentException("Points for exam must be > 0.");
        }

        Points = points;
    }
}