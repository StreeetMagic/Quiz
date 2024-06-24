using Gameplay.GameLoop;
using Infrastructure.StateMachines;
using UnityEngine;

namespace Infrastructure.SceneInstallers.GameLoop
{
  public class ChooseAnswerState : IPayloadedState<bool>

  {
    private readonly UserIntefaceOperator _uiOperator;
    private readonly MainCanvasRoot _root;

    public ChooseAnswerState(UserIntefaceOperator uiOperator, MainCanvasRoot root)
    {
      _uiOperator = uiOperator;
      _root = root;
    }

    public void Enter(bool fromMainMenu)
    {
      if (fromMainMenu == false)
        return;

      RectTransform hud = _root.GameLoopHeadsUpDisplay;

      _uiOperator
        .PlaceRight(hud, _root.Width)
        .Enable(hud)
        .SlideFromRight(hud, _root.AnimationDuration);
    }

    public void Exit()
    {
    }
  }
}