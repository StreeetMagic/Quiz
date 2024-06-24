using Infrastructure.SceneInstallers.GameLoop;
using Infrastructure.StateMachines;
using UnityEngine.UI;

namespace Gameplay.GameLoop.StateMachines
{
  public class ExitMainMenuState : IState
  {
    private readonly UserIntefaceOperator _uiOperator;
    private readonly MainCanvasRoot _root;

    public ExitMainMenuState(UserIntefaceOperator uiOperator, MainCanvasRoot root)
    {
      _uiOperator = uiOperator;
      _root = root;
    }

    public void Enter()
    {
      _uiOperator
        .Enable(_root.MainMenuExitWindow)
        .ScaleFromTo(_root.MainMenuExitWindow, 0, 1, _root.AnimationDuration);

      var image = _root.MainMenuFade.GetComponent<Image>();

      _uiOperator
        .DisableAlpha(image)
        .Enable(_root.MainMenuFade)
        .FadeAlphaTo(image, _root.AnimationDuration, _root.FadeValue);
    }

    public void Exit()
    {
      var image = _root.MainMenuFade.GetComponent<Image>();

      _uiOperator
        .DisableAlpha(image)
        .Disable(_root.MainMenuFade);
    }
  }
}