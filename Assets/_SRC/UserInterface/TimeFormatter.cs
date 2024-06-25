using UnityEngine;

namespace UserInterface
{
  public static class TimeFormatter
  {
    public static string UpdateTimeText(float timeInSeconds)
    {
      int minutes = Mathf.FloorToInt(timeInSeconds / 60);
      int seconds = Mathf.FloorToInt(timeInSeconds % 60);
      float fraction = timeInSeconds % 1 * 10;

      return $"{minutes}:{seconds:00}.{fraction:0}";
    }
  }
}