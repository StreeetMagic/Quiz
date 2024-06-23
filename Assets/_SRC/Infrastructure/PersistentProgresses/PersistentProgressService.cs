using Infrastructure.ConfigProviders;
using UnityEngine;

namespace Infrastructure.PersistentProgresses
{
  public class PersistentProgressService
  {
    private readonly ConfigProvider _configProvider;

    public PersistentProgressService(ConfigProvider configProvider)
    {
      _configProvider = configProvider;
    }

    public ProjectProgress ProjectProgress { get; private set; }

    public void LoadProgress(string getString) =>
      ProjectProgress =
        JsonUtility
          .FromJson<ProjectProgress>(getString);

    public void SetDefault()
    {
      DefaultProjectProgressConfig defConfig = _configProvider.DefaultProjectProgressConfig;

      ProjectProgress = new ProjectProgress(defConfig.MusicMute);
    }
  }
}