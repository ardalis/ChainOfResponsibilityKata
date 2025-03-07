using Microsoft.AspNetCore.Mvc.Testing;

namespace ChainOfRespKataTests;

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
  
}
