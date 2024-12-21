using System.Diagnostics.CodeAnalysis;

namespace ConsolePresentation;

public interface IScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}