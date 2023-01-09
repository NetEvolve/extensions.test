﻿namespace NetEvolve.Extensions.XUnit;

using NetEvolve.Extensions.XUnit.Internal;
using System;
using System.Globalization;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = false)]
public sealed class SetUICultureAttribute : CultureAttributeBase
{
    public SetUICultureAttribute() : base("SetUICulture", string.Empty) { }

    public SetUICultureAttribute(string culture) : base("SetUICulture", culture) { }

    protected override bool SetCurrentCulture(CultureInfo culture)
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
