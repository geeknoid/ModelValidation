// The attributes that can be used to annotate fields and properties to constrain their values.
//
// Each attribute implements one or more methods with the following signature:
//
//    string? Validate(XXX value)
//
// The type of the value parameter determines the type of the properties/fields the attribute can be applied
// to. So if an attribute has a Validate function accepting a string, then the attribute can only be
// applied to string properties/fields. The code generator generates warnings about misuses.
//
// If the method returns null, validation was successful, otherwise the string represents the error message.

#pragma warning disable IDE0060

using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Microsoft.Extensions.ModelValidation;

/// <summary>
/// Ensures a string matches a given regex.
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public sealed class RegexAttribute : Attribute
{
    public RegexAttribute(string regex) {}
    public RegexAttribute(string regex, RegexOptions options) { }
    public string? Validate(string value) { throw new NotImplementedException(); }
}

/// <summary>
/// Ensures a value is not null.
/// </summary>
public sealed class NotNullAttribute : Attribute
{
    public string? Validate<T>(T value) { throw new NotImplementedException(); }
    public string? Validate<T>(Nullable<T> value) where T : struct { throw new NotImplementedException(); }
}

/// <summary>
/// Ensures a scalar value is in range, where the range is inclusive or exclusive.
/// </summary>
public sealed class ScalarRangeAttribute : Attribute
{
    public ScalarRangeAttribute(long max) { }
    public ScalarRangeAttribute(long min, long max) { }
    public bool Exclusive { get; set; }
    public string? Validate(long value) { throw new NotImplementedException(); }
}

/// <summary>
/// Ensures a double value is in range, where the range is inclusive or exclusive.
/// </summary>
public sealed class DoubleRangeAttribute : Attribute
{
    public DoubleRangeAttribute(double max) { }
    public DoubleRangeAttribute(double min, double max) { }
    public bool Exclusive { get; set; }
    public string? Validate(double value) { throw new NotImplementedException(); }
}

/// <summary>
/// Ensures a time span value is in range, where the range is inclusive or exclusive.
/// </summary>
public sealed class TimeSpanRangeAttribute : Attribute
{
    public TimeSpanRangeAttribute(string max) { }
    public TimeSpanRangeAttribute(string min, string max) { }
    public TimeSpanRangeAttribute(int maxMs) { }
    public TimeSpanRangeAttribute(int minMs, int maxMs) { }
    public bool Exclusive { get; set; }
    public string? Validate(TimeSpan value) { throw new NotImplementedException(); }
}

/// <summary>
/// Ensures a string, span, array, or collection has a count of values in range.
/// </summary>
public sealed class LengthAttribute : Attribute
{
    public LengthAttribute(int max) { }
    public LengthAttribute(int min, int max) { }
    public string? Validate<T>(IEnumerable<T> value) { throw new NotImplementedException(); }
    public string? Validate(string value) { throw new NotImplementedException(); }
    public string? Validate(ReadOnlySpan<char> value) { throw new NotImplementedException(); }
}

/// <summary>
/// Ensures that a string is well-formed.
/// </summary>
public sealed class StringAttribute : Attribute
{
    public bool InvalidIfEmpty { get; set; } = true;
    public bool InvalidIfOnlyWhitespace { get; set; } = true;
    public bool InvalidIfStartsOrEndsWithWhitespace { get; set; } = true;
    public bool InvalidIfAnyWhitespace { get; set; } = false;
    public string? Validate(string value) { throw new NotImplementedException(); }
    public string? Validate(ReadOnlySpan<char> value) { throw new NotImplementedException(); }
}

/// <summary>
/// Ensures that a string is a base64-encoded string.
/// </summary>
public sealed class Base64Attribute : Attribute
{
    public string? Validate(string value) { throw new NotImplementedException(); }
    public string? Validate(ReadOnlySpan<char> value) { throw new NotImplementedException(); }
}

/// <summary>
/// Ensures that a string is a valid block of JSON.
/// </summary>
public sealed class JsonAttribute : Attribute
{
    public string? Validate(string value) { throw new NotImplementedException(); }
    public string? Validate(ReadOnlySpan<char> value) { throw new NotImplementedException(); }
}

/// <summary>
/// Ensures that a field or property contains one of the listed values.
/// </summary>
public sealed class AllowedValuesAttribute : Attribute
{
    public AllowedValuesAttribute(params object[] allowed) { throw new NotImplementedException(); }
    public string? Validate(object value) { throw new NotImplementedException(); }
}

/// <summary>
/// Ensures that a field or property does not contain one of the listed values.
/// </summary>
public sealed class DisallowedValuesAttribute : Attribute
{
    public DisallowedValuesAttribute(params object[] disallowed) { throw new NotImplementedException(); }
    public string? Validate(object value) { throw new NotImplementedException(); }
}
