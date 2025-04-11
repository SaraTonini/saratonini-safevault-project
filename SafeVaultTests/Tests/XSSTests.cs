[TestFixture]
public class XSSTests
{
    [Test]
    public void TestSanitization()
    {
        string maliciousInput = "<script>alert('Hacked!')</script>";
        string sanitizedOutput = InputSanitizer.Sanitize(maliciousInput);
        
        Assert.That(sanitizedOutput, Is.EqualTo("&lt;script&gt;alert(&#39;Hacked!&#39;)&lt;/script&gt;"));
    }
}
