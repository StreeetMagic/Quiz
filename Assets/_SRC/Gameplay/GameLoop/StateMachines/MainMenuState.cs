using Infrastructure.SceneInstallers.GameLoop;
using Infrastructure.StateMachines;

namespace Gameplay.GameLoop.StateMachines
{
  public class MainMenuState : IState
  {
    private readonly UserIntefaceOperator _uiOperator;
    private readonly MainCanvasRoot _root;

    public MainMenuState(UserIntefaceOperator uiOperator, MainCanvasRoot root)
    {
      _uiOperator = uiOperator;
      _root = root;
    }

    public void Enter()
    {
      _uiOperator.Enable(_root.MainMenuHeadsUpDisplay);
    }

    public void Exit()
    {
    }
  }
}