using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Advanced.Tools;

public static class Validations
{
    public static string PasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$";
    public static string EmailRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$";
    public static string PhoneRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$";
    
    /// <summary>
    /// Checks if the length of the given string falls within the specified minimum and maximum length constraints.
    /// </summary>
    /// <param name="text">The string to check the length of.</param>
    /// <param name="minLength">The optional minimum length constraint. If null, no minimum length constraint is applied.</param>
    /// <param name="maxLength">The optional maximum length constraint. If null, no maximum length constraint is applied.</param>
    /// <returns>
    /// <c>True</c> if the length of the string is greater than 0 and within the specified length constraints, otherwise <c>False</c>.
    /// </returns>
    /// <example>
    /// <code>
    /// string example = "Hello";
    /// example.IsLength(minLength: 3, maxLength: 10); // true
    /// example.IsLength(minLength: 6); // false
    /// example.IsLength(maxLength: 4); // false
    /// example.IsLength(); // true
    /// </code>
    /// </example>
    public static bool IsLength(this string text, int? minLength = null, int? maxLength = null)
    {
        var length = text.Length;

        return (minLength == null || length >= minLength) && (maxLength == null || length <= maxLength) && length > 0;
    }

    /// <summary>
    /// Validates the given password string against a specified regular expression or a default pattern.
    /// </summary>
    /// <param name="text">The password string to validate.</param>
    /// <param name="regex">
    /// The optional regular expression to use for validation. If null, the default pattern is used: 
    /// the password must contain at least one lowercase letter, one uppercase letter, one digit, 
    /// and be between 8 to 15 characters long.
    /// </param>
    /// <returns>
    /// <c>True</c> if the password matches the provided or default regular expression, otherwise <c>False</c>.
    /// </returns>
    /// <example>
    /// <code>
    /// string password = "Passw0rd";
    /// bool isValidDefault = password.IsCorrectPassword(); // Returns true if password matches default pattern
    /// 
    /// Regex customRegex = new Regex(@"^[a-zA-Z0-9]{6,12}$");
    /// bool isValidCustom = password.IsCorrectPassword(customRegex); // Returns true if password matches custom pattern
    /// </code>
    /// </example>
    public static bool IsCorrectPassword(this string text, Regex? regex = null)
    {
        return (regex ?? new Regex(PasswordRegex)).IsMatch(text);
    }

    public static bool IsCorrectEmail(this string text, Regex? regex = null)
    {
        return (regex ?? new Regex(EmailRegex)).IsMatch(text);
    }

    public static bool IsCorrectPhone(this string text, Regex? regex = null)
    {
        return (regex ?? new Regex(PhoneRegex)).IsMatch(text);
    }
    
    /// <summary>
    /// Computes the SHA-512 hash of the given string and returns it as a Base64-encoded string.
    /// </summary>
    /// <param name="text">The input string to hash.</param>
    /// <returns>
    /// A Base64-encoded string representing the SHA-512 hash of the input string.
    /// </returns>
    /// <example>
    /// <code>
    /// string example = "HelloWorld";
    /// example.Hash();
    /// </code>
    /// </example>
    public static string Hash(this string text)
    {
        return Convert.ToBase64String(new SHA512Managed().ComputeHash(System.Text.Encoding.Unicode.GetBytes(text)));
    }
}