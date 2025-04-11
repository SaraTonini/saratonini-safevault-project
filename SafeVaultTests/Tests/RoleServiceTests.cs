[TestFixture]
public class RoleServiceTests
{
    [Test]
    public void TestAdminAccess()
    {
        // Check if an admin has access to admin functionality
        Assert.That(RoleService.HasAccess("admin", "admin"), Is.True);
    }

    [Test]
    public void TestUserAccessToAdmin()
    {
        // Verify that a normal user cannot access admin functionality
        Assert.That(RoleService.HasAccess("user", "admin"), Is.False);
    }

    [Test]
    public void TestValidUserRole()
    {
        // Check if a user has access to user functionality
        Assert.That(RoleService.HasAccess("user", "user"), Is.True);
    }

    [Test]
    public void TestInvalidRoleAccess()
    {
        // Test that an invalid role does not grant access
        Assert.That(RoleService.HasAccess("guest", "admin"), Is.False);
    }
}
