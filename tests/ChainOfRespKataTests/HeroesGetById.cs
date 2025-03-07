using Ardalis.HttpClientTestExtensions;
using Kata.ApiModels;
using Kata.DataAccess;

namespace ChainOfRespKataTests;

public class HeroesGetById : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client;

  public HeroesGetById(CustomWebApplicationFactory<Program> factory)
  {
    _client = factory.CreateClient();
  }

  [Fact]
  public async Task ReturnsIronManGivenId1()
  {
    var result = await _client.GetAndDeserializeAsync<HeroDto>("/heroes/1");

    Assert.Equal(1, result.Id);
    Assert.Equal(HeroesDa._heroes[0].Name, result.Name);
  }
}
