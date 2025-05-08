using Api.Shared.Utils;

namespace Test.Shared.Utils;

public class IdGeneratorTest
{
    [Fact]
    public void CorrectFormat()
    {
        string id = IdGenerator.GenerateUniqueId();
        Assert.Matches(@"^\d{6}-[a-zA-Z0-9]{6}-\d{6}$", id);
    }

    [Fact]
    public void UniqueValues()
    {
        var id1 = IdGenerator.GenerateUniqueId();
        var id2 = IdGenerator.GenerateUniqueId();

        Assert.NotEqual(id1, id2);
    }

    [Fact]
    public void CorrectLength()
    {
        var id = IdGenerator.GenerateUniqueId();

        Assert.Equal(20, id.Length);
    }
}
