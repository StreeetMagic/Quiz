using System;
using Gameplay;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface
{
  public class RobotIconSwitcher : MonoBehaviour
  {
    [SerializeField] private GameObject _robotIcon;
    [SerializeField] private Image _background;

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
        _robotIcon.SetActive(false);
        _background.enabled = false;
      }
      else
      {
        _robotIcon.SetActive(true);
        _background.enabled = true;
      }
    }
  }
}