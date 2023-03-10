namespace NetEvolve.Extensions.XUnit.Tests.Unit;

using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Xunit;
using VerifyXunit;
using System.Linq;
using System.Collections.Generic;

[ExcludeFromCodeCoverage]
[UsesVerify]
public class SetUICultureAttributeTests : AttributeTestsBase
{
    [Fact]
    [SetUICulture("en")]
    public async Task Execute_English()
    {
        var traits = GetTraits();
        var translations = new Dictionary<string, string>
        {
            { "Translation", Translations.HelloWorld }
        };

        _ = await Verify(traits.Union(translations));
    }

    [Fact]
    [SetUICulture("")]
    public async Task Execute_Invariant()
    {
        var traits = GetTraits();
        var translations = new Dictionary<string, string>
        {
            { "Translation", Translations.HelloWorld }
        };

        _ = await Verify(traits.Union(translations));
    }

    [Fact]
    [SetUICulture("de")]
    public async Task Execute_German()
    {
        var traits = GetTraits();
        var translations = new Dictionary<string, string>
        {
            { "Translation", Translations.HelloWorld }
        };

        _ = await Verify(traits.Union(translations));
    }

    [Fact]
    [SetUICulture("de-DE")]
    public async Task Execute_German_Germany()
    {
        var traits = GetTraits();
        var translations = new Dictionary<string, string>
        {
            { "Translation", Translations.HelloWorld }
        };

        _ = await Verify(traits.Union(translations));
    }
}
