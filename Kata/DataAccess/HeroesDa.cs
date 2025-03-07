using Kata.Entities;

namespace Kata.DataAccess;

public class HeroesDa
{
  private static List<Hero> _heroes = new() { new Hero { Id = 1, Name = "Iron Man" } };
  public Task<Hero?> GetById(int id)
  {
    return Task.FromResult(_heroes.FirstOrDefault(x => x.Id == id));
  }

  public Task<Hero?> Add(Hero hero)
  {
    // Simulate unique constraint on name
    if (_heroes.Any(x => x.Name == hero.Name))
    {
      throw new DuplicateKeyException("Name must be unique");
    }
    hero.Id = _heroes.Max(x => x.Id) + 1;
    _heroes.Add(hero);
    return Task.FromResult(hero);
  }
}
