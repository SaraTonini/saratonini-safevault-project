using System.Web;

public static class InputSanitizer
{
    // Sanitize user input to prevent XSS attacks
    public static string Sanitize(string userInput)
    {
        return HttpUtility.HtmlEncode(userInput);
    }
}
