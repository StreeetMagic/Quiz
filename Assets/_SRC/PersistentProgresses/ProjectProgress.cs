using System;

namespace PersistentProgresses
{
  [Serializable]
  public class ProjectProgress
  {
    public bool MusicMute;

    public ProjectProgress(bool musicMute)
    {
      MusicMute = musicMute;
    }
  }
}