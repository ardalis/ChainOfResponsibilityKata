using Ardalis.HttpClientTestExtensions;
using Kata.ApiModels;

namespace ChainOfRespKataTests;

public class HeroesCreate : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client;

  public HeroesCreate(CustomWebApplicationFactory<Program> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsOneNewHeroGivenUniqueName()
  {
    var testHeroName = Guid.NewGuid().ToString();
    var request = new HeroDto() { Name = testHeroName };
    var content = StringContentHelpers.FromModelAsJson(request);

    var result = await _client.PostAndDeserializeAsync<HeroDto>(
        "/heroes", content);

    Assert.Equal(testHeroName, result.Name);
  }

  [Fact]
  public async Task ReturnsBadRequestGivenDuplicateName()
  {
    var testName = "test";
    var request = new HeroDto() { Name = testName };
    var content = StringContentHelpers.FromModelAsJson(request);

    // add it once
    _ = await _client.PostAndDeserializeAsync<HeroDto>(
        "/heroes", content);
    // add it again and ensure it returns Bad Request
    await _client.PostAndEnsureBadRequestAsync(
        "/heroes", content);
  }
}
