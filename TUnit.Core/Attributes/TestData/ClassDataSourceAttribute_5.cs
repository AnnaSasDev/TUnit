﻿using System.Diagnostics.CodeAnalysis;
using TUnit.Core.Interfaces;

namespace TUnit.Core;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
public sealed class ClassDataSourceAttribute<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T1, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T2, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T3, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T4, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T5> : DataSourceGeneratorAttribute<T1, T2, T3, T4, T5>, ITestRegisteredEvents, ITestStartEvent, ITestEndEvent, ILastTestInClassEvent, ILastTestInAssemblyEvent 
    where T1 : new()
    where T2 : new()
    where T3 : new()
    where T4 : new()
    where T5 : new()
{
    private DataGeneratorMetadata? _dataGeneratorMetadata;
    
    public SharedType[] Shared { get; set; } = [SharedType.None, SharedType.None, SharedType.None, SharedType.None, SharedType.None];
    public string[] Keys { get; set; } = [string.Empty, string.Empty, string.Empty, string.Empty, string.Empty];

    private
    (
        (T1 T, SharedType SharedType, string Key),
        (T2 T, SharedType SharedType, string Key),
        (T3 T, SharedType SharedType, string Key),
        (T4 T, SharedType SharedType, string Key),
        (T5 T, SharedType SharedType, string Key)
    ) _itemsWithMetadata;
    
    public override IEnumerable<(T1, T2, T3, T4, T5)> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        _dataGeneratorMetadata = dataGeneratorMetadata;

        _itemsWithMetadata = (
            ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).GetItemForIndex<T1>(0, dataGeneratorMetadata.TestClassType, Shared, Keys),
            ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).GetItemForIndex<T2>(1, dataGeneratorMetadata.TestClassType, Shared, Keys),
            ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).GetItemForIndex<T3>(2, dataGeneratorMetadata.TestClassType, Shared, Keys),
            ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).GetItemForIndex<T4>(3, dataGeneratorMetadata.TestClassType, Shared, Keys),
            ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).GetItemForIndex<T5>(4, dataGeneratorMetadata.TestClassType, Shared, Keys)
        );

        yield return 
        (
            _itemsWithMetadata.Item1.T,
            _itemsWithMetadata.Item2.T,
            _itemsWithMetadata.Item3.T,
            _itemsWithMetadata.Item4.T,
            _itemsWithMetadata.Item5.T
        );
    }

    public async ValueTask OnTestRegistered(TestRegisterContext testRegisterContext)
    {
        var testContext = testRegisterContext.TestContext;

        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).OnTestRegistered(
            testContext,
            _dataGeneratorMetadata?.PropertyInfo?.GetAccessors()[0].IsStatic == true,
            _itemsWithMetadata.Item1.SharedType,
            _itemsWithMetadata.Item1.Key,
            _itemsWithMetadata.Item1.T);
        
        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).OnTestRegistered(
            testContext,
            _dataGeneratorMetadata?.PropertyInfo?.GetAccessors()[0].IsStatic == true,
            _itemsWithMetadata.Item2.SharedType,
            _itemsWithMetadata.Item2.Key,
            _itemsWithMetadata.Item2.T);
        
        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).OnTestRegistered(
            testContext,
            _dataGeneratorMetadata?.PropertyInfo?.GetAccessors()[0].IsStatic == true,
            _itemsWithMetadata.Item3.SharedType,
            _itemsWithMetadata.Item3.Key,
            _itemsWithMetadata.Item3.T);
        
        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).OnTestRegistered(
            testContext,
            _dataGeneratorMetadata?.PropertyInfo?.GetAccessors()[0].IsStatic == true,
            _itemsWithMetadata.Item4.SharedType,
            _itemsWithMetadata.Item4.Key,
            _itemsWithMetadata.Item4.T);
        
        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).OnTestRegistered(
            testContext,
            _dataGeneratorMetadata?.PropertyInfo?.GetAccessors()[0].IsStatic == true,
            _itemsWithMetadata.Item5.SharedType,
            _itemsWithMetadata.Item5.Key,
            _itemsWithMetadata.Item5.T);
    }

    public async ValueTask OnTestStart(BeforeTestContext beforeTestContext)
    {
        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).OnTestStart(
            beforeTestContext,
            _dataGeneratorMetadata?.PropertyInfo?.GetAccessors()[0].IsStatic == true,
            _itemsWithMetadata.Item1.SharedType,
            _itemsWithMetadata.Item1.Key,
            _itemsWithMetadata.Item1.Key);
        
        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).OnTestStart(
            beforeTestContext,
            _dataGeneratorMetadata?.PropertyInfo?.GetAccessors()[0].IsStatic == true,
            _itemsWithMetadata.Item2.SharedType,
            _itemsWithMetadata.Item2.Key,
            _itemsWithMetadata.Item2.Key);
        
        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).OnTestStart(
            beforeTestContext,
            _dataGeneratorMetadata?.PropertyInfo?.GetAccessors()[0].IsStatic == true,
            _itemsWithMetadata.Item3.SharedType,
            _itemsWithMetadata.Item3.Key,
            _itemsWithMetadata.Item3.Key);
        
        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).OnTestStart(
            beforeTestContext,
            _dataGeneratorMetadata?.PropertyInfo?.GetAccessors()[0].IsStatic == true,
            _itemsWithMetadata.Item4.SharedType,
            _itemsWithMetadata.Item4.Key,
            _itemsWithMetadata.Item4.Key);
        
        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).OnTestStart(
            beforeTestContext,
            _dataGeneratorMetadata?.PropertyInfo?.GetAccessors()[0].IsStatic == true,
            _itemsWithMetadata.Item5.SharedType,
            _itemsWithMetadata.Item5.Key,
            _itemsWithMetadata.Item5.Key);
    }

    public async ValueTask OnTestEnd(TestContext testContext)
    {
        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).OnTestEnd(
            _itemsWithMetadata.Item1.SharedType,
            _itemsWithMetadata.Item1.Key,
            _itemsWithMetadata.Item1.T);

        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).OnTestEnd(
            _itemsWithMetadata.Item2.SharedType,
            _itemsWithMetadata.Item2.Key,
            _itemsWithMetadata.Item2.T);
        
        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).OnTestEnd(
            _itemsWithMetadata.Item3.SharedType,
            _itemsWithMetadata.Item3.Key,
            _itemsWithMetadata.Item3.T);
        
        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).OnTestEnd(
            _itemsWithMetadata.Item4.SharedType,
            _itemsWithMetadata.Item4.Key,
            _itemsWithMetadata.Item4.T);
        
        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).OnTestEnd(
            _itemsWithMetadata.Item5.SharedType,
            _itemsWithMetadata.Item5.Key,
            _itemsWithMetadata.Item5.T);
    }

    public async ValueTask IfLastTestInClass(ClassHookContext context, TestContext testContext)
    {
        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).IfLastTestInClass<T1>(_itemsWithMetadata.Item1.SharedType);
        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).IfLastTestInClass<T2>(_itemsWithMetadata.Item2.SharedType);
        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).IfLastTestInClass<T3>(_itemsWithMetadata.Item3.SharedType);
        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).IfLastTestInClass<T4>(_itemsWithMetadata.Item4.SharedType);
        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).IfLastTestInClass<T5>(_itemsWithMetadata.Item5.SharedType);
    }

    public async ValueTask IfLastTestInAssembly(AssemblyHookContext context, TestContext testContext)
    {
        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).IfLastTestInAssembly<T1>(_itemsWithMetadata.Item1.SharedType);
        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).IfLastTestInAssembly<T2>(_itemsWithMetadata.Item2.SharedType);
        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).IfLastTestInAssembly<T3>(_itemsWithMetadata.Item3.SharedType);
        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).IfLastTestInAssembly<T4>(_itemsWithMetadata.Item4.SharedType);
        await ClassDataSources.Get(_dataGeneratorMetadata!.TestSessionId).IfLastTestInAssembly<T5>(_itemsWithMetadata.Item5.SharedType);
    }
}