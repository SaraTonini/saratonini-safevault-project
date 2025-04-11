[TestFixture]
public class AuthServiceTests
{
    [Test]
    public void TestValidLogin()
    {
        // Test valid credentials for a user
        Assert.That(AuthService.Authenticate("admin", "admin123"), Is.True);
    }

    [Test]
    public void TestInvalidPassword()
    {
        // Test invalid password for a valid username
        Assert.That(AuthService.Authenticate("admin", "wrongpassword"), Is.False);
    }

    [Test]
    public void TestInvalidUsername()
    {
        // Test invalid username
        Assert.That(AuthService.Authenticate("nonexistent", "admin123"), Is.False);
    }
}
