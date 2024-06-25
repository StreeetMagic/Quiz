using Infrastructure;
using Infrastructure.SceneInstallers.GameLoop;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface
{
  public class GameLoopFinishWindow : Window
  {
    [SerializeField] private Button _finishButton;

    private UserIntefaceOperator _uiOperator;
    private MainCanvasRoot _root;

    [Inject]
    private void Construct(UserIntefaceOperator uiOperator, MainCanvasRoot root)
    {
      _uiOperator = uiOperator;
      _root = root;
    }

    protected override void OnAwake()
    {
      base.OnAwake();

      _finishButton.onClick.AddListener(() =>
      {
        _uiOperator.SlideToRight(_root.GameLoopFinishWindow, _root.AnimationDuration, _root.Width,
          () => _uiOperator.Disable(_root.GameLoopFinishWindow));

        _uiOperator.SlideToRight(_root.GameLoopHeadsUpDisplay, _root.AnimationDuration, _root.Width,
          () => _uiOperator.Disable(_root.GameLoopHeadsUpDisplay));
      });
    }
  }
}