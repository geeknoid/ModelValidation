// Example generated code

namespace Microsoft.Extensions.ModelValidation;

partial class MyModel : IValidatable
{
    private static readonly ScalarRangeAttribute _a0 = new(0, 1);
    private static readonly TimeSpanRangeAttribute _a1 = new(0, 10);
    private static readonly NotNullAttribute _a2 = new();
    private static readonly ScalarRangeAttribute _a3 = new(100);

    public ValidationResult? Validate()
    {
        ValidationResult? result = new();

        RecordError(nameof(Number), _a0.Validate(Number));
        RecordError(nameof(Duration), _a1.Validate(Duration));
        RecordError(nameof(Name), _a2.Validate(Name));
        RecordErrors(nameof(Sub), Validate(Sub));

        if (Subs != null)
        {
            int count = 0;
            foreach (var item in Subs)
            {
                RecordErrorsWhileEnumerating(nameof(Subs), count++, Validate(item));
            }
        }

        return result;

        void RecordError(string member, string? message)
        {
            if (message != null)
            {
                result ??= new ValidationResult();
                result.Value.RecordError(member, message);
            }
        }

        void RecordErrors(string member, ValidationResult? memberResult)
        {
            if (memberResult != null)
            {
                result ??= new ValidationResult();
                result.Value.RecordErrors(member, memberResult.Value!);
            }
        }

        void RecordErrorsWhileEnumerating(string member, int index, ValidationResult? memberResult)
        {
            if (memberResult != null)
            {
                result ??= new ValidationResult();
                result.Value.RecordErrors(member + $"[{index}]", memberResult.Value!);
            }
        }
    }

    private static ValidationResult? Validate(MySubmodel? model)
    {
        // ... omit implementation since I'm lazy
        return new();
    }
}
