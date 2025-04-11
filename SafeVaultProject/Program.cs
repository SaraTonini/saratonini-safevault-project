class Program
{
    static void Main(string[] args)
    {
        // Display a welcome message
        Console.WriteLine("Welcome to SafeVault!");

        // Simulate user input
        Console.Write("Enter your username: ");
        string username = Console.ReadLine() ?? string.Empty; // Handle null values by assigning an empty string

        Console.Write("Enter your email: ");
        string email = Console.ReadLine() ?? string.Empty; // Handle null values by assigning an empty string

        // Sanitize inputs
        username = InputValidator.SanitizeInput(username); // Remove harmful characters from username
        email = InputValidator.SanitizeInput(email);       // Remove harmful characters from email

        // Validate username format (3-20 characters, letters, numbers, and underscores only)
        if (!InputValidator.ValidateInput(username, "^[a-zA-Z0-9_]{3,20}$"))
        {
            Console.WriteLine("Invalid username! Please use only letters, numbers, and underscores (3-20 characters).");
            return;
        }

        // Validate email format (standard email validation regex)
        if (!InputValidator.ValidateInput(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
        {
            Console.WriteLine("Invalid email! Please enter a valid email address.");
            return;
        }

        // Display confirmation message after successful validation
        Console.WriteLine("Your inputs have been successfully validated and sanitized!");
        Console.WriteLine($"Username: {username}");
        Console.WriteLine($"Email: {email}");
    }
}
