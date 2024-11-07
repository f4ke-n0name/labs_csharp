namespace Itmo.ObjectOrientedProgramming.Lab2.SubjectDir;

public class Credit : IAssessmentType
{
    public AssessmentResult Result => AssessmentResult.Credit;

    public double MinPoints { get; }

    public Credit(double minPoints)
    {
        if (minPoints is <= 0 or > 100)
        {
            throw new ArgumentException("Minimum points for pass must be between 0 and 100.");
        }

        MinPoints = minPoints;
    }
}