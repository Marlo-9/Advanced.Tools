using System;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Advanced.Tools;

/// <summary>
/// A service class for checking data for correctness.
/// </summary>
public static class Validations
{
    /// <summary>
    /// Regular expression pattern for validating password.
    /// </summary>
    public static string PasswordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$";
    
    /// <summary>
    /// Regular expression pattern for validating email addresses.
    /// </summary>
    public static string EmailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    
    /// <summary>
    /// Regular expression pattern for validating Russian phone numbers.
    /// </summary>
    public static string PhoneRegex = @"^(\+7|8)?[\s-]?(\(?\d{3}\)?[\s-]?)?[\d\s-]{7,10}$";
    
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
    /// The optional regular expression to use for validation. If null, the default pattern <see cref="PasswordRegex"/> is used.
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

    /// <summary>
    /// Validates the given string as an email address using the specified regular expression or a default pattern.
    /// </summary>
    /// <param name="text">The email address string to validate.</param>
    /// <param name="regex">
    /// The optional regular expression to use for validation. If null, the default pattern <see cref="EmailRegex"/> is used.
    /// </param>
    /// <returns>
    /// <c>True</c> if the email address matches the provided or default regular expression, otherwise <c>False</c>.
    /// </returns>
    /// <example>
    /// <code>
    /// string email = "example@example.com";
    /// bool isValid = email.IsCorrectEmail(); // Returns true if email matches default pattern
    /// 
    /// Regex customRegex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
    /// bool isValidCustom = email.IsCorrectEmail(customRegex); // Returns true if email matches custom pattern
    /// </code>
    /// </example>
    public static bool IsCorrectEmail(this string text, Regex? regex = null)
    {
        return (regex ?? new Regex(EmailRegex)).IsMatch(text);
    }

    /// <summary>
    /// Validates the given string as a Russian phone number using the specified regular expression or a default pattern.
    /// </summary>
    /// <param name="text">The phone number string to validate.</param>
    /// <param name="regex">
    /// The optional regular expression to use for validation. If null, the default pattern <see cref="PhoneRegex"/> is used.
    /// </param>
    /// <returns>
    /// <c>True</c> if the phone number matches the provided or default regular expression, otherwise <c>False</c>.
    /// </returns>
    /// <example>
    /// <code>
    /// string phoneNumber = "+7 123 456-78-90";
    /// bool isValid = phoneNumber.IsCorrectPhone(); // Returns true if phone number matches default pattern
    /// 
    /// Regex customRegex = new Regex(@"^\+7\d{10}$");
    /// bool isValidCustom = phoneNumber.IsCorrectPhone(customRegex); // Returns true if phone number matches custom pattern
    /// </code>
    /// </example>
    public static bool IsCorrectPhone(this string text, Regex? regex = null)
    {
        return (regex ?? new Regex(PhoneRegex)).IsMatch(text);
    }
}