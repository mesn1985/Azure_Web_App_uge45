using System;
using System.Text.RegularExpressions;

public class Lastname
{
    private const int MinLength = 2;
    private const int MaxLength = 20;
    private static readonly Regex AlphabeticPattern = new Regex(@"^[A-Za-z]+$", RegexOptions.Compiled);

    private string Value { get; }

    public Lastname(string value)
    {
        Validate(value);
        Value = value;
    }

    public string GetValue()
    {
        return Value;
    }

    private void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Lastname cannot be null or empty.", nameof(value));

        if (value.Length < MinLength)
            throw new ArgumentException($"Lastname must be at least {MinLength} characters long.", nameof(value));

        if (value.Length > MaxLength)
            throw new ArgumentException($"Lastname cannot exceed {MaxLength} characters.", nameof(value));

        if (!AlphabeticPattern.IsMatch(value))
            throw new ArgumentException("Lastname must contain only alphabetic characters (A-Z).", nameof(value));
    }
}
