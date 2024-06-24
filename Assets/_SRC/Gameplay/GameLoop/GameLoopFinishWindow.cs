using Infrastructure;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay.GameLoop
{
  public class GameLoopFinishWindow : Window
  {
    [SerializeField] private Button _finishButton;

    [Inject] private GameManager _gameManager;
    
    private void Awake()
    {
      _finishButton.onClick.AddListener(() => _gameManager.FinishGameLoop());
    }
  }
}