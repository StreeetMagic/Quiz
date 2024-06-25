using System;
using System.Collections.Generic;

namespace Gameplay
{
  public class CurrentQuestionProvider
  {
    private readonly GameMatchProvider _gameMatchProvider;

    public CurrentQuestionProvider(GameMatchProvider gameMatchProvider)
    {
      _gameMatchProvider = gameMatchProvider;

      _gameMatchProvider.Instance.ValueChanged += QuestionChanged;
    }

    public event Action<Question> Changed;

    public bool TryGetCurrentQuestion(out Question question)
    {
      if (_gameMatchProvider.Instance.Value.Questions.Value.TryPeek(out question))
        return true;

      question = null;
      return false;
    }

    public void QuestionChanged(GameMatch gameMatch = null)
    {
      if (TryGetCurrentQuestion(out var question))
        Changed?.Invoke(question);
    }
  }
}