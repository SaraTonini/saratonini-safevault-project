[TestFixture]
public class InputValidationTests
{
    [Test]
    public void TestSanitizeInput()
    {
        string maliciousInput = "<script>alert('XSS');</script>";
        string sanitizedInput = InputValidator.SanitizeInput(maliciousInput);
        
        Assert.IsFalse(sanitizedInput.Contains("<script>"));
    }

    [Test]
    public void TestValidateInput()
    {
        string validInput = "Username123";
        string invalidInput = "<script>";

        bool isValid = InputValidator.ValidateInput(validInput, "^[a-zA-Z0-9_]{3,20}$");
        bool isInvalid = InputValidator.ValidateInput(invalidInput, "^[a-zA-Z0-9_]{3,20}$");

        Assert.IsTrue(isValid);
        Assert.IsFalse(isInvalid);
    }
}
