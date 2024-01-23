using Moq;
using NASA_API_Endpoint.Models;

namespace NASA_API_Endpoint_Tests;

public class Tests
{
    AsteroidModel asteroidTest;

    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void Test1()
    {
        var mock = new Mock<AsteroidModel>();

        var mockObject = mock.Object;

        mockObject.Diametro = 2.0;

        Assert.That(mockObject.Diametro == 2.0);
    }
}
