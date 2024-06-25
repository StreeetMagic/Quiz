using Gameplay;
using Infrastructure.ConfigProviders;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UserInterface.AnswerButtons;
using Zenject;

namespace UserInterface
{
  public class AnswerText : MonoBehaviour
  {
    [SerializeField] private AnswerIndexHolder answerIndexHolder;
    [SerializeField] private TextMeshProUGUI _text;

    private CurrentQuestionProvider _currentQuestionProvider;

    [Inject]
    public void Construct(CurrentQuestionProvider currentQuestionProvider)
    {
      _currentQuestionProvider = currentQuestionProvider;
    }

    private void OnEnable()
    {
      DisplayText(answerIndexHolder.Index.Value);
      _currentQuestionProvider.Changed += OnChanged;
    }

    private void OnDisable()
    {
      _currentQuestionProvider.Changed -= OnChanged;
    }

    private void OnChanged(Question question)
    {
      DisplayText(answerIndexHolder.Index.Value);
    }

    private void DisplayText(int index)
    {
      if (_currentQuestionProvider.TryGetCurrentQuestion(out var question))
        _text.text = question.Answers[index];
    }
  }
}