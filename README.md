![](assets/banner.png) 

A modern, flexible and fast testing framework for C#. With Native AOT and Trimmed Single File application support included!

TUnit is designed to aid with all testing types:

- Unit
- Integration
- Acceptance
- and more!

[![thomhurst%2FTUnit | Trendshift](https://trendshift.io/api/badge/repositories/11781)](https://trendshift.io/repositories/11781)

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/a8231644d844435eb9fd15110ea771d8)](https://app.codacy.com/gh/thomhurst/TUnit?utm_source=github.com&utm_medium=referral&utm_content=thomhurst/TUnit&utm_campaign=Badge_Grade) ![GitHub Repo stars](https://img.shields.io/github/stars/thomhurst/TUnit) ![GitHub Issues or Pull Requests](https://img.shields.io/github/issues-closed-raw/thomhurst/TUnit)
 [![GitHub Sponsors](https://img.shields.io/github/sponsors/thomhurst)](https://github.com/sponsors/thomhurst) [![nuget](https://img.shields.io/nuget/v/TUnit.svg)](https://www.nuget.org/packages/TUnit/) [![NuGet Downloads](https://img.shields.io/nuget/dt/TUnit)](https://www.nuget.org/packages/TUnit/) ![GitHub Workflow Status (with event)](https://img.shields.io/github/actions/workflow/status/thomhurst/TUnit/dotnet.yml) ![GitHub last commit (branch)](https://img.shields.io/github/last-commit/thomhurst/TUnit/main) ![License](https://img.shields.io/github/license/thomhurst/TUnit)

# Quick Start

Assuming you have the .NET SDK installed, simply run:

`dotnet new install TUnit.Templates` 

`dotnet new TUnit -n "YourProjectName"`

A new test project will be created for you with some samples of different test types and tips. When you're ready to get going, delete them and create your own!

# Documentation

See here: <https://tunit.dev/>

# Modern and Fast

TUnit leverages source generators to locate and register your tests as opposed to reflection. You'll have a slight bump in build time, but a speedier runtime.

TUnit also builds upon the newer Microsoft.Testing.Platform, whereas most other frameworks you'll have used will use VSTest. The new platform was reconstructed from the ground up to address pain points, be more extensible, and be faster.

# Hooks, Events and Lifecycles

One of the most powerful parts of TUnit is the information you have available to you because of the source generation and the events you can subscribe to. Because tests are constructed at the point of discovery, and not at runtime, you know all your arguments, properties, etc. upfront.

You can then register to be notified about various events such as test registered (scheduled to run in this test session at some point in the future), test started, test finished, etc.

Say we injected an external object into our tests: By knowing how many tests are registered, we could count them up, and then on a test end event, we could decrease the count. When hitting 0, we know our object isn't going to be used by any other tests, so we can dispose of it. We know when we can handle the lifecycle, and this prevents it from living till the end of the test session where it could be hanging on to precious resources.

# Flexible Data Inputs

One popular feature of TUnit is the `[ClassDataSource<T>]` attribute - Allowing you to inject in classes to your tests with specific lifetimes, such as Per Test Session, or Per Test Class.
Or if you want to run a combination of lots of different inputs, you can use a `[MatrixDataSource]` and annotate your parameters with `[Matrix(...)`] values.

But guess what? Those features are built on top of a `DataSourceGenerator<T>` class - Which is exposed directly to you.
That means that that functionality can be extended greatly. If they didn't exist already, you could implement them yourself!

So if you've got creative or complex ways to generate new data, this gives you the flexibility to do it. 
You create a class which will end up being an attribute you place on your test - So your test classes remain simple and readable! 

# Built in Analyzers

TUnit tries to help you write your tests correctly with analyzers. If something isn't quite right, an analyzer should tell you what's wrong.

# IDE

TUnit is built on top of the newer Microsoft.Testing.Platform, as opposed to the older VSTest platform. Because the infrastructure behind the scenes is new and different, you may need to enable some settings. This should just be a one time thing.

## Visual Studio

Visual Studio is fully supported from 2022 17.13 onwards. The "Use testing platform server mode" option is not present from 2022 17.13 onwards.

For prior versions, the "Use testing platform server mode" option must be selected in Tools > Manage Preview Features.

![](/docs/static/img/visual-studio.png)

## Rider

Rider is supported. The [Enable Testing Platform support](https://www.jetbrains.com/help/rider/Reference__Options__Tools__Unit_Testing__VSTest.html) option must be selected in Settings > Build, Execution, Deployment > Unit Testing > VSTest.

![](/docs/static/img/rider.png)

# VS Code

Visual Studio Code is supported.

- Install the extension Name: [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)
- Go to the C# Dev Kit extension's settings
- Enable Dotnet > Test Window > Use Testing Platform Protocol

![](/docs/static/img/visual-studio-code.png)

## CLI

`dotnet` CLI - Fully supported. Tests should be runnable with `dotnet test`, `dotnet run`, `dotnet exec` or executing an executable directly. See the docs for more information!

# Packages

## TUnit.Core

To be used when you want to define re-useable components, such as a test library, but it wouldn't be run as its own test suite.

## TUnit.Engine

For test suites. This contains the test execution logic and test adapter. Only install this on actual test projects you intend to run, not class libraries.

## TUnit.Assertions

This is independent from the framework and can be used wherever - Even in other test frameworks. It is just an assertion library used to assert data is as you expect. It uses an asychronous syntax which may be different to other assertion libraries you may have used.

## TUnit

This is a helper package to combine the above 3 packages. If you just want a standard test app where you can write, run and assert tests, just install this!

## TUnit.Playwright

This provides you base classes, similarly to Microsoft.Playwright.NUnit or Microsoft.Playwright.MSTest, to automatically create and dispose of Playwright objects in tests, to make it easier for you to write tests without worrying about lifecycles or disposing. The base classes are named the same as the other libraries: `PageTest`, `ContextTest`, `BrowserTest`, and `PlaywrightTest`.

# Features

- Native AOT / Trimmed Single File application support
- Source generated tests
- Property injection
- Full async support
- Parallel by default, with mechanisms to:

  - Run specific tests completely on their own
  - Run specific tests not in parallel with other specific tests
  - Limit the parallel limit on a per-test, class or assembly level

- Tests can depend on other tests to form chains, useful for if one test depends on state from another action. While not recommended for unit tests, this can be useful in integration testing where state matters
- Easy to read assertions - though you're also free to use whichever assertion library you like
- Injectable test data via classes, methods, compile-time args, or matrices
- Hooks before and after: 

  - TestDiscover
  - TestSession
  - Assembly
  - Class
  - Test

- Designed to avoid common pitfalls such as leaky test states
- Dependency injection support ([See here](https://tunit.dev/docs/tutorial-advanced/dependency-injection))
- Ability to view and interrogate metadata and results from various assembly/class/test context objects

# Installation

`dotnet add package TUnit --prerelease`

# Example test

```csharp
    [Test]
    public async Task Create_User_Has_Expected_Creation_Time()
    {
        var user = await CreateUser();

        await Assert.That(user.CreatedAt)
            .IsEqualTo(DateTime.Now)
            .Within(TimeSpan.FromMinutes(1));
    }
```

or with more complex test orchestration needs

```csharp
    [Before(Class)]
    public static async Task ClearDatabase(ClassHookContext context) { ... }

    [After(Class)]
    public static async Task AssertDatabaseIsAsExpected(ClassHookContext context) { ... }

    [Before(Test)]
    public async Task CreatePlaywrightBrowser(TestContext context) { ... }

    [After(Test)]
    public async Task DisposePlaywrightBrowser(TestContext context) { ... }

    [Retry(3)]
    [Test, DisplayName("Register an account")]
    [MethodDataSource(nameof(GetAuthDetails))]
    public async Task Register(string username, string password) { ... }

    [Repeat(5)]
    [Test, DependsOn(nameof(Register))]
    [MethodDataSource(nameof(GetAuthDetails))]
    public async Task Login(string username, string password) { ... }

    [Test, DependsOn(nameof(Login), [typeof(string), typeof(string)])]
    [MethodDataSource(nameof(GetAuthDetails))]
    public async Task DeleteAccount(string username, string password) { ... }

    [Category("Downloads")]
    [Timeout(300_000)]
    [Test, NotInParallel(Order = 1)]
    public async Task DownloadFile1() { ... }

    [Category("Downloads")]
    [Timeout(300_000)]
    [Test, NotInParallel(Order = 2)]
    public async Task DownloadFile2() { ... }

    [Repeat(10)]
    [Test]
    [Arguments(1)]
    [Arguments(2)]
    [Arguments(3)]
    [DisplayName("Go to the page numbered $page")]
    public async Task GoToPage(int page) { ... }

    [Category("Cookies")]
    [Test, Skip("Not yet built!")]
    public async Task CheckCookies() { ... }

    [Test, Explicit, WindowsOnlyTest, RetryHttpServiceUnavailable(5)]
    [Property("Some Key", "Some Value")]
    public async Task Ping() { ... }

    [Test]
    [ParallelLimit<LoadTestParallelLimit>]
    [Repeat(1000)]
    public async Task LoadHomepage() { ... }

    public static IEnumerable<(string Username, string Password)> GetAuthDetails()
    {
        yield return ("user1", "password1");
        yield return ("user2", "password2");
        yield return ("user3", "password3");
    }

    public class WindowsOnlyTestAttribute : SkipAttribute
    {
        public WindowsOnlyTestAttribute() : base("Windows only test")
        {
        }

        public override Task<bool> ShouldSkip(TestContext testContext)
        {
            return Task.FromResult(!OperatingSystem.IsWindows());
        }
    }

    public class RetryHttpServiceUnavailableAttribute : RetryAttribute
    {
        public RetryHttpServiceUnavailableAttribute(int times) : base(times)
        {
        }

        public override Task<bool> ShouldRetry(TestInformation testInformation, Exception exception, int currentRetryCount)
        {
            return Task.FromResult(exception is HttpRequestException { StatusCode: HttpStatusCode.ServiceUnavailable });
        }
    }

    public class LoadTestParallelLimit : IParallelLimit
    {
        public int Limit => 50;
    }
```

# Motivations

TUnit is inspired by NUnit and xUnit - two of the most popular testing frameworks for .NET.

It aims to build upon the useful features of both while trying to address any pain points that they may have.

[Read more here](https://tunit.dev/docs/comparison/framework-differences)

# Prerelease

You'll notice that version 1.0 isn't out yet. While this framework is mostly feature complete, I'm waiting for a few things:

- Full Rider support for all features
- Full VS support for all features
- Open to feedback on existing features
- Open to ideas on new features

As such, the API may change. I'll try to limit this but it's a possibility.

# Benchmark

### Scenario: Building the test project

#### macos-latest

```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.7.5 (23H527) [Darwin 23.6.0]
Apple M1 (Virtual), 1 CPU, 3 logical and 3 physical cores
.NET SDK 9.0.300
  [Host]   : .NET 9.0.5 (9.0.525.21509), Arm64 RyuJIT AdvSIMD
  .NET 9.0 : .NET 9.0.5 (9.0.525.21509), Arm64 RyuJIT AdvSIMD

Job=.NET 9.0  Runtime=.NET 9.0  

```
| Method       | Mean     | Error    | StdDev   |
|------------- |---------:|---------:|---------:|
| Build_TUnit  | 973.4 ms | 17.69 ms | 36.14 ms |
| Build_NUnit  | 784.0 ms | 15.58 ms | 19.70 ms |
| Build_xUnit  | 775.8 ms | 10.61 ms |  9.41 ms |
| Build_MSTest | 832.8 ms | 14.69 ms | 15.09 ms |



#### ubuntu-latest

```

BenchmarkDotNet v0.14.0, Ubuntu 24.04.2 LTS (Noble Numbat)
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.300
  [Host]   : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2
  .NET 9.0 : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2

Job=.NET 9.0  Runtime=.NET 9.0  

```
| Method       | Mean    | Error    | StdDev   |
|------------- |--------:|---------:|---------:|
| Build_TUnit  | 1.864 s | 0.0357 s | 0.0298 s |
| Build_NUnit  | 1.414 s | 0.0118 s | 0.0105 s |
| Build_xUnit  | 1.428 s | 0.0169 s | 0.0150 s |
| Build_MSTest | 1.452 s | 0.0103 s | 0.0097 s |



#### windows-latest

```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.20348.3561) (Hyper-V)
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.300
  [Host]   : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2
  .NET 9.0 : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2

Job=.NET 9.0  Runtime=.NET 9.0  

```
| Method       | Mean    | Error    | StdDev   |
|------------- |--------:|---------:|---------:|
| Build_TUnit  | 1.876 s | 0.0316 s | 0.0422 s |
| Build_NUnit  | 1.448 s | 0.0283 s | 0.0251 s |
| Build_xUnit  | 1.460 s | 0.0218 s | 0.0204 s |
| Build_MSTest | 1.493 s | 0.0212 s | 0.0198 s |


### Scenario: A single test that completes instantly (including spawning a new process and initialising the test framework)

#### macos-latest

```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.7.5 (23H527) [Darwin 23.6.0]
Apple M1 (Virtual), 1 CPU, 3 logical and 3 physical cores
.NET SDK 9.0.300
  [Host]   : .NET 9.0.5 (9.0.525.21509), Arm64 RyuJIT AdvSIMD
  .NET 9.0 : .NET 9.0.5 (9.0.525.21509), Arm64 RyuJIT AdvSIMD

Job=.NET 9.0  Runtime=.NET 9.0  

```
| Method    | Mean      | Error     | StdDev    | Median    |
|---------- |----------:|----------:|----------:|----------:|
| TUnit_AOT |  70.95 ms |  0.222 ms |  0.173 ms |  70.91 ms |
| TUnit     | 477.97 ms |  5.963 ms |  5.286 ms | 475.96 ms |
| NUnit     | 712.60 ms | 13.906 ms | 27.449 ms | 700.25 ms |
| xUnit     | 712.71 ms |  5.913 ms |  5.242 ms | 713.85 ms |
| MSTest    | 622.85 ms | 11.477 ms | 10.736 ms | 623.13 ms |



#### ubuntu-latest

```

BenchmarkDotNet v0.14.0, Ubuntu 24.04.2 LTS (Noble Numbat)
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.300
  [Host]   : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2
  .NET 9.0 : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2

Job=.NET 9.0  Runtime=.NET 9.0  

```
| Method    | Mean        | Error     | StdDev    |
|---------- |------------:|----------:|----------:|
| TUnit_AOT |    25.36 ms |  0.552 ms |  1.627 ms |
| TUnit     |   820.04 ms | 16.083 ms | 20.912 ms |
| NUnit     | 1,289.73 ms | 11.584 ms | 10.836 ms |
| xUnit     | 1,332.47 ms |  8.187 ms |  7.258 ms |
| MSTest    | 1,129.05 ms | 10.714 ms | 10.022 ms |



#### windows-latest

```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.20348.3561) (Hyper-V)
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.300
  [Host]   : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2
  .NET 9.0 : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2

Job=.NET 9.0  Runtime=.NET 9.0  

```
| Method    | Mean        | Error     | StdDev    | Median      |
|---------- |------------:|----------:|----------:|------------:|
| TUnit_AOT |    56.95 ms |  2.251 ms |  6.602 ms |    54.83 ms |
| TUnit     |   865.60 ms | 17.244 ms | 25.809 ms |   871.86 ms |
| NUnit     | 1,299.09 ms | 11.689 ms | 10.362 ms | 1,301.01 ms |
| xUnit     | 1,355.48 ms | 15.108 ms | 13.393 ms | 1,354.27 ms |
| MSTest    | 1,158.75 ms | 22.111 ms | 19.601 ms | 1,163.47 ms |


### Scenario: A test that takes 50ms to execute, repeated 100 times (including spawning a new process and initialising the test framework)

#### macos-latest

```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.7.5 (23H527) [Darwin 23.6.0]
Apple M1 (Virtual), 1 CPU, 3 logical and 3 physical cores
.NET SDK 9.0.300
  [Host]   : .NET 9.0.5 (9.0.525.21509), Arm64 RyuJIT AdvSIMD
  .NET 9.0 : .NET 9.0.5 (9.0.525.21509), Arm64 RyuJIT AdvSIMD

Job=.NET 9.0  Runtime=.NET 9.0  

```
| Method    | Mean        | Error     | StdDev    |
|---------- |------------:|----------:|----------:|
| TUnit_AOT |    247.4 ms |  13.46 ms |  39.69 ms |
| TUnit     |    623.6 ms |  22.23 ms |  65.55 ms |
| NUnit     | 14,064.0 ms | 278.38 ms | 352.07 ms |
| xUnit     | 14,460.0 ms | 283.04 ms | 531.61 ms |
| MSTest    | 14,157.2 ms | 273.68 ms | 527.29 ms |



#### ubuntu-latest

```

BenchmarkDotNet v0.14.0, Ubuntu 24.04.2 LTS (Noble Numbat)
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.300
  [Host]   : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2
  .NET 9.0 : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2

Job=.NET 9.0  Runtime=.NET 9.0  

```
| Method    | Mean        | Error     | StdDev    |
|---------- |------------:|----------:|----------:|
| TUnit_AOT |    75.20 ms |  1.476 ms |  1.699 ms |
| TUnit     |   891.82 ms | 17.148 ms | 19.748 ms |
| NUnit     | 6,289.32 ms | 12.419 ms | 10.370 ms |
| xUnit     | 6,436.98 ms | 19.657 ms | 18.387 ms |
| MSTest    | 6,279.21 ms |  9.354 ms |  8.292 ms |



#### windows-latest

```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.20348.3561) (Hyper-V)
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.300
  [Host]   : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2
  .NET 9.0 : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2

Job=.NET 9.0  Runtime=.NET 9.0  

```
| Method    | Mean       | Error    | StdDev   | Median     |
|---------- |-----------:|---------:|---------:|-----------:|
| TUnit_AOT |   112.7 ms |  2.23 ms |  4.30 ms |   110.3 ms |
| TUnit     |   935.7 ms | 18.26 ms | 26.18 ms |   936.8 ms |
| NUnit     | 7,498.6 ms | 13.79 ms | 12.22 ms | 7,502.0 ms |
| xUnit     | 7,556.5 ms | 13.02 ms | 12.18 ms | 7,559.6 ms |
| MSTest    | 7,452.4 ms | 14.61 ms | 13.66 ms | 7,450.7 ms |



