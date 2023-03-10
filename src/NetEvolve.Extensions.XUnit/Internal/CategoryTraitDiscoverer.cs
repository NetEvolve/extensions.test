namespace NetEvolve.Extensions.XUnit.Internal;

using System.Collections.Generic;
using Xunit.Abstractions;
using NetEvolve.Extensions.XUnit;

/// <summary>
/// Discoverer for all implementations of <see cref="CategoryTraitAttributeBase"/>.
/// </summary>
public sealed class CategoryTraitDiscoverer : DiscovererBase
{
    /// <inheritdoc />
    public override IEnumerable<KeyValuePair<string, string>> GetTraits(
        IAttributeInfo traitAttribute
    )
    {
        if (traitAttribute is null)
        {
            yield break;
        }

        var category = GetNamedArgument(traitAttribute, Internals.Category);
        if (string.IsNullOrWhiteSpace(category))
        {
            yield break;
        }

        yield return new KeyValuePair<string, string>(Internals.TestCategory, category!);

        var id = GetNamedArgument(traitAttribute, Internals.Id);

        if (!string.IsNullOrWhiteSpace(id))
        {
            yield return new KeyValuePair<string, string>(category!, id!);
        }
    }
}
