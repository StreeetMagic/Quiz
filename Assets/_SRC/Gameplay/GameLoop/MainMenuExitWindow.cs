using Gameplay.GameLoop.StateMachines;
using Infrastructure;
using Infrastructure.StateMachines;
using Zenject;

namespace Gameplay.GameLoop
{
  public class MainMenuExitWindow : Window
  {
    private StateMachine _stateMachine;

    [Inject]
    private void Construct(StateMachine stateMachine)
    {
      _stateMachine = stateMachine;
    }

    private void OnDisable()
    {
      _stateMachine.Enter<MainMenuState>();
    }
  }
}