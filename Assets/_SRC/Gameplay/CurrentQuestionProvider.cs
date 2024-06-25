using System;

namespace Gameplay
{
  public class CurrentQuestionProvider
  {
    private readonly GameMatchProvider _gameMatchProvider;

    public CurrentQuestionProvider(GameMatchProvider gameMatchProvider)
    {
      _gameMatchProvider = gameMatchProvider;

      _gameMatchProvider.Instance.ValueChanged += OnGameMatchChanged;
    }

    public event Action<Question> Changed;

    public Question GetCurrentQuestion => _gameMatchProvider.Instance.Value.Questions.Value.Peek();

    private void OnGameMatchChanged(GameMatch match)
    {
      Changed?.Invoke(match.Questions.Value.Peek());
    }
  }
}