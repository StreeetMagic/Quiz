using Infrastructure.SceneLoaders;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay.MainMenu
{
  public class EnterGameLoopButton : MonoBehaviour
  {
    [SerializeField] private Button _button;

    private SceneLoader _sceneLoader;
  
    [Inject] private void Construct(SceneLoader sceneLoader)
    {
      _sceneLoader = sceneLoader;
    }

    private void Awake()
    {
      _button.onClick.AddListener(() => _sceneLoader.Load(SceneId.GameLoop));
    }
  }
}