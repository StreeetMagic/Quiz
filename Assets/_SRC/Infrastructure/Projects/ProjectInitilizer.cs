using Infrastructure.SceneLoaders;
using UnityEngine;
using Zenject;

namespace Infrastructure.Projects
{
  public class ProjectInitializer : MonoBehaviour, IInitializable
  {
    [Inject] private SceneLoader _sceneLoader;

    public void Initialize()
    {
      _sceneLoader.Load(SceneId.LoadConfigs);
    }
  }
}