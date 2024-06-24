using Gameplay.GameLoop.StateMachines;
using Infrastructure;
using Infrastructure.SceneInstallers.GameLoop;
using Infrastructure.StateMachines;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay.GameLoop
{
  public class GameLoopFinishWindow : Window
  {
    [SerializeField] private Button _finishButton;

    private UserIntefaceOperator _uiOperator;
    private MainCanvasRoot _root;
    private StateMachine _stateMachine;

    [Inject]
    private void Construct(UserIntefaceOperator uiOperator, MainCanvasRoot root, StateMachine stateMachine)
    {
      _uiOperator = uiOperator;
      _root = root;
      _stateMachine = stateMachine;
    }

    protected override void OnAwake()
    {
      base.OnAwake();

      foreach (Button button in CloseButtons)
        button.onClick.AddListener(() => _stateMachine.Enter<ChooseAnswerState, bool>(false));

      _finishButton.onClick.AddListener(() =>
      {
        _uiOperator.SlideToRight(_root.GameLoopFinishWindow, _root.AnimationDuration, _root.Width,
          () => _uiOperator.Disable(_root.GameLoopFinishWindow));

        _uiOperator.SlideToRight(_root.GameLoopHeadsUpDisplay, _root.AnimationDuration, _root.Width,
          () => _uiOperator.Disable(_root.GameLoopHeadsUpDisplay));

        _stateMachine.Enter<MainMenuState>();
      });
    }
  }
}