using Gameplay;
using UnityEngine;
using Zenject;

namespace UserInterface
{
  public class BotClockSwitcher : MonoBehaviour
  {
    [SerializeField] private GameObject _gameObject;

    [Inject] private GameMatchStateProvider _gameMatchStateProvider;

    private void OnEnable()
    {
      SwitchIcon(_gameMatchStateProvider.CurrentState.Value);
      _gameMatchStateProvider.CurrentState.ValueChanged += SwitchIcon;
    }

    private void OnDisable()
    {
      _gameMatchStateProvider.CurrentState.ValueChanged -= SwitchIcon;
    }

    private void SwitchIcon(GameMatchStateId state)
    {
      if (state != GameMatchStateId.AnswerChoosen)
      {
        _gameObject.SetActive(false);
      }
      else
      {
        _gameObject.SetActive(true);
      }
    }
  }
}