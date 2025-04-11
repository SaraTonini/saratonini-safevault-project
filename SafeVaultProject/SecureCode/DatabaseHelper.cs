using Microsoft.Data.SqlClient;

public static class DatabaseHelper
{
    private static string connectionString = "my_connection_string";

    // Execute a parameterized query to avoid SQL injection
    public static void AddUser(string username, string email)
    {
        string query = "INSERT INTO Users (Username, Email) VALUES (@Username, @Email)";
        
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Add parameters securely
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Email", email);
                
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
