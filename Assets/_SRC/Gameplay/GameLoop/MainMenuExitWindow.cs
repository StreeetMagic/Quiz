using System;
using Infrastructure;
using Zenject;

namespace Gameplay.GameLoop
{
  public class MainMenuExitWindow : Window
  {
    [Inject] private GameManager _gameManager;
    
    private void OnEnable()
    {
      _gameManager.EnableMainMenuFade();
    }

    private void OnDisable()
    {
      _gameManager.DisableMainMenuFade();
    }
  }
}