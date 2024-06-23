using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Infrastructure.LoadingCurtains
{
  public class LoadingCurtain : MonoBehaviour
  {
    public CanvasGroup Curtain;

    public void Show()
    {
      gameObject.SetActive(true);
      Curtain.alpha = 1;
    }
    
    public void Hide()
    {
      DoFadeIn().Forget();
    }

    private async UniTaskVoid DoFadeIn()
    {
      while (Curtain.alpha > 0)
      {
        Curtain.alpha -= 0.03f;
        await UniTask.Delay(30);
      }
      
      gameObject.SetActive(false);
    }
  }
}