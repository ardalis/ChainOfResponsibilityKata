using Kata.ApiModels;
using Kata.DataAccess;
using MediatR;

namespace Kata.UseCases.Heroes;

public class AddHeroHandler(HeroesDa heroesDa, ILogger<AddHeroHandler> logger)
    : IRequestHandler<AddHeroCommand, HeroDto>
{
  private readonly HeroesDa _heroesDa = heroesDa;
  private readonly ILogger<AddHeroHandler> _logger = logger;

  public async Task<HeroDto> Handle(AddHeroCommand request, CancellationToken cancellationToken)
  {
    // TODO: Implement the "real work" of adding a hero to the database via your HeroesDa here
    throw new NotImplementedException();
  }
}
