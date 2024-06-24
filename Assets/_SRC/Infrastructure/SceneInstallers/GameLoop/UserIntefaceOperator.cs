using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.SceneInstallers.GameLoop
{
  public class UserIntefaceOperator
  {
    public UserIntefaceOperator Enable(RectTransform element)
    {
      element.gameObject.SetActive(true);

      return this;
    }

    public UserIntefaceOperator Disable(RectTransform element)
    {
      element.gameObject.SetActive(false);

      return this;
    }

    public UserIntefaceOperator PlaceRight(RectTransform element, float offset)
    {
      element.anchoredPosition = new Vector2(offset, 0);

      return this;
    }

    public UserIntefaceOperator SlideFromRight(RectTransform element, float duration)
    {
      element
        .DOAnchorPosX(0, duration)
        .SetEase(Ease.OutQuad);

      return this;
    }

    public UserIntefaceOperator SlideToRight(RectTransform element, float duration, float offset, Action onComplete = null)
    {
      element
        .DOAnchorPosX(offset, duration)
        .SetEase(Ease.OutQuad)
        .OnComplete(() => onComplete?.Invoke());

      return this;
    }

    public UserIntefaceOperator DisableAlpha(Image image)
    {
      image.color = new Color(image.color.r, image.color.g, image.color.b, 0);

      return this;
    }

    public UserIntefaceOperator FadeAlphaTo(Image image, float duration, float value)
    {
      image.DOFade(value, duration);

      return this;
    }

    public UserIntefaceOperator ScaleFromTo(RectTransform element, float from, float to, float duration)
    {
      element.localScale = new Vector3(from, from, from);

      element
        .DOScale(to, duration)
        .SetEase(Ease.OutQuad);

      return this;
    }
  }
}