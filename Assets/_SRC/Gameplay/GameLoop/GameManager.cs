using Infrastructure.SceneInstallers.GameLoop;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay.GameLoop
{
  public class GameManager : IInitializable
  {
    private readonly UserIntefaceOperator _uiOperator;
    private readonly MainCanvasRoot _root;

    public GameManager(UserIntefaceOperator userIntefaceOperator, MainCanvasRoot mainCanvasRoot)
    {
      _uiOperator = userIntefaceOperator;
      _root = mainCanvasRoot;
    }

    public void Initialize()
    {
      _root.DisableAll();
      EnterMainMenu();
    }

    private void EnterMainMenu()
    {
      _uiOperator.Enable(_root.MainMenuHeadsUpDisplay);
    }

    public void EnterGameLoop()
    {
      RectTransform hud = _root.GameLoopHeadsUpDisplay;

      _uiOperator
        .PlaceRight(hud, _root.Width)
        .Enable(hud)
        .SlideFromRight(hud, _root.AnimationDuration);
    }

    public void OpenMainMenuExitButtonWindow()
    {
      _uiOperator
        .Enable(_root.MainMenuExitWindow)
        .ScaleFromTo(_root.MainMenuExitWindow, 0, 1, _root.AnimationDuration);
    }

    public void EnableMainMenuFade()
    {
      var image = _root.MainMenuFade.GetComponent<Image>();

      _uiOperator
        .DisableAlpha(image)
        .Enable(_root.MainMenuFade)
        .FadeAlphaTo(image, _root.AnimationDuration, _root.FadeValue);
    }

    public void DisableMainMenuFade()
    {
      var image = _root.MainMenuFade.GetComponent<Image>();

      _uiOperator
        .DisableAlpha(image)
        .Disable(_root.MainMenuFade);
    }

    public void OpenGameLoopFinishWindow()
    {
      _uiOperator
        .PlaceRight(_root.GameLoopFinishWindow, _root.Width)
        .Enable(_root.GameLoopFinishWindow)
        .SlideFromRight(_root.GameLoopFinishWindow, _root.AnimationDuration);
    }

    public void FinishGameLoop()
    {
      _uiOperator.SlideToRight(_root.GameLoopFinishWindow, _root.AnimationDuration, _root.Width,
        () => _uiOperator.Disable(_root.GameLoopFinishWindow));

      _uiOperator.SlideToRight(_root.GameLoopHeadsUpDisplay, _root.AnimationDuration, _root.Width,
        () => _uiOperator.Disable(_root.GameLoopHeadsUpDisplay));
    }
  }
}