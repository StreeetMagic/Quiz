using Infrastructure.LoadingCurtains;
using Infrastructure.SceneLoaders;
using UnityEngine;
using Zenject;

namespace Infrastructure.Projects
{
  public class ProjectInitializer : MonoBehaviour, IInitializable
  {
    [Inject] private SceneLoader _sceneLoader;
    [Inject] private LoadingCurtain _loadingCurtain;

    public void Initialize()
    {
      _loadingCurtain.Show();
      _sceneLoader.Load(SceneId.LoadConfigs);
    }
  }
}