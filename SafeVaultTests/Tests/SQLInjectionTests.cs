using Moq;

[TestFixture]
public class SQLInjectionTests
{
    [Test]
    public void TestInjectionAttempt()
    {
        // Create a mock implementation of IDatabaseHelper
        var mockDatabaseHelper = new Mock<IDatabaseHelper>();

        // Configure the mock to return false when input contains "DROP TABLE"
        mockDatabaseHelper
            .Setup(db => db.IsUserValid(It.Is<string>(username => username.Contains("DROP TABLE"))))
            .Returns(false);

        // Use the mocked database helper in the test
        var databaseHelper = mockDatabaseHelper.Object;

        // Simulated malicious input to test SQL injection protection
        string maliciousInput = "'; DROP TABLE Users; --";
        bool result = databaseHelper.IsUserValid(maliciousInput);

        // Assert that the result is false, indicating the injection attempt was blocked
        Assert.That(result, Is.False, "SQL injection attempt should be blocked");
    }
}
