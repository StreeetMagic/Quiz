using Infrastructure.ConfigProviders;
using Infrastructure.SceneLoaders;
using UnityEngine;
using Zenject;

namespace Infrastructure.SceneInstallers.LoadConfigs
{
  public class LoadConfigsInitializer : MonoBehaviour, IInitializable
  {
    [Inject] private SceneLoader _sceneLoader;

    [Inject] private ConfigProvider _configProvider;

    public void Initialize()
    {
      _configProvider.LoadConfigs();

      _sceneLoader.Load(SceneId.LoadProgress);
    }
  }
}