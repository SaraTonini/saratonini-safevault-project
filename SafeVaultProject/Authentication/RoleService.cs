public static class RoleService
{
    // Mock database for user roles
    private static Dictionary<string, string> userRoles = new Dictionary<string, string>
    {
        { "admin", "admin" },
        { "user", "user" }
    };

    // Check if a user has the required role
    public static bool HasAccess(string username, string requiredRole)
    {
        // Try to get the user's role
        if (userRoles.TryGetValue(username, out string? userRole)) // Use nullable type for userRole
        {
            // Check if userRole is not null and matches the required role
            return userRole != null && userRole == requiredRole;
        }
        return false; // Return false if the user does not exist or role is null
    }

}
