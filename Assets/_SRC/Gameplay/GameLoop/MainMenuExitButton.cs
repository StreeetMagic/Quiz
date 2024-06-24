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

    private StateMachine _stateMachine;

    [Inject]
    private void Construct(StateMachine stateMachine)
    {
      _stateMachine = stateMachine;
    }

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