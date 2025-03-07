using Kata.ApiModels;
using Kata.DataAccess;
using Kata.Entities;
using MediatR;

namespace Kata.UseCases.Heroes;

public record AddHeroCommand(string Name) : IRequest<HeroDto>;

public class AddHeroHandler(HeroesDa heroesDa, ILogger<AddHeroHandler> logger)
    : IRequestHandler<AddHeroCommand, HeroDto>
{
  private readonly HeroesDa _heroesDa = heroesDa;
  private readonly ILogger<AddHeroHandler> _logger = logger;

    public async Task<HeroDto> Handle(AddHeroCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (String.IsNullOrWhiteSpace(request.Name))
            {
                _logger.LogError("New Hero must have a name");
                return null;
            }
            var hero = new Hero { Name = request.Name };
            await _heroesDa.Add(hero);
            if (hero == null)
            {
                _logger.LogError("Hero FAILED TO ADD");
                return null;
            }
            var dto = new HeroDto { Id = hero.Id, Name = hero.Name };
            return dto;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding hero");
            throw;
        }
    }
}