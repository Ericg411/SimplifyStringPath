namespace SimplifyStringPath.Tests;

[TestClass]
public class UnitTest1
{
    private readonly Class1 _test;
    public UnitTest1()
    {
        _test = new Class1();
    }

    [TestMethod]
    public void TrailingSlash()
    {
        var str = "/home/";
        var result = _test.SimplifyPath(str);
        Assert.AreEqual("/home", result);
    }
    [TestMethod]
    public void TrailingSlashWithPrevDirectory()
    {
        var str = "/../";
        var result = _test.SimplifyPath(str);
        Assert.AreEqual("/", result);
    }
    [TestMethod]
    public void DoubleSlash()
    {
        var str = "/home//foo/";
        var result = _test.SimplifyPath(str);
        Assert.AreEqual("/home/foo", result);
    }
    [TestMethod]
    public void MultipleErrorsInString()
    {
        var str = "/home/..//documents//../thispc/./c/../foo//bar//";
        var result = _test.SimplifyPath(str);
        Assert.AreEqual("/thispc/foo/bar", result);
    }
}