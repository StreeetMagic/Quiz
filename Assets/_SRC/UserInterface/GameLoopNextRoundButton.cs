using Gameplay;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameLoopNextRoundButton : MonoBehaviour
{
  [SerializeField] private Button _button;

  [Inject] private GameMatchStateProvider _gameMatchStateProvider;
  [Inject] private GameMatchProvider _gameMatchProvider;
  [Inject] private CurrentQuestionProvider _currentQuestionProvider;

  private void Awake()
  {
    _button.onClick.AddListener(() =>
    {
      _gameMatchProvider.Instance.Value.Questions.Dequeue();
      _currentQuestionProvider.QuestionChanged();
      _gameMatchStateProvider.CurrentState.Value = GameMatchStateId.ChooseAnswer;
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
}