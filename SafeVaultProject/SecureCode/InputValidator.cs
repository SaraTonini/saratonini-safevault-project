using System.Text.RegularExpressions;
using System.Text.Encodings.Web;

public static class InputValidator
{
    // Sanitize input to remove harmful characters
    public static string SanitizeInput(string input)
    {
        // Remove HTML tags
        input = Regex.Replace(input, "<.*?>", string.Empty);
        
        // Encode input to prevent XSS
        input = HtmlEncoder.Default.Encode(input);

        return input;
    }

    // Validate input against a specified pattern
    public static bool ValidateInput(string input, string pattern)
    {
        return Regex.IsMatch(input, pattern);
    }
}
