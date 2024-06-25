using System;
using Gameplay;
using UnityEngine;
using UnityEngine.UI;
using UserInterface.AnswerButtons;
using Zenject;

namespace UserInterface
{
  public class BotIconSwitcher : MonoBehaviour
  {
    [SerializeField] private AnswerIndexHolder _answerIndexHolder;
    [SerializeField] private GameObject _robotIcon;
    [SerializeField] private Image _background;

    [Inject] private BotAnswerProvider _botAnswerProvider;
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
      if (state == GameMatchStateId.AnswerChoosen)
      {
        if (_answerIndexHolder.Index.Value == _botAnswerProvider.Index.Value)
        {
          _robotIcon.SetActive(true);
          _background.enabled = true;
        }
      }
      else
      {
        _robotIcon.SetActive(false);
        _background.enabled = false;
      }
    }
  }
}