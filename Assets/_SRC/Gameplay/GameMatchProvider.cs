using Utilities;

namespace Gameplay
{
  public class GameMatchProvider
  {
    public ReactiveProperty<GameMatch> Instance { get; } = new();
  }
}