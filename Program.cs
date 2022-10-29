using System.Reflection;
using System.Runtime.CompilerServices;

namespace Microsoft.Extensions.ModelValidation;

// an annotated model
[MakeValidatable]
partial class MyModel
{
    [ScalarRange(0, 1)]
    public int Number;

    [TimeSpanRange(0, 10)]
    public TimeSpan Duration;

    [NotNull]
    public string? Name;

    [ValidateTransitively]
    MySubmodel? Sub { get; set; }

    [ValidateEnumerable]
    IList<MySubmodel>? Subs { get; set; }
}

// a component of the bigger model
[MakeValidatable]
class MySubmodel
{
    [ScalarRange(100)]
    public int Number { get; set; }
}

internal class Program
{
    static void Main()
    {
        var model = new MyModel();

        var vc = model.Validate();
        if (vc != null)
        {
            // invalid model
        }
    }
}
