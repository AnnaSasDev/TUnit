﻿using System.Reflection;

namespace TUnit.Core.Data;

internal static class AttributeCache
{
    public static readonly GetOnlyDictionary<Type, Attribute[]> Types = new();
    public static readonly GetOnlyDictionary<Assembly, Attribute[]> Assemblies = new();
}