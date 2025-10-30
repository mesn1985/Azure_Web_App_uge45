using System;
using System.Text.RegularExpressions;

public class Firstname
{
    private const int MinLength = 2;
    private const int MaxLength = 20;
    private static readonly Regex AlphabeticPattern = new Regex(@"^[A-Za-z]+$", RegexOptions.Compiled);

    private string Value { get; }

    public Firstname(string value)
    {
        // Validate(value);
        Value = value;
    }

    public string GetValue()
    {
        return Value;
    }

    private void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Firstname cannot be null or empty.", nameof(value));

        if (value.Length < MinLength)
            throw new ArgumentException($"Firstname must be at least {MinLength} characters long.", nameof(value));

        if (value.Length > MaxLength)
            throw new ArgumentException($"Firstname cannot exceed {MaxLength} characters.", nameof(value));

        if (!AlphabeticPattern.IsMatch(value))
            throw new ArgumentException("Firstname must contain only alphabetic characters (A-Z).", nameof(value));
    }
}
