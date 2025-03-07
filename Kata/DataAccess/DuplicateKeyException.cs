namespace Kata.DataAccess;

public class DuplicateKeyException : Exception
{
  public DuplicateKeyException(string message) : base(message)
  {
  }
} 
