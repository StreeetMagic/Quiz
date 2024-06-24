using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure
{
  public abstract class Window : MonoBehaviour
  {
    [SerializeField] protected Button[] CloseButtons;

    private void Awake() =>
      OnAwake();

    private void Start()
    {
      Initialize();
      SubscribeUpdates();
    }

    private void OnDestroy() =>
      Cleanup();

    protected virtual void OnAwake()
    {
      foreach (Button button in CloseButtons)
        button.onClick.AddListener(() => gameObject.SetActive(false));
    }

    protected virtual void Initialize() { }
    protected virtual void SubscribeUpdates() { }
    protected virtual void Cleanup() { }
  }
}