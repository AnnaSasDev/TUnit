﻿namespace TUnit.Core;

internal record TUnitTestResult
{
    public required TestDetails TestDetails { get; init; }
    public required Status Status { get; init; }
    public required DateTimeOffset Start { get; init; }
    public required DateTimeOffset End { get; init; }
    public required TimeSpan Duration { get; init; }
    public required Exception? Exception { get; init; }
    public required string ComputerName { get; init; }
};