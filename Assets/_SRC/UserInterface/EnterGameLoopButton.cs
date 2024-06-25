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
        RectTransform hud = _root.GameLoopHeadsUpDisplay;

        _uiOperator
          .PlaceRight(hud, _root.Width)
          .Enable(hud)
          .SlideFromRight(hud, _root.AnimationDuration);
        
        var image = _root.MainMenuFade.GetComponent<Image>();

        _uiOperator
          .DisableAlpha(image)
          .Disable(_root.MainMenuFade);
      });
    }
  }
}