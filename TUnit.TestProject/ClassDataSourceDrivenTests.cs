using TUnit.TestProject.Dummy;

namespace TUnit.TestProject;

public class ClassDataSourceDrivenTests
{
    [Test]
    [ClassDataSource<SomeAsyncDisposableClass>]
    public void DataSource_Class(SomeAsyncDisposableClass value, SomeAsyncDisposableClass value2,
        SomeAsyncDisposableClass value3, SomeAsyncDisposableClass value4, SomeAsyncDisposableClass value5)
    {
        // Dummy method
    }

    [Test]
    [ClassDataSource<SomeAsyncDisposableClass>]
    public void DataSource_Class_Generic(SomeAsyncDisposableClass value)
    {
        // Dummy method
    }
}