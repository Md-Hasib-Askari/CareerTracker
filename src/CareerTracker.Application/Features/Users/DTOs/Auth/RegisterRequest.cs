using System.ComponentModel.DataAnnotations;

public sealed record RegisterRequest : IValidatableObject
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string Password2 { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Password != Password2)
        {
            yield return new ValidationResult(
                "Passwords do not match.",
                [nameof(Password), nameof(Password2)]
            );
        }
    }
}