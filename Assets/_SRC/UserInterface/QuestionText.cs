using Gameplay;
using TMPro;
using UnityEngine;
using Zenject;

namespace UserInterface
{
  public class QuestionText : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI _text;

    private CurrentQuestionProvider _currentQuestionProvider;
    private GameMatchStateProvider _gameMatchStateProvider;

    [Inject]
    public void Construct(CurrentQuestionProvider currentQuestionProvider, GameMatchStateProvider gameMatchStateProvider)
    {
      _currentQuestionProvider = currentQuestionProvider;
      _gameMatchStateProvider = gameMatchStateProvider;
    }

    private void OnEnable()
    {
      if (_currentQuestionProvider.TryGetCurrentQuestion(out var question))
        DisplayText(question);

      _gameMatchStateProvider.CurrentState.ValueChanged += OnStateChanged;
    }

    private void OnDisable()
    {
      _gameMatchStateProvider.CurrentState.ValueChanged -= OnStateChanged;
    }

    private void DisplayText(Question question)
    {
      _text.text = question.Text;
    }

    private void OnStateChanged(GameMatchStateId state)
    {
      if (_currentQuestionProvider.TryGetCurrentQuestion(out var question))
        DisplayText(question);
    }
  }
}