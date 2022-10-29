// The atributes you can apply to control the code generator
//
//     * [MakeValidatable] triggers the code generator to emit an implementation of IDataValidator
//     * [ValidateTransitively] triggers transitive validation of a member's object
//     * [ValidateEnumerable] triggers validation of the items of an enumeration

using System.Diagnostics;

namespace Microsoft.Extensions.ModelValidation;

/// <summary>
/// Triggers the automatic generation of the implementation of <see cref="IValidatable" /> at compile time.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public sealed class MakeValidatableAttribute : Attribute
{
}

/// <summary>
/// Marks a field or property to be validated transitively.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class ValidateTransitivelyAttribute : Attribute
{
}

/// <summary>
/// Marks a field or property to be enumerated, and each enumerated object to be validated.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
public sealed class ValidateEnumerableAttribute : Attribute
{
}
