using Kata.ApiModels;
using Kata.Entities;
using MediatR;

namespace Kata.UseCases.Heroes;

public record AddHeroCommand(string Name) : IRequest<HeroDto>;
