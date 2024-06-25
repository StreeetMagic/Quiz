using Gameplay;
using UnityEngine;
using UnityEngine.UI;
using UserInterface.AnswerButtons;
using Zenject;

namespace UserInterface
{
  public class GameLoopNextRoundButton : MonoBehaviour
  {
    [SerializeField] private Button _button;

    [Inject] private GameMatchStateProvider _gameMatchStateProvider;
    [Inject] private GameMatchProvider _gameMatchProvider;
    [Inject] private CurrentQuestionProvider _currentQuestionProvider;
    [Inject] private CurrentPlayerAnswerIndexHolder _currentPlayerAnswerIndexHolder;

    private void Awake()
    {
      _button.onClick.AddListener(() =>
      {
        if (_gameMatchProvider.Instance.Value.Questions.Value.TryPeek(out _) == false)
        {
          Lose();
          return;
        }
        
        if (_currentPlayerAnswerIndexHolder.Index.Value == 0)
        {
          Continue();
        }
        else if (_gameMatchProvider.Instance.Value.Rounds.Value == 5)
        {
          Win();
        }
      });
    }

    private void OnEnable()
    {
      OnStateChanged(_gameMatchStateProvider.CurrentState.Value);
      _gameMatchStateProvider.CurrentState.ValueChanged += OnStateChanged;
    }

    private void OnDisable()
    {
      _gameMatchStateProvider.CurrentState.ValueChanged -= OnStateChanged;
    }

    private void OnStateChanged(GameMatchStateId state)
    {
      _button.gameObject.SetActive(state == GameMatchStateId.AnswerChoosen);
    }

    private void Win()
    {
      Debug.Log("Win");
    }

    private void Lose()
    {
      Debug.Log("Lose");
    }

    private void Continue()
    {
      _gameMatchProvider.Instance.Value.Questions.Dequeue();
      _currentQuestionProvider.QuestionChanged();
      _gameMatchStateProvider.CurrentState.Value = GameMatchStateId.ChooseAnswer;
    }
  }
}