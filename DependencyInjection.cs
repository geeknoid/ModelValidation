// Extensions to enable automatic option validation of DI-inserted options.
// This may need to go into a separate assembly in order to keep the core model validation dependency set smaller

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Microsoft.Extensions.ModelValidation;

/// <summary>
/// Extension methods for adding configuration related options services to the DI container via <see cref="OptionsBuilder{TOptions}"/>.
/// </summary>
public static class OptionsBuilderExtensions
{
    /// <summary>
    /// Adds options that are automatically validated during startup using a built-in validator.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <typeparam name="TOptions">Options to validate.</typeparam>
    /// <returns>The <see cref="OptionsBuilder{TOptions}"/> so that additional calls can be chained.</returns>
    /// <remarks>
    /// We recommend using custom generated validator.
    /// </remarks>
    public static OptionsBuilder<TOptions> AddValidatedOptions<TOptions>(this IServiceCollection services)
        where TOptions : class, IValidatable
        => AddValidatedOptions<TOptions>(services, Microsoft.Extensions.Options.Options.DefaultName);

    /// <summary>
    /// Adds named options that are automatically validated during startup using a built-in validator.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <param name="name">Name of the options.</param>
    /// <typeparam name="TOptions">Options to validate.</typeparam>
    /// <returns>The <see cref="OptionsBuilder{TOptions}"/> so that additional calls can be chained.</returns>
    /// <remarks>
    /// We recommend using custom generated validator.
    /// </remarks>
    public static OptionsBuilder<TOptions> AddValidatedOptions<TOptions>(this IServiceCollection services, string name)
        where TOptions : class, IValidatable
    {
        throw new NotImplementedException();
    }
}
