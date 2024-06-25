using Gameplay;
using UnityEngine;
using UserInterface.AnswerButtons;
using Zenject;

namespace UserInterface
{
  public class CorrectAnswerColorSwitcher : MonoBehaviour
  {
    [SerializeField] private AnswerIndexHolder _answerIndexHolder;
    [SerializeField] private GameObject _gameObject;

    [Inject] private GameMatchStateProvider _gameMatchStateProvider;
    [Inject] private CurrentPlayerAnswerIndexHolder _currentPlayerAnswerIndexHolder;
    [Inject] private CurrentQuestionProvider _currentQuestionProvider;

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
        if (_answerIndexHolder.Index.Value == 0)
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