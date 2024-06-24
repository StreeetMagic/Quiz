using Infrastructure.SceneInstallers.GameLoop;
using Infrastructure.StateMachines;

namespace Gameplay.GameLoop.StateMachines
{
  public class ReturnToMainMenuState : IState
  {
    private readonly UserIntefaceOperator _uiOperator;
    private readonly MainCanvasRoot _root;

    public ReturnToMainMenuState(UserIntefaceOperator uiOperator, MainCanvasRoot root)
    {
      _uiOperator = uiOperator;
      _root = root;
    }

    public void Enter()
    {
      _uiOperator
        .PlaceRight(_root.GameLoopFinishWindow, _root.Width)
        .Enable(_root.GameLoopFinishWindow)
        .SlideFromRight(_root.GameLoopFinishWindow, _root.AnimationDuration);
    }

    public void Exit()
    {
    }
  }
}