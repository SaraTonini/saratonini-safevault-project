[TestFixture]
public class DatabaseTests
{
    [Test]
    public void TestAddUser()
    {
        string username = "' OR '1'='1";
        string email = "example@example.com";

        Assert.DoesNotThrow(() => DatabaseHelper.AddUser(username, email));
    }
}
