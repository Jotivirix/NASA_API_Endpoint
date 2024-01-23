using Moq;
using NASA_API_Endpoint.Controllers;
using NASA_API_Endpoint.Models;
using Newtonsoft.Json;

namespace NASA_API_Endpoint_Tests;

public class Tests
{

    List<AsteroidModel> validData = new List<AsteroidModel>();

    AsteroidsController controller = new AsteroidsController();

    public string result = 
        "[{\n\"nombre\":\"175706 (1996 FG3)\"," +
                           "\n\"diametro\":0.91525606795," +
                           "\n\"velocidad\": 35467.2898501555," +
                           "\n\"fecha\": \"2024-01-28\"," +
                           "\n\"planeta\":\"Earth\"\n}," +

        "{\n\"nombre\":\"Test 2\"," +
                           "\n\"diametro\":0.95," +
                           "\n\"velocidad\": 35467.2898501555," +
                           "\n\"fecha\": \"2024-01-28\"," +
                           "\n\"planeta\":\"Earth\"\n}," +

        "{\n\"nombre\":\"Test 3\"," +
                           "\n\"diametro\":0.92795," +
                           "\n\"velocidad\": 35467.2898501555," +
                           "\n\"fecha\": \"2024-01-28\"," +
                           "\n\"planeta\":\"Earth\"\n}," +

        "{\n\"nombre\":\"Test 4\"," +
                           "\n\"diametro\":0.906795," +
                           "\n\"velocidad\": 35467.2898501555," +
                           "\n\"fecha\": \"2024-01-28\"," +
                           "\n\"planeta\":\"Earth\"\n}," +

        "{\n\"nombre\":\"Test 5\"," +
                           "\n\"diametro\":0.152," +
                           "\n\"velocidad\": 35467.2898501555," +
                           "\n\"fecha\": \"2024-01-28\"," +
                           "\n\"planeta\":\"Earth\"\n}," +

        "{\n\"nombre\":\"Test 6\"," +
                           "\n\"diametro\":0.52506795," +
                           "\n\"velocidad\": 35467.2898501555," +
                           "\n\"fecha\": \"2024-01-28\"," +
                           "\n\"planeta\":\"Earth\"\n}," +

        "{\n\"nombre\":\"Test 7\"," +
                           "\n\"diametro\":0.25606795," +
                           "\n\"velocidad\": 35467.2898501555," +
                           "\n\"fecha\": \"2024-01-28\"," +
                           "\n\"planeta\":\"Earth\"\n}," +

        "{\n\"nombre\":\"Test 8\"," +
                           "\n\"diametro\":0.06795," +
                           "\n\"velocidad\": 35467.2898501555," +
                           "\n\"fecha\": \"2024-01-28\"," +
                           "\n\"planeta\":\"Earth\"\n}]";

    [SetUp]
    public void Setup()
    {
        validData = JsonConvert.DeserializeObject<List<AsteroidModel>>(result)!;

    }

    [Test]
    public void Test1()
    {
        var mock = new Mock<AsteroidModel>();

        var mockObject = mock.Object;

        mockObject.Diametro = 2.0;

        Assert.That(mockObject.Diametro == 2.0);
    }

    [Test]
    public void Test2()
    {
        var mock = new Mock<AsteroidModel>();

        var mockObject = mock.Object;

        mockObject.Diametro = 2.0;

        bool mockIsBigger = false;

        foreach(var ast in validData)
        {
            if(mockObject.Diametro > ast.Diametro)
            {
                mockIsBigger = true;
            }
        }

        Assert.IsTrue(mockIsBigger);
    }

    [Test]
    public void Test3()
    {
        validData = controller.SortAndFilterTop3(validData);

        Assert.That(validData.Count == 3);
    }
}
