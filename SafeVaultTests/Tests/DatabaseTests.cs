[TestFixture]
public class DatabaseTests
{
    [Test]
    public void TestSQLInjectionPrevention()
    {
        // Simulate an input with an SQL injection attempt
        string maliciousInput = "'; DROP TABLE Users; --";
        bool isValid = InputValidator.ValidateInput(maliciousInput, "^[a-zA-Z0-9_]{3,20}$");
        Assert.That(isValid, Is.False);
    }

    [Test]
    public void TestSafeQuery()
    {
        // Simulate a valid input
        string safeInput = "SafeUser";
        bool isValid = InputValidator.ValidateInput(safeInput, "^[a-zA-Z0-9_]{3,20}$");
        Assert.That(isValid, Is.True);
    }
}
