using System.Collections.Generic;
using Utilities;

namespace Gameplay
{
  public class GameMatch
  {
    public ReactiveQueue<Question> Questions { get; set; }
    public ReactiveProperty<int> Rounds { get; } = new();

    public GameMatch(IEnumerable<Question> questions, GameMatchStateProvider gameMatchStateProvider)
    {
      gameMatchStateProvider.CurrentState.ValueChanged += OnStateChanged;

      Questions = new ReactiveQueue<Question>(questions);
    }

    private void OnStateChanged(GameMatchStateId state)
    {
      if (state == GameMatchStateId.CreateMatch)
        Rounds.Value = 0;
      else if (state == GameMatchStateId.ChooseAnswer)
        Rounds.Value++;
    }
  }
}