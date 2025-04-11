using Microsoft.Data.SqlClient;

// Interface defining database methods for mocking in tests
public interface IDatabaseHelper
{
    bool IsUserValid(string username);
}

// Concrete class that implements database interactions
public class DatabaseHelper : IDatabaseHelper
{
    // Fake connection string to simulate database connection
    private static string connectionString = "MyConnectionString";

    // Method to verify if a user exists in the database
    public bool IsUserValid(string username)
    {
        // SQL query using parameterized statements to prevent SQL injection
        string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";

        // Initialize the SQL connection with the (fake) connection string
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(query, connection);

            // Safely add user input as a parameter to the query
            command.Parameters.AddWithValue("@Username", username);

            // Open the SQL connection (this simulates database interaction)
            connection.Open();

            // Execute the query and return the result
            int result = (int)command.ExecuteScalar();

            // Return true if user exists (result > 0), false otherwise
            return result > 0;
        }
    }
}
