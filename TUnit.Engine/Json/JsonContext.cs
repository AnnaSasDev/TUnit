﻿using System.Text.Json.Serialization;
using TUnit.Core;

namespace TUnit.Engine.Json;

[JsonSourceGenerationOptions(
    WriteIndented = true,
    IgnoreReadOnlyProperties = true,
    IgnoreReadOnlyFields = true,
    Converters = [ typeof(TypeJsonConverter), typeof(MethodInfoJsonConverter), typeof(JsonStringEnumConverter<Status>) ],
    GenerationMode = JsonSourceGenerationMode.Default)]
[JsonSerializable(typeof(TestSessionJson))]
[JsonSerializable(typeof(TestJson))]
[JsonSerializable(typeof(MethodInfoJsonConverter.SerializeableMethodInfo))]
internal partial class JsonContext : JsonSerializerContext;