using FsCheck;
using TUnit.Assertions;
using TUnit.Assertions.Extensions;
using TUnit.FsCheck;

namespace TUnit.TestProject;

public class FsCheckTests
{
    [Test]
    [Data]
    public async Task FsCheckTest(string data)
    {
        await Assert.That(data).IsNotNull()
            .And.DoesNotContain('A')
            .And.DoesNotContain('a');
    }
    
    public class DataAttribute : FsCheckAttribute<string>
    {
        protected override Arbitrary<string> CreateGenerator(DataGeneratorMetadata dataGeneratorMetadata)
        {
            return Arb.Default.String();
        }
        
        protected override int SampleSize => 5;
    }
}