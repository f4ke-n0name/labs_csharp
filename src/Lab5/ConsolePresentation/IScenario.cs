﻿namespace ConsolePresentation;

public interface IScenario
{
    string Name { get; }

    Task Run();
}