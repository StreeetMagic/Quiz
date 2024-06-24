using Infrastructure.SceneInstallers.GameLoop;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay.GameLoop
{
  public class MainMenuExitButton : MonoBehaviour
  {
    [SerializeField] private Button _button;
    
    [Inject] private GameManager _gameManager;

    private void Awake()
    {
      _button.onClick.AddListener(() => _gameManager.OpenMainMenuExitButtonWindow());
    }
  }
}