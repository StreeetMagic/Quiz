using Infrastructure.LoadingCurtains;
using Infrastructure.StateMachines;

namespace Gameplay.GameLoop.StateMachines
{
  public class BootstrapState : IState
  {
    private readonly LoadingCurtain _loadingCurtain;
    private readonly MainCanvasRoot _root;
    private readonly StateMachine _stateMachine;

    public BootstrapState(MainCanvasRoot root,
      LoadingCurtain loadingCurtain, StateMachine stateMachine)
    {
      _root = root;
      _loadingCurtain = loadingCurtain;
      _stateMachine = stateMachine;
    }

    public void Enter()
    {
      _root.DisableAll();
      _stateMachine.Enter<MainMenuState>();
    }

    public void Exit()
    {
      _loadingCurtain.Hide();
    }
  }
}