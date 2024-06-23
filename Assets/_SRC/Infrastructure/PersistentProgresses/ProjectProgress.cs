using System;

namespace Infrastructure.PersistentProgresses
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