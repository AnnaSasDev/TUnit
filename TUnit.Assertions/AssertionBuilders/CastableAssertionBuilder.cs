﻿using System.Runtime.CompilerServices;

namespace TUnit.Assertions.AssertionBuilders;

public class CastableAssertionBuilder<TActual, TExpected> : InvokableValueAssertionBuilder<TExpected>
{
    private readonly Func<AssertionData, TExpected?> _mapper;

    internal CastableAssertionBuilder(InvokableAssertionBuilder<TActual> assertionBuilder) : base(assertionBuilder)
    {
        _mapper = DefaultMapper;
    }

    internal CastableAssertionBuilder(InvokableAssertionBuilder<TActual> assertionBuilder, Func<AssertionData, TExpected?> mapper) : base(assertionBuilder)
    {
        _mapper = mapper;
    }

    public new TaskAwaiter<TExpected?> GetAwaiter()
    {
        return AssertType().GetAwaiter();
    }

    private static TExpected? DefaultMapper(AssertionData data)
    {
        try
        {
            return (TExpected?)data.Result;
        }
        catch
        {
            return default;
        }
    }

    private async Task<TExpected?> AssertType()
    {
        var data = await ProcessAssertionsAsync();
        return _mapper(data);
    }
}