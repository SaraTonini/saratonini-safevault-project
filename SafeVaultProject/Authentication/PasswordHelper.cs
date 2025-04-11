using System.Security.Cryptography;
using System.Text;

public static class PasswordHelper
{
    // Generate a hashed password using SHA256
    public static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hashedBytes = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hashedBytes);
        }
    }

    // Verify a hashed password against the input
    public static bool VerifyPassword(string input, string hashedPassword)
    {
        string hashedInput = HashPassword(input);
        return hashedInput == hashedPassword;
    }
}
