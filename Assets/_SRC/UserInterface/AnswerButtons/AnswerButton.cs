using System;
using Gameplay;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UserInterface.AnswerButtons
{
  public class AnswerButton : MonoBehaviour
  {
    [SerializeField] private Button _button;
    [SerializeField] private AnswerIndexHolder _answerIndexHolder;

    [Inject] private CurrentPlayerAnswerIndexHolder _currentPlayerAnswerIndexHolder;
    [Inject] private GameMatchStateProvider _gameMatchStateProvider;

    private void Awake()
    {
      _button.onClick.AddListener(() =>
      {
        if (_gameMatchStateProvider.CurrentState.Value != GameMatchStateId.ChooseAnswer)
          return;

        _currentPlayerAnswerIndexHolder.Index.Value = _answerIndexHolder.Index.Value;
        _gameMatchStateProvider.CurrentState.Value = GameMatchStateId.AnswerChoosen;
      });
    }

    private void OnEnable()
    {
      SwitchInterraction(_gameMatchStateProvider.CurrentState.Value);
      _gameMatchStateProvider.CurrentState.ValueChanged += SwitchInterraction;
    }
    
    private void OnDisable()
    {
      _gameMatchStateProvider.CurrentState.ValueChanged -= SwitchInterraction;
    }

    private void SwitchInterraction(GameMatchStateId state)
    {
      _button.interactable = state == GameMatchStateId.ChooseAnswer;
    }
  }
}