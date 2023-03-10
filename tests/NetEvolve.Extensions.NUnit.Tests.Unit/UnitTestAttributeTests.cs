namespace NetEvolve.Extensions.NUnit.Tests.Unit;

using global::NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// Unit tests for <see cref="UnitTestAttribute"/>.
/// </summary>
[ExcludeFromCodeCoverage]
public class UnitTestAttributeTests : AttributeTestsBase
{
    [Theory]
    [UnitTest]
    [TestCase(nameof(UnitTest_without_parameters))]
    public async Task UnitTest_without_or_invalid_parameters(string methodName)
    {
        var properties = GetProperties(methodName);

        _ = await Verify(properties).UseParameters(methodName);
    }

    [UnitTest]
    public void UnitTest_without_parameters() { }
}
