using Gameplay;
using UnityEngine;
using UserInterface.AnswerButtons;
using Zenject;

namespace UserInterface
{
  public class PlayerClockSwitcher : MonoBehaviour
  {
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private AnswerIndexHolder _answerIndexHolder;

    [Inject] private CurrentPlayerAnswerIndexHolder _currentPlayerAnswerIndexHolder;
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
        if (_answerIndexHolder.Index.Value == _currentPlayerAnswerIndexHolder.Index.Value)
          _gameObject.SetActive(true);
      }
      else
      {
        _gameObject.SetActive(false);
      }
    }
  }
}