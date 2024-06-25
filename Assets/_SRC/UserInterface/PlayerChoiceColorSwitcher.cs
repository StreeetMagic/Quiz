using System;
using Gameplay;
using UnityEngine;
using UserInterface.AnswerButtons;
using Zenject;

namespace UserInterface
{
  public class PlayerChoiceColorSwitcher : MonoBehaviour
  {
    [SerializeField] private AnswerIndexHolder _answerIndexHolder;
    [SerializeField] private GameObject _gameObject;

    [Inject] private GameMatchStateProvider _gameMatchStateProvider;
    [Inject] private CurrentPlayerAnswerIndexHolder _currentPlayerAnswerIndexHolder;

    private void OnEnable()
    {
      Switch(_gameMatchStateProvider.CurrentState.Value);
      _gameMatchStateProvider.CurrentState.ValueChanged += Switch;
    }
    
    private void OnDisable()
    {
      _gameMatchStateProvider.CurrentState.ValueChanged -= Switch;
    }

    private void Switch(GameMatchStateId state)
    {
      if (state != GameMatchStateId.AnswerChoosen)
      {
        _gameObject.SetActive(false);
      }
      else
      {
        if (_answerIndexHolder.Index.Value == _currentPlayerAnswerIndexHolder.Index.Value)
        {
          _gameObject.SetActive(true);
        }
        else
        {
          _gameObject.SetActive(false);
        }
      }
    }
  }
}