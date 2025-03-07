using System.Reflection;
using Kata.ApiModels;
using Kata.DataAccess;
using Kata.Managers;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<HeroesDa>();
builder.Services.AddScoped<HeroesManager>();

var mediatRAssemblies = new[]
  {
          Assembly.GetAssembly(typeof(HeroDto)), // this assembly
      };

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatRAssemblies!));
    //.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
