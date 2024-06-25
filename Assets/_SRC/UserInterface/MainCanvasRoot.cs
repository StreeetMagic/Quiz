using System;
using UnityEngine;

namespace UserInterface
{
  public class MainCanvasRoot : MonoBehaviour
  {
    [field: SerializeField] public RectTransform MainMenuHeadsUpDisplay { get; private set; }
    [field: SerializeField] public RectTransform MainMenuFade { get; private set; }
    [field: SerializeField] public RectTransform MainMenuExitWindow { get; private set; }
    [field: SerializeField] public RectTransform GameLoopHeadsUpDisplay { get; private set; }
    [field: SerializeField] public RectTransform GameLoopNextRoundButton { get; private set; }
    [field: SerializeField] public RectTransform GameLoopFinishWindow { get; private set; }
    [field: SerializeField] public RectTransform GameLoopWinPanel { get; private set; }
    [field: SerializeField] public RectTransform GameLoopLosePanel { get; private set; }

    public float Width => MainMenuHeadsUpDisplay.rect.width;
    public float FadeValue => .9f;
    public float AnimationDuration => .3f;

    private RectTransform[] _allObjects;

    private void Awake()
    {
      _allObjects = new RectTransform[]
      {
        MainMenuHeadsUpDisplay,
        MainMenuFade,
        MainMenuExitWindow,
        GameLoopHeadsUpDisplay,
        GameLoopNextRoundButton,
        GameLoopFinishWindow,
        GameLoopWinPanel,
        GameLoopLosePanel
      };

      foreach (RectTransform serializedObject in _allObjects)
      {
        if (!serializedObject)
          throw new Exception($"RectTransform не назначен в инспекторе");
      }
    }

    public void DisableAll()
    {
      foreach (RectTransform rectTransform in _allObjects)
        rectTransform.gameObject.SetActive(false);
    }
  }
}