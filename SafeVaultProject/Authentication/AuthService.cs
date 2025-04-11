public static class AuthService
{
    // Mock database for user credentials
    private static Dictionary<string, string> users = new Dictionary<string, string>
    {
        { "admin", PasswordHelper.HashPassword("admin123") },
        { "user", PasswordHelper.HashPassword("user123") }
    };

    // Authenticate user by username and password
    public static bool Authenticate(string username, string password)
    {
        // Try to get the stored password
        if (users.TryGetValue(username, out string? storedPassword))
        {
            // Ensure storedPassword is not null
            if (storedPassword != null && PasswordHelper.VerifyPassword(password, storedPassword))
            {
                return true;
            }
        }
        return false;
    }

}
