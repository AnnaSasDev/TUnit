using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing;
using System.Diagnostics.CodeAnalysis;
using TUnit.Assertions.AssertionBuilders;
using TUnit.Core;

namespace TUnit.Assertions.Analyzers.Tests.Verifiers;

public static partial class CSharpCodeFixVerifier<TAnalyzer, TCodeFix>
    where TAnalyzer : DiagnosticAnalyzer, new()
    where TCodeFix : CodeFixProvider, new()
{
    /// <inheritdoc cref="Microsoft.CodeAnalysis.Diagnostic"/>
    public static DiagnosticResult Diagnostic()
        => CSharpCodeFixVerifier<TAnalyzer, TCodeFix, DefaultVerifier>.Diagnostic();

    /// <inheritdoc cref="Microsoft.CodeAnalysis.Diagnostic"/>
    public static DiagnosticResult Diagnostic(string diagnosticId)
        => CSharpCodeFixVerifier<TAnalyzer, TCodeFix, DefaultVerifier>.Diagnostic(diagnosticId);

    /// <inheritdoc cref="Microsoft.CodeAnalysis.Diagnostic"/>
    public static DiagnosticResult Diagnostic(DiagnosticDescriptor descriptor)
        => CSharpCodeFixVerifier<TAnalyzer, TCodeFix, DefaultVerifier>.Diagnostic(descriptor);

    public static async Task VerifyAnalyzerAsync(
        [StringSyntax("c#-test")] string source,
        params DiagnosticResult[] expected
    )
    {
        var test = new Test
        {
            TestCode = source,
            CodeActionValidationMode = CodeActionValidationMode.SemanticStructure,
            ReferenceAssemblies = ReferenceAssemblies.Net.Net90
                .AddPackages([new PackageIdentity("xunit.v3.assert", "2.0.0")]),
            TestState =
            {
                AdditionalReferences =
                {
                    typeof(TUnitAttribute).Assembly.Location,
                    typeof(AssertionBuilder).Assembly.Location,
                },
            },
        };

        test.ExpectedDiagnostics.AddRange(expected);
        await test.RunAsync(CancellationToken.None);
    }

    /// <inheritdoc cref="CodeFixVerifier{TAnalyzer, TCodeFix, TTest, TVerifier}.VerifyCodeFixAsync(string, string)"/>
    public static async Task VerifyCodeFixAsync([StringSyntax("c#-test")] string source, [StringSyntax("c#-test")] string fixedSource)
        => await VerifyCodeFixAsync(source, DiagnosticResult.EmptyDiagnosticResults, fixedSource);

    /// <inheritdoc cref="CodeFixVerifier{TAnalyzer, TCodeFix, TTest, TVerifier}.VerifyCodeFixAsync(string, DiagnosticResult, string)"/>
    public static async Task VerifyCodeFixAsync([StringSyntax("c#-test")] string source, DiagnosticResult expected, [StringSyntax("c#-test")] string fixedSource)
        => await VerifyCodeFixAsync(source, [expected], fixedSource);

    /// <inheritdoc cref="CodeFixVerifier{TAnalyzer, TCodeFix, TTest, TVerifier}.VerifyCodeFixAsync(string, DiagnosticResult[], string)"/>
    public static async Task VerifyCodeFixAsync(
        [StringSyntax("c#-test")] string source,
        IEnumerable<DiagnosticResult> expected,
        [StringSyntax("c#-test")] string fixedSource
    )
    {
        var test = new Test
        {
            TestCode = source,
            FixedCode = fixedSource,
            ReferenceAssemblies = ReferenceAssemblies.Net.Net90,
            TestState =
            {
                AdditionalReferences =
                {
                    typeof(TUnitAttribute).Assembly.Location,
                    typeof(AssertionBuilder).Assembly.Location,
                },
            },
        };

        test.ExpectedDiagnostics.AddRange(expected);
        await test.RunAsync(CancellationToken.None);
    }
}