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
    }

    public event Action<Question> Changed;

    public Question GetCurrentQuestion => _gameMatchProvider.Instance.Value.Questions.Value.Peek();

    public void QuestionChanged()
    {
      Changed?.Invoke(GetCurrentQuestion);
    }
  }
}