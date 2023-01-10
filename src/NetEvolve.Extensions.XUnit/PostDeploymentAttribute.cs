﻿namespace NetEvolve.Extensions.XUnit;
using NetEvolve.Extensions.XUnit.Internal;

/// <summary>
/// Attribute used to decorate a test class or method with TestCategory PostDeployment
/// </summary>
public sealed class PostDeploymentAttribute : CategoryTraitAttributeBase
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PostDeploymentAttribute"/> class.
    /// </summary>
    public PostDeploymentAttribute() : base(Internals.PostDeployment) { }
}
