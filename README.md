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

BenchmarkDotNet v0.14.0, macOS Sonoma 14.7.6 (23H626) [Darwin 23.6.0]
Apple M1 (Virtual), 1 CPU, 3 logical and 3 physical cores
.NET SDK 9.0.303
  [Host]   : .NET 9.0.7 (9.0.725.31616), Arm64 RyuJIT AdvSIMD
  .NET 9.0 : .NET 9.0.7 (9.0.725.31616), Arm64 RyuJIT AdvSIMD

Job=.NET 9.0  Runtime=.NET 9.0  

```
| Method       | Mean    | Error    | StdDev   |
|------------- |--------:|---------:|---------:|
| Build_TUnit  | 1.372 s | 0.0642 s | 0.1873 s |
| Build_NUnit  | 1.164 s | 0.0483 s | 0.1402 s |
| Build_xUnit  | 1.344 s | 0.0634 s | 0.1870 s |
| Build_MSTest | 1.575 s | 0.0811 s | 0.2341 s |



#### ubuntu-latest

```

BenchmarkDotNet v0.14.0, Ubuntu 24.04.2 LTS (Noble Numbat)
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.303
  [Host]   : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX2
  .NET 9.0 : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX2

Job=.NET 9.0  Runtime=.NET 9.0  

```
| Method       | Mean    | Error    | StdDev   |
|------------- |--------:|---------:|---------:|
| Build_TUnit  | 1.944 s | 0.0371 s | 0.0310 s |
| Build_NUnit  | 1.479 s | 0.0156 s | 0.0130 s |
| Build_xUnit  | 1.505 s | 0.0177 s | 0.0157 s |
| Build_MSTest | 1.513 s | 0.0154 s | 0.0136 s |



#### windows-latest

```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.20348.3932) (Hyper-V)
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.303
  [Host]   : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX2
  .NET 9.0 : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX2

Job=.NET 9.0  Runtime=.NET 9.0  

```
| Method       | Mean    | Error    | StdDev   |
|------------- |--------:|---------:|---------:|
| Build_TUnit  | 1.933 s | 0.0339 s | 0.0363 s |
| Build_NUnit  | 1.511 s | 0.0249 s | 0.0233 s |
| Build_xUnit  | 1.510 s | 0.0166 s | 0.0155 s |
| Build_MSTest | 1.561 s | 0.0297 s | 0.0278 s |


### Scenario: A single test that completes instantly (including spawning a new process and initialising the test framework)

#### macos-latest

```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.7.6 (23H626) [Darwin 23.6.0]
Apple M1 (Virtual), 1 CPU, 3 logical and 3 physical cores
.NET SDK 9.0.303
  [Host]   : .NET 9.0.7 (9.0.725.31616), Arm64 RyuJIT AdvSIMD
  .NET 9.0 : .NET 9.0.7 (9.0.725.31616), Arm64 RyuJIT AdvSIMD

Job=.NET 9.0  Runtime=.NET 9.0  

```
| Method    | Mean       | Error    | StdDev    | Median     |
|---------- |-----------:|---------:|----------:|-----------:|
| TUnit_AOT |   142.6 ms | 17.25 ms |  50.86 ms |   126.7 ms |
| TUnit     |   989.4 ms | 62.33 ms | 180.82 ms |   981.5 ms |
| NUnit     | 1,217.3 ms | 76.35 ms | 225.12 ms | 1,180.6 ms |
| xUnit     |   986.1 ms | 61.29 ms | 175.86 ms |   960.9 ms |
| MSTest    |   874.6 ms | 38.37 ms | 108.84 ms |   861.8 ms |



#### ubuntu-latest

```

BenchmarkDotNet v0.14.0, Ubuntu 24.04.2 LTS (Noble Numbat)
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.303
  [Host]   : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX2
  .NET 9.0 : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX2

Job=.NET 9.0  Runtime=.NET 9.0  

```
| Method    | Mean        | Error     | StdDev    | Median      |
|---------- |------------:|----------:|----------:|------------:|
| TUnit_AOT |    28.24 ms |  1.016 ms |  2.997 ms |    28.41 ms |
| TUnit     |   798.43 ms | 15.806 ms | 21.635 ms |   784.57 ms |
| NUnit     | 1,247.46 ms |  5.845 ms |  5.181 ms | 1,246.12 ms |
| xUnit     | 1,305.52 ms |  8.389 ms |  7.847 ms | 1,304.58 ms |
| MSTest    | 1,103.30 ms |  7.703 ms |  7.205 ms | 1,104.34 ms |



#### windows-latest

```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.20348.3932) (Hyper-V)
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.303
  [Host]   : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX2
  .NET 9.0 : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX2

Job=.NET 9.0  Runtime=.NET 9.0  

```
| Method    | Mean        | Error     | StdDev    |
|---------- |------------:|----------:|----------:|
| TUnit_AOT |    78.00 ms |  0.244 ms |  0.203 ms |
| TUnit     |   881.64 ms | 17.086 ms | 27.101 ms |
| NUnit     | 1,355.08 ms | 13.352 ms | 11.836 ms |
| xUnit     | 1,395.12 ms | 18.940 ms | 17.717 ms |
| MSTest    | 1,199.26 ms | 16.177 ms | 15.132 ms |


### Scenario: A test that takes 50ms to execute, repeated 100 times (including spawning a new process and initialising the test framework)

#### macos-latest

```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.7.6 (23H626) [Darwin 23.6.0]
Apple M1 (Virtual), 1 CPU, 3 logical and 3 physical cores
.NET SDK 9.0.303
  [Host]   : .NET 9.0.7 (9.0.725.31616), Arm64 RyuJIT AdvSIMD
  .NET 9.0 : .NET 9.0.7 (9.0.725.31616), Arm64 RyuJIT AdvSIMD

Job=.NET 9.0  Runtime=.NET 9.0  

```
| Method    | Mean        | Error     | StdDev    |
|---------- |------------:|----------:|----------:|
| TUnit_AOT |    210.5 ms |   8.87 ms |  26.15 ms |
| TUnit     |    990.9 ms |  64.79 ms | 190.02 ms |
| NUnit     | 13,259.5 ms | 263.60 ms | 605.67 ms |
| xUnit     | 13,634.6 ms | 269.91 ms | 603.69 ms |
| MSTest    | 13,819.4 ms | 270.97 ms | 617.14 ms |



#### ubuntu-latest

```

BenchmarkDotNet v0.14.0, Ubuntu 24.04.2 LTS (Noble Numbat)
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.303
  [Host]   : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX2
  .NET 9.0 : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX2

Job=.NET 9.0  Runtime=.NET 9.0  

```
| Method    | Mean        | Error     | StdDev    |
|---------- |------------:|----------:|----------:|
| TUnit_AOT |    74.89 ms |  1.133 ms |  0.946 ms |
| TUnit     |   911.09 ms | 17.849 ms | 21.921 ms |
| NUnit     | 6,289.16 ms | 12.614 ms | 11.182 ms |
| xUnit     | 6,442.49 ms | 15.277 ms | 14.290 ms |
| MSTest    | 6,272.21 ms | 15.239 ms | 14.254 ms |



#### windows-latest

```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.20348.3932) (Hyper-V)
AMD EPYC 7763, 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.303
  [Host]   : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX2
  .NET 9.0 : .NET 9.0.7 (9.0.725.31616), X64 RyuJIT AVX2

Job=.NET 9.0  Runtime=.NET 9.0  

```
| Method    | Mean       | Error    | StdDev   | Median     |
|---------- |-----------:|---------:|---------:|-----------:|
| TUnit_AOT |   112.3 ms |  2.24 ms |  4.26 ms |   109.4 ms |
| TUnit     |   957.9 ms | 18.94 ms | 19.45 ms |   957.2 ms |
| NUnit     | 7,528.5 ms | 30.97 ms | 27.46 ms | 7,526.0 ms |
| xUnit     | 7,584.8 ms | 22.66 ms | 21.20 ms | 7,589.1 ms |
| MSTest    | 7,463.1 ms | 29.14 ms | 27.26 ms | 7,474.0 ms |



