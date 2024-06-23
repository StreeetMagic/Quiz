using System.Collections;
using UnityEngine;

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
      Debug.Log("Curtain Hide");
      
      StartCoroutine(DoFadeIn());
    }

    private IEnumerator DoFadeIn()
    {
      Debug.Log("Curtain DoFadeIn"); 
      
      while (Curtain.alpha > 0)
      {
        Curtain.alpha -= 0.03f;
        yield return new WaitForSeconds(0.03f);
        
        Debug.Log("Curtain DoFadeIn " + Curtain.alpha); 
      }
      
      Debug.Log("Curtain DoFadeIn " + Curtain.alpha);
      
      gameObject.SetActive(false);
    }
  }
}