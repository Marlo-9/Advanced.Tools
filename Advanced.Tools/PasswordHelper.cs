using System;
using System.Security.Cryptography;

namespace Advanced.Tools
{
	/// <summary>
    /// A helper class for password-related operations such as generating salts, hashing passwords, and authenticating users.
    /// </summary>
    public static class PasswordHelper
    {
        /// <summary>
        /// The length of the salt in bytes.
        /// </summary>
        public static int SaltLength = 32;

        /// <summary>
        /// Generates a cryptographically secure salt.
        /// </summary>
        /// <returns>A byte array containing the generated salt.</returns>
        /// <example>
        /// <code>
        /// byte[] salt = PasswordHelper.GenerateSalt();
        /// </code>
        /// </example>
        public static byte[] GenerateSalt()
        {
            var salt = new byte[SaltLength];
            RandomNumberGenerator.Fill(salt);
            return salt;
        }

        /// <summary>
        /// Hashes the given password using the specified salt.
        /// </summary>
        /// <param name="text">The password to hash.</param>
        /// <param name="salt">The salt to use in the hashing process.</param>
        /// <returns>A Base64 encoded string representing the hashed password.</returns>
        /// <example>
        /// <code>
        /// string password = "securePassword";
        /// byte[] salt = PasswordHelper.GenerateSalt();
        /// string hashedPassword = password.HashPassword(salt);
        /// </code>
        /// </example>
        public static string HashPassword(this string text, byte[] salt)
        {
            using Rfc2898DeriveBytes passwordKeyGenerator = new(text, salt, 10000);
            return Convert.ToBase64String(passwordKeyGenerator.GetBytes(SaltLength));
        }

        /// <summary>
        /// Authenticates a user by comparing the entered password with the stored password hash and salt.
        /// </summary>
        /// <param name="enteredPassword">The password entered by the user.</param>
        /// <param name="storedPasswordHash">The stored hash of the user's password.</param>
        /// <param name="storedSalt">The salt used when the user's password was hashed.</param>
        /// <returns><c>True</c> if the entered password matches the stored password hash, otherwise <c>False</c>.</returns>
        /// <example>
        /// <code>
        /// string enteredPassword = "securePassword";
        /// string storedPasswordHash = "hashedPasswordFromDatabase";
        /// byte[] storedSalt = GetSaltFromDatabase(); // Retrieve the salt from the database
        /// bool isAuthenticated = PasswordHelper.AuthenticateUser(enteredPassword, storedPasswordHash, storedSalt);
        /// </code>
        /// </example>
        public static bool AuthenticateUser(string enteredPassword, string storedPasswordHash, byte[] storedSalt)
        {
            return enteredPassword.HashPassword(storedSalt).Equals(storedPasswordHash);
        }
    }
}
