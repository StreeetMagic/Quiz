using Infrastructure.LoadingCurtains;
using UnityEngine;
using Zenject;

namespace Infrastructure.SceneInstallers.GameLoop
{
  public class GameLoopInitializer : MonoBehaviour, IInitializable
  {
    [Inject] private LoadingCurtain _loadingCurtain;

    public void Initialize()
    {
      _loadingCurtain.Hide();
    }
  }
}