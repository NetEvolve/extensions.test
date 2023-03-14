﻿namespace NetEvolve.Extensions.XUnit;

using NetEvolve.Extensions.XUnit.Internal;
using System;
using System.Globalization;
using System.Reflection;

/// <summary>
/// Based on the value passed as culture, the marked test is executed.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
public sealed class SetCultureAttribute : CultureAttributeBase
{
    private readonly CultureInfo _uiCulture;
    private CultureInfo? _originalUICulture;
    private bool _changed;

    /// <summary>
    /// UI culture
    /// </summary>
    public string? UICulture { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetCultureAttribute"/> class.
    /// </summary>
    public SetCultureAttribute()
        : this(string.Empty, string.Empty) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetCultureAttribute"/> class.
    /// </summary>
    /// <param name="culture">Culture to use.</param>
    public SetCultureAttribute(string culture)
        : this(culture, string.Empty) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="SetCultureAttribute"/> class.
    /// </summary>
    /// <param name="culture">Culture to use.</param>
    /// <param name="uiCulture">UI culture to use.</param>
    public SetCultureAttribute(string culture, string? uiCulture)
        : base("SetCulture", culture)
    {
        if (string.IsNullOrWhiteSpace(uiCulture))
        {
            uiCulture = string.Empty;
        }

        _uiCulture = CreateCultureInfo(uiCulture!);
    }

    /// <inheritdoc/>
    public override void After(MethodInfo methodUnderTest)
    {
        base.After(methodUnderTest);

        if (_changed)
        {
            _ = SetUICulture(_originalUICulture!);
        }
    }

    /// <inheritdoc/>
    public override void Before(MethodInfo methodUnderTest)
    {
        base.Before(methodUnderTest);

        _originalUICulture = CultureInfo.CurrentUICulture;
        _changed = SetUICulture(_uiCulture);
    }

    private static bool SetUICulture(CultureInfo culture)
    {
        if (CultureInfo.CurrentUICulture != culture)
        {
            CultureInfo.CurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            return true;
        }

        return false;
    }
}
