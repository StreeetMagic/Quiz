using Utilities;

namespace Gameplay
{
  public class PlayerAnswerProvider
  {
    public PlayerAnswerProvider(GameMatchStateProvider gameMatchStateProvider)
    {
      gameMatchStateProvider.CurrentState.ValueChanged += OnStateChanged;
    }

    private void OnStateChanged(GameMatchStateId state)
    {
      if (state == GameMatchStateId.CreateMatch)
        Reset();
    }

    public ReactiveProperty<int> CorrectAnswers { get; } = new();
    public ReactiveProperty<int> WrongAnswers { get; } = new();

    public void Reset()
    {
      CorrectAnswers.Value = 0;
      WrongAnswers.Value = 0;
    }
  }
}