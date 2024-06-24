using System;
using UnityEngine;

namespace Gameplay.GameLoop
{
  public class MainCanvasRoot : MonoBehaviour
  {
    [field: SerializeField] public RectTransform MainMenuHeadsUpDisplay { get; private set; }
    [field: SerializeField] public RectTransform MainMenuExitWindow { get; private set; }
    [field: SerializeField] public RectTransform MainMenuFade { get; private set; }
    [field: SerializeField] public RectTransform GameLoopHeadsUpDisplay { get; private set; }
    [field: SerializeField] public RectTransform GameLoopFinishWindow { get; private set; }

    public float Width => MainMenuHeadsUpDisplay.rect.width;
    public float FadeValue => .9f;
    public float AnimationDuration => .3f;

    //TODO добавлять в массив
    private void Awake()
    {
      if (!MainMenuHeadsUpDisplay
          || !MainMenuExitWindow
          || !MainMenuFade
          || !GameLoopHeadsUpDisplay
          || !GameLoopFinishWindow)
        throw new NullReferenceException("MainCanvasRoot содержит неназначенные поля в инспекторе");
    }

    public void DisableAll()
    {
      MainMenuHeadsUpDisplay.gameObject.SetActive(false);
      MainMenuExitWindow.gameObject.SetActive(false);
      MainMenuFade.gameObject.SetActive(false);

      GameLoopHeadsUpDisplay.gameObject.SetActive(false);
      GameLoopFinishWindow.gameObject.SetActive(false);
    }
  }
}