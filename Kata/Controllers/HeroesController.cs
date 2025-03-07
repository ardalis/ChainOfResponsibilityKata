using Kata.ApiModels;
using Kata.Managers;
using Microsoft.AspNetCore.Mvc;

namespace Kata.Controllers;

[Route("[controller]")]
public class HeroesController(ILogger<HeroesController> logger,
    HeroesManager heroesManager) : ControllerBase
{
    private readonly ILogger<HeroesController> _logger = logger;
    private readonly HeroesManager _heroesManager = heroesManager;

    [HttpGet("{id}")]
    public async Task<ActionResult<HeroDto>> GetById(int id)
    {
        if (id < 0)
        {
            _logger.LogError("Invalid id");
            return BadRequest();
        }
        var hero = await _heroesManager.GetById(id);

        // TODO: Add Automapper
        return Ok(new HeroDto { Id = hero.Id, Name = hero.Name });

    }

    [HttpPost()]
    public async Task<ActionResult<HeroDto>> Add([FromBody]HeroDto hero)
    {
        if (hero.Id != 0)
        {
            _logger.LogError("New Hero cannot have Id");
            return BadRequest();
        }

        if (String.IsNullOrWhiteSpace(hero.Name))
        {
            _logger.LogError("New Hero must have a name");
            return BadRequest();
        }

        var newHero = await _heroesManager.Add(hero);

        // TODO: Add Automapper
        return Ok(new HeroDto { Id = newHero.Id, Name = newHero.Name });

    }
}
