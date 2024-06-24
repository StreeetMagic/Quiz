using Infrastructure.SceneInstallers.GameLoop;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Gameplay.GameLoop
{
  public class GameLoopOpenFinishButton : MonoBehaviour
  {
    [SerializeField] private Button _button;

    private UserIntefaceOperator _uiOperator;
    private MainCanvasRoot _root;
    
    [Inject]
    public void Construct(UserIntefaceOperator uiOperator, MainCanvasRoot root)
    {
      _uiOperator = uiOperator;
      _root = root;
    }

    private void Awake()
    {
      _button.onClick.AddListener(() =>
      {
        _uiOperator
          .PlaceRight(_root.GameLoopFinishWindow, _root.Width)
          .Enable(_root.GameLoopFinishWindow)
          .SlideFromRight(_root.GameLoopFinishWindow, _root.AnimationDuration);
      });
    }
  }
}