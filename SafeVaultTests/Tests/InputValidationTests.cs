[TestFixture]
public class InputValidationTests
{
    [Test]
    public void TestValidUsername()
    {
        Assert.That(InputValidator.ValidateInput("ValidUser123", "^[a-zA-Z0-9_]{3,20}$"), Is.True);
    }

    [Test]
    public void TestInvalidUsername()
    {
        Assert.That(InputValidator.ValidateInput("Invalid!@#", "^[a-zA-Z0-9_]{3,20}$"), Is.False);
    }

    [Test]
    public void TestValidEmail()
    {
        Assert.That(InputValidator.ValidateInput("email@example.com", @"^[^@\s]+@[^@\s]+\.[^@\s]+$"), Is.True);
    }

    [Test]
    public void TestInvalidEmail()
    {
        Assert.That(InputValidator.ValidateInput("invalid-email", @"^[^@\s]+@[^@\s]+\.[^@\s]+$"), Is.False);
    }
}
