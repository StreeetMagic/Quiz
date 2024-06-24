using Gameplay.GameLoop.StateMachines;
using Infrastructure.StateMachines;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay.GameLoop
{
  public class MainMenuExitButton : MonoBehaviour
  {
    [SerializeField] private Button _button;

    [Inject] private StateMachine _stateMachine;

    private void Awake()
    {
      _button.onClick.AddListener(() =>
      {
        if (_stateMachine.ActiveState is not MainMenuState)
          return;

        _stateMachine.Enter<ExitMainMenuState>();
      });
    }
  }
}