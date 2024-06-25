using Gameplay;
using Infrastructure.SceneInstallers.GameLoop;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface
{
  public class EnterGameLoopButton : MonoBehaviour
  {
    [SerializeField] private Button _button;

    private UserIntefaceOperator _uiOperator;
    private MainCanvasRoot _root;
    private GameMatchStateProvider _gameMatchStateProvider;
    
    [Inject]
    public void Construct(UserIntefaceOperator uiOperator, MainCanvasRoot root, GameMatchStateProvider gameMatchStateProvider)
    {
      _uiOperator = uiOperator;
      _root = root;
      _gameMatchStateProvider = gameMatchStateProvider;
    }

    private void Awake()
    {
      _button.onClick.AddListener(() =>
      {
        _gameMatchStateProvider.CurrentState.Value = GameMatchStateId.CreateMatch;
        _gameMatchStateProvider.CurrentState.Value = GameMatchStateId.ChooseAnswer;
        
        RectTransform hud = _root.GameLoopHeadsUpDisplay;

        _uiOperator
          .PlaceRight(hud, _root.Width)
          .Enable(hud)
          .SlideFromRight(hud, _root.AnimationDuration);

        _uiOperator
          .DisableAlpha(_root.MainMenuFade.GetComponent<Image>())
          .Disable(_root.MainMenuFade);

        _uiOperator
          .Enable(_root.GameLoopNextRoundButton);
      });
    }
  }
}