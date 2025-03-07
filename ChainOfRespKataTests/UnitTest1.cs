using System;
using Ardalis.HttpClientTestExtensions;
using Kata.ApiModels;
using Kata.DataAccess;

namespace ChainOfRespKataTests;


public class ContributorGetById : IClassFixture<CustomWebApplicationFactory<Program>>
{
  private readonly HttpClient _client;

  public ContributorGetById(CustomWebApplicationFactory<Program> factory)
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

  //[Fact]
  //public async Task ReturnsNotFoundGivenInvalidId1000()
  //{
  //  string route = GetContributorByIdRequest.BuildRoute(1000);
  //  _ = await _client.GetAndEnsureNotFoundAsync(route);
  //}
}
