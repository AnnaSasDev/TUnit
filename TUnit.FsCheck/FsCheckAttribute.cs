using FsCheck;
using TUnit.Core;
using TUnit.Core.Enums;
using TUnit.Core.Interfaces;
using TUnit.Engine.Extensions;

namespace TUnit.FsCheck;

public abstract class FsCheckAttribute<T> : DataSourceGeneratorAttribute<T>, ITestEndEventReceiver
{
    private DataGeneratorMetadata _dataGeneratorMetadata;
    
    public Arbitrary<T>? Arbitrary => field ??= CreateGenerator(_dataGeneratorMetadata);

    public override IEnumerable<Func<T>> GenerateDataSources(DataGeneratorMetadata dataGeneratorMetadata)
    {
        _dataGeneratorMetadata = dataGeneratorMetadata;
        
        foreach (var data in Arbitrary!.Generator.Sample(50, SampleSize))
        {
            yield return () => data;
        }
    }
    
    protected abstract Arbitrary<T> CreateGenerator(DataGeneratorMetadata dataGeneratorMetadata);
    protected virtual int SampleSize => 100;
    
    public async ValueTask OnTestEnd(TestContext testContext)
    {
        if (testContext.Result?.Status is not Status.Failed)
        {
            return;
        }
        
        var args = testContext.TestDetails.TestMethodArguments ?? [];
        
        var t = args.OfType<T>().First();
        
        var shrinkValues = Arbitrary!.Shrinker(t).ToArray();

        if (shrinkValues.Any())
        {
            testContext.SuppressReportingResult();
        }
        
        foreach (var shrinkT in shrinkValues)
        {
#pragma warning disable WIP
            await testContext.ReregisterTestWithArguments([shrinkT]);;
#pragma warning restore WIP
        }
    }

    public int Order => 0;
}