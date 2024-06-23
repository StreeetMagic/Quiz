using UnityEngine;

namespace Infrastructure.Loggers
{
  public class DebugLogger
  {
    public void Log(string message)
    {
      Debug.Log(message);
    }
  }
}