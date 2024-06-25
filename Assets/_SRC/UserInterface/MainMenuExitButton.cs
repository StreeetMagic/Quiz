using Infrastructure.SceneInstallers.GameLoop;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface
{
  public class MainMenuExitButton : MonoBehaviour
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
          .Enable(_root.MainMenuExitWindow)
          .ScaleFromTo(_root.MainMenuExitWindow, 0, 1, _root.AnimationDuration);

        var image = _root.MainMenuFade.GetComponent<Image>();

        _uiOperator
          .DisableAlpha(image)
          .Enable(_root.MainMenuFade)
          .FadeAlphaTo(image, _root.AnimationDuration, _root.FadeValue);
      });
    }
  }
}