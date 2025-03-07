using Kata.ApiModels;
using Kata.DataAccess;
using Kata.Entities;

namespace Kata.Managers;

public class HeroesManager(ILogger<HeroesManager> logger, HeroesDa heroesDa)
{
  private readonly ILogger<HeroesManager> _logger = logger;
  private readonly HeroesDa _heroesDa = heroesDa;

  public async Task<Hero> GetById(int id)
  {
    try
    {
      if (id < 0)
      {
        _logger.LogError("Invalid id");
        return null;
      }
      var hero = await _heroesDa.GetById(id);
      if (hero == null)
      {
        _logger.LogError("Hero not found");
        return null;
      }
      return hero;
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Error getting hero by id");
      throw;
    }
  }
  public async Task<Hero> Add(HeroDto newHero)
  {
    try
    {
      if (newHero.Id != 0)
      {
        _logger.LogError("Invalid id");
        return null;
      }
      if (string.IsNullOrWhiteSpace(newHero.Name))
      {
        _logger.LogError("New Hero must have a name");
        return null;
      }
      var hero = new Hero { Name = newHero.Name };
      await _heroesDa.Add(hero);
      if (hero == null)
      {
        _logger.LogError("Hero FAILED TO ADD");
        return null;
      }
      return hero;
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Error adding hero");
      throw;
    }
  }
}
