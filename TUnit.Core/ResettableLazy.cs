﻿using System.Diagnostics.CodeAnalysis;

namespace TUnit.Core;

public class ResettableLazy<
#if NET8_0_OR_GREATER
[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] 
#endif
    T>
{
    private readonly Func<T> _factory;

    private Lazy<T> _lazy;

    public T Value => _lazy.Value;

    public ResettableLazy(Func<T> factory)
    {
        _factory = factory;
        _lazy = new Lazy<T>(factory);
    }

    public void ResetLazy()
    {
        _lazy = new Lazy<T>(_factory);
    }
}